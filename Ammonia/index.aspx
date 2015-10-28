<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Ammonia.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="navigation">
        
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="newsHeader" class="col-md-12 bordered"><h2 style="color: red">Новости</h2></div>
    <asp:Panel runat="server" ID="newsSpace" CssClass="col-md-12 bordered" style="padding: 0"></asp:Panel>
</asp:Content>
