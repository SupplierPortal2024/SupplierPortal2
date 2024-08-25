<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manager_log.aspx.cs" Inherits="sysmanager_manager_log" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>用户操作日志</title>
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
    <li><a href="#">User log</a></li>
    </ul>
    </div>
    
    <div class="rightinfo">
    
    <div class="tools">
    
    	<ul class="toolbar">
    <li><span><img src="../images/t02.png" /></span><a href="javascript:;" onclick="checkAll(this);">Select All</a></li>
        <li class="click"><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><img src="../images/t03.png" /></span>Delete</asp:LinkButton></li>
        </ul>         
    </div>    
    <dl class="seachform">
       <dd><label>Key words</label><span class="single-select"><asp:TextBox ID="txtKeywords" runat="server" CssClass="scinput"></asp:TextBox></span></dd>
      <dd class="cx"> <asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="Serarch"></asp:Button></dd>
    </dl>
        <!--列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
    <table class="tablelist">
    	<thead>
    	<tr>
        <th>Select</th>
        <th>No</th>
         <th>Create User</th>
        <th>Type</th>
        <th>Log Content</th>
		<th>User IP</th>
        <th>Create Time</th>    
        </tr>
        </thead>
        <tbody>
        </HeaderTemplate>
<ItemTemplate> 
        <tr>
		<td><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></td>
		<td><%# pageSize * page + Container.ItemIndex + 1 - pageSize%></td>	
        <td><a href="manager_log.aspx?keywords=<%# Eval("user_name") %>"><%# Eval("user_name")%></a></td>
		<td> <a href="manager_log.aspx?keywords=<%# Eval("action_type") %>"> <%# Eval("action_type") %></a></td>
		<td><%# Eval("remark") %></td>
        <td> <%# Eval("user_ip") %></td>
        <td><%#string.Format("{0:g}",Eval("add_time"))%></td>
        </tr> 
  </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\"><font color=red>No Record</font></td></tr>" : ""%>
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

