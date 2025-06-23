using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Concrete;
using HuntControl.WebUI.Models;
using Newtonsoft.Json;

namespace HuntControl.WebUI.Controllers
{
    public partial class ReferenceController
    {
        public ActionResult HuntingFarms()
        {
            ViewBag.SprHuntingFarmsType = new SelectList(repository.SprHuntingFarmTypes.OrderBy(s => s.type_name), "id", "type_name");
            return View("HuntingFarm/HuntingFarms");
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Охотугодья  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление охотугодья
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddHuntingFarm()
        {
            ViewBag.LegalPersons = new SelectList(repository.SprLegalPersons.OrderBy(s => s.legal_name), "id", "legal_name");
            ViewBag.Banks = new SelectList(repository.SprBanks.OrderBy(s => s.bank_name), "id", "bank_name");
            ViewBag.HuntingFarmTypes = new SelectList(repository.SprHuntingFarmTypes.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("HuntingFarm/HuntingFarms/PartialModalAddHuntingFarm", new spr_hunting_farm { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение охотугодья
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditHuntingFarm(Guid huntingFarmId)
        {
            ViewBag.LegalPersons = new SelectList(repository.SprLegalPersons.OrderBy(s => s.legal_name), "id", "legal_name");
            ViewBag.Banks = new SelectList(repository.SprBanks.OrderBy(s => s.bank_name), "id", "bank_name");
            ViewBag.HuntingFarmTypes = new SelectList(repository.SprHuntingFarmTypes.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("HuntingFarm/HuntingFarms/PartialModalEditHuntingFarm", repository.SprHuntingFarms.SingleOrDefault(hf => hf.id == huntingFarmId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет охотугодье
        /// </summary>
        /// <param name="huntingFarm">объект охотугодья</param>
        /// <returns>частичное представление таблицы "охотугодья"</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmSave(spr_hunting_farm huntingFarm)
        {
            if (ModelState.IsValid)
            {
                if (huntingFarm.id == Guid.Empty)
                {
                    repository.Insert(huntingFarm);
                }
                else
                {
                    huntingFarm.employees_fio_modifi = Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
                    repository.Update(huntingFarm);
                }
                return RedirectToAction("PartialTableHuntingFarms", new { legalPersonId = huntingFarm.spr_legal_person_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="huntingFarmId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmRecovery(Guid huntingFarmId)
        {
            spr_hunting_farm recoveryHuntingFarm = repository.SprHuntingFarms.SingleOrDefault(slp => slp.id == huntingFarmId);

            recoveryHuntingFarm.is_remove = false;
            repository.Update(recoveryHuntingFarm);
            return RedirectToAction("PartialTableHuntingFarms", new { legalPersonId = recoveryHuntingFarm.spr_legal_person_id });
        }

        /// <summary>
        /// Удаляет охотугодье по указанному id
        /// </summary>
        /// <param name="huntingFarmId">id охотугодья</param>
        /// <returns>частичное представление таблицы "охотугодья"</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmDelete(Guid huntingFarmId, string comment)
        {

            spr_hunting_farm deleteHuntingFarm = repository.SprHuntingFarms.SingleOrDefault(shf => shf.id == huntingFarmId);
            deleteHuntingFarm.is_remove = true;
            deleteHuntingFarm.date_remove = DateTime.Now;
            deleteHuntingFarm.employees_fio_modifi = UserName;
            deleteHuntingFarm.commentt_remove = comment;
            repository.Update(deleteHuntingFarm);
            return RedirectToAction("PartialTableHuntingFarms", new { legalPersonId = deleteHuntingFarm.spr_legal_person_id });
        }

        public ActionResult PartialTableHuntingFarms(string search, Guid? sprHuntingFarmsTypeId, bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            ViewBag.Serach = search;
            ViewBag.sprHuntingFarmsTypeId = sprHuntingFarmsTypeId;
            var huntingFarms = repository.SprHuntingFarms.Include(hf => hf.spr_hunting_farm_type).Include(hf => hf.spr_legal_person).Include(i => i.spr_hunting_farm_animal).Include(i => i.spr_hunting_farm_location);
            if (sprHuntingFarmsTypeId != null)
            {
                huntingFarms = huntingFarms.Where(w => w.spr_hunting_farm_type.id == sprHuntingFarmsTypeId);
            }
            huntingFarms = !isRemove ? huntingFarms.Where(o => o.is_remove != true) : huntingFarms;
            huntingFarms = String.IsNullOrEmpty(search) ? huntingFarms :
                search.ToLower().Split().Aggregate(huntingFarms, (current, item) => current.Where(h => h.hunting_farm_name.ToLower().Contains(item)));

            HuntingFarmViewModel model = new HuntingFarmViewModel
            {
                HuntingFarmList = huntingFarms.OrderBy(s => s.hunting_farm_name).Skip((page - 1) * PageSize).Take(PageSize).ToArray(),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingFarms.Count()
                },
            };
            return PartialView("HuntingFarm/HuntingFarms/PartialTableHuntingFarms", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Координаты  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|



        /// <summary>
        /// Координаты
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalHuntingFarmLocation(Guid huntingFarmId)
        {
            ViewBag.HuntingFarmId = huntingFarmId;
            var huntingFarms = repository.SprHuntingFarms;
            ViewBag.HuntingFarmName = huntingFarms.Where(w => w.id == huntingFarmId).SingleOrDefault().hunting_farm_name;
            return PartialView("HuntingFarm/Locations/PartialModalHuntingFarmLocation");
        }

        /// <summary>
        /// Получение координат охотугодий
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        public ActionResult GetHuntingFarmCoords()
        {
            var huntingFarmCoords = repository.SprHuntingFarms.Include(i => i.spr_hunting_farm_location).Select(s => new { s.id, name = s.hunting_farm_name, coords = s.spr_hunting_farm_location.OrderBy(o => o.spr_hunting_farm.hunting_farm_name).ThenBy(o => o.index_).Select(s2 => new { lat = s2.latitude, lng = s2.longitude }) }).ToArray();
            return new JsonResult()
            {
                Data = huntingFarmCoords,
                ContentType = "application/json",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
            //return Json(huntingFarmCoords, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет запись
        /// </summary>
        /// <param name="huntingFarmLocation">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmLocationSave(List<HuntingFarmLocationModel> huntingFarmLocation, Guid huntingFarmId)
        {
            var locations = repository.SprHuntingFarmLocations.Where(l => l.spr_hunting_farm_id == huntingFarmId);
            foreach (var sprHuntingFarmLocation in locations)
            {
                repository.Delete(sprHuntingFarmLocation);
            }

            foreach (var location in huntingFarmLocation.Select((value, i) => new { value, i }))
            {
                repository.Insert(new spr_hunting_farm_location { spr_hunting_farm_id = huntingFarmId, index_ = location.i, latitude = location.value.Latitude, longitude = location.value.Longitude });
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Сезоны  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        /// <summary>
        /// Добавление сезона
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddHuntingFarmSeason(Guid huntingFarmId)
        {
            ViewBag.AnimalGroupTypes = new SelectList(repository.SprSeasons.OrderBy(s => s.season_name), "id", "season_name");
            return PartialView("HuntingFarm/Seasons/PartialModalAddHuntingFarmSeason", new spr_hunting_farm_season { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", spr_hunting_farm_id = huntingFarmId, date_start = DateTime.Now, date_stop = DateTime.Now.AddMonths(1).AddDays(-1) });
        }

        /// <summary>
        /// Изменение сезона
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditHuntingFarmSeason(Guid huntingFarmSeasonId)
        {
            ViewBag.AnimalGroupTypes = new SelectList(repository.SprSeasons.OrderBy(s => s.season_name), "id", "season_name");
            return PartialView("HuntingFarm/Seasons/PartialModalEditHuntingFarmSeason", repository.SprHuntingFarmSeasons.SingleOrDefault(hfs => hfs.id == huntingFarmSeasonId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет запись
        /// </summary>
        /// <param name="huntingFarmSeason">объект сезона</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmSeasonSave(spr_hunting_farm_season huntingFarmSeason)
        {
            if (ModelState.IsValid)
            {
                if (huntingFarmSeason.id == Guid.Empty)
                {
                    repository.Insert(huntingFarmSeason);
                }
                else
                {
                    huntingFarmSeason.employees_fio_modifi = UserName;
                    repository.Update(huntingFarmSeason);
                }
                return RedirectToAction("PartialTableHuntingFarmSeasons", new { huntingFarmId = huntingFarmSeason.spr_hunting_farm_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="huntingFarmSeasonId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmSeasonRecovery(Guid huntingFarmSeasonId)
        {
            spr_hunting_farm_season recoveryHuntingFarmSeason = repository.SprHuntingFarmSeasons.SingleOrDefault(sa => sa.id == huntingFarmSeasonId);

            recoveryHuntingFarmSeason.is_remove = false;
            repository.Update(recoveryHuntingFarmSeason);
            return RedirectToAction("PartialTableHuntingFarmSeasons", new { huntingFarmId = recoveryHuntingFarmSeason.spr_hunting_farm_id });
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="huntingFarmSeasonId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmSeasonDelete(Guid huntingFarmSeasonId, string comment)
        {
            spr_hunting_farm_season deleteHuntingFarmSeason = repository.SprHuntingFarmSeasons.SingleOrDefault(sa => sa.id == huntingFarmSeasonId);
            deleteHuntingFarmSeason.is_remove = true;
            deleteHuntingFarmSeason.date_remove = DateTime.Now;
            deleteHuntingFarmSeason.employees_fio_modifi = UserName;
            deleteHuntingFarmSeason.commentt_remove = comment;
            repository.Update(deleteHuntingFarmSeason);
            return RedirectToAction("PartialTableHuntingFarmSeasons", new { huntingFarmId = deleteHuntingFarmSeason.spr_hunting_farm_id });
        }

        public ActionResult PartialTableHuntingFarmSeasons(Guid huntingFarmId, bool isRemove = false, int page = 1)
        {
            ViewBag.HuntingFarmId = huntingFarmId;
            ViewBag.IsRemove = isRemove;
            ViewBag.StepValues = repository.SprHuntingFarms.Where(w => w.id == huntingFarmId).SingleOrDefault().hunting_farm_name;
            var huntingFarmSeasons = repository.SprHuntingFarmSeasons.Where(hfa => hfa.spr_hunting_farm_id == huntingFarmId).Include(i => i.spr_season).Include(i => i.spr_hunting_farm_season_forms);

            huntingFarmSeasons = !isRemove ? huntingFarmSeasons.Where(o => o.is_remove != true) : huntingFarmSeasons;

            HuntingFarmViewModel model = new HuntingFarmViewModel
            {
                HuntingFarmSeasonList = huntingFarmSeasons.OrderBy(a => a.spr_season.season_name).Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingFarmSeasons.Count() - 1 
                },
            };
            return PartialView("HuntingFarm/Seasons/PartialTableHuntingFarmSeasons", model);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Животные к сезону  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSeasonAnimal(Guid huntingFarmSeasonId)
        {
            var seasons = repository.SprHuntingFarmSeasons.Where(fs => fs.id == huntingFarmSeasonId).Include(i => i.spr_hunting_farm);
            // var animals = seasons.Join (repository.SprAnimals, s => s.spr_hunting_farm_season_animal, a => a.spr_hunting_farm_season_animal, (s, a) => a).Join(seasons.Join(repository.SprHuntingFarms, fs => fs.spr_hunting_farm_id, f => f.id, (fs, f) => f).Join(repository.SprHuntingFarmAnimals, f => f.id, fa => fa.spr_hunting_farm_id, (f, fa) => fa), a => a.id, fa => fa.spr_animal_id, (a, fa) => a).Where(sa => sa.is_remove != true).ToArray();
            //var selectAnimals = repository.SprHuntingFarmSeasonAnimals.Where(w => w.spr_hunting_farm_season_id == huntingFarmSeasonId).ToArray();
            //var anime = repository.SprSeasons.Include(x => x.spr_hunting_farm_season.Where(z => z.id == huntingFarmSeasonId)).Include(x => x.spr_season_animal).ToArray();
            var anime1 = from huntingFarmSeason in repository.SprHuntingFarmSeasons
                         join season in repository.SprSeasons on huntingFarmSeason.spr_season_id equals season.id
                         join seasonAnimal in repository.SprSeasonAnimals on season.id equals seasonAnimal.spr_season_id
                         join animal in repository.SprAnimals on seasonAnimal.spr_animal_id equals animal.id
                         where seasonAnimal.is_remove != true && huntingFarmSeason.id == huntingFarmSeasonId
                         select new { Name = animal.animal_name, Id = animal.id };

            ViewBag.Animals = new SelectList(anime1, "Id", "Name");

            return PartialView("HuntingFarm/SeasonAnimals/PartialModalAddSeasonAnimal", new spr_hunting_farm_season_animal { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", spr_hunting_farm_season_id = huntingFarmSeasonId });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditSeasonAnimal(Guid seasonAnimalId)
        {
            return PartialView("HuntingFarm/SeasonAnimals/PartialModalEditSeasonAnimal", repository.SprHuntingFarmSeasonAnimals.SingleOrDefault(hfsa => hfsa.id == seasonAnimalId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет запись
        /// </summary>
        /// <param name="huntingFarmSeason">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSeasonAnimalSave(spr_hunting_farm_season_animal seasonAnimal)
        {
            if (ModelState.IsValid)
            {
                if (seasonAnimal.id == Guid.Empty)
                {
                    repository.Insert(seasonAnimal);
                }
                else
                {
                    seasonAnimal.employees_fio_modifi = UserName;
                    repository.Update(seasonAnimal);
                }
                return RedirectToAction("PartialTableSeasonAnimals", new { huntingFarmSeasonId = seasonAnimal.spr_hunting_farm_season_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="seasonAnimalId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSeasonAnimalRecovery(Guid seasonAnimalId)
        {
            spr_hunting_farm_season_animal recoverySeasonAnimal = repository.SprHuntingFarmSeasonAnimals.SingleOrDefault(sa => sa.id == seasonAnimalId);

            recoverySeasonAnimal.is_remove = false;
            repository.Update(recoverySeasonAnimal);
            return RedirectToAction("PartialTableSeasonAnimals", new { huntingFarmSeasonId = recoverySeasonAnimal.spr_hunting_farm_season_id });
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="seasonAnimalId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSeasonAnimalDelete(Guid seasonAnimalId, string comment)
        {
            spr_hunting_farm_season_animal deleteSeasonAnimal = repository.SprHuntingFarmSeasonAnimals.SingleOrDefault(sa => sa.id == seasonAnimalId);
            deleteSeasonAnimal.is_remove = true;
            deleteSeasonAnimal.date_remove = DateTime.Now;
            deleteSeasonAnimal.employees_fio_modifi = UserName;
            deleteSeasonAnimal.commentt_remove = comment;
            repository.Update(deleteSeasonAnimal);
            return RedirectToAction("PartialTableSeasonAnimals", new { huntingFarmSeasonId = deleteSeasonAnimal.spr_hunting_farm_season_id });
        }


        public ActionResult PartialTableSeasonAnimals(Guid huntingFarmSeasonId, bool isRemove = false, int page = 1)
        {
            ViewBag.HuntingFarmSeasonId = huntingFarmSeasonId;
            ViewBag.IsRemove = isRemove;
            var season = repository.SprHuntingFarmSeasons.Where(w => w.id == huntingFarmSeasonId).Include(i => i.spr_hunting_farm).Include(i => i.spr_season).SingleOrDefault();
            Dictionary<string, string> Steps = new Dictionary<string, string>();
            Steps.Add("ion-android-locate", season.spr_hunting_farm.hunting_farm_name);
            Steps.Add("ion-ios7-paw", season.spr_season.season_name);
            ViewBag.StepValues = Steps;
            var huntingFarmSeasonAnimals = repository.SprHuntingFarmSeasonAnimals.Where(hfa => hfa.spr_hunting_farm_season_id == huntingFarmSeasonId && hfa.is_remove !=true).Include(i => i.spr_animal.spr_animal_group_type.spr_animal_group);
            huntingFarmSeasonAnimals = !isRemove ? huntingFarmSeasonAnimals.Where(o => o.is_remove != true) : huntingFarmSeasonAnimals;

            HuntingFarmViewModel model = new HuntingFarmViewModel
            {
                HuntingFarmSeasonAnimalList = huntingFarmSeasonAnimals,
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingFarmSeasonAnimals.Count()
                },
            };
            return PartialView("HuntingFarm/SeasonAnimals/PartialTableSeasonAnimals", model);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Бланки  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        /// <summary>
        /// Бланки
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalHuntingFarmSeasonForm(Guid huntingFarmSeasonId)
        {
            ViewBag.HuntingFarmSeasonId = huntingFarmSeasonId;
            return PartialView("HuntingFarm/Seasons/SeasonForms/PartialModalHuntingFarmSeasonForm");
        }

        /// <summary>
        /// Добавление бланка
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialAddHuntingFarmSeasonForm(Guid huntingFarmSeasonId)
        {
            return PartialView("HuntingFarm/Seasons/SeasonForms/PartialAddHuntingFarmSeasonForm", new spr_hunting_farm_season_forms { employees_fio = UserName, spr_hunting_farm_season_id = huntingFarmSeasonId, date_issue = DateTime.Now });
        }

        /// <summary>
        /// Изменение бланка
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialEditHuntingFarmSeasonForm(Guid huntingFarmSeasonFormId)
        {
            return PartialView("HuntingFarm/Seasons/SeasonForms/PartialEditHuntingFarmSeasonForm", repository.SprHuntingFarmSeasonForms.SingleOrDefault(hfsf => hfsf.id == huntingFarmSeasonFormId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет бланки
        /// </summary>
        /// <param name="huntingFarmSeasonForm">объект бланка</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmSeasonFormSave(spr_hunting_farm_season_forms huntingFarmSeasonForm)
        {
            if (ModelState.IsValid)
            {
                if (huntingFarmSeasonForm.id == Guid.Empty)
                {
                    repository.Insert(huntingFarmSeasonForm);
                }
                else
                {
                    huntingFarmSeasonForm.employees_fio_modifi = UserName;
                    repository.Update(huntingFarmSeasonForm);
                }
                return RedirectToAction("PartialTableHuntingFarmSeasonForms", new { huntingFarmSeasonId = huntingFarmSeasonForm.spr_hunting_farm_season_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет бланки по указанному id
        /// </summary>
        /// <param name="huntingFarmSeasonFormId">id бланка</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmSeasonFormDelete(Guid huntingFarmSeasonFormId)
        {
            spr_hunting_farm_season_forms deleteHuntingFarmSeasonForm = repository.SprHuntingFarmSeasonForms.SingleOrDefault(hfsf => hfsf.id == huntingFarmSeasonFormId);
            repository.Delete(deleteHuntingFarmSeasonForm);
            return RedirectToAction("PartialTableHuntingFarmSeasonForms", new { huntingFarmSeasonId = deleteHuntingFarmSeasonForm.spr_hunting_farm_season_id });
        }

        public ActionResult PartialTableHuntingFarmSeasonForms(Guid huntingFarmSeasonId, int page = 1)
        {
            ViewBag.HuntingFarmSeasonId = huntingFarmSeasonId;
            var huntingFarmSeasonFormList = repository.SprHuntingFarmSeasonForms.Where(hfa => hfa.spr_hunting_farm_season_id == huntingFarmSeasonId).ToList();
            HuntingFarmViewModel model = new HuntingFarmViewModel
            {
                HuntingFarmSeasonFormList = huntingFarmSeasonFormList,
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingFarmSeasonFormList.Count()
                },
            };
            return PartialView("HuntingFarm/Seasons/SeasonForms/PartialTableHuntingFarmSeasonForms", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Виды охотугодий  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление вида охотхозяйства
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddHuntingFarmType()
        {
            return PartialView("HuntingFarm/HuntingFarmTypes/PartialModalAddHuntingFarmType", new spr_hunting_farm_type { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение данных вида охотхозяйства
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditHuntingFarmType(Guid huntingFarmTypeId)
        {
            ViewBag.Animals = new SelectList(repository.SprAnimals.OrderBy(s => s.animal_name), "id", "animal_name");
            var model = repository.SprHuntingFarmTypes.SingleOrDefault(hft => hft.id == huntingFarmTypeId);
            model.employees_fio_modifi = Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
            return PartialView("HuntingFarm/HuntingFarmTypes/PartialModalEditHuntingFarmType", model);
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет виды охотхозяйства
        /// </summary>
        /// <param name="huntingFarmType">объект вида охотхозяйства</param>
        /// <returns>частичное представление таблицы "Вида охотхозяйства"</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmTypeSave(spr_hunting_farm_type huntingFarmType)
        {
            if (ModelState.IsValid)
            {
                repository.SaveHuntingFarmType(huntingFarmType);
                return RedirectToAction("PartialTableHuntingFarmTypes");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет виды охотхозяйства по указанному id
        /// </summary>
        /// <param name="huntingFarmTypeId">id вида охотхозяйства</param>
        /// <returns>частичное представление таблицы "Виды охотхозяйства"</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmTypeDelete(Guid huntingFarmTypeId)
        {
            spr_hunting_farm_type deletedHuntingFarmType = repository.DeleteHuntingFarmType(huntingFarmTypeId);
            return RedirectToAction("PartialTableHuntingFarmTypes");
        }

        public ActionResult PartialTableHuntingFarmTypes(int page = 1)
        {
            var huntingFarmTypes = repository.SprHuntingFarmTypes.ToList();
            HuntingFarmViewModel model = new HuntingFarmViewModel
            {
                HuntingFarmTypeList = huntingFarmTypes,
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingFarmTypes.Count()
                },
            };
            return PartialView("HuntingFarm/HuntingFarmTypes/PartialTableHuntingFarmTypes", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Животные охотугодья  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        /// <summary>
        /// Животные охотугодья
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalHuntingFarmAnimal(Guid huntingFarmId)
        {
            ViewBag.HuntingFarmId = huntingFarmId;
            return PartialView("HuntingFarm/HuntingFarms/HuntingFarmAnimals/PartialModalHuntingFarmAnimal");
        }

        /// <summary>
        /// Добавление животного в охотугодье
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialAddHuntingFarmAnimal(Guid huntingFarmId)
        {
            var animals = repository.SprAnimals.Include(i => i.spr_animal_group_type).Where(sa => sa.is_remove != true).Select(s => new { s.id, s.animal_name, s.spr_animal_group_type.group_type_name });
            ViewBag.Animals = new SelectList(animals.OrderBy(s => s.animal_name), "id", "animal_name", "group_type_name", 1);
            return PartialView("HuntingFarm/HuntingFarms/HuntingFarmAnimals/PartialAddHuntingFarmAnimal", new spr_hunting_farm_animal { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", spr_hunting_farm_id = huntingFarmId });
        }

        /// <summary>
        /// Изменение охотугодья
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialEditHuntingFarmAnimal(Guid huntingFarmAnimalId)
        {
            var animals = repository.SprAnimals.Include(i => i.spr_animal_group_type).Where(sa => sa.is_remove != true).Select(s => new { s.id, s.animal_name, s.spr_animal_group_type.group_type_name });
            ViewBag.Animals = new SelectList(repository.SprAnimals.OrderBy(s => s.animal_name), "id", "animal_name", "group_type_name");
            return PartialView("HuntingFarm/HuntingFarms/HuntingFarmAnimals/PartialEditHuntingFarmAnimal", repository.SprHuntingFarmAnimals.SingleOrDefault(hfa => hfa.id == huntingFarmAnimalId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет животное в охотугодье
        /// </summary>
        /// <param name="huntingFarmAnimal">объект животного в охотхозяйстве</param>
        /// <returns>частичное представление таблицы "Животные в охотхозяйстве"</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmAnimalSave(spr_hunting_farm_animal huntingFarmAnimal)
        {
            if (ModelState.IsValid)
            {
                if (huntingFarmAnimal.id == Guid.Empty)
                {
                    repository.Insert(huntingFarmAnimal);
                }
                else
                {
                    huntingFarmAnimal.employees_fio_modifi = UserName;
                    repository.Update(huntingFarmAnimal);
                }
                return RedirectToAction("PartialTableHuntingFarmAnimals", new { huntingFarmId = huntingFarmAnimal.spr_hunting_farm_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет животное я охотугодья по указанному id
        /// </summary>
        /// <param name="huntingFarmAnimalId">id животного в охотугодье</param>
        /// <returns>частичное представление таблицы "Животные в охотугодье"</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmAnimalDelete(Guid huntingFarmAnimalId)
        {
            spr_hunting_farm_animal deleteHuntingFarmAnimal = repository.SprHuntingFarmAnimals.SingleOrDefault(a => a.id == huntingFarmAnimalId);
            repository.Delete(deleteHuntingFarmAnimal);
            return RedirectToAction("PartialTableHuntingFarmAnimals", new { huntingFarmId = deleteHuntingFarmAnimal.spr_hunting_farm_id });
        }

        public ActionResult PartialTableHuntingFarmAnimals(Guid huntingFarmId, int page = 1)
        {
            ViewBag.HuntingFarmId = huntingFarmId;
            var huntingFarmAnimals = repository.SprHuntingFarmAnimals.Where(hfa => hfa.spr_hunting_farm_id == huntingFarmId).Include(hfa => hfa.spr_animal).Include(ii => ii.spr_animal.spr_animal_group_type).OrderBy(o => o.spr_animal.animal_name).ToList();
            HuntingFarmViewModel model = new HuntingFarmViewModel
            {
                HuntingFarmAnimalList = huntingFarmAnimals.Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 7,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingFarmAnimals.Count()
                },
            };
            return PartialView("HuntingFarm/HuntingFarms/HuntingFarmAnimals/PartialTableHuntingFarmAnimals", model);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Лимиты  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление лимита
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddHuntingFarmLimit(Guid seasonAnimalId)
        {
            var accountings = repository.SprHuntingFarmSeasonAnimals.Where(sa => sa.id == seasonAnimalId).Join(repository.SprHuntingFarmAccountings, sa => new { sa.spr_animal_id, sa.spr_hunting_farm_season.spr_hunting_farm_id }, hfa => new { hfa.spr_animal_id, hfa.spr_hunting_farm_id }, (sa, hfa) => hfa).Where(hfa => hfa.is_remove != true).Include(i => i.spr_animal_method_account).ToList().Select(s => new
            {
                s.id,
                method_name = s.spr_animal_method_account.method_name + " - (" + s.year_ + ", " + (s.animal_sex == 1 ? "Самец" : s.animal_sex == 2 ? "Самка" : "БП") + ", " + (s.animal_age == 1 ? "До года" : s.animal_sex == 2 ? "Старше года" : "БВ") + ", " + s.count_animal + ")"
            });
            ViewBag.Accountings = new SelectList(accountings.OrderBy(s => s.method_name), "id", "method_name");
            return PartialView("HuntingFarm/HuntingFarmsLimits/PartialModalAddHuntingFarmLimit", new spr_hunting_farm_limit
            {
                employees_fio = UserName,
                spr_hunting_farm_season_animal_id = seasonAnimalId
            });
        }

        /// <summary>
        /// Изменение лимита
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditHuntingFarmLimit(Guid huntingFarmLimitId)
        {
            var accountings = repository.SprHuntingFarmLimits.Where(hfl=>hfl.id == huntingFarmLimitId).Join(repository.SprHuntingFarmSeasonAnimals, hfl=>hfl.spr_hunting_farm_season_animal_id, sa=>sa.id, (hfl, sa)=>sa).Join(repository.SprHuntingFarmAccountings, sa => new { sa.spr_animal_id, sa.spr_hunting_farm_season.spr_hunting_farm_id }, hfa => new { hfa.spr_animal_id, hfa.spr_hunting_farm_id }, (sa, hfa) => hfa).Where(hfa => hfa.is_remove != true).Include(i => i.spr_animal_method_account).ToList().Select(s => new
            {
                s.id,
                method_name = s.spr_animal_method_account.method_name + " - (" + s.year_ + ", " + (s.animal_sex == 1 ? "Самец" : s.animal_sex == 2 ? "Самка" : "БП") + ", " + (s.animal_age == 1 ? "До года" : s.animal_sex == 2 ? "Старше года" : "БВ") + ", " + s.count_animal + ")"
            });
            ViewBag.Accountings = new SelectList(accountings.OrderBy(s => s.method_name), "id", "method_name");
            return PartialView("HuntingFarm/HuntingFarmsLimits/PartialModalEditHuntingFarmLimit", repository.SprHuntingFarmLimits.SingleOrDefault(hfl => hfl.id == huntingFarmLimitId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет лимит
        /// </summary>
        /// <param name="huntingFarmLimit">объект лимита</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmLimitSave(spr_hunting_farm_limit huntingFarmLimit)
        {
            ModelState["spr_hunting_farm_accounting"]?.Errors?.Clear();
            if (ModelState.IsValid)
            {
                if (huntingFarmLimit.id == Guid.Empty)
                {
                    repository.Insert(huntingFarmLimit);
                }
                else
                {
                    huntingFarmLimit.employees_fio_modifi = UserName;
                    repository.Update(huntingFarmLimit);
                }
                return RedirectToAction("PartialTableHuntingFarmLimits", new { seasonAnimalId = huntingFarmLimit.spr_hunting_farm_season_animal_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="huntingFarmLimitId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmLimitRecovery(Guid huntingFarmLimitId)
        {
            spr_hunting_farm_limit recoveryHuntingFarmLimit = repository.SprHuntingFarmLimits.SingleOrDefault(sa => sa.id == huntingFarmLimitId);

            recoveryHuntingFarmLimit.is_remove = false;
            repository.Update(recoveryHuntingFarmLimit);
            return RedirectToAction("PartialTableHuntingFarmLimits", new { seasonAnimalId = recoveryHuntingFarmLimit.spr_hunting_farm_season_animal_id });
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="huntingFarmLimitId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmLimitDelete(Guid huntingFarmLimitId, string comment)
        {
            spr_hunting_farm_limit deleteHuntingFarmLimit = repository.SprHuntingFarmLimits.SingleOrDefault(hfl => hfl.id == huntingFarmLimitId);
            deleteHuntingFarmLimit.is_remove = true;
            deleteHuntingFarmLimit.date_remove = DateTime.Now;
            deleteHuntingFarmLimit.employees_fio_modifi = UserName;
            deleteHuntingFarmLimit.commentt_remove = comment;
            repository.Update(deleteHuntingFarmLimit);
            return RedirectToAction("PartialTableHuntingFarmLimits", new { seasonAnimalId = deleteHuntingFarmLimit.spr_hunting_farm_season_animal_id });
        }

        public ActionResult PartialTableHuntingFarmLimits(Guid seasonAnimalId, bool isRemove = false, int page = 1)
        {
            ViewBag.SeasonAnimalId = seasonAnimalId;
            ViewBag.IsRemove = isRemove;
            var steps = repository.SprHuntingFarmSeasonAnimals.Where(w => w.id == seasonAnimalId).Include(i => i.spr_hunting_farm_season.spr_hunting_farm).Include(i => i.spr_animal.spr_animal_group_type).SingleOrDefault();
            Dictionary<string, string> Steps = new Dictionary<string, string>();
            Steps.Add("ion-android-locate", steps.spr_hunting_farm_season.spr_hunting_farm.hunting_farm_name);
            Steps.Add("ion-ios7-paw", steps.spr_animal.spr_animal_group_type.group_type_name + " - " + steps.spr_animal.animal_name);
            ViewBag.StepValues = Steps;

            var huntingFarmLimits = repository.SprHuntingFarmLimits.Where(hfl => hfl.spr_hunting_farm_season_animal_id == seasonAnimalId).Include(i => i.spr_hunting_farm_accounting.spr_animal_method_account);
            huntingFarmLimits = !isRemove ? huntingFarmLimits.Where(o => o.is_remove != true) : huntingFarmLimits;

            HuntingFarmViewModel model = new HuntingFarmViewModel
            {
                HuntingFarmLimitList = huntingFarmLimits,
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingFarmLimits.Count()
                },
            };
            return PartialView("HuntingFarm/HuntingFarmsLimits/PartialTableHuntingFarmLimits", model);
        }

        #endregion
    }
}