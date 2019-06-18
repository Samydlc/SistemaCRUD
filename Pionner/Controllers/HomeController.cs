using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pionner.Models;
//Lib
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Pionner.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //
        public IActionResult Index()
        {
            return View();
        }

        //Insertar
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(Controlador controlador)
        {
            if (ModelState.IsValid)
            {
                string ConnectionString = Configuration["ConnectionStrings:SqlConnection"];
                using (SqlConnection connection = new SqlConnection(ConnectionString)) 
                {
                    string sql = $"insert into Controlador (Modelo,Software,Canales,Precio) values ('{controlador.Modelo}','{controlador.Software}','{controlador.Canales}','{controlador.Precio}')";
                    
                    using (SqlCommand command = new SqlCommand(sql,connection)) 
                    {
                        command.CommandType = CommandType.Text;
                        // command.Parameters.AddWithValue("@id", controlador.Id);
                        //command.Parameters.AddWithValue("@modelo", controlador.Modelo);
                        //command.Parameters.AddWithValue("@software", controlador.Software);
                        //command.Parameters.AddWithValue("@canales", controlador.Canales);
                        //command.Parameters.AddWithValue("@precio", controlador.Precio);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();
                    }
                    return RedirectToAction("Index");

                }
            }
            else
                return View();
        }

        //leer
        public IActionResult List()
        {
           List<Controlador> lista = new List<Controlador>();
                string ConnectionString = Configuration["ConnectionStrings:SqlConnection"];
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string sql = "select * from Controlador";
                   SqlCommand command = new SqlCommand(sql, connection) ;
                    

                        using (SqlDataReader rdr = command.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                Controlador cont = new Controlador();
                                cont.Id = Convert.ToInt32(rdr["Id"]);
                                cont.Modelo = Convert.ToString(rdr["Modelo"]);
                                cont.Software = Convert.ToString(rdr["Software"]);
                                cont.Canales = Convert.ToInt32(rdr["Canales"]);
                                cont.Precio = Convert.ToInt32(rdr["Precio"]);
                                lista.Add(cont);

                            }
                        }
                        //command.ExecuteNonQuery();
                        connection.Close();
                        connection.Dispose();
                    }
                    return View(lista);
                    }


        //actualizar
        public IActionResult Update(int Id)
        {
            string connectionString = Configuration["ConnectionStrings:SQLConnection"];
            Controlador cont = new Controlador();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from Controlador where Id='{Id}'";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                using (SqlDataReader drd = command.ExecuteReader())
                {
                    while (drd.Read())
                    {
                        cont.Id = Convert.ToInt32(drd["Id"]);
                        cont.Modelo = Convert.ToString(drd["Modelo"]);
                        cont.Software = Convert.ToString(drd["Software"]);
                        cont.Canales = Convert.ToInt32(drd["Canales"]);
                        cont.Precio = Convert.ToInt32(drd["Precio"]);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return View(cont);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update(Controlador controlador)
        {
            string connectionString = Configuration["ConnectionStrings:SQLConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Update Controlador set Modelo = '{controlador.Modelo}' , Software = '{controlador.Software}' , Canales= '{controlador.Canales}' , Precio= '{controlador.Precio}' Where Id = '{controlador.Id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    connection.Dispose();
                }
            }
            return RedirectToAction("List");
        }

       
        //Eliminar
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Detele(int Id)
        {
            string connectionString = Configuration["ConnectionStrings:SQLConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Delete From Controlador Where Id='{Id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        ViewBag.Result = "error:" + ex.Message;
                    }
                    connection.Close();
                    connection.Dispose();
                }
            }
            return RedirectToAction("List");
        }

        //eliminar
        public IActionResult Delete(int Id)
        {
            string connectionString = Configuration["ConnectionStrings:SQLConnection"];
            Controlador cont = new Controlador();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"select * from Controlador where Id='{Id}'";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                using (SqlDataReader drd = command.ExecuteReader())
                {
                    while (drd.Read())
                    {
                        cont.Id = Convert.ToInt32(drd["Id"]);
                        cont.Modelo = Convert.ToString(drd["Modelo"]);
                        cont.Software = Convert.ToString(drd["Software"]);
                        cont.Canales = Convert.ToInt32(drd["Canales"]);
                        cont.Precio = Convert.ToInt32(drd["Precio"]);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return View(cont);
        }

        //Detalles
        public IActionResult Details(int Id)
        {
            string connectionString = Configuration["ConnectionStrings:SQLConnection"];
            Controlador cont = new Controlador();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Select * From Controlador Where Id='{Id}'";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                using (SqlDataReader rdr = command.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        cont.Id = Convert.ToInt32(rdr["Id"]);
                        cont.Modelo = Convert.ToString(rdr["Modelo"]);
                        cont.Software = Convert.ToString(rdr["Software"]);
                        cont.Canales = Convert.ToInt32(rdr["Canales"]);
                        cont.Precio= Convert.ToInt32(rdr["Precio"]);
                    }
                }
                connection.Close();
                connection.Dispose();
            }
            return View(cont);
        }

        public IActionResult Galeria()
        {
            return View();
        }

        public IActionResult Catalogos()
        {
            return View();
        }
        public IActionResult Software()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Pdf()
        {
            return View();
        }
        public IActionResult Privacidad()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
