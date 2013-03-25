<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignForm.ascx.cs" Inherits="Suzy.Web.SignForm" %>
<form class="well form-inline" style="float:right; margin: 0px; padding-bottom: 1em; padding-top: 1em;margin-top:10px;">
    <% if (Session["id"] == null)
       { %>
  	<input type="text" class="input-small" placeholder="Email">
  	<input type="password" class="input-small" placeholder="Password">
	<button type="submit" class="btn btn-primary" style="padding-bottom: 5px; padding-top: 5px;">Sign</button>
	<a class="btn btn-info" style="padding-bottom: 5px; padding-top: 5px;" href="#"><i class="icon-wrench  icon-white"></i></a>
  	<!--<div style="width:110px;">-->
<!--   			 		<div style='float: bottom;'>
  			<label class="checkbox" ><strong>Remember password</strong><input type="checkbox"> </label> 
  		</div> -->
  			
  	<!-- <button type="submit" class="btn btn-primary" style="padding-bottom: 5px; padding-top: 5px;">Sign</button> -->
  	<!-- <button type="submit" class="btn btn-info" style="padding-bottom: 5px; padding-top: 5px;">Sign up</button>  -->
    <% } 
       else
       { %>
    111111

    <% } %>
</form>