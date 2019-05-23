using JobListing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobListing.UI.Models.ViewModels
{
    public class HomeIndexVM
    {
        public List<JobListVM> Jobs { get; set; }
        public List<Category> Categories { get; set; }
        public List<City> Cities { get; set; }
    }
}