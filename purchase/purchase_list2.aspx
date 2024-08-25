<%@ Page Language="C#" AutoEventWireup="true" CodeFile="purchase_list2.aspx.cs" Inherits="purchase_purchase_list2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Orders</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/lhgcore.min.js"></script>
<script type="text/javascript" src="../js/lhgcalendar.min.js"></script>
<script type="text/javascript">
    J(function () {
        J('#txtstart_time').calendar({ btnBar: true });
        J('#txtstop_time').calendar({ btnBar: true });
    });
    function opdg(s_type, s_url) {
        var t_width, t_height, t_title, t_url, t_id;
        t_id = 'w_1';
        switch (s_type) {
            case 'info':
                t_width = 1080;
                t_height = 460;
                t_title = '查看订单详情';
                t_url = s_url;
                break;
        }
        $.dialog({
            width: t_width,
            height: t_height,
            title: t_title,
            max: false,
            content: 'url:' + t_url
        });
    } 
</script> 
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>Position:</span>
    <ul class="placeul">
    <li><a href="../home.aspx">Home</a></li>
    <li><a href="#">Order</a></li>
    </ul>
    </div>  
    <div class="rightinfo">
    <dl class="seachform"> 
    <dd><label>PO Num</label><span class="single-select"><asp:TextBox ID="txtNote_no" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></dd>
   
	<dd><label>Order Date From</label><span class="single-select"><input  type="text" class="timeinput" id="txtstart_time" name="txtstart_time" readonly="readonly" runat="server" /></span></dd>
	<dd><label>To</label><span class="single-select"><input type="text" class="timeinput" id="txtstop_time" name="txtstop_time" readonly="readonly" runat="server"/></span></dd>



      <dd class="cx"><asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="Search"></asp:Button>   
 </dd>
     <dd class="toolbar1" >
        <asp:LinkButton ID="btnExport" runat="server" CssClass="save" onclick="btnExport_Click">   <li><span><img src="../images/t04.png" /></span>Export Excel</li></asp:LinkButton>
        </dd>
    </dl>
            <!--列表-->

	  <table class="imgtable">
    	<thead>
    	<tr>
            <%--<th width="40px;">Line</th>
            <th width="40px;">Company</th>--%>
		    <th  width="110px;">PO Number</th>
            <th  width="50px;">PO Line</th>
            <th  width="110px;">Supplier</th>
            <th width="80px;">Order Date</th>
            <th width="110px">Part Num</th>
	        <th width="200px;">Line Desc</th>
            <th width="50px;">Purchase UOM</th>
            <th width="50px;">Currency</th>
            <th width="50px;">Order Qty</th>
            <th width="50px;">Unit Cost</th>     
        </tr>
        </thead>

        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                    <tr>
                       <%-- <td><%# pageSize * page + Container.ItemIndex + 1 - pageSize%></td>
                        <td><%# Eval("Vendor_Company")%></td>--%>
                        <td><%# Eval("POHeader_PONum")%></td>
                        <td><%# Eval("PODetail_POLine")%></td>
                        <td><%# Eval("Vendor_Name")%></td>
                        <td><%# Eval("POHeader_OrderDate")==null ? "" : Convert.ToDateTime(Eval("POHeader_OrderDate")).ToShortDateString()%></td>
                        <td ><%# Eval("PODetail_PartNum")%></td>
                        <td ><%# Eval("PODetail_LineDesc")%></td>
                        <td ><%# Eval("PODetail_PUM")%></td>	
                        <td ><%# Eval("POHeader_CurrencyCode")%></td>	
                        <td style="text-align:right"><%# String.Format("{0:N}",Eval("PODetail_OrderQty"))%></td>
                        <td style="text-align:right"><%# String.Format("{0:N}",Eval("PODetail_DocUnitCost"))%></td>
                        
                       <%--<td><a href="purchase_edit.aspx?action=Edit&id=<%#Eval("id")%>" class="tablelink"> 处理订单</a> --%>
                       <%--&nbsp;&nbsp;<asp:LinkButton ID="lbtnDelCa" runat="server" CommandArgument='<%# Eval("id")%>' OnClientClick="return confirm('是否真的要取消该订单吗？')" onclick="lbtnDelCa_Click"><%# Eval("Response").ToString() != "W" ? "<font color =red>[取消订单]</font>" : ""%></asp:LinkButton>--%>
 
        
      
                    </tr> 		
 	               </ItemTemplate>
            <FooterTemplate>
              <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"8\"><font color=red>No record</font></td></tr>" : ""%>
               </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater> 

    <div class="pagelist">
      <div class="l-btns">
        <span>Display</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>Records/Page</span>
      </div>
      <div id="PageContent" runat="server" class="default"></div>
    </div>
      
    </div>
    </form>
</body>
</html>

