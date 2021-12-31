namespace HomeworkServicesAPI6.Models
{
    public class Result
    {
            public int Status { get; set; }
            public string? Message { get; set; }
            public List<Product>? Products { get; set; }
    }
}
