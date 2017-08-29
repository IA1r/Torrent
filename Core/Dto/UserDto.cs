using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{

    /// <summary>
    /// The User data transfer object
    /// </summary>
    public class UserDto
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The user image/avatar.
        /// </value>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The user name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        /// <value>
        /// The user login.
        /// </value>
        public string Login { get; set; }

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
        /// Gets or sets the downloads count.
        /// </summary>
        /// <value>
        /// The downloads count of user.
        /// </value>
        public string DownloadsCount { get; set; }

        /// <summary>
        /// Gets or sets the registration date.
        /// </summary>
        /// <value>
        /// The user registration date.
        /// </value>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The user role.
        /// </value>
        public string Role { get; set; }
    }
}
