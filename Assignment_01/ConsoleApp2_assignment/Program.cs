using System;
namespace ConsoleApp2_assignment { 
internal class Program
{  
    static void menu()
    {
        BookDataAccess bda = new BookDataAccess();

        while (true) { 
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add Book\n2. View All Books\n3. Find Book by ID\n4. Create Backup\n5. Exit");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
                bda.AddBook();
            else if (choice == 2)
                bda.viewBooks();
            else if (choice == 3)
                bda.findBook();
            else if (choice == 4)
                bda.createBackup();
            else return;
        }
    }
    static void Main(string[] args)
    {
        menu();
    }   
}
}