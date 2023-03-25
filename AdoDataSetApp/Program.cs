using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = @"Data Source=DESKTOP-ISC66B9\MSSQLSERVER2022;Database=Shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
using (SqlConnection connection = new(connectionString))
{
    SqlCommand command = connection.CreateCommand();
    command.CommandText = "SELECT * FROM Product";

    SqlDataAdapter adapter = new SqlDataAdapter(command);

    DataSet data = new DataSet();
    adapter.Fill(data);

    // add new
    //DataTable table = data.Tables[0];
    //DataRow row = table.NewRow();
    //row["id_category"] = 1;
    //row["id_brand"] = 2;
    //row["title"] = "Product from ADO NET";
    //row["price"] = 12345.67;
    //table.Rows.Add(row);

    // update
    //table.Rows[0]["price"] = 55000.0;
    SqlCommandBuilder builder = new(adapter);
    Console.WriteLine(builder.GetInsertCommand().CommandText);
    Console.WriteLine();
    Console.WriteLine(builder.GetUpdateCommand().CommandText);
    Console.WriteLine();
    Console.WriteLine(builder.GetDeleteCommand().CommandText);
    Console.WriteLine();
    //adapter.Update(data);
    //data.Clear();
    //adapter.Fill(data);

    //foreach (DataTable t in data.Tables)
    //{
    //    foreach (DataColumn c in t.Columns)
    //        Console.Write($"{c.ColumnName}\t");
    //    Console.WriteLine();
    //    foreach (DataRow r in t.Rows)
    //    {
    //        var items = r.ItemArray;
    //        foreach (var item in items)
    //            Console.Write($"{item.ToString()}\t");
    //        Console.WriteLine();
    //    }
    //}
}

void DataSetWithoutDb()
{
    DataSet data = new();
    DataTable table = new();

    data.Tables.Add(table);

    DataColumn idCol = new("Id", Type.GetType("System.Int32"));
    idCol.Unique = true;
    idCol.AllowDBNull = false;
    idCol.AutoIncrement = true;
    idCol.AutoIncrementSeed = 1;
    idCol.AutoIncrementStep = 1;
    table.Columns.Add(idCol);

    DataColumn nameCol = new("Name", Type.GetType("System.String"));
    DataColumn ageCol = new("Age", Type.GetType("System.Int32"));
    table.Columns.Add(nameCol);
    table.Columns.Add(ageCol);

    table.PrimaryKey = new DataColumn[] { table.Columns["idCol"] };

    DataRow row = table.NewRow();
    row.ItemArray = new object[] { null, "Bob", 32 };
    table.Rows.Add(row);
    table.Rows.Add(new object[] { null, "Jim", 25 });
    table.Rows.Add(new object[] { null, "Tom", 41 });

    foreach (DataColumn col in table.Columns)
        Console.Write($"{col.ColumnName}\t");
    Console.WriteLine();
    foreach (DataRow r in table.Rows)
    {
        var items = r.ItemArray;
        foreach (var item in items)
            Console.Write($"{item.ToString()}\t");
        Console.WriteLine();
    }

    table.Rows.RemoveAt(1);

    Console.WriteLine();
    foreach (DataRow r in table.Rows)
    {
        var items = r.ItemArray;
        foreach (var item in items)
            Console.Write($"{item.ToString()}\t");
        Console.WriteLine();
    }

}
void DataSetConnection()
{
    string connectionString = @"Data Source=DESKTOP-ISC66B9\MSSQLSERVER2022;Database=Shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    using (SqlConnection connection = new(connectionString))
    {
        // SqlDataAdapter adapter = new SqlDataAdapter();

        // SqlCommand command = new SqlCommand();
        // SqlDataAdapter adapter = new SqlDataAdapter(command);

        // SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TempTable", connection);
        // SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM TempTable", connectionString);

        SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Product";

        SqlDataAdapter adapter = new SqlDataAdapter(command);

        DataSet data = new DataSet();
        adapter.Fill(data);

        foreach (DataTable table in data.Tables)
        {
            foreach (DataColumn column in table.Columns)
                Console.Write($"{column.ColumnName}\t");
            Console.WriteLine();
            foreach (DataRow row in table.Rows)
            {
                var items = row.ItemArray;
                foreach (var item in items)
                    Console.Write($"{item.ToString()}\t");
                Console.WriteLine();
            }
        }
    }
}
    