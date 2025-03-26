using ClassLibrary1;

//throw away Author no books
Author bill = new Author("123", "Bill");


//Lemony with 1 book
Book badBeg = new Book("The bad Beginning", 200, 10);
// calls author constructor with lists of books badBeg
Author lemony = new Author(
    "1", 
    "Lemony Snicket", 
    new List<Book>(){badBeg}
);

//Print Lemony
Console.WriteLine(lemony.ToString());

// Create 3 new books objects
Book b1 = new Book("Book 1", 800, 25.99);
Book b2 = new Book("Book 2", 256, 32.99);
Book b3 = new Book("Book 3", 150, 43.59);

// list of books
// valid option 1
//List<Book> books = new List<Book>(){b1, b2, b3};

// valid option 2
List<Book> books = new List<Book>();
books.Add(b1);
books.Add(b2);
books.Add(b3);

books.Sort(); // sort books list, this will sort by our page number

// create new author 
Author jack = new Author("555", "Jack Lastly", books);

Console.WriteLine(jack.ToString());

// CalcTotal in my author class wil return the Sum() of all the books in tied
// to the author
jack.CalcTotal();
Console.WriteLine(jack.Total);


// Using custom getters and setters from my Author class 
jack.AuthName = "Jack The Second";
Console.WriteLine(jack.AuthName);

Author casey = jack + lemony;
Console.WriteLine(casey.ToString());