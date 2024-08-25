using System;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sysmanager_vendor_list : System.Web.UI.Page
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
        int nav_id = 28;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }
        this.status = AXRequest.GetQueryInt("status");
        this.CatID = AXRequest.GetQueryInt("CatID");
        this.keywords = AXRequest.GetQueryString("keywords");
        this.pageSize = GetPageSize(10); //每页数量
        this.page = AXRequest.GetQueryInt("page", 1);

        if (!Page.IsPostBack)
        {
            TreeBind(Convert.ToInt32(Session["DepotCatID"])); //绑定地区
            if (Convert.ToInt32(Session["DepotID"]) == 0 && Convert.ToInt32(Session["DepotCatID"]) == 0)
            {
                RptBind("id>0" + CombSqlTxt(this.status, this.CatID, this.keywords), "CatID asc,id desc");
            }
            else if (Convert.ToInt32(Session["DepotID"]) == 0 && Convert.ToInt32(Session["DepotCatID"]) > 0)
            {
                this.ddlCategoryId.SelectedValue = Session["DepotCatID"].ToString();
                RptBind("DepotCatID=" + Convert.ToInt32(Session["DepotCatID"]) + CombSqlTxt(this.status, this.CatID, this.keywords), "CatID asc,id desc");
            }

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
        ps_vendor bll = new ps_vendor();
        this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();

        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("vendor_list.aspx", "status={0}&CatID={1}&keywords={2}&page={3}", this.status.ToString(), this.CatID.ToString(), this.keywords, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(int _status, int _CatID, string _keywords)
    {
        StringBuilder strTemp = new StringBuilder();
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
            strTemp.Append(" and (name like  '%" + _keywords + "%' or Address1 like '%" + _keywords + "%' or  VendorID like '%" + _keywords + "%')");
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
        Response.Redirect(Utils.CombUrlTxt("vendor_list.aspx", "status={0}&CatID={1}&keywords={2}", this.status.ToString(), this.CatID.ToString(), txtKeywords.Text));
    }

    //筛选地区
    protected void ddlCategoryId_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("vendor_list.aspx", "status={0}&CatID={1}&keywords={2}",
            this.status.ToString(), ddlCategoryId.SelectedValue, this.keywords));
    }
    //筛选状态
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("vendor_list.aspx", "status={0}&CatID={1}&keywords={2}",
            ddlStatus.SelectedValue, this.CatID.ToString(), this.keywords));
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
        Response.Redirect(Utils.CombUrlTxt("vendor_list.aspx", "status={0}&CatID={1}&keywords={2}", this.status.ToString(), this.CatID.ToString(), this.keywords));
    }

    // 单个删除
    protected void lbtnDelCa_Click(object sender, EventArgs e)
    {
        // 当前点击的按钮
        LinkButton lb = (LinkButton)sender;
        int caId = int.Parse(lb.CommandArgument);
        ps_vendor bll = new ps_vendor();
        bll.GetModel(caId);
        string name = bll.Name;
        ps_manager bllpp = new ps_manager();
        bllpp.depot_id = caId;
        if (!bllpp.ExistsMD())//查找是否存在用户
        {
            bll.Delete(caId);
            mym.AddAdminLog("删除", "删除供应商：" + name + ""); //记录日志
            mym.JscriptMsg(this.Page, " 成功删除供应商：" + name + "", Utils.CombUrlTxt("vendor_list.aspx", "status={0}&CatID={1}&keywords={2}&page={3}", this.status.ToString(), this.CatID.ToString(), this.keywords, this.page.ToString()), "Success");
        }
        else
        {
            mym.JscriptMsg(this.Page, "有用户属于该供应商，不能删除！", "", "Error");
            return;
        }
    }
    //保存排序
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ps_vendor bll = new ps_vendor();
        Repeater rptList = new Repeater();
        rptList = this.rptList;

        for (int i = 0; i < rptList.Items.Count; i++)
        {
            int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            int sortId;
            if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
            {
                sortId = 99;
            }
            bll.UpdateField(id, "sort_id=" + sortId.ToString());
        }
        mym.JscriptMsg(this.Page, " 排序保存成功", Utils.CombUrlTxt("vendor_list.aspx", "status={0}&CatID={1}&keywords={2}&page={3}", this.status.ToString(), this.CatID.ToString(), this.keywords, this.page.ToString()), "Success");
    }

    //导出报表
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("vendor_rep.aspx", "status={0}&CatID={1}&keywords={2}", this.status.ToString(), this.CatID.ToString(), this.keywords));
    }
}
