namespace SauceDemoTAF.UiTests.Models.Factories
{
    public interface IUserFactory
    {
        UserModel CreateDefault();
        UserModel CreateCustom(
            string? firstName = null,
            string? lastName = null,
            string? postalCode = null);
    }
}
