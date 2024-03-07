using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Specification.EFCore;

namespace Specification.Logic.Movies;

public class MovieRepository
{
    private SpecPatternContext _context;
    public MovieRepository(SpecPatternContext context)
    {
        _context = context;
    }

    public Maybe<Movie> GetOne(Guid id)
    {
        return _context.Movies.SingleOrDefault(m => m.Id == id);
    }

    public IReadOnlyList<MovieDto> GetList(
        Specification<Movie> specification,
        double minimumRating,
        int page = 0,
        int pageSize = 20)
    {
        var expression = specification.ToExpression();
       

        return _context.Movies.Where(specification.ToExpression())
            .Include(x => x.Director)
            .ToList()
            .Select(x => new MovieDto
        {
            Name = x.Name,
            Director = x.Director.Name,
            Genre = x.Genre,
            Id = x.Id,
            MpaaRating = x.MpaaRating.ToString(),
            Rating = x.Rating,
            ReleaseDate = x.ReleaseDate
        })
                .ToList();

        return _context.Movies.Where(specification.ToExpression())
                .Where(x => x.Rating >= minimumRating)
                .Skip(page * pageSize)
                .Take(pageSize)
                .Include(x => x.Director)
                .ToList().Select(x => new MovieDto
                {
                    Name = x.Name,
                    Director = x.Director.Name,
                    Genre = x.Genre,
                    Id = x.Id,
                    MpaaRating = x.MpaaRating.ToString(),
                    Rating = x.Rating,
                    ReleaseDate = x.ReleaseDate
                })
                .ToList();
        
    }
}

