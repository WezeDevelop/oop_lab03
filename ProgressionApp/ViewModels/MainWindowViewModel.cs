using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProgressionApp.Models;

namespace ProgressionApp.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty] private string selectedType = "Linear";
        [ObservableProperty] private string inputA = "1";
        [ObservableProperty] private string inputStep = "1";
        [ObservableProperty] private string inputJ = "1";
        [ObservableProperty] private string inputN = "1";
        [ObservableProperty] private string result = "";

        [RelayCommand]
        private void Calculate()
        {
            try
            {
                double a = double.Parse(InputA);
                double step = double.Parse(InputStep);
                int j = int.Parse(InputJ);
                int n = int.Parse(InputN);

                Series series = SelectedType == "Linear"
                    ? new Linear(a, step)
                    : new Exponential(a, step);

                double elem = series.GetElement(j);
                double sum = series.GetSum(n);

                Result = $"{j}-й елемент: {elem:F2}\nСума перших {n} елементів: {sum:F2}";
            }
            catch (Exception ex)
            {
                Result = $"Помилка: {ex.Message}";
            }
        }
    }
}
