<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeeManagement.aspx.cs" Inherits="EmployeeManagementSystem.EmployeeManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Delete member</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>UserName</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Member ID"></asp:TextBox>                           
                       
                  <div class="row">
                     <div class="col-15 mx-auto">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete User Permanently" OnClick="Button2_Click" />
                     </div>
                            </div>
   </div>
                            
</div>
 <br>
                  </div>
               </div>
            </div>
                </div>
             </div>
      <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
                    <div class="card-body">
                       <div class="row">
                          <div class="col">
                             <center>
                                <h4>Login Details</h4>
                             </center>
                          </div>
                       </div>
                       <div class="row">
                          <div class="col">
                             <hr>
                          </div>
                       </div>
                       <div class="row">
                          <div class="col">
                             <asp:GridView class="table table-striped table-bordered" ID="GridView2" runat="server"></asp:GridView>
                          </div>
                       </div>
                    </div>
                 </div>
            </div>
          
            <br>
         </div>
         <div class="col-md-10">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Member List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                     </div>
                  </div>
               </div>
            </div>  <a href="homepage.aspx"><< Back to Home</a><br>
         </div>
      </div>
   </div>
</asp:Content>
