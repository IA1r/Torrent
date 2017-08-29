using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Dto;

namespace Torrent.ViewModels
{

    /// <summary>
    /// The Send Message View Model
    /// </summary>
    public class SendMessageViewModel
    {

        /// <summary>
        /// Gets or sets to user.
        /// </summary>
        /// <value>
        /// To user dto.
        /// </value>
        public UserDto ToUser { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the private message.
        /// </summary>
        /// <value>
        /// The private message dto.
        /// </value>
        public PrivateMessageDto PrivateMessage { get; set; }
    }
}