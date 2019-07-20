using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examen_Axsis.Models;

namespace Examen_Axsis.Controllers
{
    public class UsuarioController : Controller
    {
        private Examen_AxsisDBEntities db = new Examen_AxsisDBEntities();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(db.Usuario.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Usuario,Correo,Nombre_Usuario,Contraseña,Estatus,Sexo")] Usuario usuario)
        {
            using (Examen_AxsisDBEntities dbModel = new Examen_AxsisDBEntities())
            {
                if (dbModel.Usuario.Any(x => x.Nombre_Usuario == usuario.Nombre_Usuario))
                {
                    ViewBag.DuplicateMessage = "El nombre de usuario ya ha sido registrado anteriormente";
                    return View("Create", usuario);
                }

                if (ModelState.IsValid)
                {
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "El usuario ha sido gurdado Exitosamente";
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Usuario,Correo,Nombre_Usuario,Contraseña,Estatus,Sexo")] Usuario usuario)
        {
            using (Examen_AxsisDBEntities dbModel = new Examen_AxsisDBEntities())
            {
                if (dbModel.Usuario.Any(x => x.Nombre_Usuario == usuario.Nombre_Usuario))
                {
                    ViewBag.DuplicateMessage = "El nombre de usuario ya ha sido registrado anteriormente";
                    return View("Create", usuario);
                }

                if (ModelState.IsValid)
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "El usuario ha sido modificado Exitosamente";
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
