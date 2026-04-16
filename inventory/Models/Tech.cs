using System;

namespace inventory.Models;

public class Tech
{
    public int Id { get; set; }
    public string InvNumber { get; set; }
    public string Name { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Cost { get; set; }
    public int IsWrittenOff { get; set; }
    public int CurrentEmployeeId { get; set; }
    public string CurrentEmployeeFullName { get; set; } 
}