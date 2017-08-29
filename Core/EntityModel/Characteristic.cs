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
    /// The Characteristic entity model
    /// </summary>
    public partial class Characteristic
    {
        public Characteristic()
        {
            this.TorrentCharacteristics = new HashSet<TorrentCharacteristic>();
        }

        /// <summary>
        /// Gets or sets the characteristic identifier.
        /// </summary>
        /// <value>
        /// The characteristic identifier.
        /// </value>
        public int CharacteristicID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The characteristic name.
        /// </value>
        public string Name { get; set; }
    
        public virtual ICollection<TorrentCharacteristic> TorrentCharacteristics { get; set; }
    }
}