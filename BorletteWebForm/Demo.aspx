<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
             <%= Databindind %>
             <asp:Label ID="lbl_Text" runat="server"></asp:Label>
             <asp:Textbox ID="Txt_Text"  runat="server" EnableViewState="false"></asp:Textbox>
             <asp:Button ID="btn_Compteur" runat="server" OnClick="btn_Compteur_Click" Text="Demo" />

             <asp:DropDownList ID="ddl_DemoType" runat="server"> 
             </asp:DropDownList>
             <asp:CheckBox ID="CheckDEmo" runat="server" AutoPostBack="True" />

             <asp:GridView ID="GridViewDemo" runat="server" AutoGenerateColumns="false" AllowPaging="false"
                PageSize="10" Visible="true" OnRowDataBound="DemoRowDataBound">
                <Columns>
                    <asp:BoundField  DataField="Id" HeaderText="Code" />
                    <asp:BoundField  DataField="Name" HeaderText="Libelle" />
                    <asp:HyperLinkField HeaderText="" target="_blank"
                        DataNavigateUrlFormatString="~/PageTypeIdentification/{0}" DataNavigateUrlFields ="Id" Text="Editer" />
                    <asp:TemplateField HeaderText="Demo">
                        <ItemTemplate>
                            <asp:DropDownList ID="DemoGridItem" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
