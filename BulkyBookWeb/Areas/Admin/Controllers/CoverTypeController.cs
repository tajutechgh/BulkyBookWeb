﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyBookWeb.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable <CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();

            return View(objCoverTypeList);
        }

        // GET: /<controller>/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /<controller>/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {

                _unitOfWork.CoverType.Add(obj);

                _unitOfWork.Save();

                TempData["success"] = "Cover type added successfully";

                return RedirectToAction("Index");
            }

            return View(obj);


        }

        // GET: /<controller>/Edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var coverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u=>u.Id==id);

            if (coverTypeFromDbFirst == null)
            {
                return NotFound();
            }

            return View(coverTypeFromDbFirst);
        }

        // POST: /<controller>/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);

                _unitOfWork.Save();

                TempData["success"] = "Cover type updated successfully";

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // GET: /<controller>/Delete
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var coverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u=>u.Id==id);

            if (coverTypeFromDbFirst == null)
            {
                return NotFound();
            }

            return View(coverTypeFromDbFirst);
        }

        // POST: /<controller>/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverType.Remove(obj);

            _unitOfWork.Save();

            TempData["success"] = "Cover type deleted successfully";

            return RedirectToAction("Index");
        }
        
    }
}

