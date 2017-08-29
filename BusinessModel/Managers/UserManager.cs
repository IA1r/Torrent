using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Provider;
using Core.EntityModel;
using Core.Dto;

namespace BusinessModel.Managers
{
    public class UserManager
    {

        /// <summary>
        /// The Custom Membership provider
        /// </summary>
        private CustomMembershipProvider provider;

        public UserManager()
        {
            provider = new CustomMembershipProvider();
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user entity.</param>
        public void CreateUser(User user)
        {
            provider.CreateUser(user);
        }

        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="login">The user login.</param>
        /// <param name="password">The user password.</param>
        public bool ValidateUser(string login, string password)
        {
            return provider.ValidateUser(login, password);
        }

        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <param name="login">Theuser login.</param>
        public UserDto GetUserProfile(string login)
        {
            UserDto userProfile = provider.GetUserProfile(login);
            if (userProfile != null)
                return userProfile;
            throw new ArgumentException("This user doesn't exist");
        }

        /// <summary>
        /// Updates the user profile.
        /// </summary>
        /// <param name="newProfile">The new user profile.</param>
        public void UpdateUserProfile(UserDto newProfile)
        {
            provider.UpdateUserProfile(newProfile);
        }

        /// <summary>
        /// Gets the user login.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        public string GetUserLogin(int id)
        {
            string login = provider.GetUserLogin(id);
            if (login != null)
                return login;

            throw new ArgumentException("This user doesn't exist");
        }

    }
}
