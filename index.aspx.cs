using System;
using System.Web.UI;
using System.Web.Security;


public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //(new EpicorRequest()).GetEpicorRFQRFQANS();
        //(new EpicorRequest()).GetEpicorRFQVendPrice("1003", "GECCO1");
        //(new EpicorRequest()).GetEpicorRFQRFQANS("1003", "GECCO1");
        //(new EpicorRequest()).GetEpicorRFQRFHead();
        //(new EpicorRequest()).GetEpicorVenderBankList();
        //(new EpicorRequest()).GetEpicorSupplierNotice();
        //(new EpicorRequest()).GetEpicorRFQAttachmentBase64("108");
        //(new EpicorRequest()).GetEpicorRFQAttachment("");
        











        if (!Page.IsPostBack)
        {
            txtUserName.Value = Utils.GetCookie("RememberName");
        }
        //(new EpicorRequest()).GetCustomerCreditInfo("");
        //string tt =(new EpicorRequest()).CopyPart("C03", "P70201000737");
        




    }

    #region 登录系统=========================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, typeof(string), "Success", "$.dialog.agree( 'You must read and agree to the Privacy Policy<br> in order to proceed');", true);


        string userName = txtUserName.Value.Trim();
        string userPwd = txtPassword.Value.Trim();

        //判断登录信息
        ps_manager myuser = new ps_manager();
        string sqlGetUserID = "select  id  from [ps_manager] where user_name='" + userName + "'";
        int userid = Convert.ToInt16(DbHelperSQL.GetSingle(sqlGetUserID));
        myuser.GetModel(userid);
        if (myuser.password != null)
        {
            userPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(userPwd, "MD5");
            if (myuser.password.Trim() != userPwd)
            {
                //MessageBox.errorShow(this.Page, "User account or password is not correct！");
                ScriptManager.RegisterStartupScript(this, typeof(string), "Success", "$.dialog.alert( 'User account or password is not correct！');", true);
                return;
            }

            //判断账号是否被禁用
            if (Convert.ToInt32(myuser.is_lock) ==2)
            {
                //MessageBox.errorShow(this.Page, "You account is inactive！");
                ScriptManager.RegisterStartupScript(this, typeof(string), "Success", "$.dialog.alert( 'You account is inactive！');", true);
                return;
            }
            //ps_depot  myd = new ps_depot();
            //myd.GetModel(Convert.ToInt32(myuser.depot_id));

            ps_depot_category mydc = new ps_depot_category();
            mydc.GetModel(Convert.ToInt32(myuser.depot_category_id));

            ////判断账号对应的商家是否被禁用
            //if (Convert.ToInt32(myuser.depot_id) != 0 && Convert.ToInt32(myd.status) == 2)
            //{
            //    MessageBox.errorShow(this.Page, "您所在商家被禁用，请联系客服！");
            //    return;
            //}
            //写入登录日志
            ps_manager_log mylog = new ps_manager_log();
            mylog.user_id = userid;
            mylog.user_name = userName;
            mylog.action_type = "Login";
            mylog.add_time = DateTime.Now;
            mylog.remark = "Login system";
            mylog.user_ip = AXRequest.GetIP();
            mylog.Add();


            //写入Cookies
            Utils.WriteCookie("RememberName", userName, 30);
            Utils.WriteCookie("AdminName", userName, 30);
            Utils.WriteCookie("RoleID", myuser.role_id.ToString(), 30);
            Utils.WriteCookie("AID", myuser.id.ToString(), 30);
            Utils.WriteCookie("RealName", myuser.real_name==""? userName : myuser.real_name, 30);
            Utils.WriteCookie("DepotID", myuser.depot_id.ToString(), 30);
            Utils.WriteCookie("DepotCode", myuser.depot_id.ToString(), 30);
            //Utils.WriteCookie("ConpanyName", (myd.title.ToString() == "" ? (mydc.name==""?"所有公司":mydc.name) : myd.title.ToString()), 30);
            Utils.WriteCookie("ConpanyName", myuser.company.ToString() , 30);
            Utils.WriteCookie("ConpanyCode", myuser.company.ToString(), 30);
            Utils.WriteCookie("VendorID", myuser.vendor_id.ToString(), 30);
            Utils.WriteCookie("DepotCatID", myuser.depot_category_id.ToString(), 30);
            Utils.WriteCookie("IsDisplayPrice", myuser.is_displayprice.ToString(), 30);
            Utils.WriteCookie("CustomerSupportURL", myuser.customersupporturl.ToString(), 30);
            //写入Session
            Session["RememberName"] = userName;
            Session["AdminName"] = userName;
            Session["RoleID"] = myuser.role_id.ToString();
            Session["AID"] = myuser.id.ToString();
            Session["RealName"] = myuser.real_name == "" ? userName : myuser.real_name;
            Session["DepotID"] = myuser.depot_id.ToString();
            //Session["ConpanyName"] = (myd.title.ToString() == "" ? (mydc.name == "" ? "所有公司" : mydc.name) : myd.title.ToString());
            Session["ConpanyName"] = myuser.company.ToString();
            Session["ConpanyCode"] = myuser.company.ToString();
            Session["VendorID"] = myuser.vendor_id.ToString();
            Session["DepotCatID"] = myuser.depot_category_id.ToString();
            Session["IsDisplayPrice"] = myuser.is_displayprice.ToString();
            Session["CustomerSupportURL"] = myuser.customersupporturl.ToString();
            Session.Timeout = 45;

            //Response.Redirect("main.aspx");
            ScriptManager.RegisterStartupScript(this, typeof(string), "Success", "ShowDiv('MyDiv','fade')", true);
            //Response.Redirect("purchase/purchase_request2.aspx");

            return;
        }
        else
        {
            //MessageBox.errorShow(this.Page, "User account or password is not correct！");
            ScriptManager.RegisterStartupScript(this, typeof(string), "Success", "$.dialog.alert( 'User account or password is not correct！');", true);
            return;
        }
    }
    #endregion

    protected void lkDontAgress_Click(object sender, EventArgs e)
    {
        Utils.WriteCookie("AdminName", "AoXiang", -14400);
        Utils.WriteCookie("RoleID", "AoXiang", -14400);
        Utils.WriteCookie("AID", "AoXiang", -14400);
        Utils.WriteCookie("RealName", "AoXiang", -14400);
        Utils.WriteCookie("DepotID", "AoXiang", -14400);
        Utils.WriteCookie("DepotCode", "AoXiang", -14400);
        Utils.WriteCookie("ConpanyName", "AoXiang", -14400);
        Utils.WriteCookie("VendorID", "AoXiang", -14400);
        Utils.WriteCookie("DepotCatID", "AoXiang", -14400);
        Utils.WriteCookie("IsDisplayPrice", "AoXiang", -14400);
        Utils.WriteCookie("CustomerSupportURL", "AoXiang", -14400);


        Session["RememberName"] = null;
        Session["AdminName"] = null;
        Session["RoleID"] = null;
        Session["AID"] = null;
        Session["RealName"] = null;
        Session["DepotID"] = null;
        Session["ConpanyName"] = null;
        Session["VendorID"] = null;
        Session["DepotCatID"] = null;
        Session["IsDisplayPrice"] = null;
        Session["CustomerSupportURL"] = null;
    }
}
