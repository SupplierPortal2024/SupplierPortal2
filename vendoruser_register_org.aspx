<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vendoruser_register_org.aspx.cs" Inherits="vendoruser_register_org" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Vendor User Register</title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<script type="text/javascript" src="../js/jquery.autocomplete.min.js"></script>
<link rel="Stylesheet" href="../css/jquery.autocomplete.css" />
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();

        $("#btnSelCus").click(function () {
            var dialog = $.dialog({
                title: '选择经销商',
                content: 'url:../select/customer_select.aspx?selType=sel1&category_id=' + $("#ddlCategoryId").val()+'',
                min: false,
                max: false,
                lock: true,
                width: 1200,
                top:200,
            });

        });

        $("#btnSelCus2").click(function () {
            var dialog = $.dialog({
                title: '选择经销商',
                content: 'url:../select/customer_select.aspx?selType=sel2&category_id=' + $("#ddlCategoryId").val() + '',
                min: false,
                max: false,
                lock: true,
                width: 1200,
                top: 200,
            });

        });

        $("#btnSelVen").click(function () {
            var dialog = $.dialog({
                title: '选择供应商',
                content: 'url:../select/vendor_select.aspx?CatID=' + $("#ddlCategoryId").val() + '',
                min: false,
                max: false,
                lock: true,
                width: 1200,
                top: 200,
            });

        });
    });


    

    
    function SelCus(obj) {
        if ($("#ddlCategoryId").val() == '')
            alert('请先选择所属公司.')
        else {
            if (obj.value.length >= 1) {
                var postData = { "searchcontent": obj.value, compamy: $("#ddlCategoryId").val() };
                $.ajax({
                    type: "post",
                    url: "../tools/search_ajax.ashx?searchtype=cust",
                    data: postData,
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert('尝试发送失败，错误信息' + errorThrown);
                    },

                    success: function (data, textStatus) {
                        $('#txtCustCode').autocomplete(data, {
                            max: 200,    //列表里的条目数
                            minChars: 1,    //自动完成激活之前填入的最小字符
                            width: 400,     //提示的宽度，溢出隐藏
                            scrollHeight: 300,   //提示的高度，溢出显示滚动条
                            matchContains: true,    //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示
                            autoFill: false,    //自动填充
                            formatItem: function (row, i, max) {
                                return i + '/' + max + ':  "' + row.custcode + '"  [' + row.custname + ']';
                            },
                            formatMatch: function (row, i, max) {
                                return row.custcode + row.custname;
                            },
                            formatResult: function (row) {
                                return row.custcode;
                            }
                        }).result(function (event, row, formatted) {
                            $('#txtCustName').val(row.custname);
                            $('#txtCustID').val(row.custid);
                        });
                    }
                });
            }
        }
    }


    function SelCus2(obj) {
        if ($("#ddlCategoryId").val() == '')
            alert('请先选择所属公司.')
        else {
            if (obj.value.length >= 1) {
                var postData = { "searchcontent": obj.value, compamy: $("#ddlCategoryId").val() };
                $.ajax({
                    type: "post",
                    url: "../tools/search_ajax.ashx?searchtype=cust",
                    data: postData,
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert('尝试发送失败，错误信息' + errorThrown);
                    },

                    success: function (data, textStatus) {
                        $('#txtCustomerName').autocomplete(data, {
                            max: 200,    //列表里的条目数
                            minChars: 1,    //自动完成激活之前填入的最小字符
                            width: 400,     //提示的宽度，溢出隐藏
                            scrollHeight: 300,   //提示的高度，溢出显示滚动条
                            matchContains: true,    //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示
                            autoFill: false,    //自动填充
                            formatItem: function (row, i, max) {
                                return i + '/' + max + ':  "' + row.custcode + '"  [' + row.custname + ']';
                            },
                            formatMatch: function (row, i, max) {
                                return row.custcode + row.custname;
                            },
                            formatResult: function (row) {
                                return row.custcode;
                            }
                        }).result(function (event, row, formatted) {
                            $('#txtCustomerName').val(row.custname);
                            $('#txtCustomerID').val(row.custid);
                        });
                    }
                });
            }
        }
    }


    function SelVendor(obj) {

        if ($("#ddlCategoryId").val() == '')
            alert('请先选择所属公司.')
        else {
            if (obj.value.length >= 1) {
                var postData = { "searchcontent": obj.value, compamy: $("#ddlCategoryId").val() };
                $.ajax({
                    type: "post",
                    url: "../tools/search_ajax.ashx?searchtype=vendor",
                    data: postData,
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert('尝试发送失败，错误信息' + errorThrown);
                    },

                    success: function (data, textStatus) {
                        $('#txtVendorName').autocomplete(data, {
                            max: 200,    //列表里的条目数
                            minChars: 1,    //自动完成激活之前填入的最小字符
                            width: 400,     //提示的宽度，溢出隐藏
                            scrollHeight: 300,   //提示的高度，溢出显示滚动条
                            matchContains: true,    //包含匹配，就是data参数里的数据，是否只要包含文本框里的数据就显示
                            autoFill: false,    //自动填充
                            formatItem: function (row, i, max) {
                                return i + '/' + max + ':  "' + row.vendorcode + '"  [' + row.vendorname + ']';
                            },
                            formatMatch: function (row, i, max) {
                                return row.vendorcode + row.vendorname;
                            },
                            formatResult: function (row) {
                                return row.vendorcode;
                            }
                        }).result(function (event, row, formatted) {
                            $('#txtVendorName').val(row.vendorname);
                            $('#txtVendorID').val(row.vendorid);
                        });
                    }
                });
            }
        }
    }

