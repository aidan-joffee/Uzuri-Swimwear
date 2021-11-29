<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/UzuriSwimwear.Master" AutoEventWireup="true" CodeBehind="CustomOrder.aspx.cs" Inherits="Uzuri_Swimwear.Forms.CustomOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
      <div class="row">
         <div class="col-md-5 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img  width="100" src="/Images/uzuri-logo-transparent-small.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Custom Order</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col mx-auto">
                        <label>Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="DescriptionTextbox" runat="server" placeholder="Description" TextMode="MultiLine" Rows="4"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Colour</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="ColourTextbox" runat="server" placeholder="Colour"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Pattern</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="PatternTextbox" runat="server" placeholder="Pattern"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  
                   <div class="row">
                     <div class="col">
                        <label>Image</label>
                        <div class="form-group">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                     </div>
                  </div>
                   <td>  
                    <asp:Label ID="Label1" runat="server"></asp:Label>  
                </td>
                   <div class="col-md-4">
                        <label> </label>
                     </div>
                  <div class="row">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-outline-dark btn-block btn-lg" ID="OrderButton" runat="server" Text="Add to Cart" OnClick="OrderButton_Click" />
                               <asp:Button class="btn btn-outline-success btn-block btn-lg" ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click"/>
                           </div>
                        </center>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>