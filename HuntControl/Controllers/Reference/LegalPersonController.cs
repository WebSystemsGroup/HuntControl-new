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
        public ActionResult LegalPersons()
        {
            return View("LegalPersons/Main");
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Юр. лица  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        /// <summary>
        /// Добавление ЮЛ
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddLegalPerson()
        {
            ViewBag.Banks = new SelectList(repository.SprBanks.OrderBy(s => s.bank_name), "id", "bank_name");
            ViewBag.RecipientTypes = new SelectList(repository.SprServicesSubTypeRecipients.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("LegalPersons/PartialModalAddLegalPerson", new spr_legal_person { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение ЮЛ
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditLegalPerson(Guid legalPersonId)
        {
            ViewBag.RecipientTypes = new SelectList(repository.SprServicesSubTypeRecipients.OrderBy(s => s.type_name), "id", "type_name");
            ViewBag.Banks = new SelectList(repository.SprBanks.OrderBy(s => s.bank_name), "id", "bank_name");
            return PartialView("LegalPersons/PartialModalEditLegalPerson", repository.SprLegalPersons.SingleOrDefault(lp => lp.id == legalPersonId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет ЮЛ
        /// </summary>
        /// <param name="legalPerson">объект ЮЛ</param>
        /// <returns>частичное представление таблицы "ЮЛ"</returns>
        [HttpPost]
        public ActionResult SubmitLegalPersonSave(spr_legal_person legalPerson)
        {
            if (ModelState.IsValid)
            {
                if (legalPerson.id == Guid.Empty)
                {
                    repository.Insert(legalPerson);
                }
                else
                {
                    legalPerson.employees_fio_modifi = Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
                    repository.Update(legalPerson);
                }
                return RedirectToAction("PartialTableLegalPersons");
            }
            throw new Exception("Ошибка валидации!");
        }



        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="legalPersonId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitLegalPersonRecovery(Guid legalPersonId)
        {
            spr_legal_person recoveryLegalPerson = repository.SprLegalPersons.SingleOrDefault(slp => slp.id == legalPersonId);

            recoveryLegalPerson.is_remove = false;
            repository.Update(recoveryLegalPerson);
            return RedirectToAction("PartialTableLegalPersons");
        }

        /// <summary>
        /// Удаляет ЮЛ по указанному id
        /// </summary>
        /// <param name="legalPersonId">id ЮЛ</param>
        /// <returns>частичное представление таблицы "ЮЛ"</returns>
        [HttpPost]
        public ActionResult SubmitLegalPersonDelete(Guid legalPersonId, string comment)
        {
            spr_legal_person deleteLegalPerson = repository.SprLegalPersons.SingleOrDefault(slp => slp.id == legalPersonId);

            deleteLegalPerson.is_remove = true;
            deleteLegalPerson.date_remove = DateTime.Now;
            deleteLegalPerson.employees_fio_modifi = UserName;
            deleteLegalPerson.commentt_remove = comment;
            repository.Update(deleteLegalPerson);
            return RedirectToAction("PartialTableLegalPersons");
        }

        public ActionResult PartialTableLegalPersons(string search, bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            var legalPersons = repository.SprLegalPersons;
            legalPersons = !isRemove ? legalPersons.Where(o => o.is_remove != true) : legalPersons;
            ViewBag.Serach = search;
            legalPersons = String.IsNullOrEmpty(search) ? legalPersons :
                search.ToLower().Split().Aggregate(legalPersons, (current, item) => current.Where(h => h.legal_name.ToLower().Contains(item) || h.legal_address.Contains(item))).Include(i=>i.spr_bank);

            HuntingFarmViewModel model = new HuntingFarmViewModel
            {
                LegalPersonList = legalPersons.OrderBy(a => a.legal_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = legalPersons.Count()
                },
            };
            return PartialView("LegalPersons/PartialTableLegalPersons", model);
        }

        #endregion
    }
}