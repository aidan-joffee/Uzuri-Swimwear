﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uzuri_Swimwear
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class UzuriSwimwearDBEntities : DbContext
    {
        public UzuriSwimwearDBEntities()
            : base("name=UzuriSwimwearDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<ACCOUNT_TYPE> ACCOUNT_TYPE { get; set; }
        public virtual DbSet<ADDRESS> ADDRESSes { get; set; }
        public virtual DbSet<CART> CARTs { get; set; }
        public virtual DbSet<CART_PRODUCTS> CART_PRODUCTS { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<CUSTOMER_REQUEST> CUSTOMER_REQUEST { get; set; }
        public virtual DbSet<IMAGE> IMAGES { get; set; }
        public virtual DbSet<INVOICE> INVOICEs { get; set; }
        public virtual DbSet<ORDER> ORDERs { get; set; }
        public virtual DbSet<ORDER_CUST_REQUESTS> ORDER_CUST_REQUESTS { get; set; }
        public virtual DbSet<ORDER_PRODUCTS> ORDER_PRODUCTS { get; set; }
        public virtual DbSet<ORDER_STATUS> ORDER_STATUS { get; set; }
        public virtual DbSet<PASSWORD> PASSWORDs { get; set; }
        public virtual DbSet<PAYMENT> PAYMENTs { get; set; }
        public virtual DbSet<PAYMENT_METHOD> PAYMENT_METHOD { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
    
        public virtual int AddImageToProduct(Nullable<int> role, byte[] image, Nullable<int> product_ID, ObjectParameter responseMessage)
        {
            var roleParameter = role.HasValue ?
                new ObjectParameter("Role", role) :
                new ObjectParameter("Role", typeof(int));
    
            var imageParameter = image != null ?
                new ObjectParameter("Image", image) :
                new ObjectParameter("Image", typeof(byte[]));
    
            var product_IDParameter = product_ID.HasValue ?
                new ObjectParameter("Product_ID", product_ID) :
                new ObjectParameter("Product_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddImageToProduct", roleParameter, imageParameter, product_IDParameter, responseMessage);
        }
    
        public virtual int AddProduct(Nullable<int> role, string name, string description, Nullable<int> category_ID, ObjectParameter responseMessage)
        {
            var roleParameter = role.HasValue ?
                new ObjectParameter("Role", role) :
                new ObjectParameter("Role", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var category_IDParameter = category_ID.HasValue ?
                new ObjectParameter("Category_ID", category_ID) :
                new ObjectParameter("Category_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddProduct", roleParameter, nameParameter, descriptionParameter, category_IDParameter, responseMessage);
        }
    
        public virtual int EditProductImage(Nullable<int> role, Nullable<int> product_ID, Nullable<int> image_ID, ObjectParameter responseMessage)
        {
            var roleParameter = role.HasValue ?
                new ObjectParameter("Role", role) :
                new ObjectParameter("Role", typeof(int));
    
            var product_IDParameter = product_ID.HasValue ?
                new ObjectParameter("Product_ID", product_ID) :
                new ObjectParameter("Product_ID", typeof(int));
    
            var image_IDParameter = image_ID.HasValue ?
                new ObjectParameter("Image_ID", image_ID) :
                new ObjectParameter("Image_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditProductImage", roleParameter, product_IDParameter, image_IDParameter, responseMessage);
        }
    
        public virtual ObjectResult<GetAllProductsDetails_Result> GetAllProductsDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProductsDetails_Result>("GetAllProductsDetails");
        }
    }
}
