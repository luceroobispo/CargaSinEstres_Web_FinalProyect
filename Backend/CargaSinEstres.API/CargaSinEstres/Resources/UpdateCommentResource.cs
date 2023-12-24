namespace CargaSinEstres.API.CargaSinEstres.Resources;

/// <summary>
/// Represents a resource for updating comments.
/// </summary>
///<remarks> Grupo 1: Carga sin estres </remarks>
public class UpdateCommentResource
{
    /// <summary>
    /// Gets or sets the list of updated comments.
    /// </summary>
    public IList<CommentUpdatedResource> Comments { get; set; } = new List<CommentUpdatedResource>();
}