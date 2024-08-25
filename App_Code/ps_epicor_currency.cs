using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


/// <summary>
/// 数据访问类:ps_epicor_currency
/// </summary>
public partial class ps_epicor_currency
{
	public ps_epicor_currency()
	{ }
	#region  BasicMethod
	#region Model

	/// 
	/// </summary>
	public int ID { set; get; }
	public string Currency_Company { set; get; }
	public string Currency_CurrencyCode { set; get; }
	public string Currency_CurrDesc { set; get; }


	#endregion Model


	/// <summary>
	/// 增加一条数据
	/// </summary>
	public int Add()
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("insert into ps_epicor_currency(");
		strSql.Append("Currency_Company,Currency_CurrencyCode,Currency_CurrDesc)");
		strSql.Append(" values (");
		strSql.Append("@Currency_Company,@Currency_CurrencyCode,@Currency_CurrDesc)");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
				new SqlParameter("@Currency_Company", SqlDbType.NVarChar,50),
				new SqlParameter("@Currency_CurrencyCode", SqlDbType.NVarChar,50),
				new SqlParameter("@Currency_CurrDesc", SqlDbType.NVarChar,200)};
		parameters[0].Value = Currency_Company;
		parameters[1].Value = Currency_CurrencyCode;
		parameters[2].Value = Currency_CurrDesc;


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
	/// 删除一条数据
	/// </summary>
	public bool Delete(int ID)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("delete from ps_epicor_currency ");
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
		strSql.Append("delete from ps_epicor_currency ");
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
	/// 批量删除数据
	/// </summary>
	public bool DeleteAll()
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("delete from ps_epicor_currency ");
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
	public ps_epicor_currency GetModel(int ID)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("select  top 1 * from ps_epicor_currency ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
				new SqlParameter("@ID", SqlDbType.Int,4)
		};
		parameters[0].Value = ID;

		ps_epicor_currency model = new ps_epicor_currency();
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
	public ps_epicor_currency DataRowToModel(DataRow row)
	{
		ps_epicor_currency model = new ps_epicor_currency();
		if (row != null)
		{
			if (row["ID"] != null && row["ID"].ToString() != "")
			{
				ID = int.Parse(row["ID"].ToString());
			}
			if (row["Currency_Company"] != null)
			{
				Currency_Company = row["Currency_Company"].ToString();
			}
			if (row["Currency_CurrencyCode"] != null)
			{
				Currency_CurrencyCode = row["Currency_CurrencyCode"].ToString();
			}
			if (row["Currency_CurrDesc"] != null)
			{
				Currency_CurrDesc = row["Currency_CurrDesc"].ToString();
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
		strSql.Append("select * ");
		strSql.Append(" FROM ps_epicor_currency ");
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
		strSql.Append(" * ");
		strSql.Append(" FROM ps_epicor_currency ");
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
		strSql.Append("select count(1) FROM ps_epicor_currency ");
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
		strSql.Append(")AS Row, T.*  from ps_epicor_currency T ");
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
		strSql.Append("select * FROM  ps_epicor_currency");
		if (strWhere.Trim() != "")
		{
			strSql.Append(" where " + strWhere);
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
		parameters[0].Value = "ps_epicor_currency";
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
