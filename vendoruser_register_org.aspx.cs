using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class vendoruser_register_org : System.Web.UI.Page
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
                    ps_epicor_vendor modelEpicorVendor = new ps_epicor_vendor();
                    DataSet dsVendor = modelEpicorVendor.GetList(" Vendor_Company='" + companycode + "' and  Vendor_VendorID='" + vendorid + "'");
                    if (dsVendor.Tables[0].Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Vendor is not exist! Windows will close.');window.opener=null;window.open('','_self');window.close();", true);
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
                            this.txtRealName.Text = modelEpicorVendor.VendCnt_Name;

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Vendor contact num is not exist! Windows will close.');window.opener=null;window.open('','_self');window.close();", true);
                        }

                    }
                }
            }
            if (!string.IsNullOrEmpty(_action) && _action == "Edit")
            {
                this.action = "Edit";//修改类型
                if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
                {
                    mym.JscriptMsg(this.Page, "Parameter incorrect！", "back", "Error");
                    return;
                }

            }
            if (action == "Edit") //修改
            {
                txtUserName.Attributes.Remove("ajaxurl");
            }
            if (!Page.IsPostBack)
            {
                RoleBind(ddlRoleId, Convert.ToInt32(Session["RoleID"]));//绑定角色

                ddlRoleId.SelectedValue = "5";
                //if (Convert.ToInt32(Session["RoleID"]) == 4)//店长用户权限
                //{
                //    this.ddlRoleId.SelectedValue = "5";
                //    role.Visible = false;
                //    bm.Visible = false;
                //    md.Visible = false;
                //    CategoryBind(Convert.ToInt32(Session["DepotCatID"])); //绑定公司
                //    this.ddlCategoryId.SelectedValue = Session["DepotCatID"].ToString();
                //    DepotBind(Convert.ToInt32(Session["DepotCatID"])); //绑定商家
                //    VendorBind(Convert.ToInt32(Session["VendorID"])); //绑定供应商
                //    this.ddlDepotId.SelectedValue = Session["DepotID"].ToString();
                //}

                if (action == "Edit") //修改
                {
                    ShowInfo(this.id);
                    RptBind(" user_id=" + this.id, "id asc");
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

    #region 绑定商家=================================
    private void DepotBind(int _category_id)
    {
        ps_depot bll = new ps_depot();
        DataTable dt = bll.GetList(_category_id);
        this.ddlDepotId.Items.Clear();
        this.ddlDepotId.Items.Add(new ListItem("请选择所属经销商...", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["title"].ToString().Trim();
            this.ddlDepotId.Items.Add(new ListItem(Title, Id));
        }
    }
    #endregion

    #region 绑定供应商=================================
    private void VendorBind(int _category_id)
    {
        ps_vendor bll = new ps_vendor();
        DataTable dt = bll.GetListByCatID(_category_id);
        this.ddlVendorId.Items.Clear();
        this.ddlVendorId.Items.Add(new ListItem("请选择所属供应商...", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["VendorNum"].ToString();
            string Title = dr["name"].ToString().Trim();
            this.ddlVendorId.Items.Add(new ListItem(Title, Id));
        }
    }
    #endregion

    #region 角色类型=================================
    private void RoleBind(DropDownList ddl, int role_type)
    {
        ps_manager_role bll = new ps_manager_role();
        DataTable dt = bll.GetList("status=1 order by id desc").Tables[0];
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("请选择角色...", ""));
        foreach (DataRow dr in dt.Rows)
        {
            if (Convert.ToInt32(dr["role_type"]) > role_type)
            {
                ddl.Items.Add(new ListItem(dr["role_name"].ToString(), dr["id"].ToString()));
            }
        }
        
    }
    #endregion

    #region 绑定客服=================================
    private void BindCustomerSupport()
    {
        ps_depot_category bll = new ps_depot_category();
        DataTable dt = bll.GetCustomerSupportList(0);
        this.ddlCustomerSupport.Items.Clear();
        this.ddlCustomerSupport.Items.Add(new ListItem("请选择所属客服...", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string Title = dr["name"].ToString().Trim();
            this.ddlCustomerSupport.Items.Add(new ListItem(Title, Id));
        }
    }
    #endregion

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ps_manager model = new ps_manager();
        model.GetModel(_id);
        ddlRoleId.SelectedValue = model.role_id.ToString();
        BindCustomerSupport();

        //if (model.role_id == 2 || model.role_id == 3)
        if (model.role_id == 3)
        {
            bm.Visible = true;
            cu.Visible = true;
            md.Visible = false;
            vd.Visible = false;
            CategoryBind(Convert.ToInt32(Session["DepotCatID"])); //绑定公司
        }
        else if (model.role_id == 4)
        {
            bm.Visible = true;
            md.Visible = true;
            CategoryBind(Convert.ToInt32(Session["DepotCatID"])); //绑定公司
            //DepotBind(Convert.ToInt32(model.depot_category_id.ToString())); //绑定商家
        }
        else if (model.role_id == 5)
        {
            bm.Visible = true;
            vd.Visible = true;
            CategoryBind(Convert.ToInt32(Session["DepotCatID"])); //绑定公司
            //VendorBind(Convert.ToInt32(model.vendor_id.ToString())); //绑定供应商
        }
        else
        {
            bm.Visible = false;
            md.Visible = false;
            vd.Visible = false;
            CategoryBind(Convert.ToInt32(model.depot_category_id)); //绑定公司
        }
        this.ddlCategoryId.SelectedValue = model.depot_category_id.ToString();
        this.ddlCustomerSupport.SelectedValue = model.customersupportid.ToString();
        //ddlDepotId.SelectedValue = model.depot_id.ToString();
        this.txtCustomerID.Text = model.depot_id.ToString();
        this.txtCustomerName.Text = (new ps_depot()).GetTitle(Convert.ToInt32(model.depot_id));
        //ddlVendorId.SelectedValue = model.vendor_id.ToString();
        //ddlVendorId.SelectedValue = model.vendor_id.ToString();
        this.txtVendorID.Text = model.vendor_id.ToString();
        this.txtVendorName.Text = (new ps_vendor()).GetName(Convert.ToInt32(model.vendor_id));

        txtUserName.Text = model.user_name;
        //this.ddlRoleId.Enabled = false;
        if (_id == 1)//admin账号不能修改
        {
            txtUserName.ReadOnly = true;
        }

        if (!string.IsNullOrEmpty(model.password))
        {
            txtPassword.Attributes["value"] = txtPassword1.Attributes["value"] = defaultpassword;
        }
        txtRealName.Text = model.real_name;
        txtmobile.Text = model.mobile;
        txtEmailAddress.Text = model.emailaddress;
        txtremark.Text = model.remark;
        if (model.is_lock == 1)
        {
            cbIsLock.Checked = true;
        }
        else
        {
            cbIsLock.Checked = false;
        }
        if (model.is_displayprice == 1)
        {
            ckIsDisplayPrice.Checked = true;
        }
        else
        {
            ckIsDisplayPrice.Checked = false;
        }

    }

    private void RptBind(string _strWhere, string _orderby)
    {
        ps_manager_customer bll = new ps_manager_customer();
        this.rptList.DataSource = bll.GetList(100, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();
    }
    #endregion

    #region 增加操作=================================
    private bool DoAdd()
    {
        ps_manager model = new ps_manager();

        model.role_id = int.Parse(ddlRoleId.SelectedValue);
        //if (model.role_id == 4)
        //{
        //    if (txtCustomerID.Text.Trim() == "" || txtCustomerID.Text.Trim() == "0")
        //    {
        //        mym.JscriptMsg(this.Page, "请选择所属经销商！", "", "Error");
        //        return false;
        //    }
        //}
        //if (model.role_id == 5)
        //{
        //    if (txtVendorID.Text.Trim() == "" || txtVendorID.Text.Trim() == "0")
        //    {
        //        mym.JscriptMsg(this.Page, "请选择所属供应商！", "", "Error");
        //        return false;
        //    }
        //}
        //if (ddlCategoryId.SelectedValue != "")
        //{
        //    model.depot_category_id = int.Parse(ddlCategoryId.SelectedValue);
        //}
        //else
        //{
        //    model.depot_category_id = 0;
        //}

        //if (ddlDepotId.SelectedValue != "")
        //{
        //    model.depot_id = int.Parse(ddlDepotId.SelectedValue);
        //}
        //else
        //{
        //    model.depot_id = 0;
        //}
        //if (ddlDepotId.SelectedValue != "")
        //{
        //    model.depot_id = int.Parse(txtCustomerID.Text.Trim());
        //}
        //else
        //{
        //    model.depot_id = 0;
        //}
        //if (ddlVendorId.SelectedValue != "")
        //{
        //    model.vendor_id = int.Parse(ddlVendorId.SelectedValue);
        //}
        //else
        //{
        //    model.depot_id = 0;
        //}
        ps_depot_category modalCompany = new ps_depot_category();
        modalCompany.GetCompanyIDByCode(this.companycode);
        if (modalCompany != null)
            model.depot_category_id = modalCompany.id;
        else
            model.depot_category_id = 0;

        if (txtVendorName.Text.Trim() != "")
        {
            model.vendor_id = txtVendorID.Text.Trim();
        }
        else
        {
            model.vendor_id = "0";
        }

        //检测用户名是否重复
        if (model.Exists(txtUserName.Text.Trim()))
        {
            mym.JscriptMsg(this.Page, "User name already exist.", "", "Error");
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
        model.customersupportid = ddlCustomerSupport.SelectedValue;


        if (cbIsLock.Checked == true)
        {
            model.is_lock = 1;
        }
        else
        {
            model.is_lock = 2;
        }

        if (ckIsDisplayPrice.Checked == true)
        {
            model.is_displayprice = 1;
        }
        else
        {
            model.is_displayprice = 0;
        }
        if (model.Add() > 0)
        {
            //mym.AddAdminLog("增加", "添加用户：" + txtRealName.Text); //记录日志
            return true;
        }

        return false;
    }
    #endregion

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;

        ps_manager model = new ps_manager();
        model.GetModel(_id);

        model.role_id = int.Parse(ddlRoleId.SelectedValue);
        if (model.role_id == 4)
        {
            if (txtCustomerID.Text.Trim() == "" || txtCustomerID.Text.Trim() == "0")
            {
                mym.JscriptMsg(this.Page, "请选择所属经销商！", "", "Error");
                return false;
            }
        }
        if (model.role_id == 5)
        {
            if (txtVendorID.Text.Trim() == "" || txtVendorID.Text.Trim() == "0")
            {
                mym.JscriptMsg(this.Page, "请选择所属供应商！", "", "Error");
                return false;
            }
        }
        if (ddlCategoryId.SelectedValue != "")
        {
            model.depot_category_id = int.Parse(ddlCategoryId.SelectedValue);
        }
        else
        {
            model.depot_category_id = 0;
        }

        //if (ddlDepotId.SelectedValue != "")
        if (txtCustomerID.Text.Trim() != "")
        {
            //model.depot_id = int.Parse(ddlDepotId.SelectedValue);
            model.depot_id = int.Parse(txtCustomerID.Text.Trim());
        }
        else
        {
            model.depot_id = 0;
        }

        //if (ddlVendorId.SelectedValue != "")
        //{
        //    model.vendor_id = int.Parse(ddlVendorId.SelectedValue);
        //}
        //else
        //{
        //    model.vendor_id = 0;
        //}
        if (txtVendorName.Text.Trim() != "")
        {
            model.vendor_id = txtVendorID.Text.Trim();
        }
        else
        {
            model.vendor_id = "0";
        }

        if (model.role_id != 4)
        {
            model.depot_id = 0;
        }
        if (model.role_id != 5)
        {
            model.vendor_id = "0";
        }

        if (ckIsDisplayPrice.Checked == true)
        {
            model.is_displayprice = 1;
        }
        else
        {
            model.is_displayprice = 0;
        }

        //检测用户名是否重复
        if (model.ExistsE(txtUserName.Text.Trim(), _id))
        {
            mym.JscriptMsg(this.Page, "用户名已经存在，请更换！", "", "Error");
            return false;
        }
        model.user_name = txtUserName.Text.Trim();

        //判断密码是否更改
        if (txtPassword.Text.Trim() != defaultpassword)
        {
            model.password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
        }
        model.real_name = txtRealName.Text.Trim();
        //model.add_time = DateTime.Now;
        model.mobile = txtmobile.Text.Trim();
        model.emailaddress = txtEmailAddress.Text.Trim();
        model.remark = txtremark.Text.Trim();
        model.customersupportid = ddlCustomerSupport.SelectedValue;


        if (cbIsLock.Checked == true)
        {
            model.is_lock = 1;
        }
        else
        {
            model.is_lock = 2;
        }

        if (model.Update())
        {
            mym.AddAdminLog("修改", "修改用户:" + txtRealName.Text); //记录日志
            result = true;
        }

        return result;
    }
    #endregion


    //筛选角色
    protected void ddlRoleId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRoleId.SelectedValue != "")
        {
            //if (Convert.ToInt32(ddlRoleId.SelectedValue) == 2 || Convert.ToInt32(ddlRoleId.SelectedValue) == 3)
            if (Convert.ToInt32(ddlRoleId.SelectedValue) == 3)
            {
                bm.Visible = true;
                md.Visible = false;
                vd.Visible = false;
                this.ddlCategoryId.Items.Clear();
                this.ddlCategoryId.Items.Add(new ListItem("请选择所属公司...", ""));
                CategoryBind(Convert.ToInt32(Session["DepotCatID"])); //绑定公司
                //this.ddlDepotId.Items.Clear();
                //this.ddlDepotId.Items.Add(new ListItem("请选择所属经销商...", ""));
                txtCustomerID.Text = "0";
                txtCustomerName.Text = "";
            }
            else if (Convert.ToInt32(ddlRoleId.SelectedValue) == 4)
            {
                bm.Visible = true;
                md.Visible = true;
                vd.Visible = false;
                CategoryBind(Convert.ToInt32(Session["DepotCatID"])); //绑定公司
                //this.ddlDepotId.Items.Clear();
                //this.ddlDepotId.Items.Add(new ListItem("请选择所属经销商...", ""));
                txtCustomerID.Text = "0";
                txtCustomerName.Text = "";
            }
            else if (Convert.ToInt32(ddlRoleId.SelectedValue) == 5)
            {
                bm.Visible = true;
                md.Visible = false;
                vd.Visible = true;
                CategoryBind(Convert.ToInt32(Session["DepotCatID"])); //绑定公司
                //this.ddlVendorId.Items.Clear();
                //this.ddlVendorId.Items.Add(new ListItem("请选择所属供应商...", ""));
                this.txtVendorID.Text = "";
                this.txtVendorName.Text = "";
            }
            else
            {
                md.Visible = false;
                vd.Visible = false;
            }
        }

    }

    //筛选地区
    protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategoryId.SelectedValue != "")
        {

            if (ddlRoleId.SelectedValue == "5")
            {
                vd.Visible = true;
                //VendorBind(Convert.ToInt32(ddlCategoryId.SelectedValue));
            }
            else
            {
                md.Visible = true;
                //DepotBind(Convert.ToInt32(ddlCategoryId.SelectedValue));
            }
        }
        else
        {
            //this.ddlDepotId.Items.Clear();
            //this.ddlDepotId.Items.Add(new ListItem("请选择所属经销商...", ""));
            txtCustomerID.Text = "0";
            txtCustomerName.Text = "";
        }
    }

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == "Edit") //修改
        {
            if (!DoEdit(this.id))
            {
                mym.JscriptMsg(this.Page, "Error on process！", "", "Error");
                return;
            }
            mym.JscriptMsg(this.Page, "修改用户信息成功！", Utils.CombUrlTxt("manager_list.aspx", "page={0}", this.page.ToString()), "Success");
        }
        else //添加
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
                    if (modelEpicorVendor.Vendor_PortalRegTempPW_c.Trim() != "")
                    {
                        if (this.txtTempPassword.Text.Trim() != modelEpicorVendor.Vendor_PortalRegTempPW_c)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( 'Temp password is not correct. ');", true);
                            return;
                        }
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


    protected void btnAddCust_Click(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;


        if (txtCustID.Text.Trim() != "")
        {
            ps_manager_customer modelManagerCustomer = new ps_manager_customer();
            if (modelManagerCustomer.CustExists(this.id, Convert.ToInt32(txtCustID.Text)) == true)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( '客户已绑定！');", true);
                return;
            }

            modelManagerCustomer.user_id = this.id;
            modelManagerCustomer.cust_id = Convert.ToInt32(txtCustID.Text);
            mym.AddAdminLog("用户", "绑定经销商，经销商：" + this.txtCustID.Text); //记录日志
            if (modelManagerCustomer.Add() > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Success", "alert( '绑定经销商成功！');window.location='" + Utils.CombUrlTxt("manager_edit.aspx", "action={0}&id={1}&page={2}", "Edit", this.id.ToString(), this.page.ToString()) + "'", true);
                return;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( '保存过程中发生错误！');", true);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert( '请选择经销商！');", true);
            return;
        }

    }


    protected void lbtnDelCust_Click(object sender, EventArgs e)
    {
        // 当前点击的按钮
        LinkButton lb = (LinkButton)sender;
        int custid = int.Parse(lb.CommandArgument);
        ps_manager_customer bll = new ps_manager_customer();
        bll.Delete(custid);

        ScriptManager.RegisterStartupScript(this, typeof(string), "Success", "alert( '删除经销商完成！');window.location='" + Utils.CombUrlTxt("manager_edit.aspx", "action={0}&id={1}&page={2}", "Edit", this.id.ToString(), this.page.ToString()) + "'", true);
    }

}