<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPersonalInformation.aspx.cs" Inherits="YMClothsStore.ModifyPersonalInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        
    
        <asp:Label ID="Label1" runat="server" Text="staffId:"></asp:Label>
        <asp:TextBox ID="staffId" runat="server"></asp:TextBox>
        </br>
        <asp:Label ID="Label2" runat="server" Text="staffName:"></asp:Label>
        <asp:TextBox ID="staffName" runat="server"></asp:TextBox>
        </br>
        <asp:Label ID="Label3" runat="server" Text="staffGender"></asp:Label>
        <asp:TextBox ID="staffGender" runat="server"></asp:TextBox>
        </br>
        <asp:Label ID="Label4" runat="server" Text="staffPhone:"></asp:Label>
        <asp:TextBox ID="staffPhone" runat="server"></asp:TextBox>
        </br>
        <asp:Label ID="Label5" runat="server" Text="password:"></asp:Label>
        <asp:TextBox ID="password" runat="server"></asp:TextBox>
        </br>
        <asp:Label ID="Label6" runat="server" Text="passwordConfirm:"></asp:Label>
        <asp:TextBox ID="passwordConfirm" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="getStaff" runat="server" Text="getStaff" OnClick="getStaff_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:Button ID="ok" runat="server" Text="ok" />&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:Button ID="concel" runat="server" Text="concel" />
        </br>
        
    
    </div>
        
    </form>
</body>
</html>
