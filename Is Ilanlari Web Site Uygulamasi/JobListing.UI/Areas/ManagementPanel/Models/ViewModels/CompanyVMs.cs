using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobListing.UI.Areas.ManagementPanel.ViewModels
{
    public class CompanyListVM
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        [UIHint("CompanyLogo")]
        public byte[] Logo { get; set; }
    }
}