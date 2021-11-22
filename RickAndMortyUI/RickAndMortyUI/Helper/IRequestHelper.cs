namespace RickAndMortyUI.Helper
{
    public interface IRequestHelper
    {
        T Get<T>(string url);
    }
}