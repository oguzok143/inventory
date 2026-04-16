using System;

namespace inventory.Models;

public class VisualTech
{
    //удалить
    public string InvNumber { get; set; }
    public string Name { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Cost { get; set; }
    public string IsWrittenString { get; set; }
    public string CurrentEmployeeName { get; set; }
}