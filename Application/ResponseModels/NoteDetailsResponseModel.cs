namespace Application.NoteBooks.ResponseModels;

public class NoteDetailsResponseModel
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? LastActivityDate { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}