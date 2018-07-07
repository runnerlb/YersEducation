using CodeCarvings.Piczard;
using System;

namespace Yers.Tests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine("123".CalcMd5());
            //Console.WriteLine(CommonHelper.GenerateCaptchaCode(5));

            #region 邮件发送

            //using (MailMessage mailMessage = new MailMessage())
            //using (SmtpClient smtpClient = new SmtpClient("smtp.163.com"))
            //{
            //    mailMessage.To.Add("lbrunner@126.com");
            //    mailMessage.To.Add("libaodnc@gmail.com");
            //    mailMessage.Body = "邮件正文";
            //    mailMessage.From = new MailAddress("lbrunner@163.com");
            //    mailMessage.Subject = "邮件标题";
            //    smtpClient.Credentials = new System.Net.NetworkCredential("lbrunner@163.com", "123qweasdzxc");//如果启用了“客户端授权码”，要用授权码代替密码
            //    smtpClient.Send(mailMessage);
            //}

            #endregion 邮件发送

            #region 生成缩略图

            ImageProcessingJob job = new ImageProcessingJob();
            job.Filters.Add(new FixedResizeConstraint(200, 200));
            job.SaveProcessedImageToFileSystem(@"G:\私活项目\07微信公众号\优而思校长在线\src\Tests\Yers.AllTests\images\fengjin.jpg", @"G:\私活项目\07微信公众号\优而思校长在线\src\Tests\Yers.AllTests\images\fengjin-new.jpg");

            #endregion 生成缩略图

            #region 测试数据库

            /*
            using (YersDbContext db = new YersDbContext())
            {
                db.Database.Delete();
                db.Database.Create();
            }*/

            #endregion 测试数据库

            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}