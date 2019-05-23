using JobListing.BLL;
using JobListing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobListing.UI.Areas.ManagementPanel.Controllers
{
    public class JobController : Controller
    {
        JobService _jobs;
        public JobController()
        {
            _jobs = new JobService();
        }
        // GET: ManagementPanel/Job
        public ActionResult Index()
        {
            return View(_jobs.GetAll().ToList());
        }

        // GET: ManagementPanel/Job/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagementPanel/Job/Create
        public ActionResult Create()
        {
            ViewData["CompanyList"] = new CompanyService().GetAll().ToList();
            var model = new Job();
            model.Requirements.Add(new JobRequirement() { RequirementNature = RequirementNatures.Education });
            model.Requirements.Add(new JobRequirement() { RequirementNature = RequirementNatures.Experience });
            model.Requirements.Add(new JobRequirement() { RequirementNature = RequirementNatures.JobFeature });
            return View(model);
        }

        // POST: ManagementPanel/Job/Create
        [HttpPost]
        public ActionResult Create(Job job)
        {
            try
            {
                _jobs.Insert(job);

                return RedirectToAction("Index");
            }
            catch
            {
                //ViewData["CompanyList"] = new CompanyService().GetAll().ToList();
                return View(job);
            }
        }

        // GET: ManagementPanel/Job/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagementPanel/Job/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagementPanel/Job/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagementPanel/Job/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
