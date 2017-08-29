using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Dto;
using System.Web.Mvc;

namespace Torrent.ViewModels
{

    /// <summary>
    /// The Add Torrent View Model
    /// </summary>
    public class AddTorrentViewModel
    {

        /// <summary>
        /// Gets or sets the torrent.
        /// </summary>
        /// <value>
        /// The torrent dto.
        /// </value>
        public TorrentDto Torrent { get; set; }

        /// <summary>
        /// Gets or sets the type of the torrent.
        /// </summary>
        /// <value>
        /// The type of the torrent.
        /// </value>
        public string TorrentType { get; set; }

        /// <summary>
        /// Gets or sets the list types.
        /// </summary>
        /// <value>
        /// The list types of torrent.
        /// </value>
        public List<SelectListItem> ListTypes { get; set; }
    }
}