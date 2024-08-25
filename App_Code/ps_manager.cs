using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 用户信息-类
	/// </summary>
	[Serializable]
	public partial class ps_manager
	{
		public ps_manager()
		{}
        #region Model
        private int _id;
        private int _role_id = 0;
        private string _user_name;
        private string _password;
        private string _company;
        private string _real_name = "";
        private string _mobile = "";
        private string _emailaddress = "";
        private string _remark = "";
        private int? _is_lock = 1;
        private DateTime? _add_time = DateTime.Now;
        private int? _depot_id = 0;
        private int? _depot_category_id = 0;
        private string _vendor_id = "";
        private int? _is_displayprice = 1;
        private string _customersupportid = "";
        private string _customersupporturl = "";

        private string _address = "";
        private string _position = "";


    /// <summary>
    /// 
    /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 角色id
        /// </summary>
        public int role_id
        {
            set { _role_id = value; }
            get { return _role_id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }

        public string company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// MD5加密密码
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string real_name
        {
            set { _real_name = value; }
            get { return _real_name; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }

        public string emailaddress
        {
            set { _emailaddress = value; }
            get { return _emailaddress; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public int? is_lock
        {
            set { _is_lock = value; }
            get { return _is_lock; }
        }
        /// <summary>
        /// 增加时间
        /// </summary>
        public DateTime? add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        /// <summary>
        /// 商家ID
        /// </summary>
        public int? depot_id
        {
            set { _depot_id = value; }
            get { return _depot_id; }
        }
        /// <summary>
        /// 地区d
        /// </summary>
        public int? depot_category_id
        {
            set { _depot_category_id = value; }
            get { return _depot_category_id; }
        }
        public string vendor_id
        {
            set { _vendor_id = value; }
            get { return _vendor_id; }
        }

        public int? is_displayprice
        {
            set { _is_displayprice = value; }
            get { return _is_displayprice; }
        }

        public string customersupportid
        {
            set { _customersupportid = value; }
            get { return _customersupportid; }
        }

        public string customersupporturl
        {
            set { _customersupporturl = value; }
            get { return _customersupporturl; }
        }

        public string position
        {
            set { _position = value; }
            get { return _position; }
        }

        public string address
        {
            set { _address = value; }
            get { return _address; }
        }




    #endregion Model


    #region  Method

    /// <summary>
    /// 是否存在该记录
    /// </summary>
    public bool Exists(int id)
	{
		StringBuilder strSql=new StringBuilder();
		strSql.Append("select count(1) from [ps_manager]");
		strSql.Append(" where id=@id ");

		SqlParameter[] parameters = {
				new SqlParameter("@id", SqlDbType.Int,4)};
		parameters[0].Value = id;

		return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 查询用户名-账号是否存在
        /// </summary>
        public bool Exists(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  ps_manager");
            strSql.Append(" where user_name=@user_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100)};
            parameters[0].Value = user_name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在商家d记录
        /// </summary>
        public bool ExistsMD()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [ps_manager]");
            strSql.Append(" where depot_id=@depot_id ");

            SqlParameter[] parameters = {
					new SqlParameter("@depot_id", SqlDbType.Int,4)};
            parameters[0].Value = depot_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 排除自己查询用户名-账号是否存在
        /// </summary>
        public bool ExistsE(string user_name,int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  ps_manager");
            strSql.Append(" where user_name=@user_name and  id<>@id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = user_name;
            parameters[1].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回用户名
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 user_name from [ps_manager]");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }
        /// <summary>
        /// 返回用户姓名
        /// </summary>
        public string GetName(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 real_name from [ps_manager]");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into [ps_manager] (");
			strSql.Append("role_id,user_name,password,real_name,mobile,remark,is_lock,add_time,depot_id,depot_category_id,vendor_id,emailaddress,is_displayprice,customersupportid,address,position,company)");
			strSql.Append(" values (");
			strSql.Append("@role_id,@user_name,@password,@real_name,@mobile,@remark,@is_lock,@add_time,@depot_id,@depot_category_id,@vendor_id,@emailaddress,@is_displayprice,@customersupportid,@address,@position,@company)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@role_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@password", SqlDbType.NVarChar,100),
					new SqlParameter("@real_name", SqlDbType.NVarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,20),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@is_lock", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@depot_category_id", SqlDbType.Int,4),
                    new SqlParameter("@vendor_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@emailaddress", SqlDbType.VarChar,200),
                    new SqlParameter("@is_displayprice", SqlDbType.Int,4),
                    new SqlParameter("@address", SqlDbType.VarChar,200),
                    new SqlParameter("@position", SqlDbType.VarChar,200),
                    new SqlParameter("@company", SqlDbType.VarChar,200),
                    new SqlParameter("@customersupportid", SqlDbType.VarChar,50)};
			parameters[0].Value = role_id;
			parameters[1].Value = user_name;
			parameters[2].Value = password;
			parameters[3].Value = real_name;
			parameters[4].Value = mobile;
			parameters[5].Value = remark;
			parameters[6].Value = is_lock;
			parameters[7].Value = add_time;
			parameters[8].Value = depot_id;
			parameters[9].Value = depot_category_id;
            parameters[10].Value = vendor_id;
            parameters[11].Value = emailaddress;
            parameters[12].Value = is_displayprice;
            parameters[13].Value = address;
            parameters[14].Value = position;
            parameters[15].Value = company;
            parameters[16].Value = customersupportid;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update [ps_manager] set ");
			strSql.Append("role_id=@role_id,");
			strSql.Append("user_name=@user_name,");
			strSql.Append("password=@password,");
			strSql.Append("real_name=@real_name,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("remark=@remark,");
			strSql.Append("is_lock=@is_lock,");
            //strSql.Append("add_time=@add_time,");
			strSql.Append("depot_id=@depot_id,");
			strSql.Append("depot_category_id=@depot_category_id,");
            strSql.Append("vendor_id=@vendor_id,");
            strSql.Append("emailaddress=@emailaddress,");
            strSql.Append("is_displayprice=@is_displayprice, ");
            strSql.Append("customersupportid=@customersupportid ,");
            strSql.Append("address=@address ,");
            strSql.Append("company=@company ,");
            strSql.Append("position=@position");
            strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@role_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@password", SqlDbType.NVarChar,100),
					new SqlParameter("@real_name", SqlDbType.NVarChar,50),
					new SqlParameter("@mobile", SqlDbType.VarChar,20),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@is_lock", SqlDbType.Int,4),
                    //new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@depot_id", SqlDbType.Int,4),
					new SqlParameter("@depot_category_id", SqlDbType.Int,4),
                    new SqlParameter("@vendor_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@emailaddress",SqlDbType.NVarChar,200),
                    new SqlParameter("@is_displayprice", SqlDbType.Int,4),
                    new SqlParameter("@customersupportid", SqlDbType.NVarChar,50),
                    new SqlParameter("@address", SqlDbType.NVarChar,500),
                    new SqlParameter("@position", SqlDbType.NVarChar,500),
                    new SqlParameter("@company", SqlDbType.NVarChar,500),
                    new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = role_id;
			parameters[1].Value = user_name;
			parameters[2].Value = password;
			parameters[3].Value = real_name;
			parameters[4].Value = mobile;
			parameters[5].Value = remark;
			parameters[6].Value = is_lock;
            //parameters[7].Value = add_time;
			parameters[7].Value = depot_id;
			parameters[8].Value = depot_category_id;
            parameters[9].Value = vendor_id;
            parameters[10].Value = emailaddress;
            parameters[11].Value = is_displayprice;
            parameters[12].Value = customersupportid;
            parameters[13].Value = address;
            parameters[14].Value = position;
            parameters[15].Value = company;
            parameters[16].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        /// 修改个人信息
        /// </summary>
        public bool UpdateMY()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ps_manager] set ");
            strSql.Append("password=@password,");
            strSql.Append("mobile=@mobile");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {

					new SqlParameter("@password", SqlDbType.NVarChar,100),
                    new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4)};

            parameters[0].Value = password;
            parameters[1].Value = mobile;
            parameters[2].Value = id;

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
		public bool Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from [ps_manager] ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public void GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,role_id,user_name,password,real_name,mobile,remark,is_lock,add_time,depot_id,depot_category_id,vendor_id,emailaddress,is_displayprice,customersupportid,customersupporturl,address,position,company ");
			strSql.Append(" FROM [v_Manager] ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					this.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["role_id"]!=null && ds.Tables[0].Rows[0]["role_id"].ToString()!="")
				{
					this.role_id=int.Parse(ds.Tables[0].Rows[0]["role_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["user_name"]!=null )
				{
					this.user_name=ds.Tables[0].Rows[0]["user_name"].ToString();
				}
                if (ds.Tables[0].Rows[0]["company"] != null)
                {
                    this.company = ds.Tables[0].Rows[0]["company"].ToString();
                }
                if (ds.Tables[0].Rows[0]["password"]!=null )
				{
					this.password=ds.Tables[0].Rows[0]["password"].ToString();
				}
				if(ds.Tables[0].Rows[0]["real_name"]!=null )
				{
					this.real_name=ds.Tables[0].Rows[0]["real_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["mobile"]!=null )
				{
					this.mobile=ds.Tables[0].Rows[0]["mobile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["remark"]!=null )
				{
					this.remark=ds.Tables[0].Rows[0]["remark"].ToString();
				}
				if(ds.Tables[0].Rows[0]["is_lock"]!=null && ds.Tables[0].Rows[0]["is_lock"].ToString()!="")
				{
					this.is_lock=int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
				}
				if(ds.Tables[0].Rows[0]["add_time"]!=null && ds.Tables[0].Rows[0]["add_time"].ToString()!="")
				{
					this.add_time=DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["depot_id"]!=null && ds.Tables[0].Rows[0]["depot_id"].ToString()!="")
				{
					this.depot_id=int.Parse(ds.Tables[0].Rows[0]["depot_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["depot_category_id"]!=null && ds.Tables[0].Rows[0]["depot_category_id"].ToString()!="")
				{
					this.depot_category_id=int.Parse(ds.Tables[0].Rows[0]["depot_category_id"].ToString());
				}
                if (ds.Tables[0].Rows[0]["vendor_id"] != null)
                {
                    this.vendor_id = ds.Tables[0].Rows[0]["vendor_id"].ToString();
                }
    
            
                if (ds.Tables[0].Rows[0]["emailaddress"] != null)
                {
                    this.emailaddress = ds.Tables[0].Rows[0]["emailaddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["is_displayprice"] != null && ds.Tables[0].Rows[0]["is_displayprice"].ToString() != "")
                {
                    this.is_displayprice = int.Parse(ds.Tables[0].Rows[0]["is_displayprice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["customersupportid"] != null && ds.Tables[0].Rows[0]["customersupportid"].ToString() != "")
                {
                    this.customersupportid = ds.Tables[0].Rows[0]["customersupportid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["customersupporturl"] != null && ds.Tables[0].Rows[0]["customersupporturl"].ToString() != "")
                {
                    this.customersupporturl = ds.Tables[0].Rows[0]["customersupporturl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null && ds.Tables[0].Rows[0]["address"].ToString() != "")
                {
                    this.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["position"] != null && ds.Tables[0].Rows[0]["position"].ToString() != "")
                {
                    this.position = ds.Tables[0].Rows[0]["position"].ToString();
                }


        }
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [ps_manager] ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetManagerVendorList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [v_Manager_Vendor] ");
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
            strSql.Append(" FROM  ps_manager");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM  ps_manager");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
		#endregion  Method
	}


