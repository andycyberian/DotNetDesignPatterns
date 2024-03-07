using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Specification.EFCore;
using Specification.Logic.Movies;

var serviceCollection = new ServiceCollection();

serviceCollection.AddDbContext<SpecPatternContext>();

var serviceProvider = serviceCollection.BuildServiceProvider();

var context = serviceProvider.GetService<SpecPatternContext>();
await context.Database.MigrateAsync();

var _repository = new MovieRepository(context);

var forKidsOnly = true;
var onCD = true;
var minimumRating = 0;

Specification<Movie> spec = Specification<Movie>.All;

if (forKidsOnly)
{
    spec = spec.And(new MovieForKidsSpecification());
}
if (onCD)
{
    spec = spec.And(new AvailableOnCDSpecification());
}

var movies = _repository.GetList(spec, minimumRating);


Console.ReadLine();