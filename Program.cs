using System.Xml.Linq;

public class ConsoleWorkspace
{
    private Library MyLib = new Library();
    public void InitiateStart()
    {
        Console.WriteLine("Greetings! You are currently working with a Library Management System (LMS)");
        ActivateMenu();
    }

    public void ActivateMenu() //выношу в отдельный метод, т. к. пригождается в нескольких местах
    {
        Console.WriteLine("\n~~~ Provide a sensible output ~~~");
        Console.WriteLine("Type 1 : Book management ");
        Console.WriteLine("Type 2 : User Management");
        Console.WriteLine("Type 3 : Borrowing Operations");
        Console.WriteLine("Type 0 : Exit\n");

        switch (Console.ReadLine())
        {
            case "1":
                BookManagement();
                break;

            case "2": 
                UserManagement();
                break;

            case "3":
                BorrowedManagement();
                break;
                
            case "0": break;

            default: Console.WriteLine("\nYou have entered incomprehensible input. Try again\n"); ActivateMenu(); break;
        }

    }

    private void BookManagement()
    {
        Console.WriteLine("\n~~~ Proceed ~~~");
        Console.WriteLine("Type 1: Add book");  
        Console.WriteLine("Type 2: Remove book");  
        Console.WriteLine("Type 3: Search book");
        Console.WriteLine("Type 4: Borrow book");
        Console.WriteLine("Type 0 : Exit\n");

        string user_ans_1, user_ans_2, user_ans_3, user_ans_4;
        
        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine("\n~~~ Write the title ~~~\n");
                user_ans_1 = Console.ReadLine();
                Console.WriteLine("\n~~~ Write the author ~~~\n");
                user_ans_2 = Console.ReadLine();
                Console.WriteLine("\n~~~ Write the isbn ~~~\n");
                user_ans_3 = Console.ReadLine();
                Console.WriteLine("\n~~~ Write the genre ~~~\n");
                user_ans_4 = Console.ReadLine();

                // Check if everything is fine

                MyLib.addBook(user_ans_1, user_ans_2, user_ans_3, user_ans_4);
                break;

            case "2":
                Console.WriteLine("\n~~~ Write the isbn ~~~\n");
                user_ans_1 = Console.ReadLine();
                if (MyLib.removeBook(user_ans_1))
                {
                    Console.WriteLine("\nGranted! The book is absolutely annihialted\n");
                }
                else
                {
                    Console.WriteLine("\nThere is no book with such isbn. Try again\n");
                }

                break;


            case "3":

                Console.WriteLine("\n~~~ Configure search ~~~");
                Console.WriteLine("Type 1: By title");
                Console.WriteLine("Type 2: By author");
                Console.WriteLine("Type 3: By isbn\n");

                user_ans_1 = Console.ReadLine(); //exception
                List<Book> tmpList;

                switch (user_ans_1)
                {
                    case "1":
                        Console.WriteLine("\n~~~ Provide the title ~~~");
                        user_ans_2 = Console.ReadLine();
                      
                        tmpList = MyLib.searchBooks(user_ans_2, "Title");
                        if (tmpList.Count != 0)
                        {
                            foreach (Book x in tmpList)
                            {
                                Console.WriteLine(x);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no books with this title");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n~~~ Provide the author ~~~");
                        user_ans_2 = Console.ReadLine();

                        tmpList = MyLib.searchBooks(user_ans_2, "Author");
                        if (tmpList.Count != 0)
                        {
                            foreach (Book x in tmpList)
                            {
                                Console.WriteLine(x);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThere are no books with this author\n");
                        }
                        break;

                    case "3":
                        Console.WriteLine("\n~~~ Provide isbn ~~~");
                        user_ans_2 = Console.ReadLine();
                        try
                        {

                            Console.WriteLine(MyLib.findBook(user_ans_2));
                        }
                        catch (KeyNotFoundException)
                        {
                            Console.WriteLine("\nThere is no book with such isbn. Try again\n");
                        }
                        break;

                    default: Console.WriteLine("\nYou have entered incomprehensible input. Try again\n"); break;
                }
                break;

            case "0": break;
            default: Console.WriteLine("\nYou have entered incomprehensible input. Try again\n"); break;
        }
        ActivateMenu();
    }

    private void UserManagement()
    {
        Console.WriteLine("\n~~~ Proceed ~~~");
        Console.WriteLine("Type 1: Add user\n");
        //Console.WriteLine("Type 2: Remove user");

        string user_ans_1, user_ans_2, user_ans_3, user_ans_4;
        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine("\n~~~ Write user's name ~~~\n");
                user_ans_1 = Console.ReadLine();
                Console.WriteLine("\n~~~ Write user's id ~~~\n");
                user_ans_2 = Console.ReadLine();
                Console.WriteLine("\n~~~ Write user's email ~~~\n");
                user_ans_3 = Console.ReadLine();
                Console.WriteLine("\n~~~ Write user's type ~~~");
                Console.WriteLine("Type G: Guest");
                Console.WriteLine("Type S: Student");
                Console.WriteLine("Type F: Faculty\n");


                user_ans_4 = Console.ReadLine();

                switch (user_ans_4)
                {
                    case "G": MyLib.registerUser(user_ans_1, user_ans_2, user_ans_3, "G"); Console.WriteLine("\nUser was added succesfuly!\n"); break;
                    case "S": MyLib.registerUser(user_ans_1, user_ans_2, user_ans_3, "S"); Console.WriteLine("\nUser was added succesfuly!\n"); break;
                    case "F": MyLib.registerUser(user_ans_1, user_ans_2, user_ans_3, "F"); Console.WriteLine("\nUser was added succesfuly!\n"); break;
                    default: Console.WriteLine("\nYou have entered incomprehensible input. Try again\n"); ActivateMenu(); break;
                }
                
                break;

            //case "2":
            //    Console.WriteLine("\n~~~ Write user's id ~~~\n");
            //    user_ans_1 = Console.ReadLine();

            //    MyLib.
            //    break; //TODO

            default: Console.WriteLine("\nYou have entered incomprehensible input. Try again\n"); ActivateMenu(); break;
        }
        ActivateMenu();
    }

