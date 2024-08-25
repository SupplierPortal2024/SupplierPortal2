using System;

public partial class top : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        ManagePage mym = new ManagePage();
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='index.aspx'</script>");
            Response.End();
        }
        if (!IsPostBack)
        {
            //string CompanyName = (Session["RealName"].ToString() + (Session["ConpanyName"] != null ? ("    " + Session["ConpanyName"].ToString()) : ""));
            string CompanyName = Session["RealName"].ToString();
            Lit_Name.Text = CompanyName.Substring(0, CompanyName.Length>40 ? 40 : CompanyName.Length);
        }
    }

    //安全退出
    protected void lbtnExit_Click(object sender, EventArgs e)
    {
        Utils.WriteCookie("AdminName", "AoXiang", -14400);
        Utils.WriteCookie("RoleID", "AoXiang", -14400);
        Utils.WriteCookie("AID", "AoXiang", -14400);
        Utils.WriteCookie("RealName", "AoXiang", -14400);
        Utils.WriteCookie("DepotID", "AoXiang", -14400);
        Utils.WriteCookie("DepotCode", "AoXiang", -14400);
        Utils.WriteCookie("ConpanyName", "AoXiang", -14400);
        Utils.WriteCookie("VendorID", "AoXiang", -14400);
        Utils.WriteCookie("DepotCatID", "AoXiang", -14400);
        Utils.WriteCookie("IsDisplayPrice", "AoXiang", -14400);
        Utils.WriteCookie("CustomerSupportURL", "AoXiang", -14400);


        Session["RememberName"] = null;
        Session["AdminName"] = null;
        Session["RoleID"] = null;
        Session["AID"] = null;
        Session["RealName"] = null;
        Session["DepotID"] = null;
        Session["ConpanyName"] = null;
        Session["VendorID"] = null;
        Session["DepotCatID"] = null;
        Session["IsDisplayPrice"] = null;
        Session["CustomerSupportURL"] = null;
        

        Response.Write("<script>parent.location.href='index.aspx'</script>");
        Response.End();
    }

}