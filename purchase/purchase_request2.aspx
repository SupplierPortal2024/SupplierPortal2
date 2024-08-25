<%@ Page Language="C#" AutoEventWireup="true" CodeFile="purchase_request2.aspx.cs" Inherits="purchase_purchase_request2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>RFQ</title>
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
                t_title = 'RFQ';
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

    function ShowDiv(show_div, bg_div, url) {
        document.getElementById('url').href = url;
        document.getElementById(show_div).style.display = 'block';
        document.getElementById(bg_div).style.display = 'block';
        var bgdiv = document.getElementById(bg_div);
        bgdiv.style.width = document.body.scrollWidth;
        // bgdiv.style.height = $(document).height();
        $("#" + bg_div).height($(document).height());
        
    };
    //关闭弹出层
    function CloseDiv(show_div, bg_div) {
        document.getElementById(show_div).style.display = 'none';
        document.getElementById(bg_div).style.display = 'none';
    };
</script> 
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>Position:</span>
    <ul class="placeul">
    <li><a href="../home.aspx">Home</a></li>
    <li><a href="#">Tender/RFQ</a></li>
    </ul>
    </div>  
    <div class="rightinfo">
    <dl class="seachform"> 
    <dd><label>RFQ Number</label><span class="single-select"><asp:TextBox ID="txtNote_no" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></dd>
     <dd><label>Expired</label>  
    <span class="rule-single-select">
        <asp:DropDownList ID="ddlExpired" runat="server" AutoPostBack="True" onselectedindexchanged="ddlExpired_SelectedIndexChanged">
            <asp:ListItem Value="0">No</asp:ListItem>
            <asp:ListItem Value="1">Yes</asp:ListItem>
          </asp:DropDownList>
    </span>
    </dd>

    <dd class="cx"><asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="Search"></asp:Button>  
     <dd class="toolbar1" <%--style="visibility:hidden"--%>>
        <asp:LinkButton ID="btnExport" runat="server" CssClass="save" onclick="btnExport_Click"><li><span><img src="../images/t04.png" /></span>Export Excel</li></asp:LinkButton>
     </dd>
    
	<dd style="visibility:hidden"><label>Order Date From</label><span class="single-select"><input  type="text" class="timeinput" id="txtstart_time" name="txtstart_time" readonly="readonly" runat="server" /></span></dd>
	<dd style="visibility:hidden"><label>To</label><span class="single-select"><input type="text" class="timeinput" id="txtstop_time" name="txtstop_time" readonly="readonly" runat="server"/></span></dd>
    


       

    </dl>
       <!--列表-->
	  <table class="imgtable">
    	<thead>
    	<tr>
            <%--<th width="40px;">Line</th>
            <th width="40px;">Company</th>--%>
		    <th  width="80px;">RFQ Number</th>
            <%--<th  width="110px;">RFQ Line</th>--%>
            <th  width="50px;">Supplier ID</th>
            <th  width="110px;">Supplier</th>
            <th width="80px;">RFQ Date Time</th>
            <th width="80px;">RFQ Due Date</th>
            <th width="130px;">Subject</th>
            <th width="50px;">Status</th>
            <%--<th width="110px">Part Num</th>
	        <th width="100px;">Line Desc</th>
            <th width="100px;">Purchase UOM</th>
            <th width="100px;">RFQ Qty</th> --%>  
            <th width="90px;">Operate</th>  
        </tr>
        </thead>

        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
            <tr>
               <%-- <td><%# pageSize * page + Container.ItemIndex + 1 - pageSize%></td>
                <td><%# Eval("RFQHead_Company")%></td>--%>
                <td><%# Eval("RFQHead_RFQNum")%></td>
                <%--<td><%# Eval("RFQItem_RFQLine")%></td>--%>
                <td><%# Eval("Vendor_VendorID")%></td>
                <td><%# Eval("Vendor_Name")%></td>
                <td><%# Eval("Calculated_RFQDateDsp")==null ? "" : Eval("Calculated_RFQDateDsp")%></td>
                <td><%# Eval("Calculated_DueDateTimeDsp")%> </td>	
                <td ><%# Eval("RFQHead_Rptsubject_c")%></td>	
                <td ><%# Eval("RFQVend_ud_SPortalstatus_c")%></td>
                <%--<td ><%# Eval("RFQItem_PartNum")%></td>
                <td ><%# Eval("RFQItem_LineDesc")%></td>
                
                <td ><%# Eval("RFQItem_PUM")%></td>	
                <td style="text-align:right"><%# String.Format("{0:N}",Eval("RFQQty_Quantity"))%></td>--%><%--href="purchase_request_edit3.aspx?action=Edit&id=<%#Eval("id")%>&rfqnum=<%#Eval("RFQHead_RFQNum")%>&vendorid=<%#Eval("Vendor_VendorID")%>"--%>
                <td><a onclick="ShowDiv('MyDiv','fade','purchase_request_edit3.aspx?action=Edit&id=<%#Eval("id")%>&rfqnum=<%#Eval("RFQHead_RFQNum")%>&vendorid=<%#Eval("Vendor_VendorID")%>')" class="tablelink" style="color:red;cursor:pointer;">[Reply RFQ]</a> 
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
     <style>
    .black_overlay{
    display: none;
    position: absolute;
    top: 0%;
    left: 0%;
    width: 100%;
    height: 100%;
    background-color: black;
    z-index:1001;
    -moz-opacity: 0.8;
    opacity:.80;
    filter: alpha(opacity=80);
    }
    .white_content {
    display: none;
    position: absolute;
    top: 30%;
    left: 32%;
    width: 40%;
    height: 36%;
    border: 3px solid lightblue;
    background-color: white;
    z-index:1002;
    overflow: auto;
    }
    </style>
 

        <div id="MyDiv" class="white_content">
        <div style="text-align: right; cursor: default; height: 40px;" id="move">
            <span style="font-size: 16px;" onclick="CloseDiv('MyDiv','fade')">&nbsp;X&nbsp;</span>
        </div>
        <span style="font-size:25px;color:#467886;">Default policy</span>
        <br>
        <br>
        <span style="font-size:12px;">You must read and agree to the Privacy Policy in order to proceed</span>
        <br>
        <br>
        <span style="font-size:15px;">Any information collected by us, relating to an identifiable person, shall be used only in accordance with theprocedures and for the purposes that are here acknowledged to the data subject and where the latter, as requiredby law, has expressely consented.</span>
        <br>
        <br>
        <input type="checkbox" checked="checked"/> <span style="font-size:12px;">I accept the terms of the privacy policy (Required)</span>
        <br>
        <br>
        <div style="text-align: right; cursor: default; height: 40px;" >
            <span onclick="CloseDiv('MyDiv','fade')" style="font-size: 18px;">&nbsp;&nbsp;&nbsp;&nbsp;I DON'T AGREE&nbsp;&nbsp;&nbsp;&nbsp;</span>
             <a href="main.aspx" style="font-size: 18px;color:green" id="url">&nbsp;&nbsp;&nbsp;&nbsp;I AGREE&nbsp;&nbsp;&nbsp;&nbsp;</a>
        </div>
        </div>

    </div>
    </form>
</body>
</html>

