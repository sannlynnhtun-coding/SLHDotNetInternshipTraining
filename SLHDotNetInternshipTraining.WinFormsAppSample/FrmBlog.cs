using Dapper;
using Microsoft.Data.SqlClient;
using SLHDotNetInternshipTraining.EFCoreSample2.Database.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLHDotNetInternshipTraining.WinFormsAppSample
{
    public partial class FrmBlog : Form
    {
        private readonly SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "SLHDotNetInternshipTraining",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public FrmBlog()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //AppDbContext
            string query = @"INSERT INTO Tbl_Blog
    (
        BlogTitle,
        BlogAuthor,
        BlogContent
    )
    VALUES
    (
        @BlogTitle,
        @BlogAuthor,
        @BlogContent
    )";

            Blog blog = new Blog()
            {
                BlogTitle = txtTitle.Text,
                BlogAuthor = txtAuthor.Text,
                BlogContent = txtContent.Text
            };

            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            db.Open();

            int result = db.Execute(query, blog);

            if (result > 0)
            {
                MessageBox.Show("Saving Successful");
                ClearControls();
                BindData();
            }
            else
            {
                MessageBox.Show("Saving Failed");
            }
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void FrmBlog_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            db.Open();
            dataGridView1.DataSource = db.Query<Blog>("select * from Tbl_Blog");
        }

        private void ClearControls()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }
    }
}
