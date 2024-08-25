using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class resetpassword : System.Web.UI.Page
{
    protected int page;
    string defaultpassword = "0|0|0|0"; //默认显示密码
    private string action = "Add"; //操作类型
    private int id = 0;
    private string vendorid = "";
    private string companycode = "";
    private string connum = "";
    protected int totalCount;
    ManagePage mym = new ManagePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断权限
        ps_manager_role_value myrv = new ps_manager_role_value();
        int role_id = Convert.ToInt32(Session["RoleID"]);

        string _action = AXRequest.GetQueryString("action");
        this.page = AXRequest.GetQueryInt("page", 1);
        this.companycode = AXRequest.GetQueryString("companycode");
        this.vendorid = AXRequest.GetQueryString("vendorid");
    }



    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        ps_manager model = new ps_manager();
        DataSet ds = model.GetManagerVendorList(" user_name='" + txtUserName.Text + "' and emailaddress='" + txtEmailAddress.Text + "' ");
        bool isUpdate = false;

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["Vendor_PortalRegTempPW_c"].ToString().Trim() == txtTempPassword.Text.Trim())
            {
                model.password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
                isUpdate = model.UpdateMY();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Success", "alert( 'Password is updated.');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Temp password is not correct.');", true);
        }
        else
        {
            mym.JscriptMsg(this.Page, "User Name and email is not match！", "", "Error");
        }

        return isUpdate;
    }
    #endregion



    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        
        ps_manager model = new ps_manager();
        DataSet ds = model.GetManagerVendorList(" user_name='" + txtUserName.Text + "' and emailaddress='" + txtEmailAddress.Text + "' ");
        
        ds = model.GetManagerVendorList(" user_name='" + txtUserName.Text + "' and emailaddress='" + txtEmailAddress.Text + "' ");
        bool isUpdate = false;
        

        if (ds.Tables[0].Rows.Count > 0)
        {
            (new EpicorRequest()).GetEpicorVenderList(ds.Tables[0].Rows[0]["vendor_id"].ToString());
            model.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString()));
            if (ds.Tables[0].Rows[0]["Vendor_PortalRegTempPW_c"].ToString().Trim() == txtTempPassword.Text.Trim())
            {
                model.password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
                isUpdate = model.UpdateMY();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Success", "alert( 'Password reset.');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Temp password is not correct.');", true);
        }
        else
        {
            mym.JscriptMsg(this.Page, "User Name and email is not match！", "", "Error");
        }
        //mym.JscriptMsg(this.Page, "修改用户信息成功！", Utils.CombUrlTxt("manager_list.aspx", "page={0}", this.page.ToString()), "Success");
       
    }


}