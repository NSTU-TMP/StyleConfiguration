﻿using System.Reactive;using ReactiveUI;using ReactiveUI.Fody.Helpers;namespace StyleConfiguration.ViewModels{    public class MainWindowViewModel : ReactiveObject    {        public MainWindowViewModel()        {            ConfirmPassword = ReactiveCommand.Create(() =>            {                            });        }        public ReactiveCommand<Unit, Unit> ConfirmPassword { get; }        [Reactive] public string UserLogin { get; set; }        [Reactive] public string UserPassword { get; set; }    }}