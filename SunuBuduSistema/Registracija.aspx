<%@ Page Language="C#"  Title="Register" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="SunuBuduSistema.Registracija" %>

<%--<!DOCTYPE html>--%>

<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<%--<head runat="server">--%>
  <%--  <title>Registracija</title>
    <link href="StyleSheet2.css" rel="stylesheet" />
</head>
<body>--%>
<%--    <form id="form1" runat="server">--%>
       <%-- <div>--%>
           
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href ="RegistracijaStyle.css" rel="stylesheet" />
            <div class="main">
                 <h1 style="font-size:300%; color:black; font-family:'Times New Roman'";>Vartotojo registracija</h1>

                <h1 style="font-size:200%; padding-bottom:20px; color:black; font-family:'Times New Roman'">Užpildykite visus pateiktus laukus</h1>
  <asp:Label ID="ErrorUserEmailLabel" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                <p>
                <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Prisijungimo vardas" Font-Size="20px" ></asp:Label>
        
                    </p>
                <p>
                <asp:TextBox ID="TextBox1" runat="server" Width="300px" Font-Size="18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Font-Size="Larger" ForeColor="Blue" ErrorMessage="Reikalingas prisijungimo vardas" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                                  
                    </p>
        <p>
            <asp:Label ID="Label2" runat="server" ForeColor="Black" Text="Vardas" Font-Size="20px"></asp:Label>
                </p>

                <p>
                <asp:TextBox ID="TextBox2"  runat="server" Width="300px" Font-Size="18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Font-Size="Larger" ForeColor="Blue" ErrorMessage="Reikalingas vardas" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                </p>
                <p>
                <asp:Label ID="Label3"  ForeColor="Black" runat="server" Text="Pavardė"  Font-Size="20px"></asp:Label>
        
                </p>
                <p>
        
                <asp:TextBox ID="TextBox3" runat="server" Width="300px" Font-Size="18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Font-Size="Larger" ForeColor="Blue" ErrorMessage="Reikalinga pavardė" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                </p>
        <p>
            <asp:Label ID="Label4" runat="server" ForeColor="Black" Text="Slaptažodis"  Font-Size="20px"  ></asp:Label>
                </p>
                <p>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" Width="300px" Font-Size="18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Font-Size="Larger" ForeColor="Blue" ErrorMessage="Reikalingas slaptažodis" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
                </p>
        <p>
            <asp:Label ID="Label5" runat="server" ForeColor="Black" Text="Telefonas"  Font-Size="20px" ></asp:Label>

                </p>
                <p>

                <asp:TextBox ID="TextBox5" runat="server" Width="300px" Font-Size="18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Font-Size="Larger" ForeColor="Blue" ErrorMessage="Reikalingas telefonas" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
                </p>
        <p>
            <asp:Label ID="Label6" runat="server" ForeColor="Black" Text="El.paštas"  Font-Size="20px" ></asp:Label>
            
             </p>
                <p>
                <asp:TextBox ID="TextBox6" runat="server" Width="300px" Font-Size="18px" ></asp:TextBox>      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Padding="100px" ForeColor="Blue" Font-Size="Larger" Display="Dynamic" ErrorMessage="Reikalingas el. paštas " ControlToValidate="TextBox6"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Font-Size="Larger" ForeColor="Blue" Display="Dynamic" ErrorMessage="Reikalingas teisingas el. paštas" ControlToValidate="TextBox6" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                </p>
                <p>
                <asp:Label ID="Label7" runat="server" ForeColor="Black" Text="Adresas" Font-Size="20px"></asp:Label>
               </p>
                <p>
                <asp:TextBox ID="TextBox7" runat="server" Width="300px" Font-Size="18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Font-Size="Larger" ForeColor="Blue" ErrorMessage="Reikalingas adresas" ControlToValidate="TextBox7"></asp:RequiredFieldValidator>
               </p>
                 <p>
                     &nbsp;</p>
                <div align="left">
                <asp:Button ID="RegistrationButton" runat="server" Text="Registruotis" Height="50px"  Width="150px" BackColor="CornflowerBlue" Font-Size="X-Large" OnClick="RegistrationButton_Click" />
            </div>
                </div>
       <%-- </div>--%>
   
  <%--  </form>
</body>
</html>--%>
</asp:Content>