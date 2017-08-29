using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Torrent.RequestModel
{

    /// <summary>
    /// The Update User Request Model
    /// </summary>
    public class UpdateUserRequestModel
    {

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The user password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The user email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The user image/avatar.
        /// </value>
        public string Image { get; set; }
    }
}