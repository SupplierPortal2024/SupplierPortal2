<%@ WebHandler Language="C#" Class="search_ajax" %>

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Web.SessionState;
using LitJson;

/// <summary>
/// AJAX提交处理
/// </summary>
public class search_ajax : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        //取得处事类型
        string searchtype = AXRequest.GetQueryString("searchtype");

        switch (searchtype)
        {

            case "part": //购物车加入商品
                search_part(context);
                break;
            case "cust": //搜索经销商
                search_cust(context);
                break;
            case "vendor": //搜索供应商
                search_vendor(context);
                break;
            case "cart_goods_update": //购物车修改商品
                //cart_goods_update(context);
                break;
            case "cart_goods_delete": //购物车删除商品
                //cart_goods_delete(context);
                break;
            case "view_cart_count": //输出当前购物车总数
                //view_cart_count(context);
                break;
        }
    }

    #region 搜索Part OK===============================
    private void search_part(HttpContext context)
    {
        string searchcontent = AXRequest.GetFormString("searchcontent").Trim().Replace("'","");
        string compamy = AXRequest.GetFormString("compamy");

        if (searchcontent == "")
        {
            context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
            return;
        }

        //统计购物车
        ps_here_depot model = new ps_here_depot();
        DataSet ds = model.GetList(200, " (product_no like '%"+searchcontent+"%' or product_name like N'%"+searchcontent+"%' or product_desc like N'%"+searchcontent+"%' or commercialstyle like N'%"+searchcontent+"%' ) and company = '"+compamy+"'  ", " id ");
        StringBuilder retrunSB = new StringBuilder();
        retrunSB.Append("[");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string product_no = ds.Tables[0].Rows[i]["product_no"].ToString();
            string product_name = ds.Tables[0].Rows[i]["product_name"].ToString();
            string product_desc = ds.Tables[0].Rows[i]["product_desc"].ToString();
            string commercialstyle = ds.Tables[0].Rows[i]["commercialstyle"].ToString();
            retrunSB.Append("{\"productno\":\""+ product_no +"\",\"productname\":\""+ product_name +"\",\"productdesc\":\""+ product_desc +"\",\"commercialstyle\":\""+ commercialstyle +"\"},");
        }
        retrunSB.Append("{\"productno\":\""+ "---" +"\",\"productname\":\""+ "---" +"\",\"productdesc\":\""+ "---" +"\",\"commercialstyle\":\""+ "---" +"\"}");
        retrunSB.Append("]");
        context.Response.Clear();
        context.Response.ClearContent();
        context.Response.Cache.SetNoStore();
        context.Response.ContentType = "application/json";
        context.Response.ContentEncoding = System.Text.Encoding.UTF8;
        context.Response.Write(retrunSB.ToString());
        context.Response.Flush();
        context.Response.End();
        return;
    }
    #endregion

    #region 搜索customer OK===============================
    private void search_cust(HttpContext context)
    {
        string searchcontent = AXRequest.GetFormString("searchcontent").Trim().Replace("'","");
        string compamy = AXRequest.GetFormString("compamy");
        if (compamy != "")
        {
            ps_depot_category modelCat = new ps_depot_category();
            modelCat.GetModel(Convert.ToInt32(compamy));
            if (modelCat != null)
                compamy = modelCat.title;
        }


        if (searchcontent == "")
        {
            context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
            return;
        }

        //统计购物车
        ps_depot model = new ps_depot();
        DataSet ds = model.GetList(10, " (code like '%"+searchcontent+"%' or title like N'%"+searchcontent+"%'  ) and company = '"+compamy+"'  ", " id ");
        StringBuilder retrunSB = new StringBuilder();
        retrunSB.Append("[");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string custid = ds.Tables[0].Rows[i]["id"].ToString();
            string custcode = ds.Tables[0].Rows[i]["code"].ToString();
            string custname = ds.Tables[0].Rows[i]["title"].ToString();
            
            retrunSB.Append("{\"custcode\":\""+ custcode +"\",\"custname\":\""+ custname +"\",\"custid\":\""+ custid +"\"},");
        }
        retrunSB.Append("{\"custcode\":\""+ "---" +"\",\"custname\":\""+ "---" +"\",\"custid\":\""+ "---" +"\"}");
        retrunSB.Append("]");
        context.Response.Clear();
        context.Response.ClearContent();
        context.Response.Cache.SetNoStore();
        context.Response.ContentType = "application/json";
        context.Response.ContentEncoding = System.Text.Encoding.UTF8;
        context.Response.Write(retrunSB.ToString());
        context.Response.Flush();
        context.Response.End();
        return;
    }
    #endregion

    #region Vendor OK===============================
    private void search_vendor(HttpContext context)
   {
        string searchcontent = AXRequest.GetFormString("searchcontent").Trim().Replace("'","");
        string compamy = AXRequest.GetFormString("compamy");
        if (compamy != "")
        {
            ps_depot_category modelCat = new ps_depot_category();
            modelCat.GetModel(Convert.ToInt32(compamy));
            if (modelCat != null)
                compamy = modelCat.title;
        }


        if (searchcontent == "")
        {
            context.Response.Write("{\"status\":0, \"msg\":\"您提交的商品参数有误！\"}");
            return;
        }

        //统计购物车
        ps_vendor model = new ps_vendor();
        DataSet ds = model.GetList(10, " (VendorID like '%"+searchcontent+"%' or Name like N'%"+searchcontent+"%'  or address1 like N'%"+searchcontent+"%'  ) and company = '"+compamy+"'  ", " id ");
        StringBuilder retrunSB = new StringBuilder();
        retrunSB.Append("[");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string vendorid = ds.Tables[0].Rows[i]["id"].ToString();
            string vendorcode = ds.Tables[0].Rows[i]["vendorid"].ToString();
            string vendorname = ds.Tables[0].Rows[i]["name"].ToString();
            
            retrunSB.Append("{\"vendorcode\":\""+ vendorcode +"\",\"vendorname\":\""+ vendorname +"\",\"vendorid\":\""+ vendorid +"\"},");
        }
        retrunSB.Append("{\"vendorcode\":\""+ "---" +"\",\"vendorname\":\""+ "---" +"\",\"vendorid\":\""+ "---" +"\"}");
        retrunSB.Append("]");
        context.Response.Clear();
        context.Response.ClearContent();
        context.Response.Cache.SetNoStore();
        context.Response.ContentType = "application/json";
        context.Response.ContentEncoding = System.Text.Encoding.UTF8;
        context.Response.Write(retrunSB.ToString());
        context.Response.Flush();
        context.Response.End();
        return;
    }
    #endregion

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}