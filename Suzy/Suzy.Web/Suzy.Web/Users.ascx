<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Users.ascx.cs" Inherits="Suzy.Web.Users1" %>
<%@ Import Namespace="Suzy.BO" %>
<%@ Import Namespace="Suzy.Web" %>
<div class="container">
        <table class="table table-striped userList">
        <thead>
          <tr>
            <th>#</th>
            <th>Name</th>
            <th>Email</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <%  if (this.Accounts != null)
              foreach(Account account in this.Accounts) {%>
          <tr>
            <td><a href="<%= Suzy.Web.Helper.UserURL(account) %>"><%= account.id %></a></td>
            <td><a href="<%= Suzy.Web.Helper.UserURL(account) %>"><%= account.name ?? string.Empty %></a></td>
            <td><a href="<%= Suzy.Web.Helper.UserURL(account) %>"><%= account.email %></a></td>
                        <td><% if(SessionManager.IsAuthorization())
                   {
                       if (SessionManager.Get() == account.id)
                       {
                                       
                       }
                       else if(SessionManager.GetAccount().IsFollowing(account.id))
                       {
                           %><input class="btn btn-mini btn-danger userFolButton" id="<%=account.id %>" type="button" value="Follow"><%
                       }
                       else
                       {
                            %><input class="btn btn-mini btn-success userFolButton" id="<%=account.id %>"type="button" value="Following"><%
                       }
                   }
                     %></td>
            <td><% if(SessionManager.IsAuthorization())
                   {
                       if(SessionManager.GetAccount().IsFollower(account.id))
                       {
                           %><input class="btn btn-mini disabled " type="button"
         value="Follower"><%
                       }
                   }
                     %></td>
          </tr>
          <% } %>
        </tbody>
      </table>
    </div>