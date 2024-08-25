<%@ Page Language="C#" AutoEventWireup="true" CodeFile="role_edit.aspx.cs" Inherits="sysmanager_role_edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>编辑角色权限设置</title>
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
        //是否启用权限
        if ($("#ddlRoleType").find("option:selected").attr("value") == 1) {
            $(".border-table").find("input[type='checkbox']").prop("disabled", true);
        }
        $("#ddlRoleType").change(function () {
            if ($(this).find("option:selected").attr("value") == 1) {
                $(".border-table").find("input[type='checkbox']").prop("checked", false);
                $(".border-table").find("input[type='checkbox']").prop("disabled", true);
            } else {
                $(".border-table").find("input[type='checkbox']").prop("disabled", false);
            }
        });
        //权限全选
        $("input[name='checkAll']").click(function () {
            if ($(this).prop("checked") == true) {
                $(this).parent().siblings("td").find("input[type='checkbox']").prop("checked", true);
            } else {
                $(this).parent().siblings("td").find("input[type='checkbox']").prop("checked", false);
            }
        });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">Home</a></li>
    <li><a href="role_list.aspx">Security Setup</a></li>
    <li><a href="#">Security Setup</a></li>
    </ul>
    </div>
    
    <div class="formbody">   
    <div class="formtitle"><span>Security Setup</span></div>
    <!--角色权限信息-->
<div class="tab-content">
   <dl>
    <dt>Role</dt>
   <dd><asp:Literal ID="Litrole_name" runat="server"></asp:Literal></dd>
  </dl>
 <dl>
    <dt>Security</dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
        <thead>
          <tr>
            <th align="left">Navigation</th>
            <th width="10%"><a href="javascript:;" onclick="checkAll(this);">Select ALL</a></th>
          </tr>
        </thead>
        <tbody>
          <asp:Repeater ID="rptList" runat="server" onitemdatabound="rptList_ItemDataBound">
          <ItemTemplate>
          <tr>
            <td style="white-space:nowrap;word-break:break-all;overflow:hidden;">
              <asp:HiddenField ID="hidLayer" Value='<%#Eval("parent_id") %>' runat="server" />
              <asp:Literal ID="LitFirst" runat="server"></asp:Literal>
              <%#Eval("title")%>
            </td>
            <td align="center"> <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
                <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /> </td>
          </tr>
          </ItemTemplate>
          </asp:Repeater>
        </tbody>
      </table>
    </dd>
  </dl>
</div>
<!--/角色权限信息-->    
    </div>

    <!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn" onclick="btnSubmit_Click"  />
    <input name="btnReturn" type="button" value="Back" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->

    
    </form>
</body>
</html>
