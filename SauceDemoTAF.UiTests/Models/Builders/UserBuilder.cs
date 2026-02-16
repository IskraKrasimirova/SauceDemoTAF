namespace SauceDemoTAF.UiTests.Models.Builders
{
    public class UserBuilder
    {
        private readonly UserModel _userModel;

        public UserBuilder()
        {
            _userModel = new UserModel();
        }

        public UserBuilder WithDefaultValues()
        {
            
            _userModel.FirstName = "John";
            _userModel.LastName = "Doe";
            _userModel.PostalCode = "1000";

            return this;
        }

        public UserBuilder WithFirstName(string firstName)
        {
            _userModel.FirstName = firstName;
            return this;
        }
        public UserBuilder WithLastName(string lastName)
        {
            _userModel.LastName = lastName;
            return this;
        }
        public UserBuilder WithPostalCode(string postalCode)
        {
            _userModel.PostalCode = postalCode;
            return this;
        }

        public UserModel Build()
        {
            return _userModel;
        }
    }
}
