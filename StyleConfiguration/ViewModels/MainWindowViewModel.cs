﻿using System;using System.Collections.ObjectModel;using System.Reactive;using System.Reactive.Linq;using System.Threading.Tasks;using Avalonia.Controls;using ReactiveUI;using ReactiveUI.Fody.Helpers;using StyleConfiguration.Config;namespace StyleConfiguration.ViewModels{    public class MainWindowViewModel : ReactiveObject, IScreen    {        private ObservableCollection<MenuItem>? MenuItems { get; set; }        public MainWindowViewModel()        {            ConfirmPassword = ReactiveCommand.CreateFromTask(Authorize);        }        private async Task Authorize()        {            try            {                var reader = new UserChecker("../../../DataSets/Users/userTest.txt", UserPassword, UserLogin);                reader.CompareUsers();                await Router.Navigate.Execute(new WorkPlaceViewModel(                    new ObservableCollection<MenuItem>(                        MenuItemsParser.Parse(reader.PathToConfig,   ReactiveCommand.CreateFromTask<string>(ShowMessageBox))))                );            }            catch (Exception ex)            {                UserLogin = string.Empty;                UserPassword = string.Empty;                await ShowMessageBox(ex.Message);            }        }                private async Task ShowMessageBox(string message)        {            await MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Сообщение", message)                .Show();        }                public ReactiveCommand<Unit, Unit> ConfirmPassword { get; }        [Reactive] public string? UserLogin { get; set; }        [Reactive] public string? UserPassword { get; set; }        public RoutingState Router { get; } = new();    }}