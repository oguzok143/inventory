using System;
using inventory.Models;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace inventory.DB;

public class TechRepository
{
    MySqlConnection connection;
    
    public TechRepository(IOptions<DatabaseConnection> conString)
    {
        connection = new MySqlConnection(conString.Value.ConnectionString);
    }

    public void Insert(Tech tech)
    {
        connection.Open();
        string sql = "INSERT into TechInventory142.Equipment (Id, InvNumber, Name, PurchaseDate, Cost, IsWrittenOff, CurrentEmployeeId) values (0, @InvNumber, @Name, @PurchaseDate, @Cost, @IsWrittenOff, @CurrentEmployeeId)";
        try
        {
            using (var mc = new MySqlCommand(sql, connection))
            {
                mc.Parameters.AddWithValue("@InvNumber", tech.InvNumber);
                mc.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            
        }
        connection.Close();
    }
}