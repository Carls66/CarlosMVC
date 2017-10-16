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
    public class maquinasController : Controller
    {
        private MaquinasContext db = new MaquinasContext();

        // GET: maquinas
        public async Task<ActionResult> Index()
        {
            return View(await db.maquinas.ToListAsync());
        }

        // GET: maquinas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maquinas maquinas = await db.maquinas.FindAsync(id);
            if (maquinas == null)
            {
                return HttpNotFound();
            }
            return View(maquinas);
        }

        // GET: maquinas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: maquinas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Tipo,Nombre,Funcion,Estado")] maquinas maquinas)
        {
            if (ModelState.IsValid)
            {
                db.maquinas.Add(maquinas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(maquinas);
        }

        // GET: maquinas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maquinas maquinas = await db.maquinas.FindAsync(id);
            if (maquinas == null)
            {
                return HttpNotFound();
            }
            return View(maquinas);
        }

        // POST: maquinas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Tipo,Nombre,Funcion,Estado")] maquinas maquinas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maquinas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(maquinas);
        }

        // GET: maquinas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maquinas maquinas = await db.maquinas.FindAsync(id);
            if (maquinas == null)
            {
                return HttpNotFound();
            }
            return View(maquinas);
        }

        // POST: maquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            maquinas maquinas = await db.maquinas.FindAsync(id);
            db.maquinas.Remove(maquinas);
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
