using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace vs2010.consoleApp.demo
{
   public class Des
    {
        public static string ToDESEncrypt(string encryptString, string sKey)
        {
            try
            {

                byte[] keyBytes = Encoding.UTF8.GetBytes(sKey);
                byte[] keyIV = keyBytes;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);

                DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
                         
                // java 默认的是ECB模式，PKCS5padding；c#默认的CBC模式，PKCS7padding 所以这里我们默认使用ECB方式
                desProvider.Mode = CipherMode.ECB;
                MemoryStream memStream = new MemoryStream();
                CryptoStream crypStream = new CryptoStream(memStream, desProvider.CreateEncryptor(keyBytes, keyIV), CryptoStreamMode.Write);

                crypStream.Write(inputByteArray, 0, inputByteArray.Length);
                crypStream.FlushFinalBlock();
                return Convert.ToBase64String(memStream.ToArray());

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return encryptString;
            }
        }
         public static string ToDESDecrypt(string decryptString, string sKey)
       {
           byte[] keyBytes = Encoding.UTF8.GetBytes(sKey);
           byte[] keyIV = keyBytes;
           byte[] inputByteArray = Convert.FromBase64String(decryptString);
 
           DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();
 
           // java 默认的是ECB模式，PKCS5padding；c#默认的CBC模式，PKCS7padding 所以这里我们默认使用ECB方式
           desProvider.Mode = CipherMode.ECB;
           MemoryStream memStream = new MemoryStream();
           CryptoStream crypStream = new CryptoStream(memStream, desProvider.CreateDecryptor(keyBytes, keyIV), CryptoStreamMode.Write);
 
           crypStream.Write(inputByteArray, 0, inputByteArray.Length);
           crypStream.FlushFinalBlock();
           return Encoding.Default.GetString(memStream.ToArray());
 
       }

    }
}
