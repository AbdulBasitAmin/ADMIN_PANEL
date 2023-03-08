using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace ADMIN_PANEL.Model
{
    class studentlogiclayer
    {

        student s = new student();
        private string connectionstring = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        // Data insertion code.......


        public int insert(student evm)

        {

            int msg = -1;

            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("insert_into_employee",conn);

                conn.Open();

                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = evm.name;
                cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = evm.dob;
                cmd.Parameters.Add("@contact", SqlDbType.VarChar, 50).Value = evm.contact;

                cmd.CommandType = CommandType.StoredProcedure;
                msg = cmd.ExecuteNonQuery();
                conn.Close();


            }
            catch (Exception)
            {
                msg = 0;
                throw;
            }

            return msg;

        }


        public List<student> getallStudent()
        {
            List<student> li = new List<student>();

			try
            {
                SqlConnection conn = new SqlConnection(connectionstring);

                SqlCommand cmd = new SqlCommand("view_all_records", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{

                    student st= new student();
                    st.id = Convert.ToInt32(rdr["id"].ToString());
                    st.name = rdr["name"].ToString();
                    st.dob = Convert.ToDateTime(rdr["dob"].ToString());

                    st.contact = rdr["contact"].ToString();

                    li.Add(st);

				}
                
            }
            catch (Exception)
			{
                MessageBox.Show("Some Error");


				throw;
			}

            return li;

        }

        public student getstudent(int id)
        {

            student s = new student();
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("getEmployeeById", con);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    s.id = Convert.ToInt32(rdr["id"].ToString());
                    s.name = rdr["name"].ToString();
                    s.dob = Convert.ToDateTime(rdr["dob"].ToString());
                    s.contact = rdr["contact"].ToString();
                  


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No record found......");
                //  throw;
            }

            return s;



        }

    }
}
