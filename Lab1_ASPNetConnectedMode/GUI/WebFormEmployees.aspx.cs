using Lab1_ASPNetConnectedMode.BLL;
using Lab1_ASPNetConnectedMode.VALIDATION;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Lab1_ASPNetConnectedMode.GUI
{
    public partial class WebFormEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //1st time the page is loaded only, just once
                DropDownListSearchOption.Items.Add("Employee ID");
                DropDownListSearchOption.Items.Add("First Name");
                DropDownListSearchOption.Items.Add("Last Name");
                DropDownListSearchOption.Items.Add("Job Title");
            }
        }

   

        protected void ButtonList_Click(object sender, EventArgs e)
        {
            BLL.Employee employees = new BLL.Employee();
            GridViewEmployees.DataSource = employees.GetAllEmployees();// Assuming GetAllCustomers returns a list or dataset of customers
            GridViewEmployees.DataBind();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            
                //Employee id Validation
                string input = TextBoxEmpId.Text.Trim();
                if (!Validation.IsValidId(input, 4))
                {
                    MessageBox.Show("EmployeeId must be 4-digit number.\n" + "Please enter another one.", "Invalid Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBoxEmpId.Text = "";
                    TextBoxEmpId.Focus();
                    return;
                }

                //Validate dupliacate id
                BLL.Employee emp = new BLL.Employee();
                if (emp.IsDuplicateEmployeeId(Convert.ToInt32(input)))
                {
                    MessageBox.Show("This CustomerId already exists.\n" + "Please enter another one.", "Duplicate CustomerId", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBoxEmpId.Text = "";
                    TextBoxEmpId.Focus();
                    return;
                }

                //First Name Validation
                input = TextBoxFirstN.Text.Trim();
                if (!Validation.IsValidName(input))
                {
                    MessageBox.Show("Invalid FirstName.\n" + "PLease enter another one.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBoxFirstN.Text = "";
                    TextBoxFirstN.Focus();
                    return;
                }

                //validate LastName
                input = TextBoxLastN.Text.Trim();
                if (!Validation.IsValidName(input))
                {
                    MessageBox.Show("Invalid LastName.\n" + "PLease enter another one.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBoxLastN.Text = "";
                    TextBoxLastN.Focus();
                    return;
                }

                //validate job title
                input = TextBoxJobT.Text.Trim();
                if (!Validation.IsValidName(input))
                {
                    MessageBox.Show("Invalid Job Title.\n" + "PLease enter another one.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextBoxJobT.Text = "";
                    TextBoxJobT.Focus();
                    return;

                }

                emp.EmployeeId = Convert.ToInt32(TextBoxEmpId.Text.Trim());
                emp.FirstName = TextBoxFirstN.Text.Trim();
                emp.LastName = TextBoxLastN.Text.Trim();
                emp.JobTitle = TextBoxJobT.Text.Trim();

                emp.SaveEmployee(emp);
                MessageBox.Show("Employee added successfully.", "Confirmation");
            
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BLL.Employee emp = new BLL.Employee();
            string input = TextBoxSearch.Text.Trim();
            List<BLL.Employee> listE =new List<BLL.Employee>();
            switch (DropDownListSearchOption.SelectedIndex)
            {
                case 0: //search by empId
                   // input = TextBoxSearch.Text.Trim();
                    if (!Validation.IsValidId(input, 4))
                    {
                        MessageBox.Show("CustomerId must be 4-digit number.\n" + "Please enter another one.", "Invalid Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TextBoxSearch.Text = "";
                        TextBoxSearch.Focus();
                        return;

                    }
                    emp = emp.SearchEmployee(Convert.ToInt32(TextBoxSearch.Text.Trim()));
                    if (emp != null) // customer found
                    {
                        TextBoxEmpId.Text = emp.EmployeeId.ToString();
                        TextBoxFirstN.Text = emp.FirstName.ToString();
                        TextBoxLastN.Text = emp.LastName.ToString();
                        TextBoxJobT.Text = emp.JobTitle.ToString();

                    }
                    else   // not found
                    {
                        TextBoxSearch.Text = "";
                        TextBoxSearch.Focus();
                        MessageBox.Show("Employee not found!", "Invalid Employee ID");
                    }
                    break;

                case 1: //search by FirstName

                    listE = emp.SearchEmployee(input, "FirstName");
                    if (listE.Count > 0)
                    {
                        GridViewEmployees.DataSource = listE;
                        GridViewEmployees.DataBind();
                    }
                    else
                    {
                        MessageBox.Show("No employees found with the given First Name.", "Search Result");
                    }
                    break;
                case 2: //search by LastName
                    listE = emp.SearchEmployee(input, "LastName");
                    if (listE.Count > 0)
                    {
                        GridViewEmployees.DataSource = listE;
                        GridViewEmployees.DataBind();
                    }
                    else
                    {
                        MessageBox.Show("No employees found with the given Last Name.", "Search Result");
                    }
                    break;

                case 3: //search by JobTitle
                    listE = emp.SearchEmployee(input, "JobTitle");
                    if (listE.Count > 0)
                    {
                        GridViewEmployees.DataSource = listE;
                        GridViewEmployees.DataBind();
                    }
                    else
                    {
                        MessageBox.Show("No employees found with the given Job Title.", "Search Result");
                    }
                    break;
                default:
                    break;

            }

        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
           
                BLL.Employee emp = new BLL.Employee();
                emp.EmployeeId = Convert.ToInt32(TextBoxEmpId.Text.Trim());
                emp.FirstName = TextBoxFirstN.Text.Trim();
                emp.LastName = TextBoxLastN.Text.Trim();
                emp.JobTitle = TextBoxJobT.Text.Trim();

                emp.UpdateEmployee(emp);

                MessageBox.Show("Employee Updated!");

                //to refresh
                ButtonList_Click(sender, e);
            
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            // Get the employee ID from the TextBoxSearch
            int employeeId;
            bool isValidId = int.TryParse(TextBoxSearch.Text.Trim(), out employeeId);

            if (isValidId)
            {
                BLL.Employee emp = new BLL.Employee();
                emp.DeleteEmployee(employeeId);

                MessageBox.Show("Employee deleted successfully.");

                ButtonList_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Please enter a valid Employee ID.");
            }
        }

        protected void DropDownListSearchOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownListSearchOption.SelectedIndex)
            {
                case 0:// search by EmpId
                    LabelDisplay.Text = "Please enter Employee ID.";
                    break;
                case 1:// search by FirstName
                    LabelDisplay.Text = "Please enter FirstName.";
                    break;
                case 2:// search by LastName
                    LabelDisplay.Text = "Please enter LastName.";
                    break;
                case 3:
                    LabelDisplay.Text = "Please enter Job Title";
                    break;
                default:
                    break;
            }

        }
    }
}