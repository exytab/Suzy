<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignForm.ascx.cs" Inherits="Suzy.Web.SignForm" %>
<%@ Import Namespace="Suzy.BO" %>
<%@ Import Namespace="Suzy.Web" %>
    <% if (SessionManager.IsAuthorization())
       { %>
        <div align="right" >
          <ul class="thumbnails" style="float:right">
             <li class="span3 tile ">
               <a href="#" >
                 <img src="http://cs419718.vk.me/v419718749/3b3b/HLAQDGdCRAk.jpg">
                 <h5><%= AccountList.Get((int) SessionManager.Get()).email %></h5>
               </a>    
             </li>
          </ul>
        </div>
    <% } 
       else
       { %>
<form class="well form-inline login-form" style="float:right; margin: 0px; padding-bottom: 1em; padding-top: 1em; margin-top:10px;">
  	<input type="email" class="input-small login-email" placeholder="Email">
  	<input type="password" class="input-small login-password" placeholder="Password">
	<button type="submit" class="btn btn-primary login-button" style="padding-bottom: 5px; padding-top: 5px;">Sign</button>
	<a class="btn btn-info" style="padding-bottom: 5px; padding-top: 5px;" href="#"><i class="icon-wrench  icon-white"></i></a>
  	<!--<div style="width:110px;">-->
<!--   			 		<div style='float: bottom;'>
  			<label class="checkbox" ><strong>Remember password</strong><input type="checkbox"> </label> 
  		</div> -->
  			
  	<!-- <button type="submit" class="btn btn-primary" style="padding-bottom: 5px; padding-top: 5px;">Sign</button> -->
  	<!-- <button type="submit" class="btn btn-info" style="padding-bottom: 5px; padding-top: 5px;">Sign up</button>  -->
</form>
    <% } %>
