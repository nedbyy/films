using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsEF
{
    public class FilmsApp
    {
        public void Run()
        {
            Console.WriteLine("Vítej ve FilmsApp!");
            Console.WriteLine();

            Console.WriteLine("Přidávání nového filmu...");
            AddFilm();
            Console.WriteLine("Film byl úspěšně přidán.");
            Console.WriteLine();

            Console.WriteLine("Výběr filmu podle ID...");
            SelectFilmById();
            Console.WriteLine();

            Console.WriteLine("Aktualizace filmu...");
            UpdateFilm();
            Console.WriteLine("Film byl úspěšně aktualizován.");
            Console.WriteLine();


            Console.WriteLine("Filtrování filmů podle režiséra...");
            FilterFilmsByDirector();
            Console.WriteLine();

            Console.WriteLine("Řazení filmů podle režiséra a názvu...");
            SortFilmsByDirectorAndName();
            Console.WriteLine();

            Console.WriteLine("Mazání filmu...");
            DeleteFilm();
            Console.WriteLine("Film byl úspěšně smazán.");
        }


        public void AddFilm()
        {
            using var dbContext = new FilmDatabase();

            Console.WriteLine("Zadej Jméno Filmu:");
            var name = Console.ReadLine();

            Console.WriteLine("Zadej Délku Filmu (v minutách):");
            var length = int.Parse(Console.ReadLine());

            Console.WriteLine("Zadejte režiséra filmu:");
            var director = Console.ReadLine();

            var film = new Film
            {
                Name = name,
                Length = length,
                Director = director,
                Modified = DateTime.Now
            };

            dbContext.Films.Add(film);
            dbContext.SaveChanges();
        }

        public void UpdateFilm()
        {
            using var dbContext = new FilmDatabase();

            var filmToUpdate = dbContext.Films.FirstOrDefault(film => film.Id == 1);
            filmToUpdate.Name = "The Godfather";
            filmToUpdate.Length = 175;
            filmToUpdate.Modified = DateTime.Now;

            dbContext.SaveChanges();
        }

        public void DeleteFilm()
        {
            using var dbContext = new FilmDatabase();

            var film = dbContext.Films.FirstOrDefault(film => film.Id == 1);
            dbContext.Films.Remove(film);
            dbContext.SaveChanges();
        }

        public void SelectFilmById()
        {
            using var dbContext = new FilmDatabase();

            var film = dbContext.Films.FirstOrDefault(film => film.Id == 1);
            Console.WriteLine(film.Name);
        }

        public void SelectFilmList()
        {
            using var dbContext = new FilmDatabase();

            var films = dbContext.Films.ToList();
            foreach (var film in films)
            {
                Console.WriteLine(film.Name);
            }
        }

        public void FilterFilmsByDirector()
        {
            using var dbContext = new FilmDatabase();

            var films = dbContext.Films.Where(film => film.Director == "Steven Spielberg").ToList();
            foreach (var film in films)
            {
                Console.WriteLine(film.Name);
            }
        }

        public void SortFilmsByDirectorAndName()
        {
            using var dbContext = new FilmDatabase();

            var films = dbContext.Films.OrderBy(film => film.Director).ThenBy(film => film.Name).ToList();
            foreach (var film in films)
            {
                Console.WriteLine($"{film.Name} ({film.Director})");
            }
        }

    }
}
