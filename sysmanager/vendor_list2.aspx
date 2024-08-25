<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vendor_list2.aspx.cs" Inherits="sysmanager_vendor_list2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>Position：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">Home</a></li>
    <li><a href="#">Supplier</a></li>
    </ul>
    </div>  
    <div class="rightinfo">    
   
    
    <dl class="seachform"> 
    <dd><label>Key words</label><span class="single-select"><asp:TextBox ID="txtKeywords" runat="server" CssClass="scinput"></asp:TextBox></span></dd>
    <dd class="cx"> <asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="Search"></asp:Button></dd> 
    <dd style="visibility:hidden"><label>Company</label>  
    <span class="rule-single-select">
    <asp:DropDownList ID="ddlCategoryId"  runat="server" AutoPostBack="True" onselectedindexchanged="ddlCategoryId_SelectedIndexChanged">
    </asp:DropDownList>
    </span>
    </dd>
    <dd style="visibility:hidden"><label>Status</label>  
    <span class="rule-single-select">
      <asp:DropDownList ID="ddlStatus"  runat="server" AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
            <asp:ListItem Value="" Selected="True">==All==</asp:ListItem>
             <asp:ListItem Value="1">Active</asp:ListItem>
             <asp:ListItem Value="2">Inactive</asp:ListItem>
          </asp:DropDownList>
    </span>
    </dd>
      
    </dl>
    
    <!--列表-->
    <asp:Repeater ID="rptList" runat="server">
        <HeaderTemplate>
            <table class="tablelist">
    	        <thead>
    	        <tr>
                <th width="50px;">No</th>
                <th width="50px;">Company</th>
                <th width="80px;">Supplier ID</th>
                <th width="120px;">Supplier Name</th>
                <th>Currency</th>
                <th>Terms</th>
                <%--<th>BR Number</th>
                <th>BR Expiry Date</th>
                <th>CR Number</th>--%>
                <th>Phone</th>
                <th>Fax</th>
                <th>Email</th>
                <th width="150px;">Address</th>
                <%--<th>Address Line 2</th>
                <th>Address Line 3</th>--%>
                <th>City</th>
                <th>State/Prov</th>
                <th>Country</th>
                <th width="120px;">Contact Number</th>
                <th  width="120px;">Contact Name</th>
                <th>Inactive</th>
                <%--<th width="50px;">Status</th>--%>
                <%--<th width="50px;">Sequence</th>--%>
                <%--<th>Remarks</th>--%>
                <th width="90px;">Operate</th>
                </tr>
                </thead>
           <tbody>
        </HeaderTemplate>
        <ItemTemplate> 
            <tr>
		    <td><%# pageSize * page + Container.ItemIndex + 1 - pageSize%><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></td>	
		    <%--<td><%#new ps_vendor_category().GetName(Convert.ToInt32(Eval("category_id")))%></td>--%>
            <td><%# Eval("Vendor_Company")%></td>
            <td><%# Eval("Vendor_VendorID")%></td>
            <td><%# Eval("Vendor_Name")%></td>
            <td><%# Eval("Vendor_CurrencyCode")%></td>
            <td><%# Eval("Vendor_TermsCode")%></td>
            <%--<td></td>
            <td></td>
            <td><%# Eval("OrgRegCode")%></td>--%>
            <td><%# Eval("Vendor_PhoneNum")%></td>
            <td><%# Eval("Vendor_FaxNum")%></td>
            <td><%# Eval("Vendor_EMailAddress")%></td>
            <td><%# Eval("Vendor_Address1") + "" + Eval("Vendor_Address2") + "" + Eval("Vendor_Address3")%></td>
            <%--<td><%# Eval("Address2")%></td>
            <td><%# Eval("Address3")%></td>--%>
            <td><%# Eval("Vendor_City")%></td>
            <td><%# Eval("Vendor_State")%></td>
            <td><%# Eval("Vendor_Country")%></td>
            <td><%# Eval("VendCnt_ConNum")%></td>
            <td><%# Eval("VendCnt_Name")%></td>
            <td><%# Eval("VendCnt_Inactive")%></td>
            
            <%--<td><%# Convert.ToInt32(Eval("Inactive")) == 1 ? "<font color=red>InActive</font>" : "Active"%></td>--%>
		    <%--<td><asp:TextBox ID="txtSortId" runat="server" Height="25"   Text='<%#Eval("sort_id")%>' CssClass="scinput" Width="40" onkeydown="return checkNumber(event);" /></td>--%>
		    <%--<td><%# Eval("Comment")%></td>--%>
		    <td><a href="vendor_edit2.aspx?action=Edit&companycode=<%#Eval("Vendor_Company")%>&vendorid=<%#Eval("Vendor_VendorID")%>&page=<%=page%>" class="tablelink"><font color =green>[Edit]</font></a>  <%--&nbsp;&nbsp;<asp:LinkButton ID="lbtnDelCa" runat="server" CommandArgument='<%# Eval("id")%>' OnClientClick="return confirm('是否真的要删除？')" onclick="lbtnDelCa_Click"><font color =red>[Delete]</font></asp:LinkButton>--%></td>
            </tr> 
         </ItemTemplate>
        <FooterTemplate>
          <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\"><font color=red>No record</font></td></tr>" : ""%>
           </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>  
   <!--列表-->
    <div class="pagelist">
      <div class="l-btns">
        <span>Dispaly</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>Reocrds/Page</span>
      </div>
      <div id="PageContent" runat="server" class="default"></div>
    </div>   
    </div>
    </form>
</body>
</html>


