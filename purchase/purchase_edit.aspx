<%@ Page Language="C#" AutoEventWireup="true" CodeFile="purchase_edit.aspx.cs" Inherits="purchase_purchase_edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑订单信息</title>
    <script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<script type="text/javascript" src="../js/datepicker/WdatePicker.js"></script>
<script type="text/javascript" charset="utf-8" src="../editor/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../editor/lang/zh_CN.js"></script>

<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    J(function () {
        J('#txtstop_time').calendar({ btnBar: true });
    });

    $(function () {
        $('#txtstop_time').calendar({ btnBar: true });
        $("#btnConfirm").click(function () { OrderConfirm(); });   //确认订单
        $("#btnComplete").click(function () { OrderComplete(); }); //完成订单
        $("#btnCancel").click(function () { OrderCancel(); });     //取消订单
        $("#btnPrint").click(function () { OrderPrint(); });       //打印订单

        $("#btnEditRemark").click(function () { EditOrderRemark(); });    //修改订单备注
        $("#btnEditPaymentFee").click(function () { EditPaymentFee(); });  //调价

    });

    //确认订单
    function OrderConfirm() {
        var dialog = $.dialog.confirm('确认订单后将无法修改金额，确认要继续吗？', function () {
            var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "order_confirm" };
            //发送AJAX请求
            sendAjaxUrl(dialog, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
            return false;
        });
    }

    //完成订单
    function OrderComplete() {
        var dialog = $.dialog.confirm('订单完成后，说明商品已经送到客户手里，订单完成，确认要继续吗？', function () {
            var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "order_complete" };
            //发送AJAX请求
            sendAjaxUrl(dialog, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
            return false;
        });
    }
    //取消订单
    function OrderCancel() {
        var dialog = $.dialog({
            title: '取消订单',
            content: '操作提示信息：<br />1、请与下单商家沟通；<br />2、取消订单后该订单不做财务收入统计；<br />3、请单击相应按钮继续下一步操作！',
            min: false,
            max: false,
            lock: true,
            icon: 'confirm.gif',
            button: [{
                name: '确认取消',
                callback: function () {
                    var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "order_cancel", "check_revert": 0 };
                    //发送AJAX请求
                    sendAjaxUrl(dialog, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
                    return false;
                }
            }, {
                name: '关闭'
            }]
        });

    }
 
    //打印订单
    function OrderPrint() {
        var dialog = $.dialog({
            title: '打印订单',
            content: 'url:../dialog/dialog_print.aspx?order_no=' + $("#spanOrderNo").text(),
            min: false,
            max: false,
            lock: true,
            width: 850//,
            //height: 500
        });
    }
   
    //修改订单备注
    function EditOrderRemark() {
        var dialog = $.dialog({
            title: '订单备注',
            content: '<textarea id="txtOrderRemark" name="txtOrderRemark" rows="2" cols="20" class="input">' + $("#divRemark").html() + '</textarea>',
            min: false,
            max: false,
            lock: true,
            ok: function () {
                //var remark2 = $("#txtOrderRemark", parent.document).val();
                var remark = $("#txtOrderRemark").val();
                if (remark == "") {
                    $.dialog.alert('对不起，请输入订单备注内容！' + remark, function () { }, dialog);
                    return false;
                }
                var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "edit_order_remark", "remark": remark };
                //发送AJAX请求
                sendAjaxUrl(dialog, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
                return false;
            },
            cancel: true
        });
    }
    //调价
    function EditPaymentFee() {
        var pop = $.dialog.prompt('请调整商品实际总金额',
            function (val) {
                if (!checkIsMoney(val)) {
                    $.dialog.alert('对不起，请输入正确的商品实际总金额！', function () { }, pop);
                    return false;
                }
                var postData = { "order_no": $("#spanOrderNo").text(), "edit_type": "edit_payment_fee", "payment_fee": val };
                //发送AJAX请求
                sendAjaxUrl(pop, postData, "../tools/admin_ajax.ashx?action=edit_order_status");
                return false;
            },
            $("#spanPaymentFeeValue").text()
        );
    }

 
    //=================================工具类的JS函数====================================
    //检查是否货币格式
    function checkIsMoney(val) {
        var regtxt = /^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/;
        if (!regtxt.test(val)) {
            return false;
        }
        return true;
    }
    //发送AJAX请求
    function sendAjaxUrl(winObj, postData, sendUrl) {
        $.ajax({
            type: "post",
            url: sendUrl,
            data: postData,
            dataType: "json",
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $.dialog.alert('尝试发送失败，错误信息：' + errorThrown, function () { }, winObj);
            },
            success: function (data, textStatus) {
                if (data.status == 1) {
                    winObj.close();
                    $.dialog.tips(data.msg, 2, '32X32/succ.png', function () { location.reload(); }); //刷新页面
                } else {
                    $.dialog.alert('错误提示：' + data.msg, function () { }, winObj);
                }
            }
        });
    }
</script>
</head>
<body>
<form id="form1" runat="server">
	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="order_list.aspx">采购订单</a></li>
    <li><a href="#">采购订单信息</a></li>
    </ul>
    </div>

    <div class="formbody">   
    <div class="formtitle"><span>采购订单详细信息</span></div>
    <!--/订单详细信息-->
