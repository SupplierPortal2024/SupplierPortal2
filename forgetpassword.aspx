<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgetpassword.aspx.cs" Inherits="forgetpassword" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>Forget password
   </title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>
</head>
<body>
    <form id="form1" runat="server">


    <div class="formbody">   
    <div class="formtitle"><span>Forget password</span></div>

<!--/我的信息-->
<div class="tab-content">
  <dl>  
    <dt>User Name</dt>
    <dd><asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/"  nullmsg="Please input user name"  sucmsg=" " ></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl> 
    
   
   <dl>
    <dt>Email</dt>
    <dd><asp:TextBox ID="txtEmail" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9_\.]+@[a-zA-Z0-9-]+[\.a-zA-Z]+$/"  nullmsg="Please input email"  sucmsg=" " ></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>

     <dl>
    <dt></dt>
    <dd>
    <div class="btn-list">   
    <asp:Button ID="btnSubmit" runat="server" Visible="true" Text="Send Email" CssClass="btn" onclick="btnSubmit_Click"  />
    <asp:Button ID="btnChangePassword" Visible="false" runat="server" Text="Change password2" CssClass="btn" onclick="btnChangePassword_Click"  />
    <input name="btnReturn" type="button" value="Back" class="btn yellow" onclick="javascript:window.location.href='index.aspx';" />
    </div>
    </dd>
    </dl>
     
 </div>
  
    
  

</div>

  


    </form>
</body>
</html>
