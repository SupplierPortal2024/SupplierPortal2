using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


/// <summary>
/// 数据访问类:ps_epicor_vendor
/// </summary>
public partial class ps_epicor_po
{
	public ps_epicor_po()
	{ }
	#region  BasicMethod
	#region Model
	public int ID { set; get; }

	public string Vendor_Company { set; get; }

	public string Vendor_VendorID { set; get; }

	public string Vendor_Name { set; get; }

	public string POHeader_PONum { set; get; }

	public DateTime POHeader_OrderDate { set; get; }

	public string PODetail_OpenLine { set; get; }

	public string PODetail_VoidLine { set; get; }

	public string PODetail_POLine { set; get; }

	public string PODetail_PartNum { set; get; }

	public string PODetail_LineDesc { set; get; }

	public decimal PODetail_DocUnitCost { set; get; }

	public decimal PODetail_OrderQty { set; get; }

	public string PODetail_PUM { set; get; }

	public decimal PODetail_DocExtCost { set; get; }

	public string POHeader_CurrencyCode { set; get; }

	public DateTime CreateDate { set; get; }
	#endregion Model


	public int Add()
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("insert into ps_epicor_po(");
		strSql.Append("Vendor_Company,Vendor_VendorID,Vendor_Name,POHeader_PONum,POHeader_OrderDate,PODetail_OpenLine,PODetail_VoidLine,PODetail_POLine,PODetail_PartNum,PODetail_LineDesc,PODetail_DocUnitCost,PODetail_OrderQty,PODetail_PUM,PODetail_DocExtCost,POHeader_CurrencyCode)");
		strSql.Append(" select ");
		strSql.Append("@Vendor_Company,@Vendor_VendorID,@Vendor_Name,@POHeader_PONum,@POHeader_OrderDate,@PODetail_OpenLine,@PODetail_VoidLine,@PODetail_POLine,@PODetail_PartNum,@PODetail_LineDesc,@PODetail_DocUnitCost,@PODetail_OrderQty,@PODetail_PUM,@PODetail_DocExtCost,@POHeader_CurrencyCode ");
		strSql.Append(" WHERE @POHeader_PONum not in (select POHeader_PONum from ps_epicor_po)");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
					new SqlParameter("@Vendor_Company", SqlDbType.NVarChar,100),
					new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,100),
					new SqlParameter("@Vendor_Name", SqlDbType.NVarChar,200),
					new SqlParameter("@POHeader_PONum", SqlDbType.NVarChar,100),
					new SqlParameter("@POHeader_OrderDate", SqlDbType.DateTime),
					new SqlParameter("@PODetail_OpenLine", SqlDbType.NVarChar,10),
					new SqlParameter("@PODetail_VoidLine", SqlDbType.NVarChar,10),
					new SqlParameter("@PODetail_POLine", SqlDbType.NVarChar,10),
					new SqlParameter("@PODetail_PartNum", SqlDbType.NVarChar,100),
					new SqlParameter("@PODetail_LineDesc", SqlDbType.NVarChar,200),
					new SqlParameter("@PODetail_DocUnitCost", SqlDbType.Decimal,9),
					new SqlParameter("@PODetail_OrderQty", SqlDbType.Decimal,9),
					new SqlParameter("@PODetail_PUM", SqlDbType.NVarChar,10),
					new SqlParameter("@PODetail_DocExtCost", SqlDbType.Decimal,9),
					new SqlParameter("@POHeader_CurrencyCode", SqlDbType.NVarChar,10)};
		parameters[0].Value = Vendor_Company;
		parameters[1].Value = Vendor_VendorID;
		parameters[2].Value = Vendor_Name;
		parameters[3].Value = POHeader_PONum;
		parameters[4].Value = POHeader_OrderDate;
		parameters[5].Value = PODetail_OpenLine;
		parameters[6].Value = PODetail_VoidLine;
		parameters[7].Value = PODetail_POLine;
		parameters[8].Value = PODetail_PartNum;
		parameters[9].Value = PODetail_LineDesc;
		parameters[10].Value = PODetail_DocUnitCost;
		parameters[11].Value = PODetail_OrderQty;
		parameters[12].Value = PODetail_PUM;
		parameters[13].Value = PODetail_DocExtCost;
		parameters[14].Value = POHeader_CurrencyCode;

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
	public bool Update()
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_po set ");
		strSql.Append("Vendor_Company=@Vendor_Company,");
		strSql.Append("Vendor_VendorID=@Vendor_VendorID,");
		strSql.Append("Vendor_Name=@Vendor_Name,");
		strSql.Append("POHeader_PONum=@POHeader_PONum,");
		strSql.Append("POHeader_OrderDate=@POHeader_OrderDate,");
		strSql.Append("PODetail_OpenLine=@PODetail_OpenLine,");
		strSql.Append("PODetail_VoidLine=@PODetail_VoidLine,");
		strSql.Append("PODetail_POLine=@PODetail_POLine,");
		strSql.Append("PODetail_PartNum=@PODetail_PartNum,");
		strSql.Append("PODetail_LineDesc=@PODetail_LineDesc,");
		strSql.Append("PODetail_DocUnitCost=@PODetail_DocUnitCost,");
		strSql.Append("PODetail_OrderQty=@PODetail_OrderQty,");
		strSql.Append("PODetail_PUM=@PODetail_PUM,");
		strSql.Append("PODetail_DocExtCost=@PODetail_DocExtCost,");
		strSql.Append("POHeader_CurrencyCode=@POHeader_CurrencyCode");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@Vendor_Company", SqlDbType.NVarChar,100),
					new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,100),
					new SqlParameter("@Vendor_Name", SqlDbType.NVarChar,200),
					new SqlParameter("@POHeader_PONum", SqlDbType.NVarChar,100),
					new SqlParameter("@POHeader_OrderDate", SqlDbType.DateTime),
					new SqlParameter("@PODetail_OpenLine", SqlDbType.NVarChar,10),
					new SqlParameter("@PODetail_VoidLine", SqlDbType.NVarChar,10),
					new SqlParameter("@PODetail_POLine", SqlDbType.NVarChar,10),
					new SqlParameter("@PODetail_PartNum", SqlDbType.NVarChar,100),
					new SqlParameter("@PODetail_LineDesc", SqlDbType.NVarChar,200),
					new SqlParameter("@PODetail_DocUnitCost", SqlDbType.Decimal,9),
					new SqlParameter("@PODetail_OrderQty", SqlDbType.Decimal,9),
					new SqlParameter("@PODetail_PUM", SqlDbType.NVarChar,10),
					new SqlParameter("@PODetail_DocExtCost", SqlDbType.Decimal,9),
					new SqlParameter("@POHeader_CurrencyCode", SqlDbType.NVarChar,10),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
		parameters[0].Value = Vendor_Company;
		parameters[1].Value = Vendor_VendorID;
		parameters[2].Value = Vendor_Name;
		parameters[3].Value = POHeader_PONum;
		parameters[4].Value = POHeader_OrderDate;
		parameters[5].Value = PODetail_OpenLine;
		parameters[6].Value = PODetail_VoidLine;
		parameters[7].Value = PODetail_POLine;
		parameters[8].Value = PODetail_PartNum;
		parameters[9].Value = PODetail_LineDesc;
		parameters[10].Value = PODetail_DocUnitCost;
		parameters[11].Value = PODetail_OrderQty;
		parameters[12].Value = PODetail_PUM;
		parameters[13].Value = PODetail_DocExtCost;
		parameters[14].Value = POHeader_CurrencyCode;
		parameters[16].Value = ID;

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
		strSql.Append("delete from ps_epicor_po ");
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
		strSql.Append("delete from ps_epicor_po ");
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
	public ps_epicor_po GetModel(int ID)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("select  top 1 ID,Vendor_Company,Vendor_VendorID,Vendor_Name,POHeader_PONum,POHeader_OrderDate,PODetail_OpenLine,PODetail_VoidLine,PODetail_POLine,PODetail_PartNum,PODetail_LineDesc,PODetail_DocUnitCost,PODetail_OrderQty,PODetail_PUM,PODetail_DocExtCost,POHeader_CurrencyCode,CreateDate from ps_epicor_po ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
		parameters[0].Value = ID;

		ps_epicor_po model = new ps_epicor_po();
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
	public ps_epicor_po DataRowToModel(DataRow row)
	{
		ps_epicor_po model = new ps_epicor_po();
		if (row != null)
		{
			if (row["ID"] != null && row["ID"].ToString() != "")
			{
				model.ID = int.Parse(row["ID"].ToString());
			}
			if (row["Vendor_Company"] != null)
			{
				model.Vendor_Company = row["Vendor_Company"].ToString();
			}
			if (row["Vendor_VendorID"] != null)
			{
				model.Vendor_VendorID = row["Vendor_VendorID"].ToString();
			}
			if (row["Vendor_Name"] != null)
			{
				model.Vendor_Name = row["Vendor_Name"].ToString();
			}
			if (row["POHeader_PONum"] != null)
			{
				model.POHeader_PONum = row["POHeader_PONum"].ToString();
			}
			if (row["POHeader_OrderDate"] != null && row["POHeader_OrderDate"].ToString() != "")
			{
				model.POHeader_OrderDate = DateTime.Parse(row["POHeader_OrderDate"].ToString());
			}
			if (row["PODetail_OpenLine"] != null)
			{
				model.PODetail_OpenLine = row["PODetail_OpenLine"].ToString();
			}
			if (row["PODetail_VoidLine"] != null)
			{
				model.PODetail_VoidLine = row["PODetail_VoidLine"].ToString();
			}
			if (row["PODetail_POLine"] != null)
			{
				model.PODetail_POLine = row["PODetail_POLine"].ToString();
			}
			if (row["PODetail_PartNum"] != null)
			{
				model.PODetail_PartNum = row["PODetail_PartNum"].ToString();
			}
			if (row["PODetail_LineDesc"] != null)
			{
				model.PODetail_LineDesc = row["PODetail_LineDesc"].ToString();
			}
			if (row["PODetail_DocUnitCost"] != null && row["PODetail_DocUnitCost"].ToString() != "")
			{
				model.PODetail_DocUnitCost = decimal.Parse(row["PODetail_DocUnitCost"].ToString());
			}
			if (row["PODetail_OrderQty"] != null && row["PODetail_OrderQty"].ToString() != "")
			{
				model.PODetail_OrderQty = decimal.Parse(row["PODetail_OrderQty"].ToString());
			}
			if (row["PODetail_PUM"] != null)
			{
				model.PODetail_PUM = row["PODetail_PUM"].ToString();
			}
			if (row["PODetail_DocExtCost"] != null && row["PODetail_DocExtCost"].ToString() != "")
			{
				model.PODetail_DocExtCost = decimal.Parse(row["PODetail_DocExtCost"].ToString());
			}
			if (row["POHeader_CurrencyCode"] != null)
			{
				model.POHeader_CurrencyCode = row["POHeader_CurrencyCode"].ToString();
			}
			if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
			{
				model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
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
		strSql.Append("select ID,Vendor_Company,Vendor_VendorID,Vendor_Name,POHeader_PONum,POHeader_OrderDate,PODetail_OpenLine,PODetail_VoidLine,PODetail_POLine,PODetail_PartNum,PODetail_LineDesc,PODetail_DocUnitCost,PODetail_OrderQty,PODetail_PUM,PODetail_DocExtCost,POHeader_CurrencyCode,CreateDate ");
		strSql.Append(" FROM ps_epicor_po ");
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
		strSql.Append(" ID,Vendor_Company,Vendor_VendorID,Vendor_Name,POHeader_PONum,POHeader_OrderDate,PODetail_OpenLine,PODetail_VoidLine,PODetail_POLine,PODetail_PartNum,PODetail_LineDesc,PODetail_DocUnitCost,PODetail_OrderQty,PODetail_PUM,PODetail_DocExtCost,POHeader_CurrencyCode,CreateDate ");
		strSql.Append(" FROM ps_epicor_po ");
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
		strSql.Append("select count(1) FROM ps_epicor_po ");
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
		strSql.Append(")AS Row, T.*  from ps_epicor_po T ");
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
		strSql.Append("select * FROM  ps_epicor_po ");
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


