<%@ Page Title="" Language="C#" MasterPageFile="~/ISMSmaster.Master" AutoEventWireup="true" CodeBehind="ISMSLogin.aspx.cs" Inherits="WebISMSManagmentSystem.ISMSLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <script src="JsLogin/jquery-1.7.2.min.js"></script>
    <script src="JsLogin/Loginformvalidation.js"></script>
 <section class="container">
    <div class="login">
      <h1>Login to ISMS</h1>
     <p><asp:Label ID="ldlMessage" ForeColor="Red" runat="server"></asp:Label></p>
        <p>   <asp:TextBox ID="TxtUsername" runat="server" placeholder="Username"  ></asp:TextBox></p>
        <p> <asp:TextBox ID="txtpassword" runat="server"  placeholder="Password" TextMode="Password"></asp:TextBox></p>
        <p class="remember_me">
              <asp:CheckBox ID="remember_me"  runat="server" OnCheckedChanged="remember_me_CheckedChanged" />
              <label>
   
            &nbsp;Remember me on this computer
          </label>
        </p>
        <p class="submit"> <asp:Button ID="LoginISMSBntn" runat="server" Text="Login" OnClientClick="Loginvalidate()" OnClick="LoginISMSBntn_Click"  /></p>
    
    </div>

   <%-- <div class="login-help">
      <p>Forgot your password? <a href="index.html">Click here to reset it</a>.</p>
    </div>--%>
  </section>
  
</asp:Content>


  
