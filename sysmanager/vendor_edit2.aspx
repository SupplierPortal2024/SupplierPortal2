<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vendor_edit2.aspx.cs" Inherits="sysmanager_vendor_edit2" %>
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
<script type="text/javascript" src="../js/lhgcalendar.min.js"></script>
<script type="text/javascript" src="../js/lhgcore.min.js"></script>
<script type="text/javascript" src="../js/lhgcalendar.min.js"></script>
<script type="text/javascript">
    J(function () {
        J('#txtBRExpireDate').calendar({ btnBar: true });
    });
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
    <li><a href="vendor_list2.aspx">Supplier</a></li>
    <li><a href="#">Edit</a></li>
    </ul>
    </div>

    <div class="formbody">   
    <div class="formtitle"><span>Supplier Edit</span></div>
    <div class="tab-content">
    
 
  

  <dl >
    <dt>Supplier ID</dt>
    <dd><asp:TextBox ID="txtSupplierID" runat="server"  MaxLength="8" CssClass="input normal" Enabled="false" Width="300"></asp:TextBox></dd>
 
  </dl>

   <dl >
    <dt>Supplier Name</dt>
    <dd><asp:TextBox ID="txtSupplierName" runat="server"  MaxLength="50" CssClass="input normal" Enabled="false" datatype="*"  errormsg=""  Width="300"></asp:TextBox></dd>
  </dl>

  <dl >
    <dt>Company Website</dt>
    <dd><asp:TextBox ID="txtCompanyWebsite" runat="server"  MaxLength="100" CssClass="input normal"  Width="300"></asp:TextBox></dd>
  </dl>
 <dl >
    <dt>Approved</dt>
    <dd><asp:Label ID="lbApprove" runat="server"></asp:Label></dd>
  </dl>
        
   <dl >
    <dt>Currency</dt>
    <dd>
        <span class="rule-single-select">
        <asp:DropDownList ID="ddlCurrency" Enabled="false"  runat="server" AutoPostBack="false">
            <asp:ListItem Value="" Selected="True">==Select Currency==</asp:ListItem>
          </asp:DropDownList>
        </span>
    </dd>
  </dl>
    

  <dl >
    <dt>Terms</dt>
    <dd><asp:TextBox ID="txtTerms" runat="server"  MaxLength="80" CssClass="input normal" Enabled="false" Width="300"></asp:TextBox></dd>
  </dl>
  <dl >
    <dt>BR Number</dt>
    <dd><asp:TextBox ID="txtBRNumber" runat="server"  MaxLength="100" CssClass="input normal" datatype="*"  errormsg=""   Width="300"></asp:TextBox><span class="Validform_checktip">*</span></dd>
  </dl>
  <dl >
    <dt>BR Expire Date</dt>
    <dd><input  type="text" class="timeinput" id="txtBRExpireDate" name="txtstart_time" readonly="readonly" runat="server" /><span class="Validform_checktip">*</span></dd>
  </dl>
  <dl >
    <dt>CR Number</dt>
    <dd><asp:TextBox ID="txtCRNumber" runat="server"  MaxLength="12" CssClass="input normal" datatype="*"  errormsg=""   Width="300"></asp:TextBox><span class="Validform_checktip">*</span></dd>
  </dl>
   <dl >
    <dt>Phone</dt>
    <dd><asp:TextBox ID="txtPhone" runat="server"  MaxLength="20" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>
   <dl >
    <dt>Fax</dt>
    <dd><asp:TextBox ID="txtFax" runat="server"  MaxLength="20" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>
    <dl >
    <dt>Email Address</dt>
    <dd><asp:TextBox ID="txtEmail" runat="server"  MaxLength="50" CssClass="input normal" datatype="*"  errormsg=""  Width="300"></asp:TextBox><span class="Validform_checktip">*</span></dd>
  </dl>

  <dl >
    <dt>Address</dt>
    <dd><asp:TextBox ID="txtAddress1" runat="server"  MaxLength="50" CssClass="input normal" Width="300"></asp:TextBox></dd>
    <dd><asp:TextBox ID="txtAddress2" runat="server"  MaxLength="50" CssClass="input normal" Width="300"></asp:TextBox></dd>
    <dd><asp:TextBox ID="txtAddress3" runat="server"  MaxLength="50" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>

   <dl>
    <dt>City</dt>
    <dd><asp:TextBox ID="txtCity" runat="server"  MaxLength="50" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>

   <dl >
    <dt>State/Prov</dt>
    <dd><asp:TextBox ID="txtState" runat="server"  MaxLength="50" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>

    <dl >
    <dt>Post Code</dt>
    <dd><asp:TextBox ID="txtPostCode" runat="server"  MaxLength="10" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>Country</dt>
    <dd>
        <span class="rule-single-select">
        <asp:DropDownList ID="ddlCountry"  runat="server" AutoPostBack="false">
            <asp:ListItem Value="" Selected="True">==Select Country==</asp:ListItem>
          </asp:DropDownList>
        </span>
    </dd>
  </dl>
  
   <dl >
    <dt>Bank Code</dt>
    <dd><asp:TextBox ID="txtBankCode" runat="server"  MaxLength="9" CssClass="input normal"  Width="300"></asp:TextBox></dd>
  </dl>
  <dl >
    <dt>Bank Name</dt>
    <dd><asp:TextBox ID="txtBankName" runat="server"  MaxLength="50" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>
   <dl >
    <dt>Payment Method</dt>
    <dd> <span class="rule-single-select">
        <asp:DropDownList ID="ddlPaymentMethod"  runat="server" AutoPostBack="false">
            <asp:ListItem Value="" Selected="True">==Select PaymentMethod==</asp:ListItem>
          </asp:DropDownList></dd>
  </dl>
    <dl >
    <dt>Bank Account Name</dt>
    <dd><asp:TextBox ID="txtBankAccountName" runat="server"  MaxLength="50" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>
  <dl >
    <dt>Bank Account Code</dt>
    <dd><asp:TextBox ID="txtBankAccountCode" runat="server"  MaxLength="34" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>
  <dl >
    <dt>Bank Country</dt>
    <dd>
        <span class="rule-single-select">
        <asp:DropDownList ID="ddlBankCountry"  runat="server" AutoPostBack="false">
          </asp:DropDownList>
        </span>
    </dd>
  </dl>
  <dl >
    <dt>IBAN/ABA/BSB Code</dt>
    <dd><asp:TextBox ID="txtIBANABABSBCode" runat="server"  MaxLength="34" CssClass="input normal" Width="300"></asp:TextBox></dd>
  </dl>
 <dl >
    <dt>Swift Code</dt>
    <dd><asp:TextBox ID="txtSwiftCode" runat="server"  MaxLength="11" CssClass="input normal"  Width="300"></asp:TextBox></dd>
  </dl>

  

    




