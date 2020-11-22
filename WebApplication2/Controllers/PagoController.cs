using BAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers
{
    public class PagoController : Controller
    {

        PagoManager man = new PagoManager();

        [HttpGet]
        public ActionResult Index()
        {
            return View(man.Listar());
        }



        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.Reservas = man.Reservas();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(PagoModelo obj)
        {

            ViewBag.Reservas = man.Reservas();
            man.Crear(obj);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Editar(int id)
        {
            ViewBag.Reservas = man.Reservas();
            var obj = man.Buscar(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Editar(int id, PagoModelo obj)
        {
            ViewBag.Reservas = man.Reservas();
            obj.idreserva = id;
            man.Editar(obj);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Borrar(int id)
        {
            var obj = man.Buscar(id);
            return View(obj);
        }


        [HttpPost]
        public ActionResult Borrar(int id, PagoModelo obj)
        {
            man.Borrar(id);
            return RedirectToAction("Index");
        }
    }
}