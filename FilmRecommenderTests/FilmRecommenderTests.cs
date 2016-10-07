using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilmRecommender;

namespace FilmRecommenderTests
{
    [TestClass]
    public class FilmRecommenderTests
    {

        [TestMethod]
        public void StringFromDB_ReturnCorrectStringByIdUser()
        {
            MySQL db = new MySQL();
            var expectedString = "k-f222@ya.ru";

            var actualString = db.GetFieldValueById("Users", "mail", 3);

            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void StringFromDB_ReturnCorrectStringByIdFilm()
        {
            MySQL db = new MySQL();
            var expectedString = "Отряд самоубийц";

            var actualString = db.GetFieldValueById("Films", "name", 1);

            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void StringFromDB_ReturnCorrectStringByField()
        {
            MySQL db = new MySQL();
            var expectedString = "k-f222@ya.ru";

            var actualString = db.GetFieldValueByField("Users", "mail", "nick", "klimfl");

            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void StringToRequest_ReturnCorrectString()
        {
            MySQL db = new MySQL();
            var expectedString = "INSERT INTO Test (field) VALUES('" + DateTime.Now.ToString() + "')";
            var actualString = db.SetFieldValue("Test", "field", DateTime.Now.ToString());

            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void CountStringsOfTable_ReturnThree()
        {
            MySQL db = new MySQL();
            var expectedString = "3";

            var actualString = db.Count("Users");

            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void ArrayFromString_returnCorrectArray()
        {
            User user = new User();
            var forParse = "<1,70,05-10-2016><2,60,06-10-2016>";
            string[] expectedArray = new string[] { "1", "2" };

            string[] actualArray = user.GetAllElems(forParse, 0);

            Assert.AreEqual(expectedArray[0], actualArray[0]);
            Assert.AreEqual(expectedArray[1], actualArray[1]);
        }
        [TestMethod]
        public void GetSameInterestsUsersId_returnCorrectArray()
        {
            User user = new User();
            int[] expectedArray = new int[] { 1, 2 };

            int[] actualArray = user.GetSameInterestsUsersId(1);

            Assert.AreEqual(expectedArray[0], actualArray[0]);
            Assert.AreEqual(expectedArray[1], actualArray[1]);
        }
        [TestMethod]
        public void GetContainInArrays_returnTrue()
        {
            User user = new User();
            string[] array1 = new string[] { "5", "2", "4", "1", "6" };
            string[] array2 = new string[] { "8", "5", "3", "7", "9" };

            bool rtrn = user.ContainInArrays(array1, array2);

            Assert.AreEqual(true, rtrn);
        }
        [TestMethod]
        public void GetContainInArrays_returnFalse()
        {
            User user = new User();
            string[] array1 = new string[] { "5", "2", "4", "1", "6" };
            string[] array2 = new string[] { "8", "3", "7", "9" };

            bool rtrn = user.ContainInArrays(array1, array2);

            Assert.AreEqual(false, rtrn);
        }
        [TestMethod]
        public void AverageRatingOfGenre_returnZero()
        {
            Film film = new Film();
            int expectedRating = 0;

            int actualRating = film.AverageGenreRating("action");

            Assert.AreEqual(expectedRating, actualRating);
        }
        [TestMethod]
        public void AverageRatingOfUser_return65()
        {
            User user = new User();
            double expectedRating = 65;

            double actualRating = user.AverageUserRating(1);

            Assert.AreEqual(expectedRating, actualRating);
        }
        [TestMethod]
        public void TestAction()
        {
            User user = new User();

            //user.AddFilm(2, 1, 80);

            Assert.AreEqual(true, true);
        }


    }
}
