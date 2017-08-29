using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Torrent.ViewModels
{

    /// <summary>
    /// The Search View Model
    /// </summary>
    public class SearchViewModel
    {

        /// <summary>
        /// Gets or sets the torrents.
        /// </summary>
        /// <value>
        /// The torrents dto.
        /// </value>
       public TorrentDto[] Torrents { get; set; }
    }
}