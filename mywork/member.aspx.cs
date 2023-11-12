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
        /*LoginP loginPage = new LoginP();*/
        SqlConnection dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\reidm\\OneDrive\\Desktop\\assignment4\\KarateApp\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
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

                    using (KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn))
                    {
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
                            Label1.Text = memberInfo.FirstName;
                            Label2.Text = memberInfo.LastName;
                        }
                    }

                    // Set labels to display first name and last name
                    /*                    if (dataTable.Rows.Count > 0)
                                        {
                                            Label1.Text = dataTable.Rows[0]["InstructorFirstName"].ToString();
                                            Label2.Text = dataTable.Rows[0]["InstructorLastName"].ToString();
                                        }
                    */
                }
            }


             int GetMemberIDByUsername(string username)
            {
                // Retrieve member ID based on username
                // This could involve querying your database or using another authentication method
                // For the sake of this example, we're assuming the username is the member ID
                int memberID;
                if (int.TryParse(username, out memberID))
                {
                    return memberID;
                }
                else
                {
                    return -1; // Replace with an appropriate default or error handling
                }
            }
            

        }
    }
}