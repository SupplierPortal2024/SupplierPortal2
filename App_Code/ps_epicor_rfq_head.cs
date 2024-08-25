using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ps_epicor_rfq_vendorprice
/// </summary>
public class ps_epicor_rfq_head
{
	public ps_epicor_rfq_head()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	#region Model
	public int ID { set; get; }

	public string RFQHead_Company { set; get; }

	public string RFQHead_OpenRFQ { set; get; }

	public string RFQHead_RFQNum { set; get; }

	public DateTime? RFQHead_PostDate { set; get; }

	public DateTime? RFQHead_RFQDueDate { set; get; }

	public string RFQHead_DueTime_c { set; get; }

	public string RFQHead_RptSubject_c { set; get; }

	public string RFQHead_CommentText { set; get; }
	public string RFQHead_DueTime_DelayMin_c { set; get; }
	

	public string Attachment1 { set; get; }
	public string Attachment2 { set; get; }
	public string Attachment3 { set; get; }
	public string Attachment4 { set; get; }
	public string Attachment5 { set; get; }

	public DateTime? CreateDate { set; get; }

	public DateTime? ModifyDate { set; get; }
	#endregion Model
	#region  BasicMethod
	/// <summary>
	/// 增加一条数据
	/// </summary>
	public bool Add(ps_epicor_rfq_head model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("insert into ps_epicor_rfq_head(");
		strSql.Append("RFQHead_Company,RFQHead_OpenRFQ,RFQHead_RFQNum,RFQHead_PostDate,RFQHead_RFQDueDate,RFQHead_DueTime_c,RFQHead_RptSubject_c,RFQHead_CommentText,CreateDate,ModifyDate,RFQHead_DueTime_DelayMin_c)");
		strSql.Append(" select ");
		strSql.Append(" @RFQHead_Company,@RFQHead_OpenRFQ,@RFQHead_RFQNum,@RFQHead_PostDate,@RFQHead_RFQDueDate,@RFQHead_DueTime_c,@RFQHead_RptSubject_c,@RFQHead_CommentText,@CreateDate,@ModifyDate,@RFQHead_DueTime_DelayMin_c ");
		strSql.Append(" WHERE @RFQHead_RFQNum not in (select RFQHead_RFQNum from ps_epicor_rfq_head)");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@RFQHead_Company", SqlDbType.NChar,10),
					new SqlParameter("@RFQHead_OpenRFQ", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_RFQNum", SqlDbType.NVarChar,200),
					new SqlParameter("@RFQHead_PostDate", SqlDbType.DateTime),
					new SqlParameter("@RFQHead_RFQDueDate", SqlDbType.DateTime),
					new SqlParameter("@RFQHead_DueTime_c", SqlDbType.NVarChar,20),
					new SqlParameter("@RFQHead_RptSubject_c", SqlDbType.NVarChar,500),
					new SqlParameter("@RFQHead_CommentText", SqlDbType.NVarChar,500),
					new SqlParameter("@RFQHead_DueTime_DelayMin_c", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ModifyDate", SqlDbType.DateTime)};
		parameters[0].Value = model.ID;
		parameters[1].Value = model.RFQHead_Company;
		parameters[2].Value = model.RFQHead_OpenRFQ;
		parameters[3].Value = model.RFQHead_RFQNum;
		parameters[4].Value = model.RFQHead_PostDate;
		parameters[5].Value = model.RFQHead_RFQDueDate;
		parameters[6].Value = model.RFQHead_DueTime_c;
		parameters[7].Value = model.RFQHead_RptSubject_c;
		parameters[8].Value = model.RFQHead_CommentText;
		parameters[9].Value = model.RFQHead_DueTime_DelayMin_c;
		parameters[10].Value = model.CreateDate;
		parameters[11].Value = model.ModifyDate;

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
	public bool Update(ps_epicor_rfq_head model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_rfq_head set ");
		strSql.Append("RFQHead_Company=@RFQHead_Company,");
		strSql.Append("RFQHead_OpenRFQ=@RFQHead_OpenRFQ,");
		strSql.Append("RFQHead_RFQNum=@RFQHead_RFQNum,");
		strSql.Append("RFQHead_PostDate=@RFQHead_PostDate,");
		strSql.Append("RFQHead_RFQDueDate=@RFQHead_RFQDueDate,");
		strSql.Append("RFQHead_DueTime_c=@RFQHead_DueTime_c,");
		strSql.Append("RFQHead_RptSubject_c=@RFQHead_RptSubject_c,");
		strSql.Append("RFQHead_CommentText=@RFQHead_CommentText,");
		strSql.Append("RFQHead_DueTime_DelayMin_c=@RFQHead_DueTime_DelayMin_c,");
		
		strSql.Append("ModifyDate=getdate()");
		strSql.Append(" where RFQHead_RFQNum=@RFQHead_RFQNum");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@RFQHead_Company", SqlDbType.NChar,10),
					new SqlParameter("@RFQHead_OpenRFQ", SqlDbType.NVarChar,50),
					new SqlParameter("@RFQHead_RFQNum", SqlDbType.NVarChar,200),
					new SqlParameter("@RFQHead_PostDate", SqlDbType.DateTime),
					new SqlParameter("@RFQHead_RFQDueDate", SqlDbType.DateTime),
					new SqlParameter("@RFQHead_DueTime_c", SqlDbType.NVarChar,20),
					new SqlParameter("@RFQHead_RptSubject_c", SqlDbType.NVarChar,500),
					new SqlParameter("@RFQHead_CommentText", SqlDbType.NVarChar,500),
					new SqlParameter("@RFQHead_DueTime_DelayMin_c", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ModifyDate", SqlDbType.DateTime)};
		parameters[0].Value = model.ID;
		parameters[1].Value = model.RFQHead_Company;
		parameters[2].Value = model.RFQHead_OpenRFQ;
		parameters[3].Value = model.RFQHead_RFQNum;
		parameters[4].Value = model.RFQHead_PostDate;
		parameters[5].Value = model.RFQHead_RFQDueDate;
		parameters[6].Value = model.RFQHead_DueTime_c;
		parameters[7].Value = model.RFQHead_RptSubject_c;
		parameters[8].Value = model.RFQHead_CommentText;
		parameters[9].Value = model.RFQHead_DueTime_DelayMin_c;
		parameters[10].Value = model.CreateDate;
		parameters[11].Value = model.ModifyDate;

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
	/// 是否存在该记录
	/// </summary>
	public bool RFQAttachmentExists(string RfqNumber, string VendorID)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select count(1) from [ps_epicor_rfq_attachment]");
		strSql.Append(" where RFQNum=@RFQNum ");
		strSql.Append(" and VendorID=@VendorID ");

		SqlParameter[] parameters = {
					new SqlParameter("@RFQNum", SqlDbType.NVarChar,50),
					new SqlParameter("@VendorID", SqlDbType.NVarChar,200)};
		parameters[0].Value = RfqNumber;
		parameters[1].Value = VendorID;

		return DbHelperSQL.Exists(strSql.ToString(), parameters);
	}

	/// <summary>
	/// 增加一条数据
	/// </summary>
	public bool AddRFQAttachment(string RfqNumber, string VendorID)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("insert into ps_epicor_rfq_attachment(");
		strSql.Append("RFQNum,VendorID)");
		strSql.Append(" select ");
		strSql.Append(" @RFQNum,@VendorID ");
		strSql.Append(" where (select count(1) from ps_epicor_rfq_attachment where RFQNum =@RFQNum and VendorID=@VendorID)=0 ");
		//strSql.Append(" WHERE @RFQHead_RFQNum not in (select RFQHead_RFQNum from ps_epicor_rfq_head)");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
					new SqlParameter("@RFQNum", SqlDbType.NVarChar,50),
					new SqlParameter("@VendorID", SqlDbType.NVarChar,200)};
		parameters[0].Value = RfqNumber;
		parameters[1].Value = VendorID;
		

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

	// <summary>
	//Update一条数据
	/// </summary>
	public bool UpdateRFQAttachment1(string RfqNumber, string VendorID, string Line, string FileName, Byte[] FileData, string Password)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_rfq_attachment");
		strSql.Append(" set Attachment1FileName=@Attachment1FileName,");
		strSql.Append(" Attachment1=@Attachment1, ");
		strSql.Append(" Password1=@Password1 ");
		strSql.Append(" where RFQNum=@RFQNum ");
		strSql.Append(" and VendorID=@VendorID ");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
					new SqlParameter("@RFQNum", SqlDbType.NVarChar,50),
					new SqlParameter("@VendorID", SqlDbType.NVarChar,200),
					new SqlParameter("@Attachment1FileName", SqlDbType.NVarChar,200),
					new SqlParameter("@Attachment1", SqlDbType.Binary),
					new SqlParameter("@Password1", SqlDbType.NVarChar,200),};
		parameters[0].Value = RfqNumber;
		parameters[1].Value = VendorID;
		parameters[2].Value = FileName;
		parameters[3].Value = FileData;
		parameters[4].Value = Password;


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
	// <summary>
	//Update一条数据
	/// </summary>
	public bool UpdateRFQAttachment2(string RfqNumber, string VendorID, string Line, string FileName, Byte[] FileData, string Password)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_rfq_attachment");
		strSql.Append(" set Attachment2FileName=@Attachment2FileName,");
		strSql.Append(" Attachment2=@Attachment2, ");
		strSql.Append(" Password2=@Password2 ");
		strSql.Append(" where RFQNum=@RFQNum ");
		strSql.Append(" and VendorID=@VendorID ");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
					new SqlParameter("@RFQNum", SqlDbType.NVarChar,50),
					new SqlParameter("@VendorID", SqlDbType.NVarChar,200),
					new SqlParameter("@Attachment2FileName", SqlDbType.NVarChar,200),
					new SqlParameter("@Attachment2", SqlDbType.Binary),
					new SqlParameter("@Password2", SqlDbType.NVarChar,200),};
		parameters[0].Value = RfqNumber;
		parameters[1].Value = VendorID;
		parameters[2].Value = FileName;
		parameters[3].Value = FileData;
		parameters[4].Value = Password;


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
	//Update一条数据
	/// </summary>
	public bool UpdateRFQAttachment3(string RfqNumber, string VendorID, string Line, string FileName, Byte[] FileData, string Password)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_rfq_attachment");
		strSql.Append(" set Attachment3FileName=@Attachment3FileName,");
		strSql.Append(" Attachment3=@Attachment3, ");
		strSql.Append(" Password3=@Password3 ");
		strSql.Append(" where RFQNum=@RFQNum ");
		strSql.Append(" and VendorID=@VendorID ");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
					new SqlParameter("@RFQNum", SqlDbType.NVarChar,50),
					new SqlParameter("@VendorID", SqlDbType.NVarChar,200),
					new SqlParameter("@Attachment3FileName", SqlDbType.NVarChar,200),
					new SqlParameter("@Attachment3", SqlDbType.Binary),
					new SqlParameter("@Password3", SqlDbType.NVarChar,200),};
		parameters[0].Value = RfqNumber;
		parameters[1].Value = VendorID;
		parameters[2].Value = FileName;
		parameters[3].Value = FileData;
		parameters[4].Value = Password;


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



	



	


