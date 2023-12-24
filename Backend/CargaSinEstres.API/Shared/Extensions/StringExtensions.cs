namespace CargaSinEstres.API.Shared.Extensions;

/// <summary>
/// Provides extension methods for working with strings.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public static class StringExtensions
{
    /// <summary>
    /// Converts a string to snake_case.
    /// </summary>
    /// <param name="text">The input string.</param>
    /// <returns>The string converted to snake_case.</returns>
    public static string ToSnakeCase(this string text) //this : agregar extensión a ESTE objeto
    {
        static IEnumerable<char> Convert(CharEnumerator e) //CharEnumerator implementa IEnumerable
        {
            if (!e.MoveNext()) yield break;
            yield return char.ToLower(e.Current);
            while (e.MoveNext())
            {
                if (char.IsUpper(e.Current))
                {
                    yield return '_';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    yield return e.Current;
                }
            }
        }
        return new string(Convert(text.GetEnumerator()).ToArray()); //+EC ?
    }
}