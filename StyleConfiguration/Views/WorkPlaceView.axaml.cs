using Avalonia;using Avalonia.Controls;using Avalonia.Markup.Xaml;using Avalonia.ReactiveUI;using StyleConfiguration.ViewModels;namespace StyleConfiguration.Views;public partial class WorkPlaceView : ReactiveUserControl<WorkPlaceViewModel>{    public WorkPlaceView()    {        InitializeComponent();    }    private void InitializeComponent()    {        AvaloniaXamlLoader.Load(this);    }}