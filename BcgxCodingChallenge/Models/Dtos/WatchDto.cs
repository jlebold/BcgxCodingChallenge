namespace BcgxCodingChallenge.Models.Dtos;

public class WatchDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public int Price { get; set; }
    public int? DiscountPrice { get; set; }
    public int? DiscountUnits { get; set; }
}
