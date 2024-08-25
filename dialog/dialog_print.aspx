<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialog_print.aspx.cs" Inherits="dialog_dialog_print" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>打印订单窗口</title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript">
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: '确认打印',
        focus: true,
        callback: function () {
            printWin();
        }
    }, {
        name: '取消'
    });
    //打印方法
    function printWin() {
        var oWin = window.open("", "_blank");
        oWin.document.write(document.getElementById("content").innerHTML);
        oWin.focus();
        oWin.document.close();
        oWin.print()
        oWin.close()
    }
</script>
</head>

<body style="margin:0;">
<form id="form1" runat="server">
<div id="content">
<table width="1050" border="0" align="center" cellpadding="3" cellspacing="0" style="font-size:12px; font-family:'微软雅黑'; background:#fff;">
<tr>
  <td width="346" height="50" style="font-size:20px;">商品订单</td>
  <td width="216">订单号：<%=model.order_no%><br />
下单时间：<%= Convert.ToDateTime(model.add_time).ToString()%></td>
  <td width="220">操&nbsp; 作 人：<%= Session["RealName"].ToString()%><br />打印时间：<%=DateTime.Now%></td>
</tr>
<tr>
  <td colspan="3" style="padding:10px 0; border-top:1px solid #000;">
  <asp:Repeater ID="rptList" runat="server">
      <HeaderTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="5" style="font-size:12px; font-family:'微软雅黑'; background:#fff;">
          <tr>
           <%--<td width="10%" align="left" style="background:#ccc;">产品类别</td>--%>
            <td width="10%" align="left" style="background:#ccc;">商品名称</th>
            <td width="12%" style="background:#ccc;">规格型号</td>
            <td width="8%" style="background:#ccc;">产品型号</td>
            <td width="8%" style="background:#ccc;">颜色</td>
            <td width="4%" style="background:#ccc;">售价</td>
            <td width="4%" style="background:#ccc;">折扣%</td>  
            <td width="4%" style="background:#ccc;">数量</td>
            <td width="8%" style="background:#ccc;">定制<BR>规格</td>
            <td width="4%" style="background:#ccc;">折扣前<BR>金额</td>
            <td width="4%" style="background:#ccc;">实付<BR>金额</td>
            <td width="4%" style="background:#ccc;">折扣<BR>金额</td>
            <td width="10%" style="background:#ccc;">备注</td>
          </tr>
      </HeaderTemplate>
      <ItemTemplate>
          <tr>   
            <%--<td><%#new ps_product_category().GetTitle(Convert.ToInt32(Eval("product_category_id")))%></td>--%>
            <td style="text-align:left;white-space:normal;" width="100"><%#Eval("goods_title")%></td>
            <td style="text-align:left;white-space:normal;"><%#Eval("specification")%></td>
            <td style="text-align:left;white-space:normal;"><%#Eval("commercialStyle")%></td>
            <td style="text-align:left;white-space:normal;"><%#Eval("commercialcolor")%></td>
            <%--<td><%#Eval("goods_price")%></td>--%>
            <% if (Session["IsDisplayPrice"]==null || Session["IsDisplayPrice"].ToString() == "1") {%>
                <td align="right" width="40"><%# String.Format("{0:N}",MyConvert(Eval("real_price")))%></td>
                <td align="right" width="40"><%# String.Format("{0:N}",MyConvert(Eval("discount")))%></td>
            <% }else { %>
                <td>**</td>
                <td>**</td>
            <% }%>
            <td><%#Eval("quantity")%><%# Eval("dw")%></td>
            <td><%#Eval("custsize")%></td>
            <% if (Session["IsDisplayPrice"]==null || Session["IsDisplayPrice"].ToString() == "1") {%>
                <td align="right" ><%#String.Format("{0:N}", Convert.ToDecimal(Eval("real_price")) * Convert.ToDecimal(Eval("quantity")))%></td>
                <td align="right" ><%#String.Format("{0:N}", Convert.ToDecimal(Eval("real_price")) * Convert.ToDecimal(Eval("quantity")) * (100 -Convert.ToDecimal(Eval("discount").ToString()=="" ? "0" : Eval("discount")))/100)%></td>
                 <td align="right" ><%#String.Format("{0:N}", Convert.ToDecimal(Eval("real_price")) * Convert.ToDecimal(Eval("quantity")) * (Convert.ToDecimal(Eval("discount").ToString()=="" ? "0" : Eval("discount")))/100)%></td>
            <% }else { %>
                <td>**</td>
                <td>**</td>
            <% }%>
            <td><%#Eval("remarks")%></td>
          </tr>
      </ItemTemplate>
      <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
          </table>
     </FooterTemplate>
  </asp:Repeater>
  </td>
  </tr>
<tr>
  <td colspan="3" style="border-top:1px solid #000;">
  <table width="100%" border="0" cellspacing="0" cellpadding="5" style="margin:5px auto; font-size:12px; font-family:'微软雅黑'; background:#fff;">
    <tr>
      <td width="44%">
        商家账户：
        <%if (model.user_id > 0)
          { %>
          <%=model.user_name%>
        <%}
          else
          { %>
          匿名用户
        <%} %>
      </td>
      <td width="56%">联系人姓名：<asp:Label ID="contact_name" runat="server" /><br /></td>
    </tr>

    <tr>
      <td>商家名称：<asp:Label ID="title" runat="server" /></td>
      <td>商家地址：<asp:Label ID="contact_address" runat="server" /></td>
    </tr>
    <tr>
      <td valign="top">
        用户留言：<%=model.message%>
      </td>
    <td valign="top">联系电话：<asp:Label ID="contact_tel" runat="server" /></td>
    </tr>
    <tr>
      <td valign="top">订单备注：<%=model.remark%></td>
      
    </tr>
  </table>
    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" style="border-top:1px solid #000; font-size:12px; font-family:'微软雅黑'; background:#fff;">
      <tr>
        <% if (Session["IsDisplayPrice"]==null || Session["IsDisplayPrice"].ToString() == "1") {%>
            <td align="right">折扣前金额：￥<%=model.order_amount%> - 折扣金额：￥<%=model.discount_amount%>  = 折扣后总额：<%=model.real_amount%></td>
        <% }else { %>
          <td align="right">折扣前金额：￥** - 折扣金额：￥**  = 折扣后总额：**</td>
        <%} %>
      </tr>
    </table></td>
  </tr>
</table>
</div>
</form>
</body>
</html>