using JobListing.BLL;
using JobListing.Entities;
using JobListing.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobListing.UI.Controllers
{
    public class HomeController : Controller
    {
        JobService _jobs;
        public HomeController()
        {
            _jobs = new JobService();
        }
        // GET: Home
        public ActionResult Index()
        {
            var indexModel = new HomeIndexVM();
            indexModel.Jobs = _jobs.GetAll().OrderByDescending(x => x.JobId).Take(6).Select(x => new JobListVM()
            {
                JobId = x.JobId,
                Title = x.Title,
                Salary = x.SalaryMin+"-"+x.SalaryMax,
                Descripton = x.JobDescriptionBody,
                Address = x.Company.Address,
                CompanyName = x.Company.CompanyName,
                CompanyLogo = x.Company.Logo,
                JobNature = x.JobNature.ToString()
            }).ToList();
            indexModel.Categories = new ServiceBase<Category>().GetAll().ToList();
            indexModel.Cities = new ServiceBase<City>().GetAll().ToList();
            return View(indexModel);
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}