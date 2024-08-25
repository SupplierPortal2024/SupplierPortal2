using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class sysmanager_my_info : System.Web.UI.Page
{

    ManagePage mym = new ManagePage();
    protected string changepassword = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        ////判断是否登录
        //if (!mym.IsAdminLogin())
        //{
        //    Response.Write("<script>parent.location.href='../index.aspx'</script>");
        //    Response.End();
        //}
        changepassword = AXRequest.GetQueryString("cg");

        if (changepassword == "1")
        {
            this.plPassword.Visible = true;
            this.btnSubmit.Visible = true;
            this.btnChangePassword.Visible = false;
            txtOldPassword.Focus();
        }

        if (!Page.IsPostBack)
        {
            ShowInfo(Convert.ToInt32(Session["AID"]));
        }
    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        ps_manager model = new ps_manager();
        model.GetModel(_id);

        
        Lituser_name.Text = model.user_name;
        Litreal_name.Text = model.real_name;
        txtEmail.Text = model.emailaddress;
        Litdepot_id.Text = model.depot_id.ToString();

        

        if (Convert.ToInt32(model.depot_id) !=100)
        {
            mdxx.Visible = true;
            //ps_depot model1 = new ps_depot();
            //model1.GetModel(Convert.ToInt32(model.depot_id));

            ps_epicor_vendor modelVendor = new ps_epicor_vendor();
            //modelVendor.GetModel(Convert.ToInt32(model.vendor_id));
            modelVendor.GetModelByVendorID(model.company, model.vendor_id);
            //if (modelVendor.Vendor_VendorID != null && modelVendor.Vendor_VendorID != "0" && modelVendor.Vendor_VendorID != "0")
            //{
            //    Response.Redirect("../sysmanager/vendor_edit2.aspx?action=Edit&companycode=" + modelVendor.Vendor_Company + "&vendorid=" + modelVendor.Vendor_VendorID + "");
            //    return;
            //}


            Litdepotname.Text = modelVendor.Vendor_Name;
            //Litcontact_name.Text = model1.contact_name;
            //Litcontact_tel.Text = model1.contact_mobile;
            //txtcontact_address.Text = model1.contact_address;
            //txtcontact_name.Text = model1.contact_name;
            //txtcontact_tel.Text = model1.contact_tel;

            //Litdepotname.Text = model1.title;
            //Litcontact_name.Text = model.contact_name;
            txtcontact_tel.Text = model.mobile;
            //txtcontact_address.Text = model1.contact_address;
            //txtcontact_name.Text = model1.contact_name;
            //txtcontact_tel.Text = model1.contact_tel;
        }
        else
            plPassword.Visible = true;

        

        if (Convert.ToInt32(model.depot_category_id) != 0)
        {
            bmxx.Visible = true;
            ps_depot_category model2 = new ps_depot_category();
            model2.GetModel(Convert.ToInt32(model.depot_category_id));
            Litdepot_category_name.Text = model2.title;
        }
    }
    #endregion

    //保存
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ps_manager model = new ps_manager();
        model.GetModel(Convert.ToInt32(Session["AID"]));

        if (txtOldPassword.Text.Trim() != "")
        {
            string userPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtOldPassword.Text.Trim(), "MD5");
            if (userPwd != model.password)
            {
                mym.JscriptMsg(this.Page, "Old password is no correct！", "", "Warning");
                return;
            }
            if (txtPassword.Text.Trim() != txtPassword1.Text.Trim())
            {
                mym.JscriptMsg(this.Page, "New password is not the same！", "", "Warning");
                return;
            }
            model.password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim(), "MD5");
            model.UpdateMY();
        }
        //model.mobile = txtmobile.Text.Trim();
        


        //model.id = Convert.ToInt32(Session["AID"]);

        //if (!model.UpdateMY())
        //{
        //    ps_depot model1 = new ps_depot();
        //    model1.id = Convert.ToInt32(Litdepot_id.Text);
        //    model1.contact_address = txtcontact_address.Text.Trim();
        //    model1.contact_name = txtcontact_name.Text.Trim();
        //    //model1.contact_mobile = txtmobile.Text.Trim();

        //    model1.UpdateAddress();

        //    mym.JscriptMsg(this.Page, "保存过程中发生错误！", "", "Error");
        //    return;
        //}
        //else
        //{
        //    ps_depot model1 = new ps_depot();
        //    //model1.id = Convert.ToInt32(Litdepot_id.Text);
        //    model1.GetModel(Convert.ToInt32(Litdepot_id.Text));
        //    model1.contact_address = txtcontact_address.Text.Trim();
        //    model1.contact_name = txtcontact_name.Text.Trim();
        //   // model1.contact_mobile = txtmobile.Text.Trim();

        //    model1.Update();
        //}
        mym.AddAdminLog("Update", "Update User info：User Name:" + Lituser_name.Text); //记录日志
        mym.JscriptMsg(this.Page, "password changed！", "", "Success");
    }


    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        this.plPassword.Visible = true;
        this.btnSubmit.Visible = true;
        this.btnChangePassword.Visible = false;
        txtOldPassword.Focus();
    }
}
