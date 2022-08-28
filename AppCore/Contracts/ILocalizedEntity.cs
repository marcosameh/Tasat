namespace AppCore.Contracts
{
    public interface ILocalizedEntity
    {
        int DefaultLanguageId { get; set; }
        void Localize(int languageId);
    }
}
