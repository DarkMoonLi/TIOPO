using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckClocks.Models
{
    public class Product
    {
        int Id { get; set; }
        byte CategoryId { get; set; }
        string? Title { get; set; }
        string? Alias { get; set; }
        string? Content { get; set; }
        float Price { get; set; }
        float OldPrice { get; set; }
        byte Status { get; set; }
        List<string>? Keywords { get; set; }
        string? Description { get; set; }
        byte Hit { get; set; }
    }
}
