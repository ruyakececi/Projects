using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobListing.UI.Models.ViewModels
{
    public class JobListVM
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string Descripton { get; set; }
        public string Salary { get; set; }
        public byte[] CompanyLogo { get; set; }
        public string Address { get; set; }
        public string JobNature { get; set; }
    }
}