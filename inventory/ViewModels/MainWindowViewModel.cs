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

    [RelayCommand]
    public void OpenTechAdd()
    {
        Tech NewTech = new Tech();
        NewTech.Id = 0;
        NewTech.InvNumber = "";
        NewTech.Name = "New Tech";
        NewTech.PurchaseDate = DateTime.Now;
        NewTech.Cost = 0;
        NewTech.IsWrittenOff = 0;
        NewTech.CurrentEmployeeId = 0;
        NewTech.CurrentEmployeeFullName = "";
        OpenEditWindow(NewTech);
    }

    [RelayCommand]
    public void OpenTechEdit()
    {
        if (SelectedTech == null)
            return;
        OpenEditWindow(SelectedTech);
    }

    private void OpenEditWindow(Tech tech)
    {
        var win = _provider.GetRequiredService<TechEditWindow>();
        var vm = ActivatorUtilities.CreateInstance<TechEditViewModel>(_provider, tech);
        win.DataContext = vm;
        win.Show();
    }
}