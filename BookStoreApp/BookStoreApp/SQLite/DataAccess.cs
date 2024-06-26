using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.SQLite
{
    abstract class DataAccess
    {
        //abstract public void InitializeDatabase();
        abstract public List<Object> GetData();
        abstract public Boolean AddData();
        abstract public Boolean UpdateData();
        abstract public Boolean DeleteData();

    }
}
