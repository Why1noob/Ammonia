<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="photoVideo.aspx.cs" Inherits="Ammonia.PhotoVideo" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="bordered" style="color: red; margin-bottom: 0;">Галерея</h2>
    <asp:Panel runat="server" CssClass="row row-height" ID="PhotoVideoMainPanel">
        <asp:Panel runat="server" CssClass="col-md-12" ID="EnlargedPanel">
            <asp:Panel runat="server" CssClass="col-md-1 col-height" ID="PrevImagePanel" style="padding-left: 0; padding-right: 0;">
                <asp:Panel runat="server" CssClass="col-md-12 invisible" style="height:48%">a</asp:Panel>
                <asp:Button runat="server" CssClass="col-md-12 btn btn-default" ID="PrevButton" Text="&lt;" OnClick="PrevButton_Click" />
                <asp:Panel runat="server" CssClass="col-md-12 invisible" style="height:48%">a</asp:Panel>
            </asp:Panel>
            <asp:Image ID="ViewedImage" runat="server" CssClass="col-md-10 bordered" style="padding: 0" />
            <asp:Panel runat="server" CssClass="col-md-1 col-height" ID="NextImagePanel" style="padding-left: 0; padding-right: 0;">
                <asp:Panel runat="server" CssClass="col-md-12 invisible" style="height:48%">a</asp:Panel>
                <asp:Button runat="server" CssClass="col-md-12 btn btn-default" ID="NextButton" Text="&gt;" OnClick="NextButton_Click" />
                <asp:Panel runat="server" CssClass="col-md-12 invisible" style="height:48%">a</asp:Panel>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel runat="server" CssClass="col-md-12" ID="CollectionPanel"></asp:Panel>
    </asp:Panel>
</asp:Content>
