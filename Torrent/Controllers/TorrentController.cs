using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessModel.Managers;
using Torrent.ViewModels;
using System.IO;
using PagedList;
using System.Web.UI;

namespace Torrent.Controllers
{

    /// <summary>
    /// The Torrent Controller
    /// </summary>
    public class TorrentController : Controller
    {

        /// <summary>
        /// The torrent manager
        /// </summary>
        private TorrentManager torrentManager;

        /// <summary>
        /// The torrent view mdel
        /// </summary>
        private TorrentViewModel torrentViewMdel;

        /// <summary>
        /// The search view model
        /// </summary>
        private SearchViewModel searchViewModel;

        public TorrentController()
        {
            torrentManager = new TorrentManager();
        }

        /// <summary>
        /// View of torrents.
        /// </summary>
        /// <param name="type">The torrent type.</param>
        /// <param name="page">The page number.</param>
        [HttpGet]
        public ActionResult Torrents(string type, int page = 1)
        {
            int pageSize = 10;
            if (type != null)
            {
                try
                {
                    this.torrentViewMdel = new TorrentViewModel
                    {
                        Torrents = this.torrentManager
                                       .GetTorrents(type)
                                       .ToPagedList(page, pageSize)
                    };
                }
                catch (ArgumentException ex)
                {
                    return RedirectToAction("ErrorPage", new { error = ex.Message });
                }
            }
            else
                this.torrentViewMdel = new TorrentViewModel
                {
                    Torrents = this.torrentManager
                                   .GetTorrents()
                                   .ToPagedList(page, pageSize)
                };
            return View(this.torrentViewMdel);
        }

        /// <summary>
        /// View of current Torrent.
        /// </summary>
        /// <param name="id">The torrent identifier.</param>
        /// <param name="page">The page number of comments.</param>
        [HttpGet]
        public ActionResult Torrent(int id, int page = 1)
        {
            int pageSize = 5;

            try
            {
                this.torrentViewMdel = new TorrentViewModel
                {
                    Torrent = this.torrentManager.GetTorrent(id),
                    Comments = this.torrentManager.GetComments(id).ToPagedList(page, pageSize),
                    PopularTorrents = this.torrentManager.GetPopularTorrents()
                };
            }
            catch (ArgumentException ex)
            {
                return RedirectToAction("ErrorPage", new { error = ex.Message });
            }
            return View(this.torrentViewMdel);
        }

        /// <summary>
        /// Downloads the specified torrent file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        [Authorize]
        public FileResult Download(string filePath)
        {
            this.torrentManager.IncDownloadsCount(filePath);
            return File(filePath, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(filePath));
        }

        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name="id">The torrent identifier.</param>
        /// <param name="comment">The comment text.</param>
        [HttpPost]
        public ActionResult AddComment(int id, string comment)
        {
            this.torrentManager.AddComment(id, comment);
            return RedirectToAction("Torrent", "Torrent", routeValues: new { id = id });
        }

        /// <summary>
        /// View of add the torrent.
        /// </summary>
        [HttpGet]
        public ActionResult AddTorrent()
        {
            return View(new AddTorrentViewModel
            {
                ListTypes = torrentManager.GetListTypes()
            });
        }

        /// <summary>
        /// Adds the torrent.
        /// </summary>
        /// <param name="model">The torrent model.</param>
        /// <param name="image">The torrent image.</param>
        /// <param name="torrentFile">The torrent file.</param>
        [HttpPost]
        public ActionResult AddTorrent(AddTorrentViewModel model, HttpPostedFileBase image, HttpPostedFileBase torrentFile)
        {
            if (model.TorrentType != null)
            {
                model.ListTypes = torrentManager.GetListTypes();
                return View(model);
            }
            torrentManager.AddTorrent(model.Torrent, image, torrentFile);
            return RedirectToAction("AddTorrent", "Torrent");
        }

        /// <summary>
        /// View of Options of Web site.
        /// </summary>
        [HttpGet]
        [Authorize(Roles="Admin")]
        public ActionResult Options()
        {
            return View();
        }

        /// <summary>
        /// View of Search of the torrent.
        /// </summary>
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        /// <summary>
        /// Searches the torrent.
        /// </summary>
        /// <param name="keyword">The keyword(torrent name).</param>
        [HttpPost]
        public PartialViewResult SearchTorrent(string keyword)
        {
            searchViewModel = new SearchViewModel
            {
                Torrents = torrentManager.SearchTorrents(keyword)
            };
            return PartialView(searchViewModel);
        }


        /// <summary>
        /// View of error page.
        /// </summary>
        /// <param name="error">The error.</param>
        [HttpGet]
        public ActionResult ErrorPage(string error)
        {
            return View("Error", null, error);
        }
    }
}
