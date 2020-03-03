using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace WFAppTPi_ProgramacionII
{
    static class AccesoDatos
    {
        static string CadenaDeConexion = ConfigurationManager.ConnectionStrings["BDtpiAutomoviles"].ConnectionString;
        static OleDbConnection connection = new OleDbConnection(CadenaDeConexion);

        static public OleDbConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        static public OleDbDataReader Lector { get; set; }

        static public DataTable ConsultarTablaDT(string nombreTabla)
        {
            DataTable tabla = new DataTable();
            connection.Open();

            OleDbCommand command = new OleDbCommand("SELECT * FROM " + nombreTabla, connection);

            tabla.Load(command.ExecuteReader());

            connection.Close();

            return tabla;
        }

        static public DataTable ConsultaSQL(string consultaSQL)
        {
            DataTable table = new DataTable();

            connection.Open();
            OleDbCommand command = new OleDbCommand(consultaSQL, connection);
            table.Load(command.ExecuteReader());
            connection.Close();

            return table;
        }

        static public void ConsultarTablaDR(string nombreTabla)
        {
            connection.Open();

            OleDbCommand command = new OleDbCommand("SELECT * FROM " + nombreTabla, connection);
            Lector = command.ExecuteReader();
            
            //cerrar connection fuera
        }

        static public void ActualizarBD(string SQL_Query)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand(SQL_Query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }       

    }
}
