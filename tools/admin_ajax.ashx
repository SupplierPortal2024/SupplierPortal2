<%@ WebHandler Language="C#" Class="admin_ajax" %>

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.SessionState;


public class admin_ajax : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        //取得处事类型
        string action = AXRequest.GetQueryString("action");

        switch (action)
        {
            case "manager_validate": //验证管理员用户名是否重复
                manager_validate(context);
                break;
            case "code_validate": //验证管理员用户名是否重复
                code_validate(context);
                break;
            case "edit_order_status": //修改订单信息和状态
                edit_order_status(context);
                break;
        }

    }

    #region 修改订单信息和状态==============================
    private void edit_order_status(HttpContext context)
    {
        //取得登录信息
        ManagePage mym = new ManagePage();
        ps_manager_log mylog = new ps_manager_log();
        if (!mym.IsAdminLogin())
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"未登录或已超时，请重新登录！\"}");
            return;
        }

        string order_no = AXRequest.GetString("order_no");
        string edit_type = AXRequest.GetString("edit_type");

        if (order_no == "")
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"传输参数有误，无法获取订单号！\"}");
            return;
        }
        if (edit_type == "")
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"无法获取修改订单类型！\"}");
            return;
        }
        ps_orders model = new ps_orders();
        model.GetModel(order_no);
        if (!model.Exists(order_no))
        {
            context.Response.Write("{\"status\": 0, \"msg\": \"订单号不存在或已被删除！\"}");
            return;
        }
        string EpicorOrderNumber = "";
        string OrgEpicorOrderNumber = "";
        ps_order_goods bllOrderGoods = new ps_order_goods();
        EpicorRequest bllEpicor = new EpicorRequest();
        switch (edit_type.ToLower())
        {
            case "order_confirm": //确认订单

                if (model.status > 1 && model.status != 4)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单已经确认，不能重复处理！\"}");
                    return;
                }

                EpicorOrderNumber = "";
                OrgEpicorOrderNumber = "";
                OrgEpicorOrderNumber = bllEpicor.PostQuoteToEpicor(order_no) ;
                if(OrgEpicorOrderNumber!="" && OrgEpicorOrderNumber.Contains("Error")==false)
                {
                    EpicorOrderNumber = OrgEpicorOrderNumber + "(报价单)";
                }
                //if (bllOrderGoods.IsOrerExistCustStyle(order_no))
                //{
                //    OrgEpicorOrderNumber = bllEpicor.PostQuoteToEpicor(order_no) ;
                //    if(OrgEpicorOrderNumber!="")
                //    {
                //        //bllEpicor.UpdateQuoteToEpicor(order_no,OrgEpicorOrderNumber);
                //        //(new EpicorRequest()).UpdateQuoteToEpicor("23040912074797","204202");
                //        EpicorOrderNumber = OrgEpicorOrderNumber + "(报价单)";
                //    }
                //}
                //else
                //{
                //    OrgEpicorOrderNumber = bllEpicor.PostSalesOrderToEpicor(order_no);
                //    if (OrgEpicorOrderNumber != "")
                //    {
                //        EpicorOrderNumber = OrgEpicorOrderNumber + "(销售单)";
                //    }
                //}

                if (OrgEpicorOrderNumber == "" || OrgEpicorOrderNumber.Contains("Error"))
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单确认失败！"+ OrgEpicorOrderNumber.Split('\r')[0].ToString() +" \"}");
                    return;
                }

                if (bllOrderGoods.IsOrerExistCustStyle(order_no))
                {
                    model.status = 5;
                    model.quotetime = DateTime.Now;
                }
                else
                {
                    model.status = 2;
                    model.confirm_time = DateTime.Now;
                    model.status = 5;
                    model.quotetime = DateTime.Now;
                }

                model.backremark = "";

                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单确认失败！\"}");
                    return;
                }
                else//增加订单销售记录
                {
                    if (EpicorOrderNumber.Substring(0, 5) != "Error" && OrgEpicorOrderNumber!="" )
                    {
                        ps_salse_depot model1 = new ps_salse_depot();
                        model1.note_no = order_no;
                        model1.depot_category_id = model.depot_category_id;
                        model1.add_time = DateTime.Now;
                        model1.depot_id = model.depot_id;
                        model1.order_id = model.id;
                        model1.user_id = model.user_id;


                        ps_orders bllorders = new ps_orders();
                        bllorders.UpdateEpicorOrderNo(order_no, EpicorOrderNumber);

                        ps_order_goods bll = new ps_order_goods();
                        DataTable dt = bll.GetList(model.id);
                        foreach (DataRow dr in dt.Rows)
                        {
                            model1.goods_id = int.Parse(dr["goods_id"].ToString());
                            model1.goods_title = dr["goods_title"].ToString().Trim();
                            model1.goods_price = Convert.ToDecimal(dr["goods_price"].ToString());
                            model1.real_price = Convert.ToDecimal(dr["real_price"].ToString());
                            model1.quantity = int.Parse(dr["quantity"].ToString());
                            model1.here_depot_id = int.Parse(dr["goods_id"].ToString());

                            ps_here_depot model2 = new ps_here_depot();
                            model2.GetModel(int.Parse(dr["goods_id"].ToString()));
                            model2.product_num = int.Parse(model2.product_num.ToString()) - int.Parse(dr["quantity"].ToString());
                            model2.UpdateALL();
                            model1.Add();
                        }
                        //写入登录日志
                        mylog.user_id = model.user_id;
                        mylog.user_name = model.user_name;
                        mylog.action_type = "订单";
                        mylog.add_time = DateTime.Now;
                        mylog.remark = "确认订单(订单号:" + order_no + ")";
                        mylog.user_ip = AXRequest.GetIP();
                        mylog.Add();
                        context.Response.Write("{\"status\": 1, \"msg\": \"订单确认成功！\"}");
                    }
                    else
                    {
                        context.Response.Write("{\"status\": 0, \"msg\": \"订单确认失败！"+ EpicorOrderNumber +"\"}");
                    }

                }

                break;
            //order_design, order_confirm_design, order_quote, order_confirm_quote, order_pay, order_confirm_pay
            case "order_design": //完成订单=========================================

                if (model.status >= 3)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单已经设计，不能重复处理！\"}");
                    return;
                }

                

                model.status = 3;
                model.designtime = DateTime.Now;
                model.backremark = "";

                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单设计失败！\"}");
                    return;
                }

                //写入登录日志
                mylog.user_id = model.user_id;
                mylog.user_name = model.user_name;
                mylog.action_type = "订单";
                mylog.add_time = DateTime.Now;
                mylog.remark = "设计订单(订单号:"+order_no+")";
                mylog.user_ip = AXRequest.GetIP();
                mylog.Add();

                context.Response.Write("{\"status\": 1, \"msg\": \"设计订单完成！\"}");
                break;
            case "order_confirm_design": //完成订单=========================================
                                         //order_design, order_confirm_design, order_quote, order_confirm_quote, order_pay, order_confirm_pay
                if (model.status >= 4)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单已经确认设计，不能重复处理！\"}");
                    return;
                }
                bllEpicor.CreateNewPartForOrder(order_no);

                model.status = 4;
                model.comfirmdesigntime = DateTime.Now;
                model.backremark = "";
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"确认设计失败！\"}");
                    return;
                }

                //写入登录日志
                mylog.user_id = model.user_id;
                mylog.user_name = model.user_name;
                mylog.action_type = "订单";
                mylog.add_time = DateTime.Now;
                mylog.remark = "确认设计订单(订单号:"+order_no+")";
                mylog.user_ip = AXRequest.GetIP();
                mylog.Add();

                context.Response.Write("{\"status\": 1, \"msg\": \"设计订单完成！\"}");
                break;
            case "order_quote": //报价订单=========================================
                                //order_design, order_confirm_design, order_quote, order_confirm_quote, order_pay, order_confirm_pay
                if (model.status >= 5)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单已经报价，不能重复处理！\"}");
                    return;
                }
                model.status = 5;
                model.quotetime = DateTime.Now;
                model.backremark = "";
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"报价失败！\"}");
                    return;
                }

                //写入登录日志
                mylog.user_id = model.user_id;
                mylog.user_name = model.user_name;
                mylog.action_type = "订单";
                mylog.add_time = DateTime.Now;
                mylog.remark = "报价订单(订单号:"+order_no+")";
                mylog.user_ip = AXRequest.GetIP();
                mylog.Add();

                context.Response.Write("{\"status\": 1, \"msg\": \"报价完成！\"}");
                break;
            case "order_confirm_quote": //确认报价订单=========================================
                                        //order_design, order_confirm_design, order_quote, order_confirm_quote, order_pay, order_confirm_pay
                if (model.status >= 6)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单已经确认报价，不能重复处理！\"}");
                    return;
                }
                model.status = 6;
                model.comfirmquotetime = DateTime.Now;
                model.backremark = "";
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"确认报价失败！\"}");
                    return;
                }

                //写入登录日志
                mylog.user_id = model.user_id;
                mylog.user_name = model.user_name;
                mylog.action_type = "订单";
                mylog.add_time = DateTime.Now;
                mylog.remark = "确认报价订单(订单号:"+order_no+")";
                mylog.user_ip = AXRequest.GetIP();
                mylog.Add();

                context.Response.Write("{\"status\": 1, \"msg\": \"确认报价！\"}");
                break;
            case "order_pay": //汇款订单=========================================
                              //order_design, order_confirm_design, order_quote, order_confirm_quote, order_pay, order_confirm_pay
                if (model.status >= 7)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单已经汇款，不能重复处理！\"}");
                    return;
                }
                model.status = 7;
                model.paytime = DateTime.Now;
                model.backremark = "";
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"汇款失败！\"}");
                    return;
                }

                //写入登录日志
                mylog.user_id = model.user_id;
                mylog.user_name = model.user_name;
                mylog.action_type = "订单";
                mylog.add_time = DateTime.Now;
                mylog.remark = "汇款订单(订单号:"+order_no+")";
                mylog.user_ip = AXRequest.GetIP();
                mylog.Add();

                context.Response.Write("{\"status\": 1, \"msg\": \"汇款完成！\"}");
                break;
            case "order_confirm_pay": //确认汇款订单=========================================
                                      //order_design, order_confirm_design, order_quote, order_confirm_quote, order_pay, order_confirm_pay
                if (model.status >= 8)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单已经确认汇款，不能重复处理！\"}");
                    return;
                }
                //Post销售单到Epicor
                EpicorOrderNumber = "";
                OrgEpicorOrderNumber = "";
                //if (bllOrderGoods.IsOrerExistCustStyle(order_no)==false)
                //{
                //    OrgEpicorOrderNumber = bllEpicor.PostSalesOrderToEpicor(order_no);
                //    if (OrgEpicorOrderNumber != "")
                //    {
                //        EpicorOrderNumber = OrgEpicorOrderNumber + "(销售单)";
                //    }
                //    if (OrgEpicorOrderNumber == "")
                //    {
                //        context.Response.Write("{\"status\": 0, \"msg\": \"确认汇款失败！\"}");
                //        return;
                //    }
                //    else
                //    {
                //        ps_orders bllorders = new ps_orders();
                //        bllorders.UpdateEpicorOrderNo(order_no, EpicorOrderNumber);
                //    }
                //}
                OrgEpicorOrderNumber = bllEpicor.PostSalesOrderToEpicor(order_no);
                if (OrgEpicorOrderNumber != "")
                {
                    EpicorOrderNumber = OrgEpicorOrderNumber + "(销售单)";
                }
                if (OrgEpicorOrderNumber == "")
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"确认汇款失败！\"}");
                    return;
                }
                else
                {
                    ps_orders bllorders = new ps_orders();
                    bllorders.UpdateEpicorOrderNo(order_no, EpicorOrderNumber);
                }


                model.status = 8;
                model.comfirmpaytime = DateTime.Now;
                model.backremark = "";
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"确认汇款失败！\"}");
                    return;
                }

                //写入登录日志
                mylog.user_id = model.user_id;
                mylog.user_name = model.user_name;
                mylog.action_type = "订单";
                mylog.add_time = DateTime.Now;
                mylog.remark = "确认汇款订单(订单号:"+order_no+")";
                mylog.user_ip = AXRequest.GetIP();
                mylog.Add();

                context.Response.Write("{\"status\": 1, \"msg\": \"确认汇款完成！\"}");
                break;
            case "order_complete": //完成订单=========================================

                if (model.status >=9)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单已经完成，不能重复处理！\"}");
                    return;
                }
                model.status = 9;
                model.complete_time = DateTime.Now;
                model.backremark = "";
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"确认订单完成失败！\"}");
                    return;
                }

                //写入登录日志
                mylog.user_id = model.user_id;
                mylog.user_name = model.user_name;
                mylog.action_type = "订单";
                mylog.add_time = DateTime.Now;
                mylog.remark = "完成订单(订单号:"+order_no+")";
                mylog.user_ip = AXRequest.GetIP();
                mylog.Add();

                context.Response.Write("{\"status\": 1, \"msg\": \"确认订单完成成功！\"}");
                break;
            case "order_cancel": //取消订单==========================================

                if (model.status >= 10)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单已经完成，不能取消订单！\"}");
                    return;
                }
                model.status = 10;
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"取消订单失败！\"}");
                    return;
                }
                //bllEpicor.CancelQuoteToEpicor(model.order_no, model.epicor_order_no.Replace("(报价单)", ""));
                if(model.epicor_order_no!="" && model.epicor_order_no!="未生成")
                    model.CancelEpicorQuote(Convert.ToInt32(model.epicor_order_no.Replace("(报价单)", "")));
                //写入登录日志
                mylog.user_id = model.user_id;
                mylog.user_name = model.user_name;
                mylog.action_type = "订单";
                mylog.add_time = DateTime.Now;
                mylog.remark = "取消订单(订单号:"+order_no+")";
                mylog.user_ip = AXRequest.GetIP();
                mylog.Add();

                context.Response.Write("{\"status\": 1, \"msg\": \"订单已取消！\"}");
                break;

            case "edit_order_remark": //修改订单备注=================================
                string remark = AXRequest.GetFormString("remark");
                if (remark == "")
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"请填写订单备注内容！\"}");
                    return;
                }
                model.remark = remark;
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"修改订单备注失败！\"}");
                    return;
                }

                //写入登录日志
                mylog.user_id = model.user_id;
                mylog.user_name = model.user_name;
                mylog.action_type = "订单";
                mylog.add_time = DateTime.Now;
                mylog.remark = "修改订单备注(订单号:"+order_no+")";
                mylog.user_ip = AXRequest.GetIP();
                mylog.Add();

                context.Response.Write("{\"status\": 1, \"msg\": \"修改订单备注成功！\"}");
                break;

            case "edit_payment_fee": //调整商品总金额================================

                if (model.status > 1)
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"订单已经确认，不能调整商品实际总金额！\"}");
                    return;
                }
                decimal payment_fee = AXRequest.GetFormDecimal("payment_fee", 0);

                model.order_amount = payment_fee;
                model.real_amount = payment_fee - model.payable_amount;
                if (!model.Update())
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"调整商品实际总金额失败！\"}");
                    return;
                }

                //写入登录日志
                mylog.user_id = model.user_id;
                mylog.user_name = model.user_name;
                mylog.action_type = "订单";
                mylog.add_time = DateTime.Now;
                mylog.remark = "调整商品实际总金额(订单号:"+order_no+")";
                mylog.user_ip = AXRequest.GetIP();
                mylog.Add();
                context.Response.Write("{\"status\": 1, \"msg\": \"调整商品实际总金额成功！\"}");
                break;
        }

    }
    #endregion

    #region 验证用户账号是否重复========================
    private void manager_validate(HttpContext context)
    {
        string user_name = AXRequest.GetString("param");
        if (string.IsNullOrEmpty(user_name))
        {
            context.Response.Write("{ \"info\":\"Please input user account\", \"status\":\"n\" }");
            return;
        }
        ps_manager bll = new ps_manager();
        if (bll.Exists(user_name))
        {
            context.Response.Write("{ \"info\":\"User account already exist，please change！\", \"status\":\"n\" }");
            return;
        }
        context.Response.Write("{ \"info\":\"User account is valid\", \"status\":\"y\" }");
        return;
    }
    #endregion


    #region 验证商品名称是否重复========================
    private void code_validate(HttpContext context)
    {
        string product_name = AXRequest.GetString("param");
        if (string.IsNullOrEmpty(product_name))
        {
            context.Response.Write("{ \"info\":\"请输入商品名称\", \"status\":\"n\" }");
            return;
        }

        ps_here_depot bll = new ps_here_depot();
        if (bll.Exists(product_name))
        {
            context.Response.Write("{ \"info\":\"商品名称已被占用，请更换！\", \"status\":\"n\" }");
            return;
        }
        context.Response.Write("{ \"info\":\"商品名称可使用\", \"status\":\"y\" }");
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