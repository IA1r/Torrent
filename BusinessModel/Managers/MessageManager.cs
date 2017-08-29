using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Repository;
using Core.Dto;

namespace BusinessModel.Managers
{

    /// <summary>
    /// The Message Manager
    /// </summary>
    public class MessageManager
    {

        /// <summary>
        /// The Private Message repository
        /// </summary>
        private PrivateMessageRepository repository;

        public MessageManager()
        {
            repository = new PrivateMessageRepository();
        }

        /// <summary>
        /// Sends the message to user.
        /// </summary>
        /// <param name="messageDto">The message dto.</param>
        /// <param name="titleDto">The title dto.</param>
        public void SendMessage(PrivateMessageDto messageDto, MessageTitleDto titleDto)
        {
            repository.SendMessage(messageDto, titleDto);
        }

        /// <summary>
        /// Gets the messages.
        /// </summary>
        /// <param name="id">The title identifier.</param>
        public PrivateMessageDto[] GetMessages(int id)
        {
            return repository.GetMessages(id);
        }

        /// <summary>
        /// Gets the titles.
        /// </summary>
        /// <param name="type">The title type.</param>
        /// <returns></returns>
        public MessageTitleDto[] GetTitles(string type)
        {
            return repository.GetTitles(type);
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <param name="id">The title identifier.</param>
        /// <returns></returns>
        public MessageTitleDto GetTitle(int id)
        {
            return repository.GetTitle(id);
        }

        /// <summary>
        /// Sends the answer.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <param name="message">The message.</param>
        public void SendAnswer(int id, string message)
        {
            repository.SendAnswer(id, message);
        }
    }
}
