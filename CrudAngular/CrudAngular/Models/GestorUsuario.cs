using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using Antlr.Runtime.Misc;

namespace CrudAngular.Models
{
    public class GestorUsuario
    {


        public List<Usuario> GetUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            string conexion = ConfigurationManager.ConnectionStrings["Dblocal"].ToString();

            using (SqlConnection con = new SqlConnection(conexion)) 
            { 
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Sp_usuario";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr= cmd.ExecuteReader();

                while(dr.Read()) 
                {
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    int edad= dr.GetInt32(2);
                    string desc = dr.GetString(3).Trim();


                    Usuario usuario = new Usuario(id,nombre,edad,desc);

                    lista.Add(usuario); 

                }
                dr.Close();
                con.Close();
               
            }

            return lista;
        }


        public bool AddUsuario(Usuario usuario)
        {
            bool res = false;
            string conexion = ConfigurationManager.ConnectionStrings["Dblocal"].ToString();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "sp_usuario_add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                cmd.Parameters.AddWithValue("@edad", usuario.edad);
                cmd.Parameters.AddWithValue("@desc", usuario.descripcion);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    con.Close();
                }

                return res;

            }
        }


        public bool UpdateUsuario(int id,Usuario usuario)
        {
            bool res = false;
            string conexion = ConfigurationManager.ConnectionStrings["Dblocal"].ToString();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Sp_usuario_update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id",id);
                cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                cmd.Parameters.AddWithValue("@edad", usuario.edad);
                cmd.Parameters.AddWithValue("@desc", usuario.descripcion);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    con.Close();
                }

                return res;

            }
        }


        public bool DeleteUsuario(int id)
        {
            bool res = false;
            string conexion = ConfigurationManager.ConnectionStrings["Dblocal"].ToString();

            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Sp_usuario_delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
               

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    con.Close();
                }

                return res;

            }
        }



    }
}