using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarlosMVC.Models
{
    public class trabajosTerminadosController : Controller
    {
        private TrabajosTerminadosContext db = new TrabajosTerminadosContext();

        // GET: trabajosTerminados
        public async Task<ActionResult> Index()
        {
            return View(await db.trabajosTerminados.ToListAsync());
        }

        // GET: trabajosTerminados/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajosTerminados trabajosTerminados = await db.trabajosTerminados.FindAsync(id);
            if (trabajosTerminados == null)
            {
                return HttpNotFound();
            }
            return View(trabajosTerminados);
        }

        // GET: trabajosTerminados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: trabajosTerminados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Cliente,Descripcion,Recibido,Entregado,Total")] trabajosTerminados trabajosTerminados)
        {
            if (ModelState.IsValid)
            {
                db.trabajosTerminados.Add(trabajosTerminados);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(trabajosTerminados);
        }

        // GET: trabajosTerminados/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajosTerminados trabajosTerminados = await db.trabajosTerminados.FindAsync(id);
            if (trabajosTerminados == null)
            {
                return HttpNotFound();
            }
            return View(trabajosTerminados);
        }

        // POST: trabajosTerminados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Cliente,Descripcion,Recibido,Entregado,Total")] trabajosTerminados trabajosTerminados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajosTerminados).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trabajosTerminados);
        }

        // GET: trabajosTerminados/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajosTerminados trabajosTerminados = await db.trabajosTerminados.FindAsync(id);
            if (trabajosTerminados == null)
            {
                return HttpNotFound();
            }
            return View(trabajosTerminados);
        }

        // POST: trabajosTerminados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            trabajosTerminados trabajosTerminados = await db.trabajosTerminados.FindAsync(id);
            db.trabajosTerminados.Remove(trabajosTerminados);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
