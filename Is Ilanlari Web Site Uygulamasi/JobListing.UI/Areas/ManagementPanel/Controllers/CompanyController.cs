using JobListing.BLL;
using JobListing.Entities;
using JobListing.UI.Areas.ManagementPanel.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobListing.UI.Areas.ManagementPanel.Controllers
{
    [Authorize(Roles ="SiteAdmin")]
    public class CompanyController : Controller
    {
        private CompanyService _companies;
        public CompanyController()
        {
            _companies = new CompanyService();
        }
        // GET: ManagementPanel/Company
        public ActionResult Index()
        {
            var cities = new ServiceBase<City>().GetAll().ToList();
            var model = _companies.GetAll().Select(x => new CompanyListVM() {
                CompanyId = x.CompanyId,
                CompanyName = x.CompanyName,
                CityId = x.CityId,
                Logo = x.Logo
            }).ToList();
            foreach (var item in model)
            {
                item.CityName = cities.SingleOrDefault(x => x.CityId == item.CityId).CityName;
            }
            return View(model);
        }

        // GET: ManagementPanel/Company/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManagementPanel/Company/Create
        public ActionResult Create()
        {
            ViewData["CityList"] = new ServiceBase<City>().GetAll().ToList();
            return View();
        }

        // POST: ManagementPanel/Company/Create
        [HttpPost]
        public ActionResult Create(Company company)
        {
            try
            {
                if (Request.Files.Count > 0 && Request.Files["CompanyLogo"].ContentLength > 0)
                {
                    MemoryStream target = new MemoryStream();
                    Request.Files["CompanyLogo"].InputStream.CopyTo(target);
                    company.Logo = target.ToArray();
                }
                _companies.Insert(company);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(company);
            }
        }

        // GET: ManagementPanel/Company/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagementPanel/Company/Edit/5
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

        // GET: ManagementPanel/Company/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagementPanel/Company/Delete/5
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
