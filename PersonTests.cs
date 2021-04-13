using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AutoFixture_Bogus
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        [PersonAutoData]
        public void AutoFixtureBogusTest_Person(Person person)
        {
            Assert.NotNull(person);
        }
    }
}
