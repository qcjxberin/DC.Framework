using System;
using System.Text;
using System.Management;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using System.Security.Cryptography;
using Ding.Helpers;

namespace Ding.Security
{
    /// <summary>
    /// 机器码操作类
    /// </summary>
    public class RegistrationMachine
    {
        /// <summary>
        /// 获取机器码
        /// </summary>
        /// <returns></returns>
        public static string GetMachineInfo()
        {
            var unique = "";
            // 获取处理器信息
            ManagementClass cimobject = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = cimobject.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                unique += mo.Properties["ProcessorId"].Value.ToString();
            }
            // 获取硬盘ID
            ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            foreach (ManagementObject mo in moc1)
            {
                unique += mo.Properties["Model"].Value;
            }
            // 获取BIOS
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select SerialNumber From Win32_BIOS");
            ManagementObjectCollection moc2 = searcher.Get();
            if (moc2.Count > 0)
            {
                foreach (ManagementObject share in moc2)
                {
                    unique += share["SerialNumber"].ToString();
                }
            }

            #region 获取网卡
            //常量
            const string keyPrefix = @"SYSTEM\CurrentControlSet\Control\Network\{4D36E972-E325-11CE-BFC1-08002BE10318}";
            const string connection = "Connection";
            const string pnpInstanceIdKey = "PnpInstanceID";
            const string pci = "PCI";
            const string wireless = "wireless";
            const string mediaSubTypeKey = "MediaSubType";

            PhysicalAddress physicalAddress = null;
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            #region # 优先物理网卡
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                string registryKeyPath = $@"{keyPrefix}\{networkInterface.Id}\{connection}";
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(registryKeyPath, false);
                string pnpInstanceId = registryKey?.GetValue(pnpInstanceIdKey, string.Empty).ToString();

                //真实网卡
                if (pnpInstanceId != null && pnpInstanceId.Length > 3 && pnpInstanceId.Substring(0, 3) == pci)
                {
                    //物理网卡
                    if (networkInterface.NetworkInterfaceType.ToString().ToLower().IndexOf(wireless, StringComparison.Ordinal) == -1)
                    {
                        physicalAddress = networkInterface.GetPhysicalAddress();
                        break;
                    }
                }
            }
            #endregion

            #region # 次优无线网卡
            if (physicalAddress == null)
            {
                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    string registryKeyPath = $@"{keyPrefix}\{networkInterface.Id}\{connection}";
                    RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(registryKeyPath, false);
                    string pnpInstanceId = registryKey?.GetValue(pnpInstanceIdKey, string.Empty).ToString();

                    //真实网卡
                    if (pnpInstanceId != null && pnpInstanceId.Length > 3 && pnpInstanceId.Substring(0, 3) == pci)
                    {
                        //无线网卡
                        physicalAddress = networkInterface.GetPhysicalAddress();
                        break;
                    }
                }
            }
            #endregion

            #region # 再次虚拟网卡
            if (physicalAddress == null)
            {
                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    string registryKeyPath = $@"{keyPrefix}\{networkInterface.Id}\{connection}";
                    RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(registryKeyPath, false);
                    int? mediaSubType = registryKey == null
                        ? (int?)null
                        : System.Convert.ToInt32(registryKey.GetValue(mediaSubTypeKey, 0));

                    //再次虚拟网卡
                    if (mediaSubType == 1 || mediaSubType == 0)
                    {
                        physicalAddress = networkInterface.GetPhysicalAddress();
                        break;
                    }
                }
            }
            #endregion

            if (physicalAddress != null)
            {
                unique += physicalAddress.ToString();
            }
            #endregion

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            return HexHelper.ByteToHexString(md5.ComputeHash(Encoding.Unicode.GetBytes(unique))).Substring(2, 27);
        }

    }
}
