using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class sysmanager_vendor_edit2 : System.Web.UI.Page
{
    protected int page;
    private string action = ""; //Type
    private string companycode = "";
    private string vendorid = "";
    protected int totalCount;
    ManagePage mym = new ManagePage();
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='../index.aspx'</script>");
            Response.End();
        }
        //判断权限
        ps_manager_role_value myrv = new ps_manager_role_value();
        int role_id = Convert.ToInt32(Session["RoleID"]);
        int nav_id = 46;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }
        string _action = AXRequest.GetQueryString("action");
        this.page = AXRequest.GetQueryInt("page", 1);
        if (!string.IsNullOrEmpty(_action) && _action == "Edit")
        {
            this.action = "Edit";//修改类型
            this.companycode = AXRequest.GetQueryString("companycode");
            this.vendorid = AXRequest.GetQueryString("vendorid");
            if (companycode=="" || vendorid=="")
            {
                mym.JscriptMsg(this.Page, "Wrong parameter！", "back", "Error");
                return;
            }

        }
        if (!Page.IsPostBack)
        {
            if (action == "Edit") //修改
            {
                //(new EpicorRequest()).GetEpicorVenderList(vendorid);
                ShowInfo(companycode,vendorid);
                Focus myFocus = new Focus();
                myFocus.SetEnterControl(this.txtSupplierName);


            }
        }
    }


    #region 赋值操作=================================
    private void ShowInfo(string _companycode, string _vendorid)
    {
        (new EpicorRequest()).GetEpicorCurrencyList();
        (new EpicorRequest()).GetEpicorPayMethodList();
        (new EpicorRequest()).GetEpicorCountryList();
        BindCountry(); //Bind Country
        BindCurrency(); //Bind Currency
        BindPayMethod(); //Bind PayMethod

        ps_epicor_vendor modelvendor = new ps_epicor_vendor();
        modelvendor.GetModelByVendorID(_companycode, _vendorid);



        this.txtSupplierID.Text = modelvendor.Vendor_VendorID.ToString();
        this.txtSupplierName.Text = modelvendor.Vendor_Name.ToString();
        this.ddlCurrency.SelectedValue = modelvendor.Vendor_CurrencyCode.ToString();
        this.txtTerms.Text = modelvendor.PurTerms_Description.ToString();
        this.txtCompanyWebsite.Text = modelvendor.Vendor_Website_c.ToString();

        this.txtBRNumber.Text = modelvendor.Vendor_BRNum_c.ToString();
        this.txtBRExpireDate.Value = (modelvendor.Vendor_BRExpiryDate_c==null || modelvendor.Vendor_BRExpiryDate_c==new DateTime(9999,12,30)) ? "" : Convert.ToDateTime(modelvendor.Vendor_BRExpiryDate_c).ToString("yyyy-MM-dd");

        this.txtCRNumber.Text = modelvendor.Vendor_OrgRegCode.ToString();
        this.txtPostCode.Text = modelvendor.Vendor_ZIP.ToString();
        this.lbApprove.Text = modelvendor.Vendor_Approved.ToString();

        this.txtPhone.Text = modelvendor.Vendor_PhoneNum.ToString();
        this.txtFax.Text = modelvendor.Vendor_FaxNum.ToString();
        this.txtEmail.Text = modelvendor.Vendor_EMailAddress.ToString();
        this.txtAddress1.Text = modelvendor.Vendor_Address1.ToString();
        this.txtAddress2.Text = modelvendor.Vendor_Address2.ToString();
        this.txtAddress3.Text = modelvendor.Vendor_Address3.ToString();
        this.txtCity.Text = modelvendor.Vendor_City.ToString();
        this.txtState.Text = modelvendor.Vendor_State.ToString();
        this.ddlCountry.SelectedValue = modelvendor.Vendor_CountryNum.ToString();
        //this.txtdw.Text = model1.dw;
        //this.txtgo_price.Text = MyConvert(model1.go_price.ToString());
        //this.txtsalse_price.Text = MyConvert(model1.salse_price.ToString());
        //this.txtproduct_num.Text = model1.product_num.ToString();
        //this.dw = model1.dw;
        //this.txtSpecification.Text = model1.specification.ToString();
        //this.txtCommercialStyle.Text = model1.commercialStyle.ToString();
        //this.cbIsActive.Checked = model1.status == 0 ? true : false;

        //txtBankCode,txtBankName,txtPaymentMethod,txtBankAccountName,txtBankAccountCode,ddlBankCountry,txtIBANABABSBCode,txtSwiftCode

        this.txtBankCode.Text = modelvendor.VendorBank_BankID.ToString();
        this.txtBankName.Text = modelvendor.VendorBank_BankName.ToString();
        this.ddlPaymentMethod.SelectedValue = modelvendor.VendorBank_PayMethodType.ToString();
        this.txtBankAccountName.Text = modelvendor.VendorBank_NameOnAccount.ToString();
        this.txtBankAccountCode.Text = modelvendor.VendorBank_BankAcctNumber.ToString();
        this.txtSwiftCode.Text = modelvendor.VendorBank_SwiftNum.ToString();
        this.txtIBANABABSBCode.Text = modelvendor.VendorBank_IBANABABSBCode.ToString();
        this.ddlBankCountry.SelectedValue = modelvendor.VendorBank_CountryNum.ToString();

        //ps_epicor_vendorbank modelvendorbank = new ps_epicor_vendorbank();
        //modelvendorbank.GetModelByVendorID(_companycode, modelvendor.Vendor_VendorNum.ToString());


        RptBind(" Vendor_VendorID ='" + this.vendorid + "' and Vendor_Company ='" + this.companycode + "'  and VendCnt_ConNum <>'' and status<>-1", "VendCnt_ConNum asc");
    }
    #endregion

    private void RptBind(string _strWhere, string _orderby)
    {
        ps_epicor_vendor bll = new ps_epicor_vendor();

        this.rptList.DataSource = bll.GetList(100, 1, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();
    }

    #region 绑定地区=================================
    private void BindCountry()
    {
        ps_epicor_country bll = new ps_epicor_country();
        DataTable dt = bll.GetList("").Tables[0];
        this.ddlCountry.Items.Clear();
        this.ddlCountry.Items.Add(new ListItem("==Select Country==", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["Country_CountryNum"].ToString();
            string name = dr["Country_Description"].ToString().Trim();
            this.ddlCountry.Items.Add(new ListItem(name, Id));
        }

        
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["Country_CountryNum"].ToString();
            string name = dr["Country_Description"].ToString().Trim();
            this.ddlBankCountry.Items.Add(new ListItem(name, Id));
        }

    }
    private void BindCurrency()
    {
        ps_epicor_currency bll = new ps_epicor_currency();
        DataTable dt = bll.GetList("").Tables[0];
        this.ddlCurrency.Items.Clear();
        this.ddlCurrency.Items.Add(new ListItem("==Select Currency==", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["Currency_CurrencyCode"].ToString();
            string name = dr["Currency_CurrencyCode"].ToString().Trim();
            this.ddlCurrency.Items.Add(new ListItem(name, Id));
        }
    }

    private void BindPayMethod()
    {
        ps_epicor_paymethod bll = new ps_epicor_paymethod();
        DataTable dt = bll.GetList("").Tables[0];
        this.ddlPaymentMethod.Items.Clear();
        this.ddlPaymentMethod.Items.Add(new ListItem("==Select PayMethod==", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["PayMethod_PMUID"].ToString();
            string name = dr["PayMethod_Name"].ToString().Trim();
            this.ddlPaymentMethod.Items.Add(new ListItem(name, Id));
        }
    }

    #endregion

    #region Update=================================
    private bool DoEdit(string _companycode, string _vendorid, int _status)
    {
        bool result = false;
        ps_epicor_vendor modelvendor = new ps_epicor_vendor();
        modelvendor.GetModelByVendorID(_companycode, _vendorid);

        modelvendor.Vendor_PhoneNum = this.txtPhone.Text;
        modelvendor.Vendor_FaxNum = this.txtFax.Text;
        modelvendor.Vendor_EMailAddress = this.txtEmail.Text;
        modelvendor.Vendor_Address1 = this.txtAddress1.Text;
        modelvendor.Vendor_Address2 = this.txtAddress2.Text;
        modelvendor.Vendor_Address3 = this.txtAddress3.Text;

        modelvendor.Vendor_BRNum_c = this.txtBRNumber.Text;
        modelvendor.Vendor_BRExpiryDate_c = this.txtBRExpireDate.Value != "" ? Convert.ToDateTime(this.txtBRExpireDate.Value) : new DateTime(9999, 12, 31);
        modelvendor.Vendor_OrgRegCode = this.txtCRNumber.Text;

        modelvendor.Vendor_City = this.txtCity.Text;
        modelvendor.Vendor_State = this.txtState.Text;
        modelvendor.Vendor_CountryNum = this.ddlCountry.SelectedValue;

        modelvendor.Vendor_ZIP = this.txtPostCode.Text;
        modelvendor.Vendor_Website_c = this.txtCompanyWebsite.Text;
        modelvendor.PurTerms_Description = this.txtTerms.Text;

        modelvendor.Vendor_CurrencyCode = this.ddlCurrency.SelectedValue;

        modelvendor.VendorBank_BankID = this.txtBankCode.Text.Trim();
        modelvendor.VendorBank_BankName = this.txtBankName.Text.Trim();
        modelvendor.VendorBank_PayMethodType = this.ddlPaymentMethod.SelectedValue;
        modelvendor.VendorBank_NameOnAccount = this.txtBankAccountName.Text.Trim();
        modelvendor.VendorBank_BankAcctNumber = this.txtBankAccountCode.Text.Trim();
        modelvendor.VendorBank_SwiftNum = this.txtSwiftCode.Text.Trim();
        //modelvendor.VendorBank_BankID = this.txtBankCode.Text.Trim();
        modelvendor.VendorBank_CountryNum = this.ddlBankCountry.SelectedValue;
        modelvendor.VendorBank_IBANABABSBCode = this.txtIBANABABSBCode.Text.Trim();
        modelvendor.Status = _status;


        modelvendor.UpdateVendorHeadByCompanyAndVerdorID(modelvendor.Vendor_Company,modelvendor.Vendor_VendorID);
        result = modelvendor.Update();
        modelvendor.UpdateVendorStatusByCompanyAndVerdorID(_companycode, _vendorid, _status);
        //(new EpicorRequest()).PostVendorToEpicor(modelvendor.Vendor_Company, modelvendor.Vendor_VendorID);

        return result;
    }

    
    #endregion





    //Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int intPrimaryContactCount = 0;
        foreach (RepeaterItem rptitem in this.rptList.Items)
        {
            CheckBox ckPrimaryContact1 = rptitem.FindControl("ckPrimaryContact") as CheckBox;
            if (ckPrimaryContact1.Checked)
                intPrimaryContactCount++;
        }

        if (intPrimaryContactCount > 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "$.dialog.alert( 'Only one contact can set as primary contact！');", true);
            return;
        }
        else
        {
            if (action == "Edit") //Edit
            {
                string strSaveMessage = SaveContact();
                if (strSaveMessage != "")
                {
                    mym.JscriptMsg(this.Page, strSaveMessage, "", "Error");
                    return;
                }
                else
                {
                    if (!DoEdit(companycode, vendorid, 1))
                    {
                        mym.JscriptMsg(this.Page, "Error on process！", "", "Error");
                        return;
                    }
                    mym.JscriptMsg(this.Page, "Supplier saved！", "", "Success");
                }
            }
            else //Error
            {
                mym.JscriptMsg(this.Page, "Error on process！", "", "Error");
                return;
            }
        }
    }
    //Submit
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (action == "Edit") //Edit
        {
            string strSaveMessage = SaveContact();
            if (strSaveMessage != "")
            {
                mym.JscriptMsg(this.Page, strSaveMessage, "", "Error");
                return;
            }
            else
            {
                if (!DoEdit(companycode, vendorid, 2))
                {
                    mym.JscriptMsg(this.Page, "Error on process！", "", "Error");
                    return;
                }

                //(new EpicorRequest()).PostVendorToEpicor(companycode, vendorid);
                (new EpicorRequest()).PostVendorStatusToEpicor(companycode, vendorid);
                mym.JscriptMsg(this.Page, "Supplier submitted！", "", "Success");
            }
        }
        else //Error
        {
            mym.JscriptMsg(this.Page, "Error on process！", "", "Error");
            return;
        }
    }

    protected void lbtnUpdateContact_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        int ConNum = int.Parse(lb.CommandArgument);
        ps_epicor_vendor bllVendor = new ps_epicor_vendor();
        bllVendor.GetModelByVendorID(companycode, vendorid);
        bllVendor.GetModelByVendorIDAndConNum(bllVendor.Vendor_Company, bllVendor.Vendor_VendorID, ConNum.ToString());
        txtContactNumber.Text = bllVendor.VendCnt_ConNum;
        txtContactName.Text = bllVendor.VendCnt_Name;
        txtContactFunc.Text = bllVendor.VendCnt_Func;
        txtContactPhone.Text = bllVendor.VendCnt_PhoneNum;
        txtContactCellPhone.Text = bllVendor.VendCnt_CellPhoneNum;
        txtContactEmail.Text = bllVendor.VendCnt_EmailAddress;
        ckContactSendRFQ.Checked = bllVendor.VendCnt_UD_RFQRecipent_c.Trim() == "True";
        ckContactSendPO.Checked = bllVendor.VendCnt_UD_PORecipient_c.Trim() == "True";
        ckPrimaryContact.Checked = bllVendor.Calculated_PrimaryContact.Trim() == "True";

        //txtContactNumber.Enabled = true;
        txtContactName.Enabled = true;
        txtContactFunc.Enabled = true;
        txtContactPhone.Enabled = true;
        txtContactCellPhone.Enabled = true;
        txtContactEmail.Enabled = true;
        ckContactSendRFQ.Enabled = true;
        ckContactSendPO.Enabled = true;
        ckPrimaryContact.Enabled = true;

    }

    protected void btnSaveContact_Click(object sender, EventArgs e)
    {
        int intPrimaryContactCount = 0;
        foreach (RepeaterItem rptitem in this.rptList.Items)
        {
            CheckBox ckPrimaryContact1 = rptitem.FindControl("ckPrimaryContact") as CheckBox;
            if (ckPrimaryContact1.Checked)
                intPrimaryContactCount++;
        }

        if (intPrimaryContactCount > 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "$.dialog.alert( 'Only one contact can set as primary contact！');", true);
            return;
        }
        else
        {
            SaveContact();
            mym.JscriptMsg(this.Page, "Edit supplier success！", "", "Success");
        }

    }


    protected void btnDeleteContact_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string connum = btn.CommandArgument;
        ps_epicor_vendor modelvendor = new ps_epicor_vendor();
        modelvendor.DeleteByVendorNumAndCntNum(this.vendorid, connum);
        RptBind(" Vendor_VendorID ='" + this.vendorid + "' and Vendor_Company ='" + this.companycode + "'  and VendCnt_ConNum <>'' and status<>-1 ", "VendCnt_ConNum asc");
        mym.JscriptMsg(this.Page, "Contact deleted！", "", "Success");
        //SaveContact();
        //mym.JscriptMsg(this.Page, "Edit supplier success！", "", "Success");

    }

    protected void btnAddContact_Click(object sender, EventArgs e)
    {

        if (txtContactName.Text.Trim() != "")
        {
            ps_epicor_vendor modelvendor = new ps_epicor_vendor();
            DataSet ds = null;
            ds = modelvendor.GetList(100, 1, " Vendor_VendorID = '" + this.vendorid + "'  and VendCnt_Name='" + txtContactName.Text.Trim() + "' ", " ID ", out this.totalCount);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "$.dialog.alert( 'Contact name already exist.');", true);
                return;
            }

            if (this.ckPrimaryContact.Checked == true)
            {
                ds = modelvendor.GetList(100, 1, " Vendor_VendorID = '" + this.vendorid + "'  and Calculated_PrimaryContact='True' ", " ID ", out this.totalCount);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "$.dialog.alert( 'Only one can set one primary contact.');", true);
                    return;
                }
            }
            modelvendor.GetModelByVendorID(this.companycode, vendorid);
            string maxVendorConNum = modelvendor.GetMaxVendorConNumByVendorID(vendorid);
            modelvendor.GetModelByVendorIDAndConNum(modelvendor.Vendor_Company, modelvendor.Vendor_VendorID, this.txtContactNumber.Text.ToString());



            modelvendor.Vendor_PhoneNum = this.txtPhone.Text;
            modelvendor.Vendor_FaxNum = this.txtFax.Text;
            modelvendor.Vendor_EMailAddress = this.txtEmail.Text;
            modelvendor.Vendor_Address1 = this.txtAddress1.Text;
            modelvendor.Vendor_Address2 = this.txtAddress2.Text;
            modelvendor.Vendor_Address3 = this.txtAddress3.Text;

            modelvendor.Vendor_City = this.txtCity.Text;
            modelvendor.Vendor_State = this.txtState.Text;
            modelvendor.Vendor_CountryNum = this.ddlCountry.SelectedValue;

            if (maxVendorConNum == "")
                maxVendorConNum = "1";
            else
                maxVendorConNum = (Convert.ToInt32(maxVendorConNum) + 1).ToString();
            txtContactNumber.Text = maxVendorConNum;

            if (txtContactNumber.Text.Trim() != "")
            {
                

                modelvendor.VendCnt_ConNum = this.txtContactNumber.Text;
                modelvendor.VendCnt_Name = this.txtContactName.Text;
                modelvendor.VendCnt_Func = this.txtContactFunc.Text;
                modelvendor.VendCnt_PhoneNum = this.txtContactPhone.Text;
                modelvendor.VendCnt_CellPhoneNum = this.txtContactCellPhone.Text;
                modelvendor.VendCnt_EmailAddress = this.txtContactEmail.Text;
                modelvendor.VendCnt_UD_RFQRecipent_c = this.ckContactSendRFQ.Checked.ToString();
                modelvendor.VendCnt_UD_PORecipient_c = this.ckContactSendPO.Checked.ToString();
                modelvendor.Calculated_PrimaryContact = this.ckPrimaryContact.Checked.ToString();
                modelvendor.VendCnt_Inactive = this.ckInactive.Checked.ToString();
            }


            modelvendor.Add();
            RptBind(" Vendor_VendorNum ='" + modelvendor.Vendor_VendorNum + "' and Vendor_Company ='" + modelvendor.Vendor_Company + "'  and VendCnt_ConNum <>'' and status<>-1 ", "VendCnt_ConNum asc");
            this.txtContactNumber.Text ="";
            this.txtContactName.Text = "";
            this.txtContactFunc.Text = "";
            this.txtContactPhone.Text = "";
            this.txtContactCellPhone.Text = "";
            this.txtContactEmail.Text = "";
            this.ckContactSendRFQ.Checked = false;
            this.ckContactSendPO.Checked = false;
            this.ckPrimaryContact.Checked = false;
            this.ckInactive.Checked = false;
            mym.JscriptMsg(this.Page, "Add contact success！", "", "Success");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "$.dialog.alert( 'Please input contact name！');", true);
            return;
        }

    }


    

    public string SaveContact()
    {
        ps_epicor_vendor modelvendor = new ps_epicor_vendor();
        modelvendor.GetModelByVendorID(this.companycode,vendorid);
        modelvendor.GetModelByVendorIDAndConNum(modelvendor.Vendor_Company, modelvendor.Vendor_VendorID, this.txtContactNumber.Text.ToString());

        modelvendor.Vendor_PhoneNum = this.txtPhone.Text;
        modelvendor.Vendor_FaxNum = this.txtFax.Text;
        modelvendor.Vendor_EMailAddress = this.txtEmail.Text;
        modelvendor.Vendor_Address1 = this.txtAddress1.Text;
        modelvendor.Vendor_Address2 = this.txtAddress2.Text;
        modelvendor.Vendor_Address3 = this.txtAddress3.Text;

        modelvendor.Vendor_City = this.txtCity.Text;
        modelvendor.Vendor_State = this.txtState.Text;
        modelvendor.Vendor_CountryNum = this.ddlCountry.SelectedValue;

        int intPrimaryVendCnt = 0;
        foreach (RepeaterItem rptitem in this.rptList.Items)
        {
            CheckBox ckPrimaryContact1 = rptitem.FindControl("ckPrimaryContact") as CheckBox;
            if (ckPrimaryContact1.Checked) 
                intPrimaryVendCnt++;
        }

        if (txtEmail.Text.Trim() != "")
            if (IsValidEmail(txtEmail.Text) == false)
                return "Email address " + txtEmail.Text + " is invalid!";

        if (intPrimaryVendCnt > 1)
            return "Only one contact can set as primary contact!";

        foreach (RepeaterItem rptitem in this.rptList.Items)
        {
            TextBox txtContactNumber1 = rptitem.FindControl("txtContactNumber") as TextBox;
            TextBox txtContactName1 = rptitem.FindControl("txtContactName") as TextBox;
            TextBox txtContactFunc1 = rptitem.FindControl("txtContactFunc") as TextBox;
            TextBox txtContactPhone1 = rptitem.FindControl("txtContactPhone") as TextBox;
            TextBox txtContactCellPhone1 = rptitem.FindControl("txtContactCellPhone") as TextBox;
            TextBox txtContactEmail1 = rptitem.FindControl("txtContactEmail") as TextBox;

            CheckBox ckContactSendRFQ1 = rptitem.FindControl("ckContactSendRFQ") as CheckBox;
            CheckBox ckContactSendPO1 = rptitem.FindControl("ckContactSendPO") as CheckBox;
            CheckBox ckPrimaryContact1 = rptitem.FindControl("ckPrimaryContact") as CheckBox;
            CheckBox ckInactive1 = rptitem.FindControl("ckInactive") as CheckBox;

            if(txtContactEmail1.Text.Trim()!="")
                if(IsValidEmail(txtContactEmail1.Text) ==false)
                    return "Email address "+ txtContactEmail1.Text + " is invalid!";

            if (txtContactName1.Text.Trim() != "")
            {
                modelvendor.VendCnt_ConNum = txtContactNumber1.Text;
                modelvendor.VendCnt_Name = txtContactName1.Text;
                modelvendor.VendCnt_Func = txtContactFunc1.Text;
                modelvendor.VendCnt_PhoneNum = txtContactPhone1.Text;
                modelvendor.VendCnt_CellPhoneNum = txtContactCellPhone1.Text;
                modelvendor.VendCnt_EmailAddress = txtContactEmail1.Text;

                modelvendor.VendCnt_UD_RFQRecipent_c = ckContactSendRFQ1.Checked.ToString();
                modelvendor.VendCnt_UD_PORecipient_c = ckContactSendPO1.Checked.ToString();
                modelvendor.Calculated_PrimaryContact = ckPrimaryContact1.Checked.ToString();
                modelvendor.VendCnt_Inactive = ckInactive1.Checked.ToString();
            }

            modelvendor.UpdateContact();
        }
        return "";
        //modelvendor.UpdateContact();
    }

    
    public string MyConvert(object d)
    {
        string myNum = d.ToString();
        string[] strs = d.ToString().Split('.');
        if (strs.Length > 1)
        {
            if (Convert.ToInt32(strs[1]) == 0)
            {
                myNum = strs[0];
            }
        }
        return myNum;
    }

    public static bool IsValidEmail(string Mail)
    {
        string strRegex = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);
        if (re.IsMatch(Mail))
            return true;
        else
            return false;
    }
}