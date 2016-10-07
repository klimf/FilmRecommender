using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FilmRecommender
{
    
    public class User
    {
        MySQL db = new MySQL();
        Film film = new Film();
        int maxElems = 100;
        public void Add(string nick, string mail, string name, string surname)
        {
            var table = "Users";
            var id = GetLastId()+1;
            db.Connect("INSERT INTO " + table + " (id, nick, mail, name, surname ) VALUES('" + id + "', '" + nick + "', '" + mail + "', '" + name + "', '" + surname + "')", "set");
        }
        public void Remove(int id)
        {
            db.Connect("DELETE FROM Variations WHERE id = '" + id + "'", "set");
        }
        public int GetIdByNick(string nick)
        {
            return int.Parse(db.GetFieldValueByField("Users", "id", "nick", nick));
        }
        public void AddFilm(int userId, int filmId, int rating)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            db.UpdateFieldValueById("Users", userId, "films", "<" + filmId + "," + rating + "," + date + ">");
        }
        public int GetLastId()
        {
            return int.Parse(db.Count("Users"));
        }
        public int[] GetSameInterestsUsersId(int userId)
        {
            int[] usersIds = new int[maxElems];
            string[] yourFilm = GetFilms(userId, "id");
            int j = 0;
            for(int i = 1; i <= GetLastId(); i++)
            {
                if (ContainInArrays(yourFilm, GetFilms(i, "id")))
                {
                    usersIds[j] = i;
                    j++;
                }
            }
            return usersIds;
        }
        public bool ContainInArrays(string[] array1, string[] array2)
        {
            bool isTrue = false;
            for(int i = 0; i < array2.Length; i++)
                if (array1.Contains(array2[i])) isTrue = true;
            return isTrue;
        }
        public string[] GetFilms(int userId, string type)
        {
            if (type == "id")
                return GetAllElems(db.GetFieldValueById("Users", "films", userId), 0);
            else if (type == "rating")
                return GetAllElems(db.GetFieldValueById("Users", "films", userId), 1);
            else if (type == "date")
                return GetAllElems(db.GetFieldValueById("Users", "films", userId), 2);
            else
                return null;
        }
        public string[] GetAllElems(string strForParse, int index)
        {
            string[] elementsArray = new string[maxElems];
            string[] array;
            string[] externalSeparators = { "><", "<", ">" };
            string[] internalSeparators = { "," };
            array = strForParse.Split(externalSeparators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < array.Length; i++)
            {
                elementsArray[i] = array[i].Split(internalSeparators, StringSplitOptions.RemoveEmptyEntries)[index];
            }
            return elementsArray;
        }

        public int AverageUserRating(int userId)
        {
            string[] elementsArray = GetAllElems(db.GetFieldValueById("Users", "films", userId), 1);
            int summRating = 0;
            int i; 
            for (i = 0; elementsArray[i]!=null; i++)
            {
                summRating += int.Parse(elementsArray[i]);
            }
            return summRating/(i);
        }
    }
}
