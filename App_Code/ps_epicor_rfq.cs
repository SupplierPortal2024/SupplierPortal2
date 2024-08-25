using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


/// <summary>
/// 数据访问类:ps_epicor_vendor
/// </summary>
public partial class ps_epicor_rfq
{
	public ps_epicor_rfq()
	{ }
	#region  BasicMethod
	#region Model
	public int ID { set; get; }

	public string RFQHead_Company { set; get; }
	public string RFQHead_OpenRFQ { set; get; }
	public string RFQHead_RFQNum { set; get; }
	public DateTime RFQHead_RFQDate { set; get; }
	public DateTime? RFQHead_RFQDueDate { set; get; }
	public int RFQItem_RFQLine { set; get; }
	public string RFQItem_PartNum { set; get; }
	public string RFQItem_LineDesc { set; get; }
	public string RFQItem_PUM { set; get; }
	public string RFQQty_QtyNum { set; get; }
	public decimal RFQQty_Quantity { set; get; }
	public string Vendor_VendorID { set; get; }
	public string Vendor_Name { set; get; }
	public DateTime? CreateDate { set; get; }

	public string Vendor_ReplyRemarks { set; get; }
	public decimal Vendor_ReplyPrice { set; get; }
	public string Vendor_ReplyAttachment1 { set; get; }
	public string Vendor_ReplyAttachment2 { set; get; }
	public string Vendor_ReplyAttachment3 { set; get; }
	public int Vendor_ReplyStatus { set; get; }
	public DateTime? Vendor_ReplyDatetime { set; get; }
	public string RFQHead_PostToSupPortalTime_c { set; get; }

	public string Calculated_DueDateTime { set; get; }
	public string RFQVend_ud_SPortalstatus_c { set; get; }
	public string RFQHead_Rptsubject_c { set; get; }

	public string Calculated_DueDateDsp { set; get; }
	public string Calculated_DueDateTimeDsp { set; get; }
	public string Calculated_RFQDateDsp { set; get; }
	public string Calculated_RFQExpired { set; get; }

	public string ImageID { set; get; }
	public string ImageFileName { set; get; }
	public string ImageContent { set; get; }





	#endregion Model

