using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fiap.App.ViewModels
{
    public class ImcPageViewModel : BaseViewModel
    {
        public ImcPageViewModel()
        {
            Title = "IMC";
            CalcularCommand = new Command(CalcularHandler);
            LimparCommand = new Command(LimparHandler);
        }

        string altura;
        public string Altura
        {
            get => altura;
            set
            {
                if (altura == value) return;

                altura = value;
                OnPropertyChanged();
            }
        }

        string peso;
        public string Peso
        {
            get => peso;
            set
            {
                if (peso == value) return;

                peso = value;
                OnPropertyChanged();
            }
        }

        string resultado;
        public string Resultado
        {
            get => resultado;
            set
            {
                if (resultado == value) return;

                resultado = value;
                OnPropertyChanged();
            }
        }

        bool ativo;
        public bool Ativo
        {
            get => ativo;
            set
            {
                if (ativo == value) return;

                ativo = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalcularCommand { get; private set; }

        public ICommand LimparCommand { get; private set; }

        private void CalcularHandler(object obj)
        {
            Resultado = Convert.ToString(double.Parse(Peso) / double.Parse(Altura) * double.Parse(Altura));
            Ativo = true;
        }

        private void LimparHandler(object obj)
        {
            Resultado = Altura = Peso = null;
            Ativo = false;
        }
    }
}