
//Entity Framework database first approach
//1. database and tables creation
//2.Installing EF Core with
//   - dotnet add package Microsoft.EntityFrameworkCore.SqlServer
//   - dotnet add package Microsoft.EntityFrameworkCore.Tools
//    commands.
//    Generating the model classes and DbContext with
// dotnet ef dbcontext scaffold "Data Source=(localdb)\mssqllocaldb;
// Initial Catalog=LibraryDB1;Integrated Security=True; 
// Pooling=False" Microsoft.EntityFrameworkCore.SqlServer -o Models
// command;
//  
using LibMan01.Models;
using System;

string ver = "1.0";
Console.WriteLine($"Welcome to the Library Manager v. {ver} !\n" +
    $"Please select the table you want to work on \n" +
    $"1. Borrowers \n" +
    $"2. Books");

string borb = Console.ReadLine();

if (borb == "1")
{

    Console.WriteLine($"You are browsing the 'Borrowers' table.\n" +
        $" \n" +
        $"Please select:\n" +
        $"1. Add a record\n" +
        $"2. Read whole table\n" +
        $"3. Update a record\n" +
        $"4. Delete a record\n");

    string input = Console.ReadLine();


    if (input == "1")
    {

        //create

        using (var context = new LibraryDb1Context())
        {
            Console.WriteLine("Please enter a name you want to add in a 'Name SecondName' format");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter an email address you want to add to the record");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter a phone number you want to add to the record");
            string phonenumber = Console.ReadLine();
            Console.WriteLine("Please enter a total number of borrowed books associated with the record");
            int totborbooks = Convert.ToInt32(Console.ReadLine());
            var borrower = new Borrower { Name = name, Email = email, Phone = phonenumber, TotalBorrowedBooks = totborbooks };
            context.Borrowers.Add(borrower);
            context.SaveChanges();
        }
    }
    else if (input == "2")
    {
        // read

        using (var context = new LibraryDb1Context())
        {
            var borrowers = context.Borrowers.ToList();
            foreach (var borrower in borrowers)
            {
                Console.WriteLine($"BorrowerID: {borrower.BorrowerId}| Name: {borrower.Name}| Email: {borrower.Email}| TotalBorrowedBooks: {borrower.TotalBorrowedBooks}");
            }
        }
    }

    else if (input == "3")
    {


        //update

        using (var context = new LibraryDb1Context())
        {
            Console.WriteLine("Select the BorrowerID you want to update");
            int borIDupdate = Convert.ToInt32(Console.ReadLine());
            var borrower = context.Borrowers.FirstOrDefault(p => p.BorrowerId == borIDupdate);
            if (borrower != null)
            {

                Console.WriteLine("Please enter an updated name in a 'Name SecondName' format");
                string name = Console.ReadLine();
                borrower.Name = name;
                Console.WriteLine("Please enter an updated email address");
                string email = Console.ReadLine();
                borrower.Email = email;
                Console.WriteLine("Please enter an updated phone number");
                string phonenumber = Console.ReadLine();
                borrower.Phone = phonenumber;
                Console.WriteLine("Please enter an updated total number of borrowed books");
                int totborbooks = Convert.ToInt32(Console.ReadLine());
                borrower.TotalBorrowedBooks = totborbooks;

                context.SaveChanges();
            }
        }
    }
    else if (input == "4")
    {
        //delete

        using (var context = new LibraryDb1Context())
        {
            Console.WriteLine("Select the BorrowerID you want to delete");
            int borIDdelete = Convert.ToInt32(Console.ReadLine());
            var borrower = context.Borrowers.FirstOrDefault(p => p.BorrowerId == borIDdelete);
            if (borrower != null)
            {
                context.Borrowers.Remove(borrower);
                context.SaveChanges();
            }
        }
    }

    else
        Console.WriteLine("Wrong input, you need to choose an option by typing 1, 2, 3 or 4");
}
else if (borb == "2")
{
    Console.WriteLine($"You are browsing the 'Books' table.\n" +
       $" \n" +
       $"Please select:\n" +
       $"1. Add a record\n" +
       $"2. Read whole table\n" +
       $"3. Update a record\n" +
       $"4. Delete a record\n");

    string input = Console.ReadLine();

    if (input == "1")
    {

        //create

        using (var context = new LibraryDb1Context())
        {
            Console.WriteLine("Please enter a book title you want to add");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter an author of the book you want to add");
            string author = Console.ReadLine();
            Console.WriteLine("Please enter an ISBN number you want to add to the record");
            string isbn = Console.ReadLine();
            Console.WriteLine("Please enter an availability status of the book associated with the record, \n" +
                " '0' for not available and '1' for available");
            int avail = Convert.ToInt32(Console.ReadLine());
            var book = new Book { Title = title, Author = author, Isbn = isbn, Availability = avail };
            context.Books.Add(book);
            context.SaveChanges();
        }
    }
    else if (input == "2")
    {
        // read

        using (var context = new LibraryDb1Context())
        {
            var books = context.Books.ToList();
            foreach (var book in books)
            {
                Console.WriteLine($"BookID: {book.BookId}| Title: {book.Title}| Author: {book.Author}| ISBN: {book.Isbn}|Avaialability: {book.Availability}");
            }
        }
    }

    else if (input == "3")
    {


        //update

        using (var context = new LibraryDb1Context())
        {
            Console.WriteLine("Select the BookID you want to update");
            int bookIDupdate = Convert.ToInt32(Console.ReadLine());
            var book = context.Books.FirstOrDefault(p => p.BookId == bookIDupdate);
            if (book != null)
            {

                Console.WriteLine("Please enter an updated Title");
                string title = Console.ReadLine();
                book.Title = title;
                Console.WriteLine("Please enter an updated Author name");
                string author = Console.ReadLine();
                book.Author = author;
                Console.WriteLine("Please enter an updated ISBN number");
                string isbn = Console.ReadLine();
                book.Isbn = isbn;
                Console.WriteLine("Please enter an updated availability status for the book");
                int avail = Convert.ToInt32(Console.ReadLine());
                book.Availability = avail;

                context.SaveChanges();
            }
        }
    }
    else if (input == "4")
    {
        //delete

        using (var context = new LibraryDb1Context())
        {
            Console.WriteLine("Select the BookID you want to delete");
            int bookIDdelete = Convert.ToInt32(Console.ReadLine());
            var book = context.Books.FirstOrDefault(p => p.BookId == bookIDdelete);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }

    }

    else
        Console.WriteLine("Wrong input, you need to choose either '1' for 'Borrowers' table or '2' for 'Books' table.");
}