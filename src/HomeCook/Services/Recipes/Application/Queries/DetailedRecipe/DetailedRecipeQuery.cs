using Application.Common.Interfaces;
using MediatR;

namespace Application.Queries.DetailedRecipe;

public class DetailedRecipeQuery : IRequest<RecipeDetails>
{
    public Guid RecipeId { get; }

    public DetailedRecipeQuery(Guid recipeId)
    {
        RecipeId = recipeId;
    }
}

public class DetailedRecipeQueryHandler : IRequestHandler<DetailedRecipeQuery, RecipeDetails?>
{
    private readonly IRecipeDbContext _dbContext;

    public DetailedRecipeQueryHandler(IRecipeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<RecipeDetails?> Handle(DetailedRecipeQuery request, CancellationToken cancellationToken)
    {
        var recipe = await _dbContext.Recipes.FindAsync(request.RecipeId);

        return recipe == null ? null : RecipeDetails.MapFromDomain(recipe);
    }
}