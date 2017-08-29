using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.EntityModel;
using Core.Dto;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace DataModel.Repository
{

    /// <summary>
    /// The Torrent Repository
    /// </summary>
    public class TorrentRepository
    {

        /// <summary>
        /// The entity context
        /// </summary>
        private Torrent_dbEntities context;

        /// <summary>
        /// The user identifier
        /// </summary>
        private int userID = 0;
        public TorrentRepository()
        {
            context = new Torrent_dbEntities();

            this.userID = context.Users
                .Where(u => u.Login == HttpContext.Current.User.Identity.Name)
                .Select(u => u.UserID)
                .SingleOrDefault();
        }

        /// <summary>
        /// Gets the torrents.
        /// </summary>
        public TorrentDto[] GetTorrents()
        {
            return this.context.Torrents
                .Select(t => new
                {
                    torrent = new TorrentDto
                    {
                        ID = t.TorrentID,
                        TorrentType = t.TorrentType.Name
                    },
                    characteristics = t.TorrentCharacteristics
                    .Where(ch => ch.Characteristic.Name == "Name" || ch.Characteristic.Name == "Image")
                    .Select(ch => new
                    {
                        Name = ch.Characteristic.Name,
                        Value = ch.CharacteristicValue
                    })
                })
                .AsEnumerable()
                .Select(x =>
                {
                    x.torrent.Characteristics = x.characteristics
                        .ToDictionary(ch => ch.Name, ch => ch.Value);
                    return x.torrent;

                })
                .ToArray();
        }

        /// <summary>
        /// Gets the torrents.
        /// </summary>
        /// <param name="type">The torrent type.</param>
        public TorrentDto[] GetTorrents(string type)
        {
            if (!this.context.TorrentTypes.Any(t => t.Name == type))
                return null;

            return this.context.Torrents
                .Where(t => t.TorrentType.Name == type)
                .Select(t => new
                {
                    torrent = new TorrentDto
                    {
                        ID = t.TorrentID,
                        TorrentType = t.TorrentType.Name
                    },
                    characteristics = t.TorrentCharacteristics
                    .Where(ch => ch.Characteristic.Name == "Name" || ch.Characteristic.Name == "Image")
                    .Select(ch => new
                    {
                        Name = ch.Characteristic.Name,
                        Value = ch.CharacteristicValue
                    })
                })
                .AsEnumerable()
                .Select(x =>
                {
                    x.torrent.Characteristics = x.characteristics
                        .ToDictionary(ch => ch.Name, ch => ch.Value);
                    return x.torrent;

                })
                .ToArray();
        }

        /// <summary>
        /// Gets the torrent.
        /// </summary>
        /// <param name="id">The torrent identifier.</param>
        public TorrentDto GetTorrent(int id)
        {
            if (!this.context.Torrents.Any(t => t.TorrentID == id))
                return null;

            return this.context.Torrents
                .Where(t => t.TorrentID == id)
                .Select(t => new
                {
                    torrent = new TorrentDto
                    {
                        ID = t.TorrentID,
                        TorrentType = t.TorrentType.Name,
                        TorrentFile = new TorrentFileDto
                        {
                            TorrentFileID = t.TorrentFile.TorrentFileID,
                            Size = t.TorrentFile.Size,
                            Path = t.TorrentFile.Path,
                            DownloadsCount = t.TorrentFile.DownloadsCount,
                            AddedDate = t.TorrentFile.AddedDate
                        },
                    },
                    characteristics = t.TorrentCharacteristics
                    .Select(ch => new
                    {
                        Name = ch.Characteristic.Name,
                        Value = ch.CharacteristicValue
                    })
                })
                .AsEnumerable()
                 .Select(x =>
                 {
                     x.torrent.Characteristics = x.characteristics
                         .ToDictionary(ch => ch.Name, ch => ch.Value);
                     return x.torrent;

                 })
                 .Single();
        }

        /// <summary>
        /// Searches the torrents.
        /// </summary>
        /// <param name="name">The torrent name.</param>
        public TorrentDto[] SearchTorrents(string name)
        {
            if (!this.context.TorrentCharacteristics.Any(tc => tc.Characteristic.Name == "Name" && tc.CharacteristicValue.Contains(name)))
                return null;

            return this.context.TorrentCharacteristics
                .Where(tc => tc.Characteristic.Name == "Name" && tc.CharacteristicValue.Contains(name))
                .Select(tc => new
                {
                    torrent = new TorrentDto
                    {
                        ID = tc.TorrentID,
                        TorrentType = tc.Torrent.TorrentType.Name,
                        TorrentFile = new TorrentFileDto
                        {
                            Size = tc.Torrent.TorrentFile.Size,
                            DownloadsCount = tc.Torrent.TorrentFile.DownloadsCount,
                        },
                    },
                    characteristics = tc.Torrent.TorrentCharacteristics
                    .Where(ch => ch.Characteristic.Name == "Name" || ch.Characteristic.Name == "Image")
                    .Select(ch => new
                    {
                        Name = ch.Characteristic.Name,
                        Value = ch.CharacteristicValue
                    })

                })
                .AsEnumerable()
                 .Select(x =>
                 {
                     x.torrent.Characteristics = x.characteristics
                         .ToDictionary(ch => ch.Name, ch => ch.Value);
                     return x.torrent;

                 })
                 .ToArray();
        }

        /// <summary>
        /// Gets the comments of torrent.
        /// </summary>
        /// <param name="id">The torrent identifier.</param>
        public CommentDto[] GetComments(int id)
        {
            return this.context.Comments
                .Where(com => com.TorrentID == id)
                .Select(com => new CommentDto
                {
                    ID = com.CommentID,
                    Comment = com.Message,
                    Author = new UserDto
                    {
                        Login = com.User.Login,
                        Image = com.User.Image,
                        DownloadsCount = com.User.DownloadsCount.ToString()
                    },
                    PostedDate = com.PostedDate,
                    LastEdit = com.LastEdit.Value
                })
                .ToArray();
        }

        /// <summary>
        /// Adds the comment to torrent.
        /// </summary>
        /// <param name="id">The torrent identifier.</param>
        /// <param name="comment">The comment.</param>
        public void AddComment(int id, string comment)
        {
            this.context.Comments.Add(new Comment
            {
                AuthorID = this.userID,
                TorrentID = id,
                Message = comment,
                PostedDate = DateTime.Now,
            });
            this.context.SaveChanges();
        }

        /// <summary>
        /// Edits the comment.
        /// </summary>
        /// <param name="newComment">The new comment dto.</param>
        public void EditComment(CommentDto newComment)
        {
            Comment oldComment = this.context.Comments.Find(newComment.ID);

            oldComment.Message = newComment.Comment;
            oldComment.LastEdit = DateTime.Now;

            this.context.Entry(oldComment).State = EntityState.Modified;
            this.context.SaveChanges();

        }

        /// <summary>
        /// Adds the torrent.
        /// </summary>
        /// <param name="torrentDto">The torrent dto.</param>
        /// <param name="image">The image of torrent.</param>
        /// <param name="file">The torrentfile.</param>
        public void AddTorrent(TorrentDto torrentDto, HttpPostedFileBase image, HttpPostedFileBase file)
        {
            if (image != null && file != null)
            {
                string imageName = System.IO.Path.GetFileName(image.FileName);
                string imagePath = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images"), imageName);
                image.SaveAs(imagePath);

                string fileName = System.IO.Path.GetFileName(file.FileName);
                string filePath = System.IO.Path.Combine(HttpContext.Current.Server.MapPath("~/TorrentFiles"), fileName);
                file.SaveAs(filePath);

                torrentDto.Characteristics.Add("12", "/Content/Images/" + imageName);

                TorrentFile torrentFile = new TorrentFile
                {
                    Path = "/TorrentFiles/" + fileName,
                    Size = torrentDto.TorrentFile.Size,
                    DownloadsCount = 0,
                    AddedDate = DateTime.Now
                };
                this.context.TorrentFiles.Add(torrentFile);
                this.context.SaveChanges();

                Torrent torrent = new Torrent
                {
                    TorrentTypeID = this.context.TorrentTypes
                                    .Where(tp => tp.Name == torrentDto.TorrentType)
                                    .Select(tp => tp.TorrentTypeID)
                                    .SingleOrDefault(),
                    TorrentFileID = this.context.TorrentFiles
                                    .Where(tf => tf.Path == torrentFile.Path)
                                    .Select(tf => tf.TorrentFileID)
                                    .SingleOrDefault()
                };

                this.context.Torrents.Add(torrent);
                this.context.SaveChanges();

                foreach (string key in torrentDto.Characteristics.Keys)
                {
                    this.context.TorrentCharacteristics.Add(new TorrentCharacteristic
                    {
                        TorrentID = torrent.TorrentID,
                        CharacteristicID = Convert.ToInt32(key),
                        CharacteristicValue = torrentDto.Characteristics[key]
                    });
                }
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// Increments the downloads count.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        public void IncDownloadsCount(string filepath)
        {
            TorrentFile file = this.context.TorrentFiles
                .Where(tf => tf.Path == filepath)
                .Single();
            User user = this.context.Users
                .Where(u => u.UserID == this.userID)
                .Single();

            file.DownloadsCount = file.DownloadsCount + 1;
            user.DownloadsCount = user.DownloadsCount + 1;

            this.context.Entry(file).State = EntityState.Modified;
            this.context.Entry(user).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        /// <summary>
        /// Gets the list types.
        /// </summary>
        public List<SelectListItem> GetListTypes()
        {
            return this.context.TorrentTypes
                .Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Name
                })
                .Distinct()
                .ToList<SelectListItem>();
        }

        /// <summary>
        /// Gets the popular torrents.
        /// </summary>
        public TorrentDto[] GetPopularTorrents()
        {
            return this.context.Torrents
                .Where(t => t.TorrentFile.DownloadsCount > 0)
                .Select(t => new
                {
                    torrent = new TorrentDto
                    {
                        ID = t.TorrentID,
                        TorrentType = t.TorrentType.Name,
                        TorrentFile = new TorrentFileDto
                        {
                            DownloadsCount = t.TorrentFile.DownloadsCount
                        }
                    },
                    characteristics = t.TorrentCharacteristics
                    .Where(ch => ch.Characteristic.Name == "Name" || ch.Characteristic.Name == "Image")
                    .Select(ch => new
                    {
                        Name = ch.Characteristic.Name,
                        Value = ch.CharacteristicValue
                    })
                })

                .AsEnumerable()
                .Select(x =>
                 {
                     x.torrent.Characteristics = x.characteristics
                         .ToDictionary(ch => ch.Name, ch => ch.Value);
                     return x.torrent;

                 })
                 .OrderByDescending(t => t.TorrentFile.DownloadsCount)
                 .Take(6)
                 .ToArray();
        }
    }
}
