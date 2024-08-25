using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class purchase_purchase_edit : System.Web.UI.Page
{
    protected int page;
    private string action = ""; //操作类型
    private int id = 0;
    ManagePage mym = new ManagePage();
    protected ps_po model = new ps_po();

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
        int nav_id = 43;
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
            }
        }

    }

    #region 赋值操作=================================
    private void ShowInfo(int _id)
    {
        int recordCount = 0;
        model = model.GetModel(_id);
        DataSet dsPO= model.GetListByID(_id,out recordCount);
        //绑定商品列表
        ps_podetail bll = new ps_podetail();
        string sql = " POID =" + _id;

        DataTable dt = bll.GetList(sql).Tables[0];
        this.rptList.DataSource = dt;
        this.rptList.DataBind();

        ////获得商家信息
        //if (dsPO.Tables[0].Rows[0][] > 0)
        //{
        //    ps_depot user_info = new ps_depot();
        //    user_info.GetModel(Convert.ToInt32(model.depot_id));
        //    user_name.Text = model.user_name;
        //    title.Text = user_info.title;

        //    contact_address.Text = model.address == "" ? user_info.contact_address : model.address;
        //    contact_name.Text = model.contract_name == "" ? user_info.contact_name : model.contract_name;
        //    contact_tel.Text = model.contact_number == "" ? user_info.contact_mobile : model.contact_number;
        //}
        litOrderNo.Text = dsPO.Tables[0].Rows[0]["PONum"].ToString();
        litOrderDate.Text = (Convert.ToDateTime(dsPO.Tables[0].Rows[0]["OrderDate"])).ToShortDateString();
        txtConfirmDate.Text = dsPO.Tables[0].Rows[0]["PromiseDate"].ToString()!=""? (Convert.ToDateTime(dsPO.Tables[0].Rows[0]["PromiseDate"])).ToShortDateString() :"";
        txtVendorRemark.Text = dsPO.Tables[0].Rows[0]["VendorRemark"].ToString();
        contact_address.Text = dsPO.Tables[0].Rows[0]["ShipAddress1"].ToString();
        contact_name.Text = dsPO.Tables[0].Rows[0]["ShipName"].ToString();
        contact_tel.Text = "";

        //根据订单状态，显示各类操作按钮
        switch (model.Confirmed)
        {
            case false: //订单为未确认状态     
                this.btnSubmit.Visible =  true;
                this.txtConfirmDate.Enabled = true;
                this.txtVendorRemark.Enabled = true;
                //修改订单备注、调价按钮显示
                //btnEditRemark.Visible = btnEditPaymentFee.Visible = true;
                break;
            case true: //如果订单为已确认状态
                this.btnSubmit.Visible = false;
                this.txtConfirmDate.Enabled = false;
                this.txtVendorRemark.Enabled = false;
                //修改订单备注按钮可见
                btnEditRemark.Visible = true;
                break;

        }
        btnEditRemark.Visible = false;
    }
    #endregion

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //检测确认日期
        if (txtConfirmDate.Text.Trim()=="")
        {
            mym.JscriptMsg(this.Page, "请输入确认日期！", "", "Error");
            return;
        }

        
        if (!model.ComfirmPO(id, Convert.ToDateTime(this.txtConfirmDate.Text),txtVendorRemark.Text))
        {
            mym.JscriptMsg(this.Page, "错误！", "", "Error");
            return;
        }
        mym.JscriptMsg(this.Page, "确认订单成功！", "purchase_edit.aspx?action=Edit&id="+ this.id.ToString() + "", "Success");
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("purchase_list.aspx");
    }
    
}