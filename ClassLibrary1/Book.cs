namespace ClassLibrary1;

public class Book(string title, int pages, double price) : IComparable<Book>
{
    private string? Title { get; } = title;

    private int NumPages { get; } = pages;

    public double Price { get; } = price;

    public override string ToString()
    {
        return $"Title: {Title}\nPages: {NumPages}\nPrice: {Price:C2}";
    }

    public int CompareTo(Book other)
    {
        return NumPages.CompareTo(other.NumPages);
    }
}