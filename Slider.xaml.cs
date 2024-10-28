using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace LanguageApp
{
    public partial class SliderPage : ContentPage
    {
        public ObservableCollection<Word> Words { get; set; }

        public SliderPage()
        {
            InitializeComponent();
            Words = new ObservableCollection<Word>(FileHelper.LoadWords());
            BindingContext = this;
        }

        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            var newWord = new Word("", "", "", "обучение");
            await Navigation.PushAsync(new AddEditWordPage(newWord, false));
            Words.Add(newWord);
            FileHelper.SaveWords(Words.ToList());
        }

        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
            var word = (sender as Button).BindingContext as Word;
            await Navigation.PushAsync(new AddEditWordPage(word, true));
            FileHelper.SaveWords(Words.ToList());
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var word = (sender as Button).BindingContext as Word;
            Words.Remove(word);
            FileHelper.SaveWords(Words.ToList());
        }
    }
}
