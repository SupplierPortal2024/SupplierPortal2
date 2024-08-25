using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Xml;

public partial class home : System.Web.UI.Page
{
    protected string msg = "";
    protected string vendor_id;
    protected string company_code;
    protected ps_epicor_vendor modelvendor = new ps_epicor_vendor();
    protected string syst_portalnotice;
    protected string vendor_portalnotice;

    protected string Calculated_RepliedRFQ;
    protected string calculated_waitforreplyRFQ;

    protected string Calculated_RepliedPO;
    protected string calculated_waitforreplyPO;

    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        ManagePage mym = new ManagePage();

        if (Session["VendorID"] != null)
        {
            this.vendor_id = Session["VendorID"].ToString();
        }
        if (Session["ConpanyCode"] != null)
        {
            this.company_code = Session["ConpanyCode"].ToString();
        }
        

        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='index.aspx'</script>");
            Response.End();
        }
       
        if (!IsPostBack)
        {
            
            noticeBind();//通知公告
            if (this.vendor_id != "")
            {
                modelvendor = new ps_epicor_vendor();
                modelvendor.GetModelByVendorID(this.company_code, this.vendor_id);


                string portalNotice = (new EpicorRequest()).GetEpicorSupplierNotice(this.vendor_id);
                string[] portalNoticeArr = Regex.Split(portalNotice, "vvvvvvvvvv", RegexOptions.IgnoreCase);
                syst_portalnotice = (portalNoticeArr.Length > 1) ? portalNoticeArr[0].ToString() : "";
                vendor_portalnotice = (portalNoticeArr.Length > 1) ? portalNoticeArr[1].ToString() : "";

                string epicorRFQCount = (new EpicorRequest()).GetEpicorRFQCount(this.vendor_id);
                string[] epicorRFQCountArr = Regex.Split(epicorRFQCount, "vvvvvvvvvv", RegexOptions.IgnoreCase);
                Calculated_RepliedRFQ = (epicorRFQCountArr.Length > 1) ? epicorRFQCountArr[0].ToString() : "";
                calculated_waitforreplyRFQ = (epicorRFQCountArr.Length > 1) ? epicorRFQCountArr[1].ToString() : "";

                string epicorPOCount = (new EpicorRequest()).GetEpicorPOCount(this.vendor_id);
                string[] epicorPOCountArr = Regex.Split(epicorPOCount, "vvvvvvvvvv", RegexOptions.IgnoreCase);
                Calculated_RepliedPO = (epicorPOCountArr.Length > 1) ? epicorPOCountArr[0].ToString() : "";
                calculated_waitforreplyPO = (epicorPOCountArr.Length > 1) ? epicorPOCountArr[1].ToString() : "";

            }
            //Response.Redirect("purchase/purchase_request2.aspx");
        }
    }

  
    #region 绑定通知公告=================================
    protected void noticeBind()
    {
        //ps_article bll = new ps_article();
        //this.rptList_notice.DataSource = bll.GetList(13, " status=1 ", " sort_id asc, add_time desc");
        //this.rptList_notice.DataBind();
    }
    #endregion

   
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