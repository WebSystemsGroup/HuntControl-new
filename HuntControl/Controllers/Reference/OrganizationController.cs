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
        public ActionResult Organizations()
        {
            return View("Organizations/Main");
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Органы власти  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddOrganization()
        {
            return PartialView("Organizations/PartialModalAddOrganization", new spr_organization { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditOrganization(Guid organizationId)
        {
            return PartialView("Organizations/PartialModalEditOrganization", repository.SprOrganizations.SingleOrDefault(so => so.id == organizationId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="organization">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitOrganizationSave(spr_organization organization)
        {
            if (ModelState.IsValid)
            {
                if (organization.id == Guid.Empty)
                {
                    repository.Insert(organization);
                }
                else
                {
                    organization.employees_fio_modifi = UserName;
                    repository.Update(organization);
                }
                return RedirectToAction("PartialTableOrganizations");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="organizationId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitOrganizationRecovery(Guid organizationId)
        {
            spr_organization deleteOrganization = repository.SprOrganizations.SingleOrDefault(so => so.id == organizationId);

            deleteOrganization.is_remove = false;
            repository.Update(deleteOrganization);
            return RedirectToAction("PartialTableOrganizations");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="organizationId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitOrganizationDelete(Guid organizationId, string comment)
        {
            spr_organization deleteOrganization = repository.SprOrganizations.SingleOrDefault(so => so.id == organizationId);

            deleteOrganization.is_remove = true;
            deleteOrganization.date_remove = DateTime.Now;
            deleteOrganization.employees_fio_modifi = UserName;
            deleteOrganization.commentt_remove = comment;
            repository.Update(deleteOrganization);
            return RedirectToAction("PartialTableOrganizations");
        }

        public ActionResult PartialTableOrganizations(string search, bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            var organizations = repository.SprOrganizations;
            organizations = !isRemove ? organizations.Where(o => o.is_remove != true) : organizations;
            ViewBag.Serach = search;
            organizations = String.IsNullOrEmpty(search) ? organizations :
                search.ToLower().Split().Aggregate(organizations, (current, item) => current.Where(h => h.name_organization.ToLower().Contains(item) || h.address_organization.Contains(item)));

            OrganizationViewModel model = new OrganizationViewModel
            {
                SprOrganizationList = organizations.OrderBy(a => a.name_organization).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = organizations.Count()
                },
            };
            return PartialView("Organizations/PartialTableOrganizations", model);
        }

        #endregion
    }
}