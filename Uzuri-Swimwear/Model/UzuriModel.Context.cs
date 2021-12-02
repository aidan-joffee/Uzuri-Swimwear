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
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ADDRESS> ADDRESSes { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<CART> CARTs { get; set; }
        public virtual DbSet<CART_PRODUCTS> CART_PRODUCTS { get; set; }
        public virtual DbSet<CART_REQUESTS> CART_REQUESTS { get; set; }
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<CUSTOMER_REQUEST> CUSTOMER_REQUEST { get; set; }
        public virtual DbSet<IMAGE> IMAGES { get; set; }
        public virtual DbSet<INVOICE> INVOICEs { get; set; }
        public virtual DbSet<ORDER> ORDERs { get; set; }
        public virtual DbSet<ORDER_CUST_REQUESTS> ORDER_CUST_REQUESTS { get; set; }
        public virtual DbSet<ORDER_PRODUCTS> ORDER_PRODUCTS { get; set; }
        public virtual DbSet<ORDER_STATUS> ORDER_STATUS { get; set; }
        public virtual DbSet<PAYMENT> PAYMENTs { get; set; }
        public virtual DbSet<PAYMENT_METHOD> PAYMENT_METHOD { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<PRODUCT_IMAGES> PRODUCT_IMAGES { get; set; }
    
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
    
        public virtual int DeleteCartProduct(Nullable<int> cartProdId)
        {
            var cartProdIdParameter = cartProdId.HasValue ?
                new ObjectParameter("cartProdId", cartProdId) :
                new ObjectParameter("cartProdId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteCartProduct", cartProdIdParameter);
        }
    
        public virtual int DeleteCartRequst(Nullable<int> cartRequestId)
        {
            var cartRequestIdParameter = cartRequestId.HasValue ?
                new ObjectParameter("cartRequestId", cartRequestId) :
                new ObjectParameter("cartRequestId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteCartRequst", cartRequestIdParameter);
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
    
        public virtual ObjectResult<GetAllOrders_Result> GetAllOrders(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllOrders_Result>("GetAllOrders", startDateParameter, endDateParameter);
        }
    
        public virtual ObjectResult<GetAllProductsDetails_Result> GetAllProductsDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProductsDetails_Result>("GetAllProductsDetails");
        }
    
        public virtual ObjectResult<GetCartCustomerRequests_Result> GetCartCustomerRequests(string userID)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCartCustomerRequests_Result>("GetCartCustomerRequests", userIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GetCartFromId(string userId)
        {
            var userIdParameter = userId != null ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetCartFromId", userIdParameter);
        }
    
        public virtual ObjectResult<GetCartProducts_Result> GetCartProducts(string userID)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCartProducts_Result>("GetCartProducts", userIDParameter);
        }
    
        public virtual ObjectResult<GetCustomerDetails_Result> GetCustomerDetails(Nullable<int> orderID, ObjectParameter responseMessage)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("OrderID", orderID) :
                new ObjectParameter("OrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCustomerDetails_Result>("GetCustomerDetails", orderIDParameter, responseMessage);
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
    
        public virtual ObjectResult<GetPlacedOrderProducts_Result> GetPlacedOrderProducts(Nullable<int> orderID, ObjectParameter responseMessage)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("OrderID", orderID) :
                new ObjectParameter("OrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPlacedOrderProducts_Result>("GetPlacedOrderProducts", orderIDParameter, responseMessage);
        }
    
        public virtual int GetPlacedOrderRequests(Nullable<int> orderID, ObjectParameter responseMessage)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("OrderID", orderID) :
                new ObjectParameter("OrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetPlacedOrderRequests", orderIDParameter, responseMessage);
        }
    
        public virtual ObjectResult<GetProdCategories_Result> GetProdCategories()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProdCategories_Result>("GetProdCategories");
        }
    
        public virtual ObjectResult<GetProductImages_Result> GetProductImages(Nullable<int> productID, ObjectParameter responseMessage)
        {
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductImages_Result>("GetProductImages", productIDParameter, responseMessage);
        }
    
        public virtual ObjectResult<GetProductsForSale_Result> GetProductsForSale(ObjectParameter responseMessage)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductsForSale_Result>("GetProductsForSale", responseMessage);
        }
    
        public virtual int GetSumOfCart(string userID, ObjectParameter sumTotal)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetSumOfCart", userIDParameter, sumTotal);
        }
    
        public virtual ObjectResult<GetUserCustomRequests_Result> GetUserCustomRequests(string userID, ObjectParameter responseMessage)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserCustomRequests_Result>("GetUserCustomRequests", userIDParameter, responseMessage);
        }
    
        public virtual ObjectResult<GetUserProfileInfo_Result> GetUserProfileInfo(string userID)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserProfileInfo_Result>("GetUserProfileInfo", userIDParameter);
        }
    
        public virtual int LoginUser(string email, string password, ObjectParameter responseMessage)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LoginUser", emailParameter, passwordParameter, responseMessage);
        }
    
        public virtual int placeOrder(string userID, ObjectParameter orderID)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("placeOrder", userIDParameter, orderID);
        }
    
        public virtual int placeOrderItems(Nullable<int> orderID, Nullable<int> itemID, Nullable<decimal> bustLine, Nullable<decimal> waistLine, Nullable<decimal> hipLine, Nullable<bool> isProduct, ObjectParameter responseMessage)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("orderID", orderID) :
                new ObjectParameter("orderID", typeof(int));
    
            var itemIDParameter = itemID.HasValue ?
                new ObjectParameter("itemID", itemID) :
                new ObjectParameter("itemID", typeof(int));
    
            var bustLineParameter = bustLine.HasValue ?
                new ObjectParameter("bustLine", bustLine) :
                new ObjectParameter("bustLine", typeof(decimal));
    
            var waistLineParameter = waistLine.HasValue ?
                new ObjectParameter("waistLine", waistLine) :
                new ObjectParameter("waistLine", typeof(decimal));
    
            var hipLineParameter = hipLine.HasValue ?
                new ObjectParameter("hipLine", hipLine) :
                new ObjectParameter("hipLine", typeof(decimal));
    
            var isProductParameter = isProduct.HasValue ?
                new ObjectParameter("isProduct", isProduct) :
                new ObjectParameter("isProduct", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("placeOrderItems", orderIDParameter, itemIDParameter, bustLineParameter, waistLineParameter, hipLineParameter, isProductParameter, responseMessage);
        }
    
        public virtual int RegisterUser(string email, string password, string firstName, string lastName, string phone, string streetName, string city, string suburb, string postalCode, ObjectParameter responseMessage)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var streetNameParameter = streetName != null ?
                new ObjectParameter("StreetName", streetName) :
                new ObjectParameter("StreetName", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var suburbParameter = suburb != null ?
                new ObjectParameter("Suburb", suburb) :
                new ObjectParameter("Suburb", typeof(string));
    
            var postalCodeParameter = postalCode != null ?
                new ObjectParameter("PostalCode", postalCode) :
                new ObjectParameter("PostalCode", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RegisterUser", emailParameter, passwordParameter, firstNameParameter, lastNameParameter, phoneParameter, streetNameParameter, cityParameter, suburbParameter, postalCodeParameter, responseMessage);
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
    
        public virtual int usp_ImportImage(string picName, string imageFolderPath, string filename)
        {
            var picNameParameter = picName != null ?
                new ObjectParameter("PicName", picName) :
                new ObjectParameter("PicName", typeof(string));
    
            var imageFolderPathParameter = imageFolderPath != null ?
                new ObjectParameter("ImageFolderPath", imageFolderPath) :
                new ObjectParameter("ImageFolderPath", typeof(string));
    
            var filenameParameter = filename != null ?
                new ObjectParameter("Filename", filename) :
                new ObjectParameter("Filename", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_ImportImage", picNameParameter, imageFolderPathParameter, filenameParameter);
        }
    
        public virtual int usp_ImportImageToImages(string picName, string imageFolderPath, string filename)
        {
            var picNameParameter = picName != null ?
                new ObjectParameter("PicName", picName) :
                new ObjectParameter("PicName", typeof(string));
    
            var imageFolderPathParameter = imageFolderPath != null ?
                new ObjectParameter("ImageFolderPath", imageFolderPath) :
                new ObjectParameter("ImageFolderPath", typeof(string));
    
            var filenameParameter = filename != null ?
                new ObjectParameter("Filename", filename) :
                new ObjectParameter("Filename", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_ImportImageToImages", picNameParameter, imageFolderPathParameter, filenameParameter);
        }
    
        public virtual int DeleteCustRequest(Nullable<int> custReqId)
        {
            var custReqIdParameter = custReqId.HasValue ?
                new ObjectParameter("CustReqId", custReqId) :
                new ObjectParameter("CustReqId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteCustRequest", custReqIdParameter);
        }
    }
}
