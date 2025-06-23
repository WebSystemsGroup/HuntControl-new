using HuntControl.Domain.Abstract;
using HuntControl.WebUI.Filters;
using HuntControl.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Controllers
{
    [ClientErrorHandler]
    [Authorize]
    public class SeasonController : Controller
    {
        public int PageSize = 7;

        #region Инициализация Repository
        private IRepository repository;
        private string UserName => Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
        public SeasonController(IRepository repo)
        {
            repository = repo;
        }
        #endregion

        public ActionResult Main()
        {
            return View();
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Сезоны охоты  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult HuntingFarms()
        {
            try
            {
                ViewBag.SprHuntingFarmsType = new SelectList(repository.SprHuntingFarmTypes.OrderBy(s => s.type_name), "id", "type_name");
                return PartialView("HuntingFarms/HuntingFarms");
            }
            catch (Exception ex)
            {
                return PartialView(ex);
            }
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
                HuntingFarmList = huntingFarms.OrderBy(s => s.hunting_farm_name).Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PageInfo = new PageInfo
                {
                    MaxPageList = 3,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingFarms.Count()
                },
            };
            return PartialView("HuntingFarms/PartialTableHuntingFarms", model);
        }

        public ActionResult PartialTableHuntingFarmSteps(Guid huntingFarmId)
        {
            ViewBag.huntingFarmId = huntingFarmId;
            return PartialView("HuntingFarms/PartialHuntingFarmsSteps");
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Масетр добавления сезона охоты  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Мастер добавления годового учёта
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        public ActionResult PartialModalWizardAddSeason()
        {
            ViewBag.AnimalGroupTypes = new SelectList(repository.SprAnimalGroupTypes.Where(agt=>agt.is_remove != true).OrderBy(s => s.group_type_name), "id", "group_type_name");
            return PartialView("HuntingFarms/PartialModalWizardAddSeason", new spr_hunting_farm_season { employees_fio = UserName });
        }



        #region исправить названия
        public ActionResult PartialModalWizardAddHuntSeason()
        {
            ViewBag.AnimalGroupTypes = new SelectList(repository.SprSeasons.OrderBy(s => s.season_name), "id", "season_name");
            return PartialView("HuntingFarms/_partialAddHunterSeason", new spr_season { employees_fio_modify = UserName });
        }

        public ActionResult PartialWizardAddHuntSeason(int idSeason, int year, DateTime dStart, DateTime dEnd)
        {
            ViewBag.idSeason = idSeason;
            ViewBag.year = year;
            ViewBag.DataStart = dStart.ToShortDateString();
            ViewBag.DateEnd = dEnd.ToShortDateString();
            var model = repository.FuncGetCustomerHuntingSeason(idSeason, year).OrderBy(a=>a.out_hunting_farm_name).ToArray();
           
            return PartialView("HuntingFarms/_partialAddSeason", model);
        }

        public JsonResult GetSearchingData( string SearchValue, int year, int idSeason)
        {
            List<CustomerHuntingSeason> stInform = new List<CustomerHuntingSeason>();
            if (SearchValue != "noSearchString")
            {
                char[] strUpper = SearchValue.ToCharArray();
                strUpper[0] = Convert.ToChar(Convert.ToInt32(strUpper[0]) - 32);
                string s = new string(strUpper);
                var model = repository.FuncGetCustomerHuntingSeason(idSeason, year).OrderBy(a => a.out_hunting_farm_name).ToArray();
                stInform = model.Where(x => x.out_hunting_farm_name.Contains(SearchValue) || x.out_hunting_farm_name.Contains(s) || SearchValue == null).ToList();
            }
            else
            {
                stInform = repository.FuncGetCustomerHuntingSeason(idSeason, year).OrderBy(a => a.out_hunting_farm_name).ToList();
            }
            return Json(stInform, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddHuntFurmSeason(int idSeason, string datStart,string datEnd,string Year, string[][] minearray)
        {
            DateTime ds = Convert.ToDateTime(datStart);
            DateTime de = Convert.ToDateTime(datEnd);
                Guid farmIdOld = Guid.Empty;
                var sprHuntingFarmSeason = new spr_hunting_farm_season();
            for (int i = 0; i < minearray.Length; i++)
            {
                int nd = int.Parse(minearray[i][0]);
                int ns = int.Parse(minearray[i][1]);
                Guid farmId = Guid.Parse(minearray[i][2]);
                Guid animalId = Guid.Parse(minearray[i][3]);
                Guid accountId = Guid.Parse(minearray[i][4]);

                if (farmId != farmIdOld)
                {
                    sprHuntingFarmSeason = new spr_hunting_farm_season();
                    sprHuntingFarmSeason.spr_season_id = idSeason;
                    sprHuntingFarmSeason.date_start = ds;
                    sprHuntingFarmSeason.date_stop = de;
                    sprHuntingFarmSeason.employees_fio = UserName;
                    sprHuntingFarmSeason.spr_hunting_farm_id = farmId;                    
                    repository.Insert(sprHuntingFarmSeason);
                    farmIdOld = farmId;
                }
                //var huntFarmAnimal = repository.SprHuntingFarmSeasonAnimals.FirstOrDefault(x => x.spr_hunting_farm_season_id == sprHuntingFarmSeason.id && x.spr_animal_id == animalId);
                var huntFarmAnimal = new spr_hunting_farm_season_animal()
                {
                    employees_fio = UserName,
                    spr_animal_id = animalId,
                    spr_hunting_farm_season_id = sprHuntingFarmSeason.id,
                    date_start = ds,
                    date_stop = de,
                    set_date = DateTime.Now
                };
                repository.Insert(huntFarmAnimal);


                var sprHuntingFarmLimit = new spr_hunting_farm_limit()
                {
                    limit_day = nd,
                    limit_season = ns,
                    spr_hunting_farm_accounting_id = accountId,
                    spr_hunting_farm_season_animal_id = huntFarmAnimal.id,
                    employees_fio = UserName                    
                };
                repository.Insert(sprHuntingFarmLimit);


            }

            return null;
        }


        #endregion





        public ActionResult PartialListWizardAnimals(Guid animalGroupTypeId, DateTime dateStart, DateTime dateStop)
        {
            ViewBag.DateStart = dateStart.ToShortDateString();
            ViewBag.DateStop = dateStop.ToShortDateString();
            var animals = repository.SprAnimals.Where(a => a.spr_animal_group_type_id == animalGroupTypeId)
                .Where(hf => hf.is_remove != true).OrderBy(o => o.animal_name);
            var model = new AnimalViewModel
            {
                AnimalList = animals,
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    ItemsPerPage = PageSize,
                    TotalItems = animals.Count()
                },
            };
            return PartialView("HuntingFarms/PartialListWizardAnimals", model);
        }

        public ActionResult PartialListWizardSeasonHuntingFarms(List<spr_hunting_farm_season_animal> animalSeasons)
        {
            var huntingFarms = animalSeasons.Join(repository.SprHuntingFarmAnimals, a=>a.spr_animal_id, hfa=>hfa.spr_animal_id,(a,hfa)=>hfa)
                .Join(repository.SprHuntingFarms, hfa => hfa.spr_hunting_farm_id, hf => hf.id, (hfa, hf) => hf)
                .Where(hf => hf.is_remove != true).OrderBy(o => o.hunting_farm_name).Distinct().ToList();
            var model = new HuntingFarmViewModel
            {
                HuntingFarmList = huntingFarms,
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingFarms.Count()
                },
            };
            return PartialView("HuntingFarms/PartialListWizardSeasonHuntingFarms", model);
        }

        /// <summary>
        /// Мастер добавления сезона
        /// </summary>
        /// <param name="huntingFarmSeason"></param>
        /// <param name="animalSeasons"></param>
        /// <param name="huntingFarms"></param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult WizardSeasonSave(spr_hunting_farm_season huntingFarmSeason, List<spr_hunting_farm_season_animal> animalSeasons, List<Guid> huntingFarms)
        {
            foreach (var huntingFarm in huntingFarms)
            {
                var model = new spr_hunting_farm_season
                {
                    date_start = huntingFarmSeason.date_start,
                    date_stop = huntingFarmSeason.date_stop,
                    spr_hunting_farm_id = huntingFarm,
                    spr_season_id = huntingFarmSeason.spr_season_id,
                    employees_fio = UserName
                };
                repository.Insert(model);
                foreach (var animalSeason in animalSeasons)
                {
                    animalSeason.employees_fio = UserName;
                    animalSeason.spr_hunting_farm_season_id = model.id;
                    animalSeason.density_habitat = 0;
                    repository.Insert(animalSeason);
                }
            }
            return Json("Данные успешно добавлены", JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Данные учета  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult AccountingData()
        {
            ViewBag.SprAnimalGroupTypes = new SelectList(repository.SprAnimalGroupTypes.OrderBy(s => s.group_type_name), "id", "group_type_name");
            return PartialView("AccountingData/AccountingData");
        }

        public ActionResult PartialAnimalList(string search, Guid? sprAnimalGroupTypeId, int page = 1)
        {
            ViewBag.Serach = search;
            ViewBag.SprAnimalGroupTypeId = sprAnimalGroupTypeId;
            var anumals = repository.SprAnimals.Where(sa => sa.is_remove != true).Include(i => i.spr_animal_group_type);
            if (sprAnimalGroupTypeId != null)
            {
                anumals = anumals.Where(w => w.spr_animal_group_type_id == sprAnimalGroupTypeId);
            }
            anumals = String.IsNullOrEmpty(search) ? anumals :
                search.ToLower().Split().Aggregate(anumals, (current, item) => current.Where(h => h.animal_name.ToLower().Contains(item)));

            AnimalViewModel model = new AnimalViewModel
            {
                AnimalList = anumals.OrderBy(s => s.animal_name).Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PageInfo = new PageInfo
                {
                    MaxPageList = 3,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = anumals.Count()
                },
            };
            return PartialView("AccountingData/PartialAnimalList", model);
        }

        public ActionResult PartialTableHuntingFarmAccountings(Guid animalId, bool isRemove = false, int page = 1)
        {
            ViewBag.AnimalId = animalId;
            ViewBag.IsRemove = isRemove;
            var huntingFarmAccountings = repository.SprHuntingFarmAccountings.Where(hfa => hfa.spr_animal_id == animalId).Include(hfa => hfa.spr_animal).Include(hfa => hfa.spr_animal_method_account).Include(hfa => hfa.spr_hunting_farm);
            huntingFarmAccountings = !isRemove ? huntingFarmAccountings.Where(o => o.is_remove != true) : huntingFarmAccountings;
            HuntingFarmViewModel model = new HuntingFarmViewModel
            {
                HuntingFarmAccountingList = huntingFarmAccountings.OrderBy(s => s.spr_animal.animal_name).Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingFarmAccountings.Count()
                },
            };
            return PartialView("AccountingData/PartialTableHuntingFarmAccountings", model);
        }

        /// <summary>
        /// Добавление годового учёта
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddHuntingFarmAccounting(Guid animalId)
        {
            var methodAccounts = repository.SprAnimalMethodAccounts.Where(ma => ma.is_remove != true);
            var huntingFarms = repository.SprHuntingFarmAnimals.Where(hfa => hfa.spr_animal_id == animalId).Join(repository.SprHuntingFarms, hfa => hfa.spr_hunting_farm_id, hf => hf.id, (hfa, hf) => hf).Where(hf => hf.is_remove != true);
            ViewBag.MethodAccounts = new SelectList(methodAccounts.OrderBy(s => s.method_name), "id", "method_name");
            ViewBag.HuntingFarms = new SelectList(huntingFarms.OrderBy(s => s.hunting_farm_name), "id", "hunting_farm_name");
            return PartialView("AccountingData/PartialModalAddAccounting", new spr_hunting_farm_accounting { employees_fio = UserName, spr_animal_id = animalId });
        }

        /// <summary>
        /// Изменение годового учёта
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditHuntingFarmAccounting(Guid huntingFarmAccountingId)
        {
            var methodAccounts = repository.SprAnimalMethodAccounts.Where(ma => ma.is_remove != true);
            var huntingFarms = repository.SprHuntingFarmAccountings.Where(hfac => hfac.id == huntingFarmAccountingId).Join(repository.SprHuntingFarmAnimals, hfac => hfac.spr_animal_id, hfa => hfa.spr_animal_id, (hfac, hfa) => hfa).Join(repository.SprHuntingFarms, hfa => hfa.spr_hunting_farm_id, hf => hf.id, (hfa, hf) => hf).Where(hf => hf.is_remove != true);
            ViewBag.MethodAccounts = new SelectList(methodAccounts.OrderBy(s => s.method_name), "id", "method_name");
            ViewBag.HuntingFarms = new SelectList(huntingFarms.OrderBy(s => s.hunting_farm_name), "id", "hunting_farm_name");
            return PartialView("AccountingData/PartialModalEditAccounting", repository.SprHuntingFarmAccountings.SingleOrDefault(hfa => hfa.id == huntingFarmAccountingId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет годовой учёт
        /// </summary>
        /// <param name="huntingFarmAccounting">объект годового учёта</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmAccountingSave(spr_hunting_farm_accounting huntingFarmAccounting)
        {
            if (ModelState.IsValid)
            {
                if (huntingFarmAccounting.id == Guid.Empty)
                {
                    repository.Insert(huntingFarmAccounting);
                }
                else
                {
                    huntingFarmAccounting.employees_fio_modifi = UserName;
                    repository.Update(huntingFarmAccounting);
                }
                return RedirectToAction("PartialTableHuntingFarmAccountings", new { animalId = huntingFarmAccounting.spr_animal_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="seasonAnimalId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmAccountingRecovery(Guid huntingFarmAccountingId)
        {
            spr_hunting_farm_accounting recoveryHuntingFarmAccounting = repository.SprHuntingFarmAccountings.SingleOrDefault(sa => sa.id == huntingFarmAccountingId);

            recoveryHuntingFarmAccounting.is_remove = false;
            repository.Update(recoveryHuntingFarmAccounting);
            return RedirectToAction("PartialTableHuntingFarmAccountings", new { animalId = recoveryHuntingFarmAccounting.spr_animal_id });
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="seasonAnimalId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmAccountingDelete(Guid huntingFarmAccountingId, string comment)
        {
            spr_hunting_farm_accounting deleteHuntingFarmAccounting = repository.SprHuntingFarmAccountings.SingleOrDefault(sa => sa.id == huntingFarmAccountingId);
            deleteHuntingFarmAccounting.is_remove = true;
            deleteHuntingFarmAccounting.date_remove = DateTime.Now;
            deleteHuntingFarmAccounting.employees_fio_modifi = UserName;
            deleteHuntingFarmAccounting.commentt_remove = comment;
            repository.Update(deleteHuntingFarmAccounting);
            return RedirectToAction("PartialTableHuntingFarmAccountings", new { animalId = deleteHuntingFarmAccounting.spr_animal_id });
        }


        /// <summary>
        /// Мастер добавления годового учёта
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        public ActionResult PartialModalWizardAddAccounting()
        {
            var methodAccounts = repository.SprAnimalMethodAccounts.Where(ma => ma.is_remove != true);
            var animals = repository.SprAnimals.Where(a => a.is_remove != true).OrderBy(o=>o.animal_name);
            ViewBag.MethodAccounts = new SelectList(methodAccounts.OrderBy(s => s.method_name), "id", "method_name");
            ViewBag.Animals = new SelectList(animals.OrderBy(s => s.animal_name), "id", "animal_name");
            return PartialView("AccountingData/PartialModalWizardAddAccounting", new spr_hunting_farm_accounting { employees_fio = UserName });
        }

        public ActionResult PartialListWizardHuntingFarms(Guid animalId)
        {
            var huntingFarms = repository.SprHuntingFarmAnimals.Where(hfa => hfa.spr_animal_id == animalId)
                .Join(repository.SprHuntingFarms, hfa => hfa.spr_hunting_farm_id, hf => hf.id, (hfa, hf) => hf)
                .Where(hf => hf.is_remove != true).OrderBy(o=>o.hunting_farm_name);
            var model = new HuntingFarmViewModel
            {
                HuntingFarmList = huntingFarms,
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingFarms.Count()
                },
            };
            return PartialView("AccountingData/PartialListWizardHuntingFarms", model);
        }

        /// <summary>
        /// Мастер добавления годового учёта
        /// </summary>
        /// <param name="huntingFarmAccounting">объект годового учёта</param>
        /// <param name="countAnimal"></param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult WizardAccountingSave(spr_hunting_farm_accounting huntingFarmAccounting, Dictionary<string, int> countAnimal)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in countAnimal)
                {
                    if (item.Value > 0)
                    {
                        huntingFarmAccounting.spr_hunting_farm_id = Guid.Parse(item.Key);
                        huntingFarmAccounting.count_animal = item.Value;
                        huntingFarmAccounting.employees_fio = UserName;
                        repository.Insert(huntingFarmAccounting);
                    }
                }
                return Json("Данные успешно добавлены", JsonRequestBehavior.AllowGet);
            }
            throw new Exception("Ошибка валидации!");
        }
    }

    #endregion

}
