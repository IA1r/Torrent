using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{

    /// <summary>
    /// MessageTitle data transfer object
    /// </summary>
    public class MessageTitleDto
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The title identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets Sender.
        /// </summary>
        /// <value>
        /// Sender dto.
        /// </value>
        public UserDto FromUser { get; set; }

        /// <summary>
        /// Gets or sets Recipient.
        /// </summary>
        /// <value>
        /// Recipient dto.
        /// </value>
        public UserDto ToUser { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title name.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date of title.
        /// </value>
        public DateTime CreationDate { get; set; }

    }
}
