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
    
    public partial class ORDER_CUST_REQUESTS
    {
        public int ORDER_CUST_REQ_ID { get; set; }
        public Nullable<int> ORDER_ID { get; set; }
        public Nullable<int> CUST_REQ_ID { get; set; }
        public decimal BUST_LINE { get; set; }
        public decimal WAIST_LINE { get; set; }
        public decimal HIP_LINE { get; set; }
    
        public virtual CUSTOMER_REQUEST CUSTOMER_REQUEST { get; set; }
        public virtual ORDER ORDER { get; set; }
    }
}
