using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManagement
{
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
            GetTotalExpense();
        }

        private void DashboardLabel_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void IncomeLabel_Click(object sender, EventArgs e)
        {
            Incomes Obj = new Incomes();
            Obj.Show();
            this.Hide();
        }

        private void ViewIncomeLabel_Click(object sender, EventArgs e)
        {
            ViewIncomes Obj = new ViewIncomes();
            Obj.Show();
            this.Hide();
        }

        private void ViewExpenseLabel_Click(object sender, EventArgs e)
        {
            ViewExpenses Obj = new ViewExpenses();
            Obj.Show();
            this.Hide();
        }

        private void ExpenseNameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ExpenseAmountTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExpenseDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ExpenseDescription_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aiswa\OneDrive\Documents\FinanceManagementDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void ExpenseSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ExpenseNameTB.Text) || string.IsNullOrEmpty(ExpenseAmountTB.Text) || string.IsNullOrEmpty(ExpenseDescription.Text) || string.IsNullOrEmpty(Category.Text))
            {
                MessageBox.Show("Missing Informations");
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("insert into ExpenseTable(ExpName, ExpAmount, ExpDescription, ExpCategory, ExpDate, ExpUser) values (@EName, @EAmt, @EDesc, @ECat, @EDate, @EUser)", conn);
                    command.Parameters.AddWithValue("@EName", ExpenseNameTB.Text);
                    command.Parameters.AddWithValue("@EAmt", ExpenseAmountTB.Text);
                    command.Parameters.AddWithValue("@EDesc", ExpenseDescription.Text);
                    command.Parameters.AddWithValue("@ECat", Category.SelectedItem.ToString());
                    //command.Parameters.AddWithValue("@UDOB", DOB.Text);
                    DateTime expenseDate;
                    if (DateTime.TryParseExact(ExpenseDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out expenseDate))
                    {
                        if (expenseDate >= SqlDateTime.MinValue.Value && expenseDate <= SqlDateTime.MaxValue.Value)
                        {
                            // Date is within the valid range, add it as a parameter
                            command.Parameters.AddWithValue("@EDate", SqlDbType.DateTime2).Value = expenseDate;
                        }
                    }
                    else
                    {
                        // Date string couldn't be parsed, handle error or display message to the user
                        MessageBox.Show("Invalid date format");
                        Clear();
                    }
                    //command.Parameters.AddWithValue("@EDate", ExpenseDate.Text);
                    command.Parameters.AddWithValue("@EUser", Login.user);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Expense Added !!!");
                    conn.Close();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    conn.Close();
                    Clear();
                }
            }
        }

        private void Clear()
        {
            ExpenseNameTB.Text = string.Empty;
            ExpenseDescription.Text = string.Empty;
            Category.SelectedIndex = 0;
            ExpenseAmountTB.Text = string.Empty;
            ExpenseDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }
        private void GetTotalExpense()
        {
            try
            {
                conn.Open();
                string query = $"select Sum(ExpAmount) from ExpenseTable where ExpUser='{Login.user}'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                TotalExpense.Text = "Rs " + dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void CloseIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogoutIcon_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void LogoutLabel_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
