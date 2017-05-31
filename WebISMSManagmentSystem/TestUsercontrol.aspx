<%@ Page Title="" Language="C#" MasterPageFile="~/ISMSmaster.Master" AutoEventWireup="true" CodeBehind="TestUsercontrol.aspx.cs" Inherits="WebISMSManagmentSystem.TestUsercontrol" %>

<%@ Register Src="~/UploadControl.ascx" TagPrefix="uc1" TagName="UploadControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UploadControl runat="server" id="UploadControl" />
</asp:Content>
