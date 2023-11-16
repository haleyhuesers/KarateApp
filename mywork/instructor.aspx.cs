using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateApp.mywork
{
    public partial class instructor : System.Web.UI.Page
    {
        SqlConnection dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\hhues\\OneDrive\\Desktop\\KarateApp\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        //string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\reidm\\OneDrive\\Desktop\\assignment4\\KarateApp\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
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
                int currentInstructorID = loginPage.GetUserID(username);

                // SQL query to retrieve member information
                var instructorQuery = "SELECT InstructorFirstName, InstructorLastName FROM Instructor WHERE InstructorID = @InstructorID;";

                // SQL query to retrieve section information for the instructor
                var sectionQuery = "SELECT S.SectionName, M.MemberFirstName, M.MemberLastName " +
                                   "FROM Section S " +
                                   "JOIN Member M ON S.Member_ID = M.Member_UserID " +
                                   "WHERE S.Instructor_ID = @InstructorID;";

                //connects to database
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    // Open the database connection
                    connection.Open();

                    using (SqlCommand instructorCmd = new SqlCommand(instructorQuery, connection))
                    {
                        instructorCmd.Parameters.AddWithValue("@InstructorID", currentInstructorID);

                        using (SqlDataReader instructorReader = instructorCmd.ExecuteReader())
                        {
                            if (instructorReader.Read())
                            {
                                // Display instructor information
                                Label1.Text = instructorReader["InstructorFirstName"].ToString();
                                Label2.Text = instructorReader["InstructorLastName"].ToString();
                            }
                        }
                    }

                    using (SqlCommand sectionCmd = new SqlCommand(sectionQuery, connection))
                    {
                        sectionCmd.Parameters.AddWithValue("@InstructorID", currentInstructorID);

                        // Create a data adapter and DataTable to fetch and store data
                        SqlDataAdapter adapter = new SqlDataAdapter(sectionCmd);
                        var dataTable = new System.Data.DataTable();
                        adapter.Fill(dataTable);

                        // Set the GridView's data source and bind the data
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }

                    

                }
            }
        }
    }
}