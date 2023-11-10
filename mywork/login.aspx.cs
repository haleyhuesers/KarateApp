using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateApp.mywork
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        SqlConnection dbcon;
        // change connection string if needed
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\hhues\\OneDrive\\Desktop\\KarateApp\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string userName = Login1.UserName;
            string pass = Login1.Password;

            string userType = "";
            string dbUser = "";
            string dbPass = "";

            // gets user information from table
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                string query = "SELECT UserType, UserName, UserPassword FROM NetUser WHERE UserName = @UserName;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userType = reader["UserType"].ToString();
                            dbUser = reader["UserName"].ToString();
                            dbPass = reader["UserPassword"].ToString();
                        }
                    }
                }
            }

            // checks to see which page to redirect to
            if (userType == "Member" && dbUser == userName && dbPass == pass)
            {
                FormsAuthentication.RedirectFromLoginPage(userName, true);
                Response.Redirect("member.aspx", true);
            }
            else if (userType == "Instructor" && dbUser == userName && dbPass == pass)
            {
                FormsAuthentication.RedirectFromLoginPage(userName, true);
                Response.Redirect("instructor.aspx", true);
            }
            else if (userType == "Administrator" && dbUser == userName && dbPass == pass)
            {
                FormsAuthentication.RedirectFromLoginPage(userName, true);
                Response.Redirect("administrator.aspx", true);
            }
            else
                Response.Redirect("login.aspx", true);


        }
    }
}