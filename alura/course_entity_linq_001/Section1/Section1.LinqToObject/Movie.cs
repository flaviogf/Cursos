﻿namespace Section1.LinqToObject
{
    public class Movie
    {
        public Movie(int id, string name, int genreId)
        {
            Id = id;
            Name = name;
            GenreId = genreId;
        }

        public Movie(int id, string name, Genre genre) : this(id, name, genre.Id)
        {
            Genre = genre;
        }

        public int Id { get; }

        public string Name { get; }

        public int GenreId { get; }

        public Genre Genre { get; }
    }
}
