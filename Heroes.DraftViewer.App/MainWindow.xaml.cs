using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Heroes.DraftViewer.Core;
using Microsoft.Win32;

namespace Heroes.DraftViewer.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DraftModel _model = new DraftModel();
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
            catch(Exception exception)
            {
                MessageBox.Show($"RIP: {exception.Message}", "OSsloth", MessageBoxButton.OK);
            }
        }

        private void LoadReplayFile(string path)
        {
            var parser = new ReplayReader();
            var chain = parser.GetDraft(path);
            var model = new DraftEventModel();
            chain.Bag(model);
            Populate(model);
        }

        private void Populate(IDraftEventModel model)
        {
            _model.FirstBan = model.Bans[1].Name;
            _model.SecondBan = model.Bans[2].Name;

            _model.ThirdBan = model.Bans[8].Name;
            _model.FourthBan = model.Bans[9].Name;

            _model.Pick1 = model.Picks[3].Name;

            _model.Pick2 = model.Picks[4].Name;
            _model.Pick3 = model.Picks[5].Name;

            _model.Pick4 = model.Picks[6].Name;
            _model.Pick5 = model.Picks[7].Name;

            _model.Pick6 = model.Picks[10].Name;
            _model.Pick7 = model.Picks[11].Name;

            _model.Pick8 = model.Picks[12].Name;
            _model.Pick9 = model.Picks[13].Name;

            _model.Pick10 = model.Picks[14].Name;
        }
    }
}
