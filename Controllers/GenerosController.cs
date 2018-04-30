using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using MovieManager.Core;
using MovieManager.Core.Domain;
using MovieManager.Helpers;
using MovieManager.Persistence;
using MovieManager.ViewModels;

namespace MovieManager.Controllers
{
    [Authorize]
    public class GenerosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private string CurrentUserAsString()
        {
            return User.Identity.Name.ToString();
        }
        public GenerosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Generoes
        public ActionResult Index()
        {
            var Generos = _unitOfWork.Generos.GetAllNotDeleted();
            var results = Mapper.Map<IEnumerable<Genero>, IEnumerable<GeneroViewModel>>(Generos);
            return View(results);
        }

        // GET: Generoes/Details/5


        // GET: Generoes/Create
        public ActionResult Create()
        {
            var generoVm = new GeneroViewModel();
            generoVm.Deleted = true;
            return View("GeneroEditForm", generoVm);
        }

        // POST: Generoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GeneroViewModel generoVm)
        {
            if (ModelState.IsValid)
            {
                //Setando somente as propriedades do AuditableEntity
                SetAuditableEntityProperties.SetFirstTimeAuditableProperties(generoVm, CurrentUserAsString());

                generoVm.CreatedBy = CurrentUserAsString();
                generoVm.DataDeCriacao = DateTime.Now;

                var genero = Mapper.Map<GeneroViewModel, Genero>(generoVm);

                _unitOfWork.Generos.Add(genero);
                _unitOfWork.Complete();

                TempData["success"] = "Gênero criado com sucesso";

                return RedirectToAction("Index");
            }

            return View("GeneroEditForm", generoVm);
        }

        // GET: Generoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = _unitOfWork.Generos.GetByIdNotDeleted(id);
            var mapperGenero = Mapper.Map<Genero, GeneroViewModel>(genero);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View("GeneroEditForm", mapperGenero);
        }

        // POST: Generoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GeneroViewModel generoVm)
        {
            if (ModelState.IsValid)
            {
                SetAuditableEntityProperties.UpdateAuditableProperties(generoVm, CurrentUserAsString());
                var genero = Mapper.Map<GeneroViewModel, Genero>(generoVm);
                _unitOfWork.Generos.SetModifiedState(genero);
                _unitOfWork.Complete();
                TempData["success"] = "Gênero alterado com sucesso";
                return RedirectToAction("Index");
            }
            return View("GeneroEditForm", generoVm);
        }

        // GET: Generoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genero genero = _unitOfWork.Generos.GetByIdNotDeleted(id);
            var generoVm = Mapper.Map<Genero, GeneroViewModel>(genero);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(generoVm);
        }

        // POST: Generoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genero genero = _unitOfWork.Generos.GetByIdNotDeleted(id);
            genero.Deleted = true;
            _unitOfWork.Complete();
            TempData["info"] = "Gênero exluído com sucesso";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
