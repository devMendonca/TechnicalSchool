using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechnicalSchool.Data;
using TechnicalSchool.Models;

namespace TechnicalSchool.Controllers
{
    public class InscricoesController : Controller
    {
        private EscolaContext db = new EscolaContext();

        // GET: Inscricoes
        public ActionResult Index()
        {
            var inscricaos = db.Inscricaos.Include(i => i.Curso).Include(i => i.Estudante);
            return View(inscricaos.ToList());
        }

        // GET: Inscricoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricaos.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            return View(inscricao);
        }

        // GET: Inscricoes/Create
        public ActionResult Create()
        {
            ViewBag.CursoID = new SelectList(db.Cursoes, "CursoID", "Titulo");
            ViewBag.EstudanteID = new SelectList(db.Estudantes, "ID", "Sobrenome");
            return View();
        }

        // POST: Inscricoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InscricaoID,CursoID,EstudanteID,Grade")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                db.Inscricaos.Add(inscricao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoID = new SelectList(db.Cursoes, "CursoID", "Titulo", inscricao.CursoID);
            ViewBag.EstudanteID = new SelectList(db.Estudantes, "ID", "Sobrenome", inscricao.EstudanteID);
            return View(inscricao);
        }

        // GET: Inscricoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricaos.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoID = new SelectList(db.Cursoes, "CursoID", "Titulo", inscricao.CursoID);
            ViewBag.EstudanteID = new SelectList(db.Estudantes, "ID", "Sobrenome", inscricao.EstudanteID);
            return View(inscricao);
        }

        // POST: Inscricoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InscricaoID,CursoID,EstudanteID,Grade")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscricao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoID = new SelectList(db.Cursoes, "CursoID", "Titulo", inscricao.CursoID);
            ViewBag.EstudanteID = new SelectList(db.Estudantes, "ID", "Sobrenome", inscricao.EstudanteID);
            return View(inscricao);
        }

        // GET: Inscricoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscricao inscricao = db.Inscricaos.Find(id);
            if (inscricao == null)
            {
                return HttpNotFound();
            }
            return View(inscricao);
        }

        // POST: Inscricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscricao inscricao = db.Inscricaos.Find(id);
            db.Inscricaos.Remove(inscricao);
            db.SaveChanges();
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
