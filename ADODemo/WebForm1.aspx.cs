using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace ADODemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        //    using (SqlConnection con = new SqlConnection(CS))
        //    {
        //        SqlCommand cmd = new SqlCommand("select * from tblStudents", con);
        //        con.Open();
        //        GridView1.DataSource = cmd.ExecuteReader();
        //        GridView1.DataBind();

        //        SqlCommand cmd2 = new SqlCommand("Insert into tblStudents values ('Sepp Kuss', 'Male', 1300)", con);
        //        int TotalRowsAffected = cmd2.ExecuteNonQuery();
        //        Response.Write("Total Rows Inserted = " + TotalRowsAffected.ToString() + "<br/>");

        //        SqlCommand cmd3 = new SqlCommand("Update  tblStudents set TotalMarks =700 where ID = 3", con);
        //        TotalRowsAffected = cmd3.ExecuteNonQuery();
        //        Response.Write("Total Rows Updated = " + TotalRowsAffected.ToString() + "<br/>");
        //    }
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    using (SqlConnection con  = new SqlConnection(CS))
        //    {
        //        SqlCommand cmd = new SqlCommand("spGetName", con);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Name", TextBox1.Text + "%");
        //        con.Open();
        //        GridView1.DataSource = cmd.ExecuteReader();
        //        GridView1.DataBind();
        //    }

        //}


        //protected void txtName_TextChanged(object sender, EventArgs e)
        //{
        //    // Your event handler code here
        //}

        //protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Your event handler code here
        //}



        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(CS))
        //    {
        //        SqlCommand cmd = new SqlCommand("spAddEmployees", con);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@Name", txtName.Text);
        //        cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
        //        cmd.Parameters.AddWithValue("@Marks", txtMarks.Text);

        //        SqlParameter outputParameter = new SqlParameter();
        //        outputParameter.ParameterName = "EmployeeId";
        //        outputParameter.SqlDbType = System.Data.SqlDbType.Int;
        //        outputParameter.Direction = System.Data.ParameterDirection.Output;
        //        cmd.Parameters.Add(outputParameter);

        //        con.Open();
        //        cmd.ExecuteNonQuery();

        //        string EmpId = outputParameter.Value.ToString();

        //        lblMessage.Text = "EmployeeId=" + EmpId;
        //    }
        //}

        //protected void page_Load(object sender, EventArgs e)
        //{
        //    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(CS))
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("Select Name, TotalMarks, (TotalMarks * 0.9) as DiscountedMarks from tblEmployees", con);
        //        using (SqlDataReader rdr = cmd.ExecuteReader())
        //        {
                    
        //            //DataTable table = new DataTable();
        //            //table.Columns.Add("Name");
        //            //table.Columns.Add("TotalMarks");
        //            //table.Columns.Add("DiscountedMarks");

        //            //while (rdr.Read())
        //            //{
        //            //    DataRow dataRow = table.NewRow();

        //            //    int OriginalMarks = Convert.ToInt32(rdr["TotalMarks"]);
        //            //    double DiscountedMarks = OriginalMarks * 0.9;

        //            //    dataRow["Name"] = rdr["Name"];
        //            //    dataRow["TotalMarks"] = OriginalMarks;
        //            //    dataRow["DiscountedMarks"] = DiscountedMarks;
        //            //    table.Rows.Add(dataRow);
        //            //}

        //            GridView1.DataSource = rdr;
        //            GridView1.DataBind();
        //        }

        //    }
        //}

        //protected void page_Load(object sender, EventArgs e)
        //{
        //    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(CS))
        //    {
        //        SqlCommand cmd = new SqlCommand("select * from tblEmployees; select * from tblEmployer", con);
        //        con.Open();
        //        using(SqlDataReader rdr = cmd.ExecuteReader())
        //        {
        //            EmployeeGridView.DataSource = rdr;
        //            EmployeeGridView.DataBind();

        //            while (rdr.NextResult())
        //            {
        //                EmployerGridView.DataSource = rdr;
        //                EmployerGridView.DataBind();
        //            }
                    
        //        }
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the SelectedIndexChanged event if needed
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("spGetEmployeesByName", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Name", TextBox1.Text);

                DataSet ds = new DataSet();
                da.Fill(ds);

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
    }
}