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

    public void InsertTech(Tech tech)
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
            Console.WriteLine(ex);
        }
        connection.Close();
    }

    public void UpdateTech(Tech tech)
    {
        connection.Open();
        string sql =
            "UPDATE TechInventory142.Equipment SET InvNumber=@InvNumber, Name=@Name, PurchaseDate=@PurchaseDate, Cost=@Cost, IsWrittenOff=@IsWrittenOff, CurrentEmployeeId=@CurrentEmployeeId WHERE Id=tech.Id";
        try
        {
            using (var mc = new MySqlCommand(sql, connection))
            {
                mc.Parameters.AddWithValue("@InvNumber", tech.InvNumber);
                mc.Parameters.AddWithValue("@Name", tech.Name);
                mc.Parameters.AddWithValue("@PurchaseDate", tech.PurchaseDate);
                mc.Parameters.AddWithValue("@Cost", tech.Cost);
                mc.Parameters.AddWithValue("@IsWrittenOff", tech.IsWrittenOff);
                mc.Parameters.AddWithValue("@CurrentEmployeeId", tech.CurrentEmployeeId);
                mc.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        connection.Close();
    }
}