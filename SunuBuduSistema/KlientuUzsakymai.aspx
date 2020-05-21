<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KlientuUzsakymai.aspx.cs" Inherits="SunuBuduSistema.KlientuUzsakymai" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <link href ="KlientuUzsakymai.css" rel="stylesheet" />
     <div class="mainBox">
    <asp:GridView ID="Uzsakymai" runat="server" CellPadding="3" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Užsakymo numeris" />
            <asp:BoundField DataField="Data" HeaderText="Data" />
            <asp:BoundField DataField="Busena" HeaderText="Būsena" />
            <asp:BoundField DataField="Kaina" HeaderText="Kaina" />
            <asp:BoundField DataField="Preliminari_data" HeaderText="Preliminari data" />
            <asp:BoundField DataField="Kiekis" HeaderText="Sienų kiekis" />
            <asp:BoundField DataField="Medis" HeaderText="Sienos medis" />
            <asp:BoundField DataField="SpalvosPav" HeaderText="Sienos spalva" />
            <asp:BoundField DataField="AngosForma" HeaderText="Sienos anga" />
            <asp:BoundField DataField="Dydis" HeaderText="Sienos dydis" />
            <asp:BoundField DataField="StogoMedis" HeaderText="Stogo medis" />
            <asp:BoundField DataField="StogoSpalva" HeaderText="Stogo spalva" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
         </div>
</asp:Content>
