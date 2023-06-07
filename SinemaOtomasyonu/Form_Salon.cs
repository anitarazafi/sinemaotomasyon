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

namespace SinemaOtomasyonu
{
    public partial class Form_Salon : Form
    {
        public Form_Salon()
        {
            InitializeComponent();
        }

        private void btn_salon_ekle_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO salonlar (numara) VALUES (@numara)";

            SqlCommand cmd = new SqlCommand(query, Database.SqlConnection);

            SqlParameter numaraParameter = new SqlParameter("@numara", System.Data.SqlDbType.VarChar); // Control this
            numaraParameter.Value = txt_salonNumara.Text;
            cmd.Parameters.Add(numaraParameter);

            cmd.ExecuteNonQuery();
        }

        private void Form_Salon_Load(object sender, EventArgs e)
        {
            DataTable salonlar = salonlistele(); //control this

            grd_salonlar.DataSource = salonlar;
        }

        public static DataTable salonlistele()
        {
            DataTable dt = new DataTable();

            try
            {
                string query = "SELECT s.id AS 'Id', s.numara AS 'Numara' * FROM salonlar s";
                SqlCommand cmd = new SqlCommand(query, Database.SqlConnection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);

            } catch(Exception ex) {
                throw ex;
            }

            return dt;
        }
    }
}
