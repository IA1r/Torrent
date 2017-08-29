//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.EntityModel
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The MessageTitle entity model
    /// </summary>
    public partial class MessageTitle
    {
        public MessageTitle()
        {
            this.PrivateMessages = new HashSet<PrivateMessage>();
        }


        /// <summary>
        /// Gets or sets the message title identifier.
        /// </summary>
        /// <value>
        /// The message title identifier.
        /// </value>
        public int MessageTitleID { get; set; }

        /// <summary>
        /// Gets or sets sender identifier.
        /// </summary>
        /// <value>
        /// Sender identifier.
        /// </value>
        public int FromUserID { get; set; }

        /// <summary>
        /// Gets or sets recipient identifier.
        /// </summary>
        /// <value>
        /// Recipient identifier.
        /// </value>
        public int ToUserID { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title of private message.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date of message title.
        /// </value>
        public System.DateTime CreationDate { get; set; }
    
        public virtual User UserFrom { get; set; }
        public virtual User UserTo { get; set; }
        public virtual ICollection<PrivateMessage> PrivateMessages { get; set; }
    }
}
