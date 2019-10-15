using Assignment_UWP.Entity;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Assignment_UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateNote : Page
    {
     

        public CreateNote()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var date = DateTime.Now;
            var day = date.ToString("yyyy-MM-dd-HH-mm");
            var note = NoteFile.Text;
            WriteTextToFile(day + ".txt", note);
            
            

        
        }

        private void WriteTextToFile(string filename, string note)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = storageFolder.CreateFileAsync(filename,
                Windows.Storage.CreationCollisionOption.ReplaceExisting).GetAwaiter().GetResult();
            Windows.Storage.FileIO.WriteTextAsync(sampleFile, note).GetAwaiter().GetResult();
            
        }

        private void ButtonNoteList_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SaveFile));
            
        }

    }
}
