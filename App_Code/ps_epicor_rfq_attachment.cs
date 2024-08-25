using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ps_epicor_rfq_vendorprice
/// </summary>
public class ps_epicor_rfq_attachment
{
	public ps_epicor_rfq_attachment()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	#region Model
	public int ID { set; get; }
	public string RFQNum { set; get; }
	public string VendorID { set; get; }
	public byte[] Attachment1 { set; get; }
	public byte[] Attachment2 { set; get; }
	public byte[] Attachment3 { set; get; }
	public byte[] Attachment4 { set; get; }
	public byte[] Attachment5 { set; get; }
	public string Password1 { set; get; }
	public string Password2 { set; get; }
	public string Password3 { set; get; }
	public string Password4 { set; get; }
	public string Password5 { set; get; }
	public string Attachment1FileName { set; get; }
	public string Attachment2FileName { set; get; }
	public string Attachment3FileName { set; get; }
	public string Attachment4FileName { set; get; }
	public string Attachment5FileName { set; get; }
	public DateTime CreateDate { set; get; }

	/// <summary>
	/// 增加一条数据
	/// </summary>
	public int Add(ps_epicor_rfq_attachment model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("insert into ps_epicor_rfq_attachment(");
		strSql.Append("RFQNum,VendorID,Attachment1,Attachment2,Attachment3,Attachment4,Attachment5,Password1,Password2,Password3,Password4,Password5,Attachment1FileName,Attachment2FileName,Attachment3FileName,Attachment4FileName,Attachment5FileName,CreateDate)");
		strSql.Append(" values (");
		strSql.Append("@RFQNum,@VendorID,@Attachment1,@Attachment2,@Attachment3,@Attachment4,@Attachment5,@Password1,@Password2,@Password3,@Password4,@Password5,@Attachment1FileName,@Attachment2FileName,@Attachment3FileName,@Attachment4FileName,@Attachment5FileName,@CreateDate)");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
					new SqlParameter("@RFQNum", SqlDbType.NVarChar,500),
					new SqlParameter("@VendorID", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment1", SqlDbType.VarBinary,-1),
					new SqlParameter("@Attachment2", SqlDbType.VarBinary,-1),
					new SqlParameter("@Attachment3", SqlDbType.VarBinary,-1),
					new SqlParameter("@Attachment4", SqlDbType.VarBinary,-1),
					new SqlParameter("@Attachment5", SqlDbType.VarBinary,-1),
					new SqlParameter("@Password1", SqlDbType.NVarChar,500),
					new SqlParameter("@Password2", SqlDbType.NVarChar,500),
					new SqlParameter("@Password3", SqlDbType.NVarChar,500),
					new SqlParameter("@Password4", SqlDbType.NVarChar,500),
					new SqlParameter("@Password5", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment1FileName", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment2FileName", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment3FileName", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment4FileName", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment5FileName", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
		parameters[0].Value = model.RFQNum;
		parameters[1].Value = model.VendorID;
		parameters[2].Value = model.Attachment1;
		parameters[3].Value = model.Attachment2;
		parameters[4].Value = model.Attachment3;
		parameters[5].Value = model.Attachment4;
		parameters[6].Value = model.Attachment5;
		parameters[7].Value = model.Password1;
		parameters[8].Value = model.Password2;
		parameters[9].Value = model.Password3;
		parameters[10].Value = model.Password4;
		parameters[11].Value = model.Password5;
		parameters[12].Value = model.Attachment1FileName;
		parameters[13].Value = model.Attachment2FileName;
		parameters[14].Value = model.Attachment3FileName;
		parameters[15].Value = model.Attachment4FileName;
		parameters[16].Value = model.Attachment5FileName;
		parameters[17].Value = model.CreateDate;

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
	public bool Update(ps_epicor_rfq_attachment model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_rfq_attachment set ");
		strSql.Append("RFQNum=@RFQNum,");
		strSql.Append("VendorID=@VendorID,");
		strSql.Append("Attachment1=@Attachment1,");
		strSql.Append("Attachment2=@Attachment2,");
		strSql.Append("Attachment3=@Attachment3,");
		strSql.Append("Attachment4=@Attachment4,");
		strSql.Append("Attachment5=@Attachment5,");
		strSql.Append("Password1=@Password1,");
		strSql.Append("Password2=@Password2,");
		strSql.Append("Password3=@Password3,");
		strSql.Append("Password4=@Password4,");
		strSql.Append("Password5=@Password5,");
		strSql.Append("Attachment1FileName=@Attachment1FileName,");
		strSql.Append("Attachment2FileName=@Attachment2FileName,");
		strSql.Append("Attachment3FileName=@Attachment3FileName,");
		strSql.Append("Attachment4FileName=@Attachment4FileName,");
		strSql.Append("Attachment5FileName=@Attachment5FileName,");
		strSql.Append("CreateDate=@CreateDate");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@RFQNum", SqlDbType.NVarChar,500),
					new SqlParameter("@VendorID", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment1", SqlDbType.VarBinary,-1),
					new SqlParameter("@Attachment2", SqlDbType.VarBinary,-1),
					new SqlParameter("@Attachment3", SqlDbType.VarBinary,-1),
					new SqlParameter("@Attachment4", SqlDbType.VarBinary,-1),
					new SqlParameter("@Attachment5", SqlDbType.VarBinary,-1),
					new SqlParameter("@Password1", SqlDbType.NVarChar,500),
					new SqlParameter("@Password2", SqlDbType.NVarChar,500),
					new SqlParameter("@Password3", SqlDbType.NVarChar,500),
					new SqlParameter("@Password4", SqlDbType.NVarChar,500),
					new SqlParameter("@Password5", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment1FileName", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment2FileName", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment3FileName", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment4FileName", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment5FileName", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
		parameters[0].Value = model.RFQNum;
		parameters[1].Value = model.VendorID;
		parameters[2].Value = model.Attachment1;
		parameters[3].Value = model.Attachment2;
		parameters[4].Value = model.Attachment3;
		parameters[5].Value = model.Attachment4;
		parameters[6].Value = model.Attachment5;
		parameters[7].Value = model.Password1;
		parameters[8].Value = model.Password2;
		parameters[9].Value = model.Password3;
		parameters[10].Value = model.Password4;
		parameters[11].Value = model.Password5;
		parameters[12].Value = model.Attachment1FileName;
		parameters[13].Value = model.Attachment2FileName;
		parameters[14].Value = model.Attachment3FileName;
		parameters[15].Value = model.Attachment4FileName;
		parameters[16].Value = model.Attachment5FileName;
		parameters[17].Value = model.CreateDate;
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
	/// 删除一条数据
	/// </summary>
	public bool Delete(int ID)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("delete from ps_epicor_rfq_attachment ");
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
		strSql.Append("delete from ps_epicor_rfq_attachment ");
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
	public ps_epicor_rfq_attachment GetModel(int ID)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("select  top 1 ID,RFQNum,VendorID,Attachment1,Attachment2,Attachment3,Attachment4,Attachment5,Password1,Password2,Password3,Password4,Password5,Attachment1FileName,Attachment2FileName,Attachment3FileName,Attachment4FileName,Attachment5FileName,CreateDate from ps_epicor_rfq_attachment ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
		parameters[0].Value = ID;

		ps_epicor_rfq_attachment model = new ps_epicor_rfq_attachment();
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
	public ps_epicor_rfq_attachment GetModelByRFQNumberAndVendorID(string RFQNum,string VendorID)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("select  top 1 ID,RFQNum,VendorID,Attachment1,Attachment2,Attachment3,Attachment4,Attachment5,Password1,Password2,Password3,Password4,Password5,Attachment1FileName,Attachment2FileName,Attachment3FileName,Attachment4FileName,Attachment5FileName,CreateDate from ps_epicor_rfq_attachment ");
		strSql.Append(" where RFQNum=@RFQNum");
		strSql.Append(" and VendorID=@VendorID");
		SqlParameter[] parameters = {
					new SqlParameter("@RFQNum", SqlDbType.NVarChar,500),
					new SqlParameter("@VendorID", SqlDbType.NVarChar,500)
			};
		parameters[0].Value = RFQNum;
		parameters[1].Value = VendorID;

		ps_epicor_rfq_attachment model = new ps_epicor_rfq_attachment();
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
	public ps_epicor_rfq_attachment DataRowToModel(DataRow row)
	{
		ps_epicor_rfq_attachment model = new ps_epicor_rfq_attachment();
		if (row != null)
		{
			if (row["ID"] != null && row["ID"].ToString() != "")
			{
				model.ID = int.Parse(row["ID"].ToString());
			}
			if (row["RFQNum"] != null)
			{
				model.RFQNum = row["RFQNum"].ToString();
			}
			if (row["VendorID"] != null)
			{
				model.VendorID = row["VendorID"].ToString();
			}
			if (row["Attachment1"] != null && row["Attachment1"].ToString() != "")
			{
				model.Attachment1 = (byte[])row["Attachment1"];
			}
			if (row["Attachment2"] != null && row["Attachment2"].ToString() != "")
			{
				model.Attachment2 = (byte[])row["Attachment2"];
			}
			if (row["Attachment3"] != null && row["Attachment3"].ToString() != "")
			{
				model.Attachment3 = (byte[])row["Attachment3"];
			}
			if (row["Attachment4"] != null && row["Attachment4"].ToString() != "")
			{
				model.Attachment4 = (byte[])row["Attachment4"];
			}
			if (row["Attachment5"] != null && row["Attachment5"].ToString() != "")
			{
				model.Attachment5 = (byte[])row["Attachment5"];
			}
			if (row["Password1"] != null)
			{
				model.Password1 = row["Password1"].ToString();
			}
			if (row["Password2"] != null)
			{
				model.Password2 = row["Password2"].ToString();
			}
			if (row["Password3"] != null)
			{
				model.Password3 = row["Password3"].ToString();
			}
			if (row["Password4"] != null)
			{
				model.Password4 = row["Password4"].ToString();
			}
			if (row["Password5"] != null)
			{
				model.Password5 = row["Password5"].ToString();
			}
			if (row["Attachment1FileName"] != null)
			{
				model.Attachment1FileName = row["Attachment1FileName"].ToString();
			}
			if (row["Attachment2FileName"] != null)
			{
				model.Attachment2FileName = row["Attachment2FileName"].ToString();
			}
			if (row["Attachment3FileName"] != null)
			{
				model.Attachment3FileName = row["Attachment3FileName"].ToString();
			}
			if (row["Attachment4FileName"] != null)
			{
				model.Attachment4FileName = row["Attachment4FileName"].ToString();
			}
			if (row["Attachment5FileName"] != null)
			{
				model.Attachment5FileName = row["Attachment5FileName"].ToString();
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
		strSql.Append("select ID,RFQNum,VendorID,Attachment1,Attachment2,Attachment3,Attachment4,Attachment5,Password1,Password2,Password3,Password4,Password5,Attachment1FileName,Attachment2FileName,Attachment3FileName,Attachment4FileName,Attachment5FileName,CreateDate ");
		strSql.Append(" FROM ps_epicor_rfq_attachment ");
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
		strSql.Append(" ID,RFQNum,VendorID,Attachment1,Attachment2,Attachment3,Attachment4,Attachment5,Password1,Password2,Password3,Password4,Password5,Attachment1FileName,Attachment2FileName,Attachment3FileName,Attachment4FileName,Attachment5FileName,CreateDate ");
		strSql.Append(" FROM ps_epicor_rfq_attachment ");
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
		strSql.Append("select count(1) FROM ps_epicor_rfq_attachment ");
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
		strSql.Append(")AS Row, T.*  from ps_epicor_rfq_attachment T ");
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
		parameters[0].Value = "ps_epicor_rfq_attachment";
		parameters[1].Value = "ID";
		parameters[2].Value = PageSize;
		parameters[3].Value = PageIndex;
		parameters[4].Value = 0;
		parameters[5].Value = 0;
		parameters[6].Value = strWhere;	
		return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
	}*/

	#endregion  BasicMethod
	#region  ExtensionMethod

	#endregion  ExtensionMethod
}
