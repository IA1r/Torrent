using Core.Dto;
using Core.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataModel.Repository
{

    /// <summary>
    /// The Private Message Repository
    /// </summary>
    public class PrivateMessageRepository
    {

        /// <summary>
        /// The entity context
        /// </summary>
        private Torrent_dbEntities context;

        /// <summary>
        /// The current user identifier
        /// </summary>
        private int userID = 0;
        public PrivateMessageRepository()
        {
            this.context = new Torrent_dbEntities();
            this.userID = context.Users
                .Where(u => u.Login == HttpContext.Current.User.Identity.Name)
                .Select(u => u.UserID)
                .SingleOrDefault();
        }

        /// <summary>
        /// Sends the message to user.
        /// </summary>
        /// <param name="messageDto">The message dto.</param>
        /// <param name="titleDto">The title dto.</param>
        public void SendMessage(PrivateMessageDto messageDto, MessageTitleDto titleDto)
        {
            MessageTitle messageTitle = new MessageTitle();

            messageTitle.FromUserID = this.userID;
            messageTitle.ToUserID = titleDto.ToUser.ID;
            messageTitle.Title = titleDto.Title;
            messageTitle.CreationDate = DateTime.Now;

            this.context.MessageTitles.Add(messageTitle);
            this.context.SaveChanges();

            this.context.PrivateMessages.Add(new PrivateMessage
            {
                Message = messageDto.Message,
                AuthorID = this.userID,
                CreationDate = DateTime.Now,
                MessageTitleID = messageTitle.MessageTitleID
            });
            this.context.SaveChanges();
        }

        /// <summary>
        /// Gets the titles.
        /// </summary>
        /// <param name="type">The message type.</param>
        public MessageTitleDto[] GetTitles(string type)
        {
            if (type == "input")
            {
                return this.context.MessageTitles
                                .Where(t => t.ToUserID == this.userID)
                                .Select(t => new MessageTitleDto
                                {
                                    ID = t.MessageTitleID,
                                    Title = t.Title,
                                    FromUser = new UserDto
                                    {
                                        Login = t.UserFrom.Login
                                    },
                                    CreationDate = t.CreationDate
                                })
                                .ToArray();
            }
            if (type == "output")
            {
                return this.context.MessageTitles
                               .Where(t => t.FromUserID == this.userID)
                               .Select(t => new MessageTitleDto
                               {
                                   ID = t.MessageTitleID,
                                   Title = t.Title,
                                   ToUser = new UserDto
                                   {
                                       Login = t.UserTo.Login
                                   },
                                   CreationDate = t.CreationDate
                               })
                               .ToArray();
            }
            return null;
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <param name="id">The title identifier.</param>
        public MessageTitleDto GetTitle(int id)
        {
            return this.context.MessageTitles
                .Where(t => t.MessageTitleID == id)
                .Select(t => new MessageTitleDto
                {
                    ID = t.MessageTitleID,
                    Title = t.Title,
                    CreationDate = t.CreationDate
                })
                .SingleOrDefault();
        }

        /// <summary>
        /// Gets the messages.
        /// </summary>
        /// <param name="id">The title identifier.</param>
        public PrivateMessageDto[] GetMessages(int id)
        {
            return this.context.PrivateMessages
                .Where(m => m.MessageTitleID == id)
                .Select(m => new PrivateMessageDto
                {
                    ID = m.PrivateMessageID,
                    Message = m.Message,
                    Author = new UserDto
                    {
                        ID = m.User.UserID,
                        Login = m.User.Login
                    },
                    CreationDate = m.CreationDate
                })
                .ToArray();
        }

        /// <summary>
        /// Sends the answer.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="message">The message.</param>
        public void SendAnswer(int id, string message)
        {
            PrivateMessage answer = new PrivateMessage
            {
                Message = message,
                AuthorID = this.userID,
                MessageTitleID = id,
                CreationDate = DateTime.Now
            };

            this.context.PrivateMessages.Add(answer);
            this.context.SaveChanges();
        }
    }
}
