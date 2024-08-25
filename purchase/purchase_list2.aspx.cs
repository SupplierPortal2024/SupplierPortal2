using System;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class purchase_purchase_list2 : System.Web.UI.Page
{
    protected int totalCount;
    protected int page;
    protected int pageSize;

    protected int depot_category_id;
    protected string vendor_id;
    protected int status = -1;
    protected string note_no = string.Empty;
    protected string start_time = string.Empty;
    protected string stop_time = string.Empty;

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
        int nav_id = 43;
        if (!myrv.QXExists(role_id, nav_id))
        {
            Response.Redirect("../error.html");
            Response.End();
        }
        if (Session["VendorID"].ToString() != "")
        {
            this.depot_category_id = Convert.ToInt32(Session["DepotCatID"]);
            this.vendor_id = Session["VendorID"].ToString();
        }
        else
        {
            this.depot_category_id = AXRequest.GetQueryInt("depot_category_id");
            this.vendor_id = AXRequest.GetQueryString("vendor_id");
        }
        this.status = AXRequest.GetQueryInt("status");
        this.note_no = AXRequest.GetQueryString("note_no");
        if (AXRequest.GetQueryString("start_time") == "")
        {
            //this.start_time = DateTime.Now.ToString("yyyy-MM-01");
            this.start_time = DateTime.Now.ToString("yyyy-MM-01");
        }
        else
        {
            this.start_time = AXRequest.GetQueryString("start_time");
        }
        if (AXRequest.GetQueryString("stop_time") == "")
        {
            this.stop_time = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else
        {
            this.stop_time = AXRequest.GetQueryString("stop_time");
        }

        this.pageSize = GetPageSize(20); //每页数量

        if (!Page.IsPostBack)
        {
            //(new EpicorRequest()).GetEpicorPOList(this.vendor_id);
            RptBind("id>0 " + CombSqlTxt( this.status, this.note_no, this.start_time, this.stop_time), "Vendor_Company,Vendor_Name,POHeader_PONum desc ");

        }

    }

    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        this.page = AXRequest.GetQueryInt("page", 1);

      
        txtNote_no.Text = this.note_no;
        txtstart_time.Value = this.start_time;
        txtstop_time.Value = this.stop_time;

        ps_epicor_po bll = new ps_epicor_po();
        this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
        this.rptList.DataBind();
        //绑定页码
        txtPageNum.Text = this.pageSize.ToString();
        string pageUrl = Utils.CombUrlTxt("purchase_list2.aspx", "start_time={0}&stop_time={1}&note_no={2}&page={3}", this.txtstart_time.Value, this.txtstop_time.Value, txtNote_no.Text, "__id__");
        PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
    }
    #endregion

    #region 组合SQL查询语句==========================
    protected string CombSqlTxt(int _status, string _note_no, string _start_time, string _stop_time)
    {
        StringBuilder strTemp = new StringBuilder();

        //if (_status == 1)
        //{
        //    strTemp.Append(" and Approve=" + _status);
        //}
        if(Session["VendorID"].ToString()!="" && Session["VendorID"].ToString() != "0")
            strTemp.Append(" and Vendor_VendorID = '"+ Session["VendorID"].ToString() + "'");
        if (Session["ConpanyName"].ToString() != "")
            strTemp.Append(" and Vendor_Company = '" + Session["ConpanyName"].ToString() + "'");

        if (string.IsNullOrEmpty(_start_time))
        {
            _start_time = "1900-01-01";
        }
        if (string.IsNullOrEmpty(_stop_time))
        {
            _stop_time = "2099-01-01";
        }
        strTemp.Append(" and POHeader_OrderDate between  '" + DateTime.Parse(_start_time) + "' and '" + DateTime.Parse(_stop_time + " 23:59:59") + "'");

        _note_no = _note_no.Replace("'", "");
        if (!string.IsNullOrEmpty(_note_no))
        {
            //strTemp.Append(" and (POHeader_PONum like  '%" + _note_no + "%'  or Vendor_Name like  '%" + _note_no + "%'  or Vendor_VendorID like  '%" + _note_no + "%'  or Vendor_Company like  '%" + _note_no + "%'  or PODetail_PartNum like  '%" + _note_no + "%'  or PODetail_LineDesc like  '%" + _note_no + "%'  or PODetail_PUM like  '%" + _note_no + "%' ) ");
            strTemp.Append(" and (POHeader_PONum like  '%" + _note_no + "%'  ) ");
        }
        return strTemp.ToString();
    }
    #endregion

    #region 返回每页数量=============================
    private int GetPageSize(int _default_size)
    {
        int _pagesize;
        if (int.TryParse(Utils.GetCookie("order_page_size"), out _pagesize))
        {
            if (_pagesize > 0)
            {
                return _pagesize;
            }
        }
        return _default_size;
    }
    #endregion

    #region 返回订单状态=============================
    protected string GetOrderStatus(int _id)
    {
        string _title = string.Empty;

        switch (_id)
        {
            case 1:
                _title = "已生成";
                break;
            case 2:
                _title = "已确认";
                break;
            case 3:
                _title = "交易完成";
                break;
            case 4:
                _title = "<font color=red>已取消</font>";
                break;
        }

        return _title;
    }
    #endregion

    //查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        (new EpicorRequest()).GetEpicorPOList(this.vendor_id);
        Response.Redirect(Utils.CombUrlTxt("purchase_list2.aspx", "start_time={0}&stop_time={1}&note_no={2}", this.txtstart_time.Value, this.txtstop_time.Value, txtNote_no.Text));
    }



    //设置分页数量
    protected void txtPageNum_TextChanged(object sender, EventArgs e)
    {
        int _pagesize;
        if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        {
            if (_pagesize > 0)
            {
                Utils.WriteCookie("order_page_size", _pagesize.ToString(), 14400);
            }
        }
        Response.Redirect(Utils.CombUrlTxt("purchase_list2.aspx", "start_time={0}&stop_time={1}&note_no={2}", this.status.ToString(), this.txtstart_time.Value, this.txtstop_time.Value, txtNote_no.Text));

    }
    //导出报表
    protected void btnExport_Click2(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("purchase_request_rep.aspx", "depot_category_id={0}&depot_id={1}&status={2}&start_time={3}&stop_time={4}&note_no={5}", this.depot_category_id.ToString(), this.vendor_id.ToString(), this.status.ToString(), this.txtstart_time.Value, this.txtstop_time.Value, txtNote_no.Text));
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


    //导出报表
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Redirect(Utils.CombUrlTxt("purchase_rep.aspx", "depot_category_id={0}&vendor_id={1}&status={2}&start_time={3}&stop_time={4}&note_no={5}&page={6}", this.depot_category_id.ToString(), this.vendor_id.ToString(), this.status.ToString(), this.txtstart_time.Value, this.txtstop_time.Value, txtNote_no.Text, this.page.ToString()));
    }
}
