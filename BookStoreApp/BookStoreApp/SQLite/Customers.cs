using BookStoreApp.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookStoreApp.SQLite
{
    internal class Customers : DataAccess
    {
        private string databaseFile = "Customers.db";
        public Customers() {
            SqliteConnection db = new SqliteConnection($"Filename={databaseFile}");
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Customers (" +
                    "Customer_ID INTEGER PRIMARY KEY, " + //book id
                    "Customer_Name varchar(50), " + //book name
                    "Address varchar(50)," + //book des
                    "Email varchar(50)" +
                    ") ";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }

        public override List<Object> GetData()
        {
            List<Object> entries = new List<Object>();
            try
            {
                using (SqliteConnection db =
               new SqliteConnection($"Filename={databaseFile}"))
                {
                    db.Open();
                    SqliteCommand selectCommand = new SqliteCommand
                        ("SELECT * from Customers", db);
                    SqliteDataReader query = selectCommand.ExecuteReader();

                    while (query.Read())
                    {
                        entries.Add(new CustomerModel { 
                            customerId = query.IsDBNull(query.GetOrdinal("Customer_ID"))? 0:query.GetInt32(query.GetOrdinal("Customer_ID")),
                            customerName = query.IsDBNull(query.GetOrdinal("Customer_Name")) ? string.Empty : query.GetString(query.GetOrdinal("Customer_Name")),
                            address = query.IsDBNull(query.GetOrdinal("Address")) ? string.Empty : query.GetString(query.GetOrdinal("Address")),
                            email = query.IsDBNull(query.GetOrdinal("Email")) ? string.Empty : query.GetString(query.GetOrdinal("Email"))
                        });
                    }
                    db.Close();
                }
                return entries;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return entries;
            }

        }

        public List<Object> GetData(int id)
        {
            List<Object> entries = new List<Object>();
            try
            {
                using (SqliteConnection db =
              new SqliteConnection($"Filename={databaseFile}"))
                {
                    db.Open();
                    SqliteCommand selectCommand = new SqliteCommand();
                    selectCommand.Connection = db;
                    selectCommand.CommandText = $"SELECT * from Customers Where Customer_ID=@Condition;";
                    selectCommand.Parameters.AddWithValue("@Condition", id);

                    SqliteDataReader query = selectCommand.ExecuteReader();
                    while (query.Read())
                    {
                        //entries.Add(query.GetString(0));
                        entries.Add(new CustomerModel
                        {
                            customerId = query.IsDBNull(query.GetOrdinal("Customer_ID")) ? 0 : query.GetInt32(query.GetOrdinal("Customer_ID")),
                            customerName = query.IsDBNull(query.GetOrdinal("Customer_Name")) ? string.Empty : query.GetString(query.GetOrdinal("Customer_Name")),
                            address = query.IsDBNull(query.GetOrdinal("Address")) ? string.Empty : query.GetString(query.GetOrdinal("Address")),
                            email = query.IsDBNull(query.GetOrdinal("Email")) ? string.Empty : query.GetString(query.GetOrdinal("Email"))
                        });
                    }
                    db.Close();
                }
                return entries;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return entries;
            }

        }

        public override Boolean AddData()
        {
            MessageBox.Show("Please in put data");
            return false;
            //throw new NotImplementedException();
        }

        public Boolean AddData(int customerId, string customerName, string address, string email)
        {
            try
            {
                using (SqliteConnection db =
                              new SqliteConnection($"Filename={databaseFile}"))
                {
                    db.Open();
                    SqliteCommand insertCommand = new SqliteCommand();
                    insertCommand.Connection = db;
                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "INSERT INTO Customers VALUES (@CustomerId, @CustomerName, @Address, @Email);";
                    insertCommand.Parameters.AddWithValue("@CustomerId", customerId); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.Parameters.AddWithValue("@CustomerName", customerName);
                    insertCommand.Parameters.AddWithValue("@Address", address);
                    insertCommand.Parameters.AddWithValue("@Email", email);
                    insertCommand.ExecuteReader();
                    db.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public override Boolean DeleteData()
        {
            MessageBox.Show("Delete must has a book id");
            return false;
        }

        public Boolean DeleteData(int customerId)
        {
            try
            {
                using (SqliteConnection db =
             new SqliteConnection($"Filename={databaseFile}"))
                {
                    db.Open();
                    SqliteCommand insertCommand = new SqliteCommand();
                    insertCommand.Connection = db;
                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "Delete From Customers WHERE Customer_ID=@CustomerId";
                    insertCommand.Parameters.AddWithValue("@CustomerId", customerId); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.ExecuteReader();
                    db.Close();
                }
                return true;
                //MessageBox.Show("this is delete book");
                //return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public override Boolean UpdateData()
        {
            MessageBox.Show("Need data for update!");
            return false;
        }

        public Boolean UpdateData(int customerId, string customerName, string address, string email)
        {
            try
            {
                using (SqliteConnection db =
                             new SqliteConnection($"Filename={databaseFile}"))
                {
                    db.Open();
                    SqliteCommand insertCommand = new SqliteCommand();
                    insertCommand.Connection = db;
                    // Use parameterized query to prevent SQL injection attacks
                    insertCommand.CommandText = "UPDATE Customers SET Customer_Name=@CustomerName, Address=@Address, Email=@Email  WHERE Customer_ID=@CustomerId";
                    insertCommand.Parameters.AddWithValue("@CustomerId", customerId); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.Parameters.AddWithValue("@CustomerName", customerName); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.Parameters.AddWithValue("@Address", address); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.Parameters.AddWithValue("@Email", email); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.ExecuteReader();
                    db.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

    }
}
