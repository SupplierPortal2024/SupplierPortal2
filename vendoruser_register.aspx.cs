
using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class vendoruser_register : System.Web.UI.Page
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
        //this.connum = AXRequest.GetQueryString("connum");

        if (!IsPostBack)
        {
            if (companycode == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Company is not exist! Windows will close.');window.opener=null;window.open('','_self');window.close();", true);
            }
            else
            {
                
                if (vendorid == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Vendor is not exist! Windows will close.');window.opener=null;window.open('','_self');window.close();", true);
                }
                else
                {
                    (new EpicorRequest()).GetEpicorVenderList(vendorid);
                    ps_epicor_vendor modelEpicorVendor = new ps_epicor_vendor();
                    DataSet dsVendor = modelEpicorVendor.GetList(" Vendor_Company='" + companycode + "' and  Vendor_VendorID='" + vendorid + "'");
                    if (dsVendor.Tables[0].Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Vendor is not exist! Windows will close.');window.open('','_self').close();", true);
                    }
                    else
                    {
                        string vendornum = dsVendor.Tables[0].Rows[0]["Vendor_VendorNum"].ToString();
                        modelEpicorVendor.GetModelByVendorID(this.companycode, this.vendorid);
                        if (modelEpicorVendor != null)
                        {
                            //this.txtVendorID.Text = dsVendor.Tables[0].Rows[0]["vendorid"].ToString();
                            this.txtVendorID.Text = modelEpicorVendor.Vendor_VendorID;
                            this.txtVendorName.Text = modelEpicorVendor.Vendor_Name;

                            //this.txtUserName.Text = this.companycode + vendornum + this.vendorcontractid;
                            this.txtUserName.Text = this.vendorid;
                            this.txtEmailAddress.Text = modelEpicorVendor.Vendor_EMailAddress;
                            this.txtmobile.Text = modelEpicorVendor.Vendor_PhoneNum;
                            this.txtRealName.Text = modelEpicorVendor.Vendor_Name;
                            this.txtAddress.Text = modelEpicorVendor.Vendor_Address1;

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Vendor contact num is not exist! Windows will close.');window.opener=null;window.open('','_self');window.close();", true);
                        }

                    }
                }
            }

           
        }
    }

    #region 绑定公司=================================
    private void CategoryBind(int _category_id)
    {
        ps_depot_category bll = new ps_depot_category();
        //DataTable dt = bll.GetList(_category_id);
        DataTable dt = bll.GetList(0);
        this.ddlCategoryId.Items.Clear();
        this.ddlCategoryId.Items.Add(new ListItem("请选择所属公司...", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["title"].ToString().Trim() + "--" + dr["name"].ToString().Trim();
            this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
        }
    }
    #endregion











    #region 增加操作=================================
    private bool DoAdd()
    {
        ps_manager model = new ps_manager();

        //if (txtVendorID.Text.Trim() == "" || txtVendorID.Text.Trim() == "0")
        //{
        //    mym.JscriptMsg(this.Page, "请选择所属供应商！", "", "Error");
        //    return false;
        //}
       
        if (txtVendorName.Text.Trim() != "")
        {
            model.vendor_id = txtVendorID.Text.Trim();
        }
        else
        {
            model.vendor_id = "";
        }

        ps_depot_category modalCompany = new ps_depot_category();
        model.depot_category_id = modalCompany.GetCompanyIDByCode(this.companycode); ;


        ps_epicor_vendor modelEpicorVendor = new ps_epicor_vendor();
        DataSet dsVendor = modelEpicorVendor.GetList(" Vendor_Company='" + companycode + "' and  Vendor_VendorID='" + vendorid + "'");
        if (dsVendor.Tables[0].Rows.Count > 0)
        {
            //if(dsVendor.Tables[0].Rows[0]["Vendor_PortalRegTempPW_c"].ToString()!="")
            if (txtTempPassword.Text.Trim() != dsVendor.Tables[0].Rows[0]["Vendor_PortalRegTempPW_c"].ToString())
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Email address is not match.');", true);
            }
            //if (dsVendor.Tables[0].Rows[0]["Vendor_PortalRegTempPW_c"].ToString() != "")
            if (txtEmailAddress.Text.Trim() != dsVendor.Tables[0].Rows[0]["Vendor_PortalRegEmailAddress_c"].ToString())
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Email address is not match.');", true);
            }
                
        }

        //检测用户名是否重复
        if (model.Exists(txtUserName.Text.Trim()))
        {
            mym.JscriptMsg(this.Page, "User name exist！", "", "Error");
            return false;
        }
        model.user_name = txtUserName.Text.Trim();

        model.password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
        model.real_name = txtRealName.Text.Trim();
        model.add_time = DateTime.Now;
        model.mobile = txtmobile.Text.Trim();
        model.emailaddress = txtEmailAddress.Text.Trim();

        model.position = txtPosition.Text.Trim();
        model.address = txtAddress.Text.Trim();
        model.remark = txtremark.Text.Trim();
        model.company = this.companycode;
        model.role_id = 5;//vendor user


        if (cbIsLock.Checked == true)
        {
            model.is_lock = 1;
        }
        else
        {
            model.is_lock = 2;
        }

        int userID = model.Add();
        if (userID > 0)
        {
            //mym.AddAdminLog("增加", "添加用户：" + txtRealName.Text); //记录日志
            ////写入登录日志
            ps_manager_log mylog = new ps_manager_log();
            mylog.user_id = userID;
            mylog.user_name = txtUserName.Text.Trim();
            mylog.action_type = "User";
            mylog.add_time = DateTime.Now;
            mylog.remark = "Register new user(User Name:" + txtUserName.Text + ")";
            mylog.user_ip = AXRequest.GetIP();
            mylog.Add();
            return true;
        }

        return false;
    }
    #endregion



    //筛选地区
    protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }


    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if ((new ps_manager()).Exists(this.txtUserName.Text.Trim()))
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'User account already exist. ');", true);
        }
        else
        {
            ps_epicor_vendor modelEpicorVendor = new ps_epicor_vendor();
            modelEpicorVendor.GetModelByVendorID(this.companycode, this.vendorid);
            if (modelEpicorVendor != null)
            {
                
                if (this.txtTempPassword.Text.Trim() != modelEpicorVendor.Vendor_PortalRegTempPW_c)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Email address is not match.');", true);
                    return;
                }

                if (this.txtEmailAddress.Text.Trim() != modelEpicorVendor.Vendor_PortalRegEmailAddress_c)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Temp password  is not match.');", true);
                    return;
                }

                if (!DoAdd())
                {
                    mym.JscriptMsg(this.Page, "Error on process！", "", "Error");
                    return;
                }
                ScriptManager.RegisterStartupScript(this, typeof(string), "Success", "alert( 'Vendor user register success. Please use user accout to login');window.location='index.aspx';", true);
            }
        }
    }



}