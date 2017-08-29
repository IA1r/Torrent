using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{

    /// <summary>
    /// The TorrentFile data transfer object
    /// </summary>
    public class TorrentFileDto
    {

        /// <summary>
        /// Gets or sets the torrent file identifier.
        /// </summary>
        /// <value>
        /// The torrent file identifier.
        /// </value>
        public int TorrentFileID { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The torrent path.
        /// </value>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The torrent size.
        /// </value>
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the downloads count.
        /// </summary>
        /// <value>
        /// The downloads count of torrent.
        /// </value>
        public int? DownloadsCount { get; set; }

        /// <summary>
        /// Gets or sets the added date.
        /// </summary>
        /// <value>
        /// The added date of torrent.
        /// </value>
        public DateTime AddedDate { get; set; }

    }
}
