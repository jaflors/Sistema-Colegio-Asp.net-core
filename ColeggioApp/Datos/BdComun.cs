using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ColegioApp.Datos
{
    public class BdComun
    {
        private string cadenaSQL = string.Empty;
        public SqlConnection conexion;


        public BdComun()
        {


            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:DefaultConnection").Value;


            conexion = new SqlConnection(cadenaSQL);


        }
       
        public string getCadenaSQL()
        {
            return cadenaSQL;
        }


        private bool Conectar()
        {
            try
            { 
                conexion.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        private void Desconectar()
        {
            conexion.Close();
        }

        public SqlConnection ConexionSQL()
        {
            SqlConnection Connection = new SqlConnection(cadenaSQL);

            try
            {
                Connection.Open();
            }
            catch (Exception exc)
            {
                throw new Exception("No se realizó la conexión a la base de pameters: " + exc.Message);
            }

            return Connection;
        }

        public DataSet EjecutarSelectsql2(string p)
        {
            System.Data.DataSet dt = new System.Data.DataSet();
            SqlConnection Conn = conexion;
            SqlCommand ComandoSelect = new SqlCommand(p);
            ComandoSelect.Connection = Conn;
            // MySqlDataReader Resultado;
            SqlDataAdapter da = new SqlDataAdapter(p, Conn);
            //da = ComandoSelect.ExecuteReader();
            da.Fill(dt);
            Conn.Close();
            return dt;
        }


        public DataTable EjecutarConsulta(string sentencia, CommandType TipoComando)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = new SqlCommand(sentencia, conexion);
            adaptador.SelectCommand.CommandType = TipoComando;

            DataSet resultado = new DataSet();
            adaptador.Fill(resultado);

            return resultado.Tables[0];
        }


        public bool RegistrarDatos(string sentencia, CommandType TipoComando)
        {
            int x = 0;
            using (SqlConnection con = conexion)
            {
                con.Open();
                SqlCommand comando = new SqlCommand(sentencia, con);
                x = comando.ExecuteNonQuery();
            }




            return x > 0 ? true : false;
        }

        public bool RealizarTransaccion(string[] cadena)
        {
            bool state = false;
            if (Conectar())
            {
                SqlTransaction Transa = conexion.BeginTransaction();
                SqlCommand cmd = null;
                try
                {
                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (cadena[i].Length > 0)
                        {
                            cmd = new SqlCommand(cadena[i], conexion);
                            cmd.Transaction = Transa;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Transa.Commit();
                    conexion.Close();
                    conexion.Dispose();
                    Transa.Dispose();
                    Desconectar();
                    state = true;
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    Transa.Rollback();
                    conexion.Close();
                    conexion.Dispose();
                    Desconectar();
                    state = false;
                }
                finally
                {
                    // Recolectamos objetos para liberar su memoria.
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            return state;
        }

        public string RealizarTransaccionString(string[] cadena)
        {
            bool state = NewMethod();
            string mensaje = "";
            if (Conectar())
            {
                SqlTransaction Transa = conexion.BeginTransaction();
                SqlCommand cmd = null;
                try
                {
                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (cadena[i].Length > 0)
                        {
                            cmd = new SqlCommand(cadena[i], conexion);
                            cmd.Transaction = Transa;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Transa.Commit();
                    conexion.Close();
                    conexion.Dispose();
                    Transa.Dispose();
                    Desconectar();
                    state = true;
                    mensaje = "Registro exitoso";
                }
                catch (Exception ex)
                {
                    Transa.Rollback();
                    conexion.Close();
                    conexion.Dispose();
                    Desconectar();
                    state = false;


                    if (ex.Message.Contains("Duplicate entry"))
                    {
                        mensaje = "El usuario ya se a regitrado";
                    }
                    else
                    {
                        mensaje = "error al guadar la informaion";
                    }

                }
                finally
                {
                    // Recolectamos objetos para liberar su memoria.
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            return mensaje;
        }

        private static bool NewMethod()
        {
            return false;
        }

        public bool Transaction(List<Transaction> list)
        {
            bool state = false;
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = null;
            conn = ConexionSQL();

            SqlTransaction Transa = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == null) continue;

                    cmd = new SqlCommand(list[i].Procedure, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (Parameter obj in list[i].Parameters)
                    {

                        cmd.Parameters.AddWithValue(obj.Name, obj.Value);

                    }
                    cmd.Transaction = Transa;
                    cmd.ExecuteNonQuery();
                }
                Transa.Commit();
                conn.Close();
                conn.Dispose();
                Transa.Dispose();
                state = true;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Transa.Rollback();
                conn.Close();
                conn.Dispose();
                state = false;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
            return state;
        }

        public bool Transaction(Transaction[] list)
        {
            bool state = false;
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = null;
            conn = ConexionSQL();

            SqlTransaction Transa = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] == null) continue;

                    cmd = new SqlCommand(list[i].Procedure, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (Parameter obj in list[i].Parameters)
                    {

                        cmd.Parameters.AddWithValue(obj.Name, obj.Value);

                    }
                    cmd.Transaction = Transa;
                    cmd.ExecuteNonQuery();
                }
                Transa.Commit();
                conn.Close();
                conn.Dispose();
                Transa.Dispose();
                state = true;
            }
            catch (Exception)
            {
                Transa.Rollback();
                conn.Close();
                conn.Dispose();
                state = false;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
            return state;
        }

        //    jhjbhj//////////////////////////////////////////////////////////////////////

        public DataTable Query(string procedure, Parameter[] pameters)
        {
            DataTable data = new DataTable();
            SqlConnection mySqlConnection = ConexionSQL();
            SqlCommand mySqlCommand = new SqlCommand();
            mySqlCommand.CommandText = procedure;
            mySqlCommand.CommandType = CommandType.StoredProcedure;

            if (pameters != null)
            {
                for (int i = 0; i < pameters.Length; i++)
                {
                    mySqlCommand.Parameters.AddWithValue(pameters[i].Name, pameters[i].Value);
                }
            }

            mySqlCommand.Connection = mySqlConnection;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(mySqlCommand);
                da.Fill(data);
                return data;
            }
            catch (Exception exc)
            {
                throw new Exception("Sentencia SQL de consulta inválida: " + exc.Message);
            }
            finally
            {
                mySqlConnection.Close();
                mySqlConnection.Dispose();
            }
        }







    }


}
