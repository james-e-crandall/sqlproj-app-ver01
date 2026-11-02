namespace BlogLib.Data;
public class Post
{
    public int Id { get; set; }
    public int BlogId { get; set; } // Required foreign key property
    public Blog Blog { get; set; } = null!; // Required reference navigation to principal
    public List<PostTag> PostTags { get; } = [];
    public List<Tag> Tags { get; } = [];
}

