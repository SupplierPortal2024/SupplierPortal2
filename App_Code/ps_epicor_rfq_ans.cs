
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ps_epicor_rfq_vendorprice
/// </summary>
public class ps_epicor_rfq_ans
{
	public ps_epicor_rfq_ans()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	#region Model
	public int ID { set; get; }

	public string UD34_Company { set; get; }

	public string UD34_Key1 { set; get; }

	public string UD34_Key2 { set; get; }

	public string UD34_Key3 { set; get; }

	public string UD34_Key4 { set; get; }

	public string UD34_Key5 { set; get; }

	public string UD34_RFQQNA_SeqNum_c { set; get; }

	public string UD34_RFQQNA_Question_c { set; get; }

	public string UD34_RFQQNA_Answer_c { set; get; }

	public DateTime? CreateDate { set; get; }

	public DateTime? ModifyDate { set; get; }
	#endregion Model
	#region  BasicMethod
	/// <summary>
	/// 增加一条数据
	/// </summary>
	public bool Add(ps_epicor_rfq_ans model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("insert into ps_epicor_rfq_ans(");
		strSql.Append("UD34_Company,UD34_Key1,UD34_Key2,UD34_Key3,UD34_Key4,UD34_Key5,UD34_RFQQNA_SeqNum_c,UD34_RFQQNA_Question_c,UD34_RFQQNA_Answer_c,CreateDate,ModifyDate)");
		strSql.Append(" select ");
		strSql.Append("@UD34_Company,@UD34_Key1,@UD34_Key2,@UD34_Key3,@UD34_Key4,@UD34_Key5,@UD34_RFQQNA_SeqNum_c,@UD34_RFQQNA_Question_c,@UD34_RFQQNA_Answer_c,@CreateDate,@ModifyDate");
		strSql.Append(" WHERE @UD34_Key1 + '-' + cast(@UD34_Key3 as nvarchar) + '-' +  cast(@UD34_Key5 as nvarchar) not in (select UD34_Key1 + '-' + cast(UD34_Key3 as nvarchar) + '-' + cast(UD34_Key5 as nvarchar)  from ps_epicor_rfq_ans)");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
					new SqlParameter("@UD34_Company", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_Key1", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_Key2", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_Key3", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_Key4", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_Key5", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_RFQQNA_SeqNum_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_RFQQNA_Question_c", SqlDbType.NVarChar,500),
					new SqlParameter("@UD34_RFQQNA_Answer_c", SqlDbType.NVarChar,2000),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ModifyDate", SqlDbType.DateTime)};
		parameters[0].Value = model.UD34_Company;
		parameters[1].Value = model.UD34_Key1;
		parameters[2].Value = model.UD34_Key2;
		parameters[3].Value = model.UD34_Key3;
		parameters[4].Value = model.UD34_Key4;
		parameters[5].Value = model.UD34_Key5;
		parameters[6].Value = model.UD34_RFQQNA_SeqNum_c;
		parameters[7].Value = model.UD34_RFQQNA_Question_c;
		parameters[8].Value = model.UD34_RFQQNA_Answer_c;
		parameters[9].Value = model.CreateDate;
		parameters[10].Value = model.ModifyDate;

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
	public bool Update(ps_epicor_rfq_ans model)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_rfq_ans set ");
		strSql.Append("UD34_Company=@UD34_Company,");
		strSql.Append("UD34_Key1=@UD34_Key1,");
		strSql.Append("UD34_Key2=@UD34_Key2,");
		strSql.Append("UD34_Key3=@UD34_Key3,");
		strSql.Append("UD34_Key4=@UD34_Key4,");
		strSql.Append("UD34_Key5=@UD34_Key5,");
		strSql.Append("UD34_RFQQNA_SeqNum_c=@UD34_RFQQNA_SeqNum_c,");
		strSql.Append("UD34_RFQQNA_Question_c=@UD34_RFQQNA_Question_c,");
		strSql.Append("UD34_RFQQNA_Answer_c=@UD34_RFQQNA_Answer_c,");
		strSql.Append("CreateDate=@CreateDate,");
		strSql.Append("ModifyDate=getdate()");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UD34_Company", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_Key1", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_Key2", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_Key3", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_Key4", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_Key5", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_RFQQNA_SeqNum_c", SqlDbType.NVarChar,200),
					new SqlParameter("@UD34_RFQQNA_Question_c", SqlDbType.NVarChar,500),
					new SqlParameter("@UD34_RFQQNA_Answer_c", SqlDbType.NVarChar,2000),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ModifyDate", SqlDbType.DateTime)};
		parameters[0].Value = model.ID;
		parameters[1].Value = model.UD34_Company;
		parameters[2].Value = model.UD34_Key1;
		parameters[3].Value = model.UD34_Key2;
		parameters[4].Value = model.UD34_Key3;
		parameters[5].Value = model.UD34_Key4;
		parameters[6].Value = model.UD34_Key5;
		parameters[7].Value = model.UD34_RFQQNA_SeqNum_c;
		parameters[8].Value = model.UD34_RFQQNA_Question_c;
		parameters[9].Value = model.UD34_RFQQNA_Answer_c;
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
	/// 删除一条数据
	/// </summary>
	public bool Delete()
	{
		//该表无主键信息，请自定义主键/条件字段
		StringBuilder strSql = new StringBuilder();
		strSql.Append("delete from ps_epicor_rfq_ans ");
		strSql.Append(" where ");
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
	public ps_epicor_rfq_ans GetModel(int ID)
	{
		//该表无主键信息，请自定义主键/条件字段
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select  top 1 ID,UD34_Company,UD34_Key1,UD34_Key2,UD34_Key3,UD34_Key4,UD34_Key5,UD34_RFQQNA_SeqNum_c,UD34_RFQQNA_Question_c,UD34_RFQQNA_Answer_c,CreateDate,ModifyDate from ps_epicor_rfq_ans ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
		parameters[0].Value = ID;

		ps_epicor_rfq_ans model = new ps_epicor_rfq_ans();
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
	public ps_epicor_rfq_ans DataRowToModel(DataRow row)
	{
		ps_epicor_rfq_ans model = new ps_epicor_rfq_ans();
		if (row != null)
		{
			if (row["ID"] != null && row["ID"].ToString() != "")
			{
				model.ID = int.Parse(row["ID"].ToString());
			}
			if (row["UD34_Company"] != null)
			{
				model.UD34_Company = row["UD34_Company"].ToString();
			}
			if (row["UD34_Key1"] != null)
			{
				model.UD34_Key1 = row["UD34_Key1"].ToString();
			}
			if (row["UD34_Key2"] != null)
			{
				model.UD34_Key2 = row["UD34_Key2"].ToString();
			}
			if (row["UD34_Key3"] != null)
			{
				model.UD34_Key3 = row["UD34_Key3"].ToString();
			}
			if (row["UD34_Key4"] != null)
			{
				model.UD34_Key4 = row["UD34_Key4"].ToString();
			}
			if (row["UD34_Key5"] != null)
			{
				model.UD34_Key5 = row["UD34_Key5"].ToString();
			}
			if (row["UD34_RFQQNA_SeqNum_c"] != null)
			{
				model.UD34_RFQQNA_SeqNum_c = row["UD34_RFQQNA_SeqNum_c"].ToString();
			}
			if (row["UD34_RFQQNA_Question_c"] != null)
			{
				model.UD34_RFQQNA_Question_c = row["UD34_RFQQNA_Question_c"].ToString();
			}
			if (row["UD34_RFQQNA_Answer_c"] != null)
			{
				model.UD34_RFQQNA_Answer_c = row["UD34_RFQQNA_Answer_c"].ToString();
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
		strSql.Append("select ID,UD34_Company,UD34_Key1,UD34_Key2,UD34_Key3,UD34_Key4,UD34_Key5,UD34_RFQQNA_SeqNum_c,UD34_RFQQNA_Question_c,UD34_RFQQNA_Answer_c,CreateDate,ModifyDate ");
		strSql.Append(" FROM ps_epicor_rfq_ans ");
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
		strSql.Append(" ID,UD34_Company,UD34_Key1,UD34_Key2,UD34_Key3,UD34_Key4,UD34_Key5,UD34_RFQQNA_SeqNum_c,UD34_RFQQNA_Question_c,UD34_RFQQNA_Answer_c,CreateDate,ModifyDate ");
		strSql.Append(" FROM ps_epicor_rfq_ans ");
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
		strSql.Append("select count(1) FROM ps_epicor_rfq_ans ");
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
		strSql.Append(")AS Row, T.*  from ps_epicor_rfq_ans T ");
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
	public DataSet GetList2(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select * FROM  ps_epicor_rfq_ans where (id>0)");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" and " + strWhere);
		}
		recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
		return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
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