</script>
</head>
<body>
    <form id="form1" runat="server">

<%--	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="manager_list.aspx">用户管理</a></li>
    <li><a href="#">编辑用户</a></li>
    </ul>
    </div>--%>
    
    <div class="formbody">   
    <div class="formtitle"><span>Vendor User Register</span></div>
    <!--用户信息-->
<div class="tab-content">
   <dl id="role" runat="server" visible="false">
    <dt>Role Type</dt>
    <dd>
      <span class="rule-single-select" style="position:absoulte;z-index:5555; ">
        <asp:DropDownList id="ddlRoleId" runat="server" datatype="*" errormsg="请选择管理员角色" sucmsg=" " Enabled="false"  AutoPostBack="True" onselectedindexchanged="ddlRoleId_SelectedIndexChanged"></asp:DropDownList>
      </span>
    </dd>
  </dl>
     <dl id="bm" runat="server" visible="false">
    <dt>Company</dt>
    <dd>
      <span class="rule-single-select" style="position:absoulte;z-index:5554; ">
        <asp:DropDownList id="ddlCategoryId" runat="server" datatype="*" errormsg="请选择所属公司" sucmsg=" " AutoPostBack="True" onselectedindexchanged="ddlCategoryId_SelectedIndexChanged"></asp:DropDownList>
      </span>
    </dd>
  </dl>
    <dl id="md" runat="server" visible="false">
    <dt>所属经销商</dt>
    <dd>
        <asp:TextBox ID="txtCustomerName"  CssClass="input normal" Enabled="false" runat="server" Width="300" datatype="*" errormsg="请选择所属经销商"  sucmsg=" " ></asp:TextBox>
        <asp:TextBox ID="txtCustomerID"  CssClass="input normal"   runat="server" Width="0" style="visibility:hidden " ></asp:TextBox>
        <input id="btnSelCus" runat="server"  type="button" class="btn green" value="选择" /> 
        <span class="rule-single-select" style="position:absoulte;z-index:5553;visibility:hidden ">
        <asp:DropDownList id="ddlDepotId" width="200" runat="server" Visible="false"  datatype="*" errormsg="请选择所属经销商"  sucmsg=" "></asp:DropDownList>
      </span>
        
    </dd>
  </dl>
   <dl id="displayprice" runat="server" visible="false">
    <dt>Display Price</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="ckIsDisplayPrice" runat="server" Checked="True" />
      </div>
      
    </dd>
  </dl>
  <dl id="vd" runat="server" visible="false">
    <dt>所属供应商</dt>
    <dd>
      <asp:TextBox ID="txtVendorName"  CssClass="input normal" oninput="SelVendor(this)" Enabled="false"  runat="server" Width="300" datatype="*" errormsg="请选择所属供应商"  sucmsg=" " ></asp:TextBox>
      <asp:TextBox ID="txtVendorID"  CssClass="input normal"   runat="server" Width="0" style="visibility:hidden " ></asp:TextBox>
        <input id="btnSelVen" runat="server"  type="button" class="btn green" value="选择" /> 
      <span class="rule-single-select" style="position:absoulte;z-index:5553;visibility:hidden ">
        <asp:DropDownList id="ddlVendorId" width="200"  runat="server" Visible="false" datatype="*" errormsg="请选择所属供应商" sucmsg=" "></asp:DropDownList>
      </span>
    </dd>
  </dl>
