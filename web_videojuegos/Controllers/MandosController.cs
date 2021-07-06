using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api_videojuegos.Models;

namespace web_videojuegos.Controllers
{
    public class MandosController : Controller
    {
        videojuegos_bd bd = new videojuegos_bd();
        // GET: Mandos
        public ActionResult Index()
        {
            return View(bd.mandos);
        }

        // GET: Mandos/Details/5
        public ActionResult Details(int id)
        {
            return View(bd.mandos.Find(id));
        }

        // GET: Mandos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mandos/Create
        [HttpPost]
        public ActionResult Create(mando nuevo_mando)
        {
            try
            {
                bd.mandos.Add(nuevo_mando);
                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mandos/Edit/5
        public ActionResult Edit(int id)
        {
            mando mando_editar = bd.mandos.Find(id);
            return View(mando_editar);
        }

        // POST: Mandos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, mando mando_editado)
        {
            try
            {
                mando mando_buscado = bd.mandos.Find(id);

                mando_buscado.marca = mando_editado.marca;
                mando_buscado.modelo = mando_editado.modelo;
                mando_buscado.compatibilidad = mando_editado.compatibilidad;
                mando_buscado.precio = mando_editado.precio;
                mando_buscado.stock = mando_editado.stock;

                bd.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mandos/Delete/5
        public ActionResult Delete(int id)
        {
            mando mando_eliminar = bd.mandos.Find(id);

            return View(mando_eliminar);
        }

        // POST: Mandos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                mando mando_eliminar = bd.mandos.Find(id);

                bd.mandos.Remove(mando_eliminar);
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
