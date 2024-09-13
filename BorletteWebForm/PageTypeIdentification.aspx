<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageTypeIdentification.aspx.cs" Inherits="PageTypeIdentification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <asp:Label ID="Lbl_TypeIdentification" runat="server" Text="Type Identification :"></asp:Label>
            <asp:TextBox ID="Txt_LibelleType" runat="server"></asp:TextBox>

        </div>
        <div class="row">
            <hr />
        </div>
        <div class="row">
            <asp:Button runat="server" ID="Btn_Sauvegarder" Text ="Sauvegarder" />
        </div>
    </form>
</body>
</html>
