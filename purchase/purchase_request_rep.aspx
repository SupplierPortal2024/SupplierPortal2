<%@ Page Language="C#" AutoEventWireup="true" CodeFile="purchase_request_rep.aspx.cs" Inherits="purchase_purchase_request_rep" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>RFQ</title>    
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
            <td height="30" colspan="7" align="center" bgcolor="#FFFFFF">
            <span style="font-size:18px;line-height: 25px;"><b>RFQ List</b></span></td>
          </tr>
          <tr bgcolor="#FFFFFF"> 
            <td align="center"  bgcolor="#C0C0C0"><b>RFQ Number</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>Supplier ID</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>Supplier</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>RFQ Date Time</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>RFQ Due Date</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>Subject</b></td>
            <td align="center"  bgcolor="#C0C0C0"><b>Status</b></td>
        </tr>
        
       <asp:Repeater ID="repCategory" runat="server">
        <ItemTemplate>
         <tr bgcolor="#FFFFFF" >
                <td><%# Eval("RFQHead_RFQNum")%></td>
                <td><%# Eval("Vendor_VendorID")%></td>
                <td><%# Eval("Vendor_Name")%></td>
                <td><%# Eval("RFQHead_RFQDate")==null ? "" : Convert.ToDateTime(Eval("RFQHead_RFQDate")).ToShortDateString()%></td>
                <td ><%# Eval("Calculated_DueDateTime")%></td>
                <td ><%# Eval("RFQHead_Rptsubject_c")%></td>
                <td ><%# Eval("RFQVend_ud_SPortalstatus_c")%></td>	
             
            </tr> 		
       </ItemTemplate>
       </asp:Repeater>
 
	</table>
    </form>
</body>
</html>


