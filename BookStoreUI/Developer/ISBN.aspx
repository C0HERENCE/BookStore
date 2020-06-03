<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ISBN.aspx.cs" Inherits="ppll.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList2_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox7" runat="server" Height="50px" 
            TextMode="MultiLine" Width="537px"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox11" runat="server" Height="189px" 
            TextMode="MultiLine" Width="543px"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox12" runat="server" Height="216px" 
            TextMode="MultiLine" Width="536px"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox14" runat="server" Height="216px" 
            TextMode="MultiLine" Width="536px"></asp:TextBox>
        <br />
        <br />
    </div>
    </form>
    <script src="jquery.js"></script>
    <script>
        function get(isbn) {
            $.ajax({
                url: 'http://api.xiaomafeixiang.com/api/bookinfo',
                data: {
                    isbn: isbn
                },
                beforeSend: function () {
                    console.log('before');
                },
                success: function (data) {
                    console.log(data);
                },
                error: function () {
                    console.log('error');
                },
                complete: function () {
                    console.log('finish');
                }
            });
        }
    </script>
</body>
</html>
