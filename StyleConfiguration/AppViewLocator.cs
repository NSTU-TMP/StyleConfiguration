using ReactiveUI;using StyleConfiguration.ViewModels;using StyleConfiguration.Views;namespace StyleConfiguration;public class AppViewLocator : IViewLocator{    public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)    {        return viewModel switch        {            MainWindowViewModel context => new WorkPlaceView { DataContext = context },        };    }}