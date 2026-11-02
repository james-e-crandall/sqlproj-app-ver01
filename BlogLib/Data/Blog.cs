namespace BlogLib.Data;

public class Blog
{
    public int Id { get; set; }
    public BlogHeader? Header { get; set; } // Reference navigation to dependent
    public BlogFooter? Footer { get; set; } // Reference navigation to dependent
    public ICollection<Post> Posts { get; } = new List<Post>(); // Collection navigation containing dependents
}

