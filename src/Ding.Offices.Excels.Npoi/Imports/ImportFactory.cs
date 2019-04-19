using System;
using System.IO;
using Ding.Offices.Excels.Imports;

namespace Ding.Offices.Excels.Npoi.Imports
{
    /// <summary>
    /// 导入器工厂
    /// </summary>
    public class ImportFactory:IImportFactory
    {
        /// <summary>
        /// 文件绝对路径
        /// </summary>
        private readonly string _path;

        /// <summary>
        /// 文件流
        /// </summary>
        private readonly Stream _stream;

        /// <summary>
        /// 工作表名称
        /// </summary>
        private readonly string _sheetName;

        /// <summary>
        /// 初始化一个<see cref="ImportFactory"/>类型的实例
        /// </summary>
        /// <param name="path">导入文件路径，绝对路径</param>
        /// <param name="sheetName">工作表名称</param>
        public ImportFactory(string path, string sheetName = "")
        {
            _path = path;
            _sheetName = sheetName;
        }

        /// <summary>
        /// 初始化一个<see cref="ImportFactory"/>类型的实例
        /// </summary>
        /// <param name="stream">导入的文件流</param>
        /// <param name="sheetName">工作表名称</param>
        public ImportFactory(Stream stream, string sheetName = "")
        {
            _stream = stream;
            _sheetName = sheetName;
        }

        /// <summary>
        /// 创建导入器
        /// </summary>
        /// <param name="version">Excel格式</param>
        /// <returns></returns>
        public IImport Create(ExcelVersion version)
        {
            switch (version)
            {
                case ExcelVersion.Xlsx:
                    return new Excel2003Import(_path,_sheetName);
                case ExcelVersion.Xls:
                    return new Excel2007Import(_path, _sheetName);
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建导入器
        /// </summary>
        /// <param name="version">Excel格式</param>
        /// <returns></returns>
        public IImport CreateStream(ExcelVersion version)
        {
            switch (version)
            {
                case ExcelVersion.Xlsx:
                    return new Excel2003Import(_stream, _sheetName);
                case ExcelVersion.Xls:
                    return new Excel2007Import(_stream, _sheetName);
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建 Excel 2003 导入器
        /// </summary>
        /// <param name="path">导入文件路径，绝对路径</param>
        /// <param name="sheetName">工作表名称</param>
        /// <returns></returns>
        public static IImport CreateExcel2003Import(string path, string sheetName = "")
        {
            return new ImportFactory(path, sheetName).Create(ExcelVersion.Xls);
        }

        /// <summary>
        /// 创建 Excel 2007 导入器
        /// </summary>
        /// <param name="path">导入文件路径，绝对路径</param>
        /// <param name="sheetName">工作表名称</param>
        /// <returns></returns>
        public static IImport CreateExcel2007Import(string path, string sheetName = "")
        {
            return new ImportFactory(path,sheetName).Create(ExcelVersion.Xlsx);
        }

        /// <summary>
        /// 创建 Excel 2003 导入器
        /// </summary>
        /// <param name="stream">导入的文件流</param>
        /// <param name="sheetName">工作表名称</param>
        /// <returns></returns>
        public static IImport CreateExcel2003ImportStream(Stream stream, string sheetName = "")
        {
            return new ImportFactory(stream, sheetName).CreateStream(ExcelVersion.Xls);
        }

        /// <summary>
        /// 创建 Excel 2007 导入器
        /// </summary>
        /// <param name="stream">导入的文件流</param>
        /// <param name="sheetName">工作表名称</param>
        /// <returns></returns>
        public static IImport CreateExcel2007ImportStream(Stream stream, string sheetName = "")
        {
            return new ImportFactory(stream, sheetName).CreateStream(ExcelVersion.Xlsx);
        }
    }
}
