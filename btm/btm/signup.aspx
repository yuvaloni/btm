
<language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="btm.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         user name;<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
        <script runat="server">

            Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs)

            End Sub
</script>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
         <br />
         password:<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
         <br />
         verify password:<asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
         <br />
         full name:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
         <br />
         email:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
         <br />
         what instruments do you play?:<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
         <br />
          <recaptcha:RecaptchaControl
              ID="recaptcha"
              runat="server"
              Theme="black"
              PublicKey="6LfOSPUSAAAAAHCFIuw-ahRC7Yg37u9UjzkIcl_T"
              PrivateKey="6LfOSPUSAAAAAFmLm10UXLq1a8y3ULUpskT8hb7b"
              />

         <br />

    <div>
    
        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" Width="36px" />
    
        (sign up)</div>
    </form>
</body>
</html>
