using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows;
using System.Globalization;
using System.Windows.Controls;

namespace MVVM
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private SystemConfiguration _configuration;
        private string _selectedLanguage;
        private string _displayLanguage;
        private string _contactPerson;
        private string _selectedInverterType;
        private double _minVoltage;
        private double _maxVoltage;
        private readonly DataService _dataService;
        private readonly string _configFilePath;

        public ObservableCollection<string> Languages { get; } = new ObservableCollection<string>
        {
            "English",
            "Spanish",
            "French",
            "German",
            "Italian"
        };

        public string SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged(nameof(SelectedLanguage));
                }
            }
        }

        public string DisplayLanguage
        {
            get { return _displayLanguage; }
            set
            {
                if (_displayLanguage != value)
                {
                    _displayLanguage = value;
                    OnPropertyChanged(nameof(DisplayLanguage));
                }
            }
        }

        public ObservableCollection<string> InverterTypes { get; } = new ObservableCollection<string>
        {
            "MT MWR 24/230-1.0F",
            "MT MWR 48/230-1.0F",
            "MT MWR 110/230-2.0F",
            "MT MWR 220/230-2.0F"
        };
        public string SelectedInverterType
        {
            get { return _selectedInverterType; }
            set
            {
                if (_selectedInverterType != value)
                {
                    _selectedInverterType = value;
                    OnPropertyChanged(nameof(SelectedInverterType));
                }
            }
        }

        public ObservableCollection<string> ContactPersons { get; } = new ObservableCollection<string>();
        public string ContactPerson
        {
            get { return _contactPerson; }
            set
            {
                if (_contactPerson != value)
                {
                    _contactPerson = value;
                    OnPropertyChanged(nameof(ContactPerson));
                }
            }
        }

        public int ContactPersonCount
        {
            get { return ContactPersons.Count; }
        }

        public double MinVoltage
        {
            get { return _minVoltage; }
            set
            {
                if (_minVoltage != value)
                {
                    _minVoltage = value;
                    OnPropertyChanged(nameof(MinVoltage));
                }
            }
        }

        public double MaxVoltage
        {
            get { return _maxVoltage; }
            set
            {
                if (_maxVoltage != value)
                {
                    _maxVoltage = value;
                    OnPropertyChanged(nameof(MaxVoltage));
                }
            }
        }

       

        //public double MinVoltage
        //{
        //    get { return _minVoltage; }
        //    set
        //    {

        //        if (_minVoltage != value)
        //        {
        //            _minVoltage = value;
        //            if (value < 16 || value > 249)
        //            {
        //                MessageBox.Show("Value must be between 16 and 249", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
        //            }
        //            else
        //            {
        //                _minVoltage = value;
        //                _configuration.SBSCOnfig.DCInputConfig.MinVoltage = _minVoltage;
        //                SaveData();
        //                OnPropertyChanged(nameof(MinVoltage));
        //            }
        //        }
        //    }
        //}

        //public double MaxVoltage
        //{
        //    get { return _maxVoltage; }
        //    set
        //    {
        //        if (_maxVoltage != value)
        //        {
        //            if (value > 249)
        //            {
        //                MessageBox.Show("Maximum voltage must be at most 249 volts.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
        //            }
        //            else
        //            {
        //                _maxVoltage = value;
        //                _configuration.SBSCOnfig.DCInputConfig.MaxVoltage = _maxVoltage;
        //                SaveData();
        //                OnPropertyChanged(nameof(MaxVoltage));
        //            }
        //        }
        //    }
        //}

        public ICommand CheckLanguageCommand { get; }
        public ICommand CheckInverterTypeCommand { get; }
        public ICommand CheckContactPersonCommand { get; }
        public ICommand AddContactPersonCommand { get; }

        public MainViewModel()
        {
            _dataService = new DataService();
            _configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "config.xml");
            LoadData();
            CheckLanguageCommand = new RelayCommand(CheckLanguage);
            CheckInverterTypeCommand = new RelayCommand(CheckInverterType);
            CheckContactPersonCommand = new RelayCommand(CheckContactPerson);
            AddContactPersonCommand = new RelayCommand(AddContactPerson);
        }

        private void LoadData()
        {
            _configuration = _dataService.LoadConfiguration(_configFilePath);
            SelectedLanguage = _configuration.GeneralConfig.Language;
            SelectedInverterType = _configuration.SBSCOnfig.InverterInputConfig.InverterType;
            MinVoltage = _configuration.SBSCOnfig.DCInputConfig.MinVoltage;
            MaxVoltage = _configuration.SBSCOnfig.DCInputConfig.MaxVoltage;
           
        }

        private void SaveData()
        {
            _dataService.SaveConfiguration(_configuration, _configFilePath);
            System.Diagnostics.Debug.WriteLine($"Configuration saved. New Language: {_configuration.GeneralConfig.Language}, New Inverter Type: {_configuration.SBSCOnfig.InverterInputConfig.InverterType}, New Min Voltage: {_configuration.SBSCOnfig.DCInputConfig.MinVoltage}, New Max Voltage: {_configuration.SBSCOnfig.DCInputConfig.MaxVoltage}");
        }

        public void ApplyMinVoltage()
        {
            _configuration.SBSCOnfig.DCInputConfig.MinVoltage = _minVoltage;
            SaveData();
        }

        public void ApplyMaxVoltage()
        {
            _configuration.SBSCOnfig.DCInputConfig.MaxVoltage = _maxVoltage;
            SaveData();
        }

        private void CheckLanguage()
        {
            if (_configuration.GeneralConfig.Language != SelectedLanguage)
            {
                _configuration.GeneralConfig.Language = SelectedLanguage;
                SaveData();
            }
            DisplayLanguage = SelectedLanguage;
            System.Diagnostics.Debug.WriteLine($"Language updated to: {SelectedLanguage}");
            MessageBox.Show($"Selected Language: {SelectedLanguage}", "Selected Language", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CheckInverterType()
        {
            if (_configuration.SBSCOnfig.InverterInputConfig.InverterType != SelectedInverterType)
            {
                _configuration.SBSCOnfig.InverterInputConfig.InverterType = SelectedInverterType;
                SaveData();
            }
            System.Diagnostics.Debug.WriteLine($"Inverter Type updated to: {SelectedInverterType}");
            MessageBox.Show($"Selected Inverter Type: {SelectedInverterType}", "Selected Inverter Type", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CheckContactPerson()
        {
            if (_configuration.GeneralConfig.ContactPerson != ContactPerson)
            {
                _configuration.GeneralConfig.ContactPerson = ContactPerson;
                if (string.IsNullOrWhiteSpace(ContactPerson))
                {
                    MessageBox.Show("Please enter a contact person name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                SaveData();
            }
            System.Diagnostics.Debug.WriteLine($"Contact Person updated to: {ContactPerson}");
            MessageBox.Show($"Contact Person updated: {ContactPerson}", "Updated Contact Person", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AddContactPerson()
        {
            if (string.IsNullOrWhiteSpace(ContactPerson))
            {
                MessageBox.Show("Please enter a contact person name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ContactPersons.Add(ContactPerson);
            OnPropertyChanged(nameof(ContactPersonCount));
            ContactPerson = string.Empty; // Clear the input field
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}

