<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manager_list.aspx.cs" Inherits="sysmanager_manager_list" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>User</title>
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
    <li><a href="#">User</a></li>
    </ul>
    </div>
    
    <div class="rightinfo"> 
    <div class="tools">   
    	<ul class="toolbar">
        <a href="manager_edit.aspx?action=Add"><li><span><img src="../images/t01.png" /></span>Add</li></a>
          <asp:LinkButton ID="btnExport" runat="server" CssClass="save" onclick="btnExport_Click">   <li><span><img src="../images/t04.png" /></span>Export Execl</li></asp:LinkButton>
      
        </ul>
    </div>
    
    <dl class="seachform">
     <dd><label>Key words</label><span class="single-select"><asp:TextBox ID="txtKeywords" runat="server" CssClass="scinput"></asp:TextBox></span></dd>


    
   
       <dd><label>Status</label>  
        <span class="rule-single-select">
          <asp:DropDownList ID="ddlStatus"  runat="server" AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
                <asp:ListItem Value="" Selected="True">==All==</asp:ListItem>
                 <asp:ListItem Value="1">Active</asp:ListItem>
                 <asp:ListItem Value="2">Inactive</asp:ListItem>
              </asp:DropDownList>
        </span>
    </dd>
    
       <dd class="cx"><asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="Serarch"></asp:Button></dd>
    
    </dl>

        <!--列表-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table class="tablelist">
    	<thead>
    	<tr>
        <th width="50px;">No</th>
		<th>Account</th>
		<th>Name</th>
        <th>Email</th>
		<th>Tel</th>
		<%--<th>Role Type</th>
		<th>Company</th>--%>
		<th>Supplier ID</th>
         <th>Supplier Name</th>
         <th>Remarks</th>
        <th width="50px;">Status</th>  
        <th width="90px;">Operate</th>
        </tr>
        </thead>
   <tbody>
</HeaderTemplate>
<ItemTemplate> 
        <tr>
		<td><%# pageSize * page + Container.ItemIndex + 1 - pageSize%><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></td>	
	
        <td><%# Eval("user_name")%></td>
        <td><%# Eval("real_name")%></td>
        <td><%# Eval("EmailAddress")%></td>
        <td><%# Eval("mobile")%></td>
        <%--<td><%#new ps_manager_role().GetTitle(Convert.ToInt32(Eval("role_id")))%></td>--%>
        <%--<td><%#Convert.ToInt32(Eval("depot_category_id")) == 0 ? "<font color=red>所有公司</font>" : new ps_depot_category().GetTitle(Convert.ToInt32(Eval("depot_category_id")))%></td>--%>
        <td><%# Eval("vendor_id").ToString() %></td>
        <td><%# Eval("vendor_id").ToString()=="" ? "" : new ps_epicor_vendor().GetVendorNameByVendorID(Eval("vendor_id").ToString())%></td>
      	<td><%# Eval("remark")%></td>
        <td><%# Convert.ToInt32(Eval("is_lock")) == 2 ? "<font color=red>Inactive</font>" : "Active"%></td>
	
		<td><a href="manager_edit.aspx?action=Edit&id=<%#Eval("id")%>&page=<%=page%>" class="tablelink"><font color =green>[Edit]</font></a>  &nbsp;&nbsp;<asp:LinkButton ID="lbtnDelCa" runat="server" CommandArgument='<%# Eval("id")%>' OnClientClick="return confirm('Confrim to delete？')" onclick="lbtnDelCa_Click"><font color =red>[Del]</font></asp:LinkButton></td>
        </tr> 
     </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\"><font color=red>暂无记录</font></td></tr>" : ""%>
   </tbody>
    </table>
</FooterTemplate>
</asp:Repeater>  

<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
    
    </div>
    </form>
</body>
</html>
