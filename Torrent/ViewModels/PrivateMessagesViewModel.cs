using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Dto;
using PagedList;

namespace Torrent.ViewModels
{

    /// <summary>
    /// The Private Messages View Model
    /// </summary>
    public class PrivateMessagesViewModel
    {

        /// <summary>
        /// Gets or sets the titles.
        /// </summary>
        /// <value>
        /// The titles dto.
        /// </value>
        public MessageTitleDto[] Titles { get; set; }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>
        /// The private messages.
        /// </value>
        public IPagedList<PrivateMessageDto> Messages { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title dto.
        /// </value>
        public MessageTitleDto Title { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The message type.
        /// </value>
        public string Type { get; set; }
    }
}