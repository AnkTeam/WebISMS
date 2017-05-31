<%@ Page Title="" Language="C#" MasterPageFile="~/RollMaster.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="WebISMSManagmentSystem.User" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/TabDesign.css" rel="stylesheet" />
    <style>
             
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    
    <center>
        
        <div id="new div" style="margin-left:-800px;margin-top:20px;; height: 31px; width: 279px;">
            <asp:Menu ID="Menu1" runat="server" CssClass="tabs" onmenuitemclick="Menu1_MenuItemClick" Orientation="Horizontal"   StaticMenuItemStyle-CssClass="tab" StaticSelectedStyle-CssClass="selectedtab" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" StaticSubMenuIndent="10px">
                <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
              <StaticMenuItemStyle HorizontalPadding="20px" VerticalPadding="2px" />
                  <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#B5C7DE" />
                <DynamicSelectedStyle BackColor="#507CD1" />
                  <Items>
                    <asp:MenuItem Selected="true" Text="Generic" Value="0"></asp:MenuItem>
                    <asp:MenuItem Text="Project" Value="1"></asp:MenuItem>
                </Items>

<StaticSelectedStyle CssClass="selectedtab" BackColor="#507CD1"></StaticSelectedStyle>
            </asp:Menu>

      

        </div>
        <div style="margin-left:500px; margin-top:-30px; height: 27px;">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>

    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers><asp:AsyncPostBackTrigger ControlID="Menu1" />   </Triggers>
        <ContentTemplate>
            <asp:Label ID="TimeLabel" runat="server" Text="" />   
                                     
               <div class="tabcontents" style="">
        <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
        <asp:View ID="View1" runat="server">
            This is a View 1.
        </asp:View>
        <asp:View ID="View2" runat="server">
            This is a View 2.
        </asp:View>       
        </asp:MultiView>
        </div> 
        </ContentTemplate>
        </asp:UpdatePanel>     
    </div>
        </center>
     
</asp:Content>
