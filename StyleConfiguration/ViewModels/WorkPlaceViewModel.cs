using System.Collections.ObjectModel;using Avalonia.Controls;using DynamicData;using ReactiveUI;using StyleConfiguration.Config;namespace StyleConfiguration.ViewModels;public class WorkPlaceViewModel : ReactiveObject, IRoutableViewModel, IScreen{    private string _pathToConfig;    private ConfigReader _configReader;    public ObservableCollection<MenuItem> Items { get; }        public WorkPlaceViewModel(string pathToConfig)    {        _pathToConfig = pathToConfig;        _configReader = new ConfigReader(pathToConfig);        Items = new ObservableCollection<MenuItem>() { _configReader.Items };    }    public string? UrlPathSegment { get; }    public IScreen HostScreen { get; }    public RoutingState Router { get; } = new();}