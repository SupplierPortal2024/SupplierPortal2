<%@ Page Language="C#" AutoEventWireup="true" CodeFile="purchase_request_edit3.aspx.cs" Inherits="purchase_purchase_request_edit3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>Reply RFQ</title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<style>
    .img-hover-effect:hover {
        transform: scale(2.5); /* 放大10% */
        transition: transform 0.3s ease; /* 动画过渡效果 */
    }
</style>
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
    function CalcAmount() {
        var repeaterId = '<%=rptVendorPriceList.ClientID %>';//Repeater的客户端ID
        var rows = <%=rptVendorPriceList.Items.Count%>;//Repeater的行数
        for (var i = 0; i < rows; i++) {
            if (document.getElementById(repeaterId + "_ctl" + getrownumber(i + 1) + "_txtUnitPrice").value != ''
                && document.getElementById(repeaterId + "_ctl" + getrownumber(i + 1) + "_txtUnitPrice").value != '0'
                && document.getElementById(repeaterId + "_ctl" + getrownumber(i + 1) + "_txtQuantity").value != ''
                && document.getElementById(repeaterId + "_ctl" + getrownumber(i + 1) + "_txtQuantity").value != '0') {
                
                document.getElementById(repeaterId + "_ctl" + getrownumber(i + 1) + "_lbAmount").innerHTML =
                    formatNumber(document.getElementById(repeaterId + "_ctl" + getrownumber(i + 1) + "_txtQuantity").value.replace(",", "") *
                        Math.floor(document.getElementById(repeaterId + "_ctl" + getrownumber(i + 1) + "_txtUnitPrice").value.replace(",", "") * 100000) / 100000);
            }

        }

        function getrownumber(i) {
            if (i > 10) {
                return i + (1-1);
            }
            else {
                return '0' + (i-1);
            }
        }
    }

    function addQianFenWei(txtBox) {
        txtBox.value = commafy(String(Math.floor(txtBox.value * 100000) / 100000));
    }
    function removeQianFenWei(txtBox) {
        txtBox.value = txtBox.value.replace(/,/g, ""); //如果是replace(',','')是只替换第一个 
    }
    function commafy(n) {
        var re = /\d{1,3}(?=(\d{3})+$)/g; //匹配1到3个数字后面跟3个数字，但不含最后的3个数字。 
        var n1 = n.replace(/^(\d+)((\.\d+)?)$/, function (s, s1, s2) { return s1.replace(re, "$&,") + s2; });
        return n1 ;
    }


    function formatNumber(num) {
        return num.toLocaleString('en-US', {
            minimumFractionDigits: 5,
            maximumFractionDigits: 5
        });
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>Position：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">Supplier</a></li>
    <li><a href="purchase_request2.aspx">Tender/RFQ</a></li>
    <li><a href="#">Reply RFQ</a></li>
    </ul>
    </div>

    <div class="formbody">   
    <div class="formtitle"><span>Reply RFQ</span></div>
    <!--/商品信息-->
<div class="tab-content">
   <dl>
    <dt>RFQ Number</dt>
     <dd><asp:Literal ID="litRFQNum" runat="server"></asp:Literal>
     </dd>
   </dl>

   <dl>
    <dt>RFQ Date</dt>
     <dd><asp:Literal ID="litRFQDate" runat="server"></asp:Literal>
     </dd>
   </dl>
   
    <dl>
    <dt>RFQ Due Date</dt>
     <dd>   <asp:Literal ID="litRFQDueDate" runat="server"></asp:Literal>
     </dd>
   </dl>
    
    <dl>
    <dt>RFQ Due Time</dt>
     <dd><asp:Literal ID="litRFQDueTime" runat="server"></asp:Literal>
     </dd>
   </dl>

    <dl>
    <dt>Subject</dt>
     <dd><asp:Literal ID="litSubject" runat="server"></asp:Literal>
     </dd>
   </dl>

    <dl>
    <dt>Remark</dt>
     <dd><asp:Literal ID="litRemark" runat="server"></asp:Literal>
     </dd>
   </dl>
    <dl>
    <dt>Status</dt>
     <dd><asp:Literal ID="litStatus" runat="server"></asp:Literal>
     </dd>
   </dl>

    <dl>
    <dt>PO Terms & Conditions</dt>
    <dd>
        <a href="../tools/downloadfile.aspx?fileName=../upload/files/TermsOfUserForJCKSCSupplierPortal.pdf" style="color:#467886;" >Download</a>
    </dd>
  </dl>
   

     <dl>
    <dt>RFQ Attachment</dt>
    <dd>
        <asp:Button ID="btnEpicorAttachmentDownload1" runat="server" Text="Download" CssClass="btn" onclick="btnEpicorAttachmentDownload1_Click" Visible="false"  />
        <asp:Label ID="lbEpicorAttachment1" runat="server" Visible="false" ></asp:Label>
        <asp:HiddenField ID="hdEpicorAttachment1" Value='<%# Eval("ID")%>' runat="server" />
    </dd>
    <dd>
        <asp:Button ID="btnEpicorAttachmentDownload2" runat="server" Text="Download" CssClass="btn" onclick="btnEpicorAttachmentDownload2_Click" Visible="false" />
        <asp:Label ID="lbEpicorAttachment2" runat="server" Visible="false" ></asp:Label>
        <asp:HiddenField ID="hdEpicorAttachment2" Value='<%# Eval("ID")%>' runat="server" />
    </dd>
    <dd>
        <asp:Button ID="btnEpicorAttachmentDownload3" runat="server" Text="Download" CssClass="btn" onclick="btnEpicorAttachmentDownload3_Click" Visible="false" />
        <asp:Label ID="lbEpicorAttachment3" runat="server" Visible="false" ></asp:Label>
        <asp:HiddenField ID="hdEpicorAttachment3" Value='<%# Eval("ID")%>' runat="server" />
    </dd>
  </dl>

 <dl >
    <dt></dt>
    <dd>
        <table width="80%" border="0" align="center" cellpadding="8" cellspacing="0" class="cart_table">
          <tr> 
           <th width="5%" align="left">Seq</th>
           <th width="40%" align="left">Questions</th>
 
           <th width="45%" align="left">Answer</th>
           <%--<th width="80" align="left">Operate</th>--%>
          </tr>
            <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate> 
                  <tr>
                    <td ><%# Eval("UD34_RFQQNA_SeqNum_c")%></td> 
                    <td ><%# Eval("UD34_RFQQNA_Question_c")%></td>
                    <td><asp:TextBox ID="txtRFQQNAAnswer" Enabled="true" Width="666" runat="server"   ReadOnly='<%# this.rfqstatus =="1" %>' MaxLength="500"  Text='<%# Eval("UD34_RFQQNA_Answer_c")%>' CssClass="input" />
                        <asp:HiddenField ID="hdID" Value='<%# Eval("ID")%>' runat="server" />
                        <asp:HiddenField ID="hdSeq" Value='<%# Eval("UD34_RFQQNA_SeqNum_c")%>' runat="server" />
                        <%--<asp:LinkButton runat="server" ID="btnUpdateQuestion2" class="btn green" CommandArgument='<%# Eval("ID")%>' CommandName="Update" Text="Update"></asp:LinkButton>--%>
                    </td>
                    <%--<td ><asp:Button ID="btnUpdateQuestion" CommandArgument='<%# Eval("ID")%>'  runat="server" Text="Update " onclick="btnUpdateQuestion_Click"  class="btn green"  Width="80" />
                    </td>--%>
                  </tr>
               </ItemTemplate>
            </asp:Repeater> 
     
    	    </table>
    </dd>
  </dl>

  <dl >
    <dt></dt>
    <dd>
        <table width="80%" border="0" align="center" cellpadding="8" cellspacing="0" class="cart_table">
          <tr> 
           <th width="50" align="left">Seq</th>
           <th width="150" align="left">Part Class</th>
           <th width="150" align="left">Part Number</th>
           <th width="150" align="left">Description</th>
           <th width="150" align="left">Photo</th>
              
           <th width="30" align="left">Qty</th>
           <th width="150" align="left">Unit</th>
            <th width="150" align="left">Est. Delivery<BR>Date</th>
            <th width="150" align="left">Unit Price<BR>(<asp:Label ID="lbUnitPriceCurrency" Text="" runat="server"></asp:Label>)</th>
            <th width="50" align="left">Amount<BR>(<asp:Label ID="lbAmountCurrency" Text="" runat="server"></asp:Label>)</th>
            <th width="150" align="left">Remark</th>
            <%--<th width="50" align="left">Operate</th>--%>
          </tr>
            <asp:Repeater ID="rptVendorPriceList" runat="server">
            <ItemTemplate> 
                  <tr>
                    <td ><%# Eval("UD37_RFQVP_RFQLine_c")%></td> 
                    <td ><%# Eval("PartClass_Description")%></td>
                    <td ><%# Eval("UD37_RFQVP_PartNum_c")%></td>    
                    <td ><%# Eval("UD37_RFQVP_PartDesc_c")%></td> 
                    <td ><img width="200" style='height: auto;visibility:<%# Eval("ImageContent").ToString()!="" ? "inherit" : "hidden"%>' class="img-hover-effect" src='<%# "data:image/jpeg;base64,"+ Eval("ImageContent")%>'  /></td> 

                    <td style="text-align:right"><%# Convert.ToDouble(Eval("UD37_RFQVP_Qty_c")).ToString("N5") %><asp:TextBox ID="txtQuantity" Width="0" runat="server" Text='<%# MyConvert(Eval("UD37_RFQVP_Qty_c"))%>' /></td>
                    <td ><%# Eval("UD37_RFQVP_PUM_c")%></td>   
                    <td ><%# (Eval("RFQItem_DueDate_c")==null || Eval("RFQItem_DueDate_c")=="")? "" : Convert.ToDateTime(Eval("RFQItem_DueDate_c").ToString()).ToShortDateString()%></td> 
                    <td><asp:TextBox ID="txtUnitPrice" ReadOnly ='<%# this.rfqstatus =="1" %>'  Width="80" runat="server"  Text='<%# Eval("UD37_RFQVP_OfferedPrice_c").ToString()=="" ? "0" : (Convert.ToDouble(AesEncryption.Decrypt(Eval("UD37_RFQVP_OfferedPrice_c").ToString()))).ToString("N5") %>' CssClass="input small" onkeyup="removeQianFenWei(this);clearNoNum(this)" onblur="CalcAmount();addQianFenWei(this);"  onfocus="removeQianFenWei(this)"   /></td> 
                   <td style="text-align:right"><asp:Label ID="lbAmount" Text='<%# (Convert.ToDouble(Eval("UD37_RFQVP_Qty_c"))  *  (Eval("UD37_RFQVP_OfferedPrice_c").ToString()=="" ? 0 : Convert.ToDouble(AesEncryption.Decrypt(Eval("UD37_RFQVP_OfferedPrice_c").ToString())))).ToString("N5") %>' runat="server"></asp:Label> </td>
                   <td> <asp:TextBox ID="txtRemark" Enabled="true" ReadOnly ='<%# this.rfqstatus =="1" %>'  MaxLength="300" Width="200" runat="server"  Text='<%# Eval("UD37_RFQVP_Remark_c")%>' CssClass="input" />
                       <asp:HiddenField ID="hdID" Value='<%# Eval("ID")%>' runat="server" />
                       <asp:HiddenField ID="hdSeq" Value='<%# Eval("UD37_RFQVP_RFQLine_c")%>' runat="server" />
                   </td>
                  <%-- <td >
                       <asp:Button ID="btnUpdateVendorPrice" CommandArgument='<%# Eval("ID")%>'  runat="server" Text="Update " onclick="btnUpdateVendorPrice_Click"  class="btn green"  Width="80" />
                   </td> --%> 
                  </tr>
               </ItemTemplate>
            </asp:Repeater> 
     
    	    </table>
    </dd>
  </dl>

    <dl>
    <dt><%--<asp:Label  ID="Label1" runat="server" Text="报价附档" class="btn"/>--%>Attachment</dt>
    <dd>
        <asp:FileUpload ID="FileReplyRFQ1" runat="server" CssClass="input date"  /><asp:HiddenField ID="txtReplyRFQ1Name" runat="server" />
           <%--<% if (modelRFQAttachment!=null && modelRFQAttachment.Attachment1FileName != null && modelRFQAttachment.Attachment1FileName != "") {%>--%> 
           <%--<img width="20" src="../images/attachment.gif" /><a href="../tools/downloadfile.aspx?fileName=../upload/files/<%=modelRFQHead.Attachment1%>" ><%=modelRFQHead.Attachment1%></a>--%>
            <asp:Button ID="btnDownLoadFile1" runat="server" Text="Download" CssClass="btn" Visible="false" onclick="btnDownload1_Click"  />
            <asp:ImageButton ImageUrl="~/images/del.png" ID="btnAttachment1Delete" Visible="false" style="vertical-align:middle" Width="25" Height="25" OnClick="btnAttachment1Delete_Click" runat="server" />
            <asp:Label ID="lbPassowrd1" runat="server" Visible="false" Text="Password:"></asp:Label> <asp:TextBox ID="txtAttachmentPassword" Enabled="true" Width="50" runat="server" Visible="false" TextMode="Password"  Text='' CssClass="input" /> <%--<font color="red">*</font>--%>
            <asp:Label ID="lbFile1Name" runat="server" Visible="false" ></asp:Label>
            
    </dd>
        <dd>
        <asp:FileUpload ID="FileReplyRFQ2" runat="server" CssClass="input date"  /><asp:HiddenField ID="txtReplyRFQ2Name" runat="server" />
           <%--<img width="20" src="../images/attachment.gif" /><a href="../tools/downloadfile.aspx?fileName=../upload/files/<%=modelRFQHead.Attachment2%>" ><%=modelRFQHead.Attachment2%></a>--%>
            <asp:Button ID="btnDownLoadFile2" runat="server" Text="Download" CssClass="btn" Visible="false" onclick="btnDownload2_Click"  />
            <asp:ImageButton ImageUrl="~/images/del.png" ID="btnAttachment2Delete" Visible="false" style="vertical-align:middle" Width="25" Height="25" OnClick="btnAttachment2Delete_Click" runat="server" />
            <asp:Label ID="lbPassowrd2" runat="server" Visible="false" Text="Password:"></asp:Label> <asp:TextBox ID="txtAttachment2Password" Enabled="true" Width="50" runat="server" Visible="false" TextMode="Password"  Text='' CssClass="input" /> 
            <asp:Label ID="lbFile2Name" runat="server" Visible="false" ></asp:Label>
            
    </dd>
        <dd>
        <asp:FileUpload ID="FileReplyRFQ3" runat="server" CssClass="input date"  /><asp:HiddenField ID="txtReplyRFQ3Name" runat="server" />
           <%--<img width="20" src="../images/attachment.gif" /><a href="../tools/downloadfile.aspx?fileName=../upload/files/<%=modelRFQHead.Attachment3%>" ><%=modelRFQHead.Attachment3%></a>--%>
            <asp:Button ID="btnDownLoadFile3" runat="server" Text="Download" CssClass="btn" Visible="false" onclick="btnDownload3_Click"  />
            <asp:ImageButton ImageUrl="~/images/del.png" ID="btnAttachment3Delete" Visible="false" style="vertical-align:middle" Width="25" Height="25" OnClick="btnAttachment3Delete_Click" runat="server" />
            <asp:Label ID="lbPassowrd3" runat="server" Visible="false" Text="Password:"></asp:Label> <asp:TextBox ID="txtAttachment3Password" Enabled="true" Width="50" runat="server" Visible="false"  TextMode="Password"  Text='' CssClass="input" />
            <asp:Label ID="lbFile3Name" runat="server" Visible="false" ></asp:Label>
            
    </dd>
  </dl>
</div>
<!--/商品信息-->    
</div>

    <!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn green" onclick="btnSave_Click"  />
      <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" onclick="btnSubmit_Click"  />
      <asp:Button ID="btnReject" runat="server" Text="Recall" CssClass="btn violet" onclick="btnReject_Click"  />
      <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn yellow" onclick="btnBack_Click"  />
    <%--<input name="btnReturn" type="button" value="Back" class="btn yellow" onclick="javascript:history.back(-1);" />--%>
  </div>
    
  <div class="clear"></div>
</div>
<!--/工具栏-->

    </form>
</body>
</html>


