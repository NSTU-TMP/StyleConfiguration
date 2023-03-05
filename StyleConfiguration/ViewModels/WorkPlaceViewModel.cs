using System.Collections.ObjectModel;using Avalonia.Controls;using DynamicData;using ReactiveUI;using StyleConfiguration.Config;namespace StyleConfiguration.ViewModels;public class WorkPlaceViewModel : ReactiveObject, IRoutableViewModel, IScreen{    public ObservableCollection<MenuItem>? Items { get; }    public WorkPlaceViewModel(ObservableCollection<MenuItem>? items)    {        if (items != null) Items = new ObservableCollection<MenuItem>() { items };    }    public string? UrlPathSegment { get; }    public IScreen? HostScreen { get; }    public RoutingState Router { get; } = new();}