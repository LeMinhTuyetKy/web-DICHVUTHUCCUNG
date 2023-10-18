using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace clonePetService.Models
{

    public class dichVuCreate
    {
        public string strCon = "Data Source=.;Initial Catalog=SANPHAM;Integrated Security=True";
        public void Create(DichVu dv)
        {
            SqlConnection sqlConnection = new SqlConnection(strCon);
            try
            {
                string strQuery = "INSERT INTO DBO.DICHVU(TENBAIHAT, MATL, MANS)VALUES(@TENBAIHAT, @MATL, @MANS)";
                //string strQuery = "insert into table dbo.DICHVU(TENBAIHAT,MATL,MANS)VALUES(@TENBAIHAT,@MATL,@MANS)";
                sqlConnection.Open();


                SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);
                //SqlCommand cmd = new SqlCommand("CREATEDICHVU", sqlConnection);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TENBAIHAT", dv.TenBaiHat);
                cmd.Parameters.AddWithValue("@MATL", dv.IDTL);
                cmd.Parameters.AddWithValue("@MANS", dv.IDNS);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
          
            
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
        public void Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(strCon);
            try
            {
                string strQuery = "DELETE FROM  DBO.DICHVU WHERE ID=@ID";
                sqlConnection.Open();


                SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {


            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
        public void Change(DichVu dv)
        {
            SqlConnection sqlConnection = new SqlConnection(strCon);
            try
            {
                string strQuery = "UPDATE DBO.DICHVU SET TENBAIHAT = @TENBAIHAT, MATL = @MATL  ,MANS=@MANS  WHERE ID = @ID;";
                //string strQuery = "insert into table dbo.DICHVU(TENBAIHAT,MATL,MANS)VALUES(@TENBAIHAT,@MATL,@MANS)";
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);
                //SqlCommand cmd = new SqlCommand("CREATEDICHVU", sqlConnection);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", dv.ID);
                cmd.Parameters.AddWithValue("@TENBAIHAT", dv.TenBaiHat);
                cmd.Parameters.AddWithValue("@MATL", dv.IDTL);
                cmd.Parameters.AddWithValue("@MANS", dv.IDNS);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {


            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        public List<DichVu> Get(int count)
        {
            SqlConnection sqlConnection = new SqlConnection(strCon);
            List<DichVu> List = new List<DichVu>();
            try
            {
                string strQuery = "SELECT TOP 5 * from dbo.DICHVU";
                if(count >5) {
                    strQuery = "SELECT * from dbo.DICHVU";
                }
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    DichVu dv = new DichVu();
                    dv.ID = Convert.ToInt32(data["ID"].ToString());
                    dv.IDTL = Convert.ToInt32(data["MATL"].ToString());
                    dv.IDNS = Convert.ToInt32(data["MANS"].ToString());
                    dv.TenBaiHat = data["TENBAIHAT"].ToString();
                    List.Add(dv);
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return List;
        }

        public List<DichVu> Search(string search)
        {
            SqlConnection sqlConnection = new SqlConnection(strCon);
            List<DichVu> List = new List<DichVu>();
            try
            {
                string strQuery = "SELECT * FROM dbo.DICHVU WHERE TENBAIHAT LIKE N'%' + @SEARCH + '%'";
               
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SEARCH", search);
                
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    DichVu dv = new DichVu();
                    dv.ID = Convert.ToInt32(data["ID"].ToString());
                    dv.IDTL = Convert.ToInt32(data["MATL"].ToString());
                    dv.IDNS = Convert.ToInt32(data["MANS"].ToString());
                    dv.TenBaiHat = data["TENBAIHAT"].ToString();
                    List.Add(dv);
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return List;
        }

        public DichVu GetByID(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(strCon);
            DichVu dv = new DichVu();
            try
            {
                string strQuery = "SELECT * from dbo.DICHVU WHERE ID=@ID";
               
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);
                cmd.Parameters.AddWithValue("@ID",id);
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                  
                    dv.ID = Convert.ToInt32(data["ID"].ToString());
                    dv.IDTL = Convert.ToInt32(data["MATL"].ToString());
                    dv.IDNS = Convert.ToInt32(data["MANS"].ToString());
                    dv.TenBaiHat = data["TENBAIHAT"].ToString();
                    
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return dv;
        }
    }
}