<dl style="visibility:hidden">
    <dt>Inactive</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsActive" runat="server" Checked="True" />
      </div>
    </dd>
  </dl>


  <dl id="vendorcnt" runat="server" visible="true">
    <dt>Contact</dt>
     <dd>       
    <table width="660" border="0" align="center" cellpadding="9" cellspacing="0" class="cart_table">
     
      <tr> 
       <th width="100" align="left">Number</th>
       <th width="100" align="left">Name</th>
       <th width="100" align="left">Position</th>
        <th width="100" align="left">Phone</th>
        <th width="100" align="left">Cell Phone</th>
        <th width="100" align="left">Email</th>
        <th width="100" align="left">Contact<br>Send RFQ?</th>
        <th width="100" align="left">Contact<br>Send PO?</th>
        <th width="100" align="left">Primary<br>Contact?</th>
        <th width="100" align="left">Inactive</th>
        <th width="180" align="left">Operate</th>
      </tr>

       <tr> 
       <th width="200" align="left"><asp:TextBox ID="txtContactNumber"  CssClass="input normal" oninput="SelCus(this)" Enabled="false"  runat="server" Width="80" ></asp:TextBox></th>
       <th width="100" align="left"><asp:TextBox ID="txtContactName"  CssClass="input normal" runat="server"  Enabled="true" Width="100" MaxLength="50"  ></asp:TextBox></th>
       <th width="100" align="left"><asp:TextBox ID="txtContactFunc"  CssClass="input normal" runat="server"  Enabled="true" Width="100" MaxLength="50" ></asp:TextBox></th>
       
       <th width="100" align="left"><asp:TextBox ID="txtContactPhone"  CssClass="input normal" runat="server"  Enabled="true" Width="100" MaxLength="20"  ></asp:TextBox></th>
        <th width="100" align="left"><asp:TextBox ID="txtContactCellPhone"  CssClass="input normal"  Enabled="true" runat="server" Width="100"  MaxLength="20" ></asp:TextBox></th>
        <th width="100" align="left"><asp:TextBox ID="txtContactEmail"  CssClass="input normal" runat="server"  Enabled="true" Width="100" MaxLength="50" ></asp:TextBox></th>
        <th width="100" align="left"><asp:CheckBox ID="ckContactSendRFQ" runat="server"  Enabled="true" Width="100" ></asp:CheckBox></th>
        <th width="100" align="left"><asp:CheckBox ID="ckContactSendPO" runat="server" Enabled="true" Width="100" ></asp:CheckBox></th>
        <th width="100" align="left"><asp:CheckBox ID="ckPrimaryContact" runat="server" Enabled="true" Width="100" ></asp:CheckBox></th>
        <th width="100" align="left"><asp:CheckBox ID="ckInactive" runat="server" Enabled="true" Width="100" ></asp:CheckBox></th>
        <th width="180" align="center" ><asp:Button ID="btnSaveContact" runat="server" Text="Add" class="btn" Width="80" onclick="btnAddContact_Click"  /></th> 
      </tr>
      <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate> 
            <tr>
                <%--<td width="100" ><%# Eval("VendCnt_ConNum")%></td>	
                <td width="100"><%# Eval("VendCnt_Name")%></td>	
                <td width="100"><%# Eval("VendCnt_Func")%></td>	
                <td width="100"><%# Eval("VendCnt_PhoneNum")%></td>	
                <td width="100"><%# Eval("VendCnt_CellPhoneNum")%></td>	
                <td width="100"><%# Eval("VendCnt_EmailAddress")%></td>	
                <td width="100"><%# Eval("VendCnt_UD_RFQRecipent_c")%></td>
                <td width="100"><%# Eval("VendCnt_UD_PORecipient_c")%></td>
                <td width="100"><%# Eval("Calculated_PrimaryContact")%></td>
                <td ><asp:LinkButton ID="lbtnUpdateContact" runat="server" class="btn"  Width="30"  CommandArgument='<%# Eval("VendCnt_ConNum")%>'  onclick="lbtnUpdateContact_Click">Update</asp:LinkButton></td>--%>

                <th width="200" align="left"><asp:TextBox ID="txtContactNumber"  CssClass="input normal" oninput="SelCus(this)" Enabled="false" Text='<%# Eval("VendCnt_ConNum") %>'  runat="server" Width="80" ></asp:TextBox></th>
                <th width="100" align="left"><asp:TextBox ID="txtContactName"  CssClass="input normal" Text='<%# Eval("VendCnt_Name")%>' runat="server"  Enabled="true" Width="100" ></asp:TextBox></th>
                <th width="100" align="left"><asp:TextBox ID="txtContactFunc"  CssClass="input normal" Text='<%# Eval("VendCnt_Func")%>' runat="server"  Enabled="true" Width="100" ></asp:TextBox></th>
                <th width="100" align="left"><asp:TextBox ID="txtContactPhone"  CssClass="input normal" Text='<%# Eval("VendCnt_PhoneNum")%>' runat="server"  Enabled="true" Width="100" ></asp:TextBox></th>
                <th width="100" align="left"><asp:TextBox ID="txtContactCellPhone"  CssClass="input normal"  Text='<%# Eval("VendCnt_CellPhoneNum")%>' Enabled="true" runat="server" Width="100" ></asp:TextBox></th>
                <th width="100" align="left"><asp:TextBox ID="txtContactEmail"  CssClass="input normal" Text='<%# Eval("VendCnt_EmailAddress")%>' runat="server"  Enabled="true" Width="100" ></asp:TextBox></th>
                <th width="100" align="left"><asp:CheckBox ID="ckContactSendRFQ" runat="server"  Checked='<%# Eval("VendCnt_UD_RFQRecipent_c").ToString().Trim()=="True" ? true:false%>' Enabled="true" Width="100" ></asp:CheckBox></th>
                <th width="100" align="left"><asp:CheckBox ID="ckContactSendPO" runat="server" Checked='<%# Eval("VendCnt_UD_PORecipient_c").ToString().Trim()=="True" ? true:false%>' Enabled="true" Width="100" ></asp:CheckBox></th>
                <th width="100" align="left"><asp:CheckBox ID="ckPrimaryContact" runat="server" Checked='<%# Eval("Calculated_PrimaryContact").ToString().Trim()=="True" ? true:false %>' Enabled="true" Width="100" ></asp:CheckBox></th>
                <th width="100" align="left"><asp:CheckBox ID="ckInactive" runat="server" Checked='<%# Eval("VendCnt_Inactive").ToString().Trim()=="True" ? true:false %>' Enabled="true" Width="100" ></asp:CheckBox></th>   
                <th width="180" align="center"><div class="btn-list"><asp:Button ID="btnSaveContact" runat="server" Text="Update" class="btn" Width="80"  onclick="btnSaveContact_Click"  />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn violet" Width="80" CommandArgument='<%# Eval("VendCnt_ConNum") %>' onclick="btnDeleteContact_Click"  /></div>
                </th> 
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
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn green" onclick="btnSave_Click"  />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" onclick="btnSubmit_Click"  />
        <input name="btnReturn" type="button" value="Back" class="btn yellow" onclick="javascript:history.back(-1);" />
      </div>
      <div class="clear"></div>
    </div>
    <!--/工具栏-->

    </form>
</body>
</html>
