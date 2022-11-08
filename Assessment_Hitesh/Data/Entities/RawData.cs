using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment_Hitesh.Data.Entities;

public class RawData
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string? Question { get; set; }
    public int Score { get; set; }
}