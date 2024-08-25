
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


/// <summary>
/// 数据访问类:ps_epicor_vendor
/// </summary>
public partial class ps_epicor_vendor
{
	public ps_epicor_vendor()
	{}
	#region  BasicMethod
	#region Model
	private int _id;
	private string _vendor_company;
	private string _vendor_vendornum;
	private string _vendor_vendorid;
	private string _vendor_name;
	private string _vendor_approved;
	private string _vendor_currencycode;
	private string _vendor_termscode;
	private string _vendor_brnum_c;
	private DateTime? _vendor_brexpirydate_c;
	private string _vendor_orgregcode;
	private string _vendor_phonenum;
	private string _vendor_faxnum;
	private string _vendor_emailaddress;
	private string _vendor_address1;
	private string _vendor_address2;
	private string _vendor_address3;
	private string _vendor_city;
	private string _vendor_state;
	private string _vendor_zip;
	private string _vendor_country;
	private string _vendor_countrynum;
	private string _vendcnt_connum;
	private string _vendcnt_perconid;
	private string _vendcnt_name;
	private string _vendcnt_func;
	private string _vendcnt_phonenum;
	private string _vendcnt_cellphonenum;
	private string _vendcnt_emailaddress;
	private string _vendcnt_ud_rfqrecipent_c;
	private string _vendcnt_ud_porecipient_c;
	private string _calculated_primarycontact;
	private string _vendor_portalregsubmit_c;
	private DateTime? _vendor_portalregexpirydate_c;
	private string _vendor_portalresetpwtime_c;
	private string _vendor_portalregtemppw_c;
	private int _status;
	private DateTime _create_date;


