<%@ Page Language="C#" AutoEventWireup="true" CodeFile="top.aspx.cs" Inherits="top" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>头部</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript">
    $(function () {
        //顶部导航切换
        $(".nav li a").click(function () {
            $(".nav li a.selected").removeClass("selected")
            $(this).addClass("selected");
        })
    })

    function About() {
        $.dialog({
            width:300,
            height: 10,
            title: 'About',
            max: false,
            min: false,
            content: 'Epcior'
        });
    }
</script>

</head>
<body style="background:url(images/topbg.gif) repeat-x;">
    <form id="form1" runat="server">
    <div class="topleft">
    <a href="main.aspx" target="_parent"></a>
    </div>      
    <div class="topright">    
    <ul style="color:#09759f">
        <div class="user">
           <a href="sysmanager/my_info.aspx"  target="rightFrame"><h2> <span><asp:Literal ID="Lit_Name" runat="server"></asp:Literal></h2></a> <%--<asp:LinkButton ID="LinkButton1" runat="server" onclick="lbtnExit_Click">退出</asp:LinkButton>--%></span>
        </div>
    
	    <%--<li><a href="sysmanager/my_info.aspx"  target="rightFrame"><h2>My Info</h2></a></li>--%>
        <li><a href="sysmanager/my_info.aspx?cg=1"  target="rightFrame" style="color:#09759f" >Change Password</a>
            <BR>
            <asp:LinkButton ID="LinkButton1" runat="server" Text="Logout" style="color:#09759f" onclick="lbtnExit_Click"></asp:LinkButton>
        </li>

    </ul>
    
    </div>
    </form>
</body>
</html>
