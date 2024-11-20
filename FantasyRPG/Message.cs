namespace FantasyRPG;

public class Message
{
    private List<string> messages = new List<string>();

    public void Add(string value)
    {
        messages.Add(value);
    }

    public void Show()
    {
        foreach (string value in messages)
        {
            Console.WriteLine(value);
        }
    }

    public int Size()
    {
        return messages.Count;
    }
}
