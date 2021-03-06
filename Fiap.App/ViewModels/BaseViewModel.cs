﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Fiap.App.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        string title;
        bool isBusy;

        public string Title
        {
            get => title;
            set
            {
                if (title == value) return;

                title = value;
                OnPropertyChanged();
            }
        }
        
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy == value) return;

                isBusy = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotBusy));
            }
        }

        public bool IsNotBusy => !IsBusy;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnPropertyChanged([CallerMemberName]string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
