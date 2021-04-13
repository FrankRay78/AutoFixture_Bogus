using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.NUnit3;
using Bogus;
using Bogus.Extensions.UnitedKingdom;

namespace AutoFixture_Bogus
{
    public class PersonAutoDataAttribute : AutoDataAttribute
    {
        public PersonAutoDataAttribute()
            : base(new Fixture().Customize(new PersonCustomization()))
        {
        }
    }

    public class PersonCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var faker = new Faker("en");

            var personIDs = 0;

            fixture.Customize<Person>(composer => composer
                .With(p => p.PersonID, personIDs++)
                .With(p => p.Name, faker.Person.FullName)
                .With(p => p.EMail, faker.Person.Email)
                .With(p => p.Address, faker.Address.FullAddress)
                .With(p => p.Postcode, faker.Address.ZipCode())
                .With(p => p.DOB, faker.Person.DateOfBirth)
                .With(p => p.AccountNumber, faker.Finance.Account())
                .With(p => p.SortCode, faker.Finance.SortCode()));
        }
    }
}
