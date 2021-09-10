using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebAppMmassImport.Clases
{
    public static class datasetMM
    {
        private static SqlConnection cnn { get; set; }
        private static string ConexionString { get; set; }
        private static SqlCommand command { get; set; }
        private static SqlDataAdapter adapter { get; set; }
        public static string getIdValor(string sql)
        {
            if (ConexionString == "" || ConexionString == null)
                ConexionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            if (cnn == null)
            {
                cnn = new SqlConnection(ConexionString);
                cnn.Open();
            }
            if (adapter == null)
                adapter = new SqlDataAdapter();

            command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader;

            dataReader = command.ExecuteReader();
            string respuesta = "null";
            while (dataReader.Read())
            {
                respuesta = dataReader.GetValue(0).ToString();
            }
            dataReader.Close();
            return respuesta;

        }
        public static string getValor(string sql)
        {
            if (ConexionString=="" || ConexionString==null)
              ConexionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            if (cnn == null)
            {
                cnn = new SqlConnection(ConexionString);
                cnn.Open();
            }
            if (adapter==null)
              adapter = new SqlDataAdapter();
        
            command = new SqlCommand(sql, cnn);
            SqlDataReader dataReader;

            dataReader = command.ExecuteReader();
            string respuesta = "";
            while (dataReader.Read())
            {
                respuesta = dataReader.GetValue(0).ToString();
            }
            dataReader.Close();
            return respuesta;
        }
    }
}