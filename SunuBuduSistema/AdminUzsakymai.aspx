<%@ Page   Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminUzsakymai.aspx.cs" Inherits="SunuBuduSistema.AdminUzsakymai" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href ="AdminUzsakymai.css" rel="stylesheet" />
    <div>
       <asp:GridView ID="Uzsakymai" runat="server" CellPadding="5" AutoGenerateColumns="False"  OnPageIndexChanging="OnPaging" AllowPaging="True"
           OnRowEditing="Uzsakymai_RowEditing" OnRowCancelingEdit="Uzsakymai_RowCancelingEdit" onrowdatabound="Uzsakymai_RowDataBound" OnRowUpdating="Uzsakymai_RowUpdating"
           BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="3px" CssClass="auto-style1" Width="801px">
        <Columns>          
            
             <asp:TemplateField HeaderText="Užsakymo nr">  
                    <ItemTemplate>  
                        <asp:Label ID="Id" runat="server" Text='<%#Eval("Id") %>'></asp:Label>  
                    </ItemTemplate>  
             </asp:TemplateField> 
             <asp:TemplateField HeaderText="Data">  
                    <ItemTemplate>  
                        <asp:Label ID="Data" runat="server" Text='<%#Eval("Data") %>'></asp:Label>  
                    </ItemTemplate>  
             </asp:TemplateField> 
             <asp:TemplateField HeaderText="Būsena">  
                    <ItemTemplate>  
                        <asp:Label ID="Busena" runat="server" Text='<%#Eval("Busena") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:DropDownList ID="busenos" runat="server"  Font-Size="15px" Width="150px">
                        </asp:DropDownList>
                    </EditItemTemplate> 
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="Kaina (eurais)">  
                    <ItemTemplate>  
                        <asp:Label ID="Kaina" runat="server" Text='<%#Eval("Kaina") %>'></asp:Label>  
                    </ItemTemplate>  
             </asp:TemplateField> 
             <asp:TemplateField HeaderText="Preliminari data">  
                    <ItemTemplate>  
                        <asp:Label ID="Preliminari_data" runat="server" Text='<%#Eval("Preliminari_data") %>'></asp:Label>  
                    </ItemTemplate>  
             </asp:TemplateField> 
             <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:LinkButton ID="btn_Edit" runat="server"  BackColor="" Text="Redaguoti būseną" style="font-style:italic; font-weight:bold; " CommandName="Edit" />  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:LinkButton ID="btn_Update" runat="server" BackColor="" Text="Išsaugoti"  style="font-style:italic; font-weight:bold; " CommandName="Update"/>  
                        <asp:LinkButton ID="btn_Cancel" runat="server" BackColor="" Text="Atšaukti" style="font-style:italic; font-weight:bold; " CommandName="Cancel"/>  
                    </EditItemTemplate>  
              </asp:TemplateField> 

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
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
            margin-top: 106px;
        }
        
    </style>
</asp:Content>

