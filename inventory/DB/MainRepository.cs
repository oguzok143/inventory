using System;
using System.Collections.Generic;
using System.Data;
using inventory.Models;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace inventory.DB;

public class MainRepository
{
    MySqlConnection connection;

    public MainRepository(IOptions<DatabaseConnection> conString)
    {
        connection = new MySqlConnection(conString.Value.ConnectionString);
    }
    
    public List<Tech> GetTechs()
    {
        List<Tech> techs = new List<Tech>();
        try
        {
            connection.Open();
            string sql = "select e.Id, e.InvNumber, e.Name, e. PurchaseDate, e.Cost, e.IsWrittenOff, e.CurrentEmployeeId, e2.FullName  from Equipment e join Employees e2 on e.CurrentEmployeeId = e2.Id ;";
            using (var mc = new MySqlCommand(sql, connection))
            using (var dr = mc.ExecuteReader())
            {
                while (dr.Read())
                {
                    techs.Add(new Tech
                    {
                        Id = dr.GetInt32("Id"),
                        InvNumber = dr.GetString("InvNumber"),
                        Name = dr.GetString("Name"),
                        PurchaseDate = dr.GetDateTime("PurchaseDate"),
                        Cost = dr.GetDecimal("Cost"),
                        IsWrittenOff = dr.GetInt32("IsWrittenOff"),
                        CurrentEmployeeId = dr.GetInt32("CurrentEmployeeId"),
                        CurrentEmployeeFullName = dr.GetString("FullName")
                    });
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
        return techs;
    }
    
    public List<Employee> GetEmpyees()
    {
        List<Employee> employees = new List<Employee>();
        try
        {
            connection.Open();
            string sql = "select e.Id, e.FullName, e.PositionId, p.Name  from Employees e join Positions p on e.PositionId = p.Id;";
            using (var mc = new MySqlCommand(sql, connection))
            using (var dr = mc.ExecuteReader())
            {
                while (dr.Read())
                {
                    employees.Add(new Employee
                    {
                        Id = dr.GetInt32("Id"),
                        FullName = dr.GetString("FullName"),
                        PositionId = dr.GetInt32("PositionId"),
                        PositionName = dr.GetString("Name")
                    });
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
        return employees;
    }

    
    public List<Position> GetPositions()
    {
        List<Position> positions = new List<Position>();
        try
        {
            connection.Open();
            string sql = "select * from Positions;";
            using (var mc = new MySqlCommand(sql, connection))
            using (var dr = mc.ExecuteReader())
            {
                while (dr.Read())
                {
                    positions.Add(new Position
                    {
                        Id = dr.GetInt32("Id"),
                        Name = dr.GetString("Name"),
                    });
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
        return positions;
    }

}
