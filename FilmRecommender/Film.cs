using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRecommender
{
    public class Film
    {
        MySQL db = new MySQL();
        public void Add(string name, string producer, string genre, int year)
        {
            var table = "Films";
            var id = GetLastId() + 1;
            db.Connect("INSERT INTO " + table + " (id, name, produser, genre, year) VALUES('" + id + "', '" + name + "', '" + producer + "', '" + genre + "', '" + year + "')", "set");
        }
        public string Get(int id, string type)
        {
            return db.GetFieldValueById("Films", type, id);
        }
        public int GetLastId()
        {
            return int.Parse(db.Count("Films"));
        }
        public void RefreshRating(int filmId)
        {
            //нужно считать все оценки всех юзеров у которых есть фильм с данным id и посчитать среднее значение
            throw new NotImplementedException();
        }
        public int AverageGenreRating(string genre)
        {
            int summRating = 0;
            for(int id = 1; id <= GetLastId(); id++)
            {
                summRating += int.Parse(Get(id, "rating"));
            }
            return summRating / GetLastId();
        }

    }
}
