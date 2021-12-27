using MVCFrameworkNeoris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFrameworkNeoris.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult AltaCli()
        {

            return View();
        }

        public ActionResult AltaPaq()
        {

            return View();
        }

        public ActionResult AltaFac()
        {

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message1 = "Your contact page.";
            ViewBag.micosa = "algoo";
            return View();
        }
        [HttpPost]
        public ActionResult AltaCli(Cliente c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAL.Cliente srv = new DAL.Cliente();
                    if (srv.IClientes(c))
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
        [HttpPost]
        public ActionResult AltaPaq(Paquete p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAL.Paquete srv = new DAL.Paquete();
                    if (srv.IPaquetes(p))
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
        [HttpPost]
        public ActionResult AltaFac(Factura f)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DAL.Factura srv = new DAL.Factura();
                    if (srv.IFacturas(f))
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

        public ActionResult ListarCli()
        {
            var ruta = RouteData.Values["id"] + Request.Url.Query;
            
            DAL.Cliente srv = new DAL.Cliente();
            ViewBag.Prueba = ruta;
            return View(srv.getClientes());
        }

        public ActionResult ListarPaq()
        {
            DAL.Paquete srv = new DAL.Paquete();

            return View(srv.getPaquetes());
        }
        public ActionResult ListarFac()
        {
            DAL.Factura srv = new DAL.Factura();


            return View(srv.getFacturas());
        }

        public ActionResult DatosModeloCli()
        {
            DAL.Cliente srv = new DAL.Cliente();

            return View(srv.getClientes());
        }

        public ActionResult DatosModeloPaq()
        {
            DAL.Paquete srv = new DAL.Paquete();

            return View(srv.getPaquetes());
        }

    }
}