<div class="tab-content2">
  <dl>
    <dd style="margin-left:50px;text-align:center;">
      <div class="order-flow" style="width:560px">
        
        <div class="order-flow-left">
          <a class="order-flow-input">批核</a>
           <%if (model.Approve == true)
          { %>
          <span><p class="name">订单已批核</p><p><%=string.Format("{0:yyyy-MM-dd HH:mm:ss}",model.CreateDate)%></p></span>
           <%}
          else 
          { %>
            <span><p class="name">订单未批核</p></span>
           <%} %>
        </div>
        <div class="order-flow-wait">
           <a class="order-flow-input">确认</a>
        <%if (model.Confirmed  == false)
          { %>
           <span><p class="name">等待确认</p></span>
        <% }
          else 
        { %>
          <span><p class="name">已确认</p><p><%=string.Format("{0:yyyy-MM-dd HH:mm:ss}",model.ConfirmDate)%></p></span>
        <%} %>
      </div>
       <div class="order-flow-right-wait">
           <a class="order-flow-input">完成</a>
           <span><p class="name">订单完成</p></span>
         </div>
       </div>
    </dd>
  </dl>
  <dl>
    <dt>采购订单号：</dt>
    <dd><span id="spanOrderNo"><asp:Literal ID="litOrderNo" runat="server"></asp:Literal></span></dd>
  </dl>
    <dl>
    <dt>订单日期：</dt>
    <dd><span id="spanOrderDate"><asp:Literal ID="litOrderDate" runat="server"></asp:Literal></span></dd>
  </dl>
    <dl id="QuoteInfo" runat="server" visible="true">
        <dt></dt>
        <dd>
            <asp:Label  ID="Label1" runat="server" Text="附档" class="btn"/>
            <asp:FileUpload ID="FileUploadQuote" runat="server" CssClass="input date"  /><asp:HiddenField ID="txtQuoteFile1Name" runat="server" />
        
            <asp:Label  ID="Label2" runat="server" Text="备注" class="btn"/> <asp:Textbox ID="txtQuoteRemark" runat="server" Width="400"  CssClass="input small" Text=''></asp:Textbox>
        </dd>
      </dl>
      <dl>
    
  </dl>
  <asp:Repeater ID="rptList" runat="server">
  <HeaderTemplate>
  <dl>
    <dt>采购列表</dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
        <thead>
          <tr>
            <th width="12%">商品编码</th>    
            <%--<th width="12%">商品类别</th>--%>
            <th>商品名称</th>
            <th>到期日</th>
            <th width="12%">单价</th>
            <th width="10%">数量</th>
            <th width="12%">金额合计</th>
             <th>备注</th>
          </tr>
        </thead>
        <tbody>
        </HeaderTemplate>
        <ItemTemplate>
          <tr class="td_c">
            <td><%#Eval("PartNUM")%></td>    
            <%--<td><%#new ps_product_category().GetTitle(Convert.ToInt32(Eval("product_category_id")))%></td>--%>
            <td><%#Eval("LineDesc")%></td>
            <td><%#(Convert.ToDateTime(Eval("DueDate"))).ToShortDateString()%></td>
            <%--<td style="text-align:left;white-space:normal;"><%#Eval("goods_title")%></td>--%>
            <td><%#(Convert.ToDecimal(Eval("UnitCost"))).ToString("f2")%></td>
            <td><%#(Convert.ToDecimal(Eval("OrderQty"))).ToString("f2")%>&nbsp;&nbsp;<%# Eval("PUM")%></td>
            <td><%#(Convert.ToDecimal(Eval("UnitCost")) * Convert.ToInt32(Eval("OrderQty"))).ToString("f2")%></td>
            <td><%#Eval("CommentText")%></td>
          </tr>
          </ItemTemplate>
          <FooterTemplate>
        </tbody>
      </table>
    </dd>
  </dl>
  </FooterTemplate>
  </asp:Repeater>
  <dl>
    <dt>收货信息</dt>
    <dd>
      <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
        
        <tr>
          <th>送货地址</th>
          <td> <span id="spanAddress"><asp:Label ID="contact_address" runat="server" /></span></td>
        </tr>
        <tr>
          <th>联系人</th>
          <td><span id="spanPostCode"><asp:Label ID="contact_name" runat="server" /></span></td>
        </tr>
        <tr>
          <th>联系电话</th>
          <td><span id="spanTelphone"><asp:Label ID="contact_tel" runat="server" /></span></td>
        
        <tr>
          <th>订单备注</th>
          <td>
            <div class="position">
              <div id="divRemark"><%=model.CommentText %></div>
              <input id="btnEditRemark" runat="server" visible="false" type="button" class="ibtn" value="修改" />
            </div>
          </td>
        </tr>

       <tr>
          <th>订单交期</th>
          <td><span class="single-select">
              <asp:TextBox ID="txtConfirmDate" runat="server" CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s$|^\d{4}\-\d{1,2}\-\d{1,2}$/"  errormsg="请选择正确的日期" sucmsg=" "/>
              </span></td>
        </tr> 
        <tr>
          <th>供应商备注</th>
          <td><span class="single-select">
               <asp:TextBox ID="txtVendorRemark" class="input" runat="server" Height="84px" 
                          TextMode="MultiLine" Width="300px"></asp:TextBox>
              </span></td>
        </tr> 
      </table>
    </dd>
  </dl>
  

  
<!--/订单详细信息-->
    </div>

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="确认订单" CssClass="btn" onclick="btnSubmit_Click"  />
    <asp:Button ID="btnBack" runat="server" Text="返回上一页" class="btn yellow" onclick="btnBack_Click"  />
    <input id="btnReturn" style="visibility:hidden" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
    <input id="btnConfirm" runat="server" style="visibility:hidden" type="button" value="确认订单" class="btn" />
    <input id="btnComplete" style="visibility:hidden" runat="server" visible="false" type="button" value="完成订单" class="btn" />
    <input id="btnCancel" style="visibility:hidden" runat="server" visible="false" type="button" value="取消订单" class="btn green" />
    <input id="btnPrint" style="visibility:hidden" type="button" value="打印订单" class="btn violet" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->

    </form>
</body>
</html>
