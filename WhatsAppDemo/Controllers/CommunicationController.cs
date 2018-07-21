using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WhatsAppDemo.Controllers
{
    public class CommunicationController : Controller
    {
        // GET: Communication
        public ActionResult Index()
        {
            return View();
        }

        // GET: Communication/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Communication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Communication/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Communication/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Communication/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Communication/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Communication/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}