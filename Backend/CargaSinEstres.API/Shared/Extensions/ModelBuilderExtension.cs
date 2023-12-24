using Microsoft.EntityFrameworkCore;

namespace CargaSinEstres.API.Shared.Extensions;

/// <summary>
/// Provides extension methods for configuring Entity Framework Core model with snake_case naming convention.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public static class ModelBuilderExtensions
{
    /// <summary>
    /// Configures the Entity Framework Core model with snake_case naming convention for tables, columns, keys, foreign keys, and indexes.
    /// </summary>
    /// <param name="builder">The <see cref="ModelBuilder"/> instance to configure.</param>
    public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName().ToSnakeCase());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnBaseName().ToSnakeCase());
            }

            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName().ToSnakeCase());
            }

            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
            }
        }
    }
}