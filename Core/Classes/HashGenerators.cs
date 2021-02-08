using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.ComponentModel;

namespace Core.Classes
{
    public static class HashGenerators
    {
        public static string MD5Encoding(string password)
        {
            Byte[] mainbyte;
            Byte[] encodebyte;

            MD5 md5;

            md5 = new MD5CryptoServiceProvider();

            mainbyte = ASCIIEncoding.Default.GetBytes(password);

            encodebyte = md5.ComputeHash(mainbyte);

            return BitConverter.ToString(encodebyte);
        }
    }
}
