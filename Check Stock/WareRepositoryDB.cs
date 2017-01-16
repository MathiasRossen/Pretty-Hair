using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PrettyHairCore
{
    public class WareRepositoryDB : IWareRepository
    {
        string connectionString;

        public WareRepositoryDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddWare(Ware ware)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("RegisterWare", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("price", ware.Price));
                    cmd.Parameters.Add(new SqlParameter("amount", ware.Amount));
                    cmd.Parameters.Add(new SqlParameter("designation", ware.Designation));

                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                }
            }
        }

        public void DeleteUnsellableWares()
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("DeleteUnsellableWares", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
            }
        }

        public Ware GetWareById(int wareId)
        {
            int id = 0;
            int price = 0;
            int amount = 0;
            string designation = "";
            bool unsellable = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("GetWareById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("wareId", wareId));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        id = int.Parse(reader["WareId"].ToString());
                        price = int.Parse(reader["Price"].ToString());
                        amount = int.Parse(reader["Amount"].ToString());
                        designation = reader["Designation"].ToString();
                        unsellable = bool.Parse(reader["Unsellable"].ToString());
                    }
                }
                catch (SqlException)
                {
                    return null;
                }
            }

            return new Ware(id, price, amount, designation, unsellable);
        }

        public List<Ware> GetWares()
        {
            List<Ware> wareList = new List<Ware>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("GetAllWares", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = int.Parse(reader["WareId"].ToString());
                        int price = int.Parse(reader["Price"].ToString());
                        int amount = int.Parse(reader["Amount"].ToString());
                        string designation = reader["Designation"].ToString();

                        wareList.Add(new Ware(id, price, amount, designation, false));
                    }
                }
                catch (SqlException)
                {
                    return null;
                }
            }

            return wareList;
        }

        public void MarkUnsellable(int wareId)
        {
            using(SqlConnection con =  new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("MarkWareUnsellable", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("wareId", wareId));

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
            }
        }

        public void RemoveWare(int wareId, int amountToRemove)
        {
            throw new NotImplementedException();
        }

        public void UpdateWare(int wareId, int newPrice)
        {
            Ware wareToChange = GetWareById(wareId);
            UpdateWare(wareId, newPrice, wareToChange.Designation);
        }

        public void UpdateWare(int wareId, int newPrice, string newDesignation)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("EditWare", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("wareId", wareId));
                    cmd.Parameters.Add(new SqlParameter("price", newPrice));
                    cmd.Parameters.Add(new SqlParameter("designation", newDesignation));

                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                }
            }
        }
    }
}
