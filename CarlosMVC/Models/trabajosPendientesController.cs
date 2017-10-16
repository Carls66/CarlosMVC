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
    public class trabajosPendientesController : Controller
    {
        private TrabajosPendientesContext db = new TrabajosPendientesContext();

        // GET: trabajosPendientes
        public async Task<ActionResult> Index()
        {
            return View(await db.trabajosPendientes.ToListAsync());
        }

        // GET: trabajosPendientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajosPendientes trabajosPendientes = await db.trabajosPendientes.FindAsync(id);
            if (trabajosPendientes == null)
            {
                return HttpNotFound();
            }
            return View(trabajosPendientes);
        }

        // GET: trabajosPendientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: trabajosPendientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Cliente,Descripcion,Recibido,Entrega,Adelanto,Total")] trabajosPendientes trabajosPendientes)
        {
            if (ModelState.IsValid)
            {
                db.trabajosPendientes.Add(trabajosPendientes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(trabajosPendientes);
        }

        // GET: trabajosPendientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajosPendientes trabajosPendientes = await db.trabajosPendientes.FindAsync(id);
            if (trabajosPendientes == null)
            {
                return HttpNotFound();
            }
            return View(trabajosPendientes);
        }

        // POST: trabajosPendientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Cliente,Descripcion,Recibido,Entrega,Adelanto,Total")] trabajosPendientes trabajosPendientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajosPendientes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trabajosPendientes);
        }

        // GET: trabajosPendientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trabajosPendientes trabajosPendientes = await db.trabajosPendientes.FindAsync(id);
            if (trabajosPendientes == null)
            {
                return HttpNotFound();
            }
            return View(trabajosPendientes);
        }

        // POST: trabajosPendientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            trabajosPendientes trabajosPendientes = await db.trabajosPendientes.FindAsync(id);
            db.trabajosPendientes.Remove(trabajosPendientes);
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
