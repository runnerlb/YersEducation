using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Yers.Common
{
    /// <summary>
    /// 通用帮助类
    /// </summary>
    public static class CommonHelper
    {
        /// <summary>
        /// 对字符串进行MD5加密
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string CalcMd5(this string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            return CalcMd5(bytes);
        }

        /// <summary>
        /// 对byte数组进行MD5加密
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <returns>加密后的字符串</returns>
        public static string CalcMd5(byte[] bytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(bytes);
                string result = "";
                foreach (byte t in computeBytes)
                {
                    result += t.ToString("X").Length == 1 ? "0" + t.ToString("X") : t.ToString("X");
                }
                return result;
            }
        }

        /// <summary>
        /// 对stream流进行MD5加密
        /// </summary>
        /// <param name="stream">stream流</param>
        /// <returns>加密后的字符串</returns>
        public static string CalcMd5(Stream stream)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(stream);
                string result = "";
                foreach (byte t in computeBytes)
                {
                    result += t.ToString("X").Length == 1 ? "0" + t.ToString("X") : t.ToString("X");
                }
                return result;
            }
        }

        /// <summary>
        /// 获取验证码字符串
        /// </summary>
        /// <param name="len">验证码长度</param>
        /// <returns>验证码字符串</returns>
        public static string GenerateCaptchaCode(int len)
        {
            char[] data = { 'a', 'c', 'd', 'e', 'f', 'g', 'k', 'm', 'p', 'r', 's', 't', 'w', 'x', 'y', '3', '4', '5', '7', '8' };
            StringBuilder sbCode = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < len; i++)
            {
                char ch = data[rand.Next(data.Length)];
                sbCode.Append(ch);
            }
            return sbCode.ToString();
        }
    }
}