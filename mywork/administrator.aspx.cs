using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateApp.mywork
{
    public partial class administrator : System.Web.UI.Page
    {
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\hhues\\OneDrive\\Desktop\\KarateApp\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        //string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\reidm\\OneDrive\\Desktop\\assignment4\\KarateApp\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMembersGridView();
                BindInstructorGridView();
            }
        }

        private void BindMembersGridView()
        {
            using (KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn))
            {
                // LINQ query to retrieve the required data
                var query = from member in dbcon.Members
                            select new
                            {
                                FirstName = member.MemberFirstName,
                                LastName = member.MemberLastName,
                                PhoneNumber = member.MemberPhoneNumber,
                                DateJoined = member.MemberDateJoined
                            };

                // Bind the LINQ query result to the GridView control
                membersGridView.DataSource = query.ToList();
                membersGridView.DataBind();
            }
        }

        private void BindInstructorGridView()
        {
            using (KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn))
            {
                // LINQ query to retrieve the first and last names of all instructors
                var query = from instructor in dbcon.Instructors
                            select new
                            {
                                FirstName = instructor.InstructorFirstName,
                                LastName = instructor.InstructorLastName
                            };

                // Bind the LINQ query result to the GridView control
                instructorGridView.DataSource = query.ToList();
                instructorGridView.DataBind();
            }
        }

        protected void deleteMemberBtn_Click(object sender, EventArgs e)
        {
            using (KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn))
            {
                try { 
                    string fName = dltMemfNameBox.Text;
                    string lName = dltMemlNameBox.Text;

                    // Find all records with the member
                    Member memberToDelete = dbcon.Members.FirstOrDefault(
                        m => m.MemberFirstName == fName && m.MemberLastName == lName);
                    NetUser userToDelete = dbcon.NetUsers.FirstOrDefault(
                        u => u.UserID == memberToDelete.Member_UserID);
                    Section sectionToDelete = dbcon.Sections.FirstOrDefault(
                        s => s.Member_ID == memberToDelete.Member_UserID);

                    if (memberToDelete != null)
                    {
                        // Remove all instances of the member
                        dbcon.Members.DeleteOnSubmit(memberToDelete);
                        dbcon.NetUsers.DeleteOnSubmit(userToDelete);
                    }
                    if (sectionToDelete != null)
                    {
                        dbcon.Sections.DeleteOnSubmit(sectionToDelete);
                    }
                    // Save changes to the database
                    dbcon.SubmitChanges();

                }
                catch (Exception ex)
                {
                    Response.Write("Make sure member exists.");
                }
            }
            BindMembersGridView();
        }

        protected void deleteInstructorBtn_Click(object sender, EventArgs e)
        {
            using (KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn))
            {
                try
                {
                    string fName = dltInsfNameBox.Text;
                    string lName = dltInslNameBox.Text;

                    // Find all records with the instructor
                    Instructor instructorToDelete = dbcon.Instructors.FirstOrDefault(
                        i => i.InstructorFirstName == fName && i.InstructorLastName == lName);
                    NetUser userToDelete = dbcon.NetUsers.FirstOrDefault(
                        u => u.UserID == instructorToDelete.InstructorID);
                    Section sectionToDelete = dbcon.Sections.FirstOrDefault(
                        s => s.Instructor_ID == instructorToDelete.InstructorID);

                    if (instructorToDelete != null)
                    {
                        // Remove all instances of the instructor
                        dbcon.Instructors.DeleteOnSubmit(instructorToDelete);
                        dbcon.NetUsers.DeleteOnSubmit(userToDelete);
                    }
                    if (sectionToDelete != null)
                    {
                        dbcon.Sections.DeleteOnSubmit(sectionToDelete);
                    }
                    // Save changes to the database
                    dbcon.SubmitChanges();

                }
                catch (Exception ex)
                {
                    Response.Write("Make sure instructor exists.");
                }
            }
            BindInstructorGridView();
        }

        protected void addMemberBtn_Click(object sender, EventArgs e)
        {
            using (KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn))
            {
                // Create a new NetUser
                NetUser newUser = new NetUser
                {
                    UserName = addMemUsrNameBox.Text,
                    UserPassword = addMemPwdBox.Text,
                    UserType = "Member",
                };
                dbcon.NetUsers.InsertOnSubmit(newUser);
                dbcon.SubmitChanges();

                // Create a new Member
                Member newMember = new Member
                {
                    Member_UserID = newUser.UserID,
                    MemberFirstName = addMemfNameBox.Text,
                    MemberLastName = addMemlNameBox.Text,
                    MemberDateJoined = DateTime.Now,
                    MemberPhoneNumber = addMemPhoneBox.Text,
                    MemberEmail = addMemEmailBox.Text,
                };

                // Add the new member to the membe and user to the tables

                dbcon.Members.InsertOnSubmit(newMember);

                // Save changes to the database
                dbcon.SubmitChanges();
            }
            BindMembersGridView();
        }

        protected void addInstructorBtn_Click(object sender, EventArgs e)
        {
            using (KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn))
            {
                // Create a new NetUser
                NetUser newUser = new NetUser
                {
                    UserName = addInsUsrNameBox.Text,
                    UserPassword = addInsPwdBox.Text,
                    UserType = "Instructor",
                };
                // add new NetUser and save changes
                dbcon.NetUsers.InsertOnSubmit(newUser);
                dbcon.SubmitChanges();

                // Create a new Instructor
                Instructor newInstructor = new Instructor
                {
                    InstructorID = newUser.UserID,
                    InstructorFirstName = addInsfNameBox.Text,
                    InstructorLastName = addInslNameBox.Text,
                    InstructorPhoneNumber = addInsPhoneBox.Text,
                };

                // Add the new instructor to the table
                dbcon.Instructors.InsertOnSubmit(newInstructor);
                // Save changes to the database
                dbcon.SubmitChanges();
            }
            BindInstructorGridView();
        }

        protected void addToSectionBtn_Click(object sender, EventArgs e)
        {
            using (KarateSchoolDataContext dbcon = new KarateSchoolDataContext(conn))
            {
                // Create a new Section
                Section newSection = new Section
                {
                    SectionName = RadioButtonList1.SelectedValue.ToString(),
                    SectionStartDate = DateTime.Now,
                    Member_ID = int.Parse(memDropDownList.SelectedValue),
                    Instructor_ID = int.Parse(insDropDownList.SelectedValue),
                    SectionFee = decimal.Parse(feeTextBox.Text),
                };
                // add new section and save changes
                dbcon.Sections.InsertOnSubmit(newSection);
                dbcon.SubmitChanges();
            }

        }
    }
}