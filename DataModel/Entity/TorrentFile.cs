//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel.Entity
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The TorrentFile entity model
    /// </summary>
    public partial class TorrentFile
    {
        public TorrentFile()
        {
            this.Torrents = new HashSet<Torrent>();
        }

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
        public Nullable<int> DownloadsCount { get; set; }

        /// <summary>
        /// Gets or sets the added date.
        /// </summary>
        /// <value>
        /// The added date of torrent.
        /// </value>
        public System.DateTime AddedDate { get; set; }
    
        public virtual ICollection<Torrent> Torrents { get; set; }
    }
}
