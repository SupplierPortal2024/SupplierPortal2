using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tools_downloadfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sGenName = Request.QueryString["fileName"]; // 获取文件名
        string fileName = "";
        if (sGenName != "")
        {
            fileName = sGenName.Split('/')[sGenName.Split('/').Length - 1].ToString();
            System.IO.FileStream fs = null;
            fs = System.IO.File.Open(Server.MapPath(sGenName), System.IO.FileMode.Open);
            byte[] btFile = new byte[fs.Length];
            fs.Read(btFile, 0, Convert.ToInt32(fs.Length)); //将文件读到数组中
            fs.Close();
            Response.AddHeader("Content-disposition", "attachment; filename=" + fileName); //告诉浏览器我们发送给它的是一个附件类型的文件
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(btFile);
            Response.End();
        }

    }
}