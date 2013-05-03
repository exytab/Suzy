<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Tabs.ascx.cs" Inherits="Suzy.Web.Tabs" %>

<div class="container" style="height: 50px">
	<div class="navbar" style="height: 25px">
		<div class="container">
			<ul class="nav" style="width: 100%;">
			    <li class="active">
				    <a href="/">Home</a>
			    </li>
			    <li class="divider-vertical"></li>
                <li>
			        <a href="/users">Users</a>
			    </li>
                <li class="divider-vertical"></li>
                <% if (Suzy.Web.SessionManager.IsAuthorization()) { %>
			    <li>
			        <a href="/profile">Profile</a>
			    </li>
                <li>
			        <a href="/followings">Followings</a>
			    </li>
                <li>
			        <a href="/followers">Followers</a>
			    </li>
                <li style="float: right;">
                     <a href="#" id="logout">Logout</a>
                </li>
                <% } %>
<%--			    <li class="divider-vertical"></li>
			    <li><a href="#">Link 2</a></li>
			    <li class="divider-vertical"></li>
			    <li><a href="#">Link 3</a></li>--%>
		    </ul>
		</div>
	</div>
</div>
