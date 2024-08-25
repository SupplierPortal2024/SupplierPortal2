using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;   //for HttpWebRequest
using System.Net.Http;  //for HttpClient
using System.Net.Http.Headers;

using System.Security.Permissions;
using System.Web.Script.Serialization;
using System.Text;
using System.IO;

/// <summary>
/// Summary description for EpicorRequest
/// </summary>
public class EpicorRequest
{
    public EpicorRequest()
    {
        GetEpicorConfig("");
    }



    public static string UserAndPw = "";    //epicor UserID:Password
    public static string APIKey = "";
    public static string ServerName = "";
    public static string AppServerName = "";
    public static string AppCompany = "";
    public static string License = "";



    public void GetEpicorConfig(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select * ");
        strSql.Append(" FROM [ps_epicor_config] ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        DataSet ds = DbHelperSQL.Query(strSql.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            UserAndPw = AesEncryption.Decrypt(ds.Tables[0].Rows[0]["UserAndPw"].ToString());
            APIKey = AesEncryption.Decrypt(ds.Tables[0].Rows[0]["APIKey"].ToString());
            ServerName = ds.Tables[0].Rows[0]["ServerName"].ToString();
            AppServerName = ds.Tables[0].Rows[0]["AppServerName"].ToString();
            AppCompany = ds.Tables[0].Rows[0]["Company"].ToString();
            License = ds.Tables[0].Rows[0]["License"].ToString();
        }
    }


