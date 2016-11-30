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
    public class TransactionController : Controller
    {
        private ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        //
        // GET: /Transaction/
        public ActionResult Index()
        {
            var transactions = _transactionService.GetTransactions();
            return View(transactions);
        }

        //
        // GET: /Transaction/
        public ActionResult Edit(int id)
        {
            var transactions = _transactionService.GetTransaction(id);
            return View(transactions);
        }

        [HttpPost]
        public ActionResult Edit(TransactionDto transaction)
        {
            if (ModelState.IsValid)
            {
                _transactionService.UpdateTransaction(transaction);
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // HTTP GET: /Dinners/Delete/1

        public ActionResult Delete(int id)
        {

            var trans = _transactionService.GetTransaction(id);

            if (trans == null)
                return RedirectToAction("Index");
            else
                return View(trans);
        }

        // 
        // HTTP POST: /Dinners/Delete/1

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {

            var trans = _transactionService.GetTransaction(id);

            if (trans == null)
                return RedirectToAction("Index");

            _transactionService.DeleteTransaction(id);

            return RedirectToAction("Index");
        }
    }
}