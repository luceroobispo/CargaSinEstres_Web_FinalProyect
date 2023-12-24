using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CargaSinEstres.API.Shared.Extensions;

/// <summary>
/// Provides extension methods for working with ModelStateDictionary.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public static class ModelStateExtensions
{
    /// <summary>
    /// Gets a list of error messages from the ModelStateDictionary.
    /// </summary>
    /// <param name="dictionary">The <see cref="ModelStateDictionary"/> instance.</param>
    /// <returns>A list of error messages.</returns>
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary.SelectMany(m => m.Value.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }

}