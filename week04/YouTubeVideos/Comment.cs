public class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string Name, string text)
    {
        _commenterName = Name;
        _text = text;
    }

    public string GetCommenterName()
    {
        return _commenterName;
    }

    public string GetText()
    {
        return _text;
    }
}