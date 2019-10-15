using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SaveFile : Page
    {
        public ObservableCollection<string> notes = new ObservableCollection<string>();
        IReadOnlyList<StorageFile> files = new List<StorageFile>();
        public SaveFile()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _ = GetListNoteAsync();
            NoteLists.ItemsSource = notes;
        }

        public async System.Threading.Tasks.Task GetListNoteAsync()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            files = await storageFolder.GetFilesAsync();

            foreach (var file in files)
            {
                Debug.WriteLine(file.Name);
                notes.Add(file.Name);
            }
        }

        private void CreateNote_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateNote));
        }



        private void NoteList_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            Note.Visibility = Visibility.Visible;
            var selectedIndex = NoteLists.SelectedIndex;
            var fileName = notes[selectedIndex];
            foreach (var file in files)
            {
                if (file.Name == fileName)
                {
                    var content = FileIO.ReadTextAsync(file).GetAwaiter().GetResult();
                    Note.Text = content;
                }
            }
        }
        private void UpdateNote_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedIndex = NoteLists.SelectedIndex;
            var fileName = notes[selectedIndex];

            Windows.Storage.FileIO.WriteTextAsync(files[selectedIndex], Note.Text).GetAwaiter().GetResult();
        }
    }
}
