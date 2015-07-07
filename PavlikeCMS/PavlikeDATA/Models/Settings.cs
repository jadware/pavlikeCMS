using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavlikeDATA.Models
{
    public class Settings
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string URL { get; set; }
        public string Slogan { get; set; }
        public string DescriptionMetaTags { get; set; }
        public string MetaTags { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string FaxNo { get; set; }
        public int LogoID { get; set; }
        [ForeignKey("LogoID")]
        public File Logo { get; set; }
    }
}
