<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Suzy.Web.Profile" %>
<%@ Import Namespace="Suzy.BO" %>
<%@ Import Namespace="Suzy.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div class="container profilePage">
        <div class="row">
            <div class="span2"></div>
            <div class="span8">
                <h2>Profile</h2>
                <br/>
                <fieldset>
                    <input type="hidden" id="idInput" value="<%= SessionManager.GetAccount().id %>"/>
                    <div class="control-group">
                        <label class="control-label" for="emailInput">E-mail</label>
                        <div class="controls">
                            <input class="input-xlarge disabled" id="emailInput" type="text" placeholder="" disabled value="<%= SessionManager.GetAccount().email ?? string.Empty %>">
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="nameInput">Name</label>
                        <div class="controls">
                            <input class="input-xlarge focused" id="nameInput" type="text" value="<%= SessionManager.GetAccount().name ?? string.Empty %>">
                        </div>
                    </div>                    
                    <div class="control-group">
                        <label class="control-label" for="passwordInput">Password</label>
                        <div class="controls">
                            <input class="input-xlarge" id="passwordInput" type="password" value="">
                        </div>
                    </div>  
                    <div class="control-group">
                        <label class="control-label" for="password2Input">Repeat password</label>
                        <div class="controls">
                            <input class="input-xlarge" id="password2Input" type="password" value="">
                        </div>
                    </div> 
                    <div class="control-group">
                        <button type="submit" class="btn btn-primary" id="saveProfile">Save changes</button>
                    </div> 
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JsContent" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        $(".profilePage").suzyProfile();
    });
</script>
</asp:Content>
