<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Calendar.aspx.cs" Inherits="Ammonia.Calendar" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="calendarHeader" class="col-md-12 bordered"><h2 style="color: red">Календарь мероприятий
        </h2></div>
    <asp:Calendar ID="Calendar1" runat="server" CssClass="col-md-12" BackColor="#FFFFCC" FirstDayOfWeek="Monday" Font-Bold="False" Font-Size="X-Large" ForeColor="Black" OnDayRender="Calendar1_DayRender" ShowGridLines="True" OnSelectionChanged="Calendar1_SelectionChanged">
        <DayHeaderStyle BackColor="#99CCFF" Font-Bold="True" />
        <DayStyle Font-Bold="True" />
        <OtherMonthDayStyle Font-Strikeout="False" ForeColor="Gray" />
    </asp:Calendar>
    <asp:Panel runat="server" CssClass="col-md-12" ID="EventDescriptionFull" style="padding: 0;" Visible="False">
        <asp:Panel runat="server" CssClass="col-md-12 bordered" ID="EventHeader" style="font-weight: bold; padding: 0;"></asp:Panel>
        <asp:Panel runat="server" CssClass="col-md-12" ID="EventDiscription"></asp:Panel>
    </asp:Panel>
</asp:Content>