    private void BorrowedManagement()
    {
        Console.WriteLine("\n~~~ Proceed ~~~");
        Console.WriteLine("Type 1: Add a borrowed book");
        Console.WriteLine("Type 2: Return a borrowed book");
        Console.WriteLine("Type 3: Track overdue books");
        string user_ans_1, user_ans_2, user_ans_3, user_ans_4;


        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine("~~~ Provide user_id ~~~");
                user_ans_1 = Console.ReadLine();
                Console.WriteLine("~~~ Provide isbn ~~~");
                user_ans_2 = Console.ReadLine();
                if (MyLib.borrowBook(user_ans_1, user_ans_2))
                {
                    Console.WriteLine("\nThe book was given to the user! \n");
                }
                else
                {
                    Console.WriteLine("\nThe book can't be given to the user! \n");
                }
                break;

            case "2":
                Console.WriteLine("~~~ Provide user_id ~~~");
                user_ans_1 = Console.ReadLine();
                Console.WriteLine("~~~ Provide isbn ~~~");
                user_ans_2 = Console.ReadLine();
                if (MyLib.returnBook(user_ans_1, user_ans_2))
                {
                    Console.WriteLine("\nThe book was returned! \n");
                }
                else
                {
                    Console.WriteLine("\nThe book wasn't returned! Try again!\n");
                }
                break;

            case "3":
                if (MyLib.getOverdueBooks().Count != 0)
                {
                    Console.WriteLine(MyLib.getOverdueBooks().ToString());
                }
                else
                {
                    Console.WriteLine("\nThere are no overdue books!\n");
                }
                break;

            default: Console.WriteLine("\nYou have entered incomprehensible input. Try again\n"); ActivateMenu(); break;
        }
        ActivateMenu();
    }
}


public interface LibraryOperations
{
    void addBook(string title, string author, string isbn, string genre);
    bool removeBook(string isbn);
    public Book findBook(string isbn);
    List<Book> searchBooks(string query, string type);

    void registerUser(string name, string user_id, string email, string type);
    User findUser(string user_id);

    
    bool borrowBook(string user_id, string isbn);
    bool returnBook(string user_id, string isbn);
    Dictionary<Book, DateTime> getOverdueBooks();
}

public class Library : LibraryOperations
{
    Dictionary<string, Book> books; //Это как hashmap, для быстрого поиска
    Dictionary<string, User> users;
    Dictionary<Book, DateTime> takenbooks;

    public Library()
    {
        books = new Dictionary<string, Book>();
        users = new Dictionary<string, User>();
        List<Book> borrowingHistory = new List<Book>(); // Chronological order
        //genres = new HashSet<>();          // Unique genres only
    }

    public void addBook(string title, string author, string isbn, string genre)
    {
        books.Add(isbn, new Book(title, author, isbn, genre));
        Console.WriteLine("\nBook succesfully added!\n");
    }

    public bool removeBook(string isbn) //UPDATE
    {
        return books.Remove(isbn);
    }

    public Book findBook(string isbn)
    {
        return books[isbn];
    }

    public List<Book> searchBooks(string query, string type)
    {
        List<Book> temp_list = new List<Book>();  //подумать, как сделать лучше
        switch (type)
        {
            case "Author":
                foreach (var x in books)
                {
                    if (x.Value.GetAuthor == query)
                        temp_list.Add(x.Value);
                }
                break;

            case "Title":
                foreach (var x in books)
                {
                    if (x.Value.GetTitle == query)
                        temp_list.Add(x.Value);
                }
                break;

            default:
                throw new Exception("BOOKSEARCH IS CONFIGURED WRONG");
        }
        return temp_list;
    }


    public void registerUser(string name, string user_id, string email, string type)
    {
        switch (type)
        {
            case "G": users.Add(user_id, new Guest(name, user_id, email)); break;
            case "S": users.Add(user_id, new Student(name, user_id, email)); break;
            case "F": users.Add(user_id, new Faculty(name, user_id, email)); break;
            default: throw new Exception("No such type of user");
        }
    }

