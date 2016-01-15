<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Disco.aspx.cs" Inherits="Ammonia.Admin.Disco" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPH" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderA" runat="server">
    <div>
        <div class="panel-group col-md-3">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" href="#ContentPlaceHolderA_collapseAlbums">Альбомы</a>
                    </h4>
                </div>
                <asp:Panel runat="server" ID="collapseAlbums" CssClass="panel-collapse collapse">
                    
                </asp:Panel>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="songsPanel">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <div class="panel-group col-md-3">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" href="#ContentPlaceHolderA_collapseSongs">Песни</a>
                    </h4>
                </div>
                <asp:Panel runat="server" ID="collapseSongs" CssClass="panel-collapse collapse">
                    
                </asp:Panel>
            </div>
        </div>
    </asp:Panel>
    <asp:Label runat="server" ID="DebugLabel"></asp:Label>
</asp:Content>
