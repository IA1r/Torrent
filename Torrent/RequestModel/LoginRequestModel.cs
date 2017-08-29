using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Torrent.RequestModel
{

    /// <summary>
    /// The Login Request Model
    /// </summary>
    public class LoginRequestModel
    {

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        /// <value>
        /// The user login.
        /// </value>
        [Required(ErrorMessage = "Enter Login!", AllowEmptyStrings = false)]
        [RegularExpression(@"([A-Z0-9]){1}([A-Za-z0-9]){2,}", ErrorMessage = "Invalid Login, or short Login.")]
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The user password.
        /// </value>
        [Required(ErrorMessage = "Enter password!", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [remember me].
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        public bool RememberMe { get; set; }
    }
}