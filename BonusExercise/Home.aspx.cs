using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Text.RegularExpressions;


namespace BonusExercise
{
    public partial class Home : System.Web.UI.Page
    {
        DBAccess objdBAccess = new DBAccess();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable x = new DataTable();

            string query = "select * from users;";
            objdBAccess.readDatathroughAdapter(query, x);
            dataGridView1.DataSource = x;
            dataGridView1.DataBind();
            
            objdBAccess.closeConn();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblNotify.Text = "";
            if (btnSave.Text == "Save") { 
            
            DBAccess objdBAccess = new DBAccess();
            DataTable dtUsers = new DataTable();

            string userName = txtUserName.Text;
            string userID = txtUserid.Text;
                bool IsStrictlyNumeric(string input)
                {
                    return Regex.IsMatch(input, @"^[0-9]+$");
                }
                
               if (userID.Equals(""))
            {
                lblNotify.Text = "Please a number id.";
            }
               else if (!IsStrictlyNumeric(userID)) { lblNotify.Text = "only number is allowed for id."; }
                else if (userName.Equals(""))
            {
                lblNotify.Text = "Please enter your name.";
            }
            else
            {
                    DataTable dx= new DataTable();
                    string query = "select * from users where userid="+userID +";";
                    objdBAccess.readDatathroughAdapter(query, dx);
                    
                    if (dx.Rows.Count == 0)
                    {

                    

                    string inscmd = "insert into users(userid,username) values (@userID,@userName)";
                SqlCommand insertcmd = new SqlCommand(inscmd);
                insertcmd.Parameters.AddWithValue("@userName", userName);
                insertcmd.Parameters.AddWithValue("@userID", userID);  
                int row = objdBAccess.executeQuery(insertcmd);
                        lblNotify.Text = "successfuly created";

                

                if (row > 0)
                {
                            lblNotify.Text = "";
                        string qry = "select * from users;";
                    objdBAccess.readDatathroughAdapter(qry, dtUsers);
                    dataGridView1.DataSource = dtUsers;
                    dataGridView1.DataBind();

                    objdBAccess.closeConn();

                }
                else
                {
                        lblNotify.Text = "error ";

                }
                    }
                    else
                    {

                        lblNotify.Text = "username is already avaliable";

                    }

                }
            }
            else if (btnSave.Text == "Update")
            {
                String userName = txtUserName.Text;
                int userID = Convert.ToInt32( txtUserid.Text);

                string cmd = "Update users set username=@userName where userid=" + userID + ";";
                SqlCommand updatecmd = new SqlCommand(cmd);
                updatecmd.Parameters.AddWithValue("@userName", userName);
                updatecmd.Parameters.AddWithValue("@userID", userID);
              
                int row = objdBAccess.executeQuery(updatecmd);
                Response.Redirect(Request.RawUrl);

                objdBAccess.closeConn();

            } 

        }



        protected void dataGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandName = e.CommandName;
            int rowIndex = Convert.ToInt32(e.CommandArgument);
         
            
            // Retrieve the UserID
            int userID = Convert.ToInt32(dataGridView1.DataKeys[rowIndex].Value);
            

            if (commandName == "Delete")
            {

               /* btnSave.Text = "Save";
                txtUserid.ReadOnly = true;*/
                string query = "delete from users where userid=" + Convert.ToInt32( userID)+ ";";
                    SqlCommand deletecmd = new SqlCommand(query);
                    objdBAccess.executeQuery(deletecmd);
                DataTable dtu = new DataTable();

                string queryy = "select * from users;";
                objdBAccess.readDatathroughAdapter(queryy, dtu);
                Response.Redirect(Request.RawUrl);

                objdBAccess.closeConn();

            }
           else if (commandName == "broUpdate")
            {
                
                DBAccess objdBAccess = new DBAccess();
                DataTable dtUsers = new DataTable();
            
                    SqlCommand lOGINcmd = new SqlCommand();
                    lOGINcmd.CommandText = "select * from users where userid = @userID  ;";
                    lOGINcmd.Parameters.AddWithValue("@userID", userID);
                    objdBAccess.readDatathroughAdapterSql(lOGINcmd, dtUsers);
                objdBAccess.closeConn();

                txtUserid.Text = dtUsers.Rows[0]["userid"].ToString();
                txtUserName.Text = dtUsers.Rows[0]["username"].ToString();

                txtUserid.ReadOnly = true;
                btnSave.Text = "Update";


            }





        }
    }
}