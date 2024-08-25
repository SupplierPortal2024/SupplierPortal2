using System;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sysmanager_vendor_list2 : System.Web.UI.Page
{

    protected int totalCount;
    protected int page;
    protected int pageSize;
    protected int status;
    protected int CatID;
    protected string keywords = string.Empty;

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
        this.status = AXRequest.GetQueryInt("status");
        this.CatID = AXRequest.GetQueryInt("CatID");
        this.keywords = AXRequest.GetQueryString("keywords").Trim();
        this.pageSize = GetPageSize(20); //每页数量
        this.page = AXRequest.GetQueryInt("page", 1);

        if (!Page.IsPostBack)
        {
            TreeBind(Convert.ToInt32(Session["DepotCatID"])); //绑定地区
            RptBind("id>0" + CombSqlTxt(this.status, this.CatID, this.keywords), " Vendor_Company,Vendor_VendorNum ");
            //if (Convert.ToInt32(Session["DepotID"]) == 0 && Convert.ToInt32(Session["DepotCatID"]) == 0)
            //{
            //    RptBind("id>0" + CombSqlTxt(this.status, this.CatID, this.keywords), " Vendor_Company,Vendor_VendorNum ");
            //}
            //else if (Convert.ToInt32(Session["DepotID"]) == 0 && Convert.ToInt32(Session["DepotCatID"]) > 0)
            //{
            //    this.ddlCategoryId.SelectedValue = Session["DepotCatID"].ToString();


            //    RptBind("DepotCatID=" + Convert.ToInt32(Session["DepotCatID"]) + CombSqlTxt(this.status, this.CatID, this.keywords), "id desc");
            //}

        }
    }

    #region 绑定地区=================================
    private void TreeBind(int _CatID)
    {
        ps_depot_category bll = new ps_depot_category();
        DataTable dt = bll.GetList(_CatID);
        this.ddlCategoryId.Items.Clear();
        this.ddlCategoryId.Items.Add(new ListItem("==All==", ""));
        foreach (DataRow dr in dt.Rows)
        {
            string Id = dr["id"].ToString();
            string name = dr["name"].ToString().Trim();
            this.ddlCategoryId.Items.Add(new ListItem(name, Id));
        }

    }
    #endregion

    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        this.page = AXRequest.GetQueryInt("page", 1);
        if (this.status > 0)
        {
            this.ddlStatus.SelectedValue = this.status.ToString();
        }
        if (this.CatID > 0)
        {
            this.ddlCategoryId.SelectedValue = this.CatID.ToString(); 
        }
        txtKeywords.Text = this.keywords;
        ps_epicor_vendor bll = new ps_epicor_vendor();
        DataSet dsVendor = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);

        bool isTheSameVendorID = true;

        if (dsVendor.Tables[0].Rows.Count>0)
        {
            string vendorid = dsVendor.Tables[0].Rows[0]["Vendor_VendorID"].ToString();
            for (int i = 0; i < dsVendor.Tables[0].Rows.Count - 1; i++)
            {
                if (vendorid != dsVendor.Tables[0].Rows[i]["Vendor_VendorID"].ToString())
                {
                    isTheSameVendorID = false;
                    break;
                }
            }
        }
        //if (dsVendor.Tables[0].Rows.Count == 1)
        if(isTheSameVendorID==true)
        {
            if (dsVendor.Tables[0].Rows.Count > 0)
            {
                (new EpicorRequest()).GetEpicorVenderList(dsVendor.Tables[0].Rows[0]["Vendor_VendorID"].ToString());
                Response.Redirect("vendor_edit2.aspx?action=Edit&companycode=" + dsVendor.Tables[0].Rows[0]["Vendor_Company"] + "&vendorid=" + dsVendor.Tables[0].Rows[0]["Vendor_VendorID"] + "");
            }
        }
        else
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        
        this.rptList.DataBind();

        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("vendor_list2.aspx", "status={0}&CatID={1}&keywords={2}&page={3}", this.status.ToString(), this.CatID.ToString(), this.keywords, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(int _status, int _CatID, string _keywords)
    {
        StringBuilder strTemp = new StringBuilder();

        if (Session["VendorID"].ToString() != "" && Session["VendorID"].ToString() != "0")
            strTemp.Append(" and Vendor_VendorID = '" + Session["VendorID"].ToString() + "'");
        if (Session["ConpanyName"].ToString() != "")
            strTemp.Append(" and Vendor_Company = '" + Session["ConpanyName"].ToString() + "'");

        if (_status > 0)
        {
            strTemp.Append(" and status=" + _status);
        }
        if (_CatID > 0)
        {
            strTemp.Append(" and CatID=" + _CatID);
        }
        _keywords = _keywords.Replace("'", "");
        if (!string.IsNullOrEmpty(_keywords))
        {
            strTemp.Append(" and (Vendor_VendorNum like  '%" + _keywords + "%' ");
            strTemp.Append("or Vendor_VendorID like '%" + _keywords + "%' or  Vendor_Name like '%" + _keywords + "%' ");
            strTemp.Append("or Vendor_PhoneNum like '%" + _keywords + "%' or  Vendor_FaxNum like '%" + _keywords + "%' ");
            strTemp.Append("or Vendor_EMailAddress like '%" + _keywords + "%' or  Vendor_Address1 like '%" + _keywords + "%' ");
            strTemp.Append("or Vendor_Address2 like '%" + _keywords + "%' or  Vendor_Address3 like '%" + _keywords + "%' ");
            strTemp.Append("or Vendor_Country like '%" + _keywords + "%' or  VendCnt_Name like '%" + _keywords + "%' ");
            strTemp.Append("or VendCnt_Func like '%" + _keywords + "%' or  VendCnt_PhoneNum like '%" + _keywords + "%' ");
            strTemp.Append("or VendCnt_CellPhoneNum like '%" + _keywords + "%' or  VendCnt_PerConID like '%" + _keywords + "%' ");
            strTemp.Append("or Vendor_VendorID like '%" + _keywords + "%' or  Vendor_Name like '%" + _keywords + "%')");
        }
        return strTemp.ToString();
    }
    #endregion

    #region 返回每页数量=============================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("vendor_page_size"), out _pagesize))
        {
            if (_pagesize > 0)
            {
                return _pagesize;
            }
        }
        return _default_size;
    }
    #endregion

    //关健字查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        (new EpicorRequest()).GetEpicorVenderList("");
        Response.Redirect(Utils.CombUrlTxt("vendor_list2.aspx", "keywords={0}",  this.txtKeywords.Text));
    }

    //筛选地区
    protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("vendor_list2.aspx", "keywords={0}", this.keywords));
    }
    //筛选状态
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("vendor_list2.aspx", "keywords={0}", this.keywords));
    }
    //设置分页数量
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("vendor_page_size", _pagesize.ToString(), 14400);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("vendor_list2.aspx", "&keywords={0}", this.keywords));
    }



    //导出报表
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("vendor_rep.aspx", "keywords={0}",  this.keywords));
    }
}
