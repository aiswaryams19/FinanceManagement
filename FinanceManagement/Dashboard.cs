using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManagement
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GetTotalIncomes();
            GetIncomeCount();
            GetLastIncomeDate();
            GetTotalExpense();
            GetExpenseCount();
            GetLastExpenseDate();
            GetMaxIncomes();
            GetMinIncomes();
            GetMaxExpense();
            GetMinExpense();
            GetLastIncome();
            GetLastExpense();
            GetBestIncomeCategory();
            GetBestExpenseCategory();
            GetBalance();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void IncomeLabel_Click(object sender, EventArgs e)
        {
            Incomes Obj = new Incomes();
            Obj.Show();
            this.Hide();
        }

        private void ExpenseLabel_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses();
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

        private void CloseIcon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aiswa\OneDrive\Documents\FinanceManagementDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void GetTotalIncomes()
        {
            try
            {
                conn.Open();
                string query = $"select Sum(IncAmount) from IncomeTable where IncUser='{Login.user}'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                TotalIncomeLabel.Text = "Rs "+ dt.Rows[0][0].ToString();
                conn.Close();
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void GetIncomeCount()
        {
            try
            {
                conn.Open();
                string query = $"select Count(IncAmount) from IncomeTable where IncUser='{Login.user}'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                NoOfIncomeLabel.Text = dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void GetLastIncomeDate()
        {
            try
            {
                conn.Open();
                string query = $"select Max(IncDate) from IncomeTable where IncUser='{Login.user}'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                IncomeDateLabel.Text = IncomeDateLabel.Text + dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void GetMaxIncomes()
        {
            try
            {
                conn.Open();
                string query = $"select Max(IncAmount) from IncomeTable where IncUser='{Login.user}'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MaxIncome.Text = "Rs " + dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void GetMinIncomes()
        {
            try
            {
                conn.Open();
                string query = $"select Min(IncAmount) from IncomeTable where IncUser='{Login.user}'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MinIncome.Text = "Rs " + dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
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
                TotalExpenseLabel.Text = "Rs " + dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void GetExpenseCount()
        {
            try
            {
                conn.Open();
                string query = $"select Count(ExpAmount) from ExpenseTable where ExpUser='{Login.user}'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                NoOfExpenseLabel.Text = dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void GetLastExpenseDate()
        {
            try
            {
                conn.Open();
                string query = $"select Max(ExpDate) from ExpenseTable where ExpUser='{Login.user}'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ExpenseDateLabel.Text = ExpenseDateLabel.Text + " : " + dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void GetMaxExpense()
        {
            try
            {
                conn.Open();
                string query = $"select Max(ExpAmount) from ExpenseTable where ExpUser='{Login.user}'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MaxExpense.Text = "Rs " + dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void GetMinExpense()
        {
            try
            {
                conn.Open();
                string query = $"select Min(ExpAmount) from ExpenseTable where ExpUser='{Login.user}'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MinExpense.Text = "Rs " + dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void GetBalance()
        {
            try
            {
                conn.Open();
                string query1 = $"select Sum(IncAmount) from IncomeTable where IncUser='{Login.user}'";
                SqlDataAdapter sda1 = new SqlDataAdapter(query1, conn);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                int totalIncome = 0;
                if (dt1.Rows.Count > 0 && dt1.Rows[0][0] != DBNull.Value)
                {
                    totalIncome = Convert.ToInt32(dt1.Rows[0][0]);
                }
                string query2 = $"select Sum(ExpAmount) from ExpenseTable where ExpUser='{Login.user}'";
                SqlDataAdapter sda2 = new SqlDataAdapter(query2, conn);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                int totalExpense = 0;
                if (dt2.Rows.Count > 0 && dt2.Rows[0][0] != DBNull.Value)
                {
                    totalExpense = Convert.ToInt32(dt2.Rows[0][0]);
                }
                Balance.Text = "Rs " + (totalIncome - totalExpense).ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void GetLastIncome()
        {
            try
            {
                conn.Open();
                string query = $"select IncName, IncAmount from IncomeTable where IncDate = (select Max(IncDate) from IncomeTable where IncUser='{Login.user}')";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                LastIncome.Text = dt.Rows[0][0].ToString() + " : Rs " + dt.Rows[0][1].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void GetLastExpense()
        {
            try
            {
                conn.Open();
                string query = $"select ExpName, ExpAmount from ExpenseTable where ExpDate = (select Max(ExpDate) from ExpenseTable where ExpUser='{Login.user}')";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                LastExpense.Text = dt.Rows[0][0].ToString() + " : Rs " + dt.Rows[0][1].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void GetBestIncomeCategory()
        {
            try
            {
                conn.Open();
                string query = $"SELECT IncCategory FROM ( SELECT IncCategory, SUM(IncAmount) AS totalIncome FROM IncomeTable WHERE IncUser = '{Login.user}' GROUP BY IncCategory) AS IncomeSummary JOIN ( SELECT MAX(totalIncome) AS maxIncome FROM (SELECT SUM(IncAmount) AS totalIncome FROM IncomeTable WHERE IncUser = '{Login.user}' GROUP BY IncCategory) AS userIncome) AS maxIncomeSummary ON incomeSummary.totalIncome = maxIncomeSummary.maxIncome;";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                BestIncomeCategory.Text = dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
        private void GetBestExpenseCategory()
        {
            try
            {
                conn.Open();
                string query = $"SELECT ExpCategory FROM ( SELECT ExpCategory, SUM(ExpAmount) AS totalExpense FROM ExpenseTable WHERE ExpUser = '{Login.user}' GROUP BY ExpCategory) AS ExpenseSummary JOIN ( SELECT MAX(totalExpense) AS maxExpense FROM (SELECT SUM(ExpAmount) AS totalExpense FROM ExpenseTable WHERE ExpUser = '{Login.user}' GROUP BY ExpCategory) AS userExpense) AS maxExpenseSummary ON ExpenseSummary.totalExpense = maxExpenseSummary.maxExpense;";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                BestExpenseCategory.Text = dt.Rows[0][0].ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
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
