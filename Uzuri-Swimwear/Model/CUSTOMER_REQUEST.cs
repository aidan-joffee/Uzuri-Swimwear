//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uzuri_Swimwear.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUSTOMER_REQUEST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER_REQUEST()
        {
            this.CART_REQUESTS = new HashSet<CART_REQUESTS>();
            this.ORDER_CUST_REQUESTS = new HashSet<ORDER_CUST_REQUESTS>();
            this.AspNetUsers = new HashSet<AspNetUser>();
        }
    
        public int CUST_REQ_ID { get; set; }
        public string DESCRIPTION { get; set; }
        public string COLOUR { get; set; }
        public string PATTERN { get; set; }
        public Nullable<int> IMAGE_ID { get; set; }
        public int CATEGORY_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CART_REQUESTS> CART_REQUESTS { get; set; }
        public virtual CATEGORY CATEGORY { get; set; }
        public virtual IMAGE IMAGE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_CUST_REQUESTS> ORDER_CUST_REQUESTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
