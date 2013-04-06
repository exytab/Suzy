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
                    <div class="control-group">
                        <label class="control-label" for="disabledInput">E-mail</label>
                        <div class="controls">
                            <input class="input-xlarge disabled" id="disabledInput" type="text" placeholder="" disabled value="<%= SessionManager.GetAccount().email ?? string.Empty %>">
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="focusedInput">Name</label>
                        <div class="controls">
                            <input class="input-xlarge focused" id="Text1" type="text" value="<%= SessionManager.GetAccount().name ?? string.Empty %>">
                        </div>
                    </div>                    

                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JsContent" runat="server">
</asp:Content>
