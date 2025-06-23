using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Concrete;
using HuntControl.WebUI.Models;

namespace HuntControl.WebUI.Controllers
{
    public partial class ReferenceController
    {
        public ActionResult Employees()
        {
            return View("Employees/Main");
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ Сотрудники  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление Сотрудника
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddEmployee()
        {
            var huntingFarms = repository.SprHuntingFarms.Where(hf => hf.is_remove != true).OrderBy(o => o.hunting_farm_name);
            ViewBag.EmployeeJobPos = new SelectList(repository.SprEmployeesJobPos.OrderBy(s => s.job_pos_name), "id", "job_pos_name");
            ViewBag.EmployeeDepartments = new SelectList(repository.SprEmployeesDepartments.OrderBy(s => s.department_name), "id", "department_name");
            ViewBag.HuntingFarms = new SelectList(huntingFarms.OrderBy(s => s.hunting_farm_name), "id", "hunting_farm_name");
            return PartialView("Employees/Employees/PartialModalAddEmployee", new spr_employees { employees_fio_add = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение данных Сотрудника
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditEmployee(Guid employeeId)
        {
            var huntingFarms = repository.SprHuntingFarms.Where(hf => hf.is_remove != true).OrderBy(o => o.hunting_farm_name);
            ViewBag.EmployeeJobPos = new SelectList(repository.SprEmployeesJobPos.OrderBy(s => s.job_pos_name), "id", "job_pos_name");
            ViewBag.EmployeeDepartments = new SelectList(repository.SprEmployeesDepartments.OrderBy(s => s.department_name), "id", "department_name");
            ViewBag.HuntingFarms = new SelectList(huntingFarms.OrderBy(s => s.hunting_farm_name), "id", "hunting_farm_name");
            return PartialView("Employees/Employees/PartialModalEditEmployee", repository.SprEmployees.SingleOrDefault(se => se.id == employeeId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет сотрудника
        /// </summary>
        /// <param name="employee">объект Сотрудника</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitEmployeeSave(spr_employees employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.id == Guid.Empty)
                {
                    employee.employees_pass = Crypto.HashPassword(employee.employees_pass);
                    repository.Insert(employee);
                }
                else
                {
                    employee.employees_fio_modifi = UserName;
                    repository.Update(employee);
                }
                return RedirectToAction("PartialTableEmployees");
            }
            throw new Exception("Ошибка валидации!");
        }

        [HttpPost]
        public JsonResult CheckLogin(string employees_login, Guid? id)
        {
            var result = !repository.SprEmployees.Any(e => e.employees_login == employees_login && e.id != id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="employeeId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitEmployeeRecovery(Guid employeeId)
        {
            spr_employees recoveryEmployee = repository.SprEmployees.SingleOrDefault(se => se.id == employeeId);

            recoveryEmployee.is_remove = false;
            repository.Update(recoveryEmployee);
            return RedirectToAction("PartialTableEmployees");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="employeeId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitEmployeeDelete(Guid employeeId, string comment)
        {
            spr_employees deleteEmployee = repository.SprEmployees.SingleOrDefault(se => se.id == employeeId);
            deleteEmployee.is_remove = true;
            deleteEmployee.date_remove = DateTime.Now;
            deleteEmployee.employees_fio_modifi = UserName;
            deleteEmployee.commentt_remove = comment;
            repository.Update(deleteEmployee);
            return RedirectToAction("PartialTableEmployees");
        }

        public ActionResult PartialTableEmployees(string search, bool isRemove = false, int page = 1)
        {

            ViewBag.IsRemove = isRemove;
            ViewBag.Search = search;
            var employees = repository.SprEmployees.Include(se => se.spr_employees_job_pos).Include(se => se.spr_employees_role_join).Include(se => se.spr_employees_hunting_farm);
            employees = !isRemove ? employees.Where(o => o.is_remove != true) : employees;
            employees = String.IsNullOrEmpty(search) ? employees :
                search.ToLower().Split().Aggregate(employees, (current, item) => current.Where(h => h.employees_fio.ToLower().Contains(item)));

            EmployeeViewModel model = new EmployeeViewModel
            {
                SprEmployees = employees.OrderBy(e => e.employees_fio).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = employees.Count()
                },
            };
            return PartialView("Employees/Employees/PartialTableEmployees", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ Роли сотрудника  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult PartialModalEmployeeRole(Guid employeeId)
        {
            ViewBag.EmployeeId = employeeId;
            var employees = repository.SprEmployees.Include(i => i.spr_employees_job_pos).Where(w => w.id == employeeId && w.spr_employees_job_pos.is_remove != true).SingleOrDefault();
            ViewBag.StepValues = employees.employees_fio + " - " + employees.spr_employees_job_pos.job_pos_name;
            return PartialView("Employees/EmployeeRoles/PartialModalEmployeeRole", employeeId);
        }
        /// <summary>
        /// Добавление роль Сотрудника
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddEmployeeRole(Guid employeeId)
        {
            ViewBag.EmployeeRoles = new SelectList(repository.SprEmployeesRoles.OrderBy(s => s.comment), "id", "comment");
            return PartialView("Employees/EmployeeRoles/PartialModalAddEmployeeRole", new spr_employees_role_join { spr_employees_id = employeeId });
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет роль сотрудника
        /// </summary>
        /// <param name="employeeRole">объект роль Сотрудника</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitEmployeeRoleSave(spr_employees_role_join employeeRole)
        {
            if (ModelState.IsValid)
            {
                if (employeeRole.id == Guid.Empty)
                {
                    repository.Insert(employeeRole);
                }
                else
                {
                    repository.Update(employeeRole);
                }
                return RedirectToAction("PartialTableEmployeeRoles", new { employeeId = employeeRole.spr_employees_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="employeeRoleId">id роли Сотрудника</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitEmployeeRoleDelete(Guid employeeRoleId)
        {
            var employeeRole = repository.SprEmployeesRoleJoins.SingleOrDefault(ser => ser.id == employeeRoleId);
            repository.Delete(employeeRole);
            return RedirectToAction("PartialTableEmployeeRoles", new { employeeId = employeeRole.spr_employees_id });
        }

        public ActionResult PartialTableEmployeeRoles(Guid employeeId)
        {
            ViewBag.EmployeeId = employeeId;
            var employees = repository.SprEmployees.Include(i => i.spr_employees_job_pos).Where(w => w.id == employeeId && w.spr_employees_job_pos.is_remove != true).SingleOrDefault();
            ViewBag.StepValues = employees.employees_fio + " - " + employees.spr_employees_job_pos.job_pos_name;
            var employeeRoleJoins = repository.SprEmployeesRoleJoins.Where(ser => ser.spr_employees_id == employeeId).Include(se => se.spr_employees_role).Include(i => i.spr_employees);
            EmployeeViewModel model = new EmployeeViewModel
            {
                SprEmployeeRoleJoins = employeeRoleJoins.OrderBy(e => e.spr_employees_role.role_name),
                PageInfo = new PageInfo(),
            };
            return PartialView("Employees/EmployeeRoles/PartialTableEmployeeRoles", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ Охотоугодья сотрудника  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult PartialModalEmployeeHuntingFarm(Guid employeeId)
        {
            ViewBag.EmployeeId = employeeId;
            var employees = repository.SprEmployees.Include(i => i.spr_employees_job_pos).Where(w => w.id == employeeId && w.spr_employees_job_pos.is_remove != true).SingleOrDefault();
            ViewBag.StepValues = employees.employees_fio + " - " + employees.spr_employees_job_pos.job_pos_name;
            return PartialView("Employees/EmployeeHuntingFarm/PartialModalEmployeeHuntingFarm", employeeId);
        }
        /// <summary>
        /// Добавление роль Сотрудника
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddEmployeeHuntingFarm(Guid employeeId)
        {
            ViewBag.HuntingFarms = new SelectList(repository.SprHuntingFarms.OrderBy(s => s.hunting_farm_name), "id", "hunting_farm_name");
            return PartialView("Employees/EmployeeHuntingFarm/PartialModalAddEmployeeHuntingFarm", new spr_employees_hunting_farm { spr_employees_id = employeeId, employees_fio_add = UserName });
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет роль сотрудника
        /// </summary>
        /// <param name="employeeHuntingFarm">объект роль Сотрудника</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitEmployeeHuntingFarmSave(spr_employees_hunting_farm employeeHuntingFarm)
        {
            if (ModelState.IsValid)
            {
                if (employeeHuntingFarm.id == Guid.Empty)
                {
                    repository.Insert(employeeHuntingFarm);
                }
                else
                {
                    repository.Update(employeeHuntingFarm);
                }
                return RedirectToAction("PartialTableEmployeeHuntingFarms", new { employeeId = employeeHuntingFarm.spr_employees_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="employeeRoleId">id роли Сотрудника</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitEmployeeHuntingFarmDelete(Guid employeeHuntingFarmId)
        {
            var employeeHuntingFarm = repository.SprEmployeesHuntingFarms.SingleOrDefault(ser => ser.id == employeeHuntingFarmId);
            repository.Delete(employeeHuntingFarm);
            return RedirectToAction("PartialTableEmployeeHuntingFarms", new { employeeId = employeeHuntingFarm.spr_employees_id });
        }

        public ActionResult PartialTableEmployeeHuntingFarms(Guid employeeId)
        {
            ViewBag.EmployeeId = employeeId;
            var employees = repository.SprEmployees.Include(i => i.spr_employees_job_pos).Where(w => w.id == employeeId && w.spr_employees_job_pos.is_remove != true).SingleOrDefault();
            ViewBag.StepValues = employees.employees_fio + " - " + employees.spr_employees_job_pos.job_pos_name;
            var employeeHuntingFarms = repository.SprEmployeesHuntingFarms.Where(ser => ser.spr_employees_id == employeeId).Include(se => se.spr_hunting_farm).Include(i => i.spr_employees);
            EmployeeViewModel model = new EmployeeViewModel
            {
                SprEmployeesHuntingFarmList = employeeHuntingFarms.OrderBy(e => e.spr_hunting_farm.hunting_farm_name),
                PageInfo = new PageInfo(),
            };
            return PartialView("Employees/EmployeeHuntingFarm/PartialTableEmployeeHuntingFarms", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ Отделы  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddDepartment()
        {
            return PartialView("Employees/Departments/PartialModalAddDepartment", new spr_employees_department { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditDepartment(Guid departmentId)
        {
            return PartialView("Employees/Departments/PartialModalEditDepartment", repository.SprEmployeesDepartments.SingleOrDefault(ed => ed.id == departmentId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="department">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitDepartmentSave(spr_employees_department department)
        {
            if (ModelState.IsValid)
            {
                if (department.id == Guid.Empty)
                {
                    repository.Insert(department);
                }
                else
                {
                    department.employees_fio_modifi = UserName;
                    repository.Update(department);
                }
                return RedirectToAction("PartialTableDepartments");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="departmentId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitDepartmentRecovery(Guid departmentId)
        {
            spr_employees_department recoveryDepartment = repository.SprEmployeesDepartments.SingleOrDefault(so => so.id == departmentId);

            recoveryDepartment.is_remove = false;
            repository.Update(recoveryDepartment);
            return RedirectToAction("PartialTableDepartments");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="departmentId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitDepartmentDelete(Guid departmentId, string comment)
        {
            spr_employees_department deleteDepartment = repository.SprEmployeesDepartments.SingleOrDefault(sed => sed.id == departmentId);

            deleteDepartment.is_remove = true;
            deleteDepartment.date_remove = DateTime.Now;
            deleteDepartment.employees_fio_modifi = UserName;
            deleteDepartment.commentt_remove = comment;
            repository.Update(deleteDepartment);
            return RedirectToAction("PartialTableDepartments");
        }

        public ActionResult PartialTableDepartments(bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            var departments = repository.SprEmployeesDepartments;
            departments = !isRemove ? departments.Where(o => o.is_remove != true) : departments;

            EmployeeViewModel model = new EmployeeViewModel
            {
                SprEmployeesDepartmentList = departments.OrderBy(a => a.department_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = departments.Count()
                },
            };
            return PartialView("Employees/Departments/PartialTableDepartments", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ Должности  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddEmployeeJobPos()
        {
            return PartialView("Employees/EmployeeJobPos/PartialModalAddEmployeeJobPos", new spr_employees_job_pos { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditEmployeeJobPos(int employeeJobPosId)
        {
            return PartialView("Employees/EmployeeJobPos/PartialModalEditEmployeeJobPos", repository.SprEmployeesJobPos.SingleOrDefault(ed => ed.id == employeeJobPosId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет
        /// </summary>
        /// <param name="employeeJobPos">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitEmployeeJobPosSave(spr_employees_job_pos employeeJobPos)
        {
            if (ModelState.IsValid)
            {
                if (employeeJobPos.id == 0)
                {
                    repository.Insert(employeeJobPos);
                }
                else
                {
                    employeeJobPos.employees_fio_modifi = UserName;
                    repository.Update(employeeJobPos);
                }
                return RedirectToAction("PartialTableEmployeeJobPos");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="employeeJobPosId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitEmployeeJobPosRecovery(int employeeJobPosId)
        {
            spr_employees_job_pos recoveryEmployeeJobPos = repository.SprEmployeesJobPos.SingleOrDefault(sejp => sejp.id == employeeJobPosId);

            recoveryEmployeeJobPos.is_remove = false;
            repository.Update(recoveryEmployeeJobPos);
            return RedirectToAction("PartialTableEmployeeJobPos");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="employeeJobPosId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitEmployeeJobPosDelete(int employeeJobPosId, string comment)
        {
            spr_employees_job_pos deleteEmployeeJobPos = repository.SprEmployeesJobPos.SingleOrDefault(sejp => sejp.id == employeeJobPosId);

            deleteEmployeeJobPos.is_remove = true;
            deleteEmployeeJobPos.date_remove = DateTime.Now;
            deleteEmployeeJobPos.employees_fio_modifi = UserName;
            deleteEmployeeJobPos.commentt_remove = comment;
            repository.Update(deleteEmployeeJobPos);
            return RedirectToAction("PartialTableEmployeeJobPos");
        }

        public ActionResult PartialTableEmployeeJobPos(bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            var employeeJobPos = repository.SprEmployeesJobPos;
            employeeJobPos = !isRemove ? employeeJobPos.Where(o => o.is_remove != true) : employeeJobPos;

            EmployeeViewModel model = new EmployeeViewModel
            {
                SprEmployeesJobPosList = employeeJobPos.OrderBy(a => a.job_pos_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = employeeJobPos.Count()
                },
            };
            return PartialView("Employees/EmployeeJobPos/PartialTableEmployeeJobPos", model);
        }

        #endregion
    }
}