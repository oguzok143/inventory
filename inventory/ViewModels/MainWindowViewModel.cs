using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using inventory.DB;
using inventory.Models;
using inventory.Views;
using Microsoft.Extensions.DependencyInjection;

namespace inventory.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly IServiceProvider _provider;
    private readonly MainRepository _repository;
    public Window _currentWindow;
    
    [ObservableProperty] public List<Tech> _techs;
    [ObservableProperty] public List<Employee> _emplyees;
    [ObservableProperty] public List<Position> _positions;
    [ObservableProperty] public Tech _selectedTech;
    
    public MainWindowViewModel(IServiceProvider serviceProvider, MainRepository repository)
    {
        _provider = serviceProvider;
        _repository = repository;

        GetTech();
        GetEmployees();
        GetPositions();

    }

    private void GetTech()
    {
        Techs = _repository.GetTechs();
    }

    private void GetEmployees()
    {
        Emplyees = _repository.GetEmpyees();
    }
    
    private void GetPositions()
    {
        Positions = _repository.GetPositions();
    }

    public void SetScreen(MainWindow win)
    {
        _currentWindow = win;
    }

    [RelayCommand]
    public void OpenTechEdit()
    {
        var win = _provider.GetRequiredService<TechEditWindow>();
        var vm = ActivatorUtilities.CreateInstance<TechEditViewModel>(_provider, SelectedTech);
        win.DataContext = vm;
        win.Show();
    }
}