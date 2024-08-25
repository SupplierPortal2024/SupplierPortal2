using System;

using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;

public partial class purchase_purchase_rep : System.Web.UI.Page
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
            this.start_time = DateTime.Now.AddYears(-2).ToString("yyyy-MM-01");
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

        this.pageSize = 100000; //每页数量
        if (!Page.IsPostBack)
        {
            RptBind("id>0 " + CombSqlTxt(this.status, this.note_no, this.start_time, this.stop_time), "Vendor_Company,Vendor_Name,POHeader_PONum desc ");

        }

        Response.Clear();
        Response.Buffer = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("POList" + DateTime.Now.ToString("yyyyMMdd") + ".xls", Encoding.UTF8).ToString());
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.ContentType = "application/vnd.ms-excel";
        //Response.ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";//.xlsx格式
 

        this.EnableViewState = false;


    }

    #region 数据绑定=================================
    private void RptBind(string _strWhere, string _orderby)
    {
        this.page = AXRequest.GetQueryInt("page", 1);


        ps_epicor_po bll = new ps_epicor_po();
        DataView dv = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount).Tables[0].DefaultView; 

        repCategory.DataSource = dv;
        repCategory.DataBind();
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
        if (Session["VendorID"].ToString() != "" && Session["VendorID"].ToString() != "0")
            strTemp.Append(" and Vendor_VendorID = '" + Session["VendorID"].ToString() + "'");
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
    

}