using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{

    /// <summary>
    /// The PrivateMessage data transfer object
    /// </summary>
    public class PrivateMessageDto
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The  message identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message text.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author dto.
        /// </value>
        public UserDto Author { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }
    }
}
