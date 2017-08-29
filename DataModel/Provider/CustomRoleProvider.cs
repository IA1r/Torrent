using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Core.EntityModel;

namespace DataModel.Provider
{

    /// <summary>
    /// The Custom Role Provider
    /// </summary>
    public class CustomRoleProvider : RoleProvider
    {

        /// <summary>
        /// The entity context
        /// </summary>
        private Torrent_dbEntities context;
        public CustomRoleProvider()
        {
            context = new Torrent_dbEntities();
        }

        /// <summary>
        /// Gets the roles for user.
        /// </summary>
        /// <param name="userLogin">The user login.</param>
        public override string[] GetRolesForUser(string userLogin)
        {
            string[] role = new string[] { };
            role = new string[] 
            { 
                this.context.Users
                .Where(u => u.Login == userLogin)
                .Select(u => u.Role.Name)
                .SingleOrDefault() 
            };

            return role;
        }


        //--------------------------------------------------------------------------------------------------------------------//


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
            throw new NotImplementedException();
        }


        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
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
    }
}
