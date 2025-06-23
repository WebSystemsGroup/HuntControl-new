using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Concrete;
using HuntControl.WebUI.Models;

namespace HuntControl.WebUI.Controllers
{
    public partial class ReferenceController
    {
        public ActionResult Bailiffs()
        {
            return View("Bailiffs/Main");
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  ФССП  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddBailiff()
        {
            return PartialView("Bailiffs/PartialModalAddBailiff", new spr_bailiffs { employees_fio = UserName });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditBailiff(Guid bailiffId)
        {
            return PartialView("Bailiffs/PartialModalEditBailiff", repository.SprBailiffs.SingleOrDefault(so => so.id == bailiffId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="bailiff">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitBailiffSave(spr_bailiffs bailiff)
        {
            if (ModelState.IsValid)
            {
                if (bailiff.id == Guid.Empty)
                {
                    repository.Insert(bailiff);
                }
                else
                {
                    bailiff.employees_fio_modifi = UserName;
                    repository.Update(bailiff);
                }
                return RedirectToAction("PartialTableBailiffs");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="bailiffId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitBailiffRecovery(Guid bailiffId)
        {
            spr_bailiffs recoveryBailiff = repository.SprBailiffs.SingleOrDefault(so => so.id == bailiffId);

            recoveryBailiff.is_remove = false;
            repository.Update(recoveryBailiff);
            return RedirectToAction("PartialTableBailiffs");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="bailiffId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitBailiffDelete(Guid bailiffId, string comment)
        {
            spr_bailiffs deleteBailiff = repository.SprBailiffs.SingleOrDefault(so => so.id == bailiffId);

            deleteBailiff.is_remove = true;
            deleteBailiff.date_remove = DateTime.Now;
            deleteBailiff.employees_fio_modifi = UserName;
            deleteBailiff.commentt_remove = comment;
            repository.Update(deleteBailiff);
            return RedirectToAction("PartialTableBailiffs");
        }

        public ActionResult PartialTableBailiffs(string search, bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            var bailiffs = repository.SprBailiffs;
            bailiffs = !isRemove ? bailiffs.Where(o => o.is_remove != true) : bailiffs;
            ViewBag.Serach = search;
            bailiffs = String.IsNullOrEmpty(search) ? bailiffs :
                search.ToLower().Split().Aggregate(bailiffs, (current, item) => current.Where(h => h.name_bailiffs.ToLower().Contains(item) || h.address_bailiffs.Contains(item)));

            BailiffViewModel model = new BailiffViewModel
            {
                SprBailiffList = bailiffs.OrderBy(a => a.name_bailiffs).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = bailiffs.Count()
                },
            };
            return PartialView("Bailiffs/PartialTableBailiffs", model);
        }

        #endregion
    }
}