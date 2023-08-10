using Homeowrk_2.Models;

namespace Homeowrk_2
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book()
            {
                Author = "Jane Austen",
                Title = "Pride and Prejudice"
            },
            new Book()
            {
                Author = "George Orwell",
                Title = "1984"
            },
            new Book()
            {
                Author = "J.K. Rowling",
                Title = "Harry Potter and the Sorcerer's Stone"
            },
            new Book()
            {
                Author = "Leo Tolstoy",
                Title = "War and Peace"
            },
            new Book()
            {
                Author = "Mark Twain",
                Title = "The Adventures of Huckleberry Finn"
            },
            new Book()
            {
                Author = "Emily Dickinson",
                Title = "The Complete Poems"
            },
            new Book()
            {
                Author = "F. Scott Fitzgerald",
                Title = "The Great Gatsby"
            },
            new Book()
            {
                Author = "Harper Lee",
                Title = "To Kill a Mockingbird"
            },
            new Book()
            {
                Author = "Charles Dickens",
                Title = "A Tale of Two Cities"
            },
            new Book()
            {
                Author = "Gabriel Garcia Marquez",
                Title = "One Hundred Years of Solitude"
            }
        };
    }
};