	public bool UpdateAttachment(ps_epicor_rfq_head model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_rfq_head set ");
		strSql.Append("Attachment1=@Attachment1,");
		strSql.Append("Attachment2=@Attachment2,");
		strSql.Append("Attachment3=@Attachment3,");
		strSql.Append("Attachment4=@Attachment4,");
		strSql.Append("Attachment5=@Attachment5,");
		strSql.Append("ModifyDate=getdate()");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Attachment1", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment2", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment3", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment4", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment5", SqlDbType.NVarChar,500)};
		parameters[0].Value = model.ID;
		parameters[1].Value = model.Attachment1;
		parameters[2].Value = model.Attachment2;
		parameters[3].Value = model.Attachment3;
		parameters[4].Value = model.Attachment4;
		parameters[5].Value = model.Attachment5;

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

	public bool UpdateAttachmentPassword(ps_epicor_rfq_head model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_rfq_head set ");
		strSql.Append("Attachment1=@Attachment1,");
		strSql.Append("Attachment2=@Attachment2,");
		strSql.Append("Attachment3=@Attachment3,");
		strSql.Append("Attachment4=@Attachment4,");
		strSql.Append("Attachment5=@Attachment5,");
		strSql.Append("ModifyDate=getdate()");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Attachment1", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment2", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment3", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment4", SqlDbType.NVarChar,500),
					new SqlParameter("@Attachment5", SqlDbType.NVarChar,500)};
		parameters[0].Value = model.ID;
		parameters[1].Value = model.Attachment1;
		parameters[2].Value = model.Attachment2;
		parameters[3].Value = model.Attachment3;
		parameters[4].Value = model.Attachment4;
		parameters[5].Value = model.Attachment5;

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
	public bool Delete()
	{
		//该表无主键信息，请自定义主键/条件字段
		StringBuilder strSql = new StringBuilder();
		strSql.Append("delete from ps_epicor_rfq_head ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
			};

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
	/// 得到一个对象实体
	/// </summary>
	public ps_epicor_rfq_head GetModel(int ID)
	{
		//该表无主键信息，请自定义主键/条件字段
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select  top 1 ID,RFQHead_Company,RFQHead_OpenRFQ,RFQHead_RFQNum,RFQHead_PostDate,RFQHead_RFQDueDate,RFQHead_DueTime_c,RFQHead_RptSubject_c,RFQHead_CommentText,CreateDate,ModifyDate,Attachment1,Attachment2,Attachment3,Attachment4,Attachment5 from ps_epicor_rfq_head ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
		parameters[0].Value = ID;

		ps_epicor_rfq_head model = new ps_epicor_rfq_head();
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
	public ps_epicor_rfq_head GetModelByRFQNum(string RFQNum)
	{
		//该表无主键信息，请自定义主键/条件字段
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select  top 1 * from ps_epicor_rfq_head ");
		strSql.Append(" where RFQHead_RFQNum=@RFQHead_RFQNum");
		SqlParameter[] parameters = {
					new SqlParameter("@RFQHead_RFQNum", SqlDbType.NVarChar,200)
			};
		parameters[0].Value = RFQNum;

		ps_epicor_rfq_head model = new ps_epicor_rfq_head();
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
	public ps_epicor_rfq_head DataRowToModel(DataRow row)
	{
		ps_epicor_rfq_head model = new ps_epicor_rfq_head();
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
			if (row["RFQHead_PostDate"] != null && row["RFQHead_PostDate"].ToString() != "")
			{
				model.RFQHead_PostDate = DateTime.Parse(row["RFQHead_PostDate"].ToString());
			}
			if (row["RFQHead_RFQDueDate"] != null && row["RFQHead_RFQDueDate"].ToString() != "")
			{
				model.RFQHead_RFQDueDate = DateTime.Parse(row["RFQHead_RFQDueDate"].ToString());
			}
			if (row["RFQHead_DueTime_c"] != null)
			{
				model.RFQHead_DueTime_c = row["RFQHead_DueTime_c"].ToString();
			}
			if (row["RFQHead_RptSubject_c"] != null)
			{
				model.RFQHead_RptSubject_c = row["RFQHead_RptSubject_c"].ToString();
			}
			if (row["RFQHead_CommentText"] != null)
			{
				model.RFQHead_CommentText = row["RFQHead_CommentText"].ToString();
			}
			if (row["RFQHead_DueTime_DelayMin_c"] != null)
			{
				model.RFQHead_DueTime_DelayMin_c = row["RFQHead_DueTime_DelayMin_c"].ToString();
			}

			if (row["Attachment1"] != null)
			{
				model.Attachment1 = row["Attachment1"].ToString();
			}
			if (row["Attachment2"] != null)
			{
				model.Attachment2 = row["Attachment2"].ToString();
			}
			if (row["Attachment3"] != null)
			{
				model.Attachment3 = row["Attachment3"].ToString();
			}
			if (row["Attachment4"] != null)
			{
				model.Attachment4 = row["Attachment4"].ToString();
			}
			if (row["Attachment5"] != null)
			{
				model.Attachment4 = row["Attachment4"].ToString();
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
		strSql.Append("select ID,RFQHead_Company,RFQHead_OpenRFQ,RFQHead_RFQNum,RFQHead_PostDate,RFQHead_RFQDueDate,RFQHead_DueTime_c,RFQHead_RptSubject_c,RFQHead_CommentText,CreateDate,ModifyDate ");
		strSql.Append(" FROM ps_epicor_rfq_head ");
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
		strSql.Append(" ID,RFQHead_Company,RFQHead_OpenRFQ,RFQHead_RFQNum,RFQHead_PostDate,RFQHead_RFQDueDate,RFQHead_DueTime_c,RFQHead_RptSubject_c,RFQHead_CommentText,CreateDate,ModifyDate ");
		strSql.Append(" FROM ps_epicor_rfq_head ");
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
		strSql.Append("select count(1) FROM ps_epicor_rfq_head ");
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
		strSql.Append(")AS Row, T.*  from ps_epicor_rfq_head T ");
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
