using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=PC339\SQL2008;Initial Catalog=asdasd;Integrated Security=True");
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGRid();
            }
        }

        private void FillGRid()
        {
            da = new SqlDataAdapter("select * from userinfo",con);
            dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            FillGRid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int UserID = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value);
            cmd = new SqlCommand("delete from userinfo where userid=@UID", con);
            cmd.Parameters.AddWithValue("@UID", UserID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            FillGRid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            FillGRid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtfname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtfname");
            TextBox txtlname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtlname");
            int UserID = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value);
            cmd = new SqlCommand("update userinfo set fname=@Fname,lname=@Lname where userid=@UID", con);
            cmd.Parameters.AddWithValue("@Fname", txtfname.Text);
            cmd.Parameters.AddWithValue("@Lname", txtlname.Text);
            cmd.Parameters.AddWithValue("@UID", UserID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            FillGRid();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ADD")
            {
                TextBox txtfname = (TextBox)GridView1.HeaderRow.FindControl("TextBox1");
                TextBox txtlname = (TextBox)GridView1.HeaderRow.FindControl("TextBox2");
                cmd = new SqlCommand("insert into userinfo values(@Fname,@Lname)",con);
                cmd.Parameters.AddWithValue("@Fname", txtfname.Text);
                cmd.Parameters.AddWithValue("@Lname", txtlname.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                FillGRid();
            }
        }
    }
}