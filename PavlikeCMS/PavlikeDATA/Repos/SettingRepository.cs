using System.Linq;
using PavlikeDATA.Models;

namespace PavlikeDATA.Repos
{
    public class SettingRepository
    {
        private readonly Context _db = new Context();
        public string Title;
        public string Description;
        public string[] MetaTags;
        public string Url;
        public string AdminEmail;
        public string MailServer;
        public int MailPort;
        public string SenderEMail;
        public string SenderPassword;
        public string SenderDisplayName;
        public bool MailServerSsl;
        public Media Logo;
        public int? SliderHeight;
        public int? SliderWidht;

        public SettingRepository()
        {
            var setting = _db.Settings.FirstOrDefault();
            if (setting == null) return;
            Title = setting.Title;
            Description = setting.Description;
            MetaTags = setting.MetaTags.Split(',');
            Url = setting.Url;
            AdminEmail = setting.AdminEmail;
            MailServer = setting.MailServer;
            MailPort = setting.MailPort;
            SenderEMail = setting.SenderEMail;
            SenderPassword = setting.SenderPassword;
            SenderDisplayName = setting.SenderDisplayName;
            MailServerSsl = setting.MailServerSsl;
            Logo = new MediaRepository().FindbyId(setting.LogoId);
            SliderHeight = setting.SliderHeight;
            SliderWidht = setting.SliderWidht;
        }
    }
}
