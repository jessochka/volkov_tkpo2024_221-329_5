namespace AbstractFactoryCinemaForms
{
    public partial class Form1 : Form
    {
        private MovieController _controller;

        public Form1()
        {
            InitializeComponent();
            _controller = new MovieController();
            LoadMovies();
        }

        private void LoadMovies()
        {
            var movies = _controller.GetMovies();
            comboBoxMovies.Items.AddRange(movies.Select(m => m.Title).ToArray());
        }

        private void comboBoxMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxLanguages.Items.Clear();

            var selectedMovie = GetSelectedMovie();
            if (selectedMovie != null)
            {
                var languages = _controller.GetLanguages(selectedMovie);
                comboBoxLanguages.Items.AddRange(languages.Select(l => l.Language).ToArray());
            }
        }

        private void buttonShowSample_Click(object sender, EventArgs e)
        {
            var selectedMovie = GetSelectedMovie();
            var selectedLanguage = GetSelectedLanguage();

            if (selectedMovie != null && selectedLanguage != null)
            {
                // ����������� ����� ��� ������ � ���������� �����
                string formattedText =
                    $"�����: {selectedMovie.Title}\n" +
                    $"�������� �������: {selectedLanguage.AudioTrack}\n" +
                    $"��������: {selectedLanguage.Subtitles}\n" +
                    $"������ �����: \"{selectedLanguage.SceneSample}\"";

                // ������� ��������� � MessageBox
                MessageBox.Show(formattedText, "������� �� ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("�������� ����� � ����!", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private Movie GetSelectedMovie()
        {
            var movieTitle = comboBoxMovies.SelectedItem?.ToString();
            return _controller.GetMovies().FirstOrDefault(m => m.Title == movieTitle);
        }

        private LanguageOption GetSelectedLanguage()
        {
            var languageName = comboBoxLanguages.SelectedItem?.ToString();
            var selectedMovie = GetSelectedMovie();

            return selectedMovie?.AvailableLanguages.FirstOrDefault(l => l.Language == languageName);
        }

        private void comboBoxLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}