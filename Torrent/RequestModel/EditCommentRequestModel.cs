using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Torrent.RequestModel
{

    /// <summary>
    /// The Edit Comment Request Model
    /// </summary>
    public class EditCommentRequestModel
    {

        /// <summary>
        /// Gets or sets the comment identifier.
        /// </summary>
        /// <value>
        /// The comment identifier.
        /// </value>
        public int CommentID { get; set; }

        /// <summary>
        /// Gets or sets the comment text.
        /// </summary>
        /// <value>
        /// The comment text.
        /// </value>
        public string CommentText { get; set; }
    }
}