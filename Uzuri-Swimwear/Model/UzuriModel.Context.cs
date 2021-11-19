﻿//------------------------------------------------------------------------------
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
    
        public virtual int AddProductImage(Nullable<int> role, Nullable<int> product_ID, byte[] image, string imageName, Nullable<bool> isPrimary, ObjectParameter responseMessage)
        {
            var roleParameter = role.HasValue ?
                new ObjectParameter("Role", role) :
                new ObjectParameter("Role", typeof(int));
    
            var product_IDParameter = product_ID.HasValue ?
                new ObjectParameter("Product_ID", product_ID) :
                new ObjectParameter("Product_ID", typeof(int));
    
            var imageParameter = image != null ?
                new ObjectParameter("Image", image) :
                new ObjectParameter("Image", typeof(byte[]));
    
            var imageNameParameter = imageName != null ?
                new ObjectParameter("ImageName", imageName) :
                new ObjectParameter("ImageName", typeof(string));
    
            var isPrimaryParameter = isPrimary.HasValue ?
                new ObjectParameter("IsPrimary", isPrimary) :
                new ObjectParameter("IsPrimary", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddProductImage", roleParameter, product_IDParameter, imageParameter, imageNameParameter, isPrimaryParameter, responseMessage);
        }
    
        public virtual int DeleteProductImage(Nullable<int> role, Nullable<int> imageID, ObjectParameter responseMessage)
        {
            var roleParameter = role.HasValue ?
                new ObjectParameter("Role", role) :
                new ObjectParameter("Role", typeof(int));
    
            var imageIDParameter = imageID.HasValue ?
                new ObjectParameter("ImageID", imageID) :
                new ObjectParameter("ImageID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProductImage", roleParameter, imageIDParameter, responseMessage);
        }
    
        public virtual int EditProduct(Nullable<int> role, string name, string description, Nullable<int> product_ID, Nullable<bool> forSale, Nullable<int> category_ID, ObjectParameter responseMessage)
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
    
            var product_IDParameter = product_ID.HasValue ?
                new ObjectParameter("Product_ID", product_ID) :
                new ObjectParameter("Product_ID", typeof(int));
    
            var forSaleParameter = forSale.HasValue ?
                new ObjectParameter("ForSale", forSale) :
                new ObjectParameter("ForSale", typeof(bool));
    
            var category_IDParameter = category_ID.HasValue ?
                new ObjectParameter("Category_ID", category_ID) :
                new ObjectParameter("Category_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditProduct", roleParameter, nameParameter, descriptionParameter, product_IDParameter, forSaleParameter, category_IDParameter, responseMessage);
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
    
        public virtual ObjectResult<GetCartCustomerRequests_Result> GetCartCustomerRequests(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCartCustomerRequests_Result>("GetCartCustomerRequests", userIDParameter);
        }
    
        public virtual int GetCartProducts(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetCartProducts", userIDParameter);
        }
    
        public virtual ObjectResult<GetProdCategories_Result> GetProdCategories()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProdCategories_Result>("GetProdCategories");
        }
    
        public virtual ObjectResult<GetProductsForSale_Result> GetProductsForSale(ObjectParameter responseMessage)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductsForSale_Result>("GetProductsForSale", responseMessage);
        }
    
        public virtual int SetProductPrimaryImage(Nullable<int> role, Nullable<int> productID, Nullable<int> imageID, ObjectParameter responseMessage)
        {
            var roleParameter = role.HasValue ?
                new ObjectParameter("Role", role) :
                new ObjectParameter("Role", typeof(int));
    
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            var imageIDParameter = imageID.HasValue ?
                new ObjectParameter("ImageID", imageID) :
                new ObjectParameter("ImageID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetProductPrimaryImage", roleParameter, productIDParameter, imageIDParameter, responseMessage);
        }
    
        public virtual ObjectResult<GetProductImages_Result> GetProductImages(Nullable<int> productID, ObjectParameter responseMessage)
        {
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductImages_Result>("GetProductImages", productIDParameter, responseMessage);
        }
    }
}
