using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PrettyHairCore
{
    public class CustomerRepositoryDB : ICustomerRepository
    {
        string connectionString;

        public CustomerRepositoryDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Customer> FindAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("FindAllCustomers", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = int.Parse(reader["CustomerId"].ToString());
                        string name = reader["CustomerName"].ToString();
                        string address = reader["CustomerAddress"].ToString();

                        customerList.Add(new Customer(id, name, address));
                    }
                }
                catch(SqlException)
                {
                }
            }

            return customerList;
        }

        public Customer FindCustomer(int customerId)
        {
            int id = 0;
            string name = "";
            string address = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("FindCustomerById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("customerId", customerId));

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        id = int.Parse(reader["CustomerId"].ToString());
                        name = reader["CustomerName"].ToString();
                        address = reader["CustomerAddress"].ToString();
                    }
                }
                catch(SqlException)
                {
                    return null;
                }
            }

            return new Customer(id, name, address);
        }

        public void RegisterCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("RegisterCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("customerName", customer.Name));
                    cmd.Parameters.Add(new SqlParameter("customerAddress", customer.Address));

                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {

                }
            }
        }
    }
}
