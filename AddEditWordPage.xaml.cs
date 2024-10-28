namespace LanguageApp
{
    public partial class AddEditWordPage : ContentPage
    {
        private Word _word;
        private bool _isEditMode;

        public AddEditWordPage(Word word, bool isEditMode)
        {
            InitializeComponent();
            _word = word;
            _isEditMode = isEditMode;
            BindingContext = _word;
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            _word.Category = CategoryPicker.SelectedItem.ToString();
            await Navigation.PopAsync();
        }
    }
}
