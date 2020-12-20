using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
namespace DatabaseExamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";
            //cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;User Id=sa;Password=sa";

            //Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trainings\JKDec20\Sample.mdf;Integrated Security=True;Connect Timeout=30
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "insert into Employees values(1,'Vikram',10000, 10)";
            // )
            cmd.CommandText = "insert into Employees values(" + txtEmpNo.Text + ",'" + txtName.Text + "',"  
                + txtBasic.Text + "," + txtDeptNo.Text +  ")";
            MessageBox.Show(cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("okay");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



            cn.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
 
            cmd.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Basic", txtBasic.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);

            //MessageBox.Show(cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("okay");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



            cn.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "InsertEmployee";

            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Basic", txtBasic.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);

            //MessageBox.Show(cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("okay");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            cn.Close();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";
            cn.Open();
            SqlTransaction t = cn.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Transaction = t;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Employees values(300,'new emp',12345,10)";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = cn;
            cmd2.Transaction = t;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "insert into Employees values(300,'new emp2',12345,10)";
            try
            {
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                t.Commit();
                MessageBox.Show("commit");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                t.Rollback();
            }
            finally
            {
                cn.Close();
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select count(*) from Employees";
            MessageBox.Show(cmd.ExecuteScalar().ToString());

            cn.Close();
        }
    }
}
