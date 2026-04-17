using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using inventory.DB;
using inventory.Models;

namespace inventory.ViewModels;

public partial class TechEditViewModel : ViewModelBase
{
    private readonly IServiceProvider _provider;
    
    [ObservableProperty] public Tech _selectedTech;

    public TechEditViewModel(IServiceProvider serviceProvider, TechRepository techRepository, Tech SelectedTech)
    {
        _provider = serviceProvider;
        if (SelectedTech != null)
        {
            _selectedTech = SelectedTech;
                        
        }
        else
            _selectedTech = new Tech();
    }
}