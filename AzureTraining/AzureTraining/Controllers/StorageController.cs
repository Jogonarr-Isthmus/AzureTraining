﻿using System.IO;
using System.Web;
using System.Web.Mvc;
using AzureTraining.Services;

namespace AzureTraining.Controllers {
	public class StorageController : Controller {
		private AzureService _azureService;

		public StorageController() {
			_azureService = new AzureService();
		}

		// GET: Storage
		public ActionResult Blobs() {
			var blobs = _azureService.GetFileList();
			return View(blobs);
		}

		// POST: Storage/SaveFile
		[HttpPost]
		public ActionResult SaveFile(HttpPostedFileBase file) {
			if (file != null && file.ContentLength > 0) {
				var fileName = Path.GetFileName(file.FileName);
				_azureService.SaveFileToBlob(fileName, file.InputStream);
			}

			return RedirectToAction("Blobs");
		}

		// GET: Storage/Details/5
		public ActionResult Details(int id) {
			return View();
		}

		// GET: Storage/Create
		public ActionResult Create() {
			return View();
		}

		// POST: Storage/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection) {
			try {
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			} catch {
				return View();
			}
		}

		// GET: Storage/Edit/5
		public ActionResult Edit(int id) {
			return View();
		}

		// POST: Storage/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection) {
			try {
				// TODO: Add update logic here

				return RedirectToAction("Index");
			} catch {
				return View();
			}
		}

		// GET: Storage/Delete/<fileName>
		[HttpGet]
		public ActionResult Delete(string fileName) {
			_azureService.DeleteBlobByName(fileName);

			return RedirectToAction("Blobs");
		}

		// POST: Storage/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection) {
			try {
				// TODO: Add delete logic here

				return RedirectToAction("Blobs");
			} catch {
				return View();
			}
		}
	}
}