	public int Add(ps_epicor_rfq model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("insert into ps_epicor_rfq(");
		strSql.Append("RFQHead_Company,RFQHead_OpenRFQ,RFQHead_RFQNum,RFQHead_RFQDate,RFQHead_RFQDueDate,RFQItem_RFQLine,RFQItem_PartNum,RFQItem_LineDesc,RFQItem_PUM,RFQQty_QtyNum,RFQQty_Quantity,Vendor_VendorID,Vendor_Name,RFQHead_PostToSupPortalTime_c,Calculated_DueDateTime,RFQVend_ud_SPortalstatus_c,RFQHead_Rptsubject_c,Calculated_DueDateDsp,Calculated_DueDateTimeDsp,Calculated_RFQDateDsp,Calculated_RFQExpired)");
		strSql.Append(" select ");
		strSql.Append("@RFQHead_Company,@RFQHead_OpenRFQ,@RFQHead_RFQNum,@RFQHead_RFQDate,@RFQHead_RFQDueDate,@RFQItem_RFQLine,@RFQItem_PartNum,@RFQItem_LineDesc,@RFQItem_PUM,@RFQQty_QtyNum,@RFQQty_Quantity,@Vendor_VendorID,@Vendor_Name,@RFQHead_PostToSupPortalTime_c,@Calculated_DueDateTime,@RFQVend_ud_SPortalstatus_c,@RFQHead_Rptsubject_c,@Calculated_DueDateDsp,@Calculated_DueDateTimeDsp,@Calculated_RFQDateDsp,@Calculated_RFQExpired");
		strSql.Append(" WHERE @RFQHead_RFQNum + '-' + cast(@RFQItem_RFQLine as nvarchar) + '-' + cast(@Vendor_VendorID as nvarchar) not in (select RFQHead_RFQNum + '-' + cast(RFQItem_RFQLine as nvarchar) + '-' + cast(Vendor_VendorID as nvarchar) from ps_epicor_rfq)");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
					new SqlParameter("@RFQHead_Company", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_OpenRFQ", SqlDbType.NVarChar,10),
					new SqlParameter("@RFQHead_RFQNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_RFQDate", SqlDbType.DateTime),
					new SqlParameter("@RFQHead_RFQDueDate", SqlDbType.DateTime),
					new SqlParameter("@RFQItem_RFQLine", SqlDbType.Int,4),
					new SqlParameter("@RFQItem_PartNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQItem_LineDesc", SqlDbType.NVarChar,500),
					new SqlParameter("@RFQItem_PUM", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQQty_QtyNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQQty_Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,50),
					new SqlParameter("@Vendor_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_PostToSupPortalTime_c", SqlDbType.NVarChar,50),
					new SqlParameter("@Calculated_DueDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQVend_ud_SPortalstatus_c", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_Rptsubject_c", SqlDbType.NVarChar,500),
					new SqlParameter("@Calculated_DueDateDsp", SqlDbType.NVarChar,50),
					new SqlParameter("@Calculated_DueDateTimeDsp", SqlDbType.NVarChar,50),
					new SqlParameter("@Calculated_RFQDateDsp", SqlDbType.NVarChar,50),
					new SqlParameter("@Calculated_RFQExpired", SqlDbType.NVarChar,500)};
		parameters[0].Value = model.RFQHead_Company;
		parameters[1].Value = model.RFQHead_OpenRFQ;
		parameters[2].Value = model.RFQHead_RFQNum;
		parameters[3].Value = model.RFQHead_RFQDate;
		parameters[4].Value = model.RFQHead_RFQDueDate;
		parameters[5].Value = model.RFQItem_RFQLine;
		parameters[6].Value = model.RFQItem_PartNum;
		parameters[7].Value = model.RFQItem_LineDesc;
		parameters[8].Value = model.RFQItem_PUM;
		parameters[9].Value = model.RFQQty_QtyNum;
		parameters[10].Value = model.RFQQty_Quantity;
		parameters[11].Value = model.Vendor_VendorID;
		parameters[12].Value = model.Vendor_Name;
		parameters[13].Value = model.RFQHead_PostToSupPortalTime_c;
		parameters[14].Value = model.Calculated_DueDateTime;
		parameters[15].Value = model.RFQVend_ud_SPortalstatus_c;
		parameters[16].Value = model.RFQHead_Rptsubject_c;
		parameters[17].Value = model.Calculated_DueDateDsp;
		parameters[18].Value = model.Calculated_DueDateTimeDsp;
		parameters[19].Value = model.Calculated_RFQDateDsp;
		parameters[20].Value = model.Calculated_RFQExpired;

		object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
		if (obj == null)
		{
			return 0;
		}
		else
		{
			return Convert.ToInt32(obj);
		}
	}

	/// <summary>
	/// 更新一条数据
	/// </summary>
	public bool UpdateRFQBySyncTime(ps_epicor_rfq model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_rfq set ");
		strSql.Append("RFQHead_Company=@RFQHead_Company,");
		strSql.Append("RFQHead_OpenRFQ=@RFQHead_OpenRFQ,");
		strSql.Append("RFQHead_RFQNum=@RFQHead_RFQNum,");
		strSql.Append("RFQHead_RFQDate=@RFQHead_RFQDate,");
		strSql.Append("RFQHead_RFQDueDate=@RFQHead_RFQDueDate,");
		strSql.Append("RFQItem_RFQLine=@RFQItem_RFQLine,");
		strSql.Append("RFQItem_PartNum=@RFQItem_PartNum,");
		strSql.Append("RFQItem_LineDesc=@RFQItem_LineDesc,");
		strSql.Append("RFQItem_PUM=@RFQItem_PUM,");
		strSql.Append("RFQQty_QtyNum=@RFQQty_QtyNum,");
		strSql.Append("RFQQty_Quantity=@RFQQty_Quantity,");
		strSql.Append("Vendor_VendorID=@Vendor_VendorID,");
		strSql.Append("Vendor_Name=@Vendor_Name,");
		strSql.Append("SyncDate=getdate(),"); 
		strSql.Append("RFQHead_PostToSupPortalTime_c=@RFQHead_PostToSupPortalTime_c,");
		strSql.Append("Calculated_DueDateTime=@Calculated_DueDateTime,");
		strSql.Append("RFQVend_ud_SPortalstatus_c=@RFQVend_ud_SPortalstatus_c,");
		strSql.Append("RFQHead_Rptsubject_c=@RFQHead_Rptsubject_c,");
		strSql.Append("Calculated_DueDateDsp=@Calculated_DueDateDsp,");
		strSql.Append("Calculated_DueDateTimeDsp=@Calculated_DueDateTimeDsp,");
		strSql.Append("Calculated_RFQDateDsp=@Calculated_RFQDateDsp,");
		strSql.Append("Calculated_RFQExpired=@Calculated_RFQExpired");

		strSql.Append(" WHERE RFQHead_RFQNum=@RFQHead_RFQNum ");
		strSql.Append(" AND RFQItem_RFQLine=@RFQItem_RFQLine ");
		strSql.Append(" AND Vendor_VendorID=@Vendor_VendorID ");
		strSql.Append(" AND Vendor_ReplyStatus<>1");

		//strSql.Append(" AND @RFQHead_PostToSupPortalTime_c<>RFQHead_PostToSupPortalTime_c ");

		SqlParameter[] parameters = {
					new SqlParameter("@RFQHead_Company", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_OpenRFQ", SqlDbType.NVarChar,10),
					new SqlParameter("@RFQHead_RFQNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_RFQDate", SqlDbType.DateTime),
					new SqlParameter("@RFQHead_RFQDueDate", SqlDbType.DateTime),
					new SqlParameter("@RFQItem_RFQLine", SqlDbType.Int,4),
					new SqlParameter("@RFQItem_PartNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQItem_LineDesc", SqlDbType.NVarChar,500),
					new SqlParameter("@RFQItem_PUM", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQQty_QtyNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQQty_Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,50),
					new SqlParameter("@Vendor_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_PostToSupPortalTime_c", SqlDbType.NVarChar,50),
					new SqlParameter("@Calculated_DueDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQVend_ud_SPortalstatus_c", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_Rptsubject_c", SqlDbType.NVarChar,500),
					new SqlParameter("@Calculated_DueDateDsp", SqlDbType.NVarChar,50),
					new SqlParameter("@Calculated_DueDateTimeDsp", SqlDbType.NVarChar,50),
					new SqlParameter("@Calculated_RFQDateDsp", SqlDbType.NVarChar,50),
					new SqlParameter("@Calculated_RFQExpired", SqlDbType.NVarChar,500)};
		parameters[0].Value = model.RFQHead_Company;
		parameters[1].Value = model.RFQHead_OpenRFQ;
		parameters[2].Value = model.RFQHead_RFQNum;
		parameters[3].Value = model.RFQHead_RFQDate;
		parameters[4].Value = model.RFQHead_RFQDueDate;
		parameters[5].Value = model.RFQItem_RFQLine;
		parameters[6].Value = model.RFQItem_PartNum;
		parameters[7].Value = model.RFQItem_LineDesc;
		parameters[8].Value = model.RFQItem_PUM;
		parameters[9].Value = model.RFQQty_QtyNum;
		parameters[10].Value = model.RFQQty_Quantity;
		parameters[11].Value = model.Vendor_VendorID;
		parameters[12].Value = model.Vendor_Name;
		parameters[13].Value = model.RFQHead_PostToSupPortalTime_c;
		parameters[14].Value = model.Calculated_DueDateTime;
		parameters[15].Value = model.RFQVend_ud_SPortalstatus_c;
		parameters[16].Value = model.RFQHead_Rptsubject_c;
		parameters[17].Value = model.Calculated_DueDateDsp;
		parameters[18].Value = model.Calculated_DueDateTimeDsp;
		parameters[19].Value = model.Calculated_RFQDateDsp;
		parameters[20].Value = model.Calculated_RFQExpired;

		int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		if (rows > 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool UpdateRFQCalculatedInfoBySyncTime(ps_epicor_rfq model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_rfq set ");
		strSql.Append("Calculated_DueDateTime=@Calculated_DueDateTime,");
		strSql.Append("Calculated_DueDateDsp=@Calculated_DueDateDsp,");
		strSql.Append("Calculated_DueDateTimeDsp=@Calculated_DueDateTimeDsp,");
		strSql.Append("Calculated_RFQDateDsp=@Calculated_RFQDateDsp,");
		strSql.Append("Calculated_RFQExpired=@Calculated_RFQExpired");

		strSql.Append(" WHERE RFQHead_RFQNum=@RFQHead_RFQNum ");
		strSql.Append(" AND RFQItem_RFQLine=@RFQItem_RFQLine ");
		strSql.Append(" AND Vendor_VendorID=@Vendor_VendorID ");

		//strSql.Append(" AND @RFQHead_PostToSupPortalTime_c<>RFQHead_PostToSupPortalTime_c ");

		SqlParameter[] parameters = {
					new SqlParameter("@RFQHead_Company", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_OpenRFQ", SqlDbType.NVarChar,10),
					new SqlParameter("@RFQHead_RFQNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_RFQDate", SqlDbType.DateTime),
					new SqlParameter("@RFQHead_RFQDueDate", SqlDbType.DateTime),
					new SqlParameter("@RFQItem_RFQLine", SqlDbType.Int,4),
					new SqlParameter("@RFQItem_PartNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQItem_LineDesc", SqlDbType.NVarChar,500),
					new SqlParameter("@RFQItem_PUM", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQQty_QtyNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQQty_Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,50),
					new SqlParameter("@Vendor_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_PostToSupPortalTime_c", SqlDbType.NVarChar,50),
					new SqlParameter("@Calculated_DueDateTime", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQVend_ud_SPortalstatus_c", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_Rptsubject_c", SqlDbType.NVarChar,500),
					new SqlParameter("@Calculated_DueDateDsp", SqlDbType.NVarChar,50),
					new SqlParameter("@Calculated_DueDateTimeDsp", SqlDbType.NVarChar,50),
					new SqlParameter("@Calculated_RFQDateDsp", SqlDbType.NVarChar,50),
					new SqlParameter("@Calculated_RFQExpired", SqlDbType.NVarChar,500)};
		parameters[0].Value = model.RFQHead_Company;
		parameters[1].Value = model.RFQHead_OpenRFQ;
		parameters[2].Value = model.RFQHead_RFQNum;
		parameters[3].Value = model.RFQHead_RFQDate;
		parameters[4].Value = model.RFQHead_RFQDueDate;
		parameters[5].Value = model.RFQItem_RFQLine;
		parameters[6].Value = model.RFQItem_PartNum;
		parameters[7].Value = model.RFQItem_LineDesc;
		parameters[8].Value = model.RFQItem_PUM;
		parameters[9].Value = model.RFQQty_QtyNum;
		parameters[10].Value = model.RFQQty_Quantity;
		parameters[11].Value = model.Vendor_VendorID;
		parameters[12].Value = model.Vendor_Name;
		parameters[13].Value = model.RFQHead_PostToSupPortalTime_c;
		parameters[14].Value = model.Calculated_DueDateTime;
		parameters[15].Value = model.RFQVend_ud_SPortalstatus_c;
		parameters[16].Value = model.RFQHead_Rptsubject_c;
		parameters[17].Value = model.Calculated_DueDateDsp;
		parameters[18].Value = model.Calculated_DueDateTimeDsp;
		parameters[19].Value = model.Calculated_RFQDateDsp;
		parameters[20].Value = model.Calculated_RFQExpired;

		int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		if (rows > 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	/// <summary>
	/// 更新一条数据
	/// </summary>
	public bool Update(ps_epicor_rfq model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_rfq set ");
		strSql.Append("RFQHead_Company=@RFQHead_Company,");
		strSql.Append("RFQHead_OpenRFQ=@RFQHead_OpenRFQ,");
		strSql.Append("RFQHead_RFQNum=@RFQHead_RFQNum,");
		strSql.Append("RFQHead_RFQDate=@RFQHead_RFQDate,");
		strSql.Append("RFQHead_RFQDueDate=@RFQHead_RFQDueDate,");
		strSql.Append("RFQItem_RFQLine=@RFQItem_RFQLine,");
		strSql.Append("RFQItem_PartNum=@RFQItem_PartNum,");
		strSql.Append("RFQItem_LineDesc=@RFQItem_LineDesc,");
		strSql.Append("RFQItem_PUM=@RFQItem_PUM,");
		strSql.Append("RFQQty_QtyNum=@RFQQty_QtyNum,");
		strSql.Append("RFQQty_Quantity=@RFQQty_Quantity,");
		strSql.Append("Vendor_VendorID=@Vendor_VendorID,");
		strSql.Append("Vendor_ReplyRemarks=@Vendor_ReplyRemarks,");
		strSql.Append("Vendor_ReplyPrice=@Vendor_ReplyPrice,");
		strSql.Append("Vendor_ReplyAttachment1=@Vendor_ReplyAttachment1,");
		strSql.Append("Vendor_ReplyAttachment2=@Vendor_ReplyAttachment2,");
		strSql.Append("Vendor_ReplyAttachment3=@Vendor_ReplyAttachment3");

		strSql.Append(" where ID=@ID");
		
		SqlParameter[] parameters = {
					new SqlParameter("@RFQHead_Company", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_OpenRFQ", SqlDbType.NVarChar,10),
					new SqlParameter("@RFQHead_RFQNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_RFQDate", SqlDbType.DateTime),
					new SqlParameter("@RFQHead_RFQDueDate", SqlDbType.DateTime),
					new SqlParameter("@RFQItem_RFQLine", SqlDbType.Int,4),
					new SqlParameter("@RFQItem_PartNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQItem_LineDesc", SqlDbType.NVarChar,500),
					new SqlParameter("@RFQItem_PUM", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQQty_QtyNum", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQQty_Quantity", SqlDbType.Decimal,9),
					new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,50),
					new SqlParameter("@Vendor_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),

					new SqlParameter("@Vendor_ReplyRemarks", SqlDbType.NVarChar,500),
					new SqlParameter("@Vendor_ReplyPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Vendor_ReplyAttachment1", SqlDbType.NVarChar,500),
					new SqlParameter("@Vendor_ReplyAttachment2", SqlDbType.NVarChar,500),
					new SqlParameter("@Vendor_ReplyAttachment3", SqlDbType.NVarChar,500)};
		parameters[0].Value = model.RFQHead_Company;
		parameters[1].Value = model.RFQHead_OpenRFQ;
		parameters[2].Value = model.RFQHead_RFQNum;
		parameters[3].Value = model.RFQHead_RFQDate;
		parameters[4].Value = model.RFQHead_RFQDueDate;
		parameters[5].Value = model.RFQItem_RFQLine;
		parameters[6].Value = model.RFQItem_PartNum;
		parameters[7].Value = model.RFQItem_LineDesc;
		parameters[8].Value = model.RFQItem_PUM;
		parameters[9].Value = model.RFQQty_QtyNum;
		parameters[10].Value = model.RFQQty_Quantity;
		parameters[11].Value = model.Vendor_VendorID;
		parameters[12].Value = model.Vendor_Name;
		parameters[13].Value = model.Vendor_ReplyRemarks;
		parameters[14].Value = model.Vendor_ReplyPrice;
		parameters[15].Value = model.Vendor_ReplyAttachment1;
		parameters[16].Value = model.Vendor_ReplyAttachment2;
		parameters[17].Value = model.Vendor_ReplyAttachment2;

		parameters[18].Value = model.ID;

		int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		if (rows > 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	/// <summary>
	/// 更新一条数据
	/// </summary>
	public bool UpdateRFQStatusByRfqNumberAndVendor(string RfqNumber,string VendorID,string VendorReplyStatus)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_rfq set ");
		strSql.Append("Vendor_ReplyStatus=@Vendor_ReplyStatus,");
		strSql.Append("Vendor_ReplyDatetime=getdate()");
		strSql.Append(" where RFQHead_RFQNum=@RFQHead_RFQNum");
		strSql.Append(" and Vendor_VendorID=@Vendor_VendorID");
		SqlParameter[] parameters = {
					new SqlParameter("@RFQHead_RFQNum", SqlDbType.NVarChar,200),
					new SqlParameter("@Vendor_ReplyStatus", SqlDbType.NVarChar,20),
					new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,20)};
		parameters[0].Value = RfqNumber;
		parameters[1].Value = VendorReplyStatus;
		parameters[2].Value = VendorID;

		int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		if (rows > 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}


	public bool DeleteRFQImageByRfqNumber(string RfqNumber)
	{
		StringBuilder strSql = new StringBuilder();

		strSql.Append("delete ps_epicor_rfq_itemimage ");
		strSql.Append(" where RFQNum=@RFQNum ");
		
		SqlParameter[] parameters = {
					new SqlParameter("@RFQNum", SqlDbType.NVarChar,200)};
		parameters[0].Value = RfqNumber;
	

		int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		if (rows > 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	/// <summary>
	/// 更新一条数据
	/// </summary>
	public bool UpdateRFQImageByRfqNumberAndLine(string RfqNumber, string RfqLine, string ImageID,string ImageFileName, string ImageContent)
	{
		StringBuilder strSql = new StringBuilder();

		strSql.Append("insert into ps_epicor_rfq_itemimage(");
		strSql.Append("RFQNum, RFQLine, ImageID, ImageFileName, ImageContent)");
		strSql.Append(" select ");
		strSql.Append("@RFQNum,@RFQLine,@ImageID,@ImageFileName,@ImageContent");
		strSql.Append(" WHERE @RFQNum + '-' + cast(@RFQLine as nvarchar)  not in (select RFQNum + '-' + cast(RFQLine as nvarchar) from ps_epicor_rfq_itemimage)");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
					new SqlParameter("@RFQNum", SqlDbType.NVarChar,200),
					new SqlParameter("@RFQLine", SqlDbType.NVarChar,20),
					new SqlParameter("@ImageID", SqlDbType.NVarChar,50),
					new SqlParameter("@ImageFileName", SqlDbType.NVarChar,200),
					new SqlParameter("@ImageContent", SqlDbType.NVarChar,int.MaxValue)};
		parameters[0].Value = RfqNumber;
		parameters[1].Value = RfqLine;
		parameters[2].Value = ImageID;
		parameters[3].Value = ImageFileName;
		parameters[4].Value = ImageContent;

		int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		if (rows > 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	/// <summary>
	/// 删除一条数据
	/// </summary>
	public bool Delete(int ID)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("delete from ps_epicor_rfq ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
		parameters[0].Value = ID;

		int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		if (rows > 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	/// <summary>
	/// 批量删除数据
	/// </summary>
	public bool DeleteList(string IDlist)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("delete from ps_epicor_rfq ");
		strSql.Append(" where ID in (" + IDlist + ")  ");
		int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
		if (rows > 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	

	/// <summary>
	/// 得到一个对象实体
	/// </summary>
	public ps_epicor_rfq GetModel(int ID)
	{

		StringBuilder strSql = new StringBuilder();
		//strSql.Append("select  top 1 ID,RFQHead_Company,RFQHead_OpenRFQ,RFQHead_RFQNum,RFQHead_RFQDate,RFQHead_RFQDueDate,RFQItem_RFQLine,RFQItem_PartNum,RFQItem_LineDesc,RFQItem_PUM,RFQQty_QtyNum,RFQQty_Quantity,Vendor_VendorID,Vendor_Name,CreateDate,Vendor_ReplyRemarks, Vendor_ReplyPrice, Vendor_ReplyAttachment1,Vendor_ReplyAttachment2, Vendor_ReplyAttachment3, Vendor_ReplyStatus, Vendor_ReplyDatetime from ps_epicor_rfq ");
		strSql.Append("select  top 1 * from ps_epicor_rfq ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
		parameters[0].Value = ID;

		ps_epicor_rfq model = new ps_epicor_rfq();
		DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
		if (ds.Tables[0].Rows.Count > 0)
		{
			return DataRowToModel(ds.Tables[0].Rows[0]);
		}
		else
		{
			return null;
		}
	}

	/// <summary>
	/// 得到一个对象实体
	/// </summary>
	public ps_epicor_rfq GetModelByRFQNumAndVendorID(string RFQNum,string VendorID)
	{

		StringBuilder strSql = new StringBuilder();
		//strSql.Append("select  top 1 ID,RFQHead_Company,RFQHead_OpenRFQ,RFQHead_RFQNum,RFQHead_RFQDate,RFQHead_RFQDueDate,RFQItem_RFQLine,RFQItem_PartNum,RFQItem_LineDesc,RFQItem_PUM,RFQQty_QtyNum,RFQQty_Quantity,Vendor_VendorID,Vendor_Name,CreateDate,Vendor_ReplyRemarks, Vendor_ReplyPrice, Vendor_ReplyAttachment1,Vendor_ReplyAttachment2, Vendor_ReplyAttachment3, Vendor_ReplyStatus, Vendor_ReplyDatetime from ps_epicor_rfq ");
		strSql.Append("select  top 1 * from ps_epicor_rfq ");
		strSql.Append(" where RFQHead_RFQNum=@RFQHead_RFQNum");
		strSql.Append(" and Vendor_VendorID=@Vendor_VendorID");
		SqlParameter[] parameters = {
					new SqlParameter("@RFQHead_RFQNum", SqlDbType.VarChar,500),
					new SqlParameter("@Vendor_VendorID", SqlDbType.VarChar,500)
			};
		parameters[0].Value = RFQNum;
		parameters[1].Value = VendorID;

		ps_epicor_rfq model = new ps_epicor_rfq();
		DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
		if (ds.Tables[0].Rows.Count > 0)
		{
			return DataRowToModel(ds.Tables[0].Rows[0]);
		}
		else
		{
			return null;
		}
	}

	public bool ResposnseRFQ(int ID, string VendorRemark, double VendorUnitPrice)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("Update ps_epicor_rfq set Vendor_ReplyRemarks = @VendorRemark,Vendor_ReplyPrice = @VendorUnitPrice ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@VendorRemark", SqlDbType.VarChar,500),
					new SqlParameter("@VendorUnitPrice", SqlDbType.Decimal)
		};
		parameters[0].Value = ID;
		parameters[1].Value = VendorRemark;
		parameters[2].Value = VendorUnitPrice;

		int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		if (rows > 0)
		{
			//ComfirmVendorResponseStatus(ID);
			return true;
		}
		else
		{
			return false;
		}
	}


	/// <summary>
	/// 得到一个对象实体
	/// </summary>
	public ps_epicor_rfq DataRowToModel(DataRow row)
	{
		ps_epicor_rfq model = new ps_epicor_rfq();
		if (row != null)
		{
			if (row["ID"] != null && row["ID"].ToString() != "")
			{
				model.ID = int.Parse(row["ID"].ToString());
			}
			if (row["RFQHead_Company"] != null)
			{
				model.RFQHead_Company = row["RFQHead_Company"].ToString();
			}
			if (row["RFQHead_OpenRFQ"] != null)
			{
				model.RFQHead_OpenRFQ = row["RFQHead_OpenRFQ"].ToString();
			}
			if (row["RFQHead_RFQNum"] != null)
			{
				model.RFQHead_RFQNum = row["RFQHead_RFQNum"].ToString();
			}
			if (row["RFQHead_RFQDate"] != null && row["RFQHead_RFQDate"].ToString() != "")
			{
				model.RFQHead_RFQDate = DateTime.Parse(row["RFQHead_RFQDate"].ToString());
			}
			if (row["RFQHead_RFQDueDate"] != null && row["RFQHead_RFQDueDate"].ToString() != "")
			{
				model.RFQHead_RFQDueDate = DateTime.Parse(row["RFQHead_RFQDueDate"].ToString());
			}
			if (row["RFQItem_RFQLine"] != null && row["RFQItem_RFQLine"].ToString() != "")
			{
				model.RFQItem_RFQLine = int.Parse(row["RFQItem_RFQLine"].ToString());
			}
			if (row["RFQItem_PartNum"] != null)
			{
				model.RFQItem_PartNum = row["RFQItem_PartNum"].ToString();
			}
			if (row["RFQItem_LineDesc"] != null)
			{
				model.RFQItem_LineDesc = row["RFQItem_LineDesc"].ToString();
			}
			if (row["RFQItem_PUM"] != null)
			{
				model.RFQItem_PUM = row["RFQItem_PUM"].ToString();
			}
			if (row["RFQQty_QtyNum"] != null)
			{
				model.RFQQty_QtyNum = row["RFQQty_QtyNum"].ToString();
			}
			if (row["RFQQty_Quantity"] != null && row["RFQQty_Quantity"].ToString() != "")
			{
				model.RFQQty_Quantity = decimal.Parse(row["RFQQty_Quantity"].ToString());
			}
			if (row["Vendor_VendorID"] != null)
			{
				model.Vendor_VendorID = row["Vendor_VendorID"].ToString();
			}
			if (row["Vendor_Name"] != null)
			{
				model.Vendor_Name = row["Vendor_Name"].ToString();
			}
			if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
			{
				model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
			}

			if (row["Vendor_ReplyRemarks"] != null)
			{
				model.Vendor_ReplyRemarks = row["Vendor_ReplyRemarks"].ToString();
			}
			if (row["Vendor_ReplyPrice"] != null)
			{
				model.Vendor_ReplyPrice = decimal.Parse(row["Vendor_ReplyPrice"].ToString());
			}
			if (row["Vendor_ReplyAttachment1"] != null)
			{
				model.Vendor_ReplyAttachment1 = row["Vendor_ReplyAttachment1"].ToString();
			}
			if (row["Vendor_ReplyAttachment2"] != null)
			{
				model.Vendor_ReplyAttachment2 = row["Vendor_ReplyAttachment2"].ToString();
			}
			if (row["Vendor_ReplyAttachment3"] != null)
			{
				model.Vendor_ReplyAttachment3 = row["Vendor_ReplyAttachment3"].ToString();
			}

			if (row["Vendor_ReplyStatus"] != null && row["Vendor_ReplyStatus"].ToString() != "")
			{
				model.Vendor_ReplyStatus = int.Parse(row["Vendor_ReplyStatus"].ToString());
			}

			if (row["Vendor_ReplyDatetime"] != null && row["Vendor_ReplyDatetime"].ToString() != "")
			{
				model.Vendor_ReplyDatetime = DateTime.Parse(row["Vendor_ReplyDatetime"].ToString());
			}

			if (row["Calculated_DueDateTime"] != null)
			{
				model.Calculated_DueDateTime = row["Calculated_DueDateTime"].ToString();
			}

			if (row["RFQVend_ud_SPortalstatus_c"] != null)
			{
				model.RFQVend_ud_SPortalstatus_c = row["RFQVend_ud_SPortalstatus_c"].ToString();
			}

			if (row["RFQHead_Rptsubject_c"] != null)
			{
				model.RFQHead_Rptsubject_c = row["RFQHead_Rptsubject_c"].ToString();
			}
			if (row["RFQHead_Rptsubject_c"] != null)
			{
				model.RFQHead_Rptsubject_c = row["RFQHead_Rptsubject_c"].ToString();
			}
			if (row["Calculated_DueDateDsp"] != null)
			{
				model.Calculated_DueDateDsp = row["Calculated_DueDateDsp"].ToString();
			}
			if (row["Calculated_DueDateTimeDsp"] != null)
			{
				model.Calculated_DueDateTimeDsp = row["Calculated_DueDateTimeDsp"].ToString();
			}
			if (row["Calculated_RFQDateDsp"] != null)
			{
				model.Calculated_RFQDateDsp = row["Calculated_RFQDateDsp"].ToString();
			}
			if (row["Calculated_RFQExpired"] != null)
			{
				model.Calculated_RFQExpired = row["Calculated_RFQExpired"].ToString();
			}

		}
		return model;
	}

	/// <summary>
	/// 获得数据列表
	/// </summary>
	public DataSet GetList(string strWhere)
	{
		StringBuilder strSql = new StringBuilder();
		//strSql.Append("select ID,RFQHead_Company,RFQHead_OpenRFQ,RFQHead_RFQNum,RFQHead_RFQDate,RFQHead_RFQDueDate,RFQItem_RFQLine,RFQItem_PartNum,RFQItem_LineDesc,RFQItem_PUM,RFQQty_QtyNum,RFQQty_Quantity,Vendor_VendorID,Vendor_Name,CreateDate, Vendor_ReplyPrice, Vendor_ReplyAttachment1,Vendor_ReplyAttachment2, Vendor_ReplyAttachment3, Vendor_ReplyStatus, Vendor_ReplyDatetime  ");
		strSql.Append("select *  ");
		strSql.Append(" FROM ps_epicor_rfq ");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" where " + strWhere);
		}
		return DbHelperSQL.Query(strSql.ToString());
	}

	/// <summary>
	/// 获得前几行数据
	/// </summary>
	public DataSet GetList(int Top, string strWhere, string filedOrder)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select ");
		if (Top > 0)
		{
			strSql.Append(" top " + Top.ToString());
		}
		//strSql.Append(" ID,RFQHead_Company,RFQHead_OpenRFQ,RFQHead_RFQNum,RFQHead_RFQDate,RFQHead_RFQDueDate,RFQItem_RFQLine,RFQItem_PartNum,RFQItem_LineDesc,RFQItem_PUM,RFQQty_QtyNum,RFQQty_Quantity,Vendor_VendorID,Vendor_Name,CreateDate, Vendor_ReplyPrice, Vendor_ReplyAttachment1,Vendor_ReplyAttachment2, Vendor_ReplyAttachment3, Vendor_ReplyStatus, Vendor_ReplyDatetime  ");
		strSql.Append(" *  ");
		strSql.Append(" FROM ps_epicor_rfq ");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" where " + strWhere);
		}
		strSql.Append(" order by " + filedOrder);
		return DbHelperSQL.Query(strSql.ToString());
	}

	/// <summary>
	/// 获取记录总数
	/// </summary>
	public int GetRecordCount(string strWhere)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select count(1) FROM ps_epicor_rfq ");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" where " + strWhere);
		}
		object obj = DbHelperSQL.GetSingle(strSql.ToString());
		if (obj == null)
		{
			return 0;
		}
		else
		{
			return Convert.ToInt32(obj);
		}
	}
	/// <summary>
	/// 分页获取数据列表
	/// </summary>
	public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("SELECT * FROM ( ");
		strSql.Append(" SELECT ROW_NUMBER() OVER (");
		if (!string.IsNullOrEmpty(orderby.Trim()))
		{
			strSql.Append("order by T." + orderby);
		}
		else
		{
			strSql.Append("order by T.ID desc");
		}
		strSql.Append(")AS Row, T.*  from ps_epicor_rfq T ");
		if (!string.IsNullOrEmpty(strWhere.Trim()))
		{
			strSql.Append(" WHERE " + strWhere);
		}
		strSql.Append(" ) TT");
		strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
		return DbHelperSQL.Query(strSql.ToString());
	}

	/// <summary>
	/// 获得查询分页数据
	/// </summary>
	public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select * FROM  ps_epicor_rfq ");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" where " + strWhere);
		}
		recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
		return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
	}

	public DataSet GetHeaderList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select * FROM  v_epicor_rfq_head ");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" where " + strWhere);
		}
		recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
		return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
	}


	#endregion  BasicMethod
	#region  ExtensionMethod

	#endregion  ExtensionMethod
}


