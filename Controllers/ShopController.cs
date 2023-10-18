using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using clonePetService.Models;
using System.Diagnostics;
using clonePetService.iService;
using clonePetService.service;
using System.Runtime.InteropServices;
using System.Reflection;

namespace clonePetService.Controllers
{


    public class ShopController : Controller
    {

        /*     private readonly iShopService _shopService;
             public ShopController(iShopService shopService)
             {
                 _shopService = shopService;
             }*/


        public List<Product> listProducts = new List<Product>();
        public string strConnect = "Data Source=.;Initial Catalog=thucung;Integrated Security=True";

        public ActionResult Index(int first_price = -1, int last_price = -1,string search_key="")
        {
            
            // lấy data 
            // render ra

            listProducts = getData(first_price, last_price);
            return View(listProducts);
        }

        public List<Product> getData(int first_price=-1, int last_price=-1)   
        {

            SqlConnection sqlCon = new SqlConnection(strConnect);
            listProducts = new List<Product>();
            try
            {
                sqlCon.Open();

                SqlCommand sqlCommand = new SqlCommand("getAllProduct", sqlCon);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@first_price", first_price);
                sqlCommand.Parameters.AddWithValue("@last_price", last_price);
                SqlDataReader data = sqlCommand.ExecuteReader();

                while (data.Read())
                {
                    

                    string Title = data["Title"].ToString();
                    int Id = Convert.ToInt32(data["Id"].ToString());

                    string Image = data["Image"].ToString();

                    int Price = Convert.ToInt32(data["Price"].ToString());
                    string Type = data["Type"].ToString();


                    //Product newItem = new Product(Id, Title, Image, Price, Type);
                    //listProducts.Add(newItem);
                }

                sqlCon.Close();
                sqlCon.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Xử lý lỗi nếu có
            }
            return listProducts;
        }
    }
}