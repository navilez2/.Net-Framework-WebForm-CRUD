using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Controller
    {
        public Controller() { }


        public DataTable ExecuteSelectProcedure(string procedureName, Dictionary<string, object> parameters)
        {
            return new DAO().ExecuteSelectProcedure(procedureName, parameters);
        }
        public void ExecuteProcedure(string procedureName, Dictionary<string, object> parameters)
        {
            new DAO().ExecuteProcedure(procedureName, parameters);
        }

        //public DataTable SPS_PRODUTO() { }
        //public void SPU_PRODUTO() { }
        //public void SPI_PRODUTO() { }
        //public void SPD_PRODUTO() { }

        //public DataTable SPS_PEDIDO() { }
        //public void SPU_PEDIDO() { }
        //public void SPI_PEDIDO() { }
        //public void SPD_PEDIDO() { }

    }
}
