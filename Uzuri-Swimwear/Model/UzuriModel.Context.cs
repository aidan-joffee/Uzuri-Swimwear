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
    
        public virtual ObjectResult<GetProductsForSale_Result> GetProductsForSale(string productName, Nullable<int> categoryID, ObjectParameter responseMessage)
        {
            var productNameParameter = productName != null ?
                new ObjectParameter("productName", productName) :
                new ObjectParameter("productName", typeof(string));
    
            var categoryIDParameter = categoryID.HasValue ?
                new ObjectParameter("categoryID", categoryID) :
                new ObjectParameter("categoryID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductsForSale_Result>("GetProductsForSale", productNameParameter, categoryIDParameter, responseMessage);
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
    
        public virtual int AddItemToCart(string userID, Nullable<int> itemID, Nullable<bool> isProduct, ObjectParameter responseMessage)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            var itemIDParameter = itemID.HasValue ?
                new ObjectParameter("itemID", itemID) :
                new ObjectParameter("itemID", typeof(int));
    
            var isProductParameter = isProduct.HasValue ?
                new ObjectParameter("isProduct", isProduct) :
                new ObjectParameter("isProduct", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddItemToCart", userIDParameter, itemIDParameter, isProductParameter, responseMessage);
        }
    
        public virtual ObjectResult<GetUserProfileInfo_Result> GetUserProfileInfo(string userID)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserProfileInfo_Result>("GetUserProfileInfo", userIDParameter);
        }
    
        public virtual int UpdateUserInfo(string userID, string firstName, string lastName, string phoneNumber, ObjectParameter responseMessage)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("phoneNumber", phoneNumber) :
                new ObjectParameter("phoneNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateUserInfo", userIDParameter, firstNameParameter, lastNameParameter, phoneNumberParameter, responseMessage);
        }
    
        public virtual int UpdateUserAddressInfo(string userID, string province, string city, string suburb, string streetName, string postalCode, ObjectParameter responseMessage)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            var provinceParameter = province != null ?
                new ObjectParameter("province", province) :
                new ObjectParameter("province", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("city", city) :
                new ObjectParameter("city", typeof(string));
    
            var suburbParameter = suburb != null ?
                new ObjectParameter("suburb", suburb) :
                new ObjectParameter("suburb", typeof(string));
    
            var streetNameParameter = streetName != null ?
                new ObjectParameter("streetName", streetName) :
                new ObjectParameter("streetName", typeof(string));
    
            var postalCodeParameter = postalCode != null ?
                new ObjectParameter("postalCode", postalCode) :
                new ObjectParameter("postalCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateUserAddressInfo", userIDParameter, provinceParameter, cityParameter, suburbParameter, streetNameParameter, postalCodeParameter, responseMessage);
        }
    
        public virtual int CheckUserAddress(string userID, ObjectParameter doesExist)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CheckUserAddress", userIDParameter, doesExist);
        }
    
        public virtual int CreateCustomRequest(string userID, string description, string colour, string pattern, byte[] image, string imageName, ObjectParameter responseMessage)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var colourParameter = colour != null ?
                new ObjectParameter("colour", colour) :
                new ObjectParameter("colour", typeof(string));
    
            var patternParameter = pattern != null ?
                new ObjectParameter("pattern", pattern) :
                new ObjectParameter("pattern", typeof(string));
    
            var imageParameter = image != null ?
                new ObjectParameter("image", image) :
                new ObjectParameter("image", typeof(byte[]));
    
            var imageNameParameter = imageName != null ?
                new ObjectParameter("imageName", imageName) :
                new ObjectParameter("imageName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateCustomRequest", userIDParameter, descriptionParameter, colourParameter, patternParameter, imageParameter, imageNameParameter, responseMessage);
        }
    
        public virtual int CreateProdCategory(string name, Nullable<decimal> price, ObjectParameter responseMessage)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateProdCategory", nameParameter, priceParameter, responseMessage);
        }
    
        public virtual ObjectResult<GetOrderProducts_Result> GetOrderProducts(string accountID)
        {
            var accountIDParameter = accountID != null ?
                new ObjectParameter("accountID", accountID) :
                new ObjectParameter("accountID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOrderProducts_Result>("GetOrderProducts", accountIDParameter);
        }
    
        public virtual ObjectResult<GetOrderRequests_Result> GetOrderRequests(string accountID)
        {
            var accountIDParameter = accountID != null ?
                new ObjectParameter("accountID", accountID) :
                new ObjectParameter("accountID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOrderRequests_Result>("GetOrderRequests", accountIDParameter);
        }
    
        public virtual ObjectResult<GetOrderStatus_Result> GetOrderStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOrderStatus_Result>("GetOrderStatus");
        }
    
        public virtual int placeOrder(Nullable<int> userID, ObjectParameter orderID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("placeOrder", userIDParameter, orderID);
        }
    
        public virtual ObjectResult<GetAllCategories_Result> GetAllCategories()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllCategories_Result>("GetAllCategories");
        }
    
        public virtual int DeleteProdCategory(Nullable<int> categoryID, ObjectParameter responseMessage)
        {
            var categoryIDParameter = categoryID.HasValue ?
                new ObjectParameter("categoryID", categoryID) :
                new ObjectParameter("categoryID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProdCategory", categoryIDParameter, responseMessage);
        }
    
        public virtual int UpdateCategory(Nullable<int> categoryID, string name, Nullable<decimal> price, ObjectParameter responseMessage)
        {
            var categoryIDParameter = categoryID.HasValue ?
                new ObjectParameter("categoryID", categoryID) :
                new ObjectParameter("categoryID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateCategory", categoryIDParameter, nameParameter, priceParameter, responseMessage);
        }
    
        public virtual int UpdateOrderStatus(Nullable<int> orderID, Nullable<int> orderStatusID, string userID, ObjectParameter responseMessage)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("orderID", orderID) :
                new ObjectParameter("orderID", typeof(int));
    
            var orderStatusIDParameter = orderStatusID.HasValue ?
                new ObjectParameter("orderStatusID", orderStatusID) :
                new ObjectParameter("orderStatusID", typeof(int));
    
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateOrderStatus", orderIDParameter, orderStatusIDParameter, userIDParameter, responseMessage);
        }
    
        public virtual ObjectResult<GetSingleProduct_Result> GetSingleProduct(Nullable<int> productID, ObjectParameter responseMessage)
        {
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("productID", productID) :
                new ObjectParameter("productID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSingleProduct_Result>("GetSingleProduct", productIDParameter, responseMessage);
        }
    
        public virtual ObjectResult<GetAllOrders_Result> GetAllOrders(Nullable<int> statusID, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var statusIDParameter = statusID.HasValue ?
                new ObjectParameter("statusID", statusID) :
                new ObjectParameter("statusID", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllOrders_Result>("GetAllOrders", statusIDParameter, startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<GetCustomerDetails_Result> GetCustomerDetails(Nullable<int> orderID, ObjectParameter responseMessage)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("OrderID", orderID) :
                new ObjectParameter("OrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCustomerDetails_Result>("GetCustomerDetails", orderIDParameter, responseMessage);
        }
    
        public virtual ObjectResult<GetPlacedOrderProducts_Result> GetPlacedOrderProducts(Nullable<int> orderID, ObjectParameter responseMessage)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("OrderID", orderID) :
                new ObjectParameter("OrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPlacedOrderProducts_Result>("GetPlacedOrderProducts", orderIDParameter, responseMessage);
        }
    
        public virtual ObjectResult<GetPlacedOrderRequests_Result> GetPlacedOrderRequests(Nullable<int> orderID, ObjectParameter responseMessage)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("OrderID", orderID) :
                new ObjectParameter("OrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPlacedOrderRequests_Result>("GetPlacedOrderRequests", orderIDParameter, responseMessage);
        }
    }
}
