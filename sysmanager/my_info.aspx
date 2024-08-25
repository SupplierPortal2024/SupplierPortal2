<%@ Page Language="C#" AutoEventWireup="true" CodeFile="my_info.aspx.cs" Inherits="sysmanager_my_info" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>我的信息</title>
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
	<div class="place">
    <span>Position：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">Home</a></li>
    <li><a href="#">My info</a></li>
    </ul>
    </div>

    <div class="formbody">   
    <div class="formtitle"><span>My info</span></div>

<!--/我的信息-->
<div class="tab-content">
 <dl>  
  <dl>  
    <dt>User Name</dt>
    <dd><asp:Literal ID="Litreal_name" runat="server"></asp:Literal></dd>
  </dl> 

    <dl>
    <dt>Account</dt>
    <dd><asp:Literal ID="Lituser_name" runat="server"></asp:Literal> </dd>
  </dl>
    <asp:Panel ID="plPassword" Visible="false" runat="server">
        <dl>
        <dt>Current password</dt>
        <dd><asp:TextBox ID="txtOldPassword" runat="server" CssClass="input normal" TextMode="Password" datatype="*4-20" nullmsg="Please input Current password"  sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
      </dl>

      <dl>
        <dt>New password</dt>
        <dd><asp:TextBox ID="txtPassword" runat="server" CssClass="input normal" TextMode="Password" datatype="*6-20" nullmsg="Please input new password" errormsg="password length is between 6-20" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
      </dl>

      <dl>
        <dt>Confirm new passowrd</dt>
        <dd><asp:TextBox ID="txtPassword1" runat="server" CssClass="input normal" TextMode="Password" datatype="*" recheck="txtPassword" nullmsg="Please input new password again" errormsg="New password don't match" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
      </dl>

   </asp:Panel>
   
    <dl id="bmxx" runat="server" style="visibility:hidden">
    <dt>所属公司</dt>
    <dd><asp:Literal ID="Litdepot_category_name" runat="server"></asp:Literal></dd>
  </dl>
  <div id="mdxx" runat="server" visible="false">

    <dl>
    <dt>Vendor</dt>
    <dd><asp:Literal ID="Litdepotname" runat="server"></asp:Literal></dd>
  </dl> 

    <dl>
    <dt>Contract Name</dt>
    <dd><asp:TextBox ID="txtcontact_name" runat="server" CssClass="input normal" ></asp:TextBox><asp:Literal ID="Litcontact_name" Visible="false" runat="server"></asp:Literal></dd>
  </dl>
    <dl>
    <dt>Email</dt>
    <dd><asp:TextBox ID="txtEmail" runat="server" CssClass="input normal" ></asp:TextBox></dd>
  </dl>
    <dl id="tel" runat="server" >
    <dt>Tel</dt>
    <dd><asp:TextBox ID="txtcontact_tel" runat="server" CssClass="input normal" ></asp:TextBox><asp:Literal ID="Litcontact_tel"  Visible="false" runat="server"></asp:Literal></dd>
  </dl>

    <dl style="visibility:hidden">
    <dt>经销商地址</dt>
    <dd><asp:TextBox ID="txtcontact_address" runat="server" CssClass="input normal" ></asp:TextBox><asp:Literal ID="Litdepot_id" runat="server" Visible="false"></asp:Literal></dd>
  </dl>
 </div>
     <dt>&nbsp;</dt>
     <div class="btn-list">
    
    <asp:Button ID="btnSubmit" runat="server" Visible="false" Text="Submit" CssClass="btn" onclick="btnSubmit_Click"  />
    <asp:Button ID="btnChangePassword" runat="server" Text="Change password" CssClass="btn" onclick="btnChangePassword_Click"  />
    <input name="btnReturn" style="visibility:hidden" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
</div>
<!--/我的信息-->  
</div>

    <!--工具栏-->
<div class="page-footer">
  
  <div class="clear"></div>
</div>
<!--/工具栏-->

    </form>
</body>
</html>
