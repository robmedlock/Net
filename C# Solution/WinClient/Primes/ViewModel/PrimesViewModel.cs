using System;
using System.ComponentModel;
using System.Diagnostics;
using WinClient.Primes.Model;
using WinClient.Utility;

namespace WinClient.Primes.ViewModel
{
    public class PrimesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IPrimesModel primesModel;
        private bool enabled = true;
        private int limit;
        private string result;

        public PrimesViewModel(IPrimesModel primesModel)
        {
            this.primesModel = primesModel;
            LoadCommands();
            LoadData();
        }

        //Bound properties

        public int Limit
        {
            get { return limit; }
            set
            {
                limit = value;
                LoadData();
            }
        }

        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }


        private void LoadCommands()
        {
            StartCommand = new CustomCommand(Start, CanStart);
        }

        private async void LoadData()
        {
            enabled = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int count = await primesModel.CountAsync(Limit);
            sw.Stop();
            Result = $"{count} prime numbers. Calculated in {Math.Round(sw.Elapsed.TotalSeconds, 2)} seconds";
            enabled = true;
        }

        //Operations
        public CustomCommand StartCommand { get; private set; }

        private void Start(object obj)
        {
            LoadData();
        }

        private bool CanStart(object obj)
        {
            return enabled;
        }
    }
}
