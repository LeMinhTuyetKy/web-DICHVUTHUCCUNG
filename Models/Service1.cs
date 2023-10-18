using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace clonePetService.Models
{
    public class Service1
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> SC_Id { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }

        public class ServiceMethod
        {
            public string strCon = "Data Source=.;Initial Catalog=DV_THUCUNG;Integrated Security=True";
            public void Create(Service1 se)
            {
                SqlConnection sqlConnection = new SqlConnection(strCon);
                try
                {
                    string strQuery = "INSERT INTO Service(Id, Title, SC_Id, Detail, Image, Price, CreateDate)" +
                        "VALUES(@Id, @Title, @SC_Id, @Detail, @Image, @Price, @CreateDate)";
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);
                    cmd.Parameters.AddWithValue("@Id", se.Id);
                    cmd.Parameters.AddWithValue("@Title", se.Title);
                    cmd.Parameters.AddWithValue("@SC_Id", se.SC_Id);
                    cmd.Parameters.AddWithValue("@Detail", se.Detail);
                    cmd.Parameters.AddWithValue("@Image", se.Image);
                    cmd.Parameters.AddWithValue("@Price", se.Price);
                    cmd.Parameters.AddWithValue("@CreateDate", se.CreateDate);
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
                    string strQuery = "DELETE FROM  Service WHERE Id=@Id";
                    sqlConnection.Open();


                    SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);

                    cmd.Parameters.AddWithValue("@Id", id);
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
            public void Change(Service1 se)
            {
                SqlConnection sqlConnection = new SqlConnection(strCon);
                try
                {
                    string strQuery = "UPDATE Product SET Title = @Title, SC_Id = @SC_Id, Detail = @Detail, Image = @Image, Price = @Price, CreateDate = @CreateDate WHERE Id = @Id;";

                    sqlConnection.Open();

                    SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);

                    cmd.Parameters.AddWithValue("@Id", se.Id);
                    cmd.Parameters.AddWithValue("@Title", se.Title);
                    cmd.Parameters.AddWithValue("@SC_Id", se.SC_Id);
                    cmd.Parameters.AddWithValue("@Detail", se.Detail);
                    cmd.Parameters.AddWithValue("@Image", se.Image);
                    cmd.Parameters.AddWithValue("@Price", se.Price);
                    cmd.Parameters.AddWithValue("@CreateDate", se.CreateDate);
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
            public List<Service1> Get(int count)
            {
                SqlConnection sqlConnection = new SqlConnection(strCon);
                List<Service1> List = new List<Service1>();
                try
                {
                    string strQuery = "SELECT TOP 5 * from Service";
                    if (count > 5)
                    {
                        strQuery = "SELECT * from Service";
                    }
                    sqlConnection.Open();

                    SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);
                    SqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        Service1 se = new Service1();
                        se.Id = Convert.ToInt32(data["Id"].ToString());
                        se.Title = data["Title"].ToString();
                        se.SC_Id = Convert.ToInt32(data["SC_Id"].ToString());
                        se.Detail = data["Detail"].ToString();
                        se.Image = data["Image"].ToString();
                        se.Price = Convert.ToInt32(data["Price"].ToString());
                        se.CreateDate = Convert.ToDateTime(data["CreateDate"].ToString());
                        List.Add(se);
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
            public List<Service1> Search(string search)
            {
                SqlConnection sqlConnection = new SqlConnection(strCon);
                List<Service1> List = new List<Service1>();
                try
                {
                    string strQuery = "SELECT * FROM Service WHERE Title LIKE N'%' + @SEARCH + '%'";

                    sqlConnection.Open();

                    SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);
                    //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SEARCH", search);

                    SqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        Service1 se = new Service1();
                        se.Id = Convert.ToInt32(data["Id"].ToString());
                        se.Title = data["Title"].ToString();
                        se.SC_Id = Convert.ToInt32(data["SC_Id"].ToString());
                        se.Detail = data["Detail"].ToString();
                        se.Image = data["Image"].ToString();
                        se.Price = Convert.ToInt32(data["Price"].ToString());
                        se.CreateDate = Convert.ToDateTime(data["CreateDate"].ToString());
                        List.Add(se);
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
            public Service1 GetByID(int id)
            {
                SqlConnection sqlConnection = new SqlConnection(strCon);
                Service1 se = new Service1();
                try
                {
                    string strQuery = "SELECT * from Service WHERE Id = @Id";

                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        se.Id = Convert.ToInt32(data["Id"].ToString());
                        se.Title = data["Title"].ToString();
                        se.SC_Id = Convert.ToInt32(data["SC_Id"].ToString());
                        se.Detail = data["Detail"].ToString();
                        se.Image = data["Image"].ToString();
                        se.Price = Convert.ToInt32(data["Price"].ToString());
                        se.CreateDate = Convert.ToDateTime(data["CreateDate"].ToString());
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
                return se;
            }
        }
    }
    
}