<dl>
    <dt>User Name</dt>
    <dd><asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/" sucmsg=" " ajaxurl="../tools/admin_ajax.ashx?action=manager_validate"></asp:TextBox> <span class="Validform_checktip">*leter、underline、number</span></dd>
  </dl> 

 <dl>
    <dt>Email</dt>
    <dd><asp:TextBox ID="txtEmailAddress" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
<dl>
    <dt>Temp Password</dt>
    <dd><asp:TextBox ID="txtTempPassword" runat="server" CssClass="input normal" TextMode="Password" datatype="*6-20" nullmsg="Please input temp password" errormsg="legth 6-20" sucmsg=" " ></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
<dl>
    <dt>Password</dt>
    <dd><asp:TextBox ID="txtPassword" runat="server" CssClass="input normal" TextMode="Password" datatype="*6-20" nullmsg="Please input password" errormsg="legth 6-20" sucmsg=" " ></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>Confirm password</dt>
    <dd><asp:TextBox ID="txtPassword1" runat="server" CssClass="input normal" TextMode="Password" datatype="*" recheck="txtPassword" nullmsg="Please input password again" errormsg="password is not match" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  
  <dl>
    <dt>Real Name</dt>
    <dd><asp:TextBox ID="txtRealName" runat="server" CssClass="input normal" nullmsg="Please impurt user name"></asp:TextBox>
  </dl>
  <dl>
    <dt>Tel</dt>
    <dd><asp:TextBox ID="txtmobile" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
  

   <dl>
    <dt>Address</dt>
    <dd><asp:TextBox ID="txtAddress" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
 <dl>
    <dt>Position</dt>
    <dd><asp:TextBox ID="txtPosition" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>


      <dl runat="server" visible="false">
        <dt>Active</dt>
        <dd>
          <div class="rule-single-checkbox">
              <asp:CheckBox ID="cbIsLock" runat="server" Checked="True" />
          </div>
          <span class="Validform_checktip">*Inactive account can't login system</span>
        </dd>
      </dl>
     <dl>
     <dl id="kf" style="display:none" runat="server" >
        <dt>微信客服</dt>
        <dd>
          <span class="rule-single-select">
            <asp:DropDownList id="ddlCustomerSupport" runat="server" errormsg="请选择微信客服" sucmsg=" "></asp:DropDownList>
          </span>
        </dd>
      </dl>

     <dl id="cu" runat="server" visible="false">
    <dt>绑定经销商</dt>
     <dd>       
        <table width="660" border="0" align="center" cellpadding="9" cellspacing="0" class="cart_table">
     
      <tr> 
       <th width="200" align="left">经销商编码</th>
       <th width="300" align="left">经销商名称</th>
        <th width="100" align="left">操作</th>
      </tr>
       <tr> 
       <th width="200" align="left"><asp:TextBox ID="txtCustCode"  CssClass="input normal" Enabled="false" oninput="SelCus(this)"   runat="server" Width="80" ></asp:TextBox><input id="btnSelCus2" runat="server"  type="button" class="btn green" value="选择" /> </th>
       <th width="300" align="left"><asp:TextBox ID="txtCustName"  CssClass="input normal" Enabled="false" runat="server" Width="300" ></asp:TextBox><asp:TextBox ID="txtCustID" runat="server" Width="0" ></asp:TextBox></th>
       <th width="100" align="center" ><asp:Button ID="btnAddCust" runat="server" Text="添加经销商 " class="btn"   onclick="btnAddCust_Click" Width="100" /></th>  
      </tr>
      <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate> 
            <tr>
                <td width="200" ><%# Eval("custcode")%></td>	
                <td width="300"><%# Eval("custname")%></td>	
                <td ><asp:LinkButton ID="lbtnDelCust" runat="server" class="btn"  Width="30"  CommandArgument='<%# Eval("id")%>'  OnClientClick="return confirm('是否真的要删除？')"   onclick="lbtnDelCust_Click" ><font color ="red">删除</font></asp:LinkButton></td>
            </tr>
           </ItemTemplate>
        </asp:Repeater>
   </table>
    </dd>
    </dl>

  <dl>
    <dt>Remarks</dt>
        <dd><asp:TextBox ID="txtremark" runat="server" CssClass="input normal" ></asp:TextBox></dd>
  </dl> 

 <dl>
     <dt></dt>
     <dd>
        <div class="btn-list">
            <asp:Button ID="btnSubmit" runat="server" Text="Register" CssClass="btn sliver" onclick="btnSubmit_Click"  />
        </div>
    </dd>
  </dl>

</div> 
    </div>



    
    </form>
</body>
</html>