    private void HttpSendRequest(string HTTPMethods, string RequestURL, string epicorLogin, string XAPIKey, string jsonStr, ref string ResponseStatusCode, ref string ResponseBody, ref string IsSuccessStatusCode, ref string ErrorMessage, ref string ExceptionMsg)
    {
        try
        {
            //Ignore SSL certificates
            var handler = new WebRequestHandler();
            handler.ServerCertificateValidationCallback = delegate { return true; };

            using (HttpClient client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(epicorLogin)));
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-API-Key", XAPIKey);
                string TokenCreateURL = RequestURL;
                var request = new HttpRequestMessage();
                HttpResponseMessage response = null;

                if (HTTPMethods == "POST")
                {
                    request.RequestUri = new Uri(TokenCreateURL);
                    request.Method = HttpMethod.Post;

                    //send user credential
                    request.Content = new StringContent(jsonStr, Encoding.GetEncoding("UTF-8"), "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    response = client.SendAsync(request).Result;
                    ResponseStatusCode = Convert.ToString((int)response.StatusCode);
                }

                if (HTTPMethods == "DELETE")
                {
                    response = client.DeleteAsync(TokenCreateURL).Result;
                    ResponseStatusCode = Convert.ToString((int)response.StatusCode);
                }

                if (HTTPMethods == "GET")
                {
                    response = client.GetAsync(TokenCreateURL).Result;
                    ResponseStatusCode = Convert.ToString((int)response.StatusCode);
                }

                //Get response


                if (response.IsSuccessStatusCode)
                {
                    IsSuccessStatusCode = "Yes";
                }
                else
                {
                    IsSuccessStatusCode = "No";
                }

                ResponseBody = response.Content.ReadAsStringAsync().Result;

                //Deserialize ResponseBody and catch "ErrorMessage"
                if (ResponseBody.IndexOf("\"ErrorMessage\"") > 0)
                {
                    dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);

                    foreach (var obj in dyn)
                    {
                        if (obj.Name == "ErrorMessage")
                        {
                            ErrorMessage = Convert.ToString(obj.Value);
                            break;
                        }
                    }
                }
            }
        }
        catch (AggregateException ex)
        {
            ExceptionMsg = ex.ToString();
        }
    }

    public ps_epicor_vendor[] GetEpicorVenderList(string vendorid)
    {
        try
        {
            //final RequestURL
            string RequestURL = "";
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/ud_SupPortalVendReg/Data";
            if(vendorid!="")
                RequestURL  = RequestURL  + "?%24filter=Vendor_VendorID%20eq%20'" + vendorid + "' ";

            

            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);


            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            if (dyn == null) return null;
            List<ps_epicor_vendor> lsEpicorVendor = new List<ps_epicor_vendor> { };
            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    ps_epicor_vendor model = new ps_epicor_vendor();
                    //if (obj.Value.Count > 0)
                    //    model.DeleteAll();
                    for (int i = 0; i < obj.Value.Count; i++)
                    {
                        ps_epicor_vendor EpicorVendor = new ps_epicor_vendor();
                        EpicorVendor.Vendor_Company = obj.Value[i]["Vendor_Company"].ToString();
                        EpicorVendor.Vendor_VendorNum = obj.Value[i]["Vendor_VendorNum"].ToString();
                        EpicorVendor.Vendor_VendorID = obj.Value[i]["Vendor_VendorID"].ToString();
                        EpicorVendor.Vendor_Name = obj.Value[i]["Vendor_Name"].ToString();
                        EpicorVendor.Vendor_Approved = obj.Value[i]["Vendor_Approved"].ToString();
                        EpicorVendor.Vendor_CurrencyCode = obj.Value[i]["Vendor_CurrencyCode"].ToString();
                        EpicorVendor.Vendor_TermsCode = obj.Value[i]["Vendor_TermsCode"].ToString();
                        EpicorVendor.Vendor_BRNum_c = obj.Value[i]["Vendor_BRNum_c"].ToString();
                        EpicorVendor.Vendor_BRExpiryDate_c = Convert.ToDateTime(obj.Value[i]["Vendor_BRExpiryDate_c"].ToString() == "" ? "9999-12-31" : obj.Value[i]["Vendor_BRExpiryDate_c"].ToString());
                        EpicorVendor.Vendor_OrgRegCode = obj.Value[i]["Vendor_OrgRegCode"].ToString();
                        EpicorVendor.Vendor_PhoneNum = obj.Value[i]["Vendor_PhoneNum"].ToString();
                        EpicorVendor.Vendor_FaxNum = obj.Value[i]["Vendor_FaxNum"].ToString();
                        EpicorVendor.Vendor_EMailAddress = obj.Value[i]["Vendor_EMailAddress"].ToString();
                        EpicorVendor.Vendor_Address1 = obj.Value[i]["Vendor_Address1"].ToString();
                        EpicorVendor.Vendor_Address2 = obj.Value[i]["Vendor_Address2"].ToString();
                        EpicorVendor.Vendor_Address3 = obj.Value[i]["Vendor_Address3"].ToString();
                        EpicorVendor.Vendor_City = obj.Value[i]["Vendor_City"].ToString();
                        EpicorVendor.Vendor_State = obj.Value[i]["Vendor_State"].ToString();
                        EpicorVendor.Vendor_ZIP = obj.Value[i]["Vendor_ZIP"].ToString();
                        EpicorVendor.Vendor_Country = obj.Value[i]["Vendor_Country"].ToString();
                        EpicorVendor.Vendor_CountryNum = obj.Value[i]["Vendor_CountryNum"].ToString();
                        EpicorVendor.VendCnt_ConNum = obj.Value[i]["VendCnt_ConNum"].ToString();
                        EpicorVendor.VendCnt_PerConID = obj.Value[i]["VendCnt_PerConID"].ToString();
                        EpicorVendor.VendCnt_Name = obj.Value[i]["VendCnt_Name"].ToString();
                        EpicorVendor.VendCnt_Func = obj.Value[i]["VendCnt_Func"].ToString();
                        EpicorVendor.VendCnt_PhoneNum = obj.Value[i]["VendCnt_PhoneNum"].ToString();
                        EpicorVendor.VendCnt_CellPhoneNum = obj.Value[i]["VendCnt_CellPhoneNum"].ToString();
                        EpicorVendor.VendCnt_EmailAddress = obj.Value[i]["VendCnt_EmailAddress"].ToString();
                        EpicorVendor.VendCnt_UD_RFQRecipent_c = obj.Value[i]["VendCnt_UD_RFQRecipent_c"].ToString();
                        EpicorVendor.VendCnt_UD_PORecipient_c = obj.Value[i]["VendCnt_UD_PORecipient_c"].ToString();
                        EpicorVendor.Calculated_PrimaryContact = obj.Value[i]["Calculated_PrimaryContact"].ToString();
                        EpicorVendor.Vendor_PortalRegSubmit_c = obj.Value[i]["Vendor_PortalRegSubmit_c"].ToString();
                        EpicorVendor.Vendor_PortalRegExpiryDate_c = Convert.ToDateTime(obj.Value[i]["Vendor_PortalRegExpiryDate_c"].ToString() == "" ? "9999-12-30" : obj.Value[i]["Vendor_PortalRegExpiryDate_c"].ToString()); ; ;
                        EpicorVendor.Vendor_PortalResetPWTime_c = obj.Value[i]["Vendor_PortalResetPWTime_c"].ToString();
                        EpicorVendor.Vendor_PortalRegTempPW_c = obj.Value[i]["Vendor_PortalRegTempPW_c"].ToString();
                        EpicorVendor.Vendor_PortalRegEmailAddress_c = obj.Value[i]["Vendor_PortalRegEmailAddress_c"] == null ? "" : obj.Value[i]["Vendor_PortalRegEmailAddress_c"].ToString();
                        EpicorVendor.PurTerms_Description = obj.Value[i]["PurTerms_Description"] == null ? "" : obj.Value[i]["PurTerms_Description"].ToString();

                        EpicorVendor.VendorBank_BankID = obj.Value[i]["VendBank_BankID"].ToString();
                        EpicorVendor.VendorBank_BankName = obj.Value[i]["VendBank_BankName"].ToString();
                        EpicorVendor.VendorBank_CountryNum = obj.Value[i]["VendBank_CountryNum"].ToString();
                        EpicorVendor.VendorBank_BankAcctNumber = obj.Value[i]["VendBank_BankAcctNumber"].ToString();
                        EpicorVendor.VendorBank_NameOnAccount = obj.Value[i]["VendBank_NameOnAccount"].ToString();
                        EpicorVendor.VendorBank_PayMethodType = obj.Value[i]["VendBank_PMUID"].ToString();
                        EpicorVendor.VendorBank_SwiftNum = obj.Value[i]["VendBank_SwiftNum"].ToString();
                        EpicorVendor.VendorBank_IBANABABSBCode = obj.Value[i]["VendBank_IBANCode"].ToString();


                        lsEpicorVendor.Add(EpicorVendor);


                        EpicorVendor.Add();
                        EpicorVendor.UpdateVendorTempInfoByCompanyAndVerdorID(obj.Value[i]["Vendor_Company"].ToString(), obj.Value[i]["Vendor_VendorID"].ToString());
                        EpicorVendor.UpdateVendorByCompanyAndVerdorID(obj.Value[i]["Vendor_Company"].ToString(), obj.Value[i]["Vendor_VendorID"].ToString(), false);
                    }
                }
            }
            return lsEpicorVendor.ToArray();

        }
        catch (AggregateException ex)
        {
            return null;
        }
    }


    public ps_epicor_vendorbank[] GetEpicorVenderBankList()
    {
        try
        {
            //final RequestURL
            string RequestURL = "";
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.VendBankSearchSvc/List";
          

            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);
            //strSql.Append("VendorBank_Company,VendorBank_VendorNum,VendorBank_BankID,VendorBank_BankName,VendorBank_CountryNum,VendorBank_BankAcctNumber,VendorBank_NameOnAccount,
            //VendorBank_PayMethodType,VendorBank_SwiftNum,Create_Date)");

            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            if (dyn == null) return null;
            List<ps_epicor_vendorbank> lsEpicorVendorBank = new List<ps_epicor_vendorbank> { };
            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    ps_epicor_vendorbank model = new ps_epicor_vendorbank();
                    
                    for (int i = 0; i < obj.Value.Count; i++)
                    {
                        ps_epicor_vendorbank EpicorVendorBank = new ps_epicor_vendorbank();
                        EpicorVendorBank.VendorBank_Company = obj.Value[i]["Company"].ToString();
                        EpicorVendorBank.VendorBank_VendorNum = obj.Value[i]["VendorNum"].ToString();
                        EpicorVendorBank.VendorBank_BankID = obj.Value[i]["BankID"].ToString();
                        EpicorVendorBank.VendorBank_BankName = obj.Value[i]["BankName"].ToString();
                        EpicorVendorBank.VendorBank_CountryNum = obj.Value[i]["CountryNum"].ToString();
                        EpicorVendorBank.VendorBank_BankAcctNumber = obj.Value[i]["BankAcctNumber"].ToString();
                        EpicorVendorBank.VendorBank_NameOnAccount = obj.Value[i]["NameOnAccount"].ToString();
                        EpicorVendorBank.VendorBank_PayMethodType = obj.Value[i]["PayMethodType"].ToString();

                        EpicorVendorBank.VendorBank_SwiftNum = obj.Value[i]["SwiftNum"].ToString();


                        lsEpicorVendorBank.Add(EpicorVendorBank);


                        EpicorVendorBank.Add(EpicorVendorBank);
                    }
                }
            }
            return lsEpicorVendorBank.ToArray();

        }
        catch (AggregateException ex)
        {
            return null;
        }
    }

    public class EpicorVendor
    {
        public string Company { get; set; }
        public string VendorID { get; set; }
        public string Name { get; set; }
        public int VendorNum { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string FaxNum { get; set; }
        public string PhoneNum { get; set; }
        public string EMailAddress { get; set; }
        public string PortalResetPWTime_c { get; set; }

        public string ZIP { get; set; }
        public string OrgRegCode { get; set; }
        public string BRNum_c { get; set; }
        public DateTime BRExpiryDate_c { get; set; }

        public List<VendCntMains> VendCntMains { get; set; }
    }

    public class EpicorVendorMain
    {
        public string Company { get; set; }
        public string VendorID { get; set; }
        public string Name { get; set; }
        public int VendorNum { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string FaxNum { get; set; }
        public string PhoneNum { get; set; }
        public string EMailAddress { get; set; }
        public string PortalResetPWTime_c { get; set; }

        public string ZIP { get; set; }
        public string OrgRegCode { get; set; }
        public string BRNum_c { get; set; }
        public DateTime BRExpiryDate_c { get; set; }

    }

    public class VendCntMains
    {
        public string Company { get; set; }
        public int VendorNum { get; set; }
        public int ConNum { get; set; }
        public string Name { get; set; }
        public string Func { get; set; }
        public string CellPhoneNum { get; set; }
        public string PhoneNum { get; set; }
        public string EmailAddress { get; set; }
        public bool PrimaryContact { get; set; }
        public bool UD_PORecipient_c { get; set; }
        public bool UD_RFQRecipent_c { get; set; }

        


    }    

    public string PostVendorToEpicor(string Company, string VendorID)
    {
        ps_epicor_vendor bllVendor = new ps_epicor_vendor();
        bllVendor.GetModelByVendorID(Company, VendorID);
        string VendorNum = "";


        
        List<VendCntMains> lsVendCnts = new List<VendCntMains>();
        if (bllVendor != null)
        {
            try
            {
                if (bllVendor != null)
                {
                    DataSet dsContact = bllVendor.GetList(" Vendor_Company = '" + bllVendor.Vendor_Company + "' and Vendor_VendorID = '" + bllVendor.Vendor_VendorID + "' and VendCnt_ConNum<>'' ");
                    if (dsContact.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsContact.Tables[0].Rows.Count; i++)
                        {
                            VendCntMains VendCnt = new VendCntMains();
                            VendCnt.Company = dsContact.Tables[0].Rows[i]["Vendor_Company"].ToString();
                            VendCnt.VendorNum = Convert.ToInt32(dsContact.Tables[0].Rows[i]["Vendor_VendorNum"].ToString());
                            VendCnt.ConNum = Convert.ToInt32(dsContact.Tables[0].Rows[i]["VendCnt_ConNum"].ToString());
                            VendCnt.Name = dsContact.Tables[0].Rows[i]["VendCnt_Name"].ToString();
                            VendCnt.Func = dsContact.Tables[0].Rows[i]["VendCnt_Func"].ToString();
                            VendCnt.PhoneNum = dsContact.Tables[0].Rows[i]["VendCnt_PhoneNum"].ToString();
                            VendCnt.CellPhoneNum = dsContact.Tables[0].Rows[i]["VendCnt_CellPhoneNum"].ToString();
                            VendCnt.EmailAddress = dsContact.Tables[0].Rows[i]["VendCnt_EmailAddress"].ToString();
                            VendCnt.PrimaryContact = dsContact.Tables[0].Rows[i]["Calculated_PrimaryContact"].ToString() == "True ? true : false";
                            VendCnt.UD_PORecipient_c = dsContact.Tables[0].Rows[i]["Vendor_Company"].ToString() == "True ? true : false";
                            VendCnt.UD_RFQRecipent_c = dsContact.Tables[0].Rows[i]["Vendor_Company"].ToString() == "True ? true : false";
                            lsVendCnts.Add(VendCnt);
                        }

                    }
                    string isoJson = "";
                    if (lsVendCnts.Count > 0)
                    {
                        EpicorVendor entry = new EpicorVendor
                        {
                            Company = bllVendor.Vendor_Company,
                            VendorID = bllVendor.Vendor_VendorID,
                            Name = bllVendor.Vendor_Name,
                            VendorNum = Convert.ToInt32(bllVendor.Vendor_VendorNum),
                            Address1 = bllVendor.Vendor_Address1,
                            Address2 = bllVendor.Vendor_Address2,
                            Address3 = bllVendor.Vendor_Address3,
                            City = bllVendor.Vendor_City,
                            State = bllVendor.Vendor_State,
                            Country = bllVendor.Vendor_Country,
                            FaxNum = bllVendor.Vendor_FaxNum,
                            PhoneNum = bllVendor.Vendor_PhoneNum,
                            EMailAddress = bllVendor.Vendor_EMailAddress,
                            ZIP = bllVendor.Vendor_ZIP,
                            OrgRegCode = bllVendor.Vendor_OrgRegCode,
                            BRNum_c = bllVendor.Vendor_BRNum_c,
                            BRExpiryDate_c = bllVendor.Vendor_BRExpiryDate_c == null ? new DateTime(9999, 12, 31) : Convert.ToDateTime(bllVendor.Vendor_BRExpiryDate_c),
                        };

                        entry.VendCntMains = lsVendCnts;
                        isoJson = JsonConvert.SerializeObject(entry);
                    }
                    else
                    {
                        EpicorVendorMain entry = new EpicorVendorMain
                        {
                            Company = bllVendor.Vendor_Company,
                            VendorID = bllVendor.Vendor_VendorID,
                            Name = bllVendor.Vendor_Name,
                            VendorNum = Convert.ToInt32(bllVendor.Vendor_VendorNum),
                            Address1 = bllVendor.Vendor_Address1,
                            Address2 = bllVendor.Vendor_Address2,
                            Address3 = bllVendor.Vendor_Address3,
                            City = bllVendor.Vendor_City,
                            State = bllVendor.Vendor_State,
                            Country = bllVendor.Vendor_Country,
                            FaxNum = bllVendor.Vendor_FaxNum,
                            PhoneNum = bllVendor.Vendor_PhoneNum,
                            EMailAddress = bllVendor.Vendor_EMailAddress,
                            //PortalResetPWTime_c = "null",
                            ZIP = bllVendor.Vendor_ZIP,
                            OrgRegCode = bllVendor.Vendor_OrgRegCode,
                            BRNum_c = bllVendor.Vendor_BRNum_c,
                            BRExpiryDate_c = bllVendor.Vendor_BRExpiryDate_c == null ? new DateTime(9999, 12, 31) : Convert.ToDateTime(bllVendor.Vendor_BRExpiryDate_c),


                        };
                        isoJson = JsonConvert.SerializeObject(entry);
                    }

                    //string isoJson = JsonConvert.SerializeObject(entry);    //Convert DataEntry to Json string

                    isoJson = isoJson.Replace("\r\n", "");
                    isoJson = isoJson.Replace("\"0001-01-01T00:00:00Z\"", "null");
                    isoJson = isoJson.Replace("00:00:00", "00:00:00Z");

                    //final RequestURL
                    string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.VendorSvc/Vendors";
                    RequestURL = RequestURL.Replace("{ServerName}", ServerName);
                    RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
                    RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);



                    string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
                    HTTPMethods = "POST";
                    HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);

                    string strHTTPStatusCode = ResponseStatusCode;
                    string strResponseBody = ResponseBody;
                    string strExceptionMsg = ExceptionMsg;
                    string strTDeserializeResponseBodyErrorMessage = ErrorMessage;

                    if (ResponseStatusCode == "201")
                    {
                        //JavaScriptSerializer jss = new JavaScriptSerializer();
                        //反序列化成Part对象
                        //PartData partData = jss.Deserialize<PartData>(ResponseBody);
                        dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
                        if (dyn == null) return null;
                        //List<PartData> lsPartDatas = new List<PartData> { };
                        foreach (var obj in dyn)
                        {
                            if (obj.Name == "VendorNum")
                            {
                                VendorNum = obj.Value;
                                break;
                            }
                        }
                    }
                    ////写入登录日志
                    ps_manager_log mylog = new ps_manager_log();
                    mylog.user_id = 1;
                    mylog.user_name = "API";
                    mylog.action_type = "Epcior";
                    mylog.add_time = DateTime.Now;
                    mylog.remark = "Update Vendor(Vendor:" + Company + " -" + VendorID + ")";
                    mylog.user_ip = AXRequest.GetIP();
                    mylog.Add();
                }
                return VendorNum;

            }
            catch (AggregateException ex)
            {
                string strExceptionMsg = ex.ToString();
                return "Error:" + strExceptionMsg;
            }
        }
        else
            return "Error";
    }



    public class EpicorVendorStatus
    {
        public string Company { get; set; }
        public string VendorID { get; set; }
        public int VendorNum { get; set; }
        public string ud_SPortalInfoUpdateStatus_c { get; set; }
        public DateTime ud_SPortalUpdateDateTime_c { get; set; }

    }

    public string PostVendorStatusToEpicor(string Company, string VendorID)
    {
        ps_epicor_vendor bllVendor = new ps_epicor_vendor();
        bllVendor.GetModelByVendorID(Company, VendorID);
        string VendorNum = "";


        List<VendCntMains> lsVendCnts = new List<VendCntMains>();
        if (bllVendor != null && bllVendor.Vendor_VendorID != "")
        {
            try
            {
                if (bllVendor != null && bllVendor.Vendor_VendorID!="")
                {
                    
                    string isoJson = "";
                    
                    EpicorVendorStatus entry = new EpicorVendorStatus
                    {
                        Company = bllVendor.Vendor_Company,
                        VendorID = bllVendor.Vendor_VendorID,
                        VendorNum = Convert.ToInt32(bllVendor.Vendor_VendorNum),
                        ud_SPortalInfoUpdateStatus_c = "Submitted",
                        ud_SPortalUpdateDateTime_c = System.DateTime.Now,
                    };

                    isoJson = JsonConvert.SerializeObject(entry);
                    

                    //string isoJson = JsonConvert.SerializeObject(entry);    //Convert DataEntry to Json string

                    isoJson = isoJson.Replace("\r\n", "");
                    isoJson = isoJson.Replace("\"0001-01-01T00:00:00Z\"", "null");
                    isoJson = isoJson.Replace("00:00:00", "00:00:00Z");

                    //final RequestURL
                    string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.VendorSvc/Vendors";
                    RequestURL = RequestURL.Replace("{ServerName}", ServerName);
                    RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
                    RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);



                    string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
                    HTTPMethods = "POST";
                    HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);

                    string strHTTPStatusCode = ResponseStatusCode;
                    string strResponseBody = ResponseBody;
                    string strExceptionMsg = ExceptionMsg;
                    string strTDeserializeResponseBodyErrorMessage = ErrorMessage;

                    if (ResponseStatusCode == "201")
                    {
                        //JavaScriptSerializer jss = new JavaScriptSerializer();
                        //反序列化成Part对象
                        //PartData partData = jss.Deserialize<PartData>(ResponseBody);
                        dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
                        //Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
                        //List<PartData> lsPartDatas = new List<PartData> { };
                        foreach (var obj in dyn)
                        {
                            if (obj.Name == "VendorNum")
                            {
                                VendorNum = obj.Value;
                                break;
                            }
                        }
                    }
                    ////写入登录日志
                    ps_manager_log mylog = new ps_manager_log();
                    mylog.user_id = 1;
                    mylog.user_name = "API";
                    mylog.action_type = "Epcior";
                    mylog.add_time = DateTime.Now;
                    mylog.remark = "Submit Vendor(Vendor:" + Company + " -" + VendorID + ")";
                    mylog.user_ip = AXRequest.GetIP();
                    mylog.Add();
                }
                return VendorNum;

            }
            catch (AggregateException ex)
            {
                string strExceptionMsg = ex.ToString();
                return "Error:" + strExceptionMsg;
            }
        }
        else
            return "Error";
    }


    public class EpicorVendor2
    {
        public string Company { get; set; }
        public string VendorID { get; set; }
        public string Name { get; set; }
        public int VendorNum { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string FaxNum { get; set; }
        public string PhoneNum { get; set; }
        public string EMailAddress { get; set; }
        public string PortalResetPWTime_c { get; set; }

        public string ZIP { get; set; }
        public string OrgRegCode { get; set; }
        public string BRNum_c { get; set; }
    }

    public string PostVendorPortalResetPWTimeToEpicor(string Company, string VendorID)
    {
        ps_epicor_vendor bllVendor = new ps_epicor_vendor();
        bllVendor.GetModelByVendorID(Company, VendorID);
        string VendorNum = "";



        if (bllVendor != null)
        {
            try
            {
                if (bllVendor != null)
                {
                    EpicorVendor2 entry = new EpicorVendor2
                    {
                        Company = bllVendor.Vendor_Company,

                        VendorID = bllVendor.Vendor_VendorID,
                        Name = bllVendor.Vendor_Name,
                        VendorNum = Convert.ToInt32(bllVendor.Vendor_VendorNum),
                        Address1 = bllVendor.Vendor_Address1,
                        Address2 = bllVendor.Vendor_Address2,
                        Address3 = bllVendor.Vendor_Address3,
                        City = bllVendor.Vendor_City,
                        State = bllVendor.Vendor_State,
                        Country = bllVendor.Vendor_Country,
                        FaxNum = bllVendor.Vendor_FaxNum,
                        PhoneNum = bllVendor.Vendor_PhoneNum,
                        EMailAddress = bllVendor.Vendor_EMailAddress,
                        //PortalResetPWTime_c = System.DateTime.Now.ToLocalTime().ToString(),
                        PortalResetPWTime_c = System.DateTime.Now.AddHours(-8).GetDateTimeFormats('s')[0].ToString()+ ".835Z",
                        //PortalResetPWTime_c = "2023-11-23T14:33:34.835Z",


                    };

                    string isoJson = JsonConvert.SerializeObject(entry);    //Convert DataEntry to Json string

                    isoJson = isoJson.Replace("\r\n", "");
                    isoJson = isoJson.Replace("\"0001-01-01T00:00:00Z\"", "null");
                    isoJson = isoJson.Replace("00:00:00", "00:00:00Z");

                    //final RequestURL
                    string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.VendorSvc/Vendors";
                    RequestURL = RequestURL.Replace("{ServerName}", ServerName);
                    RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
                    RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);



                    string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
                    HTTPMethods = "POST";
                    HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);

                    string strHTTPStatusCode = ResponseStatusCode;
                    string strResponseBody = ResponseBody;
                    string strExceptionMsg = ExceptionMsg;
                    string strTDeserializeResponseBodyErrorMessage = ErrorMessage;

                    if (ResponseStatusCode == "201")
                    {
                        //JavaScriptSerializer jss = new JavaScriptSerializer();
                        //反序列化成Part对象
                        //PartData partData = jss.Deserialize<PartData>(ResponseBody);
                        dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
                        if (dyn == null) return "Error";
                        //List<PartData> lsPartDatas = new List<PartData> { };
                        foreach (var obj in dyn)
                        {
                            if (obj.Name == "VendorNum")
                            {
                                VendorNum = obj.Value;
                                break;
                            }
                        }
                    }
                    ////写入登录日志
                    ps_manager_log mylog = new ps_manager_log();
                    mylog.user_id = 1;
                    mylog.user_name = "API";
                    mylog.action_type = "Epcior";
                    mylog.add_time = DateTime.Now;
                    mylog.remark = "Update Vendor(Vendor:" + Company + " -" + VendorID + ")";
                    mylog.user_ip = AXRequest.GetIP();
                    mylog.Add();
                }
                return VendorNum;

            }
            catch (AggregateException ex)
            {
                string strExceptionMsg = ex.ToString();
                return "Error:" + strExceptionMsg;
            }
        }
        else
            return "Error";
    }


    public ps_epicor_country[] GetEpicorCountryList()
    {
        try
        {
            //final RequestURL
            string RequestURL = "";
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/spFindCountry/Data";
            //if (CustID != "")
            //    RequestURL = RequestURL + "?% 24filter = Customer_CustID % 20eq % 20'{Customer_CustID}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/CustomerCredit/Data?%24filter=Calculated_Part%20eq%20'{Calculated_Part}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.PartSvc/Parts?$filter=Company%20eq%20'{Company}'";
            


            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);


            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            if (dyn == null) return null;
            List<ps_epicor_country> lsEpicorCountry = new List<ps_epicor_country> { };
            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    ps_epicor_country model = new ps_epicor_country();
                    if (obj.Value.Count > 0)
                        model.DeleteAll();
                    for (int i = 0; i < obj.Value.Count; i++)
                    {
                        ps_epicor_country EpicorCountry = new ps_epicor_country();
                        EpicorCountry.Country_Company = obj.Value[i]["Country_Company"].ToString();
                        EpicorCountry.Country_CountryNum = obj.Value[i]["Country_CountryNum"].ToString();
                        EpicorCountry.Country_Description = obj.Value[i]["Country_Description"].ToString();


                        lsEpicorCountry.Add(EpicorCountry);


                        EpicorCountry.Add();
                    }
                }
            }
            return lsEpicorCountry.ToArray();

        }
        catch (AggregateException ex)
        {
            return null;
        }
    }


    public ps_epicor_currency[] GetEpicorCurrencyList()
    {
        try
        {
            //final RequestURL
            string RequestURL = "";
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/spFindCcy/Data";
            
            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany == "" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);


            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            if (dyn == null) return null;
            List<ps_epicor_currency> lsEpicorCurrency = new List<ps_epicor_currency> { };
            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    ps_epicor_currency model = new ps_epicor_currency();
                    if (obj.Value.Count > 0)
                        model.DeleteAll();
                    for (int i = 0; i < obj.Value.Count; i++)
                    {
                        ps_epicor_currency EpicorCurrency = new ps_epicor_currency();
                        EpicorCurrency.Currency_Company = obj.Value[i]["Currency_Company"].ToString();
                        EpicorCurrency.Currency_CurrencyCode = obj.Value[i]["Currency_CurrencyCode"].ToString();
                        EpicorCurrency.Currency_CurrDesc = obj.Value[i]["Currency_CurrDesc"].ToString();


                        lsEpicorCurrency.Add(EpicorCurrency);


                        EpicorCurrency.Add();
                    }
                }
            }
            return lsEpicorCurrency.ToArray();

        }
        catch (AggregateException ex)
        {
            return null;
        }
    }

    public ps_epicor_paymethod[] GetEpicorPayMethodList()
    {
        try
        {
            //final RequestURL
            string RequestURL = "";
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/spFindPayMethod/Data";
            


            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany == "" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);


            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            if (dyn == null) return null;
            List<ps_epicor_paymethod> lsEpicorPayMethod = new List<ps_epicor_paymethod> { };
            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    ps_epicor_paymethod model = new ps_epicor_paymethod();
                    if (obj.Value.Count > 0)
                        model.DeleteAll();
                    for (int i = 0; i < obj.Value.Count; i++)
                    {
                        ps_epicor_paymethod EpicorPayMethod = new ps_epicor_paymethod();
                        EpicorPayMethod.PayMethod_Company = obj.Value[i]["PayMethod_Company"].ToString();
                        EpicorPayMethod.PayMethod_PMUID = obj.Value[i]["PayMethod_PMUID"].ToString();
                        EpicorPayMethod.PayMethod_Name = obj.Value[i]["PayMethod_Name"].ToString();


                        lsEpicorPayMethod.Add(EpicorPayMethod);


                        EpicorPayMethod.Add();
                    }
                }
            }
            return lsEpicorPayMethod.ToArray();

        }
        catch (AggregateException ex)
        {
            return null;
        }
    }

    public ps_epicor_po[] GetEpicorPOList(string VendorID)
    {
        try
        {
            (new ps_manager_log()).AddLog(System.Web.HttpContext.Current.Session["AID"].ToString(), System.Web.HttpContext.Current.Session["AdminName"].ToString(), "Sync PO List API Begin", "Sync PO List. Vendor:" + VendorID, AXRequest.GetIP());
            //final RequestURL
            string RequestURL = "";
            
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/ud_SupPortalPO/Data";
            if (VendorID != "")
                RequestURL = RequestURL + "?%24filter=Vendor_VendorID%20eq%20%27" + VendorID + "%27";

            //?% 24filter = Vendor_VendorID % 20eq % 20 % 27A042 % 27
            //RequestURL = RequestURL + "?% 24filter = Vendor_VendorID % 20eq % 20'" + VendorID + "'";
            //if (CustID != "")
            //    RequestURL = RequestURL + "?% 24filter = Customer_CustID % 20eq % 20'{Customer_CustID}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/CustomerCredit/Data?%24filter=Calculated_Part%20eq%20'{Calculated_Part}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.PartSvc/Parts?$filter=Company%20eq%20'{Company}'";

            


            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);


            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            (new ps_manager_log()).AddLog(System.Web.HttpContext.Current.Session["AID"].ToString(), System.Web.HttpContext.Current.Session["AdminName"].ToString(), "Sync PO List API End", "Sync PO List. Vendor:" + VendorID, AXRequest.GetIP());
            if (dyn == null) return null;
            List<ps_epicor_po> lsEpicorPO = new List<ps_epicor_po> { };
            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    ps_epicor_po model = new ps_epicor_po();
                    //if (obj.Value.Count > 0)
                    //    model.DeleteAll();
                    (new ps_manager_log()).AddLog(System.Web.HttpContext.Current.Session["AID"].ToString(), System.Web.HttpContext.Current.Session["AdminName"].ToString(), "Sync PO List Insert DB Begin", "Sync PO List. Vendor:" + VendorID + " . Record count:" + obj.Value.Count, AXRequest.GetIP());
                    for (int i = 0; i < obj.Value.Count; i++)
                    {

                        ps_epicor_po EpicorPO = new ps_epicor_po();
                        EpicorPO.Vendor_Company = obj.Value[i]["Vendor_Company"].ToString();
                        EpicorPO.Vendor_VendorID = obj.Value[i]["Vendor_VendorID"].ToString();
                        EpicorPO.Vendor_Name = obj.Value[i]["Vendor_Name"].ToString();
                        EpicorPO.POHeader_PONum = obj.Value[i]["POHeader_PONum"].ToString();
    
                        EpicorPO.POHeader_OrderDate = Convert.ToDateTime(obj.Value[i]["POHeader_OrderDate"].ToString() == "" ? "9999-12-30" : obj.Value[i]["POHeader_OrderDate"].ToString());
                        EpicorPO.PODetail_OpenLine = obj.Value[i]["PODetail_OpenLine"].ToString();
                        EpicorPO.PODetail_VoidLine = obj.Value[i]["PODetail_VoidLine"].ToString();
                        EpicorPO.PODetail_POLine = obj.Value[i]["PODetail_POLine"].ToString();


                        EpicorPO.PODetail_PartNum = obj.Value[i]["PODetail_PartNum"].ToString();
                        EpicorPO.PODetail_LineDesc = obj.Value[i]["PODetail_LineDesc"].ToString();
                        EpicorPO.PODetail_DocUnitCost = Convert .ToDecimal(obj.Value[i]["PODetail_DocUnitCost"].ToString());
                        EpicorPO.PODetail_OrderQty = Convert.ToDecimal(obj.Value[i]["PODetail_OrderQty"].ToString());
                        EpicorPO.PODetail_PUM = obj.Value[i]["PODetail_PUM"].ToString();
                        EpicorPO.PODetail_DocExtCost = Convert.ToDecimal(obj.Value[i]["PODetail_DocExtCost"].ToString());
                        EpicorPO.POHeader_CurrencyCode = obj.Value[i]["POHeader_CurrencyCode"].ToString();
                        

                        lsEpicorPO.Add(EpicorPO);


                        EpicorPO.Add();
                    }
                    (new ps_manager_log()).AddLog(System.Web.HttpContext.Current.Session["AID"].ToString(), System.Web.HttpContext.Current.Session["AdminName"].ToString(), "Sync RFQ List Insert DB End", "Sync RFQ List. Vendor:" + VendorID + " . Record count:" + obj.Value.Count, AXRequest.GetIP());
                }
            }
            return lsEpicorPO.ToArray();

        }
        catch (AggregateException ex)
        {
            return null;
        }
    }

    public ps_epicor_rfq[] GetEpicorRFQList(string VendorID)
    {
        try
        {
            (new ps_manager_log()).AddLog(System.Web.HttpContext.Current.Session["AID"].ToString(), System.Web.HttpContext.Current.Session["AdminName"].ToString(), "Sync RFQ List API Begin", "Sync RFQ List. Vendor:" + VendorID, AXRequest.GetIP());
            //final RequestURL
            string RequestURL = "";
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/ud_SupPortalRFQ/Data";
            if (VendorID != "")
                RequestURL = RequestURL + "?%24filter=Vendor_VendorID%20eq%20%27" + VendorID + "%27";
            //RequestURL = RequestURL + "?% 24filter = Vendor_VendorID % 20eq % 20'" + VendorID + "'";
            //if (CustID != "")
            //    RequestURL = RequestURL + "?% 24filter = Customer_CustID % 20eq % 20'{Customer_CustID}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/CustomerCredit/Data?%24filter=Calculated_Part%20eq%20'{Calculated_Part}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.PartSvc/Parts?$filter=Company%20eq%20'{Company}'";
            


            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);


            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            (new ps_manager_log()).AddLog(System.Web.HttpContext.Current.Session["AID"].ToString(), System.Web.HttpContext.Current.Session["AdminName"].ToString(), "Sync RFQ List API End", "Sync RFQ List. Vendor:" + VendorID, AXRequest.GetIP());
            if (dyn == null) return null;
            List<ps_epicor_rfq> lsEpicorRFQ = new List<ps_epicor_rfq> { };
            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    ps_epicor_rfq model = new ps_epicor_rfq();
                    //if (obj.Value.Count > 0)
                    //    model.DeleteAll();
                    (new ps_manager_log()).AddLog(System.Web.HttpContext.Current.Session["AID"].ToString(), System.Web.HttpContext.Current.Session["AdminName"].ToString(), "Sync RFQ List Insert DB Begin", "Sync RFQ List. Vendor:" + VendorID + " . Record count:" + obj.Value.Count, AXRequest.GetIP());
                    for (int i = 0; i < obj.Value.Count; i++)
                    {
                        
                        ps_epicor_rfq EpicorRFQ = new ps_epicor_rfq();
                        EpicorRFQ.RFQHead_Company = obj.Value[i]["RFQHead_Company"].ToString();
                        EpicorRFQ.RFQHead_OpenRFQ = obj.Value[i]["RFQHead_OpenRFQ"].ToString();
                        EpicorRFQ.RFQHead_RFQNum = obj.Value[i]["RFQHead_RFQNum"].ToString();
                        EpicorRFQ.RFQHead_RFQDate = Convert.ToDateTime(obj.Value[i]["RFQHead_RFQDate"].ToString() == "" ? "9999-12-30" : obj.Value[i]["RFQHead_RFQDate"].ToString());
                        EpicorRFQ.RFQHead_RFQDueDate = Convert.ToDateTime(obj.Value[i]["RFQHead_RFQDueDate"].ToString() == "" ? "9999-12-30" : obj.Value[i]["RFQHead_RFQDueDate"].ToString());
                        EpicorRFQ.RFQItem_RFQLine = Convert.ToInt32(obj.Value[i]["RFQItem_RFQLine"].ToString());
                        EpicorRFQ.RFQItem_PartNum = obj.Value[i]["RFQItem_PartNum"].ToString();
                        EpicorRFQ.RFQItem_LineDesc = obj.Value[i]["RFQItem_LineDesc"].ToString();
                        EpicorRFQ.RFQItem_PUM = obj.Value[i]["RFQItem_PUM"].ToString();
                        EpicorRFQ.RFQQty_QtyNum = obj.Value[i]["RFQQty_QtyNum"].ToString();
                        EpicorRFQ.RFQQty_Quantity = Convert.ToDecimal(obj.Value[i]["RFQQty_Quantity"].ToString());
                        EpicorRFQ.Vendor_VendorID = obj.Value[i]["Vendor_VendorID"].ToString();
                        EpicorRFQ.Vendor_Name = obj.Value[i]["Vendor_Name"].ToString();
                        EpicorRFQ.RFQHead_PostToSupPortalTime_c = obj.Value[i]["RFQHead_PostToSupPortalTime_c"].ToString();

                        EpicorRFQ.Calculated_DueDateTime = obj.Value[i]["Calculated_DueDateTime"].ToString();
                        EpicorRFQ.RFQVend_ud_SPortalstatus_c = obj.Value[i]["RFQVend_ud_SPortalStatus_c"] ==null ? "" : obj.Value[i]["RFQVend_ud_SPortalStatus_c"].ToString();
                        EpicorRFQ.RFQHead_Rptsubject_c = obj.Value[i]["RFQHead_RptSubject_c"] == null ? "" : obj.Value[i]["RFQHead_RptSubject_c"].ToString();

                        EpicorRFQ.Calculated_DueDateDsp = obj.Value[i]["Calculated_DueDateDsp"] == null ? "" : obj.Value[i]["Calculated_DueDateDsp"].ToString();
                        EpicorRFQ.Calculated_DueDateTimeDsp = obj.Value[i]["Calculated_DueDateTimeDsp"] == null ? "" : obj.Value[i]["Calculated_DueDateTimeDsp"].ToString();
                        EpicorRFQ.Calculated_RFQDateDsp = obj.Value[i]["Calculated_RFQDateDsp"] == null ? "" : obj.Value[i]["Calculated_RFQDateDsp"].ToString();
                        EpicorRFQ.Calculated_RFQExpired = obj.Value[i]["Calculated_RFQExpired"] == null ? "" : obj.Value[i]["Calculated_RFQExpired"].ToString();



                        lsEpicorRFQ.Add(EpicorRFQ);


                        EpicorRFQ.Add(EpicorRFQ);
                        EpicorRFQ.UpdateRFQCalculatedInfoBySyncTime(EpicorRFQ);
                        EpicorRFQ.UpdateRFQBySyncTime(EpicorRFQ);
                        
                    }
                    (new ps_manager_log()).AddLog(System.Web.HttpContext.Current.Session["AID"].ToString(), System.Web.HttpContext.Current.Session["AdminName"].ToString(), "Sync RFQ List Insert DB Begin", "Sync RFQ List. Vendor:" + VendorID + " . Record count:" + obj.Value.Count, AXRequest.GetIP());
                }
            }
            return lsEpicorRFQ.ToArray();

        }
        catch (AggregateException ex)
        {
            return null;
        }
    }

    

    public ps_epicor_rfq_head[] GetEpicorRFQRFHead(string VendorID)
    {
        try
        {
            (new ps_manager_log()).AddLog(System.Web.HttpContext.Current.Session["AID"].ToString(), System.Web.HttpContext.Current.Session["AdminName"].ToString(), "Sync RFQ Header API Begin", "Sync RFQ Header.", AXRequest.GetIP());
            //final RequestURL
            string RequestURL = "";
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/ud_SP_RFQ_Hed/Data";
            if (VendorID != "")
                RequestURL = RequestURL + "?%24filter=Vendor_VendorID%20eq%20%27" + VendorID + "%27";

            //if (CustID != "")
            //    RequestURL = RequestURL + "?% 24filter = Customer_CustID % 20eq % 20'{Customer_CustID}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/CustomerCredit/Data?%24filter=Calculated_Part%20eq%20'{Calculated_Part}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.PartSvc/Parts?$filter=Company%20eq%20'{Company}'";
            


            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);


            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            (new ps_manager_log()).AddLog(System.Web.HttpContext.Current.Session["AID"].ToString(), System.Web.HttpContext.Current.Session["AdminName"].ToString(), "Sync RFQ Header API End", "Sync RFQ Header.", AXRequest.GetIP());
            if (dyn == null) return null;
            List<ps_epicor_rfq_head> lsEpicorRFQHead = new List<ps_epicor_rfq_head> { };
            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    ps_epicor_rfq_ans model = new ps_epicor_rfq_ans();
                    //if (obj.Value.Count > 0)
                    (new ps_manager_log()).AddLog(System.Web.HttpContext.Current.Session["AID"].ToString(), System.Web.HttpContext.Current.Session["AdminName"].ToString(), "Sync RFQ Header Insert DB Begin", "Sync RFQ Header. ", AXRequest.GetIP());
                    //    model.DeleteAll();
                    for (int i = 0; i < obj.Value.Count; i++)
                    {
                        ps_epicor_rfq_head EpicorRFQHead = new ps_epicor_rfq_head();
                        EpicorRFQHead.RFQHead_Company = obj.Value[i]["RFQHead_Company"].ToString();
                        EpicorRFQHead.RFQHead_RFQNum = obj.Value[i]["RFQHead_RFQNum"].ToString();
                        EpicorRFQHead.RFQHead_OpenRFQ = obj.Value[i]["RFQHead_OpenRFQ"].ToString()=="true"?"1":"0";
                        EpicorRFQHead.RFQHead_PostDate = obj.Value[i]["RFQHead_RFQDate"] ==null ? null : Convert.ToDateTime(obj.Value[i]["RFQHead_RFQDate"].ToString());
                        EpicorRFQHead.RFQHead_RFQDueDate = obj.Value[i]["RFQHead_RFQDueDate"] == null ? null : Convert.ToDateTime(obj.Value[i]["RFQHead_RFQDueDate"].ToString());
                        EpicorRFQHead.RFQHead_DueTime_c = obj.Value[i]["Calculated_DueTime"].ToString();
                        EpicorRFQHead.RFQHead_RptSubject_c = obj.Value[i]["RFQHead_RptSubject_c"].ToString();
                        EpicorRFQHead.RFQHead_CommentText = obj.Value[i]["RFQHead_CommentText"].ToString();
                        EpicorRFQHead.RFQHead_DueTime_DelayMin_c = obj.Value[i]["RFQHead_DueTime_DelayMin_c"].ToString();
                        

                        lsEpicorRFQHead.Add(EpicorRFQHead);


                        EpicorRFQHead.Add(EpicorRFQHead);
                        EpicorRFQHead.Update(EpicorRFQHead);
                        
                    }
                    (new ps_manager_log()).AddLog(System.Web.HttpContext.Current.Session["AID"].ToString(), System.Web.HttpContext.Current.Session["AdminName"].ToString(), "Sync RFQ Header Insert DB End", "Sync RFQ Header. ", AXRequest.GetIP());
                }
            }
            return lsEpicorRFQHead.ToArray();

        }
        catch (AggregateException ex)
        {
            return null;
        }
    }

    public ps_epicor_rfq_ans[] GetEpicorRFQRFQANS(string RFQNumber, string VendorID)
    {
        try
        {
            //final RequestURL
            string RequestURL = "";
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/ud_SP_RFQ_ANS/Data";//?%24filter=UD34_Key1%20eq%20%27" + RFQNumber + "%27&%UD34_Key3%20eq%20%27" + VendorID + "%27";
            if (RFQNumber != "")
                RequestURL = RequestURL + "?%24filter=UD34_Key1%20eq%20%27"+ RFQNumber + "%27%20and%20UD34_Key3%20eq%20%27"+ VendorID + "%27";
            //if (CustID != "")
            //    RequestURL = RequestURL + "?% 24filter = Customer_CustID % 20eq % 20'{Customer_CustID}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/CustomerCredit/Data?%24filter=Calculated_Part%20eq%20'{Calculated_Part}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.PartSvc/Parts?$filter=Company%20eq%20'{Company}'";
            


            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);


            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            if (dyn == null) return null;
            List<ps_epicor_rfq_ans> lsEpicorRFQANS = new List<ps_epicor_rfq_ans> { };
            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    ps_epicor_rfq_ans model = new ps_epicor_rfq_ans();
                    //if (obj.Value.Count > 0)
                    //    model.DeleteAll();
                    for (int i = 0; i < obj.Value.Count; i++)
                    {

                        ps_epicor_rfq_ans EpicorRFQANS = new ps_epicor_rfq_ans();
                        EpicorRFQANS.UD34_Company = obj.Value[i]["UD34_Company"].ToString();
                        EpicorRFQANS.UD34_Key1 = obj.Value[i]["UD34_Key1"].ToString();
                        EpicorRFQANS.UD34_Key2 = obj.Value[i]["UD34_Key2"].ToString();

                        EpicorRFQANS.UD34_Key3 = obj.Value[i]["UD34_Key3"].ToString();
                        EpicorRFQANS.UD34_Key4 = obj.Value[i]["UD34_Key4"].ToString();
                        EpicorRFQANS.UD34_Key5 = obj.Value[i]["UD34_Key5"].ToString();
                        EpicorRFQANS.UD34_RFQQNA_SeqNum_c = obj.Value[i]["UD34_RFQQNA_SeqNum_c"].ToString();
                        EpicorRFQANS.UD34_RFQQNA_Question_c = obj.Value[i]["UD34_RFQQNA_Question_c"].ToString();
                        EpicorRFQANS.UD34_RFQQNA_Answer_c = obj.Value[i]["UD34_RFQQNA_Answer_c"].ToString();


                        lsEpicorRFQANS.Add(EpicorRFQANS);


                        EpicorRFQANS.Add(EpicorRFQANS);
                    }
                }
            }
            return lsEpicorRFQANS.ToArray();

        }
        catch (AggregateException ex)
        {
            return null;
        }
    }
    
    public ps_epicor_rfq_vendorprice[] GetEpicorRFQVendPrice(string RFQNumber,string VendorID)
    {
        try
        {
            //final RequestURL
            string RequestURL = "";
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/ud_SP_RFQ_VendPrice/Data";//?%24filter=UD37_RFQVP_RFQNum_c%20eq%20"+ RFQNumber + "and%20UD37_RFQVP_VendorID_c%20eq%20%27" + VendorID + "%27"; 
            if (RFQNumber != "")
                RequestURL = RequestURL + "?%24filter=UD37_RFQVP_RFQNum_c%20eq%20" + RFQNumber + "%20and%20UD37_RFQVP_VendorID_c%20eq%20%27" + VendorID + "%27";
             //if (CustID != "")
             //    RequestURL = RequestURL + "?% 24filter = Customer_CustID % 20eq % 20'{Customer_CustID}'";
             //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/CustomerCredit/Data?%24filter=Calculated_Part%20eq%20'{Calculated_Part}'";
             //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.PartSvc/Parts?$filter=Company%20eq%20'{Company}'";
            


            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);


            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            if (dyn == null) return null;
            List<ps_epicor_rfq_vendorprice> lsEpicorRFQVendorPrice = new List<ps_epicor_rfq_vendorprice> { };
            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    ps_epicor_rfq model = new ps_epicor_rfq();
                    //if (obj.Value.Count > 0)
                    //    model.DeleteAll();
                    for (int i = 0; i < obj.Value.Count; i++)
                    {

                        ps_epicor_rfq_vendorprice EpicorRFQVendorPrice = new ps_epicor_rfq_vendorprice();
                        EpicorRFQVendorPrice.UD37_Company = obj.Value[i]["UD37_Company"].ToString();
                        EpicorRFQVendorPrice.UD37_Key1 = obj.Value[i]["UD37_Key1"].ToString();
                        EpicorRFQVendorPrice.UD37_Key2 = obj.Value[i]["UD37_Key2"].ToString();
                        EpicorRFQVendorPrice.UD37_Key3 = obj.Value[i]["UD37_Key3"].ToString();
                        EpicorRFQVendorPrice.UD37_Key4 = obj.Value[i]["UD37_Key4"].ToString();
                        EpicorRFQVendorPrice.UD37_Key5 = obj.Value[i]["UD37_Key5"].ToString();
                        EpicorRFQVendorPrice.UD37_RFQVP_RFQNum_c = obj.Value[i]["UD37_RFQVP_RFQNum_c"].ToString();
                        EpicorRFQVendorPrice.UD37_RFQVP_VendorID_c = obj.Value[i]["UD37_RFQVP_VendorID_c"].ToString();
                        EpicorRFQVendorPrice.UD37_RFQVP_VendorName_c = obj.Value[i]["UD37_RFQVP_VendorName_c"].ToString();
                        EpicorRFQVendorPrice.UD37_RFQVP_RFQLine_c = Convert.ToInt32(obj.Value[i]["UD37_RFQVP_RFQLine_c"].ToString());
                        EpicorRFQVendorPrice.UD37_RFQVP_RFQQtyNum_c = obj.Value[i]["UD37_RFQVP_RFQQtyNum_c"].ToString();

                        EpicorRFQVendorPrice.UD37_RFQVP_PartNum_c = obj.Value[i]["UD37_RFQVP_PartNum_c"].ToString();
                        EpicorRFQVendorPrice.UD37_RFQVP_PartDesc_c = obj.Value[i]["UD37_RFQVP_PartDesc_c"].ToString();

                        EpicorRFQVendorPrice.UD37_RFQVP_Qty_c = Convert.ToDecimal(obj.Value[i]["UD37_RFQVP_Qty_c"].ToString());

                        EpicorRFQVendorPrice.UD37_RFQVP_PartNum_c = obj.Value[i]["UD37_RFQVP_PartNum_c"].ToString();
                        EpicorRFQVendorPrice.UD37_RFQVP_PartDesc_c = obj.Value[i]["UD37_RFQVP_PartDesc_c"].ToString();

                        EpicorRFQVendorPrice.UD37_RFQVP_PUM_c = obj.Value[i]["UD37_RFQVP_PUM_c"].ToString();
                        EpicorRFQVendorPrice.UD37_RFQVP_CurrencyCode_c = obj.Value[i]["UD37_RFQVP_CurrencyCode_c"].ToString();

                        EpicorRFQVendorPrice.UD37_RFQVP_OfferedPrice_c = AesEncryption.Encrypt(obj.Value[i]["UD37_RFQVP_OfferedPrice_c"].ToString());
                        EpicorRFQVendorPrice.UD37_RFQVP_NegotiatedPrice_c = Convert.ToDecimal(obj.Value[i]["UD37_RFQVP_NegotiatedPrice_c"].ToString());


                        EpicorRFQVendorPrice.UD37_RFQVP_ExchangeRate_c = Convert.ToDecimal(obj.Value[i]["UD37_RFQVP_ExchangeRate_c"].ToString());
                        EpicorRFQVendorPrice.UD37_RFQVP_BaseUnitPrice_c = Convert.ToDecimal(obj.Value[i]["UD37_RFQVP_BaseUnitPrice_c"].ToString());
          
              

                        EpicorRFQVendorPrice.PartClass_Description = obj.Value[i]["PartClass_Description"].ToString();
                        EpicorRFQVendorPrice.UD37_RFQVP_Remark_c = obj.Value[i]["UD37_RFQVP_Remark_c"].ToString();

                        EpicorRFQVendorPrice.UD37_RFQVP_Qty_c = Convert.ToDecimal(obj.Value[i]["UD37_RFQVP_Qty_c"].ToString());
                        EpicorRFQVendorPrice.UD37_RFQVP_Status_c = obj.Value[i]["UD37_RFQVP_Status_c"].ToString()==""?"0": obj.Value[i]["UD37_RFQVP_Status_c"].ToString();

                        EpicorRFQVendorPrice.RFQItem_DueDate_c = obj.Value[i]["RFQItem_DueDate_c"].ToString();
                    

                        lsEpicorRFQVendorPrice.Add(EpicorRFQVendorPrice);


                        EpicorRFQVendorPrice.Add(EpicorRFQVendorPrice);
                    }
                }
            }
            return lsEpicorRFQVendorPrice.ToArray();

        }
        catch (AggregateException ex)
        {
            return null;
        }
    }


    public class RFQVend
    {
        public string Company { get; set; }
        public int RFQNum { get; set; }
        public int RFQLine { get; set; }
        public int VendorNum { get; set; }
        public bool ud_VendSubmitted_c { get; set; }
        public string ud_SPortalStatus_c { get; set; }
        public DateTime ud_SPortalStatusUpdateTime_c { get; set; }
    }
    public string UpdateEpicorRFQVendStatus(string RFQNumber,string VendorID,int IsSunit)
    {
        ps_epicor_rfq_vendorprice bll = new ps_epicor_rfq_vendorprice();
        DataSet dsVendorPrice = bll.GetList2(" UD37_RFQVP_RFQNum_c='" + RFQNumber + "' and UD37_RFQVP_VendorID_c='" + VendorID + "' ");
        
        
        if (dsVendorPrice.Tables[0].Rows.Count > 0)
        {
            try
            {

                for (int i = 0; i < dsVendorPrice.Tables[0].Rows.Count; i++)
                {

                    RFQVend entry = new RFQVend();
                    entry.Company = dsVendorPrice.Tables[0].Rows[i]["UD37_Company"].ToString();
                    entry.RFQNum = Convert.ToInt32(dsVendorPrice.Tables[0].Rows[i]["UD37_RFQVP_RFQNum_c"].ToString());
                    entry.RFQLine = Convert.ToInt32(dsVendorPrice.Tables[0].Rows[i]["UD37_RFQVP_RFQLine_c"].ToString());
                    entry.VendorNum = Convert.ToInt32(dsVendorPrice.Tables[0].Rows[i]["UD37_RFQVP_VendorNum_c"].ToString());
                    if (IsSunit == 1)//submit
                    {
                        entry.ud_VendSubmitted_c = true;
                        entry.ud_SPortalStatus_c = "Submitted";
                    }
                    else//recall
                    {
                        entry.ud_VendSubmitted_c = false;
                        entry.ud_SPortalStatus_c = "Recalled";
                    }
                    entry.ud_SPortalStatusUpdateTime_c = System.DateTime.Now;



                    string isoJson = JsonConvert.SerializeObject(entry);    //Convert DataEntry to Json string

                    isoJson = isoJson.Replace("\r\n", "");
                    isoJson = isoJson.Replace("\"0001-01-01T00:00:00Z\"", "null");
                    isoJson = isoJson.Replace("00:00:00", "00:00:00Z");

                    //final RequestURL
                    string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.RFQVendSvc/RFQVends";
                    RequestURL = RequestURL.Replace("{ServerName}", ServerName);
                    RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
                    RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);



                    string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
                    HTTPMethods = "POST";
                    HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);

                    string strHTTPStatusCode = ResponseStatusCode;
                    string strResponseBody = ResponseBody;
                    string strExceptionMsg = ExceptionMsg;
                    string strTDeserializeResponseBodyErrorMessage = ErrorMessage;

                    if (ResponseStatusCode == "201")
                    {
                        //JavaScriptSerializer jss = new JavaScriptSerializer();
                        //反序列化成Part对象
                        //PartData partData = jss.Deserialize<PartData>(ResponseBody);
                        //dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
                        //Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
                        //List<PartData> lsPartDatas = new List<PartData> { };
                        //foreach (var obj in dyn)
                        //{
                        //    if (obj.Name == "OrderNum")
                        //    {
                        //        EpicorOrderNumber = obj.Value;
                        //        break;
                        //    }
                        //}
                    }
                    ////写入登录日志
                    ps_manager_log mylog = new ps_manager_log();
                    mylog.user_id = 1;
                    mylog.user_name = "API";
                    mylog.action_type = "Epcior";
                    mylog.add_time = DateTime.Now;
                    mylog.remark = "Update RFQVend(RFQ Num:" + entry.RFQNum  + "-"+ entry.RFQLine +")";
                    mylog.user_ip = AXRequest.GetIP();
                    mylog.Add();
                    
                }
                return RFQNumber;

            }
            catch (AggregateException ex)
            {
                string strExceptionMsg = ex.ToString();
                return "Error:" + strExceptionMsg;
            }
        }
        else
            return "Error";
    }



    public string GetEpicorSupplierNotice(string vendorid)
    {
        try
        {
            //final RequestURL
            string RequestURL = "";
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/ud_SP_Notice/Data?%24filter=Vendor_VendorID%20eq%20'" + vendorid + "' ";
            //if (vendorid != "")
            //    RequestURL = RequestURL + "?%24filter=Vendor_VendorID%20eq%20'" + vendorid + "' ";
            //if (CustID != "")
            //    RequestURL = RequestURL + "?% 24filter = Customer_CustID % 20eq % 20'{Customer_CustID}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/CustomerCredit/Data?%24filter=Calculated_Part%20eq%20'{Calculated_Part}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.PartSvc/Parts?$filter=Company%20eq%20'{Company}'";
            //DataSet ds = GetList("");
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    UserAndPw = AesEncryption.Decrypt(ds.Tables[0].Rows[0]["UserAndPw"].ToString());
            //    APIKey = AesEncryption.Decrypt(ds.Tables[0].Rows[0]["APIKey"].ToString());
            //    ServerName = ds.Tables[0].Rows[0]["ServerName"].ToString();
            //    AppServerName = ds.Tables[0].Rows[0]["AppServerName"].ToString();
            //    AppCompany = ds.Tables[0].Rows[0]["Company"].ToString();
            //}


            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);

 
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            if (dyn == null) return "";
            string strPortalNotice = "";


            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    ps_epicor_vendor model = new ps_epicor_vendor();
                    //if (obj.Value.Count > 0)
                    //    model.DeleteAll();
                    for (int i = 0; i < obj.Value.Count; i++)
                    {
                        strPortalNotice = obj.Value[i]["Calculated_Global_Notices"].ToString() + "vvvvvvvvvv" + obj.Value[i]["Calculated_Vendor_Notices"].ToString();
                        break;
                    }
                }
            }
            return strPortalNotice;

        }
        catch (AggregateException ex)
        {
            return "";
        }
    }



    public string GetEpicorRFQCount(string vendorid)
    {
        try
        {
            //final RequestURL
            string RequestURL = "";
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/ud_SP_RFQCount/Data?%24filter=Vendor_VendorID%20eq%20'" + vendorid + "' ";
            //if (vendorid != "")
            //    RequestURL = RequestURL + "?%24filter=Vendor_VendorID%20eq%20'" + vendorid + "' ";
            //if (CustID != "")
            //    RequestURL = RequestURL + "?% 24filter = Customer_CustID % 20eq % 20'{Customer_CustID}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/CustomerCredit/Data?%24filter=Calculated_Part%20eq%20'{Calculated_Part}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.PartSvc/Parts?$filter=Company%20eq%20'{Company}'";
            //DataSet ds = GetList("");
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    UserAndPw = AesEncryption.Decrypt(ds.Tables[0].Rows[0]["UserAndPw"].ToString());
            //    APIKey = AesEncryption.Decrypt(ds.Tables[0].Rows[0]["APIKey"].ToString());
            //    ServerName = ds.Tables[0].Rows[0]["ServerName"].ToString();
            //    AppServerName = ds.Tables[0].Rows[0]["AppServerName"].ToString();
            //    AppCompany = ds.Tables[0].Rows[0]["Company"].ToString();
            //}


            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);


            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            if (dyn == null) return "";
            string strCalculatedRFQ = "";


            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    ps_epicor_vendor model = new ps_epicor_vendor();
                    //if (obj.Value.Count > 0)
                    //    model.DeleteAll();
                    for (int i = 0; i < obj.Value.Count; i++)
                    {
                        strCalculatedRFQ = obj.Value[i]["Calculated_RepliedRFQ"].ToString() + "vvvvvvvvvv" + obj.Value[i]["Calculated_WaitForReply"].ToString();
                        break;
                    }
                }
            }
            return strCalculatedRFQ;

        }
        catch (AggregateException ex)
        {
            return "";
        }
    }

    public string GetEpicorPOCount(string vendorid)
    {
        try
        {
            //final RequestURL
            string RequestURL = "";
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/ud_SP_POCount/Data?%24filter=Vendor_VendorID%20eq%20'" + vendorid + "' ";
            //if (vendorid != "")
            //    RequestURL = RequestURL + "?%24filter=Vendor_VendorID%20eq%20'" + vendorid + "' ";
            //if (CustID != "")
            //    RequestURL = RequestURL + "?% 24filter = Customer_CustID % 20eq % 20'{Customer_CustID}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/CustomerCredit/Data?%24filter=Calculated_Part%20eq%20'{Calculated_Part}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.PartSvc/Parts?$filter=Company%20eq%20'{Company}'";
            //DataSet ds = GetList("");
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    UserAndPw = AesEncryption.Decrypt(ds.Tables[0].Rows[0]["UserAndPw"].ToString());
            //    APIKey = AesEncryption.Decrypt(ds.Tables[0].Rows[0]["APIKey"].ToString());
            //    ServerName = ds.Tables[0].Rows[0]["ServerName"].ToString();
            //    AppServerName = ds.Tables[0].Rows[0]["AppServerName"].ToString();
            //    AppCompany = ds.Tables[0].Rows[0]["Company"].ToString();
            //}


            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);


            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            if (dyn == null) return "";
            string strCalculatedPO = "";


            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    ps_epicor_vendor model = new ps_epicor_vendor();
                    //if (obj.Value.Count > 0)
                    //    model.DeleteAll();
                    for (int i = 0; i < obj.Value.Count; i++)
                    {
                        strCalculatedPO = obj.Value[i]["Calculated_OpenPO"].ToString() + "vvvvvvvvvv" + obj.Value[i]["Calculated_ClosedPO"].ToString();
                        break;
                    }
                }
            }
            return strCalculatedPO;

        }
        catch (AggregateException ex)
        {
            return "";
        }
    }


    public string[] GetEpicorRFQAttachment(string RFQNum)
    {
        try
        {
            //final RequestURL
            string RequestURL = "";
            RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/ud_SP_RFQ_Attch/Data";
            if (RFQNum != "")
                RequestURL = RequestURL + "?%24filter=XFileAttch_Key1%20eq%20'" + RFQNum + "' ";
            //if (CustID != "")
            //    RequestURL = RequestURL + "?% 24filter = Customer_CustID % 20eq % 20'{Customer_CustID}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/BaqSvc/CustomerCredit/Data?%24filter=Calculated_Part%20eq%20'{Calculated_Part}'";
            //string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Erp.BO.PartSvc/Parts?$filter=Company%20eq%20'{Company}'";
            


            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL = RequestURL.Replace("{Customer_CustID}", CustID);



            string isoJson = "";
            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "GET";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);


            //JavaScriptSerializer jss = new JavaScriptSerializer();
            ////反序列化成Part对象
            //PartData partData = jss.Deserialize<PartData>(ResponseBody);
            dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
            if (dyn == null) return null;
            string XFile = "";
            List<string> XFileArr = new List<string>();


            foreach (var obj in dyn)
            {
                if (obj.Name == "value")
                {
                    //ErrorMessage = Convert.ToString(dyn.Last.Value);
                    //JavaScriptSerializer jss = new JavaScriptSerializer();
                    //反序列化成Part对象
                    //ValueItem partData = jss.Deserialize<ValueItem>(obj.Value[10]);
                    
                    //if (obj.Value.Count > 0)
                    //    model.DeleteAll();
                    for (int i = 0; i < obj.Value.Count; i++)
                    {
                        XFile = obj.Value[i]["XFileAttch_Key1"].ToString() + "vvvvvvvvvv" + obj.Value[i]["XFileAttch_XFileRefNum"].ToString() + "vvvvvvvvvv" + obj.Value[i]["XFileRef_XFileName"].ToString();
                        XFileArr.Add(XFile);
                    }
                }
            }
            return XFileArr.ToArray();

        }
        catch (AggregateException ex)
        {
            return null;
        }
    }


    public class FileRefNum
    {
        public string xFileRefNum { get; set; }
    }

    public string[] GetEpicorRFQAttachmentBase64(string xFileRefNum)
    {
        try
        {
            //final RequestURL
            
            string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/odata/{currentCompany}/Ice.BO.AttachmentSvc/DownloadFile";
            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany=="" || AppCompany == "ALL") ? "JCKSC" : AppCompany);

            FileRefNum entry = new FileRefNum
            {
                xFileRefNum = xFileRefNum,
            };


            string isoJson = JsonConvert.SerializeObject(entry);    //Convert DataEntry to Json string

            isoJson = isoJson.Replace("\r\n", "");
            isoJson = isoJson.Replace("\"0001-01-01T00:00:00Z\"", "null");
            isoJson = isoJson.Replace("00:00:00", "00:00:00Z");


            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "POST";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);
            //HttpSendRequest2(HTTPMethods, RequestURL, UserAndPw, APIKey, License,isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);


            string strHTTPStatusCode = ResponseStatusCode;
            string strResponseBody = ResponseBody;
            string strExceptionMsg = ExceptionMsg;
            string strTDeserializeResponseBodyErrorMessage = ErrorMessage;

            if (ResponseStatusCode == "200")
            {

                //JavaScriptSerializer jss = new JavaScriptSerializer();

                dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
                if (dyn == null) return null;
                List<string> lsBase64list = new List<string> { };
                foreach (var obj in dyn)
                {
                    if (obj.Name == "returnObj")
                    {
                        
                        string base64str = obj.Value;
                        lsBase64list.Add(base64str);
                    }
                }
                return lsBase64list.ToArray();
            }
            else
            {
                return null;
            }
        }
        catch (AggregateException ex)
        {
            return null;
        }
    }

    public class ItemImage
    {
        public string ipCompany { get; set; }
        public string ipRFQNum { get; set; }
    }

    public class RFQItemImage
    {
        public string Company { get; set; }
        public string RFQNum { get; set; }
        public string RFQLine { get; set; }
        public string ImageID { get; set; }
        public string ImageFileName { get; set; }
        public string ImageContent { get; set; }
    }
    

    public RFQItemImage[] GetEpicorRFQItemImageBase64(string Company,string RefNum)
    {
        try
        {
            //final RequestURL
            
            string RequestURL = "https://{ServerName}/{EpicorAppServerName}/api/v2/efx/{currentCompany}/RFQ/funcGetItemImage";
            RequestURL = RequestURL.Replace("{ServerName}", ServerName);
            RequestURL = RequestURL.Replace("{EpicorAppServerName}", AppServerName);
            RequestURL = RequestURL.Replace("{currentCompany}", (AppCompany == "" || AppCompany == "ALL") ? "JCKSC" : AppCompany);
            //RequestURL= "https://ewin2019s3/e11jcksc/api/v2/efx/JCKSC/RFQ/funcGetItemImage";
            ItemImage entry = new ItemImage
            {
                ipCompany = Company,
                ipRFQNum = RefNum
            };


            string isoJson = JsonConvert.SerializeObject(entry);    //Convert DataEntry to Json string

            isoJson = isoJson.Replace("\r\n", "");
            isoJson = isoJson.Replace("\"0001-01-01T00:00:00Z\"", "null");
            isoJson = isoJson.Replace("00:00:00", "00:00:00Z");



            string HTTPMethods = "", ResponseStatusCode = "", ResponseBody = "", IsSuccessStatusCode = "", ErrorMessage = "", ExceptionMsg = "";
            HTTPMethods = "POST";
            HttpSendRequest(HTTPMethods, RequestURL, UserAndPw, APIKey, isoJson, ref ResponseStatusCode, ref ResponseBody, ref IsSuccessStatusCode, ref ErrorMessage, ref ExceptionMsg);

            string strHTTPStatusCode = ResponseStatusCode;
            string strResponseBody = ResponseBody;
            string strExceptionMsg = ExceptionMsg;
            string strTDeserializeResponseBodyErrorMessage = ErrorMessage;

            if (ResponseStatusCode == "200")
            {

                //JavaScriptSerializer jss = new JavaScriptSerializer();

                dynamic dyn = Newtonsoft.Json.JsonConvert.DeserializeObject(ResponseBody);
                if (dyn == null) return null;
                List<RFQItemImage> lsRFQItemImage = new List<RFQItemImage> { };
                foreach (var obj in dyn)
                {
                    if (obj.Name == "opDS")
                    {
                        dynamic dyn2 = Newtonsoft.Json.JsonConvert.DeserializeObject(obj.Value.ToString());
                        foreach (var obj2 in dyn2)
                        {
                            if (obj2.Name == "RFQItemImage")
                            {
                                if(obj2.Value.Count>0)
                                {
                                    (new ps_epicor_rfq()).DeleteRFQImageByRfqNumber(obj2.Value[0]["RFQNum"].ToString());
                                }
                                for (int i = 0; i < obj2.Value.Count; i++)
                                {
                                    RFQItemImage pRFQItemImage = new RFQItemImage();
                                    pRFQItemImage.Company = obj2.Value[i]["Company"].ToString();
                                    pRFQItemImage.RFQNum = obj2.Value[i]["RFQNum"].ToString();
                                    pRFQItemImage.RFQLine = obj2.Value[i]["RFQLine"].ToString();
                                    pRFQItemImage.ImageID = obj2.Value[i]["ImageID"].ToString();
                                    pRFQItemImage.ImageFileName = obj2.Value[i]["Company"].ToString();
                                    pRFQItemImage.ImageContent = obj2.Value[i]["ImageContent"].ToString();
                                    
                                    (new ps_epicor_rfq()).UpdateRFQImageByRfqNumberAndLine(pRFQItemImage.RFQNum, pRFQItemImage.RFQLine, pRFQItemImage.ImageID, pRFQItemImage.ImageFileName, pRFQItemImage.ImageContent);
                                    lsRFQItemImage.Add(pRFQItemImage);
                                }
                            }
                        }
                    }
                }
                return lsRFQItemImage.ToArray();
            }
            else
            {
                return null;
            }
        }
        catch (AggregateException ex)
        {
            return null;
        }
    }

   


}
