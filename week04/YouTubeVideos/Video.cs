public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string videoTitle, string videoAuthor, int length)
    {
        _title = videoTitle;
        _author = videoAuthor;
        _lengthInSeconds = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLengthSeconds()
    {
        return _lengthInSeconds;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}