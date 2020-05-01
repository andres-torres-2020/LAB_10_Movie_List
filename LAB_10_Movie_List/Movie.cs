using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_10_Movie_List
{
    class Movie
    {
        string title;
        int category;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public int Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }

        public Movie(string _title, int _category)
        {
            title = _title;
            category = _category;
        }
        public void Display(string[] categories)
        {
            Console.WriteLine($"title: {title} category: {categories[category]}");
        }
    }
}
