using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{

    /// <summary>
    /// The Comment data transfer object
    /// </summary>
    public class CommentDto
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The comment identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment text.
        /// </value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author dto.
        /// </value>
        public UserDto Author { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date of commetn.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the last edit.
        /// </summary>
        /// <value>
        /// The last edit of comment.
        /// </value>
        public DateTime? LastEdit { get; set; }
    }
}
