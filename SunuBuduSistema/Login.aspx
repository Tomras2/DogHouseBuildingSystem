<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SunuBuduSistema.Login" %>
<asp:Content ID="Log" ContentPlaceHolderID="HeadContent" runat="server">
         <link href="StyleSheet2.css" rel="stylesheet" />
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <link href ="LoginStyle.css" rel="stylesheet" />
    <div class="login">
        <div>
        <h1 style="font-size:40px; color:white">Prisijungimas <img src="Images/doggie.png" width="70"/></h1>
        <%--<p>&nbsp;</p>--%>
        <h2 style="font-size:20px; color:white;" >Įveskite savo prisijungimo duomenis </h2>
          <asp:Label ID="UserErrorLabel" runat="server" Font-Size="18px" Text="Neteisingas prisijungimo vardas" Visible="False" ForeColor="Tomato"></asp:Label>
        <br />
        <asp:Label ID="PassErrorLabel" runat="server" Font-Size="18px" Text="Neteisingas slaptažodis" Visible="false" ForeColor="Tomato"></asp:Label>
        <br />
            <p>
                <asp:Label ID="Label1" runat="server" ForeColor="DimGray" Font-Size="18px" Text="Prisijungimo vardas" ></asp:Label>
                   </p>
            <p>
                <asp:TextBox ID="TextBox1" runat="server" ForeColor="White"  Width="300px" Font-Size="18px" ></asp:TextBox>
            </p>
            <p>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Font-Size="18px" ForeColor="Tomato" ErrorMessage="Reikalingas prisijungimo vardas" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>  
                </p>
           
            <p>
                <asp:Label ID="Label2" runat="server" ForeColor="DimGray" Font-Size="18px" Text="Slaptažodis" ></asp:Label>
                </p>
            
          <p>
                <asp:Textbox ID="TextBox2" runat="server" ForeColor="White" TextMode="Password" Width="300px" Font-Size="18px"></asp:Textbox>
                </p>
            <p>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Font-Size="18px" ForeColor="Tomato" ErrorMessage="Reikalingas slaptažodis" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>                     
            </p>
            <p>

            </p>
                <p> 
                    <asp:Button ID="Button1" runat="server" class="color" Height="40px" BorderColor="Black" ForeColor="black" style="padding-left:20px; padding-right:10px;" Text="Prisijungti" OnClick="Button1_Click" Width="300px" Font-Size="18px" />
            </p>
            </div> 
        </div>
</asp:Content>

