using Application.Models.Recipes;
using Application.Services.Recipe;
using Microsoft.AspNetCore.Components;

namespace UI.Components;

public partial class ViewRecipeComponent : ComponentBase
{
    [Parameter] public Guid RecipeId { get; set; }

    [Inject] public IRecipeService RecipeService { get; set; } = null!;
    private bool IsLoading { get; set; } = true;

    public RecipeDetailsDto? Recipe { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        Recipe = await RecipeService.GetRecipeDetails(RecipeId);

        IsLoading = false;

        await base.OnInitializedAsync();
    }
}