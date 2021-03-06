﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Suzy.Web.Index" %>
<%@ Import Namespace="Suzy.BO" %>
<%@ Import Namespace="Suzy.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <!--MAP-->
    <div class="container-fluid" style="line-height: 0px;">
	    <div class="row" style="padding-top: 0px; margin-left: -20px;
margin-right: -20px;">
	      <div  id="big-map" style="height: 405px; width: 100%;"></div>
	    </div>
    </div>
	<!--BODY-->
	<%--<div class="container" style="float: bottom;">
		<div class="row">
			<div class="span4">
			  <h3>Typographic scale</h3>
			  <p>The entire typographic grid is based on two Less variables in our variables.less file: <code>baseFontSize</code> and <code>baseLineHeight</code>. The first is the base font-size used throughout and the second is the base line-height.</p>
			  <p>We use those variables, and some math, to create the margins, paddings, and line-heights of all our type and more.</p>
			</div>
			<div class="span4">
			  <h3>Example body text</h3>
			  <p>Nullam quis risus eget urna mollis ornare vel eu leo. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
			  <p>Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor. Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio sem nec elit. Donec sed odio dui.</p>
			</div>
			<div class="span4">
			  
				<h3>Example body text</h3>
			  <p>Nullam quis risus eget urna mollis ornare vel eu leo. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
			  <p>Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor. Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio sem nec elit. Donec sed odio dui.</p>
			  
			</div>
	  </div>
	</div>--%>
</asp:Content>
<asp:Content ID="ContentJS1" ContentPlaceHolderID="JsContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var setting = {};
            <%
            if(SessionManager.IsAuthorization())
            {
                %>
            setting.users = new Array();
                <%
                foreach (Suzy.BO.Account account in SessionManager.GetAccount().GetFollowing())
                {
                    LocationArea lastPoint = account.LastPoint();
                    if(lastPoint != null)
                    { %>
            var user<%= account.id %> = new Object();
            user<%= account.id %>.Latitude = "<%= lastPoint.lattitude %>";
            user<%= account.id %>.Longitude = "<%= lastPoint.longtitude %>";
            user<%= account.id %>.Name = "<%= account.name ?? account.email %>";
            setting.users.push(user<%= account.id %>);
                <%
                    }
                }
            }
            %>
            
            $("#big-map").suzyMap(setting);
        });

</script>
</asp:Content>