    public User findUser(string user_id)
    {
        return users[user_id];
    }

    public bool borrowBook(string user_id, string isbn)
    {
        try { findBook(isbn); } catch (KeyNotFoundException) { Console.WriteLine("\nThere is no book with such isbn. Try again\n"); return false; }
        try { findUser(user_id); } catch (KeyNotFoundException) { Console.WriteLine("\nThere is no user with such id. Try again\n"); return false; }


        if (findUser(user_id).canBorrow())
        {
            findUser(user_id).AddBorrowedBook(findBook(isbn));

            var book = findBook(isbn);
            book.WasTaken = true;     //Меняю значение в словаре так, ведь иначе не позволит мне добраться до value
            book.WhenTaken = DateTime.Now;
            books[isbn] = book;

            return true;
        }
        else { return false; }
    }

    public bool returnBook(string user_id, string isbn)
    {
        try { findBook(isbn); } catch (KeyNotFoundException) { Console.WriteLine("\nThere is no book with such isbn. Try again\n"); return false; }
        try { findUser(user_id); } catch (KeyNotFoundException) { Console.WriteLine("\nThere is no user with such id. Try again\n"); return false; }


        if (findUser(user_id).BorrowedBooks.Contains(findBook(isbn)))
        {
            findUser(user_id).RemoveBorrowedBook(findBook(isbn));

            var book = findBook(isbn);
            book.WasTaken = false;     //Меняю значение в словаре так, ведь иначе не позволит мне добраться до value
            book.WhenTaken = DateTime.MinValue;
            books[isbn] = book;

            return true;
        }
        else { return false; }
    }
    public Dictionary<Book, DateTime> getOverdueBooks()
    {
        Dictionary<Book, DateTime> tmpdict = new Dictionary<Book, DateTime>();
        foreach (var user in users.Values)
        {
            foreach (Book book in user.BorrowedBooks)
            {
                if (book.WhenTaken > DateTime.Now.AddDays(-user.getBorrowDays()))
                {
                    tmpdict.Add(book, book.WhenTaken.AddDays(user.getBorrowDays()));
                }    
            }
                   
        }
        return tmpdict;
    }
}


public struct Book // Использовать структуру уместно, так как книга - объект с большим количеством свойств, который не требует функционал класса
{
    private string title;
    private string author;
    private string isbn;
    private string genre;
    private bool taken;
    private DateTime time_taken;

    public Book (string title, string author, string isbn, string genre)
    {
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        this.genre = genre;
        taken = false;
        time_taken = DateTime.MinValue;
    }

    public override string ToString()
    {
        return $"\nTitle: {title}\nAuthor: {author}\nIsbn: {isbn}\nGenre:{genre}\n";
    }

    internal bool WasTaken
    {
        get { return taken; }
        set { taken = value; }
    }

    public DateTime WhenTaken
    {
        get { return time_taken; }
        set { time_taken = value; }
    }

    public string GetAuthor
    {
        get { return author; }
    }
    public string GetTitle
    {
        get { return title; }
    }

}


public abstract class User
{
    protected string name;
    protected string user_id;
    protected string email;
    protected List<Book> borrowed_books;

    public void AddBorrowedBook(Book book)
    { 
        borrowed_books.Add(book);
    }

    public void RemoveBorrowedBook(Book book)
    {
        borrowed_books.Add(book);
    }
    public List<Book> BorrowedBooks
    {
        get { return borrowed_books; }
    }

    public User(string name, string user_id, string email)
    {
        this.name = name;
        this.user_id = user_id;
        this.email = email;
        borrowed_books = new List<Book>();
    }

    public abstract int getMaxBooks();
    public abstract int getBorrowDays();
    public abstract double getFinePerDay();

    public bool canBorrow()
    {
        return borrowed_books.Count < getMaxBooks();
    }

    //getters and setters and so on
}


public class Guest : User
{
    public Guest(string name, string user_id, string email) : base(name, user_id, email) { }
   

    override
    public int getMaxBooks() { return 1; }

    override
    public int getBorrowDays() { return 7; }

    override
    public double getFinePerDay() { return 5; }
}

public class Student : User 
{
    public Student(string name, string user_id, string email) : base(name, user_id, email) { }

    override
    public int getMaxBooks()
    { return 3; }

    override
    public int getBorrowDays()
    { return 14; }

    override
    public double getFinePerDay()
    { return 1; }
}

public class Faculty : User
{
    public Faculty(string name, string user_id, string email) : base(name, user_id, email) { }

    override
    public int getMaxBooks()
    { return 10; }

    override
    public int getBorrowDays()
    { return 30; }

    override
    public double getFinePerDay()
    { return 2; }
}


class Program
{
    static void Main(string[] args)
    {
        ConsoleWorkspace consoleWorkspace = new ConsoleWorkspace();
        consoleWorkspace.InitiateStart();
    }
}

