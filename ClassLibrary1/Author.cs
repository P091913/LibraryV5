namespace ClassLibrary1;

public class Author
{
    private string AuthId { get; set; }
    private string? _authName;
    private List<Book> AuthBooks { get; set; } = [];
    public double Total { get; private set; }

    public string? AuthName
    {
        get => _authName; // return the value of the private _authName field
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Author name cannot be null or empty.");
            }

            _authName = value;
        }
    }


    // public constructor
    public Author(string id, string? name)
    {
        AuthId = id;
        AuthName = name;
    }

    // public constructor
    public Author(string id, string? name, List<Book> b)
    {
        AuthId = id;
        AuthName = name;
        AuthBooks = b;
    }

    public double CalcTotal()
    {
        //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/from-clause
        Total = (from books in AuthBooks select books.Price).Sum();
        return Total;
    }
    
    // operator+ overload author class, creaste a new author objects that combines
    // both 1 and 2, doesn't modify original 2
    // copies authors 1 auth_id and authname
    // merges books from both
    public static Author operator +(Author author1, Author author2)
    {
        // Create a new Author object to store the result
        var resultAuthor = new Author(author1.AuthId, author1.AuthName);

        // Combine the books of both authors
        var combinedBooks = new List<Book>();
        combinedBooks.AddRange(author1.AuthBooks);
        combinedBooks.AddRange(author2.AuthBooks);

        // Set the combined books to the resultAuthor
        resultAuthor.AuthBooks = combinedBooks;

        return resultAuthor;
    }

    public override string ToString()
    {
        string bookList = string.Join("\n", AuthBooks.Select(b => b.ToString()));
        return ($"{AuthName}:" +
                $"\n\tID: {AuthId}" +
                $"\n\tTotal: {CalcTotal():C}" +
                $"\n\tBooks:\n{bookList}");
    }
}