using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using newnorthwind;
using System.Data.Linq;
using System.Data.Common;
using System.Data;
namespace VS2010.ConsoleApp.Linq
{
    public static  class DataContextExtensions
    {
        public static List<T> ExecuteQuery<T>
      (this DataContext dataContext, IQueryable query)
        {
            DbCommand command = dataContext.GetCommand(query);
            using (dataContext.Connection)
            {
                dataContext.OpenConnection();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    return dataContext.Translate<T>(reader).ToList();
                }
            }
           
        }
        private static void OpenConnection
            (this DataContext dataContext)
        {
            if (dataContext.Connection.State ==
                ConnectionState.Closed)
            {
                dataContext.Connection.Open();
            }
        }
    }
}