	/// <summary>
	/// 
	/// </summary>
	public int ID
	{
		set { _id = value; }
		get { return _id; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_Company
	{
		set { _vendor_company = value; }
		get { return _vendor_company; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_VendorNum
	{
		set { _vendor_vendornum = value; }
		get { return _vendor_vendornum; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_VendorID
	{
		set { _vendor_vendorid = value; }
		get { return _vendor_vendorid; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_Name
	{
		set { _vendor_name = value; }
		get { return _vendor_name; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_Approved
	{
		set { _vendor_approved = value; }
		get { return _vendor_approved; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_CurrencyCode
	{
		set { _vendor_currencycode = value; }
		get { return _vendor_currencycode; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_TermsCode
	{
		set { _vendor_termscode = value; }
		get { return _vendor_termscode; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_BRNum_c
	{
		set { _vendor_brnum_c = value; }
		get { return _vendor_brnum_c; }
	}
	/// <summary>
	/// 
	/// </summary>
	public DateTime? Vendor_BRExpiryDate_c
	{
		set { _vendor_brexpirydate_c = value; }
		get { return _vendor_brexpirydate_c; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_OrgRegCode
	{
		set { _vendor_orgregcode = value; }
		get { return _vendor_orgregcode; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_PhoneNum
	{
		set { _vendor_phonenum = value; }
		get { return _vendor_phonenum; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_FaxNum
	{
		set { _vendor_faxnum = value; }
		get { return _vendor_faxnum; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_EMailAddress
	{
		set { _vendor_emailaddress = value; }
		get { return _vendor_emailaddress; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_Address1
	{
		set { _vendor_address1 = value; }
		get { return _vendor_address1; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_Address2
	{
		set { _vendor_address2 = value; }
		get { return _vendor_address2; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_Address3
	{
		set { _vendor_address3 = value; }
		get { return _vendor_address3; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_City
	{
		set { _vendor_city = value; }
		get { return _vendor_city; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_State
	{
		set { _vendor_state = value; }
		get { return _vendor_state; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_ZIP
	{
		set { _vendor_zip = value; }
		get { return _vendor_zip; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_Country
	{
		set { _vendor_country = value; }
		get { return _vendor_country; }
	}

	public string Vendor_CountryNum
	{
		set { _vendor_countrynum = value; }
		get { return _vendor_countrynum; }
	}
	
	/// <summary>
	/// 
	/// </summary>
	public string VendCnt_ConNum
	{
		set { _vendcnt_connum = value; }
		get { return _vendcnt_connum; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string VendCnt_PerConID
	{
		set { _vendcnt_perconid = value; }
		get { return _vendcnt_perconid; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string VendCnt_Name
	{
		set { _vendcnt_name = value; }
		get { return _vendcnt_name; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string VendCnt_Func
	{
		set { _vendcnt_func = value; }
		get { return _vendcnt_func; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string VendCnt_PhoneNum
	{
		set { _vendcnt_phonenum = value; }
		get { return _vendcnt_phonenum; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string VendCnt_CellPhoneNum
	{
		set { _vendcnt_cellphonenum = value; }
		get { return _vendcnt_cellphonenum; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string VendCnt_EmailAddress
	{
		set { _vendcnt_emailaddress = value; }
		get { return _vendcnt_emailaddress; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string VendCnt_UD_RFQRecipent_c
	{
		set { _vendcnt_ud_rfqrecipent_c = value; }
		get { return _vendcnt_ud_rfqrecipent_c; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string VendCnt_UD_PORecipient_c
	{
		set { _vendcnt_ud_porecipient_c = value; }
		get { return _vendcnt_ud_porecipient_c; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Calculated_PrimaryContact
	{
		set { _calculated_primarycontact = value; }
		get { return _calculated_primarycontact; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_PortalRegSubmit_c
	{
		set { _vendor_portalregsubmit_c = value; }
		get { return _vendor_portalregsubmit_c; }
	}
	/// <summary>
	/// 
	/// </summary>
	public DateTime? Vendor_PortalRegExpiryDate_c
	{
		set { _vendor_portalregexpirydate_c = value; }
		get { return _vendor_portalregexpirydate_c; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_PortalResetPWTime_c
	{
		set { _vendor_portalresetpwtime_c = value; }
		get { return _vendor_portalresetpwtime_c; }
	}
	/// <summary>
	/// 
	/// </summary>
	public string Vendor_PortalRegTempPW_c
	{
		set { _vendor_portalregtemppw_c = value; }
		get { return _vendor_portalregtemppw_c; }
	}
	/// <summary>
	/// 
	/// </summary>
	public DateTime Create_Date
	{
		set { _create_date = value; }
		get { return _create_date; }
	}

	public string VendorBank_BankID { set; get; }
	public string VendorBank_BankName { set; get; }
	public string VendorBank_CountryNum { set; get; }
	public string VendorBank_BankAcctNumber { set; get; }
	public string VendorBank_NameOnAccount { set; get; }
	public string VendorBank_PayMethodType { set; get; }
	public string VendorBank_SwiftNum { set; get; }
	public string VendorBank_IBANABABSBCode { set; get; }
	public int Status { set; get; }
	public string VendCnt_Inactive { set; get; }
	public string Vendor_PortalRegEmailAddress_c { set; get; }
	public string PurTerms_Description { set; get; }
	public string Vendor_Website_c { set; get; }
	



	#endregion Model


	/// <summary>
	/// 增加一条数据
	/// </summary>
	public int Add()
	{
		StringBuilder strSql=new StringBuilder();
		strSql.Append("insert into ps_epicor_vendor");
		strSql.Append("(Vendor_Company,Vendor_VendorNum,Vendor_VendorID,Vendor_Name,Vendor_Approved,Vendor_CurrencyCode,Vendor_TermsCode,Vendor_BRNum_c,Vendor_BRExpiryDate_c,Vendor_OrgRegCode,Vendor_PhoneNum,Vendor_FaxNum,Vendor_EMailAddress,Vendor_Address1,Vendor_Address2,Vendor_Address3,Vendor_City,Vendor_State,Vendor_ZIP,Vendor_Country,VendCnt_ConNum,VendCnt_PerConID,VendCnt_Name,VendCnt_Func,VendCnt_PhoneNum,VendCnt_CellPhoneNum,VendCnt_EmailAddress,VendCnt_UD_RFQRecipent_c,VendCnt_UD_PORecipient_c,Calculated_PrimaryContact,Vendor_PortalRegSubmit_c,Vendor_PortalRegExpiryDate_c,Vendor_PortalResetPWTime_c,Vendor_PortalRegTempPW_c,VendCnt_Inactive,VendorBank_BankID,VendorBank_BankName,VendorBank_CountryNum,VendorBank_BankAcctNumber,VendorBank_NameOnAccount,VendorBank_PayMethodType,VendorBank_SwiftNum,VendorBank_IBANABABSBCode,Vendor_PortalRegEmailAddress_c,PurTerms_Description,Vendor_Website_c)");
		strSql.Append(" select ");
		strSql.Append("@Vendor_Company,@Vendor_VendorNum,@Vendor_VendorID,@Vendor_Name,@Vendor_Approved,@Vendor_CurrencyCode,@Vendor_TermsCode,@Vendor_BRNum_c,@Vendor_BRExpiryDate_c,@Vendor_OrgRegCode,@Vendor_PhoneNum,@Vendor_FaxNum,@Vendor_EMailAddress,@Vendor_Address1,@Vendor_Address2,@Vendor_Address3,@Vendor_City,@Vendor_State,@Vendor_ZIP,@Vendor_Country,@VendCnt_ConNum,@VendCnt_PerConID,@VendCnt_Name,@VendCnt_Func,@VendCnt_PhoneNum,@VendCnt_CellPhoneNum,@VendCnt_EmailAddress,@VendCnt_UD_RFQRecipent_c,@VendCnt_UD_PORecipient_c,@Calculated_PrimaryContact,@Vendor_PortalRegSubmit_c,@Vendor_PortalRegExpiryDate_c,@Vendor_PortalResetPWTime_c,@Vendor_PortalRegTempPW_c,@VendCnt_Inactive,@VendorBank_BankID,@VendorBank_BankName,@VendorBank_CountryNum,@VendorBank_BankAcctNumber,@VendorBank_NameOnAccount,@VendorBank_PayMethodType,@VendorBank_SwiftNum,@VendorBank_IBANABABSBCode,@Vendor_PortalRegEmailAddress_c,@PurTerms_Description,@Vendor_Website_c ");
		strSql.Append(" WHERE @Vendor_Company + '-' + cast(@Vendor_VendorID as nvarchar)  + '-' + cast(@VendCnt_ConNum as nvarchar)not in (select Vendor_Company + '-' + cast(Vendor_VendorID as nvarchar) + '-' + cast(VendCnt_ConNum as nvarchar) from ps_epicor_vendor)");
		strSql.Append(";select @@IDENTITY");
		SqlParameter[] parameters = {
				new SqlParameter("@Vendor_Company", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_VendorNum", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Name", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_Approved", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_CurrencyCode", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_TermsCode", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_BRNum_c", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_BRExpiryDate_c", SqlDbType.DateTime),
				new SqlParameter("@Vendor_OrgRegCode", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_PhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_FaxNum", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_EMailAddress", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address1", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address2", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address3", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_City", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_State", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_ZIP", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Country", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_ConNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_PerConID", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_Name", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_Func", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_PhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_CellPhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_EmailAddress", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_UD_RFQRecipent_c", SqlDbType.NVarChar,20),
				new SqlParameter("@VendCnt_UD_PORecipient_c", SqlDbType.NVarChar,20),
				new SqlParameter("@Calculated_PrimaryContact", SqlDbType.NChar,10),
				new SqlParameter("@Vendor_PortalRegSubmit_c", SqlDbType.NChar,10),
				new SqlParameter("@Vendor_PortalRegExpiryDate_c", SqlDbType.DateTime),
				new SqlParameter("@Vendor_PortalResetPWTime_c", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_PortalRegTempPW_c", SqlDbType.NVarChar,20),
				new SqlParameter("@VendCnt_Inactive", SqlDbType.NVarChar,20),
				new SqlParameter("@VendorBank_BankID", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_BankName", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_CountryNum", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_BankAcctNumber", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_NameOnAccount", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_PayMethodType", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_SwiftNum", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_IBANABABSBCode", SqlDbType.NVarChar,500),
				new SqlParameter("@PurTerms_Description", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_PortalRegEmailAddress_c", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_Website_c", SqlDbType.NVarChar,500)};
		
		parameters[0].Value = Vendor_Company;
		parameters[1].Value = Vendor_VendorNum;
		parameters[2].Value = Vendor_VendorID;
		parameters[3].Value = Vendor_Name;
		parameters[4].Value = Vendor_Approved;
		parameters[5].Value = Vendor_CurrencyCode;
		parameters[6].Value = Vendor_TermsCode;
		parameters[7].Value = Vendor_BRNum_c;
		parameters[8].Value = Vendor_BRExpiryDate_c;
		parameters[9].Value = Vendor_OrgRegCode;
		parameters[10].Value = Vendor_PhoneNum;
		parameters[11].Value = Vendor_FaxNum;
		parameters[12].Value = Vendor_EMailAddress;
		parameters[13].Value = Vendor_Address1;
		parameters[14].Value = Vendor_Address2;
		parameters[15].Value = Vendor_Address3;
		parameters[16].Value = Vendor_City;
		parameters[17].Value = Vendor_State;
		parameters[18].Value = Vendor_ZIP;
		parameters[19].Value = Vendor_Country;
		parameters[20].Value = VendCnt_ConNum;
		parameters[21].Value = VendCnt_PerConID;
		parameters[22].Value = VendCnt_Name;
		parameters[23].Value = VendCnt_Func;
		parameters[24].Value = VendCnt_PhoneNum;
		parameters[25].Value = VendCnt_CellPhoneNum;
		parameters[26].Value = VendCnt_EmailAddress;
		parameters[27].Value = VendCnt_UD_RFQRecipent_c;
		parameters[28].Value = VendCnt_UD_PORecipient_c;
		parameters[29].Value = Calculated_PrimaryContact;
		parameters[30].Value = Vendor_PortalRegSubmit_c;
		parameters[31].Value = Vendor_PortalRegExpiryDate_c;
		parameters[32].Value = Vendor_PortalResetPWTime_c;
		parameters[33].Value = Vendor_PortalRegTempPW_c;
		parameters[34].Value = VendCnt_Inactive;

		parameters[35].Value = VendorBank_BankID;
		parameters[36].Value = VendorBank_BankName;
		parameters[37].Value = VendorBank_CountryNum;
		parameters[38].Value = VendorBank_BankAcctNumber;
		parameters[39].Value = VendorBank_NameOnAccount;
		parameters[40].Value = VendorBank_PayMethodType;
		parameters[41].Value = VendorBank_SwiftNum;
		parameters[42].Value = VendorBank_IBANABABSBCode;
		parameters[43].Value = PurTerms_Description;
		parameters[44].Value = Vendor_PortalRegEmailAddress_c;
		parameters[45].Value = Vendor_Website_c;
		



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
		strSql.Append("update ps_epicor_vendor set ");
		strSql.Append("Vendor_Company=@Vendor_Company,");
		strSql.Append("Vendor_VendorNum=@Vendor_VendorNum,");
		strSql.Append("Vendor_VendorID=@Vendor_VendorID,");
		strSql.Append("Vendor_Name=@Vendor_Name,");
		strSql.Append("Vendor_Approved=@Vendor_Approved,");
		strSql.Append("Vendor_CurrencyCode=@Vendor_CurrencyCode,");
		strSql.Append("Vendor_TermsCode=@Vendor_TermsCode,");
		strSql.Append("Vendor_BRNum_c=@Vendor_BRNum_c,");
		strSql.Append("Vendor_BRExpiryDate_c=@Vendor_BRExpiryDate_c,");
		strSql.Append("Vendor_OrgRegCode=@Vendor_OrgRegCode,");
		strSql.Append("Vendor_PhoneNum=@Vendor_PhoneNum,");
		strSql.Append("Vendor_FaxNum=@Vendor_FaxNum,");
		strSql.Append("Vendor_EMailAddress=@Vendor_EMailAddress,");
		strSql.Append("Vendor_Address1=@Vendor_Address1,");
		strSql.Append("Vendor_Address2=@Vendor_Address2,");
		strSql.Append("Vendor_Address3=@Vendor_Address3,");
		strSql.Append("Vendor_City=@Vendor_City,");
		strSql.Append("Vendor_State=@Vendor_State,");
		strSql.Append("Vendor_ZIP=@Vendor_ZIP,");
		strSql.Append("Vendor_Country=@Vendor_Country,");
		strSql.Append("Vendor_CountryNum=@Vendor_CountryNum,");
		strSql.Append("VendCnt_ConNum=@VendCnt_ConNum,");
		strSql.Append("VendCnt_PerConID=@VendCnt_PerConID,");
		strSql.Append("VendCnt_Name=@VendCnt_Name,");
		strSql.Append("VendCnt_Func=@VendCnt_Func,");
		strSql.Append("VendCnt_PhoneNum=@VendCnt_PhoneNum,");
		strSql.Append("VendCnt_CellPhoneNum=@VendCnt_CellPhoneNum,");
		strSql.Append("VendCnt_EmailAddress=@VendCnt_EmailAddress,");
		strSql.Append("VendCnt_UD_RFQRecipent_c=@VendCnt_UD_RFQRecipent_c,");
		strSql.Append("VendCnt_UD_PORecipient_c=@VendCnt_UD_PORecipient_c,");
		strSql.Append("Calculated_PrimaryContact=@Calculated_PrimaryContact,");
		strSql.Append("Vendor_PortalRegSubmit_c=@Vendor_PortalRegSubmit_c,");
		strSql.Append("Vendor_PortalRegExpiryDate_c=@Vendor_PortalRegExpiryDate_c,");
		strSql.Append("Vendor_PortalResetPWTime_c=@Vendor_PortalResetPWTime_c,");
		strSql.Append("Vendor_PortalRegTempPW_c=@Vendor_PortalRegTempPW_c,");
		strSql.Append("Vendor_PortalRegEmailAddress_c=@Vendor_PortalRegEmailAddress_c,");

		strSql.Append("Vendor_Website_c=@Vendor_Website_c,");
		

		strSql.Append("VendorBank_BankID=@VendorBank_BankID,");
		strSql.Append("VendorBank_BankName=@VendorBank_BankName,");
		strSql.Append("VendorBank_CountryNum=@VendorBank_CountryNum,");
		strSql.Append("VendorBank_BankAcctNumber=@VendorBank_BankAcctNumber,");
		strSql.Append("VendorBank_NameOnAccount=@VendorBank_NameOnAccount,");
		strSql.Append("VendorBank_PayMethodType=@VendorBank_PayMethodType,");
		strSql.Append("VendorBank_SwiftNum=@VendorBank_SwiftNum,");
		strSql.Append("VendorBank_IBANABABSBCode=@VendorBank_IBANABABSBCode,");
		strSql.Append("PurTerms_Description=@PurTerms_Description,");
		strSql.Append("VendCnt_Inactive=@VendCnt_Inactive,");
		strSql.Append("Status=@Status");
		


		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
				new SqlParameter("@Vendor_Company", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_VendorNum", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Name", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_Approved", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_CurrencyCode", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_TermsCode", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_BRNum_c", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_BRExpiryDate_c", SqlDbType.DateTime),
				new SqlParameter("@Vendor_OrgRegCode", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_PhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_FaxNum", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_EMailAddress", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address1", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address2", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address3", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_City", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_State", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_ZIP", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Country", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_ConNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_PerConID", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_Name", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_Func", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_PhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_CellPhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_EmailAddress", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_UD_RFQRecipent_c", SqlDbType.NVarChar,20),
				new SqlParameter("@VendCnt_UD_PORecipient_c", SqlDbType.NVarChar,20),
				new SqlParameter("@Calculated_PrimaryContact", SqlDbType.NChar,10),
				new SqlParameter("@Vendor_PortalRegSubmit_c", SqlDbType.NChar,10),
				new SqlParameter("@Vendor_PortalRegExpiryDate_c", SqlDbType.DateTime),
				new SqlParameter("@Vendor_PortalResetPWTime_c", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_PortalRegTempPW_c", SqlDbType.NVarChar,20),

				new SqlParameter("@VendorBank_BankID", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_BankName", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_CountryNum", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_BankAcctNumber", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_NameOnAccount", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_PayMethodType", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_SwiftNum", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_IBANABABSBCode", SqlDbType.NVarChar,500),
				new SqlParameter("@Status", SqlDbType.Int,4),
				new SqlParameter("@VendCnt_Inactive",  SqlDbType.NVarChar,10),
				new SqlParameter("@Vendor_PortalRegEmailAddress_c", SqlDbType.NVarChar,500),
				new SqlParameter("@PurTerms_Description", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_Website_c", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_CountryNum", SqlDbType.NVarChar,500),

				new SqlParameter("@ID", SqlDbType.Int,4)};
		parameters[0].Value = Vendor_Company;
		parameters[1].Value = Vendor_VendorNum;
		parameters[2].Value = Vendor_VendorID;
		parameters[3].Value = Vendor_Name;
		parameters[4].Value = Vendor_Approved;
		parameters[5].Value = Vendor_CurrencyCode;
		parameters[6].Value = Vendor_TermsCode;
		parameters[7].Value = Vendor_BRNum_c;
		parameters[8].Value = Vendor_BRExpiryDate_c;
		parameters[9].Value = Vendor_OrgRegCode;
		parameters[10].Value = Vendor_PhoneNum;
		parameters[11].Value = Vendor_FaxNum;
		parameters[12].Value = Vendor_EMailAddress;
		parameters[13].Value = Vendor_Address1;
		parameters[14].Value = Vendor_Address2;
		parameters[15].Value = Vendor_Address3;
		parameters[16].Value = Vendor_City;
		parameters[17].Value = Vendor_State;
		parameters[18].Value = Vendor_ZIP;
		parameters[19].Value = Vendor_Country;
		parameters[20].Value = VendCnt_ConNum;
		parameters[21].Value = VendCnt_PerConID;
		parameters[22].Value = VendCnt_Name;
		parameters[23].Value = VendCnt_Func;
		parameters[24].Value = VendCnt_PhoneNum;
		parameters[25].Value = VendCnt_CellPhoneNum;
		parameters[26].Value = VendCnt_EmailAddress;
		parameters[27].Value = VendCnt_UD_RFQRecipent_c;
		parameters[28].Value = VendCnt_UD_PORecipient_c;
		parameters[29].Value = Calculated_PrimaryContact;
		parameters[30].Value = Vendor_PortalRegSubmit_c;
		parameters[31].Value = Vendor_PortalRegExpiryDate_c;
		parameters[32].Value = Vendor_PortalResetPWTime_c;
		parameters[33].Value = Vendor_PortalRegTempPW_c;

		parameters[34].Value = VendorBank_BankID;
		parameters[35].Value = VendorBank_BankName;
		parameters[36].Value = VendorBank_CountryNum;
		parameters[37].Value = VendorBank_BankAcctNumber;
		parameters[38].Value = VendorBank_NameOnAccount;
		parameters[39].Value = VendorBank_PayMethodType;
		parameters[40].Value = VendorBank_SwiftNum;
		parameters[41].Value = VendorBank_IBANABABSBCode;
		parameters[42].Value = Status;
		parameters[43].Value = VendCnt_Inactive;
		parameters[44].Value = Vendor_PortalRegEmailAddress_c;
		parameters[45].Value = PurTerms_Description;
		parameters[46].Value = Vendor_Website_c;
		parameters[47].Value = Vendor_CountryNum;

		parameters[48].Value = ID;

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
	/// 更新一条数据
	/// </summary>
	public bool UpdateVendorHeadByCompanyAndVerdorID(string company,string vendorid)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_vendor set ");
		strSql.Append("Vendor_Name=@Vendor_Name,");
		strSql.Append("Vendor_Approved=@Vendor_Approved,");
		strSql.Append("Vendor_CurrencyCode=@Vendor_CurrencyCode,");
		strSql.Append("Vendor_TermsCode=@Vendor_TermsCode,");
		strSql.Append("Vendor_BRNum_c=@Vendor_BRNum_c,");
		strSql.Append("Vendor_BRExpiryDate_c=@Vendor_BRExpiryDate_c,");
		strSql.Append("Vendor_OrgRegCode=@Vendor_OrgRegCode,");
		strSql.Append("Vendor_PhoneNum=@Vendor_PhoneNum,");
		strSql.Append("Vendor_FaxNum=@Vendor_FaxNum,");
		strSql.Append("Vendor_EMailAddress=@Vendor_EMailAddress,");
		strSql.Append("Vendor_Address1=@Vendor_Address1,");
		strSql.Append("Vendor_Address2=@Vendor_Address2,");
		strSql.Append("Vendor_Address3=@Vendor_Address3,");
		strSql.Append("Vendor_City=@Vendor_City,");
		strSql.Append("Vendor_State=@Vendor_State,");
		strSql.Append("Vendor_ZIP=@Vendor_ZIP,");
		strSql.Append("Vendor_Country=@Vendor_Country ,");

		strSql.Append("Vendor_Website_c=@Vendor_Website_c,");

		strSql.Append("VendorBank_BankID=@VendorBank_BankID,");
		strSql.Append("VendorBank_BankName=@VendorBank_BankName,");
		strSql.Append("VendorBank_CountryNum=@VendorBank_CountryNum,");
		strSql.Append("VendorBank_BankAcctNumber=@VendorBank_BankAcctNumber,");
		strSql.Append("VendorBank_NameOnAccount=@VendorBank_NameOnAccount,");
		strSql.Append("VendorBank_PayMethodType=@VendorBank_PayMethodType,");
		strSql.Append("VendorBank_SwiftNum=@VendorBank_SwiftNum,");
		strSql.Append("VendorBank_IBANABABSBCode=@VendorBank_IBANABABSBCode,");

		strSql.Append("PurTerms_Description=@PurTerms_Description,");
		strSql.Append("VendCnt_Inactive=@VendCnt_Inactive");

		strSql.Append(" where Vendor_Company=@Vendor_Company");
		strSql.Append(" and Vendor_VendorID=@Vendor_VendorID ");
		

		SqlParameter[] parameters = {
				new SqlParameter("@Vendor_Company", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_VendorNum", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Name", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_Approved", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_CurrencyCode", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_TermsCode", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_BRNum_c", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_BRExpiryDate_c", SqlDbType.DateTime),
				new SqlParameter("@Vendor_OrgRegCode", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_PhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_FaxNum", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_EMailAddress", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address1", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address2", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address3", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_City", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_State", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_ZIP", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Country", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_ConNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_PerConID", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_Name", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_Func", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_PhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_CellPhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_EmailAddress", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_UD_RFQRecipent_c", SqlDbType.NVarChar,20),
				new SqlParameter("@VendCnt_UD_PORecipient_c", SqlDbType.NVarChar,20),
				new SqlParameter("@Calculated_PrimaryContact", SqlDbType.NChar,10),
				new SqlParameter("@Vendor_PortalRegSubmit_c", SqlDbType.NChar,10),
				new SqlParameter("@Vendor_PortalRegExpiryDate_c", SqlDbType.DateTime),
				new SqlParameter("@Vendor_PortalResetPWTime_c", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_PortalRegTempPW_c", SqlDbType.NVarChar,20),

				new SqlParameter("@VendorBank_BankID", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_BankName", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_CountryNum", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_BankAcctNumber", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_NameOnAccount", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_PayMethodType", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_SwiftNum", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_IBANABABSBCode", SqlDbType.NVarChar,500),
				new SqlParameter("@VendCnt_Inactive", SqlDbType.NVarChar,10),
				new SqlParameter("@Vendor_PortalRegEmailAddress_c", SqlDbType.NVarChar,500),
				new SqlParameter("@PurTerms_Description", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_Website_c", SqlDbType.NVarChar,500),
				new SqlParameter("@ID", SqlDbType.Int,4)};
		parameters[0].Value = company;
		parameters[1].Value = Vendor_VendorNum;
		parameters[2].Value = vendorid;
		parameters[3].Value = Vendor_Name;
		parameters[4].Value = Vendor_Approved;
		parameters[5].Value = Vendor_CurrencyCode;
		parameters[6].Value = Vendor_TermsCode;
		parameters[7].Value = Vendor_BRNum_c;
		parameters[8].Value = Vendor_BRExpiryDate_c;
		parameters[9].Value = Vendor_OrgRegCode;
		parameters[10].Value = Vendor_PhoneNum;
		parameters[11].Value = Vendor_FaxNum;
		parameters[12].Value = Vendor_EMailAddress;
		parameters[13].Value = Vendor_Address1;
		parameters[14].Value = Vendor_Address2;
		parameters[15].Value = Vendor_Address3;
		parameters[16].Value = Vendor_City;
		parameters[17].Value = Vendor_State;
		parameters[18].Value = Vendor_ZIP;
		parameters[19].Value = Vendor_Country;
		parameters[20].Value = VendCnt_ConNum;
		parameters[21].Value = VendCnt_PerConID;
		parameters[22].Value = VendCnt_Name;
		parameters[23].Value = VendCnt_Func;
		parameters[24].Value = VendCnt_PhoneNum;
		parameters[25].Value = VendCnt_CellPhoneNum;
		parameters[26].Value = VendCnt_EmailAddress;
		parameters[27].Value = VendCnt_UD_RFQRecipent_c;
		parameters[28].Value = VendCnt_UD_PORecipient_c;
		parameters[29].Value = Calculated_PrimaryContact;
		parameters[30].Value = Vendor_PortalRegSubmit_c;
		parameters[31].Value = Vendor_PortalRegExpiryDate_c;
		parameters[32].Value = Vendor_PortalResetPWTime_c;
		parameters[33].Value = Vendor_PortalRegTempPW_c;

		parameters[34].Value = VendorBank_BankID;
		parameters[35].Value = VendorBank_BankName;
		parameters[36].Value = VendorBank_CountryNum;
		parameters[37].Value = VendorBank_BankAcctNumber;
		parameters[38].Value = VendorBank_NameOnAccount;
		parameters[39].Value = VendorBank_PayMethodType;
		parameters[40].Value = VendorBank_SwiftNum;
		parameters[41].Value = VendorBank_IBANABABSBCode;
		parameters[42].Value = VendCnt_Inactive;
		parameters[43].Value = Vendor_PortalRegEmailAddress_c;
		parameters[44].Value = PurTerms_Description;
		parameters[45].Value = Vendor_Website_c;
		parameters[46].Value = ID;

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
	public bool UpdateVendorByCompanyAndVerdorID(string company,string vendorid,bool isportalmode)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_vendor set ");
		strSql.Append("Vendor_Name=@Vendor_Name,");
		strSql.Append("Vendor_Approved=@Vendor_Approved,");
		strSql.Append("Vendor_CurrencyCode=@Vendor_CurrencyCode,");
		strSql.Append("Vendor_TermsCode=@Vendor_TermsCode,");
		strSql.Append("Vendor_BRNum_c=@Vendor_BRNum_c,");
		strSql.Append("Vendor_BRExpiryDate_c=@Vendor_BRExpiryDate_c,");
		strSql.Append("Vendor_OrgRegCode=@Vendor_OrgRegCode,");
		strSql.Append("Vendor_PhoneNum=@Vendor_PhoneNum,");
		strSql.Append("Vendor_FaxNum=@Vendor_FaxNum,");
		strSql.Append("Vendor_EMailAddress=@Vendor_EMailAddress,");
		strSql.Append("Vendor_Address1=@Vendor_Address1,");
		strSql.Append("Vendor_Address2=@Vendor_Address2,");
		strSql.Append("Vendor_Address3=@Vendor_Address3,");
		strSql.Append("Vendor_City=@Vendor_City,");
		strSql.Append("Vendor_State=@Vendor_State,");
		strSql.Append("Vendor_ZIP=@Vendor_ZIP,");
		strSql.Append("Vendor_Country=@Vendor_Country ,");
		strSql.Append("Vendor_CountryNum=@Vendor_CountryNum ,");
		strSql.Append("VendCnt_ConNum=@VendCnt_ConNum,");
		strSql.Append("VendCnt_PerConID=@VendCnt_PerConID,");
		strSql.Append("VendCnt_Name=@VendCnt_Name,");
		strSql.Append("VendCnt_Func=@VendCnt_Func,");
		strSql.Append("VendCnt_PhoneNum=@VendCnt_PhoneNum,");
		strSql.Append("VendCnt_CellPhoneNum=@VendCnt_CellPhoneNum,");
		strSql.Append("VendCnt_EmailAddress=@VendCnt_EmailAddress,");
		strSql.Append("VendCnt_UD_RFQRecipent_c=@VendCnt_UD_RFQRecipent_c,");
		strSql.Append("VendCnt_UD_PORecipient_c=@VendCnt_UD_PORecipient_c,");
		strSql.Append("Calculated_PrimaryContact=@Calculated_PrimaryContact,");
		strSql.Append("Vendor_PortalRegSubmit_c=@Vendor_PortalRegSubmit_c,");
		strSql.Append("Vendor_PortalRegExpiryDate_c=@Vendor_PortalRegExpiryDate_c,");
		strSql.Append("Vendor_PortalResetPWTime_c=@Vendor_PortalResetPWTime_c,");
		strSql.Append("Vendor_PortalRegTempPW_c=@Vendor_PortalRegTempPW_c,");
		strSql.Append("VendorBank_IBANABABSBCode=@VendorBank_IBANABABSBCode,");
		strSql.Append("Vendor_Website_c=@Vendor_Website_c,");

		strSql.Append("VendorBank_BankID=@VendorBank_BankID,");
		strSql.Append("VendorBank_BankName=@VendorBank_BankName,");
		strSql.Append("VendorBank_CountryNum=@VendorBank_CountryNum,");
		strSql.Append("VendorBank_BankAcctNumber=@VendorBank_BankAcctNumber,");
		strSql.Append("VendorBank_NameOnAccount=@VendorBank_NameOnAccount,");
		strSql.Append("VendorBank_PayMethodType=@VendorBank_PayMethodType,");
		strSql.Append("VendorBank_SwiftNum=@VendorBank_SwiftNum,");
		strSql.Append("Vendor_PortalRegEmailAddress_c=@Vendor_PortalRegEmailAddress_c,");
		strSql.Append("PurTerms_Description=@PurTerms_Description,");
		strSql.Append("VendCnt_Inactive=@VendCnt_Inactive");

		strSql.Append(" where Vendor_Company=@Vendor_Company");
		strSql.Append(" and Vendor_VendorID=@Vendor_VendorID ");
		strSql.Append(" and VendCnt_ConNum=@VendCnt_ConNum ");
		if(!isportalmode)
			strSql.Append(" and Status <> 2 ");
		strSql.Append(" and @Vendor_Approved = 'True' ");
		

		SqlParameter[] parameters = {
				new SqlParameter("@Vendor_Company", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_VendorNum", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Name", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_Approved", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_CurrencyCode", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_TermsCode", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_BRNum_c", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_BRExpiryDate_c", SqlDbType.DateTime),
				new SqlParameter("@Vendor_OrgRegCode", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_PhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_FaxNum", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_EMailAddress", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address1", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address2", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address3", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_City", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_State", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_ZIP", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Country", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_ConNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_PerConID", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_Name", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_Func", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_PhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_CellPhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_EmailAddress", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_UD_RFQRecipent_c", SqlDbType.NVarChar,20),
				new SqlParameter("@VendCnt_UD_PORecipient_c", SqlDbType.NVarChar,20),
				new SqlParameter("@Calculated_PrimaryContact", SqlDbType.NChar,10),
				new SqlParameter("@Vendor_PortalRegSubmit_c", SqlDbType.NChar,10),
				new SqlParameter("@Vendor_PortalRegExpiryDate_c", SqlDbType.DateTime),
				new SqlParameter("@Vendor_PortalResetPWTime_c", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_PortalRegTempPW_c", SqlDbType.NVarChar,20),

				new SqlParameter("@VendorBank_BankID", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_BankName", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_CountryNum", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_BankAcctNumber", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_NameOnAccount", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_PayMethodType", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_SwiftNum", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_IBANABABSBCode", SqlDbType.NVarChar,500),
				new SqlParameter("@VendCnt_Inactive", SqlDbType.NVarChar,10),
				new SqlParameter("@Vendor_PortalRegEmailAddress_c", SqlDbType.NVarChar,500),
				new SqlParameter("@PurTerms_Description", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_Website_c", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_CountryNum", SqlDbType.NVarChar,500),
				new SqlParameter("@ID", SqlDbType.Int,4)};
		parameters[0].Value = company;
		parameters[1].Value = Vendor_VendorNum;
		parameters[2].Value = vendorid;
		parameters[3].Value = Vendor_Name;
		parameters[4].Value = Vendor_Approved;
		parameters[5].Value = Vendor_CurrencyCode;
		parameters[6].Value = Vendor_TermsCode;
		parameters[7].Value = Vendor_BRNum_c;
		parameters[8].Value = Vendor_BRExpiryDate_c;
		parameters[9].Value = Vendor_OrgRegCode;
		parameters[10].Value = Vendor_PhoneNum;
		parameters[11].Value = Vendor_FaxNum;
		parameters[12].Value = Vendor_EMailAddress;
		parameters[13].Value = Vendor_Address1;
		parameters[14].Value = Vendor_Address2;
		parameters[15].Value = Vendor_Address3;
		parameters[16].Value = Vendor_City;
		parameters[17].Value = Vendor_State;
		parameters[18].Value = Vendor_ZIP;
		parameters[19].Value = Vendor_Country;
		parameters[20].Value = VendCnt_ConNum;
		parameters[21].Value = VendCnt_PerConID;
		parameters[22].Value = VendCnt_Name;
		parameters[23].Value = VendCnt_Func;
		parameters[24].Value = VendCnt_PhoneNum;
		parameters[25].Value = VendCnt_CellPhoneNum;
		parameters[26].Value = VendCnt_EmailAddress;
		parameters[27].Value = VendCnt_UD_RFQRecipent_c;
		parameters[28].Value = VendCnt_UD_PORecipient_c;
		parameters[29].Value = Calculated_PrimaryContact;
		parameters[30].Value = Vendor_PortalRegSubmit_c;
		parameters[31].Value = Vendor_PortalRegExpiryDate_c;
		parameters[32].Value = Vendor_PortalResetPWTime_c;
		parameters[33].Value = Vendor_PortalRegTempPW_c;

		parameters[34].Value = VendorBank_BankID;
		parameters[35].Value = VendorBank_BankName;
		parameters[36].Value = VendorBank_CountryNum;
		parameters[37].Value = VendorBank_BankAcctNumber;
		parameters[38].Value = VendorBank_NameOnAccount;
		parameters[39].Value = VendorBank_PayMethodType;
		parameters[40].Value = VendorBank_SwiftNum;
		parameters[41].Value = VendorBank_IBANABABSBCode;
		parameters[42].Value = VendCnt_Inactive;
		parameters[43].Value = Vendor_PortalRegEmailAddress_c;
		parameters[44].Value = PurTerms_Description;
		parameters[45].Value = Vendor_Website_c;
		parameters[46].Value = Vendor_CountryNum;
		parameters[47].Value = ID;

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

	/// </summary>
	public bool UpdateVendorTempInfoByCompanyAndVerdorID(string company, string vendorid)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_vendor set ");
		
		strSql.Append("Vendor_PortalRegSubmit_c=@Vendor_PortalRegSubmit_c,");
		strSql.Append("Vendor_PortalRegExpiryDate_c=@Vendor_PortalRegExpiryDate_c,");
		strSql.Append("Vendor_PortalResetPWTime_c=@Vendor_PortalResetPWTime_c,");
		strSql.Append("Vendor_PortalRegTempPW_c=@Vendor_PortalRegTempPW_c,");
		
		strSql.Append("Vendor_PortalRegEmailAddress_c=@Vendor_PortalRegEmailAddress_c,");
		strSql.Append("PurTerms_Description=@PurTerms_Description");
		
		strSql.Append(" where Vendor_Company=@Vendor_Company");
		strSql.Append(" and Vendor_VendorID=@Vendor_VendorID ");
		


		SqlParameter[] parameters = {
				new SqlParameter("@Vendor_Company", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_VendorNum", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Name", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_Approved", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_CurrencyCode", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_TermsCode", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_BRNum_c", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_BRExpiryDate_c", SqlDbType.DateTime),
				new SqlParameter("@Vendor_OrgRegCode", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_PhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_FaxNum", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_EMailAddress", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address1", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address2", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address3", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_City", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_State", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_ZIP", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Country", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_ConNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_PerConID", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_Name", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_Func", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_PhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_CellPhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_EmailAddress", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_UD_RFQRecipent_c", SqlDbType.NVarChar,20),
				new SqlParameter("@VendCnt_UD_PORecipient_c", SqlDbType.NVarChar,20),
				new SqlParameter("@Calculated_PrimaryContact", SqlDbType.NChar,10),
				new SqlParameter("@Vendor_PortalRegSubmit_c", SqlDbType.NChar,10),
				new SqlParameter("@Vendor_PortalRegExpiryDate_c", SqlDbType.DateTime),
				new SqlParameter("@Vendor_PortalResetPWTime_c", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_PortalRegTempPW_c", SqlDbType.NVarChar,20),

				new SqlParameter("@VendorBank_BankID", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_BankName", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_CountryNum", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_BankAcctNumber", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_NameOnAccount", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_PayMethodType", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_SwiftNum", SqlDbType.NVarChar,500),
				new SqlParameter("@VendorBank_IBANABABSBCode", SqlDbType.NVarChar,500),
				new SqlParameter("@VendCnt_Inactive", SqlDbType.NVarChar,10),
				new SqlParameter("@Vendor_PortalRegEmailAddress_c", SqlDbType.NVarChar,500),
				new SqlParameter("@PurTerms_Description", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_Website_c", SqlDbType.NVarChar,500),
				new SqlParameter("@ID", SqlDbType.Int,4)};
		parameters[0].Value = company;
		parameters[1].Value = Vendor_VendorNum;
		parameters[2].Value = vendorid;
		parameters[3].Value = Vendor_Name;
		parameters[4].Value = Vendor_Approved;
		parameters[5].Value = Vendor_CurrencyCode;
		parameters[6].Value = Vendor_TermsCode;
		parameters[7].Value = Vendor_BRNum_c;
		parameters[8].Value = Vendor_BRExpiryDate_c;
		parameters[9].Value = Vendor_OrgRegCode;
		parameters[10].Value = Vendor_PhoneNum;
		parameters[11].Value = Vendor_FaxNum;
		parameters[12].Value = Vendor_EMailAddress;
		parameters[13].Value = Vendor_Address1;
		parameters[14].Value = Vendor_Address2;
		parameters[15].Value = Vendor_Address3;
		parameters[16].Value = Vendor_City;
		parameters[17].Value = Vendor_State;
		parameters[18].Value = Vendor_ZIP;
		parameters[19].Value = Vendor_Country;
		parameters[20].Value = VendCnt_ConNum;
		parameters[21].Value = VendCnt_PerConID;
		parameters[22].Value = VendCnt_Name;
		parameters[23].Value = VendCnt_Func;
		parameters[24].Value = VendCnt_PhoneNum;
		parameters[25].Value = VendCnt_CellPhoneNum;
		parameters[26].Value = VendCnt_EmailAddress;
		parameters[27].Value = VendCnt_UD_RFQRecipent_c;
		parameters[28].Value = VendCnt_UD_PORecipient_c;
		parameters[29].Value = Calculated_PrimaryContact;
		parameters[30].Value = Vendor_PortalRegSubmit_c;
		parameters[31].Value = Vendor_PortalRegExpiryDate_c;
		parameters[32].Value = Vendor_PortalResetPWTime_c;
		parameters[33].Value = Vendor_PortalRegTempPW_c;

		parameters[34].Value = VendorBank_BankID;
		parameters[35].Value = VendorBank_BankName;
		parameters[36].Value = VendorBank_CountryNum;
		parameters[37].Value = VendorBank_BankAcctNumber;
		parameters[38].Value = VendorBank_NameOnAccount;
		parameters[39].Value = VendorBank_PayMethodType;
		parameters[40].Value = VendorBank_SwiftNum;
		parameters[41].Value = VendorBank_IBANABABSBCode;
		parameters[42].Value = VendCnt_Inactive;
		parameters[43].Value = Vendor_PortalRegEmailAddress_c;
		parameters[44].Value = PurTerms_Description;
		parameters[45].Value = Vendor_Website_c;
		parameters[46].Value = ID;

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
	public bool UpdateVendorStatusByCompanyAndVerdorID(string company, string vendorid,int status)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_vendor set ");
		strSql.Append("Status=@Status ");
		

		strSql.Append(" where Vendor_Company=@Vendor_Company");
		strSql.Append(" and Vendor_VendorID=@Vendor_VendorID ");
		strSql.Append(" and status<>-1 ");

		SqlParameter[] parameters = {
				new SqlParameter("@Vendor_Company", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,20),
				new SqlParameter("@Status", SqlDbType.Int,4)};
		parameters[0].Value = company;
		parameters[1].Value = vendorid;
		parameters[2].Value = status;

		
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
	public bool UpdateContact()
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_vendor set ");
		strSql.Append("Vendor_Name=@Vendor_Name,");
		strSql.Append("Vendor_Approved=@Vendor_Approved,");
		strSql.Append("Vendor_CurrencyCode=@Vendor_CurrencyCode,");
		strSql.Append("Vendor_TermsCode=@Vendor_TermsCode,");
		strSql.Append("Vendor_BRNum_c=@Vendor_BRNum_c,");
		strSql.Append("Vendor_BRExpiryDate_c=@Vendor_BRExpiryDate_c,");
		strSql.Append("Vendor_OrgRegCode=@Vendor_OrgRegCode,");
		strSql.Append("Vendor_PhoneNum=@Vendor_PhoneNum,");
		strSql.Append("Vendor_FaxNum=@Vendor_FaxNum,");
		strSql.Append("Vendor_EMailAddress=@Vendor_EMailAddress,");
		strSql.Append("Vendor_Address1=@Vendor_Address1,");
		strSql.Append("Vendor_Address2=@Vendor_Address2,");
		strSql.Append("Vendor_Address3=@Vendor_Address3,");
		strSql.Append("Vendor_City=@Vendor_City,");
		strSql.Append("Vendor_State=@Vendor_State,");
		strSql.Append("Vendor_ZIP=@Vendor_ZIP,");
		strSql.Append("Vendor_Country=@Vendor_Country,");
		strSql.Append("Vendor_CountryNum=@Vendor_CountryNum,");
		strSql.Append("VendCnt_PerConID=@VendCnt_PerConID,");
		strSql.Append("VendCnt_Name=@VendCnt_Name,");
		strSql.Append("VendCnt_Func=@VendCnt_Func,");
		strSql.Append("VendCnt_PhoneNum=@VendCnt_PhoneNum,");
		strSql.Append("VendCnt_CellPhoneNum=@VendCnt_CellPhoneNum,");
		strSql.Append("VendCnt_EmailAddress=@VendCnt_EmailAddress,");
		strSql.Append("VendCnt_UD_RFQRecipent_c=@VendCnt_UD_RFQRecipent_c,");
		strSql.Append("VendCnt_UD_PORecipient_c=@VendCnt_UD_PORecipient_c,");
		strSql.Append("Calculated_PrimaryContact=@Calculated_PrimaryContact,");
		strSql.Append("Vendor_PortalRegSubmit_c=@Vendor_PortalRegSubmit_c,");
		strSql.Append("Vendor_PortalRegExpiryDate_c=@Vendor_PortalRegExpiryDate_c,");
		strSql.Append("Vendor_PortalResetPWTime_c=@Vendor_PortalResetPWTime_c,");
		strSql.Append("Vendor_PortalRegTempPW_c=@Vendor_PortalRegTempPW_c,");
		strSql.Append("VendCnt_Inactive=@VendCnt_Inactive");
		strSql.Append(" where Vendor_Company=@Vendor_Company");
		strSql.Append(" and Vendor_VendorNum=@Vendor_VendorNum");
		strSql.Append(" and VendCnt_ConNum=@VendCnt_ConNum");
		SqlParameter[] parameters = {
				new SqlParameter("@Vendor_Company", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_VendorNum", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Name", SqlDbType.NVarChar,500),
				new SqlParameter("@Vendor_Approved", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_CurrencyCode", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_TermsCode", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_BRNum_c", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_BRExpiryDate_c", SqlDbType.DateTime),
				new SqlParameter("@Vendor_OrgRegCode", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_PhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_FaxNum", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_EMailAddress", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address1", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address2", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Address3", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_City", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_State", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_ZIP", SqlDbType.NVarChar,100),
				new SqlParameter("@Vendor_Country", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_ConNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_PerConID", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_Name", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_Func", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_PhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_CellPhoneNum", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_EmailAddress", SqlDbType.NVarChar,100),
				new SqlParameter("@VendCnt_UD_RFQRecipent_c", SqlDbType.NVarChar,20),
				new SqlParameter("@VendCnt_UD_PORecipient_c", SqlDbType.NVarChar,20),
				new SqlParameter("@Calculated_PrimaryContact", SqlDbType.NChar,10),
				new SqlParameter("@Vendor_PortalRegSubmit_c", SqlDbType.NChar,10),
				new SqlParameter("@Vendor_PortalRegExpiryDate_c", SqlDbType.DateTime),
				new SqlParameter("@Vendor_PortalResetPWTime_c", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_PortalRegTempPW_c", SqlDbType.NVarChar,20),
				new SqlParameter("@Vendor_CountryNum", SqlDbType.NVarChar,20),
				new SqlParameter("@VendCnt_Inactive", SqlDbType.NVarChar,20)};
		parameters[0].Value = Vendor_Company;
		parameters[1].Value = Vendor_VendorNum;
		parameters[2].Value = Vendor_VendorID;
		parameters[3].Value = Vendor_Name;
		parameters[4].Value = Vendor_Approved;
		parameters[5].Value = Vendor_CurrencyCode;
		parameters[6].Value = Vendor_TermsCode;
		parameters[7].Value = Vendor_BRNum_c;
		parameters[8].Value = Vendor_BRExpiryDate_c;
		parameters[9].Value = Vendor_OrgRegCode;
		parameters[10].Value = Vendor_PhoneNum;
		parameters[11].Value = Vendor_FaxNum;
		parameters[12].Value = Vendor_EMailAddress;
		parameters[13].Value = Vendor_Address1;
		parameters[14].Value = Vendor_Address2;
		parameters[15].Value = Vendor_Address3;
		parameters[16].Value = Vendor_City;
		parameters[17].Value = Vendor_State;
		parameters[18].Value = Vendor_ZIP;
		parameters[19].Value = Vendor_Country;
		parameters[20].Value = VendCnt_ConNum;
		parameters[21].Value = VendCnt_PerConID;
		parameters[22].Value = VendCnt_Name;
		parameters[23].Value = VendCnt_Func;
		parameters[24].Value = VendCnt_PhoneNum;
		parameters[25].Value = VendCnt_CellPhoneNum;
		parameters[26].Value = VendCnt_EmailAddress;
		parameters[27].Value = VendCnt_UD_RFQRecipent_c;
		parameters[28].Value = VendCnt_UD_PORecipient_c;
		parameters[29].Value = Calculated_PrimaryContact;
		parameters[30].Value = Vendor_PortalRegSubmit_c;
		parameters[31].Value = Vendor_PortalRegExpiryDate_c;
		parameters[32].Value = Vendor_PortalResetPWTime_c;
		parameters[33].Value = Vendor_PortalRegTempPW_c;
		parameters[34].Value = Vendor_CountryNum;
		parameters[35].Value = VendCnt_Inactive;

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
			
		StringBuilder strSql=new StringBuilder();
		strSql.Append("delete from ps_epicor_vendor ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
				new SqlParameter("@ID", SqlDbType.Int,4)
		};
		parameters[0].Value = ID;

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
	/// 删除一条数据
	/// </summary>
	public bool DeleteByVendorNumAndCntNum(string VendorNum,string ConNum)
	{

		StringBuilder strSql = new StringBuilder();
		strSql.Append("update ps_epicor_vendor ");
		strSql.Append("set  status=-1 ");
		strSql.Append(" where Vendor_VendorID=@VendorNum");
		strSql.Append(" and VendCnt_ConNum=@ConNum");
		SqlParameter[] parameters = {
				new SqlParameter("@VendorNum", SqlDbType.NVarChar,50),
				new SqlParameter("@ConNum", SqlDbType.NVarChar,50)
		};
		parameters[0].Value = VendorNum;
		parameters[1].Value = ConNum;

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
	public bool DeleteList(string IDlist )
	{
		StringBuilder strSql=new StringBuilder();
		strSql.Append("delete from ps_epicor_vendor ");
		strSql.Append(" where ID in ("+IDlist + ")  ");
		int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		strSql.Append("delete from ps_epicor_vendor ");
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
	public ps_epicor_vendor GetModel(int ID)
	{
			
		StringBuilder strSql=new StringBuilder();
		//strSql.Append("select  top 1 ID,Vendor_Company,Vendor_VendorNum,Vendor_VendorID,Vendor_Name,Vendor_Approved,Vendor_CurrencyCode,Vendor_TermsCode,Vendor_BRNum_c,Vendor_BRExpiryDate_c,Vendor_OrgRegCode,Vendor_PhoneNum,Vendor_FaxNum,Vendor_EMailAddress,Vendor_Address1,Vendor_Address2,Vendor_Address3,Vendor_City,Vendor_State,Vendor_ZIP,Vendor_Country,VendCnt_ConNum,VendCnt_PerConID,VendCnt_Name,VendCnt_Func,VendCnt_PhoneNum,VendCnt_CellPhoneNum,VendCnt_EmailAddress,VendCnt_UD_RFQRecipent_c,VendCnt_UD_PORecipient_c,Calculated_PrimaryContact,Vendor_PortalRegSubmit_c,Vendor_PortalRegExpiryDate_c,Vendor_PortalResetPWTime_c,Vendor_PortalRegTempPW_c,Create_Date from ps_epicor_vendor ");
		strSql.Append("select  top 1 * from ps_epicor_vendor ");
		strSql.Append(" where ID=@ID");
		SqlParameter[] parameters = {
				new SqlParameter("@ID", SqlDbType.Int,4)
		};
		parameters[0].Value = ID;

		ps_epicor_vendor model=new ps_epicor_vendor();
		DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
		if(ds.Tables[0].Rows.Count>0)
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
	public ps_epicor_vendor GetModelByVendorIDAndConNum(string Company,string VendorID,string ConNum)
	{

		StringBuilder strSql = new StringBuilder();
		//strSql.Append("select  top 1 ID,Vendor_Company,Vendor_VendorNum,Vendor_VendorID,Vendor_Name,Vendor_Approved,Vendor_CurrencyCode,Vendor_TermsCode,Vendor_BRNum_c,Vendor_BRExpiryDate_c,Vendor_OrgRegCode,Vendor_PhoneNum,Vendor_FaxNum,Vendor_EMailAddress,Vendor_Address1,Vendor_Address2,Vendor_Address3,Vendor_City,Vendor_State,Vendor_ZIP,Vendor_Country,VendCnt_ConNum,VendCnt_PerConID,VendCnt_Name,VendCnt_Func,VendCnt_PhoneNum,VendCnt_CellPhoneNum,VendCnt_EmailAddress,VendCnt_UD_RFQRecipent_c,VendCnt_UD_PORecipient_c,Calculated_PrimaryContact,Vendor_PortalRegSubmit_c,Vendor_PortalRegExpiryDate_c,Vendor_PortalResetPWTime_c,Vendor_PortalRegTempPW_c,Create_Date from ps_epicor_vendor ");
		strSql.Append("select  top 1 * from ps_epicor_vendor ");
		strSql.Append(" where Vendor_Company=@Vendor_Company");
		strSql.Append(" and Vendor_VendorID=@Vendor_VendorID");
		strSql.Append(" and VendCnt_ConNum=@VendCnt_ConNum");
		SqlParameter[] parameters = {
				new SqlParameter("@Vendor_Company", SqlDbType.NVarChar,50),
				new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,50),
				new SqlParameter("@VendCnt_ConNum", SqlDbType.NVarChar,50)
		};
		parameters[0].Value = Company;
		parameters[1].Value = VendorID;
		parameters[2].Value = ConNum;

		ps_epicor_vendor model = new ps_epicor_vendor();
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
	public ps_epicor_vendor GetModelByVendorID(string Company, string VendorID)
	{

		StringBuilder strSql = new StringBuilder();
		//strSql.Append("select  top 1 ID,Vendor_Company,Vendor_VendorNum,Vendor_VendorID,Vendor_Name,Vendor_Approved,Vendor_CurrencyCode,Vendor_TermsCode,Vendor_BRNum_c,Vendor_BRExpiryDate_c,Vendor_OrgRegCode,Vendor_PhoneNum,Vendor_FaxNum,Vendor_EMailAddress,Vendor_Address1,Vendor_Address2,Vendor_Address3,Vendor_City,Vendor_State,Vendor_ZIP,Vendor_Country,VendCnt_ConNum,VendCnt_PerConID,VendCnt_Name,VendCnt_Func,VendCnt_PhoneNum,VendCnt_CellPhoneNum,VendCnt_EmailAddress,VendCnt_UD_RFQRecipent_c,VendCnt_UD_PORecipient_c,Calculated_PrimaryContact,Vendor_PortalRegSubmit_c,Vendor_PortalRegExpiryDate_c,Vendor_PortalResetPWTime_c,Vendor_PortalRegTempPW_c,Create_Date from ps_epicor_vendor ");
		strSql.Append("select  top 1 * from ps_epicor_vendor ");
		strSql.Append(" where (Vendor_Company=@Vendor_Company or 1=1)");
		strSql.Append(" and Vendor_VendorID=@Vendor_VendorID");
		strSql.Append(" and status<>-1");
		strSql.Append(" order by Calculated_PrimaryContact desc,VendCnt_ConNum ");
		SqlParameter[] parameters = {
				new SqlParameter("@Vendor_Company", SqlDbType.NVarChar,50),
				new SqlParameter("@Vendor_VendorID", SqlDbType.NVarChar,50)
		};
		parameters[0].Value = Company;
		parameters[1].Value = VendorID;

		ps_epicor_vendor model = new ps_epicor_vendor();
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
	/// 返回地区名称
	/// </summary>
	public string GetVendorNameByVendorID(string vendorid)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select top 1 Vendor_Name from [ps_epicor_vendor]");
		strSql.Append(" where Vendor_VendorID='" + vendorid +"'");
		string Name = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
		if (string.IsNullOrEmpty(Name))
		{
			return "";
		}
		return Name;
	}

	/// <summary>
	/// 返回地区名称
	/// </summary>
	public string GetMaxVendorConNumByVendorID(string vendorid)
	{
		StringBuilder strSql = new StringBuilder();
		strSql.Append("select MAX(VendCnt_ConNum) as VendCnt_ConNum  from [ps_epicor_vendor]");
		strSql.Append(" where Vendor_VendorID='" + vendorid + "'");
		string Name = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
		if (string.IsNullOrEmpty(Name))
		{
			return "";
		}
		return Name;
	}


	/// <summary>
	/// 得到一个对象实体
	/// </summary>
	public ps_epicor_vendor DataRowToModel(DataRow row)
	{
		ps_epicor_vendor model=new ps_epicor_vendor();
		if (row != null)
		{
			if(row["ID"]!=null && row["ID"].ToString()!="")
			{
				ID=int.Parse(row["ID"].ToString());
			}
			if(row["Vendor_Company"]!=null)
			{
				Vendor_Company=row["Vendor_Company"].ToString();
			}
			if(row["Vendor_VendorNum"]!=null)
			{
				Vendor_VendorNum=row["Vendor_VendorNum"].ToString();
			}
			if(row["Vendor_VendorID"]!=null)
			{
				Vendor_VendorID=row["Vendor_VendorID"].ToString();
			}
			if(row["Vendor_Name"]!=null)
			{
				Vendor_Name=row["Vendor_Name"].ToString();
			}
			if(row["Vendor_Approved"]!=null)
			{
				Vendor_Approved=row["Vendor_Approved"].ToString();
			}
			if(row["Vendor_CurrencyCode"]!=null)
			{
				Vendor_CurrencyCode=row["Vendor_CurrencyCode"].ToString();
			}
			if(row["Vendor_TermsCode"]!=null)
			{
				Vendor_TermsCode=row["Vendor_TermsCode"].ToString();
			}
			if(row["Vendor_BRNum_c"]!=null)
			{
				Vendor_BRNum_c=row["Vendor_BRNum_c"].ToString();
			}
			if(row["Vendor_BRExpiryDate_c"]!=null && row["Vendor_BRExpiryDate_c"].ToString()!="")
			{
				Vendor_BRExpiryDate_c=DateTime.Parse(row["Vendor_BRExpiryDate_c"].ToString());
			}
			if(row["Vendor_OrgRegCode"]!=null)
			{
				Vendor_OrgRegCode=row["Vendor_OrgRegCode"].ToString();
			}
			if(row["Vendor_PhoneNum"]!=null)
			{
				Vendor_PhoneNum=row["Vendor_PhoneNum"].ToString();
			}
			if(row["Vendor_FaxNum"]!=null)
			{
				Vendor_FaxNum=row["Vendor_FaxNum"].ToString();
			}
			if(row["Vendor_EMailAddress"]!=null)
			{
				Vendor_EMailAddress=row["Vendor_EMailAddress"].ToString();
			}
			if(row["Vendor_Address1"]!=null)
			{
				Vendor_Address1=row["Vendor_Address1"].ToString();
			}
			if(row["Vendor_Address2"]!=null)
			{
				Vendor_Address2=row["Vendor_Address2"].ToString();
			}
			if(row["Vendor_Address3"]!=null)
			{
				Vendor_Address3=row["Vendor_Address3"].ToString();
			}
			if(row["Vendor_City"]!=null)
			{
				Vendor_City=row["Vendor_City"].ToString();
			}
			if(row["Vendor_State"]!=null)
			{
				Vendor_State=row["Vendor_State"].ToString();
			}
			if(row["Vendor_ZIP"]!=null)
			{
				Vendor_ZIP=row["Vendor_ZIP"].ToString();
			}
			if(row["Vendor_Country"]!=null)
			{
				Vendor_Country=row["Vendor_Country"].ToString();
			}
			if (row["Vendor_CountryNum"] != null)
			{
				Vendor_CountryNum = row["Vendor_CountryNum"].ToString();
			}
			if (row["VendCnt_ConNum"]!=null)
			{
				VendCnt_ConNum=row["VendCnt_ConNum"].ToString();
			}
			if(row["VendCnt_PerConID"]!=null)
			{
				VendCnt_PerConID=row["VendCnt_PerConID"].ToString();
			}
			if(row["VendCnt_Name"]!=null)
			{
				VendCnt_Name=row["VendCnt_Name"].ToString();
			}
			if(row["VendCnt_Func"]!=null)
			{
				VendCnt_Func=row["VendCnt_Func"].ToString();
			}
			if(row["VendCnt_PhoneNum"]!=null)
			{
				VendCnt_PhoneNum=row["VendCnt_PhoneNum"].ToString();
			}
			if(row["VendCnt_CellPhoneNum"]!=null)
			{
				VendCnt_CellPhoneNum=row["VendCnt_CellPhoneNum"].ToString();
			}
			if(row["VendCnt_EmailAddress"]!=null)
			{
				VendCnt_EmailAddress=row["VendCnt_EmailAddress"].ToString();
			}
			if(row["VendCnt_UD_RFQRecipent_c"]!=null)
			{
				VendCnt_UD_RFQRecipent_c=row["VendCnt_UD_RFQRecipent_c"].ToString();
			}
			if(row["VendCnt_UD_PORecipient_c"]!=null)
			{
				VendCnt_UD_PORecipient_c=row["VendCnt_UD_PORecipient_c"].ToString();
			}
			if(row["Calculated_PrimaryContact"]!=null)
			{
				Calculated_PrimaryContact=row["Calculated_PrimaryContact"].ToString();
			}
			if(row["Vendor_PortalRegSubmit_c"]!=null)
			{
				Vendor_PortalRegSubmit_c=row["Vendor_PortalRegSubmit_c"].ToString();
			}
			if(row["Vendor_PortalRegExpiryDate_c"]!=null && row["Vendor_PortalRegExpiryDate_c"].ToString()!="")
			{
				Vendor_PortalRegExpiryDate_c=DateTime.Parse(row["Vendor_PortalRegExpiryDate_c"].ToString());
			}
			if(row["Vendor_PortalResetPWTime_c"]!=null)
			{
				Vendor_PortalResetPWTime_c=row["Vendor_PortalResetPWTime_c"].ToString();
			}
			if(row["Vendor_PortalRegTempPW_c"]!=null)
			{
				Vendor_PortalRegTempPW_c=row["Vendor_PortalRegTempPW_c"].ToString();
			}
			if(row["Create_Date"]!=null && row["Create_Date"].ToString()!="")
			{
				Create_Date=DateTime.Parse(row["Create_Date"].ToString());
			}

			if (row["VendorBank_BankID"] != null)
			{
				VendorBank_BankID = row["VendorBank_BankID"].ToString();
			}
			if (row["VendorBank_BankName"] != null)
			{
				VendorBank_BankName = row["VendorBank_BankName"].ToString();
			}
			if (row["VendorBank_CountryNum"] != null)
			{
				VendorBank_CountryNum = row["VendorBank_CountryNum"].ToString();
			}
			if (row["VendorBank_BankAcctNumber"] != null)
			{
				VendorBank_BankAcctNumber = row["VendorBank_BankAcctNumber"].ToString();
			}
			if (row["VendorBank_NameOnAccount"] != null)
			{
				VendorBank_NameOnAccount = row["VendorBank_NameOnAccount"].ToString();
			}
			if (row["VendorBank_PayMethodType"] != null)
			{
				VendorBank_PayMethodType = row["VendorBank_PayMethodType"].ToString();
			}
			if (row["VendorBank_SwiftNum"] != null)
			{
				VendorBank_SwiftNum = row["VendorBank_SwiftNum"].ToString();
			}
			if (row["VendorBank_IBANABABSBCode"] != null) 
			{
				VendorBank_IBANABABSBCode = row["VendorBank_IBANABABSBCode"].ToString();
			}
			if (row["VendCnt_Inactive"] != null)
			{
				VendCnt_Inactive = row["VendCnt_Inactive"].ToString();
			}
			if (row["Vendor_PortalRegEmailAddress_c"] != null)
			{
				Vendor_PortalRegEmailAddress_c = row["Vendor_PortalRegEmailAddress_c"].ToString();
			}
			if (row["PurTerms_Description"] != null)
			{
				PurTerms_Description = row["PurTerms_Description"].ToString();
			}
			if (row["Vendor_Website_c"] != null)
			{
				Vendor_Website_c = row["Vendor_Website_c"].ToString();
			}
			

		}
		return model;
	}

	/// <summary>
	/// 获得数据列表
	/// </summary>
	public DataSet GetList(string strWhere)
	{
		StringBuilder strSql=new StringBuilder();
		//strSql.Append("select ID,Vendor_Company,Vendor_VendorNum,Vendor_VendorID,Vendor_Name,Vendor_Approved,Vendor_CurrencyCode,Vendor_TermsCode,Vendor_BRNum_c,Vendor_BRExpiryDate_c,Vendor_OrgRegCode,Vendor_PhoneNum,Vendor_FaxNum,Vendor_EMailAddress,Vendor_Address1,Vendor_Address2,Vendor_Address3,Vendor_City,Vendor_State,Vendor_ZIP,Vendor_Country,VendCnt_ConNum,VendCnt_PerConID,VendCnt_Name,VendCnt_Func,VendCnt_PhoneNum,VendCnt_CellPhoneNum,VendCnt_EmailAddress,VendCnt_UD_RFQRecipent_c,VendCnt_UD_PORecipient_c,Calculated_PrimaryContact,Vendor_PortalRegSubmit_c,Vendor_PortalRegExpiryDate_c,Vendor_PortalResetPWTime_c,Vendor_PortalRegTempPW_c,Create_Date ");
		strSql.Append("select * ");
		strSql.Append(" FROM ps_epicor_vendor ");
		if(strWhere.Trim()!="")
		{
			strSql.Append(" where "+strWhere);
		}
		return DbHelperSQL.Query(strSql.ToString());
	}

	/// <summary>
	/// 获得前几行数据
	/// </summary>
	public DataSet GetList(int Top,string strWhere,string filedOrder)
	{
		StringBuilder strSql=new StringBuilder();
		strSql.Append("select ");
		if(Top>0)
		{
			strSql.Append(" top "+Top.ToString());
		}
		//strSql.Append(" ID,Vendor_Company,Vendor_VendorNum,Vendor_VendorID,Vendor_Name,Vendor_Approved,Vendor_CurrencyCode,Vendor_TermsCode,Vendor_BRNum_c,Vendor_BRExpiryDate_c,Vendor_OrgRegCode,Vendor_PhoneNum,Vendor_FaxNum,Vendor_EMailAddress,Vendor_Address1,Vendor_Address2,Vendor_Address3,Vendor_City,Vendor_State,Vendor_ZIP,Vendor_Country,VendCnt_ConNum,VendCnt_PerConID,VendCnt_Name,VendCnt_Func,VendCnt_PhoneNum,VendCnt_CellPhoneNum,VendCnt_EmailAddress,VendCnt_UD_RFQRecipent_c,VendCnt_UD_PORecipient_c,Calculated_PrimaryContact,Vendor_PortalRegSubmit_c,Vendor_PortalRegExpiryDate_c,Vendor_PortalResetPWTime_c,Vendor_PortalRegTempPW_c,Create_Date ");
		strSql.Append(" * ");
		strSql.Append(" FROM ps_epicor_vendor ");
		if(strWhere.Trim()!="")
		{
			strSql.Append(" where "+strWhere);
		}
		strSql.Append(" order by " + filedOrder);
		return DbHelperSQL.Query(strSql.ToString());
	}

	/// <summary>
	/// 获取记录总数
	/// </summary>
	public int GetRecordCount(string strWhere)
	{
		StringBuilder strSql=new StringBuilder();
		strSql.Append("select count(1) FROM ps_epicor_vendor ");
		if(strWhere.Trim()!="")
		{
			strSql.Append(" where "+strWhere);
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
		StringBuilder strSql=new StringBuilder();
		strSql.Append("SELECT * FROM ( ");
		strSql.Append(" SELECT ROW_NUMBER() OVER (");
		if (!string.IsNullOrEmpty(orderby.Trim()))
		{
			strSql.Append("order by T." + orderby );
		}
		else
		{
			strSql.Append("order by T.ID desc");
		}
		strSql.Append(")AS Row, T.*  from ps_epicor_vendor T ");
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
		strSql.Append("select * FROM  ps_epicor_vendor");
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
		parameters[0].Value = "ps_epicor_vendor";
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


