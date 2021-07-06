using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api_videojuegos.Models;

namespace web_videojuegos.Controllers
{
    public class ConsolasController : Controller
    {
        videojuegos_bd bd = new videojuegos_bd();
        // GET: Consolas
        public ActionResult Index()
        {
            return View(bd.consolas);
        }

        // GET: Consolas/Details/5
        public ActionResult Details(int id)
        {
            return View(bd.consolas.Find(id));
        }

        // GET: Consolas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consolas/Create
        [HttpPost]
        public ActionResult Create(consola nueva_consola)
        {
            try
            {
                bd.consolas.Add(nueva_consola);
                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Consolas/Edit/5
        public ActionResult Edit(int id)
        {
            consola consola_editar = bd.consolas.Find(id);
            return View(consola_editar);
        }

        // POST: Consolas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, consola consola_editada)
        {
            try
            {
                consola consola_buscada = bd.consolas.Find(id);

                consola_buscada.marca = consola_editada.marca;
                consola_buscada.modelo = consola_editada.modelo;
                consola_buscada.anio = consola_editada.anio;
                consola_buscada.nueva = consola_editada.nueva;
                consola_buscada.precio = consola_editada.precio;
                consola_buscada.stock = consola_editada.stock;

                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Consolas/Delete/5
        public ActionResult Delete(int id)
        {
            consola consola_eliminar = bd.consolas.Find(id);

            return View(consola_eliminar);
        }

        // POST: Consolas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                consola consola_eliminar = bd.consolas.Find(id);

                bd.consolas.Remove(consola_eliminar);
                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
