using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sortingPersonName.Models;

namespace sortingPersonNameTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string unsortedFile = "E:\\tesKST-master\\sortingPersonName\\data\\unsorted_name_list.txt";
            string sortedFile = "E:\\tesKST-master\\sortingPersonName\\data\\sorted_name_list.txt";

            PersonsRepo oPersonsRepo = new PersonsRepo();
            List<Person> oPersonsExpected = new List<Person>();
            oPersonsExpected.Add(new Person("Avie", "Annakin"));
            oPersonsExpected.Add(new Person("Hailey", "Annakin"));
            oPersonsExpected.Add(new Person("Erna Dorey", "Battele"));
            oPersonsExpected.Add(new Person("Selle", "Bellison"));
            oPersonsExpected.Add(new Person("Flori Chaunce", "Franzel"));
            oPersonsExpected.Add(new Person("Orson Milka", "Iddins"));
            oPersonsExpected.Add(new Person("Odetta Sue", "Kaspar"));
            oPersonsExpected.Add(new Person("Roy Ketti", "Kopfen"));
            oPersonsExpected.Add(new Person("Madel Bordie", "Mapplebeck"));
            oPersonsExpected.Add(new Person("Debra", "Micheli"));
            oPersonsExpected.Add(new Person("Leonerd Adda Micheli", "Monaghan"));
            oPersonsExpected.Add(new Person("Leonerd Adda Mitchell", "Monaghan"));

            var oPersons = new List<Person>();
            oPersons = oPersonsRepo.readPersons(unsortedFile);

            var sortedPersons = oPersonsRepo.sortPersons(oPersons);

            oPersonsRepo.createTxtFile(sortedFile, sortedPersons);

            var oPersonsActual = new List<Person>();
            oPersonsActual = oPersonsRepo.readPersons(sortedFile); ;
             
            var comparer = new PersonComparer();
            CollectionAssert.AreEqual(
                oPersonsExpected,
                oPersonsActual,
                comparer);
        }
    }
  
}
   
