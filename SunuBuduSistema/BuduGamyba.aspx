<%@ Page Title="Budu projektavimas"Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuduGamyba.aspx.cs" Inherits="SunuBuduSistema.BuduGamyba" %>

<%--<!DOCTYPE html>--%>

<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<%--<head runat="server">--%>

   <%-- <title>Šuns būdos projektavimas</title>--%>
<%--</head>--%>
<%--<body>--%>
    <%--<form id="form1" runat="server">--%>
       <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
           <link href ="ProjektavimasStyle.css" rel="stylesheet" />
       <div>
            <p>
        <asp:Label ID="Label1" runat="server" Text="Šuns būdos projektavimas" style="padding:250px; color:lightgray; font-size: 50px; font-weight: 700" ></asp:Label>
          </p>
             <p>
                  <div align="center">
                 <img src="Images/dog.png" width="70"/>
                      </div>
               <asp:Label ID="Neprisijunges" runat="server" ForeColor="White" Text="Esate neprisijungęs(us)!" Visible="false" Font-Size="Large"></asp:Label>
               <asp:HyperLink ID="PrisijungimasLink" runat="server" NavigateUrl="~/Login.aspx" Visible="false" Font-Size="Large">Prisijunkite</asp:HyperLink>
               <asp:Label ID="Arba" ForeColor="White" runat="server" Text="arba" Visible="false" Font-Size="Large"></asp:Label>
               <asp:HyperLink ID="RegistracijaLink" runat="server" NavigateUrl="~/Registracija.aspx" Visible="false" Font-Size="Large">Registruokitės</asp:HyperLink>
           </p>
                  
           <div class="main">
        &nbsp;<p>
            <asp:Label ID="Label2" runat="server" Text="Sienos" style="font-size: 30px; font-weight: 700; padding:20px"></asp:Label>
        </p>
                   <p>
            <asp:Label ID="Label3" runat="server" Text="Kiekis" style="font-size:20px; padding-left:20px;padding-right:70px"></asp:Label>
                      
            <asp:TextBox ID="sienu_kiekis_box" runat="server" Font-Size="18px" Width="300px"></asp:TextBox>
                      <asp:RangeValidator ID="sienu_kiekis_validator" runat="server" ErrorMessage="Sienų kiekis turi būt tarp 1 ir 8" ControlToValidate="sienu_kiekis_box" MinimumValue="1" MaximumValue="8" ForeColor="Red" Type="Integer"></asp:RangeValidator>
        </p>
               
               
        <p>
            <asp:Label ID="Label4" runat="server" Text="Medis" style="font-size:20px; padding-left:20px;padding-right:67px"></asp:Label>
&nbsp;<asp:DropDownList ID="sienos_medis_list" runat="server" Font-Size="20px" Width="278px">
            </asp:DropDownList>
        </p>         
        <p>
            <asp:Label ID="Label5" runat="server" Text="Spalva" style="font-size:20px; padding-left:20px;padding-right:63px"></asp:Label>
            <asp:DropDownList ID="sienos_spalva_list" runat="server" Font-Size="20px" Width="278px">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="Angos forma" style="font-size:20px; padding-left:20px;padding-right:13px"></asp:Label>
            <asp:DropDownList ID="sienos_anga_list" runat="server" Font-Size="20px" Width="276px">
            </asp:DropDownList>
        </p>
            <p>
           <asp:Label ID="Label7" runat="server" Text="Angos uždengimas" style="font-size:20px; padding:20px"></asp:Label>
           <asp:CheckBox ID="uzdengimas_status" runat="server" />
               </p>
        <p>
            <asp:Label ID="Label8" runat="server" Text="Sienų dydis" style="font-size:20px; padding:20px"></asp:Label>
            <asp:DropDownList ID="sienos_dydziai_list" runat="server" Font-Size="18px" Width="280px">
            </asp:DropDownList>
        </p>
        <p>
            &nbsp;</p>
               </div>
      
            <div class="main">
                  <p>
            <asp:Label ID="Label9" runat="server" style="font-weight: 700; font-size: 30px; padding:20px"  Text="Stogas"></asp:Label>
            </p>
        <p>
            <asp:Label ID="Label10" runat="server" Text="Kaminas" style="font-size:20px; padding:20px"></asp:Label>
&nbsp;<asp:CheckBox ID="kaminas_status" runat="server" />
        </p>
        <p>
            <asp:Label ID="Label11" runat="server" Text="Spalva" style="font-size:20px; padding-left:20px;padding-right:63px"></asp:Label>
            <asp:DropDownList ID="stogo_spalva_list" runat="server" Font-Size="18px" Width="278px">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="Label12" runat="server" Text="Medis" style="font-size:20px;  padding-left:20px;padding-right:69px"></asp:Label>
            <asp:DropDownList ID="stogo_medis_list" runat="server" Font-Size="18px" Width="278px">
            </asp:DropDownList>
        </p>
            <p>
                &nbsp;</p>
            </div>
         
          <div class="main">
                <p>
            <asp:Label ID="Label13" runat="server" style="font-size: 30px; padding:20px; font-weight: 700; text-align: left" Text="Įranga" ></asp:Label>
            </p>
        <p>
            <asp:Label ID="Label14" runat="server" style="font-size: 20px; padding:20px" Text="Pasirinkite bent vieną komponentą" ></asp:Label>
        </p>
           <p>

               <asp:CheckBoxList ID="irangos_list" runat="server" Font-Size="18px" Width="275px">
               </asp:CheckBoxList>
           </p>         
           </div>
           <div class="main">
        <asp:Label ID="Label15" runat="server" Text="Papildomi komponentai" style="font-size: 30px; padding:20px; font-weight: 700"></asp:Label>

        <br />
        <asp:CheckBoxList ID="atributai_list" style="padding-left:30px; padding-right:50px" runat="server" Font-Size="18px" Width="275px">

        </asp:CheckBoxList>
               </div>

           <br />
           &nbsp;&nbsp;<asp:Label ID="Klaidalauku" runat="server" Text="Nėra užpildyti visi privalomi laukai!" style="font-size: 25px; font-weight:bold" Visible = "false" ForeColor = "Red"></asp:Label>

           <asp:Label ID="kainoslable" runat="server" style="font-size: 17px; padding-left: 450px; font-weight:bold" ForeColor = "LightBlue" Visible = "false" Text="Bendra kaina:"></asp:Label>

           &nbsp;&nbsp;

           &nbsp;<asp:Label ID="kaina" runat="server" style="font-size: 25px; font-weight:bold" Visible = "false" ForeColor="LightBlue" Text="Label"></asp:Label>
           &nbsp;&nbsp;&nbsp;

           <asp:Label ID="datoslabel" runat="server" style="font-size: 17px; font-weight:bold" Visible = "false" ForeColor = "LightBlue" Text="Pagaminimo data:"></asp:Label>

           &nbsp;&nbsp;&nbsp;

           <asp:Label ID="data" runat="server" style="font-size: 25px; font-weight:bold" ForeColor = "LightBlue" Visible = "false" Text="Label"></asp:Label>       
           <br />
           <br />
        <asp:Button ID="Button1" runat="server" BackColor="LightBlue" Text="Užsakyti" Height="43px" style="text-align: center; font-size: 25px;" OnClick="Uzsakyti_Click"  />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Button ID="Button2" runat="server" BackColor="LightBlue" Height="43px" style="font-size: 25px;" Text="Skaičiuoti" Width="147px" OnClick="Button2_Click" />
           </div>
           </asp:Content>
     <%--   </form>--%>
<%--    </body>--%>
<%--    </html>--%>
