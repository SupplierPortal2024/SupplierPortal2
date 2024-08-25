
using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class forgetpassword : System.Web.UI.Page
{

    ManagePage mym = new ManagePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
        }
    }


    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ps_manager model = new ps_manager();
        DataSet ds =  model.GetManagerVendorList(" user_name='" + txtUserName.Text + "' and emailaddress='" + txtEmail.Text + "' ");

        if (ds.Tables[0].Rows.Count > 0)
        {
            string vendornum =  (new EpicorRequest()).PostVendorPortalResetPWTimeToEpicor(ds.Tables[0].Rows[0]["Vendor_Company"].ToString(), ds.Tables[0].Rows[0]["Vendor_VendorID"].ToString());
            //mym.AddAdminLog("修改", "修改个人信息：用户名:" + Lituser_name.Text); //记录日志
            //mym.JscriptMsg(this.Page, "password changed！", "", "Success");
            if(vendornum!="")
                ScriptManager.RegisterStartupScript(this, typeof(string), "Success", "alert( 'Email sent. Please change the password by email.');", true);
            else
                ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Failed.');window.location='index.aspx';", true);
        }
        else
        {
            mym.JscriptMsg(this.Page, "User Name and email is not match！", "", "Error");
            
        }
    }


    protected void btnChangePassword_Click(object sender, EventArgs e)
    {

        this.btnSubmit.Visible = true;
        this.btnChangePassword.Visible = false;
    }
}
