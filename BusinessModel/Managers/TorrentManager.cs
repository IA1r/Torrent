using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Repository;
using Core.Dto;
using System.Web.Mvc;
using System.Web;

namespace BusinessModel.Managers
{
    public class TorrentManager
    {

        /// <summary>
        /// The Torrent repository
        /// </summary>
        private TorrentRepository repository;
        public TorrentManager()
        {
            repository = new TorrentRepository();
        }

        /// <summary>
        /// Gets the torrents.
        /// </summary>
        public TorrentDto[] GetTorrents()
        {
          return  repository.GetTorrents();
        }

        /// <summary>
        /// Gets the torrents.
        /// </summary>
        /// <param name="type">The torrent type.</param>
        public TorrentDto[] GetTorrents(string type)
        {
            TorrentDto[] torrents = repository.GetTorrents(type);
            if (torrents != null)
                return torrents;
            throw new ArgumentException("This torrent type doesn't exist");
        }

        /// <summary>
        /// Gets the torrent.
        /// </summary>
        /// <param name="id">The torrent identifier.</param>
        public TorrentDto GetTorrent(int id)
        {
            TorrentDto torrent = repository.GetTorrent(id);
            if (torrent != null)
                return torrent;

            throw new ArgumentException("This topic doesn't exist");
        }

        /// <summary>
        /// Searches the torrents.
        /// </summary>
        /// <param name="keyword">The torrent name.</param>
        public TorrentDto[] SearchTorrents(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return null;

            TorrentDto[] torrents = repository.SearchTorrents(keyword);
            return torrents;
        }

        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name="id">The torrent identifier.</param>
        /// <param name="comment">The comment.</param>
        public void AddComment(int id, string comment)
        {
            repository.AddComment(id, comment);
        }

        /// <summary>
        /// Adds the torrent.
        /// </summary>
        /// <param name="torrentDto">The torrent dto.</param>
        /// <param name="image">The image of torrent.</param>
        /// <param name="file">The torrent file.</param>
        public void AddTorrent(TorrentDto torrentDto, HttpPostedFileBase image, HttpPostedFileBase file)
        {
            repository.AddTorrent(torrentDto, image, file);
        }

        /// <summary>
        /// Gets the comments.
        /// </summary>
        /// <param name="id">The torrent identifier.</param>
        public CommentDto[] GetComments(int id)
        {
            return this.repository.GetComments(id);
        }

        /// <summary>
        /// Edits the comment.
        /// </summary>
        /// <param name="newComment">The new comment dto.</param>
        public void EditComment(CommentDto newComment)
        {
            repository.EditComment(newComment);
        }

        /// <summary>
        /// Increments the downloads count.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        public void IncDownloadsCount(string filepath)
        {
            repository.IncDownloadsCount(filepath);
        }

        /// <summary>
        /// Gets the list types.
        /// </summary>
        public List<SelectListItem> GetListTypes()
        {
           return repository.GetListTypes();
        }

        /// <summary>
        /// Gets the popular torrents.
        /// </summary>
        public TorrentDto[] GetPopularTorrents()
        {
            return repository.GetPopularTorrents();
        }
    }
}
