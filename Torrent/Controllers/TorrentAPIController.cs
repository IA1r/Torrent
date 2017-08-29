using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Torrent.RequestModel;
using Core.Dto;
using BusinessModel.Managers;

namespace Torrent.Controllers
{

    /// <summary>
    /// The Torrent API contrroller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class TorrentAPIController : ApiController
    {

        /// <summary>
        /// The torrent manager
        /// </summary>
        private TorrentManager torrentManager;

        /// <summary>
        /// The comment dto
        /// </summary>
        private CommentDto commentDto;

        public TorrentAPIController()
        {
            torrentManager = new TorrentManager();
        }

        /// <summary>
        /// Edits the comment.
        /// </summary>
        /// <param name="requestComment">The request comment(new comment).</param>
        public void EditComment(EditCommentRequestModel requestComment)
        {
            commentDto = new CommentDto
            {
                ID = requestComment.CommentID,
                Comment = requestComment.CommentText
            };

            torrentManager.EditComment(commentDto);
        }
    }
}
