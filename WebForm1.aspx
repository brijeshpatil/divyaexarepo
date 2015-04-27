<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="userid" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:TemplateField HeaderText="UserID">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Bind("userid") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Bind("userid") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%#Bind("fname") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtfname" runat="server" Text='<%#Bind("fname") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%#Bind("lname") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtlname" runat="server" Text='<%#Bind("lname") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>&nbsp;
                            <asp:Button ID="Button1" runat="server" Text="Add" CommandName="ADD" />
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" />
                    <asp:CommandField ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
