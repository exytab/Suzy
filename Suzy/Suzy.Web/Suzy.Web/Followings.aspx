<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Followings.aspx.cs" Inherits="Suzy.Web.Followings" %>

<%@ Register Src="~/Users.ascx" TagPrefix="uc1" TagName="Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <uc1:Users runat="server" ID="Users" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JsContent" runat="server">
</asp:Content>
