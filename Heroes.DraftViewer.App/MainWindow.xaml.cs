using System;
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

        private void ReplayFilePickerButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var openDialog = new OpenFileDialog
                {
                    Filter = "StormReplay|*.StormReplay",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };

                var result = openDialog.ShowDialog();

                if (result == true)
                {
                    ReplayFileTextBox.Text = openDialog.FileName;
                    LoadReplayFile(openDialog.FileName);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"RIP: {exception.Message}", "OSsloth", MessageBoxButton.OK);
            }
        }

        private void LoadReplayFile(string path)
        {
            var parser = new ReplayReader();
            var chain = parser.GetDraft(path);
            var eventModel = new DraftEventModel();
            chain.Bag(eventModel);
            _model.Bag(eventModel);
        }
    }
}