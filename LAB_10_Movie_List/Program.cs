/*
 * A.TORRES
 * 
 * C#.NET LAB 10: Movie List!
 *
 * List movies by category
 *
 * What will the application do?
 * The application stores a list of 10 movies and displays them by category.
 * The user can enter any of the following categories to
 *      display the films in the list that match the category: animated, drama, horror, scifi.
 * After the list is displayed, the user is asked if he or she wants to continue. If no, the program ends.
 * 
 * Build Specifications:
 * Each movie should be represented by an object of type Movie.
 * The Movie class must provide two private fields: title and category and the properties that go with them.
 * The class should also provide a constructor that accepts a title and category as parameters
 *      and uses the values passed to it to initialize its fields.
 * When the user enters a category, the program should read through all of 
 *      the movies in the List and display a line for any movie
 *      whose category matches the category entered by the user.
 * Validate input don’t accept blanks for any of the questions.
 * 
 * Additional Requirements:
 * Extended Exercises:
 * Standardize the category codes by displaying a menu of categories and 
 *      having the user select the category by number rather than entering the name.
 * Display the movies for the selected category in alphabetical order.
 */
using System;
using System.Collections.Generic;

namespace LAB_10_Movie_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Movie List Application!\n");

            string[] categories = { "animated", "drama", "horror", "scifi" };
            List<Movie> movies = new List<Movie>();
            SetupData(movies, categories);

            Console.WriteLine($"There are {movies.Count} movies in this list.\n");

            bool keepBrowsing = true;
            while (keepBrowsing)
            {
                // When the user enters a category, the program should read through
                // all of the movies in the List and display a line for any movie
                // whose category matches the category entered by the user.
                int categoryIndex = GetSelectedCategoryIndex(categories.Length);
                DisplayMovies(movies, categories, categoryIndex);

                // prompt the user to continue
                keepBrowsing = ReadString("\nContinue? (y/n):  ").ToLower() == "y";
            }
        }
        public static string ReadString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine().Trim();
        }
        public static void SetupData(List<Movie> movies, string[] categories)
        {
            Random r = new Random();
            for (int i = 0; i < categories.Length; i++)
            {
                int categoryIndex = i;
                string category = categories[i];
                char randChar = (char)('a' + r.Next() % 25);
                movies.Add(new Movie("" + randChar + category + " " + r.Next(), categoryIndex));
                randChar = (char)('a' + r.Next() % 25);
                movies.Add(new Movie(randChar + " " + category + " " + r.Next(), categoryIndex));
                if (i % 2 == 1)
                {
                    randChar = (char)('a' + r.Next() % 25);
                    movies.Add(new Movie("" + randChar + category + " Z " + r.Next(), categoryIndex));
                }
            }
        }
        public static void DisplayMovies(List<Movie> movies, string[] categories, int selectedCategoryIndex)
        {
            List<string> titles = new List<string>();
            
            // build a list of movies matching the given category
            foreach (Movie m in movies)
            {
                if (m.Category == selectedCategoryIndex)
                {
                    titles.Add(m.Title);
                }
            }

            // sort the list then display it
            titles.Sort();
            foreach (string title in titles)
            {
                Console.WriteLine($"{title}");
            }
        }
        public static int GetSelectedCategoryIndex(int maxCategories)
        {
            while (true)
            {
                Console.WriteLine("What category are you interested in?\n( Enter a number for 0=animated 1=drama 2=horror 3=scifi )\n");
                try
                {
                    string input = Console.ReadLine().Trim().ToLower();
                    int catIdx = int.Parse(input);
                    if (catIdx >= 0 && catIdx < maxCategories)
                    {
                        return catIdx;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Try again!");
                }
            }
        }
    }
}
