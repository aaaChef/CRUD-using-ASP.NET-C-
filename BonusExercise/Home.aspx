<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BonusExercise.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="./style.css" />
    <title></title>
</head>
<body>
   
   

    
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="Label3" runat="server" Text="User Information Form"></asp:Label><br />
             <asp:Label ID="lblNotify" runat="server" Text="" ForeColor="DarkRed" disabled></asp:Label>
             <br />
             <asp:Label ID="Label1" runat="server" Text="User Id:"></asp:Label><br />
             <asp:TextBox ID="txtUserid" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" Text="UserName:"></asp:Label><br />
<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
       
       <asp:GridView ID="dataGridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="dataGridView1_RowCommand" AutoGenerateColumns="False" DataKeyNames="UserID">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="userid" HeaderText="UserID" ReadOnly="True" />
        <asp:BoundField DataField="username" HeaderText="Name" />
        <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" Text="Delete" />
        <asp:ButtonField ButtonType="Button" CommandName="broUpdate" HeaderText="Update" Text="Update" />
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView>

       
    </form>

      
     
</body>
</html>
