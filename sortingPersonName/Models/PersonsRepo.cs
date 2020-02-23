using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace sortingPersonName.Models
{
    public class PersonsRepo
    {
        private List<Person> oPersons;
        public List<Person> readPersons(string filename)
        {
            oPersons = new List<Person>();
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int index = line.LastIndexOf(" ");
                    if (index > 0)// last name last is exist 
                    {
                        //get first & last name per line
                        string firstName = line.Substring(0, index);
                        string lastName = line.Substring(index + 1);

                        var person = new Person(firstName, lastName);
                        oPersons.Add(person);
                    }
                    else // last name last doesn't exist
                    {
                        var person = new Person(line, "");
                        oPersons.Add(person);
                    }
                }
            }
            return oPersons;
        }
        public List<Person> sortPersons(List<Person> oPersons)
        {
            var sortedPersons = oPersons.OrderBy(s => s.lastName).ThenBy(s => s.firstName).ToList();
            return sortedPersons;
        }
        public void createTxtFile(string fileName, List<Person> oPersons)
        {
            FileInfo info = new FileInfo(fileName);
            if (info.Exists)
            {
                info.Delete();
            }

            using (StreamWriter writer = info.CreateText())
            {

                foreach (var item in oPersons)
                {
                    writer.WriteLine(item.firstName + ' ' + item.lastName);
                }

            }
        }
    }
}