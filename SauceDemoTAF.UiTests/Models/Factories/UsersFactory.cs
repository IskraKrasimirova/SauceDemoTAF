using Bogus;

namespace SauceDemoTAF.UiTests.Models.Factories
{
    public class UsersFactory : IUserFactory
    {
        private static readonly Faker Faker = new();

        public UserModel CreateDefault()
        {
            var user = new UserModel
            {
                FirstName = Faker.Name.FirstName(),
                LastName = Faker.Name.LastName(),
                PostalCode = Faker.Address.ZipCode()
            };

            return user;
        }

        public UserModel CreateCustom(
            string? firstName = null,
            string? lastName = null,
            string? postalCode = null)
        {
            var user = CreateDefault();

            if (firstName != null) user.FirstName = firstName;
            if (lastName != null) user.LastName = lastName;
            if (postalCode != null) user.PostalCode = postalCode;

            return user;
        }
    }
}
