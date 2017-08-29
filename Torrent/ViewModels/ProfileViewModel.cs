using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Dto;

namespace Torrent.ViewModels
{

    /// <summary>
    /// The User Profile View Model
    /// </summary>
    public class ProfileViewModel
    {

        /// <summary>
        /// Gets or sets the user profile.
        /// </summary>
        /// <value>
        /// The user profile dto.
        /// </value>
        public UserDto UserProfile { get; set; }
    }
}