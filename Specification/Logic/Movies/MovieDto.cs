namespace Specification.Logic.Movies;

public class MovieDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string MpaaRating { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }
    public string Director { get; set; }
}
