using System;

namespace ConsoleApp2_assignment { 
internal class Book
{
    // private int id;
    // private string? title;
    // private string? author;
    // private double price;
    public int Id{get; set;}
    public string Title{get; set;}
    public string Author{get; set;}
    public double Price{get; set;}

        
    public Book(){}
    public Book(int id, string title, string author, double price)
    {
        Id = id;
        Price = price;
        Author = author;
        Title = title;
    }

    public void displayInfo()
    {
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"Book ID: {this.Id} \nTitle: {this.Title} \nAuthor: {this.Author} \nPrice: {this.Price}");
        Console.WriteLine("-----------------------------");
    }
    }
}