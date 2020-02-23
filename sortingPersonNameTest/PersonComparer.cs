using sortingPersonName.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortingPersonNameTest
{
    public class PersonComparer : IComparer, IComparer<Person>
    {
        public int Compare(object x, object y)
        {
            var lhs = x as Person;
            var rhs = y as Person;
            if (lhs == null || rhs == null) throw new InvalidOperationException();
            return Compare(lhs, rhs);
        }

        public int Compare(Person x, Person y)
        {
            int temp;
            return (temp = x.firstName.CompareTo(y.firstName)) != 0 ? temp : x.lastName.CompareTo(y.lastName);
        }

    }
}
