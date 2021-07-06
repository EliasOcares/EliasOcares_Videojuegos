using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api_videojuegos.Models;

namespace web_videojuegos.Controllers
{
    public class JuegosController : Controller
    {
        videojuegos_bd bd = new videojuegos_bd();
        // GET: Juegos
        public ActionResult Index()
        {
            return View(bd.juegos);
        }

        // GET: Juegos/Details/5
        public ActionResult Details(int id)
        {
            return View(bd.juegos.Find(id));
        }

        // GET: Juegos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Juegos/Create
        [HttpPost]
        public ActionResult Create(juego nuevo_juego)
        {
            try
            {
                bd.juegos.Add(nuevo_juego);
                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Juegos/Edit/5
        public ActionResult Edit(int id)
        {
            juego juego_editar = bd.juegos.Find(id);
            return View(juego_editar);
        }

        // POST: Juegos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, juego juego_editado)
        {
            try
            {
                juego juego_buscado = bd.juegos.Find(id);

                juego_buscado.nombre = juego_editado.nombre;
                juego_buscado.plataforma = juego_editado.plataforma;
                juego_buscado.anio = juego_editado.anio;
                juego_buscado.precio = juego_editado.precio;
                juego_buscado.stock = juego_editado.stock;
                juego_buscado.restriccion = juego_editado.restriccion;

                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Juegos/Delete/5
        public ActionResult Delete(int id)
        {
            juego juego_eliminar = bd.juegos.Find(id);

            return View(juego_eliminar);
        }

        // POST: Juegos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                juego juego_eliminar = bd.juegos.Find(id);

                bd.juegos.Remove(juego_eliminar);
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
