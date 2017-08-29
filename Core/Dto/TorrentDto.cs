using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{

    /// <summary>
    /// Torrent data transfer object
    /// </summary>
    public class TorrentDto
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The torrent identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the type of the torrent.
        /// </summary>
        /// <value>
        /// The type of the torrent.
        /// </value>
        public string TorrentType { get; set; }

        /// <summary>
        /// Gets or sets the characteristics.
        /// </summary>
        /// <value>
        /// The torrent characteristics.
        /// </value>
        public Dictionary<string, string> Characteristics { get; set; }

        /// <summary>
        /// Gets or sets the torrent file.
        /// </summary>
        /// <value>
        /// The torrent file dto.
        /// </value>
        public TorrentFileDto TorrentFile { get; set; }
    }
}
