using System;
using System.Threading.Tasks;
using System.Windows;
using Heroes.DraftViewer.Core;
using Microsoft.Win32;

namespace Heroes.DraftViewer.App
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DraftModel _model = new DraftModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _model;
        }

        private async void ReplayFilePickerButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var openDialog = new OpenFileDialog
                {
                    Filter = "StormReplay|*.StormReplay",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };

                var result = openDialog.ShowDialog();

                if (result != true)
                    return;

                ReplayFileTextBox.Text = openDialog.FileName;

                _model.Reset();
                await LoadReplayFile(openDialog.FileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"RIP: {exception.Message}", "OSsloth", MessageBoxButton.OK);
            }
        }

        private async Task LoadReplayFile(string path)
        {
            var replayReader = new ReplayReader(path);
            var chain = await replayReader.GetDraftAsync();

            var eventModel = new DraftEventModel();
            chain.Bag(eventModel);
            _model.Bag(eventModel);
        }
    }
}