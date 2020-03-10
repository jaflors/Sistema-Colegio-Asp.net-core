using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace colegio.Conexion
{
    public class BdComun
    {
        private MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion_mysql"].ConnectionString);
        private string stringConnection = ConfigurationManager.ConnectionStrings["conexion_mysql"].ConnectionString;
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

        public MySqlConnection ConexionMySQL()
        {
            MySqlConnection Connection = new MySqlConnection(stringConnection);

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

        public DataSet EjecutarSelectMysql2(string p)
        {
            System.Data.DataSet dt = new System.Data.DataSet();
            MySqlConnection Conn = conexion;
            MySqlCommand ComandoSelect = new MySqlCommand(p);
            ComandoSelect.Connection = Conn;
            // MySqlDataReader Resultado;
            MySqlDataAdapter da = new MySqlDataAdapter(p, Conn);
            //da = ComandoSelect.ExecuteReader();
            da.Fill(dt);
            Conn.Close();
            return dt;
        }


        public DataTable EjecutarConsulta(string sentencia, CommandType TipoComando)
        {
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = new MySqlCommand(sentencia, conexion);
            adaptador.SelectCommand.CommandType = TipoComando;

            DataSet resultado = new DataSet();
            adaptador.Fill(resultado);

            return resultado.Tables[0];
        }


        public bool RegistrarDatos(string sentencia, CommandType TipoComando)
        {
            int x = 0;
            using (MySqlConnection con = conexion)
            {
                con.Open();
                MySqlCommand comando = new MySqlCommand(sentencia, con);
                x = comando.ExecuteNonQuery();
            }




            return x > 0 ? true : false;
        }

        public bool RealizarTransaccion(string[] cadena)
        {
            bool state = false;
            if (Conectar())
            {
                MySqlTransaction Transa = conexion.BeginTransaction();
                MySqlCommand cmd = null;
                try
                {
                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (cadena[i].Length > 0)
                        {
                            cmd = new MySqlCommand(cadena[i], conexion);
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
                catch
                {
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
            bool state = false;
            string mensaje = "";
            if (Conectar())
            {
                MySqlTransaction Transa = conexion.BeginTransaction();
                MySqlCommand cmd = null;
                try
                {
                    for (int i = 0; i < cadena.Length; i++)
                    {
                        if (cadena[i].Length > 0)
                        {
                            cmd = new MySqlCommand(cadena[i], conexion);
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
                    mensaje = "Reguistro exitoso";
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

        public bool Transaction(Transaction[] list)
        {
            bool state = false;
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand cmd = null;
            conn = ConexionMySQL();

            MySqlTransaction Transa = conn.BeginTransaction();

            try
            {
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] == null) continue;

                    cmd = new MySqlCommand(list[i].Procedure, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (Parameter obj in list[i].Parameters)
                    {

                        cmd.Parameters.Add(obj.Name, obj.Value);

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
            MySqlConnection mySqlConnection = ConexionMySQL();
            MySqlCommand mySqlCommand = new MySqlCommand();
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
                MySqlDataAdapter da = new MySqlDataAdapter(mySqlCommand);
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


        public bool GuardarArchivo(string cadena, HttpPostedFile file)
        {
            //cmd.CommandText = "INSERT INTO imagenes(Nombre, Image) VALUES (@Nombre, @imgArr)";
            //cmd.Parameters.AddWithValue("@imgArr", doc);

            if (!Conectar()) return false;
            try
            {
                byte[] doc = new byte[file.InputStream.Length];
                file.InputStream.Read(doc, 0, doc.Length);

                using (MySqlConnection conn = conexion)
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = cadena;
                        cmd.Parameters.AddWithValue("@doc", doc);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                Desconectar();
                return true;
            }
            Desconectar();
            return true;
        }






    }
}