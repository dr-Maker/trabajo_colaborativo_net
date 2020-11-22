using BAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers
{
    public class ReservaController : Controller
    {
        ReservaManager man = new ReservaManager();

        [HttpGet]
        public ActionResult Index()
        {
            return View(man.Listar());
        }



        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.Habitaciones = man.Habitaciones();
            ViewBag.Clientes = man.Clientes();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ReservaModelo obj)
        {
            ViewBag.Habitaciones = man.Habitaciones();
            ViewBag.Clientes = man.Clientes();
            man.Crear(obj);
            return RedirectToAction("Index");
        }





        [HttpGet]
        public ActionResult Editar(int id)
        {
            ViewBag.Habitaciones = man.Habitaciones();
            ViewBag.Clientes = man.Clientes();
            var obj = man.Buscar(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Editar(int id, ReservaModelo obj)
        {
            ViewBag.Habitaciones = man.Habitaciones();
            ViewBag.Clientes = man.Clientes();
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
        public ActionResult Borrar(int id,  ReservaModelo obj)
        {
            man.Borrar(id);
            return RedirectToAction("Index");
        }
    }
}