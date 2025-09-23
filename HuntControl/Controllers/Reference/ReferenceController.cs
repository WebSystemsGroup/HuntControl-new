using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Concrete;
using HuntControl.Domain.Models.Entities;
using HuntControl.WebUI.Filters;
using HuntControl.WebUI.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebAIS.Models;

namespace HuntControl.WebUI.Controllers
{
    [ClientErrorHandler]
    [Authorize(Roles = "superadmin, admin")]
    public partial class ReferenceController : Controller
    {
        public int PageSize = 10;

        #region Инициализация Repository
        private IRepository repository;
        private string UserName => Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
        public ReferenceController(IRepository repo)
        {
            repository = repo;
        }
        #endregion

        public ActionResult Main()
        {
            return View();
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Банки  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult Banks()
        {
            return View("Banks/Main");
        }

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddBank()
        {
            return PartialView("Banks/PartialModalAddBank", new spr_bank { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSeasonOpen(int seasonId)
        {
            return PartialView("Banks/PartialModalAddSeasonOpen", new spr_season_open { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ",spr_season_id = seasonId });
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="bank">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSeasonOpenSave(spr_season_open seasonOpen)
        {
            if (ModelState.IsValid)
            {
                if (seasonOpen.id == Guid.Empty)
                {
                    seasonOpen.id = Guid.NewGuid();
                    seasonOpen.set_date = DateTime.Now;
                    repository.Insert(seasonOpen);
                }
                else
                {
                    seasonOpen.employees_fio = User.Identity.Name;
                    repository.Update(seasonOpen);
                }

                var opens = repository.SprSeasonOpens
                .Where(o => o.spr_season_id == seasonOpen.spr_season_id)
                .OrderByDescending(o => o.date_start);

                ReferenceViewModel model = new ReferenceViewModel
                {
                    SprSeasonOpens = opens,
                    PageInfo = new PageInfo
                    {
                        MaxPageList = 5,
                        CurrentPage = 1,
                        ItemsPerPage = PageSize,
                        TotalItems = opens.Count()
                    }
                };

                return PartialView("HuntingSeasons/HuntingSeasonOpen/TableSeasonOpen", model);
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditBank(Guid bankId)
        {
            return PartialView("Banks/PartialModalEditBank", repository.SprBanks.SingleOrDefault(di => di.id == bankId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="bank">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitBankSave(spr_bank bank)
        {
            if (ModelState.IsValid)
            {
                if (bank.id == Guid.Empty)
                {
                    repository.Insert(bank);
                }
                else
                {
                    bank.employees_fio_modifi = UserName;
                    repository.Update(bank);
                }
                return RedirectToAction("PartialTableBanks");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="bankId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitBankRecovery(Guid bankId)
        {
            spr_bank recoveryBank = repository.SprBanks.SingleOrDefault(so => so.id == bankId);

            recoveryBank.is_remove = false;
            repository.Update(recoveryBank);
            return RedirectToAction("PartialTableBanks");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="bankId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitBankDelete(Guid bankId, string comment)
        {
            spr_bank deleteBank = repository.SprBanks.SingleOrDefault(so => so.id == bankId);

            deleteBank.is_remove = true;
            deleteBank.date_remove = DateTime.Now;
            deleteBank.employees_fio_modifi = UserName;
            deleteBank.commentt_remove = comment;
            repository.Update(deleteBank);
            return RedirectToAction("PartialTableBanks");
        }

        public ActionResult PartialTableBanks(string search, bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            ViewBag.Serach = search;
            var banks = repository.SprBanks;
            banks = !isRemove ? banks.Where(o => o.is_remove != true) : banks;
            banks = String.IsNullOrEmpty(search) ? banks :
                search.ToLower().Split().Aggregate(banks, (current, item) => current.Where(h => h.bank_name.ToLower().Contains(item) || h.address_full.Contains(item)));

            ReferenceViewModel model = new ReferenceViewModel
            {
                SprBankList = banks.OrderBy(a => a.bank_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = banks.Count()
                },
            };
            return PartialView("Banks/PartialTableBanks", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Документы уд. личность  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult DocumentIdentities()
        {
            return View("DocumentIdentities/Main");
        }

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddDocumentIdentity()
        {
            return PartialView("DocumentIdentities/PartialModalAddDocumentIdentity", new spr_document_identity { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditDocumentIdentity(int documentIdentityId)
        {
            return PartialView("DocumentIdentities/PartialModalEditDocumentIdentity", repository.SprDocumentIdentities.SingleOrDefault(di => di.id == documentIdentityId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="serviceType">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitDocumentIdentitySave(spr_document_identity documentIdentity)
        {
            if (ModelState.IsValid)
            {
                var isExist = repository.SprDocumentIdentities.Any(di => di.id == documentIdentity.id);
                if (!isExist)
                {
                    repository.Insert(documentIdentity);
                }
                else
                {
                    documentIdentity.employees_fio_modifi = UserName;
                    repository.Update(documentIdentity);
                }
                return RedirectToAction("PartialTableDocumentIdentities");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="documentIdentityId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitServiceTypeRecovery(int documentIdentityId)
        {
            spr_document_identity recoveryDocumentIdentity = repository.SprDocumentIdentities.SingleOrDefault(so => so.id == documentIdentityId);

            recoveryDocumentIdentity.is_remove = false;
            repository.Update(recoveryDocumentIdentity);
            return RedirectToAction("PartialTableDocumentIdentities");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="documentIdentityId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitServiceTypeDelete(int documentIdentityId, string comment)
        {
            spr_document_identity deleteDocumentIdentity = repository.SprDocumentIdentities.SingleOrDefault(so => so.id == documentIdentityId);

            deleteDocumentIdentity.is_remove = true;
            deleteDocumentIdentity.date_remove = DateTime.Now;
            deleteDocumentIdentity.employees_fio_modifi = UserName;
            deleteDocumentIdentity.commentt_remove = comment;
            repository.Update(deleteDocumentIdentity);
            return RedirectToAction("PartialTableDocumentIdentities");
        }

        public ActionResult PartialTableDocumentIdentities(bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            var documentIdentities = repository.SprDocumentIdentities;
            documentIdentities = !isRemove ? documentIdentities.Where(o => o.is_remove != true) : documentIdentities;

            ReferenceViewModel model = new ReferenceViewModel
            {
                SprDocumentIdentityList = documentIdentities.OrderBy(a => a.document_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = documentIdentities.Count()
                },
            };
            return PartialView("DocumentIdentities/PartialTableDocumentIdentities", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Типы услуг  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult ServiceTypes()
        {
            return View("ServiceTypes/Main");
        }

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddServiceType()
        {
            return PartialView("ServiceTypes/PartialModalAddServiceType", new spr_services_type { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditServiceType(Guid serviceTypeId)
        {
            return PartialView("ServiceTypes/PartialModalEditServiceType", repository.SprServicesTypes.SingleOrDefault(st => st.id == serviceTypeId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="serviceType">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitServiceTypeSave(spr_services_type serviceType)
        {
            if (ModelState.IsValid)
            {
                if (serviceType.id == Guid.Empty)
                {
                    repository.Insert(serviceType);
                }
                else
                {
                    serviceType.employees_fio_modifi = UserName;
                    repository.Update(serviceType);
                }
                return RedirectToAction("PartialTableServiceTypes");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="serviceTypeId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitServiceTypeRecovery(Guid serviceTypeId)
        {
            spr_services_type recoveryServiceType = repository.SprServicesTypes.SingleOrDefault(so => so.id == serviceTypeId);

            recoveryServiceType.is_remove = false;
            repository.Update(recoveryServiceType);
            return RedirectToAction("PartialTableServiceTypes");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="serviceTypeId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitServiceTypeDelete(Guid serviceTypeId, string comment)
        {
            spr_services_type deleteServiceType = repository.SprServicesTypes.SingleOrDefault(so => so.id == serviceTypeId);

            deleteServiceType.is_remove = true;
            deleteServiceType.date_remove = DateTime.Now;
            deleteServiceType.employees_fio_modifi = UserName;
            deleteServiceType.commentt_remove = comment;
            repository.Update(deleteServiceType);
            return RedirectToAction("PartialTableServiceTypes");
        }

        public ActionResult PartialTableServiceTypes(bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            var serviceTypes = repository.SprServicesTypes;
            serviceTypes = !isRemove ? serviceTypes.Where(o => o.is_remove != true) : serviceTypes;

            ReferenceViewModel model = new ReferenceViewModel
            {
                SprServiceTypeList = serviceTypes.OrderBy(a => a.type_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = serviceTypes.Count()
                },
            };
            return PartialView("ServiceTypes/PartialTableServiceTypes", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Вид охоты  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult HuntingTypes()
        {
            return View("HuntingTypes/Main");
        }

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddHuntingType()
        {
            return PartialView("HuntingTypes/PartialModalAddHuntingType", new spr_hunting_type { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditHuntingType(Guid huntingTypeId)
        {
            return PartialView("HuntingTypes/PartialModalEditHuntingType", repository.SprHuntingTypes.SingleOrDefault(ht => ht.id == huntingTypeId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="huntingType">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingTypeSave(spr_hunting_type huntingType)
        {
            if (ModelState.IsValid)
            {
                if (huntingType.id == Guid.Empty)
                {
                    repository.Insert(huntingType);
                }
                else
                {
                    huntingType.employees_fio_modifi = UserName;
                    repository.Update(huntingType);
                }
                return RedirectToAction("PartialTableHuntingTypes");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="huntingTypeId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingTypeRecovery(Guid huntingTypeId)
        {
            spr_hunting_type recoveryHuntingType = repository.SprHuntingTypes.SingleOrDefault(so => so.id == huntingTypeId);

            recoveryHuntingType.is_remove = false;
            repository.Update(recoveryHuntingType);
            return RedirectToAction("PartialTableHuntingTypes");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="huntingTypeId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingTypeDelete(Guid huntingTypeId, string comment)
        {
            spr_hunting_type deleteHuntingType = repository.SprHuntingTypes.SingleOrDefault(so => so.id == huntingTypeId);

            deleteHuntingType.is_remove = true;
            deleteHuntingType.date_remove = DateTime.Now;
            deleteHuntingType.employees_fio_modifi = UserName;
            deleteHuntingType.commentt_remove = comment;
            repository.Update(deleteHuntingType);
            return RedirectToAction("PartialTableHuntingTypes");
        }

        public ActionResult PartialTableHuntingTypes(bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            var huntingTypes = repository.SprHuntingTypes.Include(i => i.spr_animal_hunting_type_join);
            huntingTypes = !isRemove ? huntingTypes.Where(o => o.is_remove != true) : huntingTypes;

            ReferenceViewModel model = new ReferenceViewModel
            {
                SprHuntingTypeList = huntingTypes.OrderBy(a => a.type_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingTypes.Count()
                },
            };
            return PartialView("HuntingTypes/PartialTableHuntingTypes", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Животные к виду охоты  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        /// <summary>
        /// Животные к виду охоты
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalHuntingTypeAnimals(Guid huntingTypeId)
        {
            ViewBag.HuntingTypeId = huntingTypeId;
            return PartialView("HuntingTypes/HuntingTypeAnimals/PartialModalHuntingTypeAnimals");
        }

        /// <summary>
        /// Добавление животного к виду охоты
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialAddHuntingTypeAnimal(Guid huntingTypeId)
        {
            ViewBag.Animals = new SelectList(repository.SprAnimals.OrderBy(s => s.animal_name), "id", "animal_name");
            return PartialView("HuntingTypes/HuntingTypeAnimals/PartialAddHuntingTypeAnimal", new spr_animal_hunting_type_join { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", spr_hunting_type_id = huntingTypeId });
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет животное 
        /// </summary>
        /// <param name="huntingTypeAnimal">объект животного</param>
        /// <returns>частичное представление таблицы "Животные"</returns>
        [HttpPost]
        public ActionResult SubmitHuntingTypeAnimalSave(spr_animal_hunting_type_join huntingTypeAnimal)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(huntingTypeAnimal);
                return RedirectToAction("PartialTableHuntingTypeAnimals", new { huntingTypeId = huntingTypeAnimal.spr_hunting_type_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="huntingTypeAnimalId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingTypeAnimalRecovery(Guid huntingTypeAnimalId)
        {
            spr_animal_hunting_type_join recoveryHuntingTypeAnimal = repository.SprAnimalHuntingTypeJoins.SingleOrDefault(so => so.id == huntingTypeAnimalId);

            recoveryHuntingTypeAnimal.is_remove = false;
            repository.Update(recoveryHuntingTypeAnimal);
            return RedirectToAction("PartialTableHuntingTypeAnimals", new { huntingTypeId = recoveryHuntingTypeAnimal.spr_hunting_type_id });
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="huntingTypeAnimalId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingTypeAnimalDelete(Guid huntingTypeAnimalId, string comment)
        {
            spr_animal_hunting_type_join deleteHuntingTypeAnimal = repository.SprAnimalHuntingTypeJoins.SingleOrDefault(so => so.id == huntingTypeAnimalId);

            deleteHuntingTypeAnimal.is_remove = true;
            deleteHuntingTypeAnimal.date_remove = DateTime.Now;
            deleteHuntingTypeAnimal.employees_fio_modifi = UserName;
            deleteHuntingTypeAnimal.commentt_remove = comment;
            repository.Update(deleteHuntingTypeAnimal);
            return RedirectToAction("PartialTableHuntingTypeAnimals", new { huntingTypeId = deleteHuntingTypeAnimal.spr_hunting_type_id });
        }

        public ActionResult PartialTableHuntingTypeAnimals(Guid huntingTypeId, bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            ViewBag.HuntingTypeId = huntingTypeId;
            var huntingTypeAnimals = repository.SprAnimalHuntingTypeJoins.Where(hfa => hfa.spr_hunting_type_id == huntingTypeId).Include(i => i.spr_animal);
            huntingTypeAnimals = !isRemove ? huntingTypeAnimals.Where(o => o.is_remove != true) : huntingTypeAnimals;
            ReferenceViewModel model = new ReferenceViewModel
            {
                SprHuntingTypeAnimalList = huntingTypeAnimals.OrderBy(o => o.spr_animal.animal_name),
                PageInfo = new PageInfo()
            };
            return PartialView("HuntingTypes/HuntingTypeAnimals/PartialTableHuntingTypeAnimals", model);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Нарушения  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult Violations()
        {
            return View("Violations/Main");
        }

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddViolation()
        {
            return PartialView("Violations/PartialModalAddViolation", new spr_violations { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditViolation(Guid violationId)
        {
            return PartialView("Violations/PartialModalEditViolation", repository.SprViolations.SingleOrDefault(v => v.id == violationId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="violation">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitViolationSave(spr_violations violation)
        {
            if (ModelState.IsValid)
            {
                if (violation.id == Guid.Empty)
                {
                    repository.Insert(violation);
                }
                else
                {
                    violation.employees_fio_modifi = UserName;
                    repository.Update(violation);
                }
                return RedirectToAction("PartialTableViolations");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="violationId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitViolationRecovery(Guid violationId)
        {
            spr_violations deleteViolation = repository.SprViolations.SingleOrDefault(so => so.id == violationId);

            deleteViolation.is_remove = false;
            repository.Update(deleteViolation);
            return RedirectToAction("PartialTableViolations");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="violationId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitViolationDelete(Guid violationId, string comment)
        {
            spr_violations deleteViolation = repository.SprViolations.SingleOrDefault(so => so.id == violationId);

            deleteViolation.is_remove = true;
            deleteViolation.date_remove = DateTime.Now;
            deleteViolation.employees_fio_modifi = UserName;
            deleteViolation.commentt_remove = comment;
            repository.Update(deleteViolation);
            return RedirectToAction("PartialTableViolations");
        }

        public ActionResult PartialTableViolations(string search, bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            var violations = repository.SprViolations.Include(i => i.spr_violations_part);
            violations = !isRemove ? violations.Where(o => o.is_remove != true) : violations;
            ViewBag.Serach = search;
            violations = String.IsNullOrEmpty(search) ? violations :
                search.ToLower().Split().Aggregate(violations, (current, item) => current.Where(h => h.violation_name.ToLower().Contains(item) || h.violation_article.Contains(item)));

            ReferenceViewModel model = new ReferenceViewModel
            {
                SprViolationList = violations.OrderBy(a => a.violation_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = violations.Count()
                },
            };
            return PartialView("Violations/PartialTableViolations", model);
        }

        [HttpPost]
        public ActionResult PartialModalViolationsPart(Guid violationsId)
        {
            ViewBag.ViolationsId = violationsId;
            var violation = repository.SprViolations.Where(w => w.id == violationsId).First();
            ViewBag.ViolationName = violation.violation_article + " - " + violation.violation_name;
            return PartialView("Violations/ViolationsPart/PartialModalViolationsPart");
        }

        public ActionResult PartialTableViolationsPart(Guid violationsId, bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            ViewBag.ViolationsId = violationsId;
            var violationsPart = repository.SprViolationsPart.Where(v => v.spr_violations_id == violationsId);/*Include(i => i.spr_animal);*/
            violationsPart = !isRemove ? violationsPart.Where(o => o.is_remove != true) : violationsPart;
            ReferenceViewModel model = new ReferenceViewModel
            {
                SprViolationPartList = violationsPart,
                PageInfo = new PageInfo()
            };
            return PartialView("Violations/ViolationsPart/PartialTableViolationsPart", model);
        }
        [HttpPost]
        public ActionResult PartialModalAddViolationsPart()
        {
            return PartialView("ViolationsPart/PartialModalAddHuntingType", new spr_hunting_type { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }
        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialAddViolationsPart(Guid violationsId)
        {
            return PartialView("Violations/ViolationsPart/PartialAddViolationsPart", new spr_violations_part { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", spr_violations_id = violationsId });
        }
        [HttpPost]
        public ActionResult SubmitViolationsPartSave(spr_violations_part violationsPart)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(violationsPart);
                return RedirectToAction("PartialTableViolationsPart", new { violationsId = violationsPart.spr_violations_id });
            }
            throw new Exception("Ошибка валидации!");
        }
        [HttpPost]
        public ActionResult SubmitViolationsPartRecovery(Guid violationsId)
        {
            spr_violations_part recoveryViolationPart = repository.SprViolationsPart.SingleOrDefault(so => so.id == violationsId);

            recoveryViolationPart.is_remove = false;
            repository.Update(recoveryViolationPart);
            return RedirectToAction("PartialTableViolationsPart", new { violationsId = recoveryViolationPart.spr_violations_id });
        }
        [HttpPost]
        public ActionResult SubmitViolationsPartDelete(Guid violationsId, string comment)
        {
            spr_violations_part deleteViolationsPart = repository.SprViolationsPart.SingleOrDefault(so => so.id == violationsId);

            deleteViolationsPart.is_remove = true;
            deleteViolationsPart.date_remove = DateTime.Now;
            deleteViolationsPart.employees_fio_modifi = UserName;
            deleteViolationsPart.commentt_remove = comment;
            repository.Update(deleteViolationsPart);
            return RedirectToAction("PartialTableViolationsPart", new { violationsId = deleteViolationsPart.spr_violations_id });
        }
        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Сезоны  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult HuntingSeasons()
        {
            return View("HuntingSeasons/Main");
        }

        public ActionResult TableHuntingSeasons(string search, bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            ViewBag.Serach = search;
            var seasons = repository.SprSeasons.Include(s => s.spr_season_animal);
            seasons = String.IsNullOrEmpty(search) ? seasons :
                search.ToLower().Split().Aggregate(seasons, (current, item) => current.Where(h => h.season_name.ToLower().Contains(item)));

            ReferenceViewModel model = new ReferenceViewModel
            {
                SprSeasonList = seasons.OrderBy(a => a.season_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = seasons.Count()
                },
            };
            return PartialView("HuntingSeasons/TableHuntingSeasons", model);
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult EditSeason(int seasonId)
        {
            return PartialView("HuntingSeasons/EditSeason", repository.SprSeasons.SingleOrDefault(ss => ss.id == seasonId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="bank">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSeasonSave(spr_season season)
        {
            if (ModelState.IsValid)
            {
                if (season.id == 0)
                {
                    repository.Insert(season);
                }
                else
                {
                    season.employees_fio_modify = User.Identity.Name;
                    repository.Update(season);
                }
                return RedirectToAction("TableHuntingSeasons");
            }
            throw new Exception("Ошибка валидации!");
        }
        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Открытия сезона  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|
        public ActionResult TableSeasonOpens(int seasonId, int page = 1)
        {
            ViewBag.CurrentSeasonId = seasonId;

            var opens = repository.SprSeasonOpens
                .Where(o => o.spr_season_id == seasonId)
                .OrderByDescending(o => o.date_start);

            ReferenceViewModel model = new ReferenceViewModel
            {
                SprSeasonOpens = opens.Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = opens.Count()
                }
            };
            return PartialView("HuntingSeasons/HuntingSeasonOpen/TableSeasonOpen", model);
        }
        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Животные к истории открытия сезона  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult SeasonOpenAnimals(Guid seasonOpenId)
        {
            ViewBag.SeasonOpenId = seasonOpenId;
            return PartialView("HuntingSeasons/HuntingSeasonOpen/Main");
        }

        public ActionResult TableSeasonOpenAnimals(Guid seasonOpenId, string search, bool isRemove = false, int page = 1)
        {
            try
            {
                ViewBag.SeasonOpenId = seasonOpenId;
                ViewBag.IsRemove = isRemove;
                ViewBag.Search = search;
                var seasonOpenAnimals = repository.SprSeasonOpenAnimals.Where(s => s.spr_season_open_id == seasonOpenId).Include(s => s.spr_animal).Include(s => s.spr_season_open);
                seasonOpenAnimals = !isRemove ? seasonOpenAnimals.Where(o => !o.is_remove) : seasonOpenAnimals;
                seasonOpenAnimals = String.IsNullOrEmpty(search) ? seasonOpenAnimals :
                    search.ToLower().Split().Aggregate(seasonOpenAnimals, (current, item) => current.Where(h =>
                            h.spr_animal.animal_name.ToLower().Contains(item) ||
                            (h.norm_day.HasValue && h.norm_day.Value.ToString().Contains(item)) ||
                            (h.norm_season.HasValue && h.norm_season.Value.ToString().Contains(item))));

                ReferenceViewModel model = new ReferenceViewModel
                {
                    SprSeasonOpenAnimals = seasonOpenAnimals.OrderBy(a => a.spr_animal.animal_name).Skip((page - 1) * PageSize).Take(PageSize),
                    PageInfo = new PageInfo
                    {
                        MaxPageList = 5,
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = seasonOpenAnimals.Count()
                    },
                };

                return PartialView("HuntingSeasons/HuntingSeasonOpen/TableSeasonOpenAnimals", model);
            }
            catch (Exception ex)
            {
                return PartialView(ex);
            }
        }

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult AddSeasonOpenAnimal(Guid seasonOpenId)
        {
            ViewBag.Animal = new SelectList(repository.SprAnimals.OrderBy(s => s.animal_name), "id", "animal_name");
            return PartialView("HuntingSeasons/HuntingSeasonOpen/AddSeasonAnimalOpen", new spr_season_open_animal { employees_fio = UserName, spr_season_open_id = seasonOpenId });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult EditSeasonOpenAnimal(Guid seasonOpenAnimalId)
        {

            //var model = repository.SprSeasonOpenAnimals.SingleOrDefault(soa => soa.id == seasonOpenAnimalId);
            //.Include(soa => soa.spr_animal)
            //.Include(soa => soa.spr_season_open)
            ViewBag.Animal = new SelectList(repository.SprAnimals.OrderBy(s => s.animal_name), "id", "animal_name");
            return PartialView("HuntingSeasons/HuntingSeasonOpen/EditSeasonOpenAnimal", repository.SprSeasonOpenAnimals.SingleOrDefault(soa => soa.id == seasonOpenAnimalId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="bank">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAnimalForOpenSeasonSave(spr_season_open_animal seasonOpenAnimal)
        {

            //seasonOpenAnimal.spr_animal = new spr_animal();
            //seasonOpenAnimal.spr_season_open = new spr_season_open();

            //seasonOpenAnimal.id = Guid.Empty;

            if (ModelState.IsValid)
            {
                if (seasonOpenAnimal.id == Guid.Empty)
                {
                    repository.Insert(seasonOpenAnimal);
                }
                else
                {
                    try
                    {
                        repository.Update(seasonOpenAnimal);
                    }
                    catch (Exception r)
                    {
                        return null;
                    }
                }
                return RedirectToAction("TableSeasonOpenAnimals", new { seasonOpenId = seasonOpenAnimal.spr_season_open_id });
            }
            throw new Exception("Ошибка валидации!");
        }
        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Животные к сезону  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult SeasonAnimals(int seasonId)
        {
            ViewBag.SeasonId = seasonId;
            return PartialView("HuntingSeasons/HuntingSeasonAnimals/Main");
        }

        public ActionResult TableSeasonAnimals(int seasonId, string search, bool isRemove = false, int page = 1)
        {
            ViewBag.SeasonId = seasonId;
            ViewBag.IsRemove = isRemove;
            ViewBag.Search = search;
            var seasonAnimals = repository.SprSeasonAnimals.Where(s => s.spr_season_id == seasonId).Include(s => s.spr_animal);
            seasonAnimals = !isRemove ? seasonAnimals.Where(o => o.is_remove != true) : seasonAnimals;
            seasonAnimals = String.IsNullOrEmpty(search) ? seasonAnimals :
                search.ToLower().Split().Aggregate(seasonAnimals, (current, item) => current.Where(h => h.spr_season.season_name.ToLower().Contains(item)));

            ReferenceViewModel model = new ReferenceViewModel
            {
                SprSeasonAnimalList = seasonAnimals.OrderBy(a => a.norm_day).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = seasonAnimals.Count()
                },
            };
            return PartialView("HuntingSeasons/HuntingSeasonAnimals/TableSeasonAnimals", model);
        }

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult AddSeasonAnimal(int seasonId)
        {
            ViewBag.Animal = new SelectList(repository.SprAnimals.OrderBy(s => s.animal_name), "id", "animal_name");
            return PartialView("HuntingSeasons/HuntingSeasonAnimals/AddSeasonAnimal", new spr_season_animal { employees_fio_add = UserName, spr_season_id = seasonId });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult EditSeasonAnimal(Guid seasonAnimalId)
        {
            ViewBag.Animal = new SelectList(repository.SprAnimals.OrderBy(s => s.animal_name), "id", "animal_name");
            return PartialView("HuntingSeasons/HuntingSeasonAnimals/EditSeasonAnimal", repository.SprSeasonAnimals.SingleOrDefault(di => di.id == seasonAnimalId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="bank">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAnimalForSeasonSave(spr_season_animal seasonAnimal)
        {
            if (ModelState.IsValid)
            {
                if (seasonAnimal.id == Guid.Empty)
                {
                    repository.Insert(seasonAnimal);
                }
                else
                {
                    repository.Update(seasonAnimal);
                }
                return RedirectToAction("TableSeasonAnimals", new { seasonId = seasonAnimal.spr_season_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="seasonAnimalId">id</param>
        /// <returns>частичное представление таблицы</returns>
        //[HttpPost]
        //public ActionResult SubmitSeasonAnimalRecovery(Guid seasonAnimalId)
        //{
        //    spr_season_animal recoverySeasonAnimal = repository.SprSeasonAnimals.SingleOrDefault(so => so.id == seasonAnimalId);
        //    recoverySeasonAnimal.is_remove = false;
        //    repository.Update(recoverySeasonAnimal);
        //    return RedirectToAction("PartialTableSeasonAnimals");
        //}

        ///// <summary>
        ///// Удаляет запись по указанному id
        ///// </summary>
        ///// <param name="seasonAnimalId">id</param>
        ///// <returns>частичное представление таблицы</returns>
        //[HttpPost]
        //public ActionResult SubmitSeasonAnimalDelete(Guid seasonAnimalId, string comment)
        //{
        //    spr_season_animal deleteSeasonAnimal = repository.SprSeasonAnimals.SingleOrDefault(so => so.id == seasonAnimalId);

        //    deleteSeasonAnimal.is_remove = true;
        //    repository.Update(deleteSeasonAnimal);
        //    return RedirectToAction("PartialTableSeasonAnimals");
        //}



        #endregion


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Календарь  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult Calendar()
        {

            return View("Calendar/Calendar");
        }
        public ActionResult CalendarDay()
        {
            ViewBag.DayType = new SelectList(repository.DataCalendarDayTypes, "id", "name");
            var calendar = repository.DataCalendars.Include(s => s.data_calendar_day_type);
            CalendarViewModel model = new CalendarViewModel
            {
                DataCalendarList = calendar
            };
            return PartialView("Calendar/CalendarDay", model);
        }

        public ActionResult SubmitCalendarDayTypeSave(short dateType, DateTime dateSelect)
        {
            data_calendar dataCalendar = new data_calendar
            {
                date_type = dateType,
                date_ = dateSelect,
                employees_fio_modifi = UserName,
            };
            repository.Update(dataCalendar);
            return RedirectToAction("CalendarDay");
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Акаунты  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult Accounts()
        {
            return View("Accounts/Main");
        }

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddAccounts()
        {
            return PartialView("Accounts/PartialModalAddAccounts", new spr_account { employees_fio_add = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditAccount(Guid bankId)
        {
            return PartialView("Accounts/PartialModalEditAccount", repository.SprAccounts.SingleOrDefault(di => di.id == bankId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="bank">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAccountSave(spr_account account)
        {
            if (ModelState.IsValid)
            {
                if (account.id == Guid.Empty)
                {
                    repository.Insert(account);
                }
                else
                {
                    account.employees_fio_modifi = UserName;
                    repository.Update(account);
                }
                return RedirectToAction("PartialTableAccounts");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="bankId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAccountRecovery(Guid bankId)
        {
            spr_account recoveryAccount = repository.SprAccounts.SingleOrDefault(so => so.id == bankId);
            recoveryAccount.is_remove = false;
            repository.Update(recoveryAccount);
            return RedirectToAction("PartialTableAccounts");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="bankId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAccountDelete(Guid bankId, string comment)
        {
            spr_account deleteAccount = repository.SprAccounts.SingleOrDefault(so => so.id == bankId);
            deleteAccount.is_remove = true;
            repository.Update(deleteAccount);
            return RedirectToAction("PartialTableAccounts");
        }

        public ActionResult PartialTableAccounts(string search, bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            ViewBag.Serach = search;
            var accounts = repository.SprAccounts;
            accounts = !isRemove ? accounts.Where(o => o.is_remove != true) : accounts;
            accounts = String.IsNullOrEmpty(search) ? accounts :
                search.ToLower().Split().Aggregate(accounts, (current, item) => current.Where(h => h.employees_name.ToLower().Contains(item)));

            ReferenceViewModel model = new ReferenceViewModel
            {
                SprAccountList = accounts.OrderBy(a => a.employees_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = accounts.Count()
                },
            };
            return PartialView("Accounts/PartialTableAccounts", model);
        }

        #endregion

        #region Part Digital_regulations 

        public ActionResult Digital_regulations()
        {
            var sprKcr = repository.SprKcr.ToList();
            List<KcrModel.digitalRegulations> model = new List<KcrModel.digitalRegulations>();

            foreach (var cr in sprKcr)
            {
                var dataCr = repository.DataKcr.Where(i => i.spr_kcr_id == cr.id).OrderByDescending(i => i.date_add).FirstOrDefault();
                if (dataCr != null)
                {
                    model.Add(new KcrModel.digitalRegulations
                    {
                        serviceData = repository.SprServices.FirstOrDefault(s => s.id == cr.spr_services_id),
                        tariff = repository.SprServicesSubTariffs.ToArray(),
                        drData = JsonConvert.DeserializeObject<KcrModel.kcrResponseType>(Encoding.UTF8.GetString(dataCr.json))
                    });
                }
            }

            return View("Digital_regulations/Digital_regulations", model);
        }

        public ActionResult UpdateServicaName(Guid serviceId, string serviceName)
        {
            var service = repository.SprServices.FirstOrDefault(s => s.id == serviceId);
            if (service != null)
            {
                service.service_name = serviceName;
                service.service_name_small = serviceName;
                service.employees_fio_modifi = "";
                repository.Update(service);
            }

            return new EmptyResult();
        }

        public ActionResult UpdateTariff(Guid tariffId, short countDay)
        {
            var tariff = repository.SprServicesSubTariffs.FirstOrDefault(s => s.id == tariffId);
            if (tariff != null)
            {
                tariff.employees_fio_modifi = "";
                tariff.count_day_execution = countDay;
                repository.Update(tariff);
            }

            return new EmptyResult();
        }

        public ActionResult GetServices()
        {
            var services = repository.SprServices.Select(s => new { key = s.service_name, value = s.id });
            return Json(services, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}