<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignForm.ascx.cs" Inherits="Suzy.Web.SignForm" %>
<%@ Import Namespace="Suzy.BO" %>
<%@ Import Namespace="Suzy.Web" %>
    <% if (SessionManager.IsAuthorization())
       { %>
<div class="span4" ></div>
<div class="span2" style="
    text-align: right;
">
<%--    <a href="/profile" >
        <img src="http://cs419718.vk.me/v419718749/3b3b/HLAQDGdCRAk.jpg" style="height: 60px;">
    </a>  --%>   
</div>
<div class="span3">
    <a href="/profile"  style="text-decoration: none;">
        <h3 class="tile-text"><%= AccountList.Get((int) SessionManager.Get()).name ?? AccountList.Get((int) SessionManager.Get()).email  %></h3>             
    </a>
</div>
    <% } 
       else
       { %>
<div class="span5" ></div>
<div class="span4" >
    <form class="well form-inline login-form" style="float:right; margin: 0px; padding-bottom: 1em; padding-top: 1em; margin-top:10px;">
  	    <input type="email" class="input-small login-email" placeholder="Email">
  	    <input type="password" class="input-small login-password" placeholder="Password">
	    <button type="submit" class="btn btn-primary login-button" style="padding-bottom: 5px; padding-top: 5px;">Sign</button>
<%--	    <a class="btn btn-info" style="padding-bottom: 5px; padding-top: 5px;" href="#"><i class="icon-wrench  icon-white"></i></a>--%>
    </form>
</div>
    <% } %>
