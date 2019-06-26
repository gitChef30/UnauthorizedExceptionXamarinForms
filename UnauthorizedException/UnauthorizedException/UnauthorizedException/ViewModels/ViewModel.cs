using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace UnauthorizedException.ViewModels
{
    class ViewModel : BaseViewModel
    {
        public ICommand PickCommand { get; private set; }

        string path;

        string status = string.Empty;
        public string Status
        {
            get => status;
            set
            {
                SetPropertyValue(ref this.status, value);
            }
        }

        public ViewModel()
        {
            PickCommand = new Command(async () => await PickFile());
        }

        private async Task PickFile()
        {
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile();
                if (fileData == null)
                    return; // user canceled file picking

                path = fileData.FilePath;

                IPathResolver pathResolver = DependencyService.Get<IPathResolver>();

                if (path.ToLower().Contains(":"))
                    path = pathResolver.GetRealPath(path);      //converts paths like content://, file:// to /storage/

                Console.WriteLine("File path: " + path);

                MoveFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                Status = "Exception: " + ex.ToString();
            }
        }

        void MoveFile()
        {
            string newpath = path + ".mp3";

            System.IO.File.Move(path, newpath);

            Console.WriteLine("----------------- File moved! ------------------".ToUpper());
            Status = "----------------- File moved! ------------------".ToUpper();
        }
    }
}
