using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.CreateRecipe;

public class CreateRecipeCommand : IRequest<Guid>
{
    public RecipeToCreate? Recipe { get; }

    public CreateRecipeCommand(RecipeToCreate? recipe)
    {
        Recipe = recipe;
    }
}

public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Guid>
{
    private readonly IRecipeDbContext _dbContext;

    public CreateRecipeCommandHandler(IRecipeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        if (request.Recipe == null) 
            throw new ArgumentNullException(nameof(CreateRecipeCommand.Recipe));

        var recipeToCreate = new Recipe()
        {
            AuthorEmail = request.Recipe.AuthorEmail,
            Content = request.Recipe.Content,
            MainPhotoId = request.Recipe.MainPhotoId,
            Title = request.Recipe.Title
        };
        _dbContext.Recipes.Add(recipeToCreate);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return recipeToCreate.Id;
    }
}