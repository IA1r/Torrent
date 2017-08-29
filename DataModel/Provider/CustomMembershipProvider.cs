using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Core.EntityModel;
using Core.Dto;
using System.IO;
using System.Web;
using System.Data.Entity;

namespace DataModel.Provider
{

    /// <summary>
    /// The Custom Membership Provider
    /// </summary>
    public class CustomMembershipProvider : MembershipProvider
    {

        /// <summary>
        /// The entity context
        /// </summary>
        private Torrent_dbEntities context;  
        public CustomMembershipProvider()
        {
            context = new Torrent_dbEntities();
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user entity.</param>
        public void CreateUser(User user)
        {
            user.DownloadsCount = 0;
            user.RegistrationDate = DateTime.Today;
            user.RoleID = this.context.Roles.Where(r => r.Name == "User").Select(r => r.RoleID).Single();
            user.Image = "/Content/Images/unknown.jpg";

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="login">The user login.</param>
        /// <param name="password">The user password.</param>
        public override bool ValidateUser(string login, string password)
        {
            if (this.context.Users.Any(u => u.Login == login && u.Password == password))
                return true;
            return false;
        }

        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <param name="userLogin">The user login.</param>
        public UserDto GetUserProfile(string userLogin)
        {
            if (!this.context.Users.Any(u => u.Login == userLogin))
                return null;

            return this.context.Users
                .Where(u => u.Login == userLogin)
                .Select(u => new UserDto
                {
                    ID = u.UserID,
                    Name = u.Name,
                    Login = u.Login,
                    Password = u.Password,
                    DownloadsCount = u.DownloadsCount.ToString(),
                    Email = u.Email,
                    RegistrationDate = u.RegistrationDate,
                    Image = u.Image,
                    Role = u.Role.Name
                })
                .Single();
        }

        /// <summary>
        /// Updates the user profile.
        /// </summary>
        /// <param name="newProfile">The new user profile.</param>
        public void UpdateUserProfile(UserDto newProfile)
        {
            User oldProfile = this.context.Users.Find(newProfile.ID);

            string imageName = null;
            string imagePath = null;

            if (oldProfile.Image != newProfile.Image)
            {
                imageName = Path.GetFileName(newProfile.Image);
                imagePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images"), imageName);
                File.Copy(newProfile.Image, imagePath);

                oldProfile.Image = "/Content/Images/" + imageName;
            }

            oldProfile.Password = newProfile.Password;
            oldProfile.Email = newProfile.Email;

            this.context.Entry(oldProfile).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        /// <summary>
        /// Gets the user login.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        public string GetUserLogin(int id)
        {
            if (!this.context.Users.Any(u => u.UserID == id))
                return null;

            return this.context.Users
                .Where(u => u.UserID == id)
                .Select(u => u.Login)
                .SingleOrDefault();
        }


//---------------------------------------------------------------------------------------------------------------------------------------//


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

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
    }
}
