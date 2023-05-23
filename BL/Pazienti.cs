using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BL
{
    public class Pazienti
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    var query = "SELECT Pazienti.IdPaziente" +
                        "             , Nome" +
                        "             , Cognome" +
                        "             , DataNascita" +
                        "             , PrelieviPreno.DataOraPrelievo" +
                        "        FROM[dbo].[Pazienti]" +
                        "        inner join PrelieviPreno on Pazienti.IdPaziente = PrelieviPreno.IdPaziente" +
                        "        where month(Pazienti.DataNascita) = 9 and year(PrelieviPreno.DataOraPrelievo)= 2023";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        DataTable pazientiTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(pazientiTable);

                        if (pazientiTable.Rows.Count > 0 )
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in pazientiTable.Rows)
                            {
                                ML.Pazienti pazienti = new ML.Pazienti();

                                pazienti.IdPaziente = (int)row[0];
                                pazienti.Nome = row[1].ToString();
                                pazienti.Cognome = row[2].ToString();
                                pazienti.DataNascita = row[3].ToString();

                                pazienti.PrelieviPreno = new ML.PrelieviPreno();
                                pazienti.PrelieviPreno.DataOraPrelievo = row[4].ToString(); 

                                result.Objects.Add(pazienti);
                            }
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result GetAll(string nome, int IdPaziente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                  
                    var query = "SELECT Pazienti.IdPaziente" +
                        "             , Nome" +
                        "             , Cognome " +
                        "             , DataNascita" +
                        "             , PrelieviPreno.DataOraPrelievo" +
                        "        FROM[dbo].[Pazienti]" +
                        "        inner join PrelieviPreno on Pazienti.IdPaziente = PrelieviPreno.IdPaziente" +
                        "        where month(Pazienti.DataNascita) = 9 and year(PrelieviPreno.DataOraPrelievo)= 2023" +
                        "        and(@IdPaziente = 0 and Pazienti.Nome like '%' + @Nome + '%' or Pazienti.IdPaziente = @IdPaziente)";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("IdPaziente", SqlDbType.Int);
                        collection[0].Value = IdPaziente;

                        collection[1] = new SqlParameter("nome", SqlDbType.VarChar);
                        collection[1].Value = nome;

                        cmd.Parameters.AddRange(collection);

                        DataTable pazientiTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(pazientiTable);

                        if (pazientiTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in pazientiTable.Rows)
                            {
                                ML.Pazienti pazienti = new ML.Pazienti();

                                pazienti.IdPaziente = (int)row[0];
                                pazienti.Nome = row[1].ToString();
                                pazienti.Cognome = row[2].ToString();
                                pazienti.DataNascita = row[3].ToString();

                                pazienti.PrelieviPreno = new ML.PrelieviPreno();
                                pazienti.PrelieviPreno.DataOraPrelievo = row[4].ToString();

                                result.Objects.Add(pazienti);
                            }
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}