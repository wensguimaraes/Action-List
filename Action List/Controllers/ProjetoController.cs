using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Action_List.Models;

namespace Action_List.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly DbListaDeAcoesEntities _db = new DbListaDeAcoesEntities();

        // GET: Projeto
        public ActionResult Index()
        {
            var projeto = _db.Projeto.Include(p => p.Usuario);
            return View(projeto.ToList());
        }
        
        // GET: Projeto/Create
        public ActionResult Create()
        {
            ViewBag.Responsavel = new SelectList(_db.Usuario.OrderBy(x=> x.Nome), "Id", "Nome");
            return View();
        }

        // POST: Projeto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Title,Responsavel")] Projeto projeto)
        {
            ViewBag.Responsavel = new SelectList(_db.Usuario.OrderBy(x => x.Nome), "Id", "Nome", projeto.Responsavel);

            if (_db.Projeto.Any(x => x.Codigo == projeto.Codigo))
            {
                ModelState.AddModelError("Codigo", "Código já cadastrado!");
                return View(projeto);
            }

            if (!ModelState.IsValid) return View(projeto);


            _db.Projeto.Add(projeto);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Projeto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeto projeto = _db.Projeto.Find(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Responsavel = new SelectList(_db.Usuario, "Id", "Nome", projeto.Responsavel);
            return View(projeto);
        }

        // POST: Projeto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Title,Responsavel")] Projeto projeto)
        {
            ViewBag.Responsavel = new SelectList(_db.Usuario, "Id", "Nome", projeto.Responsavel);

            if (_db.Projeto.Any(x => x.Id != projeto.Id && x.Codigo == projeto.Codigo))
            {
                ModelState.AddModelError("Codigo", "Código já cadastrado!");
                return View(projeto);
            }

            if (ModelState.IsValid)
            {
                _db.Entry(projeto).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projeto);
        }

        // GET: Projeto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeto projeto = _db.Projeto.Find(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }

        // POST: Projeto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projeto projeto = _db.Projeto.Find(id);
            _db.Projeto.Remove(projeto);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
