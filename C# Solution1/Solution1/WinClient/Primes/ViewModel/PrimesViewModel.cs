using System;
using System.ComponentModel;
using System.Diagnostics;
using WinClient.Primes.Model;

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
            StartCommand = new CustomCommand(obj => LoadData(), obj => enabled);
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

        //Operations

        public CustomCommand StartCommand { get; private set; }

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
    }
}
