using Application.Models.Recipes;
using Application.Services.Recipe;
using Microsoft.AspNetCore.Components;

namespace UI.Components;

public partial class HomeComponent
{
    [Inject] public IRecipeService RecipeService { get; set; } = null!;


    public List<RecipeDto> Recipes { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Recipes = await RecipeService.GetAllRecipes();
        await base.OnInitializedAsync();
    }
}