<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Calendar.aspx.cs" Inherits="Ammonia.Calendar" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="calendarHeader" class="col-md-12 bordered"><h2 style="color: red">Календарь мероприятий
        </h2></div>
    <asp:Calendar ID="Calendar1" runat="server" CssClass="col-md-12" BackColor="#FFFFCC" FirstDayOfWeek="Monday" Font-Bold="False" Font-Size="X-Large" ForeColor="Black" OnDayRender="Calendar1_DayRender" ShowGridLines="True">
        <DayHeaderStyle BackColor="#99CCFF" Font-Bold="True" />
        <DayStyle Font-Bold="True" />
        <OtherMonthDayStyle Font-Strikeout="False" ForeColor="Gray" />
    </asp:Calendar>
    <asp:Panel runat="server" CssClass="col-md-12" ID="EventDescription" Visible="False"></asp:Panel>
</asp:Content>