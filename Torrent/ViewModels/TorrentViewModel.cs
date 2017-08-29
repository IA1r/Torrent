using Core.Dto;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Torrent.ViewModels
{

    /// <summary>
    /// The Torrent View Model
    /// </summary>
    public class TorrentViewModel
    {

        /// <summary>
        /// Gets or sets the torrents.
        /// </summary>
        /// <value>
        /// The torrents dto.
        /// </value>
        public IPagedList<TorrentDto> Torrents { get; set; }

        /// <summary>
        /// Gets or sets the popular torrents.
        /// </summary>
        /// <value>
        /// The popular torrents dto.
        /// </value>
        public TorrentDto[] PopularTorrents { get; set; }

        /// <summary>
        /// Gets or sets the torrent.
        /// </summary>
        /// <value>
        /// The torrent dto.
        /// </value>
        public TorrentDto Torrent { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments dto.
        /// </value>
        public IPagedList<CommentDto> Comments { get; set; }

    }
}