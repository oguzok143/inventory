using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using inventory.DB;
using inventory.Models;

namespace inventory.ViewModels;

public partial class TechEditViewModel : ViewModelBase
{
    private readonly IServiceProvider _provider;
    private readonly TechRepository _repository;
    private readonly MainRepository _mainRepository;
    
    [ObservableProperty] public Tech _selectedTech;
    [ObservableProperty] public Employee _selectedEmployee;
    //[ObservableProperty] public Employee _selectedEmployee;

    public TechEditViewModel(IServiceProvider serviceProvider, TechRepository techRepository, MainRepository mainRepository, Tech selectedTech)
    {
        _provider = serviceProvider;
        _repository = techRepository;
        _mainRepository = mainRepository;
        SelectedTech = selectedTech;
    }

    [RelayCommand]
    public void Save()
    {
        if (SelectedTech.Id <= 0)
            _repository.InsertTech(SelectedTech);
        else 
            _repository.UpdateTech(SelectedTech);
            
    }
}