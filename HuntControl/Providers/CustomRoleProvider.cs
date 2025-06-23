using System;
using System.Linq;
using System.Web.Security;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string name)
        {
            string[] role = new string[] { };
            using (EFDbContext _db = new EFDbContext())
            {
                try
                {
                    // Получаем пользователя
                    spr_employees employee = (from u in _db.spr_employees
                                      where u.employees_login == name
                                      select u).FirstOrDefault();
                    if (employee != null)
                    {
                        // получаем роль
                        string[] userRole = _db.spr_employees_role_join.Where(UR => UR.spr_employees_id == employee.id).Join(_db.spr_employees_role, S => S.spr_employees_role_id, SS => SS.id, (S, SS) => SS).Select(s => s.role_name).ToArray();

                        if (userRole != null)
                        {
                            role = userRole;
                        }
                    }
                }
                catch
                {
                    role = new string[] { };
                }
            }
            return role;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            // Находим пользователя
            using (EFDbContext _db = new EFDbContext())
            {
                try
                {
                    // Получаем пользователя
                    spr_employees employee = (from u in _db.spr_employees
                                              where u.employees_login == username
                                      select u).FirstOrDefault();
                    if (employee != null)
                    {
                        // получаем роль
                        string[] userRole = _db.spr_employees_role_join.Where(UR => UR.spr_employees_id == employee.id).Join(_db.spr_employees_role, S => S.spr_employees_role_id, SS => SS.id, (S, SS) => SS).Select(s => s.role_name).ToArray();

                        foreach (string role in userRole)
                            //сравниваем
                            if (userRole != null && role == roleName)
                            {
                                return outputResult = true;
                            }
                    }
                }
                catch
                {
                    outputResult = false;
                }
            }
            return outputResult;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}