using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Concrete;
using HuntControl.WebUI.Models;

namespace HuntControl.WebUI.Controllers
{
    public partial class ReferenceController
    {

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Животные  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult Animals()
        {
            return View("Animals/Animals");
        }
        /// <summary>
        /// Добавление животного
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddAnimal()
        {
            ViewBag.AnimalGroupTypes = new SelectList(repository.SprAnimalGroupTypes.Where(w => w.is_remove != true).OrderBy(s => s.group_type_name), "id", "group_type_name");
            return PartialView("Animals/Animals/PartialModalAddAnimal", new spr_animal { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение животного
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditAnimal(Guid animalId)
        {
            var animal = repository.SprAnimals.SingleOrDefault(sa => sa.id == animalId);
            if (animal.file_ext != null && animal.file_name != null)
            {
                var settings = repository.SprSettings.ToList();
                var ftpModel =
                    new
                    {
                        ftpServer = settings.SingleOrDefault(ss => ss.param_name == "ftp_server")?.param_value,
                        ftpFolder = settings.SingleOrDefault(ss => ss.param_name == "ftp_folder")?.param_value,
                        ftpLogin = settings.SingleOrDefault(ss => ss.param_name == "ftp_user")?.param_value,
                        ftpPass = CRPassword.Encrypt(settings.SingleOrDefault(ss => ss.param_name == "ftp_password")?.param_value),
                    };
                FtpFileModel ftp = new FtpFileModel();
                byte[] fileData = ftp.OpenFile(ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder, animalId + animal.file_ext, "Animal_photos");
                if (fileData != null)
                    ViewBag.AnimalPhoto = "data:" + MimeTypes.GetMimeType(animal.file_ext) + ";base64, " + Convert.ToBase64String(fileData);
            }

            ViewBag.AnimalGroupTypes = new SelectList(repository.SprAnimalGroupTypes.Where(w => w.is_remove != true).OrderBy(s => s.group_type_name), "id", "group_type_name");
            return PartialView("Animals/Animals/PartialModalEditAnimal", repository.SprAnimals.SingleOrDefault(a => a.id == animalId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет животного
        /// </summary>
        /// <param name="animal">объект животного</param>
        /// <returns>частичное представление таблицы "Животные"</returns>
        [HttpPost]
        public ActionResult SubmitAnimalSave(spr_animal animal, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (animal.id == Guid.Empty)
                {
                    animal.employees_fio_modifi = UserName;
                    if (uploadImage != null)
                    {
                        animal.file_name = Path.GetFileNameWithoutExtension(uploadImage.FileName);
                        animal.file_ext = Path.GetExtension(uploadImage.FileName);
                    }
                    repository.Insert(animal);
                }
                else
                {
                    animal.employees_fio_modifi = UserName;
                    if (uploadImage != null)
                    {
                        animal.file_name = Path.GetFileNameWithoutExtension(uploadImage.FileName);
                        animal.file_ext = Path.GetExtension(uploadImage.FileName);
                    }
                    repository.Update(animal);
                }

                var settings = repository.SprSettings.ToList();
                var ftpModel =
                    new
                    {
                        ftpServer = settings.SingleOrDefault(ss => ss.param_name == "ftp_server")?.param_value,
                        ftpFolder = settings.SingleOrDefault(ss => ss.param_name == "ftp_folder")?.param_value,
                        ftpLogin = settings.SingleOrDefault(ss => ss.param_name == "ftp_user")?.param_value,
                        ftpPass =
                            CRPassword.Encrypt(
                                settings.SingleOrDefault(ss => ss.param_name == "ftp_password")?.param_value),
                    };

                FtpFileModel ftp = new FtpFileModel();


                if (uploadImage != null)
                {
                    ftp.RemoveFile(ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder, animal.id + animal.file_ext, "Animal_photos");
                    //считаем загруженный файл в массив
                    byte[] fileArray = new byte[uploadImage.ContentLength];
                    uploadImage.InputStream.Read(fileArray, 0, uploadImage.ContentLength);
                    ftp.FileSave(fileArray, ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder,
                        animal.id + Path.GetExtension(uploadImage.FileName), "Animal_photos");
                }
                return RedirectToAction("PartialTableAnimals");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAnimalPhotoDelete(string fileName)
        {
            var settings = repository.SprSettings.ToList();
            var ftpModel =
                new
                {
                    ftpServer = settings.SingleOrDefault(ss => ss.param_name == "ftp_server")?.param_value,
                    ftpFolder = settings.SingleOrDefault(ss => ss.param_name == "ftp_folder")?.param_value,
                    ftpLogin = settings.SingleOrDefault(ss => ss.param_name == "ftp_user")?.param_value,
                    ftpPass =
                        CRPassword.Encrypt(
                            settings.SingleOrDefault(ss => ss.param_name == "ftp_password")?.param_value),
                };

            FtpFileModel ftp = new FtpFileModel();
            ftp.RemoveFile(ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder, fileName, "Animal_photos");
            return Json("Файл успешно удален", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="animalId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAnimalRecovery(Guid animalId)
        {
            spr_animal recoveryAnimal = repository.SprAnimals.SingleOrDefault(sa => sa.id == animalId);

            recoveryAnimal.is_remove = false;
            recoveryAnimal.employees_fio_modifi = UserName;
            repository.Update(recoveryAnimal);
            return RedirectToAction("PartialTableAnimals");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="animalId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAnimalDelete(Guid animalId, string comment)
        {
            spr_animal deleteAnimal = repository.SprAnimals.SingleOrDefault(sa => sa.id == animalId);
            deleteAnimal.is_remove = true;
            deleteAnimal.date_remove = DateTime.Now;
            deleteAnimal.employees_fio_modifi = UserName;
            deleteAnimal.commentt_remove = comment;
            repository.Update(deleteAnimal);
            return RedirectToAction("PartialTableAnimals");
        }

        public ActionResult PartialTableAnimals(string search, bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            ViewBag.Search = search;
            var animals = repository.SprAnimals.Include(a => a.spr_animal_group_type).Include(i => i.spr_animal_location).Include(i => i.spr_hunting_farm_animal);
            animals = !isRemove ? animals.Where(o => o.is_remove != true) : animals;
            animals = String.IsNullOrEmpty(search) ? animals :
                search.ToLower().Split().Aggregate(animals, (current, item) => current.Where(h => h.animal_name.ToLower().Contains(item) || h.spr_animal_group_type.group_type_name.ToLower().Contains(item)));

            AnimalViewModel model = new AnimalViewModel
            {
                AnimalList = animals.OrderBy(a => a.spr_animal_group_type.group_type_name).ThenBy(a => a.animal_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = animals.Count()
                },
            };
            return PartialView("Animals/Animals/PartialTableAnimals", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Охотугодья животного ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        /// <summary>
        /// Животные охотугодья
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAnimalHuntingFarm(Guid animalId)
        {
            ViewBag.AnimalId = animalId;
            return PartialView("Animals/Animals/AnimalHuntingFarms/PartialModalAnimalHuntingFarms");
        }

        /// <summary>
        /// Добавление животного в охотугодья
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialAddAnimalHuntingFarms(Guid animalId)
        {
            var huntingFarms = repository.SprHuntingFarms.Include(i => i.spr_hunting_farm_type).Where(sa => sa.is_remove != true).Select(s => new { s.id, s.hunting_farm_name, s.spr_hunting_farm_type.type_name });
            ViewBag.HuntingFarms = new SelectList(huntingFarms.OrderBy(s => s.type_name), "id", "hunting_farm_name", "type_name", 1);
            return PartialView("Animals/Animals/AnimalHuntingFarms/PartialAddAnimalHuntingFarms", new spr_hunting_farm_animal { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", spr_animal_id = animalId });
        }

        /// <summary>
        /// Изменение животного
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialEditAnimalHuntingFarms(Guid huntingFarmAnimalId)
        {
            var huntingFarms = repository.SprHuntingFarms.Include(i => i.spr_hunting_farm_type).Where(sa => sa.is_remove != true).Select(s => new { s.id, s.hunting_farm_name, s.spr_hunting_farm_type.type_name });
            ViewBag.HuntingFarms = new SelectList(repository.SprHuntingFarms.OrderBy(s => s.hunting_farm_name), "id", "hunting_farm_name", "type_name");
            return PartialView("Animals/Animals/AnimalHuntingFarms/PartialEditAnimalHuntingFarms", repository.SprHuntingFarmAnimals.SingleOrDefault(hfa => hfa.id == huntingFarmAnimalId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет животное в охотугодье
        /// </summary>
        /// <param name="huntingFarmAnimal">объект животного в охотхозяйстве</param>
        /// <returns>частичное представление таблицы "Животные в охотхозяйстве"</returns>
        [HttpPost]
        public ActionResult SubmitAnimalHuntingFarmSave(spr_hunting_farm_animal huntingFarmAnimal)
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
                return RedirectToAction("PartialTableAnimalHuntingFarms", new { animalId = huntingFarmAnimal.spr_animal_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет животное я охотугодья по указанному id
        /// </summary>
        /// <param name="huntingFarmAnimalId">id животного в охотугодье</param>
        /// <returns>частичное представление таблицы "Животные в охотугодье"</returns>
        [HttpPost]
        public ActionResult SubmitAnimalHuntingFarmDelete(Guid huntingFarmAnimalId)
        {
            spr_hunting_farm_animal deleteHuntingFarmAnimal = repository.SprHuntingFarmAnimals.SingleOrDefault(a => a.id == huntingFarmAnimalId);
            repository.Delete(deleteHuntingFarmAnimal);
            return RedirectToAction("PartialTableAnimalHuntingFarms", new { animalId = deleteHuntingFarmAnimal.spr_animal_id });
        }

        public ActionResult PartialTableAnimalHuntingFarms(Guid animalId, string search, bool isRemove = false, int page = 1)
        {
            ViewBag.AnimalId = animalId;
            ViewBag.IsRemove = isRemove;
            ViewBag.Search = search;
            var huntingFarmAnimals = repository.SprHuntingFarmAnimals.Where(hfa => hfa.spr_animal_id == animalId).Include(hfa => hfa.spr_hunting_farm);
            huntingFarmAnimals = !isRemove ? huntingFarmAnimals.Where(o => o.is_remove != true) : huntingFarmAnimals;
            huntingFarmAnimals = String.IsNullOrEmpty(search) ? huntingFarmAnimals :
                search.ToLower().Split().Aggregate(huntingFarmAnimals, (current, item) => current.Where(h => h.spr_hunting_farm.hunting_farm_name.ToLower().Contains(item)));

            HuntingFarmViewModel model = new HuntingFarmViewModel
            {
                HuntingFarmAnimalList = huntingFarmAnimals.OrderBy(o => o.spr_hunting_farm.hunting_farm_name).Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingFarmAnimals.Count()
                },
            };
            return PartialView("Animals/Animals/AnimalHuntingFarms/PartialTableAnimalHuntingFarms", model);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Координаты  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|



        /// <summary>
        /// Координаты
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAnimalLocation(Guid animalId)
        {
            ViewBag.AnimalId = animalId;
            return PartialView("Animals/Animals/Locations/PartialModalAnimalLocation");
        }

        /// <summary>
        /// Получение координат охотугодий
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        public ActionResult GetAnimalCoords(Guid animalId)
        {
            var animalCoords = repository.SprAnimals.Where(sa => sa.id == animalId).Include(i => i.spr_animal_location).Select(s => new { s.id, coords = s.spr_animal_location.OrderBy(o => o.spr_animal.animal_name).Select(s2 => new { lat = s2.latitude, lng = s2.longitude }) }).ToList();
            return Json(animalCoords, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет запись
        /// </summary>
        /// <param name="animalLocations">объект</param>
        /// <param name="animalId"></param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAnimalLocationSave(List<spr_animal_location> animalLocations, Guid animalId)
        {
            var locations = repository.SprAnimalLocations.Where(l => l.spr_animal_id == animalId);
            foreach (var sprAnimalLocation in locations)
            {
                repository.Delete(sprAnimalLocation);
            }

            foreach (var location in animalLocations)
            {
                repository.Insert(new spr_animal_location { spr_animal_id = animalId, latitude = location.latitude, longitude = location.longitude });
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Группы  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddAnimalGroup()
        {
            return PartialView("Animals/AnimalGroups/PartialModalAddAnimalGroup", new spr_animal_group { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditAnimalGroup(Guid animalGroupId)
        {
            return PartialView("Animals/AnimalGroups/PartialModalEditAnimalGroup", repository.SprAnimalGroups.SingleOrDefault(g => g.id == animalGroupId));
        }

        /// <summary>
        /// изменнения или добавление
        /// </summary>
        /// <param name="animalGroup">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAnimalGroupSave(spr_animal_group animalGroup)
        {
            if (ModelState.IsValid)
            {
                if (animalGroup.id == Guid.Empty)
                {
                    repository.Insert(animalGroup);
                }
                else
                {
                    animalGroup.employees_fio_modifi = UserName;
                    repository.Update(animalGroup);
                }
                return RedirectToAction("PartialTableAnimalGroups");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="animalGroupId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAnimalGroupRecovery(Guid animalGroupId)
        {
            spr_animal_group recoveryAnimalGroup = repository.SprAnimalGroups.SingleOrDefault(sag => sag.id == animalGroupId);

            recoveryAnimalGroup.is_remove = false;
            repository.Update(recoveryAnimalGroup);
            return RedirectToAction("PartialTableAnimalGroups");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="animalGroupId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAnimalGroupDelete(Guid animalGroupId, string comment)
        {
            spr_animal_group deleteAnimalGroup = repository.SprAnimalGroups.SingleOrDefault(sag => sag.id == animalGroupId);
            deleteAnimalGroup.is_remove = true;
            deleteAnimalGroup.date_remove = DateTime.Now;
            deleteAnimalGroup.employees_fio_modifi = UserName;
            deleteAnimalGroup.commentt_remove = comment;
            repository.Update(deleteAnimalGroup);
            return RedirectToAction("PartialTableAnimalGroups");
        }

        public ActionResult PartialTableAnimalGroups(bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            var animalGroups = repository.SprAnimalGroups;
            animalGroups = !isRemove ? animalGroups.Where(o => o.is_remove != true) : animalGroups;

            AnimalViewModel model = new AnimalViewModel
            {
                AnimalGroupList = animalGroups.OrderBy(at => at.identity_).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = animalGroups.Count()
                },
            };
            return PartialView("Animals/AnimalGroups/PartialTableAnimalGroups", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Группы видов  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddAnimalGroupType()
        {
            var groups = repository.SprAnimalGroups.Where(ag => ag.is_remove != true);
            ViewBag.AnimalGroups = new SelectList(groups.OrderBy(s => s.group_name), "id", "group_name");
            return PartialView("Animals/AnimalGroupTypes/PartialModalAddAnimalGroupType", new spr_animal_group_type { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditAnimalGroupType(Guid animalGroupTypeId)
        {
            var groups = repository.SprAnimalGroups.Where(ag => ag.is_remove != true);
            ViewBag.AnimalGroups = new SelectList(groups.OrderBy(s => s.group_name), "id", "group_name");
            return PartialView("Animals/AnimalGroupTypes/PartialModalEditAnimalGroupType", repository.SprAnimalGroupTypes.SingleOrDefault(at => at.id == animalGroupTypeId));
        }

        /// <summary>
        /// изменнения или добавление
        /// </summary>
        /// <param name="animalGroupType">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAnimalGroupTypeSave(spr_animal_group_type animalGroupType)
        {
            if (ModelState.IsValid)
            {
                if (animalGroupType.id == Guid.Empty)
                {
                    repository.Insert(animalGroupType);
                }
                else
                {
                    repository.Update(animalGroupType);
                }
                return RedirectToAction("PartialTableAnimalGroupTypes");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="animalGroupTypeId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAnimalGroupTypeRecovery(Guid animalGroupTypeId)
        {
            spr_animal_group_type recoveryAnimalGroupType = repository.SprAnimalGroupTypes.SingleOrDefault(sagt => sagt.id == animalGroupTypeId);

            recoveryAnimalGroupType.is_remove = false;
            repository.Update(recoveryAnimalGroupType);
            return RedirectToAction("PartialTableAnimalGroupTypes");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="animalGroupTypeId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAnimalGroupTypeDelete(Guid animalGroupTypeId, string comment)
        {
            spr_animal_group_type deleteAnimalGroupType = repository.SprAnimalGroupTypes.SingleOrDefault(sag => sag.id == animalGroupTypeId);
            deleteAnimalGroupType.is_remove = true;
            deleteAnimalGroupType.date_remove = DateTime.Now;
            deleteAnimalGroupType.employees_fio_modifi = UserName;
            deleteAnimalGroupType.commentt_remove = comment;
            repository.Update(deleteAnimalGroupType);
            return RedirectToAction("PartialTableAnimalGroupTypes");
        }

        public ActionResult PartialTableAnimalGroupTypes(bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            var animalGroupTypes = repository.SprAnimalGroupTypes.Include(i => i.spr_animal_group);
            animalGroupTypes = !isRemove ? animalGroupTypes.Where(o => o.is_remove != true) : animalGroupTypes;
            AnimalViewModel model = new AnimalViewModel
            {
                AnimalGroupTypeList = animalGroupTypes.OrderBy(at => at.identity_).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = animalGroupTypes.Count()
                },
            };
            return PartialView("Animals/AnimalGroupTypes/PartialTableAnimalGroupTypes", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Методы изъятия  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddRemoveMethod()
        {
            return PartialView("Animals/RemoveMethods/PartialModalAddRemoveMethod", new spr_method_remove { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditRemoveMethod(Guid removeMethodId)
        {
            return PartialView("Animals/RemoveMethods/PartialModalEditRemoveMethod", repository.SprMethodRemoves.SingleOrDefault(st => st.id == removeMethodId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="removeMethod">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitRemoveMethodSave(spr_method_remove removeMethod)
        {
            if (ModelState.IsValid)
            {
                if (removeMethod.id == Guid.Empty)
                {
                    repository.Insert(removeMethod);
                }
                else
                {
                    removeMethod.employees_fio_modifi = UserName;
                    repository.Update(removeMethod);
                }
                return RedirectToAction("PartialTableRemoveMethods");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="serviceTypeId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitRemoveMethodRecovery(Guid removeMethodId)
        {
            spr_method_remove recoveryRemoveMethod = repository.SprMethodRemoves.SingleOrDefault(mr => mr.id == removeMethodId);

            recoveryRemoveMethod.is_remove = false;
            repository.Update(recoveryRemoveMethod);
            return RedirectToAction("PartialTableRemoveMethods");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="serviceTypeId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitRemoveMethodDelete(Guid removeMethodId, string comment)
        {
            spr_method_remove deleteRemoveMethod = repository.SprMethodRemoves.SingleOrDefault(so => so.id == removeMethodId);

            deleteRemoveMethod.is_remove = true;
            deleteRemoveMethod.date_remove = DateTime.Now;
            deleteRemoveMethod.employees_fio_modifi = UserName;
            deleteRemoveMethod.commentt_remove = comment;
            repository.Update(deleteRemoveMethod);
            return RedirectToAction("PartialTableRemoveMethods");
        }

        public ActionResult PartialTableRemoveMethods(bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            var removeMethods = repository.SprMethodRemoves;
            removeMethods = !isRemove ? removeMethods.Where(o => o.is_remove != true) : removeMethods;

            AnimalViewModel model = new AnimalViewModel
            {
                MethodRemoveList = removeMethods.OrderBy(a => a.method_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = removeMethods.Count()
                },
            };
            return PartialView("Animals/RemoveMethods/PartialTableRemoveMethods", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Методы учёта  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddAccountMethod()
        {
            return PartialView("Animals/AccoutMethods/PartialModalAddAccountMethod", new spr_animal_method_account { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditAccountMethod(Guid accountMethodId)
        {
            return PartialView("Animals/AccoutMethods/PartialModalEditAccountMethod", repository.SprAnimalMethodAccounts.SingleOrDefault(st => st.id == accountMethodId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="accountMethod">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAccountMethodSave(spr_animal_method_account accountMethod)
        {
            if (ModelState.IsValid)
            {
                if (accountMethod.id == Guid.Empty)
                {
                    repository.Insert(accountMethod);
                }
                else
                {
                    accountMethod.employees_fio_modifi = UserName;
                    repository.Update(accountMethod);
                }
                return RedirectToAction("PartialTableAccountMethods");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="accountMethodId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAccountMethodRecovery(Guid accountMethodId)
        {
            spr_animal_method_account recoveryAccountMethod = repository.SprAnimalMethodAccounts.SingleOrDefault(mr => mr.id == accountMethodId);

            recoveryAccountMethod.is_remove = false;
            repository.Update(recoveryAccountMethod);
            return RedirectToAction("PartialTableAccountMethods");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="accountMethodId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitAccountMethodDelete(Guid accountMethodId, string comment)
        {
            spr_animal_method_account deleteAccountMethod = repository.SprAnimalMethodAccounts.SingleOrDefault(so => so.id == accountMethodId);

            deleteAccountMethod.is_remove = true;
            deleteAccountMethod.date_remove = DateTime.Now;
            deleteAccountMethod.employees_fio_modifi = UserName;
            deleteAccountMethod.commentt_remove = comment;
            repository.Update(deleteAccountMethod);
            return RedirectToAction("PartialTableAccountMethods");
        }

        public ActionResult PartialTableAccountMethods(bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            var accountMethods = repository.SprAnimalMethodAccounts;
            accountMethods = !isRemove ? accountMethods.Where(o => o.is_remove != true) : accountMethods;

            AnimalViewModel model = new AnimalViewModel
            {
                AnimalAccountMethodList = accountMethods.OrderBy(a => a.method_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = accountMethods.Count()
                },
            };
            return PartialView("Animals/AccoutMethods/PartialTableAccountMethods", model);
        }

        #endregion

    }
}