using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ps_epicor_rfq_vendorprice
/// </summary>
public class ps_epicor_rfq_vendorprice
{
    public ps_epicor_rfq_vendorprice()
    {
        //
        // TODO: Add constructor logic here
        //
    }
	#region Model
	public int ID { set; get; }
	
	public string UD37_Company { set; get; }
	
	public string UD37_Key1 { set; get; }
	
	public string UD37_Key2 { set; get; }

	
	public string UD37_Key3 { set; get; }

	public string UD37_Key4 { set; get; }

	public string UD37_Key5 { set; get; }

	public string UD37_RFQVP_RFQNum_c { set; get; }

	public string UD37_RFQVP_VendorNum_c { set; get; }

	public string UD37_RFQVP_VendorID_c { set; get; }

	public string UD37_RFQVP_VendorName_c { set; get; }

	public int UD37_RFQVP_RFQLine_c { set; get; }

	public string UD37_RFQVP_RFQQtyNum_c { set; get; }

	public string UD37_RFQVP_PartNum_c { set; get; }

	public string UD37_RFQVP_PartDesc_c { set; get; }

	public decimal? UD37_RFQVP_Qty_c { set; get; }

	public string UD37_RFQVP_PUM_c { set; get; }

	public string UD37_RFQVP_CurrencyCode_c { set; get; }

	public string UD37_RFQVP_OfferedPrice_c { set; get; }

	public decimal? UD37_RFQVP_NegotiatedPrice_c { set; get; }

	public string UD37_RFQVP_Remark_c { set; get; }

	public string UD37_RFQVP_Status_c { set; get; }

	public decimal? UD37_RFQVP_ExchangeRate_c { set; get; }

	public decimal? UD37_RFQVP_BaseUnitPrice_c { set; get; }

	public string PartClass_Description { set; get; }

	public string RFQItem_DueDate_c { set; get; }

	public DateTime? CreateDate { set; get; }

