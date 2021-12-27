using MVCFrameworkNeoris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFrameworkNeoris.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cliente/Details/5
        public ActionResult EditarCli(int id)
        {
            return View();
        }

        public ActionResult ViajesCli(int id)
        {
            DAL.Factura srv = new DAL.Factura();
            return View(srv.getFacturaSegunId(id));
        }

        public ActionResult ListarCliCond()
        {
            var ruta = RouteData.Values["id"] + Request.Url.Query;
            DAL.Cliente srv = new DAL.Cliente();
            ViewBag.Prueba = ruta;
            return View(srv.getClienteSegunCondicion(ruta));
        }

        [HttpPost]
        public ActionResult EditarCli(Cliente c, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAL.Cliente srv = new DAL.Cliente();
                    if (srv.ActClientes(c, id))
                    {
                        ViewBag.Respuesta = "Alta correcta";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Respuesta = "Ha ocurrido un error";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Respuesta = "Ha ocurrido un error:" + ex.Message;

            }

            return View();
        }

        public ActionResult BorrarCli(int id)
        {
            DAL.Cliente srv = new DAL.Cliente();

            return View(srv.borrarCliente(id));
        }

        public ActionResult DatosModeloCli(int id)
        {
            DAL.Cliente srv = new DAL.Cliente();

            return View(srv.getClienteSegunId(id));
        }

        public ActionResult EditarPaq(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditarPaq(Paquete p, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAL.Paquete srv = new DAL.Paquete();
                    if (srv.ActPaquetes(p, id))
                    {
                        ViewBag.Respuesta = "Alta correcta";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Respuesta = "Ha ocurrido un error";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Respuesta = "Ha ocurrido un error:" + ex.Message;

            }

            return View();
        }

        public ActionResult BorrarPaq(int id)
        {
            DAL.Paquete srv = new DAL.Paquete();

            return View(srv.borrarPaquete(id));
        }

        public ActionResult DatosModeloPaq(int id)
        {
            DAL.Paquete srv = new DAL.Paquete();

            return View(srv.getPaqueteSegunId(id));
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
