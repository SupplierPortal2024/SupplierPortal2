<%@ Page Language="C#" AutoEventWireup="true" CodeFile="purchase_rep.aspx.cs" Inherits="purchase_purchase_rep" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>POLIST</title>    
<style type="text/css">
body{
	OVERFLOW:SCROLL;
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	font-family: "宋体";
	font-size: 14px;
	line-height: 20px;
	color: #000000;
}
table {
	font-family: "宋体";
	font-size: 14px;
	line-height: 20px;
	color: #000000;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
	  <table width="98%"  border="1" align="center" cellpadding="5" cellspacing="1" bgcolor="#CACACA">
          <tr bgcolor="#EAEAEA">
            <td height="30" colspan="8" align="center" bgcolor="#FFFFFF">
            <span style="font-size:18px;line-height: 25px;"><b>PO List</b></span></td>
          </tr>
          <tr bgcolor="#FFFFFF"> 
            <td align="center"  bgcolor="#C0C0C0"><b>PO Number</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>PO Line</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>Supplier</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>Order Date</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>Part Num</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>Line Desc</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>Purchase UOM</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>Currency</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>Order Qty</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>Unit Cost</b></td>
        </tr>
       <asp:Repeater ID="repCategory" runat="server">
        <ItemTemplate>
         <tr bgcolor="#FFFFFF" >
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
            </tr> 		
       </ItemTemplate>
       </asp:Repeater>
    
	</table>
    </form>
</body>
</html>


