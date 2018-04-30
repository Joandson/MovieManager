using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MovieManager.Core;
using MovieManager.Core.Domain;
using MovieManager.Helpers;
using MovieManager.Persistence;
using MovieManager.ViewModels;

namespace MovieManager.Controllers
{
    [Authorize]
    public class FilmesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public FilmesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        // GET: Filmes
        public ActionResult Index()
        {
            var filme = _unitOfWork.Filmes.GetAllNotDeleted();
            var filmeVm = Mapper.Map<IEnumerable<Filme>, IEnumerable<FilmeViewModel>>(filme);
            return View(filmeVm);
        }
        private string CurrentUserAsString()
        {
            return User.Identity.Name.ToString();
        }

        // GET: Filmes/Create
        public ActionResult Create()
        {
            var filmeVm = new FilmeViewModel();
            filmeVm.GeneroSL = _unitOfWork.Filmes.GetGenresSL();

            return View("FilmesEditForm", filmeVm);
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilmeViewModel filmeVm)
        {
            if (ModelState.IsValid)
            {
                SetAuditableEntityProperties.SetFirstTimeAuditableProperties(filmeVm, CurrentUserAsString());
                var mappedFilme = Mapper.Map<FilmeViewModel, Filme>(filmeVm);

                _unitOfWork.Filmes.Add(mappedFilme);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            filmeVm.GeneroSL = _unitOfWork.Filmes.GetGenresSL();
            return View("FilmesEditForm", filmeVm);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = _unitOfWork.Filmes.GetByIdNotDeleted(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            var filmeVm = Mapper.Map<Filme, FilmeViewModel>(filme);
            filmeVm.GeneroSL = _unitOfWork.Filmes.GetGenresSL();

            return View("FilmesEditForm", filmeVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FilmeViewModel filmeVm)
        {
            if (ModelState.IsValid)
            {
                SetAuditableEntityProperties.UpdateAuditableProperties(filmeVm, currentUser: CurrentUserAsString());
                var filme = Mapper.Map<FilmeViewModel, Filme>(filmeVm);
                _unitOfWork.Filmes.SetModifiedState(filme);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            filmeVm.GeneroSL = _unitOfWork.Filmes.GetGenresSL();
            return View("FilmesEditForm", filmeVm);
        }

        // GET: Filmes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = _unitOfWork.Filmes.GetByIdNotDeleted(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            var filmeVm = Mapper.Map<Filme, FilmeViewModel>(filme);

            return View(filmeVm);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = _unitOfWork.Filmes.GetByIdNotDeleted(id);
            if (filme != null)
            {
                filme.Deleted = true;
                _unitOfWork.Complete();
            }

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
