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
    
    public partial class INVOICE
    {
        public int INVOICE_ID { get; set; }
        public Nullable<int> ORDER_ID { get; set; }
        public Nullable<int> PAYMENT_ID { get; set; }
        public System.DateTime ISSUE_DATE { get; set; }
    
        public virtual ORDER ORDER { get; set; }
        public virtual PAYMENT PAYMENT { get; set; }
    }
}
