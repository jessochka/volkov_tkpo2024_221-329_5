using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryCinemaForms
{
    public class LanguageOption
    {
        public string Language { get; }
        public string AudioTrack { get; }
        public string Subtitles { get; }
        public string SceneSample { get; }

        public LanguageOption(string language, string audioTrack, string subtitles, string sceneSample)
        {
            Language = language;
            AudioTrack = audioTrack;
            Subtitles = subtitles;
            SceneSample = sceneSample;
        }
    }

    public class Movie
    {
        public string Title { get; }
        public List<LanguageOption> AvailableLanguages { get; }

        public Movie(string title, List<LanguageOption> availableLanguages)
        {
            Title = title;
            AvailableLanguages = availableLanguages;
        }

        public string GetSample(LanguageOption languageOption)
        {
            return $"Фильм: {Title}\nЗвуковая дорожка: {languageOption.AudioTrack}\nСубтитры: {languageOption.Subtitles}\nПример сцены: \"{languageOption.SceneSample}\"";
        }
    }
}
