using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class DAO : DataBase
    {
        public DAO() { }

        internal DataTable ExecuteSelectProcedure(string procedureName, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable("table");
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(GetConnectionString("GESTAO_PEDIDO")))
            {
                cmd.Parameters.Clear();
                cmd = new SqlCommand(procedureName, conn);

                foreach (var par in parameters)
                {
                    cmd.Parameters.AddWithValue(par.Key, par.Value);
                }

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.SelectCommand.CommandTimeout = 0;
                adapter.Fill(dt);

            }
            return dt;
        }
        internal void ExecuteProcedure(string procedureName, Dictionary<string, object> parameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(GetConnectionString("GESTAO_PEDIDO")))
            {
                cmd.Parameters.Clear();
                cmd = new SqlCommand(procedureName, conn);

                foreach (var par in parameters)
                {
                    cmd.Parameters.AddWithValue(par.Key, par.Value);
                }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }


        //internal DataTable SPS_PRODUTO() { }
        //internal void SPU_PRODUTO() { }
        //internal void SPI_PRODUTO() { }
        //internal void SPD_PRODUTO() { }

        //internal DataTable SPS_PEDIDO() { }
        //internal void SPU_PEDIDO() { }
        //internal void SPI_PEDIDO() { }
        //internal void SPD_PEDIDO() { }

    }
}
