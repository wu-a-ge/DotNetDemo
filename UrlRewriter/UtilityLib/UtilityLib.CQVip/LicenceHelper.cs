using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTLICENCESVCLib;
namespace UtilityLib.CQVip
{
    /// <summary>
    /// LicenceHelper 的摘要说明
    /// </summary>
    public class LicenceHelper
    {
        //公锁
        static byte[] Modulus ={
            214,79,153,226,43,185,106,253,219,26,176,81,214,22,108,35
            ,12,102,67,208,12,172,110,110,51,206,197,62,196,41,159,0
            ,78,48,219,242,43,232,30,38,234,164,73,136,65,39,76,66
            ,144,17,139,166,125,149,123,154,116,76,130,171,99,153,213,188
            ,190,188,43,186,130,218,57,73,199,184,9,247,156,210,128,191
            ,82,27,88,250,78,239,10,137,78,130,118,206,5,176,90,187
            ,7,36,231,43,97,25,190,162,64,145,211,139,190,239,69,52
            ,85,52,45,9,115,105,113,61,230,191,92,206,129,152,253,125};
        static byte[] Exponent = { 1, 0, 1 };
        public static string ExamSystemGuid = "7F6815CE-FEE9-4fa7-A0C0-F2B3490212AC";
        public static string lastErrorInfo = "";
        public static bool hasLicence()
        {
            try
            {
                System.Security.Cryptography.RSACryptoServiceProvider rsa =
                    new System.Security.Cryptography.RSACryptoServiceProvider();

                System.Security.Cryptography.RSAParameters RSAKeyInfo = new System.Security.Cryptography.RSAParameters();
                RSAKeyInfo.Modulus = Modulus;
                RSAKeyInfo.Exponent = Exponent;
                rsa.ImportParameters(RSAKeyInfo);

                System.Security.Cryptography.RijndaelManaged RM = new System.Security.Cryptography.RijndaelManaged();
                byte[] EncryptedSymmetricKey = rsa.Encrypt(RM.Key, true);
                byte[] EncryptedSymmetricIV = rsa.Encrypt(RM.IV, true);
                IClientLicenceClass licence = new IClientLicenceClass();
                Array result;
                licence.LicenceClient(ExamSystemGuid, EncryptedSymmetricKey, EncryptedSymmetricIV, "", out result);

                byte[] byteResult = new byte[result.Length];
                for (int i = 0; i < result.Length; i++)
                    byteResult[i] = (byte)result.GetValue(i);

                //解码返回数据
                string retValue = "";
                //256bit,cbc AES算法
                System.Security.Cryptography.Rijndael aes = System.Security.Cryptography.Rijndael.Create();
                try
                {
                    using (System.IO.MemoryStream mStream = new System.IO.MemoryStream())
                    {
                        using (System.Security.Cryptography.CryptoStream cStream = new System.Security.Cryptography.CryptoStream
                            (mStream, aes.CreateDecryptor(RM.Key, RM.IV), System.Security.Cryptography.CryptoStreamMode.Write)
                            )
                        {
                            cStream.Write(byteResult, 0, result.Length);
                            cStream.FlushFinalBlock();
                            retValue = System.Text.Encoding.Unicode.GetString(mStream.ToArray());
                        }
                    }
                }
                catch (Exception e)
                {
                    lastErrorInfo = e.ToString();
                }
                aes.Clear();
                if (retValue == "T" + ExamSystemGuid)
                    return true;
            }
            catch (Exception e)
            {
                lastErrorInfo = e.ToString();
            }
            return false;
        }
    }
}
