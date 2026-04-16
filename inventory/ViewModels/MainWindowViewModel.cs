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
    
    //[ObservableProperty] public List<VisualTech> _visualTechs;
    [ObservableProperty] public List<Tech> _techs;
    [ObservableProperty] public List<Employee> _emplyees;
    [ObservableProperty] public List<Position> _positions;
    
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


    // public void GetVisualTechs()
    // {
    //     for (int i = 0; i < Techs.Count; i++)
    //     {
    //         VisualTechs.Add(new VisualTech
    //         {
    //             InvNumber = Techs[i].InvNumber,
    //             Name = Techs[i].Name,
    //             PurchaseDate = Techs[i].PurchaseDate,
    //             Cost = Techs[i].Cost,
    //             IsWrittenString = Techs[i].IsWrittenOff == 1 ? "да" : "нет",
    //             CurrentEmployeeName = Emplyees.FirstOrDefault(s => s.Id == Techs[i].CurrentEmployeeId).FullName
    //         });
    //     }
    // }
}