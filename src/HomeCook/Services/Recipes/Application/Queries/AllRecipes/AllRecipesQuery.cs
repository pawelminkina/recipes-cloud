using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.AllRecipes;

public class AllRecipesQuery : IRequest<IEnumerable<Recipe>>
{

}

public class AllRecipesQueryHandler : IRequestHandler<AllRecipesQuery, IEnumerable<Recipe>>
{
    private readonly IRecipeDbContext _dbContext;

    public AllRecipesQueryHandler(IRecipeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Recipe>> Handle(AllRecipesQuery request, CancellationToken cancellationToken)
    {
        var recipes = await _dbContext.Recipes.Select(s => new Recipe()
        {
            AuthorEmail = s.AuthorEmail,
            Id = s.Id,
            MainPhotoId = s.MainPhotoId,
            Title = s.Title
        }).ToListAsync(cancellationToken);

        return recipes;
    }
}