using System.ComponentModel;

namespace Heroes.DraftViewer.App
{
    public class DraftModel : INotifyPropertyChanged
    {
        private string _ban1;
        private string _ban4;
        private string _pick1;
        private string _pick10;
        private string _pick2;
        private string _pick3;
        private string _pick4;
        private string _pick5;
        private string _pick6;
        private string _pick7;
        private string _pick8;
        private string _pick9;
        private string _ban2;
        private string _ban3;

        public string Pick6
        {
            get => _pick6;
            set
            {
                if (_pick6 == value)
                    return;

                _pick6 = value;
                OnPropertyChanged("Pick6");
            }
        }

        public string Pick7
        {
            get => _pick7;
            set
            {
                if (_pick7 == value)
                    return;

                _pick7 = value;
                OnPropertyChanged("Pick7");
            }
        }

        public string Pick8
        {
            get => _pick8;
            set
            {
                if (_pick8 == value)
                    return;

                _pick8 = value;
                OnPropertyChanged("Pick8");
            }
        }

        public string Pick9
        {
            get => _pick9;
            set
            {
                if (_pick9 == value)
                    return;

                _pick9 = value;
                OnPropertyChanged("Pick9");
            }
        }

        public string Pick10
        {
            get => _pick10;
            set
            {
                if (_pick10 == value)
                    return;

                _pick10 = value;
                OnPropertyChanged("Pick10");
            }
        }

        public string Ban2
        {
            get => _ban2;
            set
            {
                if (_ban2 == value)
                    return;

                _ban2 = value;
                OnPropertyChanged("Ban2");
            }
        }

        public string Ban3
        {
            get => _ban3;
            set
            {
                if (_ban3 == value)
                    return;

                _ban3 = value;
                OnPropertyChanged("Ban3");
            }
        }

        public string Ban4
        {
            get => _ban4;
            set
            {
                if (_ban4 == value)
                    return;

                _ban4 = value;
                OnPropertyChanged("Ban4");
            }
        }

        public string Pick1
        {
            get => _pick1;
            set
            {
                if (_pick1 == value)
                    return;

                _pick1 = value;
                OnPropertyChanged("Pick1");
            }
        }

        public string Pick2
        {
            get => _pick2;
            set
            {
                if (_pick2 == value)
                    return;

                _pick2 = value;
                OnPropertyChanged("Pick2");
            }
        }

        public string Pick3
        {
            get => _pick3;
            set
            {
                if (_pick3 == value)
                    return;

                _pick3 = value;
                OnPropertyChanged("Pick3");
            }
        }

        public string Pick4
        {
            get => _pick4;
            set
            {
                if (_pick4 == value)
                    return;

                _pick4 = value;
                OnPropertyChanged("Pick4");
            }
        }

        public string Pick5
        {
            get => _pick5;
            set
            {
                if (_pick5 == value)
                    return;

                _pick5 = value;
                OnPropertyChanged("Pick5");
            }
        }

        public string Ban1
        {
            get => _ban1;
            set
            {
                if (_ban1 == value)
                    return;

                _ban1 = value;
                OnPropertyChanged("Ban1");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}