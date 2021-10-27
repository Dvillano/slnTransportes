using Datos.Server;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos.Admin
{
    public static class AdmAuto
    {
        public static List<Auto> Listar()
        {
            string querySql = "SELECT Id,Marca,Modelo,Matricula,Precio FROM dbo.Auto";
            SqlCommand command = new SqlCommand(querySql, AdminDB.ConectarBase());

            SqlDataReader reader;
            reader = command.ExecuteReader();

            //Creamos lista de medicos para usar el reader y devolverla
            List<Auto> listaAutos = new List<Auto>();

            while (reader.Read())
            {
                listaAutos.Add
                    (
                    new Auto
                    {
                        Id = (int)reader["Id"],
                        Marca = reader["Marca"].ToString(),
                        Modelo = reader["Modelo"].ToString(),
                        Matricula = reader["Matricula"].ToString(),
                        Precio = (decimal)reader["Precio"],
                    }
                    );
            }

            AdminDB.ConectarBase().Close();
            reader.Close();

            return listaAutos;
        }

        public static DataTable ListarMarcas()
        {
            string querySql = "SELECT Id,Marca,Modelo,Matricula,Precio FROM dbo.Auto ";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdminDB.ConectarBase());

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Autos");

            return ds.Tables["Autos"];
        }

        public static DataTable Listar(string marca)
        {
            string querySql = "SELECT Id,Marca,Modelo,Matricula,Precio FROM dbo.Auto WHERE Marca = @Marca";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdminDB.ConectarBase());

            adapter.SelectCommand.Parameters.Add("@Marca", SqlDbType.VarChar,50).Value = marca;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Autos");


            return ds.Tables["Autos"];
        }

      



        public static int Insertar(Auto auto)
        {
            string querySql = "INSERT INTO dbo.Auto (Marca, Modelo, Matricula, Precio) VALUES (@Marca, @Modelo, @Matricula, @Precio)";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdminDB.ConectarBase());

            adapter.SelectCommand.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            adapter.SelectCommand.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value = auto.Modelo;
            adapter.SelectCommand.Parameters.Add("@Matricula", SqlDbType.Char,6).Value = auto.Matricula;
            adapter.SelectCommand.Parameters.Add("@Precio", SqlDbType.Decimal).Value = auto.Precio;

            int filasAfectadas = adapter.SelectCommand.ExecuteNonQuery();
            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }

        public static int Modificar(Auto auto)
        {
            string querySql = "UPDATE dbo.Auto SET Marca = @Marca, Modelo = @Modelo, Matricula =  @Matricula, Precio = @Precio WHERE Id = @Id";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdminDB.ConectarBase());

            
            adapter.SelectCommand.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            adapter.SelectCommand.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value = auto.Modelo;
            adapter.SelectCommand.Parameters.Add("@Matricula", SqlDbType.Char, 6).Value = auto.Matricula;
            adapter.SelectCommand.Parameters.Add("@Precio", SqlDbType.Decimal).Value = auto.Precio;
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = auto.Id;

            int filasAfectadas = adapter.SelectCommand.ExecuteNonQuery();
            AdminDB.ConectarBase().Close();
            return filasAfectadas;


        }

        public static int Eliminar(int idAuto)
        {
            string querySql = "DELETE FROM dbo.Auto WHERE Id = @Id";

            SqlDataAdapter adapter = new SqlDataAdapter(querySql, AdminDB.ConectarBase());

            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = idAuto;

            int filasAfectadas = adapter.SelectCommand.ExecuteNonQuery();

            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }


    }
}
