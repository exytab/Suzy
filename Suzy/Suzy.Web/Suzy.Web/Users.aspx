﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Suzy.Web.Users" %>
<%@ Import Namespace="Suzy.BO" %>
<%@ Register Src="~/Users.ascx" TagPrefix="uc1" TagName="Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <uc1:Users runat="server" id="Users1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JsContent" runat="server">
</asp:Content>