	public DateTime? ModifyDate { set; get; }
	#endregion Model
	#region  BasicMethod
	public int Add(ps_epicor_rfq_vendorprice model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("insert into ps_epicor_rfq_vendorprice(");
		strSql.Append("UD37_Company,UD37_Key1,UD37_Key2,UD37_Key3,UD37_Key4,UD37_Key5,UD37_RFQVP_RFQNum_c,UD37_RFQVP_VendorNum_c,UD37_RFQVP_VendorID_c,UD37_RFQVP_VendorName_c,UD37_RFQVP_RFQLine_c,UD37_RFQVP_RFQQtyNum_c,UD37_RFQVP_PartNum_c,UD37_RFQVP_PartDesc_c,UD37_RFQVP_Qty_c,UD37_RFQVP_PUM_c,UD37_RFQVP_CurrencyCode_c,UD37_RFQVP_OfferedPrice_c,UD37_RFQVP_NegotiatedPrice_c,UD37_RFQVP_Remark_c,UD37_RFQVP_Status_c,UD37_RFQVP_ExchangeRate_c,UD37_RFQVP_BaseUnitPrice_c,PartClass_Description,RFQItem_DueDate_c,CreateDate,ModifyDate)");
		strSql.Append(" select ");
		strSql.Append("@UD37_Company,@UD37_Key1,@UD37_Key2,@UD37_Key3,@UD37_Key4,@UD37_Key5,@UD37_RFQVP_RFQNum_c,@UD37_RFQVP_VendorNum_c,@UD37_RFQVP_VendorID_c,@UD37_RFQVP_VendorName_c,@UD37_RFQVP_RFQLine_c,@UD37_RFQVP_RFQQtyNum_c,@UD37_RFQVP_PartNum_c,@UD37_RFQVP_PartDesc_c,@UD37_RFQVP_Qty_c,@UD37_RFQVP_PUM_c,@UD37_RFQVP_CurrencyCode_c,@UD37_RFQVP_OfferedPrice_c,@UD37_RFQVP_NegotiatedPrice_c,@UD37_RFQVP_Remark_c,@UD37_RFQVP_Status_c,@UD37_RFQVP_ExchangeRate_c,@UD37_RFQVP_BaseUnitPrice_c,@PartClass_Description,@RFQItem_DueDate_c,@CreateDate,@ModifyDate ");
		strSql.Append(" WHERE @UD37_RFQVP_RFQNum_c + '-' + cast(@UD37_Key5 as nvarchar) + '-' + @UD37_RFQVP_VendorID_c not in (select UD37_RFQVP_RFQNum_c + '-' + cast(UD37_Key5 as nvarchar) + '-' + UD37_RFQVP_VendorID_c from ps_epicor_rfq_vendorprice)");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
					new SqlParameter("@UD37_Company", SqlDbType.NVarChar,50),
					new SqlParameter("@UD37_Key1", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_Key2", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_Key3", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_Key4", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_Key5", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_RFQNum_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_VendorNum_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_VendorID_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_VendorName_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_RFQLine_c", SqlDbType.Int,4),
					new SqlParameter("@UD37_RFQVP_RFQQtyNum_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_PartNum_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_PartDesc_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_Qty_c", SqlDbType.Decimal,9),
					new SqlParameter("@UD37_RFQVP_PUM_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_CurrencyCode_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_OfferedPrice_c",SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_NegotiatedPrice_c", SqlDbType.Decimal,9),
					new SqlParameter("@UD37_RFQVP_Remark_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_Status_c", SqlDbType.NVarChar,20),
					new SqlParameter("@UD37_RFQVP_ExchangeRate_c", SqlDbType.Decimal,9),
					new SqlParameter("@UD37_RFQVP_BaseUnitPrice_c", SqlDbType.Decimal,9),
					new SqlParameter("@PartClass_Description", SqlDbType.NVarChar,200),
					new SqlParameter("@RFQItem_DueDate_c", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ModifyDate", SqlDbType.DateTime)};
		parameters[0].Value = model.UD37_Company;
		parameters[1].Value = model.UD37_Key1;
		parameters[2].Value = model.UD37_Key2;
		parameters[3].Value = model.UD37_Key3;
		parameters[4].Value = model.UD37_Key4;
		parameters[5].Value = model.UD37_Key5;
		parameters[6].Value = model.UD37_RFQVP_RFQNum_c;
		parameters[7].Value = model.UD37_RFQVP_VendorNum_c;
		parameters[8].Value = model.UD37_RFQVP_VendorID_c;
		parameters[9].Value = model.UD37_RFQVP_VendorName_c;
		parameters[10].Value = model.UD37_RFQVP_RFQLine_c;
		parameters[11].Value = model.UD37_RFQVP_RFQQtyNum_c;
		parameters[12].Value = model.UD37_RFQVP_PartNum_c;
		parameters[13].Value = model.UD37_RFQVP_PartDesc_c;
		parameters[14].Value = model.UD37_RFQVP_Qty_c;
		parameters[15].Value = model.UD37_RFQVP_PUM_c;
		parameters[16].Value = model.UD37_RFQVP_CurrencyCode_c;
		parameters[17].Value = model.UD37_RFQVP_OfferedPrice_c;
		parameters[18].Value = model.UD37_RFQVP_NegotiatedPrice_c;
		parameters[19].Value = model.UD37_RFQVP_Remark_c;
		parameters[20].Value = model.UD37_RFQVP_Status_c;
		parameters[21].Value = model.UD37_RFQVP_ExchangeRate_c;
		parameters[22].Value = model.UD37_RFQVP_BaseUnitPrice_c;
		parameters[23].Value = model.PartClass_Description;
		parameters[24].Value = model.RFQItem_DueDate_c;
		parameters[25].Value = model.CreateDate;
		parameters[26].Value = model.ModifyDate;

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
	public bool Update(ps_epicor_rfq_vendorprice model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_rfq_vendorprice set ");
		strSql.Append("UD37_Company=@UD37_Company,");
		strSql.Append("UD37_Key1=@UD37_Key1,");
		strSql.Append("UD37_Key2=@UD37_Key2,");
		strSql.Append("UD37_Key3=@UD37_Key3,");
		strSql.Append("UD37_Key4=@UD37_Key4,");
		strSql.Append("UD37_Key5=@UD37_Key5,");
		strSql.Append("UD37_RFQVP_RFQNum_c=@UD37_RFQVP_RFQNum_c,");
		strSql.Append("UD37_RFQVP_VendorNum_c=@UD37_RFQVP_VendorNum_c,");
		strSql.Append("UD37_RFQVP_VendorID_c=@UD37_RFQVP_VendorID_c,");
		strSql.Append("UD37_RFQVP_VendorName_c=@UD37_RFQVP_VendorName_c,");
		strSql.Append("UD37_RFQVP_RFQLine_c=@UD37_RFQVP_RFQLine_c,");
		strSql.Append("UD37_RFQVP_RFQQtyNum_c=@UD37_RFQVP_RFQQtyNum_c,");
		strSql.Append("UD37_RFQVP_PartNum_c=@UD37_RFQVP_PartNum_c,");
		strSql.Append("UD37_RFQVP_PartDesc_c=@UD37_RFQVP_PartDesc_c,");
		strSql.Append("UD37_RFQVP_Qty_c=@UD37_RFQVP_Qty_c,");
		strSql.Append("UD37_RFQVP_PUM_c=@UD37_RFQVP_PUM_c,");
		strSql.Append("UD37_RFQVP_CurrencyCode_c=@UD37_RFQVP_CurrencyCode_c,");
		strSql.Append("UD37_RFQVP_OfferedPrice_c=@UD37_RFQVP_OfferedPrice_c,");
		strSql.Append("UD37_RFQVP_NegotiatedPrice_c=@UD37_RFQVP_NegotiatedPrice_c,");
		strSql.Append("UD37_RFQVP_Remark_c=@UD37_RFQVP_Remark_c,");
		strSql.Append("UD37_RFQVP_Status_c=@UD37_RFQVP_Status_c,");
		strSql.Append("UD37_RFQVP_ExchangeRate_c=@UD37_RFQVP_ExchangeRate_c,");
		strSql.Append("UD37_RFQVP_BaseUnitPrice_c=@UD37_RFQVP_BaseUnitPrice_c,");
		strSql.Append("PartClass_Description=@PartClass_Description,");
		strSql.Append("RFQItem_DueDate_c=@RFQItem_DueDate_c,");
		//strSql.Append("CreateDate=@CreateDate,");
		strSql.Append("ModifyDate=getdate()");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@UD37_Company", SqlDbType.NVarChar,50),
					new SqlParameter("@UD37_Key1", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_Key2", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_Key3", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_Key4", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_Key5", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_RFQNum_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_VendorNum_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_VendorID_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_VendorName_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_RFQLine_c", SqlDbType.Int,4),
					new SqlParameter("@UD37_RFQVP_RFQQtyNum_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_PartNum_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_PartDesc_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_Qty_c", SqlDbType.Decimal,9),
					new SqlParameter("@UD37_RFQVP_PUM_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_CurrencyCode_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_OfferedPrice_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_NegotiatedPrice_c", SqlDbType.Decimal,9),
					new SqlParameter("@UD37_RFQVP_Remark_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD37_RFQVP_Status_c", SqlDbType.NVarChar,20),
					new SqlParameter("@UD37_RFQVP_ExchangeRate_c", SqlDbType.Decimal,9),
					new SqlParameter("@UD37_RFQVP_BaseUnitPrice_c", SqlDbType.Decimal,9),
					new SqlParameter("@PartClass_Description", SqlDbType.NVarChar,200),
					new SqlParameter("@RFQItem_DueDate_c", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ModifyDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
		parameters[0].Value = model.UD37_Company;
		parameters[1].Value = model.UD37_Key1;
		parameters[2].Value = model.UD37_Key2;
		parameters[3].Value = model.UD37_Key3;
		parameters[4].Value = model.UD37_Key4;
		parameters[5].Value = model.UD37_Key5;
		parameters[6].Value = model.UD37_RFQVP_RFQNum_c;
		parameters[7].Value = model.UD37_RFQVP_VendorNum_c;
		parameters[8].Value = model.UD37_RFQVP_VendorID_c;
		parameters[9].Value = model.UD37_RFQVP_VendorName_c;
		parameters[10].Value = model.UD37_RFQVP_RFQLine_c;
		parameters[11].Value = model.UD37_RFQVP_RFQQtyNum_c;
		parameters[12].Value = model.UD37_RFQVP_PartNum_c;
		parameters[13].Value = model.UD37_RFQVP_PartDesc_c;
		parameters[14].Value = model.UD37_RFQVP_Qty_c;
		parameters[15].Value = model.UD37_RFQVP_PUM_c;
		parameters[16].Value = model.UD37_RFQVP_CurrencyCode_c;
		parameters[17].Value = model.UD37_RFQVP_OfferedPrice_c;
		parameters[18].Value = model.UD37_RFQVP_NegotiatedPrice_c;
		parameters[19].Value = model.UD37_RFQVP_Remark_c;
		parameters[20].Value = model.UD37_RFQVP_Status_c;
		parameters[21].Value = model.UD37_RFQVP_ExchangeRate_c;
		parameters[22].Value = model.UD37_RFQVP_BaseUnitPrice_c;
		parameters[23].Value = model.PartClass_Description;
		parameters[24].Value = model.RFQItem_DueDate_c;
		parameters[25].Value = model.CreateDate;
		parameters[26].Value = model.ModifyDate;
		parameters[27].Value = model.ID;

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
		strSql.Append("delete from ps_epicor_rfq_vendorprice ");
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
		strSql.Append("delete from ps_epicor_rfq_vendorprice ");
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
	public ps_epicor_rfq_vendorprice GetModel(int ID)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("select  top 1 ID,UD37_Company,UD37_Key1,UD37_Key2,UD37_Key3,UD37_Key4,UD37_Key5,UD37_RFQVP_RFQNum_c,UD37_RFQVP_VendorNum_c,UD37_RFQVP_VendorID_c,UD37_RFQVP_VendorName_c,UD37_RFQVP_RFQLine_c,UD37_RFQVP_RFQQtyNum_c,UD37_RFQVP_PartNum_c,UD37_RFQVP_PartDesc_c,UD37_RFQVP_Qty_c,UD37_RFQVP_PUM_c,UD37_RFQVP_CurrencyCode_c,UD37_RFQVP_OfferedPrice_c,UD37_RFQVP_NegotiatedPrice_c,UD37_RFQVP_Remark_c,UD37_RFQVP_Status_c,UD37_RFQVP_ExchangeRate_c,UD37_RFQVP_BaseUnitPrice_c,PartClass_Description,RFQItem_DueDate_c,CreateDate,ModifyDate from ps_epicor_rfq_vendorprice ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
		parameters[0].Value = ID;

		ps_epicor_rfq_vendorprice model = new ps_epicor_rfq_vendorprice();
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
	public ps_epicor_rfq_vendorprice DataRowToModel(DataRow row)
	{
		ps_epicor_rfq_vendorprice model = new ps_epicor_rfq_vendorprice();
		if (row != null)
		{
			if (row["ID"] != null && row["ID"].ToString() != "")
			{
				model.ID = int.Parse(row["ID"].ToString());
			}
			if (row["UD37_Company"] != null)
			{
				model.UD37_Company = row["UD37_Company"].ToString();
			}
			if (row["UD37_Key1"] != null)
			{
				model.UD37_Key1 = row["UD37_Key1"].ToString();
			}
			if (row["UD37_Key2"] != null)
			{
				model.UD37_Key2 = row["UD37_Key2"].ToString();
			}
			if (row["UD37_Key3"] != null)
			{
				model.UD37_Key3 = row["UD37_Key3"].ToString();
			}
			if (row["UD37_Key4"] != null)
			{
				model.UD37_Key4 = row["UD37_Key4"].ToString();
			}
			if (row["UD37_Key5"] != null)
			{
				model.UD37_Key5 = row["UD37_Key5"].ToString();
			}
			if (row["UD37_RFQVP_RFQNum_c"] != null)
			{
				model.UD37_RFQVP_RFQNum_c = row["UD37_RFQVP_RFQNum_c"].ToString();
			}
			if (row["UD37_RFQVP_VendorNum_c"] != null)
			{
				model.UD37_RFQVP_VendorNum_c = row["UD37_RFQVP_VendorNum_c"].ToString();
			}
			if (row["UD37_RFQVP_VendorID_c"] != null)
			{
				model.UD37_RFQVP_VendorID_c = row["UD37_RFQVP_VendorID_c"].ToString();
			}
			if (row["UD37_RFQVP_VendorName_c"] != null)
			{
				model.UD37_RFQVP_VendorName_c = row["UD37_RFQVP_VendorName_c"].ToString();
			}
			if (row["UD37_RFQVP_RFQLine_c"] != null && row["UD37_RFQVP_RFQLine_c"].ToString() != "")
			{
				model.UD37_RFQVP_RFQLine_c = int.Parse(row["UD37_RFQVP_RFQLine_c"].ToString());
			}
			if (row["UD37_RFQVP_RFQQtyNum_c"] != null)
			{
				model.UD37_RFQVP_RFQQtyNum_c = row["UD37_RFQVP_RFQQtyNum_c"].ToString();
			}
			if (row["UD37_RFQVP_PartNum_c"] != null)
			{
				model.UD37_RFQVP_PartNum_c = row["UD37_RFQVP_PartNum_c"].ToString();
			}
			if (row["UD37_RFQVP_PartDesc_c"] != null)
			{
				model.UD37_RFQVP_PartDesc_c = row["UD37_RFQVP_PartDesc_c"].ToString();
			}
			if (row["UD37_RFQVP_Qty_c"] != null && row["UD37_RFQVP_Qty_c"].ToString() != "")
			{
				model.UD37_RFQVP_Qty_c = decimal.Parse(row["UD37_RFQVP_Qty_c"].ToString());
			}
			if (row["UD37_RFQVP_PUM_c"] != null)
			{
				model.UD37_RFQVP_PUM_c = row["UD37_RFQVP_PUM_c"].ToString();
			}
			if (row["UD37_RFQVP_CurrencyCode_c"] != null)
			{
				model.UD37_RFQVP_CurrencyCode_c = row["UD37_RFQVP_CurrencyCode_c"].ToString();
			}
			if (row["UD37_RFQVP_OfferedPrice_c"] != null )
			{
				model.UD37_RFQVP_OfferedPrice_c = row["UD37_RFQVP_OfferedPrice_c"].ToString();
			}
			if (row["UD37_RFQVP_NegotiatedPrice_c"] != null && row["UD37_RFQVP_NegotiatedPrice_c"].ToString() != "")
			{
				model.UD37_RFQVP_NegotiatedPrice_c = decimal.Parse(row["UD37_RFQVP_NegotiatedPrice_c"].ToString());
			}
			if (row["UD37_RFQVP_Remark_c"] != null)
			{
				model.UD37_RFQVP_Remark_c = row["UD37_RFQVP_Remark_c"].ToString();
			}
			if (row["UD37_RFQVP_Status_c"] != null )
			{
				model.UD37_RFQVP_Status_c = row["UD37_RFQVP_Status_c"].ToString();
			}
			if (row["UD37_RFQVP_ExchangeRate_c"] != null && row["UD37_RFQVP_ExchangeRate_c"].ToString() != "")
			{
				model.UD37_RFQVP_ExchangeRate_c = decimal.Parse(row["UD37_RFQVP_ExchangeRate_c"].ToString());
			}
			if (row["UD37_RFQVP_BaseUnitPrice_c"] != null && row["UD37_RFQVP_BaseUnitPrice_c"].ToString() != "")
			{
				model.UD37_RFQVP_BaseUnitPrice_c = decimal.Parse(row["UD37_RFQVP_BaseUnitPrice_c"].ToString());
			}
			if (row["PartClass_Description"] != null)
			{
				model.PartClass_Description = row["PartClass_Description"].ToString();
			}
			if (row["RFQItem_DueDate_c"] != null)
			{
				model.RFQItem_DueDate_c = row["RFQItem_DueDate_c"].ToString();
			}
			if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
			{
				model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
			}
			if (row["ModifyDate"] != null && row["ModifyDate"].ToString() != "")
			{
				model.ModifyDate = DateTime.Parse(row["ModifyDate"].ToString());
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
		strSql.Append("select ID,UD37_Company,UD37_Key1,UD37_Key2,UD37_Key3,UD37_Key4,UD37_Key5,UD37_RFQVP_RFQNum_c,UD37_RFQVP_VendorNum_c,UD37_RFQVP_VendorID_c,UD37_RFQVP_VendorName_c,UD37_RFQVP_RFQLine_c,UD37_RFQVP_RFQQtyNum_c,UD37_RFQVP_PartNum_c,UD37_RFQVP_PartDesc_c,UD37_RFQVP_Qty_c,UD37_RFQVP_PUM_c,UD37_RFQVP_CurrencyCode_c,UD37_RFQVP_OfferedPrice_c,UD37_RFQVP_NegotiatedPrice_c,UD37_RFQVP_Remark_c,UD37_RFQVP_Status_c,UD37_RFQVP_ExchangeRate_c,UD37_RFQVP_BaseUnitPrice_c,PartClass_Description,RFQItem_DueDate_c,CreateDate,ModifyDate ");
		strSql.Append(" FROM ps_epicor_rfq_vendorprice ");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" where " + strWhere);
		}
		return DbHelperSQL.Query(strSql.ToString());
	}

	/// <summary>
	/// 获得查询分页数据
	/// </summary>
	public DataSet GetList2(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select * FROM  v_epicor_rfq_vendorprice where (id>0)");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" and " + strWhere);
		}
		recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
		return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
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
		strSql.Append(" ID,UD37_Company,UD37_Key1,UD37_Key2,UD37_Key3,UD37_Key4,UD37_Key5,UD37_RFQVP_RFQNum_c,UD37_RFQVP_VendorNum_c,UD37_RFQVP_VendorID_c,UD37_RFQVP_VendorName_c,UD37_RFQVP_RFQLine_c,UD37_RFQVP_RFQQtyNum_c,UD37_RFQVP_PartNum_c,UD37_RFQVP_PartDesc_c,UD37_RFQVP_Qty_c,UD37_RFQVP_PUM_c,UD37_RFQVP_CurrencyCode_c,UD37_RFQVP_OfferedPrice_c,UD37_RFQVP_NegotiatedPrice_c,UD37_RFQVP_Remark_c,UD37_RFQVP_Status_c,UD37_RFQVP_ExchangeRate_c,UD37_RFQVP_BaseUnitPrice_c,PartClass_Description,RFQItem_DueDate_c,CreateDate,ModifyDate ");
		strSql.Append(" FROM ps_epicor_rfq_vendorprice ");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" where " + strWhere);
		}
		strSql.Append(" order by " + filedOrder);
		return DbHelperSQL.Query(strSql.ToString());
	}

	/// <summary>
	/// 获得数据列表
	/// </summary>
	public DataSet GetList2(string strWhere)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select distinct UD37_Company,UD37_RFQVP_RFQNum_c,UD37_RFQVP_RFQLine_c,UD37_Key2 as UD37_RFQVP_VendorNum_c   ");
		strSql.Append(" FROM ps_epicor_rfq_vendorprice ");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" where " + strWhere);
		}
		return DbHelperSQL.Query(strSql.ToString());
	}

	/// <summary>
	/// 获取记录总数
	/// </summary>
	public int GetRecordCount(string strWhere)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select count(1) FROM ps_epicor_rfq_vendorprice ");
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
		strSql.Append(")AS Row, T.*  from ps_epicor_rfq_vendorprice T ");
		if (!string.IsNullOrEmpty(strWhere.Trim()))
		{
			strSql.Append(" WHERE " + strWhere);
		}
		strSql.Append(" ) TT");
		strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
		return DbHelperSQL.Query(strSql.ToString());
	}

	/*
	/// <summary>
	/// 分页获取数据列表
	/// </summary>
	public DataSet GetList(int PageSize,int PageIndex,string strWhere)
	{
		SqlParameter[] parameters = {
				new SqlParameter("@tblName", SqlDbType.VarChar, 255),
				new SqlParameter("@fldName", SqlDbType.VarChar, 255),
				new SqlParameter("@PageSize", SqlDbType.Int),
				new SqlParameter("@PageIndex", SqlDbType.Int),
				new SqlParameter("@IsReCount", SqlDbType.Bit),
				new SqlParameter("@OrderType", SqlDbType.Bit),
				new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
				};
		parameters[0].Value = "ps_epicor_rfq_vendorprice";
		parameters[1].Value = "ID";
		parameters[2].Value = PageSize;
		parameters[3].Value = PageIndex;
		parameters[4].Value = 0;
		parameters[5].Value = 0;
		parameters[6].Value = strWhere;	
		return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
	}*/

#endregion  BasicMethod
}
