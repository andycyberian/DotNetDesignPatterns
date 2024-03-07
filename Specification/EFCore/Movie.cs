using Specification.Logic.Movies;

namespace Specification.EFCore;

public class Movie
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public DateTime ReleaseDate { get; set; }
    public MpaaRating MpaaRating { get; set; }
    public string Genre { get; set; } = default!;
    public double Rating { get; set; } = default!;

    public Guid DirectorId { get; set; }
    public virtual Director Director { get; set; }
}
