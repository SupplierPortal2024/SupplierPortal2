<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vendor_edit.aspx.cs" Inherits="sysmanager_vendor_edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>Supplier Edit</title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/swfupload/swfupload.js"></script>
<script type="text/javascript" src="../js/swfupload/swfupload.queue.js"></script>
<script type="text/javascript" src="../js/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();

        //初始化上传控件
        $(".upload-img").each(function () {
            $(this).InitSWFUpload({ sendurl: "../tools/upload_ajax.ashx", flashurl: "../js/swfupload/swfupload.swf" });
        });
        //设置封面图片的样式
        $(".photo-list ul li .img-box img").each(function () {
            if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                $(this).parent().addClass("selected");
            }
        });
        //设置封面图片的样式
        $(".photo-list ul li .img-box img").each(function () {
            if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                $(this).parent().addClass("selected");
            }
        });
    });

</script>
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>Position：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">Home</a></li>
    <li><a href="depot_manager.aspx">Supplier</a></li>
    <li><a href="#">Edit</a></li>
    </ul>
    </div>

    <div class="formbody">   
    <div class="formtitle"><span>Vendor Edit</span></div>
    <!--/产品信息-->
    <div class="tab-content">
    
 
  

  <dl >
    <dt>Supplier ID</dt>
    <dd><asp:TextBox ID="txtSupplierID" runat="server"  MaxLength="200" CssClass="input normal" Enabled="false" Width="300"></asp:TextBox></dd>
 
  </dl>

   <dl >
    <dt>Supplier Name</dt>
    <dd><asp:TextBox ID="txtSupplierName" runat="server"  MaxLength="200" CssClass="input normal" datatype="*"  errormsg=""  Width="300"></asp:TextBox>
    <span class="Validform_checktip">*</span></dd>
  </dl>
        
   <dl >
    <dt>Currency</dt>
    <dd><asp:TextBox ID="txtCurrency" runat="server"  MaxLength="80" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>
    

  <dl >
    <dt>Terms</dt>
    <dd><asp:TextBox ID="txtTerms" runat="server"  MaxLength="80" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>
   <dl >
    <dt>Phone</dt>
    <dd><asp:TextBox ID="txtPhone" runat="server"  MaxLength="80" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>

    <dl >
    <dt>Fax</dt>
    <dd><asp:TextBox ID="txtFax" runat="server"  MaxLength="80" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>

   <dl >
    <dt>Email</dt>
    <dd><asp:TextBox ID="txtEmail" runat="server"  MaxLength="80" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>

  <dl >
    <dt>Address</dt>
    <dd><asp:TextBox ID="txtAddress1" runat="server"  MaxLength="80" CssClass="input normal" Width="300"></asp:TextBox></dd>
    <dd><asp:TextBox ID="txtAddress2" runat="server"  MaxLength="80" CssClass="input normal" Width="300"></asp:TextBox></dd>
    <dd><asp:TextBox ID="txtAddress3" runat="server"  MaxLength="80" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>

    




<dl >
    <dt>Inactive</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsActive" runat="server" Checked="True" />
      </div>
    </dd>
  </dl>


  <dl id="vendorcnt" runat="server" visible="true">
    <dt>Contract</dt>
     <dd>       
    <table width="660" border="0" align="center" cellpadding="9" cellspacing="0" class="cart_table">
     
      <tr> 
       <th width="100" align="left">Number</th>
       <th width="100" align="left">Name</th>
       <th width="100" align="left">Email</th>
        <th width="100" align="left">Phone</th>
        <th width="100" align="left">Fax</th>
        <th width="100" align="left">Operate</th>
      </tr>
       <tr> 
       <th width="200" align="left"><asp:TextBox ID="txtContractNumber"  CssClass="input normal" Enabled="false" oninput="SelCus(this)"   runat="server" Width="80" ></asp:TextBox></th>
       <th width="100" align="left"><asp:TextBox ID="txtContractName"  CssClass="input normal" Enabled="false" runat="server" Width="100" ></asp:TextBox><asp:TextBox ID="txtCustID" runat="server" Width="0" ></asp:TextBox></th>
        <th width="100" align="left"><asp:TextBox ID="txtContractEmail"  CssClass="input normal" Enabled="false" runat="server" Width="100" ></asp:TextBox></th>
        <th width="100" align="left"><asp:TextBox ID="txtContractPhone"  CssClass="input normal" Enabled="false" runat="server" Width="100" ></asp:TextBox></th>
        <th width="100" align="left"><asp:TextBox ID="txtContractFax"  CssClass="input normal" Enabled="false" runat="server" Width="100" ></asp:TextBox></th>
           
       <th width="100" align="center" ><asp:Button ID="btnAddCust" runat="server" Text="Add Contract " class="btn"    Width="100" /></th>  <%--onclick="btnAddCust_Click"--%>
      </tr>
      <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate> 
            <tr>
                <td width="100" ><%# Eval("connum")%></td>	
                <td width="100"><%# Eval("name")%></td>	
                <td width="100"><%# Eval("EmailAddress")%></td>	
                <td width="100"><%# Eval("PhoneNum")%></td>	
                <td width="100"><%# Eval("FaxNum")%></td>	<%--onclick="lbtnDelCust_Click" --%>
                <td ><asp:LinkButton ID="lbtnDelCust" runat="server" class="btn"  Width="30"  CommandArgument='<%# Eval("connum")%>'  OnClientClick="return confirm('Confirm to Delete？')"   ><font color ="red">删除</font></asp:LinkButton></td>
            </tr>
           </ItemTemplate>
        </asp:Repeater>
   </table>
    </dd>
    </dl>
 
</div>
       
    <!--/产品信息-->    
    </div>

    <!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="Commit" CssClass="btn" onclick="btnSubmit_Click"  />
    <input name="btnReturn" type="button" value="Back" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->

    </form>
</body>
</html>
