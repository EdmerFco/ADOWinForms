using ADOWinForms.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ADOWinForms.ADO
{
    public class ADOEstatusAlumno : ICRUD
    {
        string _Conexion = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
        List<EstatusAlumno> _list;
        private SqlCommand comando;

        public List<EstatusAlumno> Consultar()
        {
            _list = new List<EstatusAlumno>();
            string query;
            SqlCommand comando;
            query = $"select * from EstatusAlumnos";

            using (SqlConnection con = new SqlConnection(_Conexion))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader adapter = comando.ExecuteReader();
                while (adapter.Read())
                {
                    _list.Add(
                        new EstatusAlumno()
                        {
                            id = Convert.ToInt32(adapter["id"]),
                            clave = adapter["clave"].ToString(),
                            nombre = adapter["Nombre"].ToString(),
                        }
                        );
                }
                con.Close();
                foreach (EstatusAlumno item in _list)
                {
                    Console.WriteLine($"ID: {item.id} clave: {item.clave} nombre: {item.nombre}");
                }
            }
            return _list;

        }

        public EstatusAlumno Consultar(int id)
        {

            string query;
            SqlCommand comando;
            EstatusAlumno estatus = new EstatusAlumno();
            query = $"select * from EstatusAlumnos where id = {id}";

            using (SqlConnection con = new SqlConnection(_Conexion))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader adapter = comando.ExecuteReader();
                while (adapter.Read())
                {
                    estatus = new EstatusAlumno()
                    {
                        id = Convert.ToInt32(adapter["id"]),
                        clave = adapter["clave"].ToString(),
                        nombre = adapter["Nombre"].ToString(),
                    };
                }
                con.Close();
            }
            return estatus;
        }

        public int Agregar(EstatusAlumno estatus)
        {
            string query;
            query = $"agregarEstatus";
            int idEstado;

            using (SqlConnection con = new SqlConnection(_Conexion))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("clave", estatus.clave);
                comando.Parameters.AddWithValue("nombre", estatus.nombre);
                con.Open();
                idEstado = (Int32)comando.ExecuteScalar();
                con.Close();
            }
            return idEstado;
        }

        public void Actulizar(EstatusAlumno estatus)
        {
            string query;
            query = $"UPDATE  EstatusAlumnos SET clave = '{estatus.clave}',[Nombre] = '{estatus.nombre}' WHERE  id = {estatus.id}";
            using (SqlConnection con = new SqlConnection(_Conexion))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();
            }

        }

        public void Eliminar(EstatusAlumno estatus)
        {
            EstatusAlumno estat = new EstatusAlumno();
            string query;
            query = $" DELETE FROM [dbo].[EstatusAlumnos] WHERE  id =  {estatus.id}";
            using (SqlConnection con = new SqlConnection(_Conexion))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}
