using System;
using System.ComponentModel.Design;
using System.IO;
namespace ConsoleApp2_assignment { 

internal class BookDataAccess
{
    public void AddBook()
    {
        Console.WriteLine("Enter the book details below:");
        Console.Write("ID: ");
        int id;
        //int id = int.Parse(Console.ReadLine());
        while(!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("Invalid ID. IDs start from 1.");
                Console.Write("ID: ");
            }

        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Author: ");
        string author = Console.ReadLine();

        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine());

        StreamWriter fout = new StreamWriter("books.txt", true);

        Book book = new Book(id, title, author, price);

        fout.WriteLine($"{book.Id},{book.Title},{book.Author},{book.Price}");

        fout.Close();
    }

    public void viewBooks()
    {
        StreamReader fin = new StreamReader("books.txt");
        string line = fin.ReadLine();
        if (line == null)
        {
            Console.WriteLine("No books found");
            return;
        }

        while (line != null)
        {
            string[] data = line.Split(',');
            Book book = new Book();
            book.Id = int.Parse(data[0]);
            book.Title = data[1];
            book.Author = data[2];
            book.Price = double.Parse(data[3]);
            book.displayInfo();
            line = fin.ReadLine();
        }
        fin.Close();
    }

    public void findBook()
    {
        Console.Write("Enter the book ID: ");
        //int id = int.Parse(Console.ReadLine());
        int id;
        while(!int.TryParse(Console.ReadLine(), out id) || id <= 0)
        {
            Console.WriteLine("Invalid ID. IDs start from 1.");
            Console.Write("Enter the book ID: ");
        }

        StreamReader fin = new StreamReader("books.txt");
        string line = fin.ReadLine();
        if (line == null)
        {
            Console.WriteLine("Book not found");
            return;
        }

        while (line != null)
        {
            string[] data = line.Split(',');
            if (id == int.Parse(data[0]))
            {
                Book book = new Book();
                book.Id = int.Parse(data[0]);
                book.Title = data[1];
                book.Author = data[2];
                book.Price = double.Parse(data[3]);
                book.displayInfo();
                return;
            }
            line = fin.ReadLine();
        }
        fin.Close();
    }

    public void createBackup()
    {
        // StreamReader fin = new StreamReader("books.txt");
        // StreamWriter fout = new StreamWriter("books_backup.txt", true);
        // string? line = fin.ReadLine();
        // while(line != null)
        // {
        //     fout.WriteLine(line);
        //     line = fin.ReadLine();
        // }
        // fin.Close();
        // fout.Close();
        // Console.WriteLine("Backup created successfully");
        FileStream fout = new FileStream("books_backup.txt", FileMode.Append);
        FileStream fin = new FileStream("books.txt", FileMode.Open);
        int data = fin.ReadByte();
        while(data != -1)
        {
            fout.WriteByte((byte)data);
            data = fin.ReadByte();
        }
        fout.Close();
        fin.Close();
        Console.WriteLine("Backup created successfully");
    }
    }
}