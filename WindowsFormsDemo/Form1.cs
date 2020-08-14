using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=RoleBase;Integrated Security=False");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            cmd.Connection = connection;

            string sqlStr = "select * From Role";

            cmd.CommandText = sqlStr;

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            //da.Fill(ds,"ds");
            da.Fill(dt);
            dataGridView1.DataSource = ds;

            //使用DataSet繫結時，必須同時指明DateMember
            //this.dataGridView1.DataSource = ds;
            //this.dataGridView1.DataMember = "ds";

            //也可以直接用DataTable來繫結
            // this.dataGridView1.DataSource = ds.Tables["ds"];
            this.dataGridView1.DataSource = dt;
        }

        public void Memo()
        {
            //https://www.itread01.com/article/1537408515.html
            //// DataSet 、DataTable
            //// 方式1
            //DataSet ds = new DataSet();
            //this.dataGridView1.DataSource = ds.Table[0];
            //this.dataGridView1.DataSource = ds.Tables["表名"];
            //// 方式2
            //DataTable dt = new DataTable();
            //this.dataGridView1.DataSource = dt;

            //// DataView
            //DataView dv = new DataView();
            //this.dataGridView1.DataSource = dv;

            //// 設定了DataMember
            //DataSet ds = new DataSet();
            //this.dataGridView1.DataSource = ds;
            //this.dataGridView1.DataMember = "表名";

            //// ArrayList
            //ArrayList Al = new ArrayList();
            //this.dataGridView1.DataSource = Al;

            //// dic
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //this.dataGridView1.DataSource = dic;

            //// List<Object>
            //this.dataGridVi.DataSource = new BindingList<Object>(List<Object>);
        }
    }
}
