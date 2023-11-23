﻿using TN.DVDCentral.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;

namespace TN.DVDCentral.UI.Controllers
{
    public class DirectorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "List of Directors";
            return View(DirectorManager.Load());
        }
        
        public IActionResult Details(int id) 
        { 
            var item = DirectorManager.LoadById(id);
            ViewBag.Title = "Detais";
            return View(item);
        }

        public IActionResult Create() 
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                ViewBag.Title = "Create";
                return View();
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }

        [HttpPost]
        public IActionResult Create(Director director) 
        {
            try
            {
                int result = DirectorManager.Insert(director);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public IActionResult Edit(int id) 
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = DirectorManager.LoadById(id);
                ViewBag.Title = "Edit";
                return View(item);
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, Director director, bool rollback = false) 
        {
            try
            {
                int result = DirectorManager.Insert(director, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
            
        }

        public IActionResult Delete(int id) 
        {
            if (Authentication.IsAuthenticated(HttpContext))
            {
                var item = DirectorManager.LoadById(id);
                ViewBag.Title = "Delete";
                return View(item);
            }

            else
            {
                return RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
            }
        }
        [HttpPost]
        public IActionResult Delete(int id, Director director, bool rollback = false) 
        {
            try
            {
                int result = DirectorManager.Delete(id, rollback);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(director);
            }
            
        }
    }
}
