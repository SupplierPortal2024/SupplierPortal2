<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Supplier Protal system</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script src="js/cloud.js" type="text/javascript"></script>
<script  type="text/javascript">
    $(function () {
        //检测IE
        if ('undefined' == typeof (document.body.style.maxHeight)) {
            window.location.href = 'ie6update.html';
        }
        $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
        $(window).resize(function () {
            $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
        })
    });
</script> 
<link href="js/win/win.css" rel="stylesheet" type="text/css" />
<script src="js/win.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function Check() {

        //var dialog = $.dialog.confirm('You must read and agree to the Privacy Policy<br> in order to proceed', function () {
        //    return true;
        //    //this.form1.Submit();
        //    //return false;
        //});
        var Name = form1.txtUserName.value;
        var PW = form1.txtPassword.value;
        var AgreePolicy = document.getElementById('ckAgreePolicy').checked;
    
        if (AgreePolicy == false) {
            $.dialog.alert('Please agree policy！');
            return false;
            ShowDiv('MyDiv', 'fade');
            
        }
        if (Name == "") {
            //win.errorInfo('账号不能为空!', null, null, '提示')
            $.dialog.alert('Please input user account！');
            return false;
        }
        if (PW == "") {
            $.dialog.alert('Please input password！');
            return false;
        }

        return true;
        this.form1.Submit();
    }

    function ShowDiv(show_div, bg_div) {
        document.getElementById(show_div).style.display = 'block';
        document.getElementById(bg_div).style.display = 'block';
        var bgdiv = document.getElementById(bg_div);
        bgdiv.style.width = document.body.scrollWidth;
        // bgdiv.style.height = $(document).height();
        $("#" + bg_div).height($(document).height());
    };
    //关闭弹出层
    function CloseDiv(show_div, bg_div) {
        document.getElementById(show_div).style.display = 'none';
        document.getElementById(bg_div).style.display = 'none';
    };
</script> 
<style>
.black_overlay{
display: none;
position: absolute;
top: 0%;
left: 0%;
width: 100%;
height: 100%;
background-color: black;
z-index:1001;
-moz-opacity: 0.8;
opacity:.80;
filter: alpha(opacity=80);
}
.white_content {
display: none;
position: absolute;
top: 30%;
left: 32%;
width: 40%;
height: 36%;
border: 3px solid lightblue;
background-color: white;
z-index:1002;
overflow: auto;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
 <div id="mainBody">
      <div id="cloud1" class="cloud"></div>
      <div id="cloud2" class="cloud"></div>
</div>  

<div class="logintop">    
    <span>Welcome to supplier portal system</span>  
</div>
    
<div > 
    <span class="systemlogo"></span>       
    <div class="loginbox">  
    <ul>
    <li><input name="txtUserName" ID="txtUserName" runat="server" type="text" class="loginuser" value="" /></li>
    <li><input name="txtPassword" ID="txtPassword" runat="server" type="password" class="loginpwd" value="" /></li>
    <li><asp:Button ID="btnSubmit" runat="server" Text="Login" CssClass="loginbtn" onclick="btnSubmit_Click"  OnClientClick="return Check();"/> &nbsp;&nbsp; &nbsp;&nbsp;<asp:CheckBox ID="ckAgreePolicy" Visible="false" Checked="true" runat="server" Text="&nbsp;&nbsp;" /><a style="visibility:hidden" onclick="ShowDiv('MyDiv','fade')">Agree policy</a> &nbsp;&nbsp; &nbsp;&nbsp; <a href="forgetpassword.aspx"  target="rightFrame">*Forget password</a> </li>
   
    </ul>  
    </div>   
    </div>  
    
    <div class="loginbm">Copyright &copy;  All Rights Reserved.  &nbsp;&nbsp;&nbsp;&nbsp;</div>

        <div id="MyDiv" class="white_content">
        <div style="text-align: right; cursor: default; height: 40px;" id="move">
            <span style="font-size: 16px;" onclick="CloseDiv('MyDiv','fade')">&nbsp;X&nbsp;</span>
        </div>
        <span style="font-size:25px;color:#467886;">Default policy</span>
        <br>
        <br>
        <span style="font-size:12px;">You must read and agree to the Privacy Policy in order to proceed</span>
        <br>
        <br>
        <span style="font-size:15px;">Any information collected by us, relating to an identifiable person, shall be used only in accordance with theprocedures and for the purposes that are here acknowledged to the data subject and where the latter, as requiredby law, has expressely consented.</span>
        <br>
        <br>
        <input type="checkbox" checked="checked"/> <span style="font-size:12px;">I accept the terms of the privacy policy (Required)</span>
        <br>
        <br>
        <div style="text-align: right; cursor: default; height: 40px;" >
            <%--<span onclick="CloseDiv('MyDiv','fade')" style="font-size: 18px;">&nbsp;&nbsp;&nbsp;&nbsp;I DON'T AGREE&nbsp;&nbsp;&nbsp;&nbsp;</span>--%>
            <asp:LinkButton ID="lkDontAgress" OnClick="lkDontAgress_Click" style="font-size: 18px;" Text="&nbsp;&nbsp;&nbsp;&nbsp;I DON'T AGREE&nbsp;&nbsp;&nbsp;&nbsp;" runat="server"></asp:LinkButton>
             <a href="main.aspx" style="font-size: 18px;;color:green">&nbsp;&nbsp;&nbsp;&nbsp;I AGREE&nbsp;&nbsp;&nbsp;&nbsp;</a>
        </div>
        </div>

    </form>
</body>
</html>
