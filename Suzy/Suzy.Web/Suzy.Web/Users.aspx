<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Suzy.Web.Users" %>
<%@ Import Namespace="Suzy.BO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div class="container">
        <table class="table table-striped">
        <thead>
          <tr>
            <th>#</th>
            <th>Name</th>
            <th>Email</th>
          </tr>
        </thead>
        <tbody>
          <% foreach(Account account in AccountList.Get()) {%>
          <tr>
            <td><a href="<%= Suzy.Web.Helper.UserURL(account) %>"><%= account.id %></a></td>
            <td><a href="<%= Suzy.Web.Helper.UserURL(account) %>"><%= account.name ?? string.Empty %></a></td>
            <td><a href="<%= Suzy.Web.Helper.UserURL(account) %>"><%= account.email %></a></td>
          </tr>
          <% } %>
        </tbody>
      </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JsContent" runat="server">
</asp:Content>
