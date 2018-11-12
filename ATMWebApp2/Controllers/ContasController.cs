using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATMWebApp.Models;

namespace ATMWebApp.Controllers
{
    public class ContasController : Controller
    {
        List<Conta> contas = Context.Db.Contas;
        // GET: Contas
        public ActionResult Index()
        {
            return View(contas.OrderBy(c => c.PrimeiroNome));
        }

        // GET: Contas/Details/5
        public ActionResult Details(int id)
        {
            var conta = GetConta(contas, id);
            if (conta == null) return RedirectToAction("Index");
            return View(conta);
        }

        // GET: Contas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contas/Create
        [HttpPost]
        public ActionResult Create(Conta conta)
        {
            try
            {
                contas.Add(conta);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contas/Edit/5
        public ActionResult Edit(int id)
        {
            var conta = GetConta(contas, id);
            if (conta == null) return RedirectToAction("Index");

            return View(conta);
        }

        // POST: Contas/Edit/5
        [HttpPost]
        public ActionResult Edit(Conta conta) // uso do modelo
        {
            try
            {
                if (conta == null) return RedirectToAction("Index");
                var conta_to_update = GetConta(contas, conta.Numero);
                if (TryUpdateModel(conta_to_update, "", new string[] { "Apelido", "PrimeiroNome" }))
                    return RedirectToAction("Index");

                return RedirectToAction("Index");
            }
            catch
            {
                return View(conta);
            }
        }

        // GET: Contas/Delete/5
        public ActionResult Delete(int id)
        {
            var conta = GetConta(contas, id);
            if (conta == null) return RedirectToAction("Index");

            return View(conta);
        }

        // POST: Contas/Delete/5
        [HttpPost]
        public ActionResult Delete(Conta conta)
        {
            try
            {
                // TODO: Add delete logic here
                var conta_remover = GetConta(contas, conta.Numero);
                if (conta_remover == null) return RedirectToAction("Index");
                contas.Remove(conta_remover);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(conta);
            }
        }

        [NonAction]
        private Conta GetConta(List<Conta> contas, int? id)
        {
            return contas.Where(c => c.Numero == id).FirstOrDefault();
        }
    }
}