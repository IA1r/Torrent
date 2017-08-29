using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Torrent.RequestModel;
using Core.Dto;
using BusinessModel.Managers;

namespace Torrent.Controllers
{

    /// <summary>
    /// The account API controller
    /// </summary>
    public class AccountAPIController : ApiController
    {

        /// <summary>
        /// The user manger
        /// </summary>
        private UserManager userManger;

        /// <summary>
        /// The user dto
        /// </summary>
        private UserDto user;

        public AccountAPIController()
        {
            userManger = new UserManager();
        }


        /// <summary>
        /// Updates the user profile.
        /// </summary>
        /// <param name="updatedUserProfile">The updated user profile(new profile).</param>
        public void UpdateProfile([FromBody]UpdateUserRequestModel updatedUserProfile)
        {
            user = new UserDto
            {
                ID = updatedUserProfile.UserID,
                Password = updatedUserProfile.Password,
                Email = updatedUserProfile.Email,
                Image = updatedUserProfile.Image,
            };
            userManger.UpdateUserProfile(user);
        }
    }
}
