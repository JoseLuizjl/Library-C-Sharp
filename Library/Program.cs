using System;
using System.Collections.Generic;

namespace ConsoleAppDotNet
{
    internal class Program
    {
        static List<string> books = new List<string>
        {
            "One Hundred Years of Solitude",
            "1984",
            "The Little Prince",
            "Don Quixote",
            "The Catcher in the Rye",
            "Blindness",
            "Animal Farm",
            "The Lord of the Rings",
            "Crime and Punishment",
            "Harry Potter and the Philosopher's Stone"
        };

        static string userName = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to become a library member?");
            Console.WriteLine("yes or no?");
            string userChoice = Console.ReadLine();

            if (userChoice == "yes")
            {
                while (string.IsNullOrWhiteSpace(userName))
                {
                    Console.Write("Enter your name:");
                    userName = Console.ReadLine();
                }

                if (!string.IsNullOrEmpty(userName))
                {
                    Console.WriteLine($"\nWelcome to the library, {userName}!\n");
                    Library();
                }
                else
                {
                    Console.WriteLine("\nBummer");
                }
            }
            else
            {
                Console.WriteLine("\nBummer");
            }
        }

        static void Library()
        {
            int number = 0;

            do
            {
                Console.WriteLine("\n1 - View book options");
                Console.WriteLine("2 - Want to rent a book?");
                Console.WriteLine("3 - Want to donate a book?");
                Console.WriteLine("4 - Exit\n");

                string text = Console.ReadLine();
                int totalBooks = books.Count;

                if (int.TryParse(text, out number))
                {
                    switch (number)
                    {
                        case 1:
                            Console.WriteLine("\nAvailable books:");
                            Console.WriteLine($"A total of {totalBooks} books available\n");
                            ShowBooks();
                            break;
                        case 2:
                            Console.WriteLine("\nHow many books do you want to rent?");
                            Console.WriteLine($"Total available books {totalBooks} \n");
                            Console.WriteLine("Enter the number of books you want to rent:\n");

                            int numBooksToRent;
                            while (!int.TryParse(Console.ReadLine(), out numBooksToRent) || numBooksToRent <= 0 || numBooksToRent > books.Count)
                            {
                                Console.WriteLine("Invalid number. Try again.");
                            }

                            List<string> rentedBooks = new List<string>();

                            for (int i = 0; i < numBooksToRent; i++)
                            {
                                Console.WriteLine($"Choose book {i + 1} (Enter a number from 0 to { books.Count - 1}):");
                                int bookChoice;
                                while (!int.TryParse(Console.ReadLine(), out bookChoice) || bookChoice < 0 || bookChoice >= books.Count)
                                {
                                    Console.WriteLine("Invalid number. Try again.");
                                }

                                string bookName = books[bookChoice];
                                rentedBooks.Add(bookName);
                            }

                            Console.WriteLine($"\nChosen book(s):");
                            foreach (var book in rentedBooks)
                            {
                                Console.WriteLine(book);
                            }
                            break;

                        case 3:
                            Console.WriteLine("\nHow many books do you want to donate?");
                            int myBooks;
                            while (!int.TryParse(Console.ReadLine(), out myBooks) || myBooks <= 0)
                            {
                                Console.WriteLine("Invalid number. Try again.");
                            }

                            int giveBook = myBooks + totalBooks;
                            Console.WriteLine("\nThanks for the donation");
                            Console.WriteLine($"Total books: {giveBook}");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number. Try again.");
                }
            } while (number != 4);
        }

        static void ShowBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
