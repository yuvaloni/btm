<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePicture.aspx.cs" Inherits="btm.UpdatePicture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:ImageButton ID="ImageButton1" runat="server" Height="57px" OnClick="ImageButton1_Click" Width="53px" />
        (change profile picture)<br />
        <asp:ImageButton ID="ImageButton2" runat="server" Height="89px" OnClick="ImageButton2_Click" Width="97px" />
        (return to homepage)</div>
    </form>
</body>
</html>
