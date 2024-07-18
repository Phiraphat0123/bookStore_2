using BookStoreApp.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookStoreApp.SQLite
{
    internal class Sales : DataAccess
    {
        private string databaseFile = "Sales.db";
        public Sales() 
        {
            SqliteConnection db = new SqliteConnection($"Filename={databaseFile}");
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Sales (" +
                    "Sale_ID INTEGER PRIMARY KEY AUTOINCREMENT," + // sales id
                    "ISBN INTEGER, " +              //book id
                    "Customer_ID INTEGER, " +       //customer id
                    "Quantity INTEGER," +           //quantity  
                    "Total_Price DOUBLE" +          // total price
                    ");";
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
                        ("SELECT * FROM Sales", db);
                    SqliteDataReader query = selectCommand.ExecuteReader();

                    while (query.Read())
                    {
                        //entries.Add(query.GetString(0));
                        //query.GetInt32(0); //Id
                        //query.GetString(1); //Title
                        //query.GetString(2); //Description
                        //query.GetDouble(3); //Price
                        entries.Add(new SalesModel
                        {
                            salesId = query.IsDBNull(query.GetOrdinal("Sale_ID")) ? 0 : query.GetInt32(query.GetOrdinal("Sale_ID")),
                            ISBN = query.IsDBNull(query.GetOrdinal("ISBN")) ? 0 : query.GetInt32(query.GetOrdinal("ISBN")),
                            customerId = query.IsDBNull(query.GetOrdinal("Customer_ID")) ? 0 : query.GetInt32(query.GetOrdinal("Customer_ID")),
                            quantity = query.IsDBNull(query.GetOrdinal("Quantity")) ? 0 : query.GetInt32(query.GetOrdinal("Quantity")),
                            totalPrice = query.IsDBNull(query.GetOrdinal("Total_Price")) ? 0.0 : query.GetDouble(query.GetOrdinal("Total_Price"))
                        });
                        //entries.Add(new SalesModel { salesId = query.GetInt32(0), ISBN = query.GetInt32(1), customerId = query.GetInt32(2), quantity = query.GetInt32(3), totalPrice = query.GetDouble(4) });
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
                    selectCommand.CommandText = $"SELECT * FROM Sales Where Sale_ID=@Condition;";
                    selectCommand.Parameters.AddWithValue("@Condition", id);

                    SqliteDataReader query = selectCommand.ExecuteReader();
                    while (query.Read())
                    {
                        
                        //entries.Add(query.GetString(0));
                        entries.Add(new SalesModel { 
                            salesId = query.IsDBNull(query.GetOrdinal("Sale_ID")) ?0: query.GetInt32(query.GetOrdinal("Sale_ID")), 
                            ISBN = query.IsDBNull(query.GetOrdinal("ISBN")) ? 0 : query.GetInt32(query.GetOrdinal("ISBN")), 
                            customerId = query.IsDBNull(query.GetOrdinal("Customer_ID")) ? 0 : query.GetInt32(query.GetOrdinal("Customer_ID")), 
                            quantity = query.IsDBNull(query.GetOrdinal("Quantity")) ? 0 : query.GetInt32(query.GetOrdinal("Quantity")), 
                            totalPrice = query.IsDBNull(query.GetOrdinal("Total_Price")) ? 0.0 : query.GetDouble(query.GetOrdinal("Total_Price"))
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

        public Boolean AddData(int bookId, int customerId, int quantity, double totalPrice)
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
                    insertCommand.CommandText = "INSERT INTO Sales(ISBN, Customer_ID, Quantity, Total_Price)  VALUES(@ISBN, @CustomerId, @Quantity, @TotalPrice)";
                    //insertCommand.Parameters.AddWithValue("@SalesId", salesId);
                    insertCommand.Parameters.AddWithValue("@ISBN", bookId); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.Parameters.AddWithValue("@CustomerId", customerId);
                    insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                    insertCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
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
        public Boolean DeleteData(int salesId)
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
                    insertCommand.CommandText = "Delete From Sales WHERE Sale_ID=@SalesId";
                    insertCommand.Parameters.AddWithValue("@SalesId", salesId); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
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
        public Boolean UpdateData(int salesId, int bookId, int customerId, int quantity, double totalPrice)
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
                    insertCommand.CommandText = "UPDATE Sales SET ISBN=@ISBN, Customer_ID=@CustomerId, Quantity=@Quantity Total_Price=@TotalPrice  WHERE Sale_ID=@SalesId";
                    insertCommand.Parameters.AddWithValue("@SalesId", salesId); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.Parameters.AddWithValue("@ISBN", bookId); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.Parameters.AddWithValue("@CustomerId", customerId); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.Parameters.AddWithValue("@Quantity", quantity); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
                    insertCommand.Parameters.AddWithValue("@TotalPrice", totalPrice); //ใช้เพื่อตรวจสอบค่าเพื่อให้เป็นแค่ข้อมูลเท่านั้น ไม่ใช่ SQL command
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
