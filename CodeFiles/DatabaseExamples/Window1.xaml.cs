using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace DatabaseExamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees";


            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
               // dr.GetString(1)
               //dr.GetInt32(0)

                lstNames.Items.Add(dr["Name"]);
                //lstNames.Items.Add(dr[1]);
            }
            dr.Close();

            cn.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees;select * from Departments";


            SqlDataReader dr = cmd.ExecuteReader();
            lstNames.Items.Add("EMPS");

            while (dr.Read())
            {

                lstNames.Items.Add(dr["Name"]);
            }

            lstNames.Items.Add("DEPTS");

            dr.NextResult();
            while(dr.Read())
            {
                lstNames.Items.Add(dr["DeptName"]);

            }

            dr.Close();

            cn.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;MultipleActiveResultSets=true";
            cn.Open();

            SqlCommand cmdDepts = new SqlCommand();
            cmdDepts.Connection = cn;
            cmdDepts.CommandType = CommandType.Text;
            cmdDepts.CommandText = "Select * from Departments";

            SqlCommand cmdEmps = new SqlCommand();
            cmdEmps.Connection = cn;
            cmdEmps.CommandType = CommandType.Text;

            SqlDataReader drDepts = cmdDepts.ExecuteReader();
            while (drDepts.Read())
            {
                lstNames.Items.Add(drDepts["DeptName"]);

                cmdEmps.CommandText = "Select * from Employees where DeptNo = " + drDepts["DeptNo"];
                SqlDataReader drEmps = cmdEmps.ExecuteReader();
                while (drEmps.Read())
                {
                    lstNames.Items.Add("    " + drEmps["Name"]);
                }
                drEmps.Close();
            }
            drDepts.Close();
            cn.Close();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlDataReader dr = GetDataReader();
            while (dr.Read())
            {
                lstNames.Items.Add(dr["Name"]);
            }
            dr.Close();
            //MessageBox.Show(cn.State.ToString());
        }

        private SqlDataReader GetDataReader()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Employees";
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //SqlDataReader dr = cmd.ExecuteReader();
            //cn.Close();
            return dr;
        }
    }
}
