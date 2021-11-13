using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Uzuri_Swimwear.Model
{
    /// <summary>
    /// Product class for accessing, editting and storing products to the database
    /// </summary>
    public class Product
    {
        [ScaffoldColumn(false)]
        private int id { get; set; }

        [Required, StringLength(255), Display(Name = "Name")]
        private string name { get; set; }

        [Required]
        private int categoryID { get; set; }

        [Required]
        private byte[] image { get; set; } //image stored in bytes

        [Required, StringLength(255), Display(Name = "Description")]
        private string description { get; set; }

        public virtual Category Category { get; set; }

    }
}
//-------------------------------------------end of file--------------------------------------------------