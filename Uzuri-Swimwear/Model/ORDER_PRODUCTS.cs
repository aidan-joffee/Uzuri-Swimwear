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
    
    public partial class ORDER_PRODUCTS
    {
        public int ORDER_ID { get; set; }
        public int PRODUCT_ID { get; set; }
        public int QTY { get; set; }
        public decimal BUST_LINE { get; set; }
        public decimal WAIST_LINE { get; set; }
        public decimal HIP_LINE { get; set; }
    
        public virtual ORDER ORDER { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}