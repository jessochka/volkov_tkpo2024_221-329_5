using AbstractFactoryCinemaForms;

public class MovieController
{
    private List<Movie> _movies;

    public MovieController()
    {
        _movies = new List<Movie>
        {
            new Movie("Матрица", new List<LanguageOption>
            {
                new LanguageOption("Английский", "English Audio", "English Subtitles", "Welcome to our world!"),
                new LanguageOption("Русский", "Русская дорожка", "Русские субтитры", "Добро пожаловать в наш мир!")
            }),
            new Movie("Интерстеллар", new List<LanguageOption>
            {
                new LanguageOption("Английский", "English Audio", "English Subtitles", "We must think beyond our own existence."),
                new LanguageOption("Русский", "Русская дорожка", "Русские субтитры", "Мы должны думать за пределами нашего существования.")
            })
        };
    }

    public List<Movie> GetMovies() => _movies;

    public List<LanguageOption> GetLanguages(Movie movie) => movie.AvailableLanguages;

    public string GetSample(Movie movie, LanguageOption languageOption) => movie.GetSample(languageOption);
}
