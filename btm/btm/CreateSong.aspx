<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateSong.aspx.cs" Inherits="btm.CreateSong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        song name:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
    </div>
        <asp:ImageButton ID="ImageButton1" runat="server" Height="83px" OnClick="ImageButton1_Click" Width="100px" />
        (create)</form>
</body>
</html>
