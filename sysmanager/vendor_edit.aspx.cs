
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class sysmanager_vendor_edit : System.Web.UI.Page
{
    protected int page;
    private string action = ""; //操作类型
    protected string dw = ""; //计量单位
    private int id = 0;
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
        int nav_id = 11;
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
            if (!int.TryParse(Request.QueryString["id"] as string, out this.id))
            {
                mym.JscriptMsg(this.Page, "传输参数不正确！", "back", "Error");
                return;
            }

        }
        if (!Page.IsPostBack)
        {
            if (action == "Edit") //修改
            {
                ShowInfo(this.id);
                Focus myFocus = new Focus();
                myFocus.SetEnterControl(this.txtSupplierName);
                

            }
        }
    }


    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        //ps_here_depot model1 = new ps_here_depot();
        ps_vendor modelvendor = new ps_vendor();
        modelvendor.GetModel(_id);

       

        this.txtSupplierID.Text = modelvendor.VendorID.ToString();
        this.txtSupplierName.Text = modelvendor.Name.ToString();
        this.txtCurrency.Text = modelvendor.CurrencyCode.ToString();
        this.txtTerms.Text = modelvendor.TermsCode.ToString();
        
        this.txtPhone.Text = modelvendor.PhoneNum.ToString();
        this.txtFax.Text = modelvendor.FaxNum.ToString();
        this.txtEmail.Text = modelvendor.EMailAddress.ToString();
        this.txtAddress1.Text = modelvendor.Address1.ToString();
        this.txtAddress2.Text = modelvendor.Address2.ToString();
        this.txtAddress3.Text = modelvendor.Address3.ToString();
        //this.txtdw.Text = model1.dw;
        //this.txtgo_price.Text = MyConvert(model1.go_price.ToString());
        //this.txtsalse_price.Text = MyConvert(model1.salse_price.ToString());
        //this.txtproduct_num.Text = model1.product_num.ToString();
        //this.dw = model1.dw;
        //this.txtSpecification.Text = model1.specification.ToString();
        //this.txtCommercialStyle.Text = model1.commercialStyle.ToString();
        //this.cbIsActive.Checked = model1.status == 0 ? true : false;
        RptBind(" vendornum =" + modelvendor.VendorNum, "ConNum asc");
    }
    #endregion

    private void RptBind(string _strWhere, string _orderby)
    {
        ps_vendor bll = new ps_vendor();
        
        this.rptList.DataSource = bll.GetVendorCntList(100, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();
    }

    #region 修改操作=================================
    private bool DoEdit(int _id)
    {
        bool result = false;
        ps_vendor modelvendor = new ps_vendor();
        modelvendor.GetModel(_id);

        modelvendor.Name = this.txtSupplierName.Text;
        modelvendor.CurrencyCode = this.txtCurrency.Text;
        modelvendor.TermsCode = this.txtTerms.Text;
        modelvendor.PhoneNum = this.txtPhone.Text;
        modelvendor.FaxNum = this.txtFax.Text;
        modelvendor.EMailAddress = this.txtEmail.Text;
        modelvendor.Address1 = this.txtAddress1.Text;
        modelvendor.Address2 = this.txtAddress2.Text;
        modelvendor.Address3 = this.txtAddress3.Text;
        modelvendor.Name = this.txtSupplierName.Text;

        modelvendor.Inactive = this.cbIsActive.Checked ? 0 : 1;

        result = modelvendor.Update();

        return result;
    }
    #endregion


   

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
            mym.JscriptMsg(this.Page, "Edit supplier success！", "", "Success");
            //mym.JscriptMsg(this.Page, "修改商品信息成功！", Utils.CombUrlTxt("depot_manager.aspx", "page={0}", this.page.ToString()), "Success");
        }
        else //发生错误
        {
            mym.JscriptMsg(this.Page, "Error on process！", "", "Error");
            return;
        }
    }

    //小数位是0的不显示
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
}