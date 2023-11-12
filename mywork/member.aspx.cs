using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace KarateApp.mywork
{
    public partial class member : System.Web.UI.Page
    {
        
        SqlConnection dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\reidm\\OneDrive\\Desktop\\assignment4\\KarateApp\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //checks if user is authenticated 
            if (User.Identity.IsAuthenticated)
            {
                //gets username of authenticated
                string username = User.Identity.Name;
                //creates an instance of the login page 
                login loginPage = new login();

                // Get the current member's ID from your authentication mechanism
                int currentMemberID = loginPage.GetUserID(username);

                // SQL query to retrieve member information
                var query = "SELECT " +
                    "S.SectionName, " +
                    "I.InstructorFirstName, " +
                    "I.InstructorLastName, " +
                    "S.SectionStartDate, " +
                    "S.SectionFee " +
                    "FROM Section S " +
                    "JOIN Instructor I ON S.Instructor_ID = I.InstructorID " +
                    "WHERE S.Member_ID = @MemberID;";

                //connects to database
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    // Open the database connection
                    connection.Open();

                    // Create a data adapter and DataTable to fetch and store data
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@MemberID", currentMemberID);
                    var dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    // Set the GridView's data source and bind the data
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();

                    //retrieves member info
                    using (KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn))
                    {
                        //query the members table to get first and last name 
                        var memberInfo = dbcon.Members
                        .Where(m => m.Member_UserID == currentMemberID)
                        .Select(m => new
                        {
                            FirstName = m.MemberFirstName,
                            LastName = m.MemberLastName
                            // Add other properties you want to retrieve
                        })
                        .FirstOrDefault();

                        if (memberInfo != null)
                        {
                            //displays inof in text box
                            Label1.Text = memberInfo.FirstName;
                            Label2.Text = memberInfo.LastName;
                        }
                    }

                }
            }

            

        }
    }
}