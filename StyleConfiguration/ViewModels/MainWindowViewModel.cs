﻿using System;using System.Collections.Generic;using System.Collections.ObjectModel;using System.Reactive;using System.Reactive.Linq;using System.Threading.Tasks;using Avalonia.Controls;using ReactiveUI;using ReactiveUI.Fody.Helpers;using StyleConfiguration.Config;namespace StyleConfiguration.ViewModels{    public class MainWindowViewModel : ReactiveObject, IScreen    {        private ObservableCollection<MenuItem>? MenuItems { get; set; }        [Reactive] public int Width { get; set; } = 400;        [Reactive] public int Height { get; set; } = 400;        private Dictionary<string, ReactiveCommand<string, Unit>> commands;        public MainWindowViewModel()        {            ConfirmPassword = ReactiveCommand.CreateFromTask(Authorize);            commands = new Dictionary<string, ReactiveCommand<string, Unit>>();            commands.Add("Button", ReactiveCommand.CreateFromTask<string>(ShowMessageBox));        }        private async Task Authorize()        {            try            {                var reader = new UserChecker("../../../DataSets/Users/userTest.txt", UserPassword, UserLogin);                reader.CompareUsers();                Width = 1280;                Height = 720;                await Router.Navigate.Execute(new WorkPlaceViewModel(                    new ObservableCollection<MenuItem>(                        MenuItemsParser.Parse(reader.PathToConfig,  commands)))                );            }            catch (Exception ex)            {                UserLogin = string.Empty;                UserPassword = string.Empty;                await ShowMessageBox(ex.Message);            }        }        private async Task ShowMessageBox()        {                    }        private async Task ShowMessageBox(string message)        {            await MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow("Сообщение", message)                .Show();        }                public ReactiveCommand<Unit, Unit> ConfirmPassword { get; }        [Reactive] public string? UserLogin { get; set; }        [Reactive] public string? UserPassword { get; set; }        public RoutingState Router { get; } = new();    }}