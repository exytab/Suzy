<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Suzy.Web.User" %>
<%@ Import Namespace="Suzy.BO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <!--NAME-->
<div class="container">
	      <h2><%= string.IsNullOrEmpty(this.account.name) ? this.account.email : this.account.name %></h2>
    
</div>
    <!--MAP-->
    <div class="container-fluid" style="line-height: 0px;">
	    <div class="row" style="padding-top: 0px; margin-left: -20px;
margin-right: -20px;">
	      <div id="profile-map" style="height: 405px; width: 100%;"></div>
	    </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JsContent" runat="server">
    <script type="text/javascript">
    $(document).ready(function () {

        var setting = {};
        setting.points = new Array();
        <% foreach(LocationArea point in this.locationAreas)
           { %>
        setting.points.push({ 
            Latitude: "<%= Suzy.Web.Helper.PointToString(point.lattitude) %>",
            Longitude: "<%= Suzy.Web.Helper.PointToString(point.longtitude) %>", 
            Title: "<%= point.time_of_marking.ToString() %>"
        });
        <% } %>

        $("#profile-map").suzyMap(setting);
        //$("#profile-map").suzyMap({ test: 'test1' });

    });
    </script>
</asp:Content>
