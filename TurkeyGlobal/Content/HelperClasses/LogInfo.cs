using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNR.WEBUI.Content.HelperClasses
{
    public class LogInfo
    {
        public string Url { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public string HataMesajı { get; set; }
        public string Tarayici { get; set; }
        public string Dil { get; set; }
    }
}