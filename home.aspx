<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>Home</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript">
    function opdg(s_type, s_url) {
        var t_width, t_height, t_title, t_url, t_id;
        t_id = 'w_1';
        switch (s_type) {
            case 'info':
                t_width = 980;
                t_height = 500;
                t_title = '查看通知公告';
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
<style>
#box{width:100%;display:flex;flex-wrap:wrap;font-size:50px;text-align:left}
#box>div:first-child{display:flex;flex-wrap:wrap;}
.noborder{border-bottom:0px solid #467886;box-sizing:border-box;}
.allborder{border:1px solid #467886;box-sizing:border-box;}
.bottomborder{border-bottom:1px solid #467886;box-sizing:border-box;}
</style>
</head>
<body>
    <form id="form1" runat="server">
	<%--<div class="place" style="visibility:hidden">
    <span>Supplier Portal</span>
    <ul class="placeul">
    <li><a href="#"></a></li>
    </ul>
    </div>
    --%>
    <div class="mainbox"  >    
    <div class="mainleft" >
        <div class="leftinfo">

        <asp:Literal ID="Lit_mysalse" runat="server"></asp:Literal>     
        <div class="maintj">  
            <div id="box">
	        <div style="width:50%;" class="sectiontitle">Supplier Information</div>
	        <div style="width:50%;color:#467886" class="sectiontitle">Hello,<%=modelvendor.VendCnt_Name %></div>
	        <div style="width:50%;font-size:16px;height:180px">
                Contact Information<br>
                <%=modelvendor.VendCnt_Name %><br><br>
                <%=modelvendor.VendCnt_EmailAddress %><br>
                <%--<a href="../sysmanager/my_info.aspx?cg=1" style="font-size:16px;color:#467886;" class="sectiontitle">Change Password</a>--%>

	        </div>
	
	        <div style="width:50%;font-size:16px;height:180px">
                Address<br><br>
                <%=modelvendor.Vendor_Name %><br>
                <%=modelvendor.Vendor_Address1 %><br>
                <%=modelvendor.Vendor_Address2 %><br>
                <%=modelvendor.Vendor_Address3 %><br>

	        </div>

	        <div style="width:100%;">&nbsp&nbsp</div>
	        <div style="width:50%;" class="sectiontitle">General Notice</div>
	        <div style="width:50%;" class="sectiontitle">Supplier Specific Notice</div>

	        <div style="width:50%;font-size:16px;"><%=syst_portalnotice=="" ? "<BR><BR>" : syst_portalnotice%></div>
	        <div style="width:50%;font-size:16px;"><%=vendor_portalnotice=="" ? "<BR><BR>" : vendor_portalnotice %></div>
	        <div style="width:100%;">&nbsp&nbsp</div>
	        <div style="width:100%;">&nbsp&nbsp</div>
	        
            <div style="width:1%;"></div>
            <div style="width:48%;" class="sectiontitle">Request for Quotations</div>
	        <div style="width:1%;"></div>
            
            <div style="width:1%;"></div>
	        <div style="width:48%;" class="sectiontitle">Purchase Orders</div>
	        <div style="width:1%;"></div>
            
            <div style="width:1%;"></div>
	        <div style="width:48%;font-size:16px;color:#467886;height:180px" class="allborder">
                <br>
                &nbsp;&nbsp;&nbsp;&nbsp;<%=Calculated_RepliedRFQ=="" ? "" : "Replied RFQ(" + Calculated_RepliedRFQ + ")" %>
                <br>
                &nbsp;&nbsp;&nbsp;&nbsp;<%=calculated_waitforreplyRFQ=="" ? "" : "Waiting for reply(" + calculated_waitforreplyRFQ + ")" %>
                <br>
	        </div>
	        <div style="width:1%;"></div>
            
            <div style="width:1%;"></div>    
	        <div style="width:48%;font-size:16px;color:#467886;height:180px" class="allborder">
                <br>
                &nbsp;&nbsp;&nbsp;&nbsp;<%=Calculated_RepliedPO=="" ? "" : "Open PO(" + Calculated_RepliedPO + ")" %>
                <br>
                &nbsp;&nbsp;&nbsp;&nbsp;<%=calculated_waitforreplyPO=="" ? "" : "Closed PO(" + calculated_waitforreplyPO + ")" %>
   
                <br>
	        </div>
	        <div style="width:1%;"></div>
            <div style="width:1%;"></div>    
	        <div style="width:98%;"><br>
            <a href="../tools/downloadfile.aspx?fileName=../upload/files/UserGuide.pdf" style="font-size:16px;color:#467886;">Download User Guide&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <a href="../tools/downloadfile.aspx?fileName=../upload/files/TermsOfUserForJCKSCSupplierPortal.pdf" style="font-size:16px;color:#467886;" >Terms of user for JCKSC Supplier Portal</a></div>
            <div style="width:1%;"></div> 
    </div>
       
    <%--<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" width="740" height="460">
  <param name="movie" value="ok.swf" />
  <param name="quality" value="high" />
  <embed src="ok.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="740" height="460"></embed>
</object>  
   </div>--%>
    
    </div>
    <!--leftinfo end-->
    
    </div>
    <!--mainleft end-->
    <div class="mainright" style="visibility:hidden">
    <div class="dflist">
    <div class="listtitle"><%--<a href="sysmanager/notice_list.aspx" class="more1" style="visibility:hidden">More</a>Notice--%></div>    
    <ul class="newlist">
    <asp:Repeater ID="rptList_notice" runat="server">
    <ItemTemplate> 
    <li><a href="javascript:opdg('info','sysmanager/notice_info.aspx?id=<%#Eval("id")%>');" title="<%# Eval("title")%>"><%# Eval("title").ToString().Length > 18 ? Eval("title").ToString().Substring(0, 18) + "..." : Eval("title").ToString()%></a></li>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList_notice.Items.Count == 0 ? "<li><font color=red>No Record</font></li>" : ""%>
    </FooterTemplate>
    </asp:Repeater>  
    </ul>        
    </div> 
    </div>
    <!--mainright end--> 
    </div>


    </form>
</body>
</html>
