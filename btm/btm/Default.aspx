<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="btm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .menu
        {
            position:fixed;
            top:0;
            right:0;
            width:20%;
            height:100%;
        }
        .search
        {
            position:fixed;
            top:64%;
            right:20%;
            width:40%;
            height:16%;
        }
       .login
        {
            position:fixed;
            top:0;
            left:0;
            width:100%;
            height:100%;
        }
    </style>
</head>
<body bgcolor="black">
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" CssClass="menu">
            <asp:ImageButton ID="Logo" runat="server" Style="position:absolute;top:0;right:0;width:100%;height:16%;" OnClick="Logo_Click" />
            <asp:ImageButton ID="Explore" runat="server" Style="position:absolute;top:16%;right:0;width:100%;height:16%;" OnClick="Explore_Click" />
            <asp:ImageButton ID="Create" runat="server" Style="position:absolute;top:32%;right:0;width:100%;height:16%;" OnClick="Create_Click" />
            <asp:ImageButton ID="News" runat="server" Style="position:absolute;top:48%;right:0;width:100%;height:16%;" OnClick="News_Click" />
            <asp:ImageButton ID="Search" runat="server" Style="position:absolute;top:64%;right:0;width:100%;height:16%;" OnClick="Search_Click" />
            <asp:ImageButton ID="profile" runat="server" Style="position:absolute;top:80%;right:0;width:100%;height:16%;" OnClick="profile_Click" />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" CssClass="search" BackColor="Gray" Visible="false">
            <div style="position:absolute;top:35%;width:60%;left:5%;">
            <asp:TextBox ID="TextBox1" runat="server" Height="20%" Width="100%" ></asp:TextBox>
            </div>
            <asp:ImageButton ID="DoSearch" runat="server" Style="position:absolute;top:0;right:0;width:30%;height:100%;" OnClick="DoSearch_Click" />
        </asp:Panel>
         <asp:Panel ID="Panel3" runat="server" CssClass="login" BackImageUrl="~/loginbg.png" Visible="false" >
            <div style="position:absolute;top:35%;width:60%;left:27%;">
          <font color="white">username:</font>  <asp:TextBox ID="TextBox2" runat="server" Height="20%" Width="50%" ></asp:TextBox>
             <br />
             <br />
             <font color="white">password:</font><asp:TextBox ID="TextBox3" runat="server" Height="20%" Width="50%" " TextMode="Password"></asp:TextBox>
            </div>
             <asp:ImageButton ID="doLogin" runat="server" Style="position:absolute;top:47%;left:34%;width:10%;height:3%;" OnClick="doLogin_Click" />
             <asp:ImageButton ID="doRegister" runat="server" Style="position:absolute;top:47%;left:54%;width:10%;height:3%;" OnClick="doRegister_Click" />
             <asp:ImageButton ID="closeLogin" runat="server" Style="position:absolute;top:30%;left:61%;width:3%;height:3%;" OnClick="closeLogin_Click" />
            
        </asp:Panel>
    </form>
</body>
</html>
