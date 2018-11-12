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
        public ActionResult Create(FormCollection collection)
        {
            try
            {   //Creates an account
                var conta = new Conta();

                //Assigns the values coming from the form
                conta.Numero = Int32.Parse(collection["Numero"].ToString());
                conta.PrimeiroNome = collection["PrimeiroNome"].ToString();
                conta.Apelido = collection["Apelido"].ToString();

                //Adds the account to the list of accounts
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
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var conta = GetConta(contas, id);
                if (conta == null) return RedirectToAction("Index");

                conta.PrimeiroNome = collection["PrimeiroNome"].ToString();
                conta.Apelido = collection["Apelido"].ToString();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
        public ActionResult Delete(int id, FormCollection collection)
        //public ActionResult Delete(FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var conta = GetConta(contas, id);
                //var conta = GetConta(contas, Int32.Parse(collection["Numero"].ToString()));
                if (conta == null) return RedirectToAction("Index");
                contas.Remove(conta);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        private Conta GetConta(List<Conta> contas, int? id)
        {
            return contas.Where(c => c.Numero == id).FirstOrDefault();
        }
    }
}