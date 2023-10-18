using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace clonePetService.Models
{
    public class Product1
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> PC_Id { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> inventery { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Icon { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateBy { get; set; }
    }
    public class ProductMethod
    {
        public string strCon = "Data Source=.;Initial Catalog=thucung;Integrated Security=True";
        public void Create(Product1 pr)
        {
            SqlConnection sqlConnection = new SqlConnection(strCon);
            try
            {
                string strQuery = "INSERT INTO Product(Title, PC_Id, Description, Detail, Image, Price, inventery, Quantity, Icon, CreateDate, CreateBy)" +
                    "VALUES(@Title, @PC_Id, @Description, @Detail, @Image, @Price, @inventery, @Quantity, @Icon, @CreateDate, @CreateBy)";
                sqlConnection.Open();


                SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);
                //SqlCommand cmd = new SqlCommand("CREATEDICHVU", sqlConnection);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", pr.Title);
                cmd.Parameters.AddWithValue("@PC_Id", 1);
                cmd.Parameters.AddWithValue("@Description", pr.Description);
                cmd.Parameters.AddWithValue("@Detail", pr.Detail);
                cmd.Parameters.AddWithValue("@Image", pr.Image);
                cmd.Parameters.AddWithValue("@Price", pr.Price);
                cmd.Parameters.AddWithValue("@inventery", pr.inventery);
                cmd.Parameters.AddWithValue("@Quantity", pr.Quantity);
                cmd.Parameters.AddWithValue("@Icon", "icon");
                cmd.Parameters.AddWithValue("@CreateDate", pr.CreateDate);
                cmd.Parameters.AddWithValue("@CreateBy", pr.CreateBy);
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
                string strQuery = "DELETE FROM  Product WHERE Id=@Id";
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
        public void Change(Product1 pr)
        {
            SqlConnection sqlConnection = new SqlConnection(strCon);
            try
            {
                string strQuery = "UPDATE Product SET Title = @Title, PC_Id = @PC_Id, Description = @Description, Detail = @Detail, Image = @Image, Price = @Price, inventery = @inventery, Quantity = @Quantity, Icon = @Icon, CreateDate = @CreateDate, CreateBy = @CreateBy WHERE Id = @Id;";

                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);

                cmd.Parameters.AddWithValue("@Id", pr.Id);
                cmd.Parameters.AddWithValue("@Title", pr.Title);
                cmd.Parameters.AddWithValue("@PC_Id", 1);
                cmd.Parameters.AddWithValue("@Description", pr.Description);
                cmd.Parameters.AddWithValue("@Detail", pr.Detail);
                cmd.Parameters.AddWithValue("@Image", pr.Image);
                cmd.Parameters.AddWithValue("@Price", pr.Price);
                cmd.Parameters.AddWithValue("@inventery", pr.inventery);
                cmd.Parameters.AddWithValue("@Quantity", pr.Quantity);
                cmd.Parameters.AddWithValue("@Icon", "icon");
                cmd.Parameters.AddWithValue("@CreateDate", pr.CreateDate);
                cmd.Parameters.AddWithValue("@CreateBy", pr.CreateBy);
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
        public List<Product1> Get(int count)
        {
            SqlConnection sqlConnection = new SqlConnection(strCon);
            List<Product1> List = new List<Product1>();
            try
            {
                string strQuery = "SELECT TOP 5 * from Product";
                if (count > 5)
                {
                    strQuery = "SELECT * from Product";
                }
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    Product1 pr = new Product1();
                    pr.Id = Convert.ToInt32(data["Id"].ToString());
                    pr.Title = data["Title"].ToString();
                    pr.PC_Id = Convert.ToInt32(data["PC_Id"].ToString());
                    pr.Image = data["Image"].ToString();
                    pr.Price = Convert.ToInt32(data["Price"].ToString());
                    pr.inventery = Convert.ToInt32(data["inventery"].ToString());
                    //pr.Quantity = data["Quantity"].ToString();
                    pr.Icon = data["Icon"].ToString();
                    pr.Detail = data["Detail"].ToString();
                    pr.CreateDate = Convert.ToDateTime(data["CreateDate"].ToString());
                    List.Add(pr);
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

        public List<Product1> Search(string search)
        {
            SqlConnection sqlConnection = new SqlConnection(strCon);
            List<Product1> List = new List<Product1>();
            try
            {
                string strQuery = "SELECT * FROM Product WHERE Title LIKE N'%' + @SEARCH + '%'";

                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SEARCH", search);

                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    Product1 pr = new Product1();
                    pr.Id = Convert.ToInt32(data["Id"].ToString());
                    pr.Title = data["Title"].ToString();
                    pr.PC_Id = Convert.ToInt32(data["PC_Id"].ToString());
                    pr.Image = data["Image"].ToString();
                    pr.Price = Convert.ToInt32(data["Price"].ToString());
                    pr.inventery = Convert.ToInt32(data["inventery"].ToString());
                    pr.Quantity = Convert.ToInt32(data["Quantity"].ToString());
                    pr.Icon = data["Icon"].ToString();
                    pr.Detail = data["Detail"].ToString();
                    pr.CreateDate = Convert.ToDateTime(data["Quantity"].ToString());
                    List.Add(pr);
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

        public Product1 GetByID(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(strCon);
            Product1 pr = new Product1();
            try
            {
                string strQuery = "SELECT * from Product WHERE Id = @Id";

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(strQuery, sqlConnection);
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    pr.Id = Convert.ToInt32(data["Id"].ToString());
                    pr.Title = data["Title"].ToString();
                    pr.PC_Id = Convert.ToInt32(data["PC_Id"].ToString());
                    pr.Image = data["Image"].ToString();
                    pr.Price = Convert.ToInt32(data["Price"].ToString());
                    pr.inventery = Convert.ToInt32(data["inventery"].ToString());
                    pr.Quantity = Convert.ToInt32(data["Quantity"].ToString());
                    pr.Icon = data["Icon"].ToString();
                    pr.Detail = data["Detail"].ToString();
                    pr.CreateDate = Convert.ToDateTime(data["Quantity"].ToString());
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
            return pr;
        }

    }
}