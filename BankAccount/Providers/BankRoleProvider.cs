using BankAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BankAccount.Providers
{
    public class BankRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
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
            string[] roles = new string[] { };
            using (BankaccountContext _db = new BankaccountContext())
            {
                try
                {
                    ICollection<Role> role =_db.Roles.ToList();
                    foreach (var item in role)
                    {
                        roles = new string[] { item.Name };
                    }
                }
                catch
                {

                   roles =new string[]{ };
                }
            }
            return roles;
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] userRole = new string[] { };
            using (BankaccountContext _db = new BankaccountContext())
            {
                try
                {
                    var user = _db.Users.Where(u => u.Login == username).FirstOrDefault();
                    if (user != null)
                    {
                        var role = _db.Roles.Find(user.Id);
                        if (role != null)
                        {
                            userRole = new string[] { role.Name };
                        }

                    }
                }
                catch 
                {

                    userRole = new string[] { };
                }
            }
            return userRole;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (BankaccountContext _db = new BankaccountContext())
            {
                try
                {
                    var userName = _db.Users.Where(u => u.Login == username).FirstOrDefault();
                    if(userName == null)
                    {
                        return false;
                    }
                    else
                    {
                        Role userRole = _db.Roles.Where(u=>u.Name == roleName).FirstOrDefault();
                        if(userRole.Name == roleName && userName.Login == username)
                        {
                            return true;
                        }
                    }
                }
                catch
                {

                    return false;
                }
            }
            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}