using System.Collections.Generic;using System.Collections.ObjectModel;using System.Reactive;using Avalonia.Controls;using ReactiveUI;namespace Presentation.ViewModels;public class WorkPlaceViewModel : ReactiveObject, IRoutableViewModel, IScreen{    public ObservableCollection<MenuItem> Items { get; }    public WorkPlaceViewModel(IReadOnlyCollection<MenuItem> items)    {         Items = new ObservableCollection<MenuItem>(items);    }      public ReactiveCommand<string, Unit> ButtonClick;    public string? UrlPathSegment { get; }    public IScreen? HostScreen { get; }    public RoutingState Router { get; } = new();}