using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxManagement.Entities;
using TaxManagement.Service;
using TaxManagement.Service.Contracts;

namespace TaxManagement.WebUI.Controllers
{
    public class UploadFileController : Controller
    {
        private ITransactionService _transactionService;

        public UploadFileController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        //
        // GET: /UploadFIle/
        public ActionResult Index()
        {
            var uploadedData = TempData["UploadedData"];
            TempData["UploadedData"] = uploadedData;
            return View(uploadedData);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase uploadedFile)
        {
            var file = Request.Files[0];
            UploadedData uploadedData = null;
            if (file.FileName.EndsWith(".csv"))
            {
                var fileStream = file.InputStream;
                uploadedData = _transactionService.UploadTransactions(fileStream);
            }
            TempData["UploadedData"] = uploadedData;
            return View(uploadedData);
        }
    }
}