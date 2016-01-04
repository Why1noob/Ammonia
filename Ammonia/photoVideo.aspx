<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="photoVideo.aspx.cs" Inherits="Ammonia.PhotoVideo" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="bordered" style="color: red">Фото/Видео</h2>
    <asp:Panel runat="server" CssClass="row" ID="PhotoVideoMainPanel">
        <asp:Panel runat="server" CssClass="col-md-12" ID="EnlargedPanel"></asp:Panel>
        <asp:Panel runat="server" CssClass="col-md-12" ID="CollectionPanel"></asp:Panel>
    </asp:Panel>
</asp:Content>
