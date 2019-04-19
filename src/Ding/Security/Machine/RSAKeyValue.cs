namespace Ding.Security
{
    public class RSAKeyValue
    {
        public string Modulus { get; set; }
        public string Exponent { get; set; }
        public string P { get; set; }
        public string Q { get; set; }
        public string DP { get; set; }
        public string DQ { get; set; }
        public string InverseQ { get; set; }
        public string D { get; set; }
        public System.Security.Cryptography.RSAParameters GetRSAParameters()
        {
            var param = new System.Security.Cryptography.RSAParameters();
            param.Modulus = FromBase64String(Modulus);
            param.Exponent = FromBase64String(Exponent);
            param.P = FromBase64String(P);
            param.DP = FromBase64String(DP);
            param.DQ = FromBase64String(DQ);
            param.InverseQ = FromBase64String(InverseQ);
            param.D = FromBase64String(D);
            return param;
        }

        byte[] FromBase64String(string value)
        {
            if (value == null)
            {
                return null;
            }
            return System.Convert.FromBase64String(value);
        }

    }
}
