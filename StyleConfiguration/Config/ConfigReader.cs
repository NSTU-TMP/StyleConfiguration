using System.Collections.Generic;using System.Collections.ObjectModel;using System.IO;using Avalonia.Controls;namespace StyleConfiguration.Config;public class ConfigReader{    private readonly StreamReader? _sr;    public ObservableCollection<MenuItem> Items { get; }    public ConfigReader(string? pathToConfig)    {        if (pathToConfig != null)        {            _sr = new StreamReader(pathToConfig);        }        Items = new ObservableCollection<MenuItem>();    }    public bool Parsing()    {        var line = _sr?.ReadLine();        if (line == null) return false;        var splitLine = line.Split();        while (line != null)        {            switch (splitLine.Length)            {                case 4 or 3 when splitLine[0] != "1":                {                    var tmp = new MenuItem                    {                        Header = splitLine[1]                    };                    if (splitLine[2] == "1") tmp.IsEnabled = false;                    if (splitLine[2] == "2") tmp.IsVisible = false;                    Items.Add(tmp);                                        break;                }                case 4 or 3 when splitLine[0] == "1":                {                    var newItems = new List<MenuItem>();                    Items[^1].Items = new List<MenuItem>[] { };                    while (splitLine[0] == "1")                    {                        var tmp = new MenuItem()                        {                            Header = splitLine[1]                        };                        if (splitLine[2] == "1") tmp.IsEnabled = false;                        if (splitLine[2] == "2") tmp.IsVisible = false;                        newItems.Add(tmp);                        line = _sr?.ReadLine();                        if (line != null) splitLine = line.Split();                        else break;                        if (splitLine.Length is < 3 or > 4) return false;                    }                    Items[^1].Items = newItems;                                        continue;                }                default:                    Items.Clear();                    return false;            }            line = _sr?.ReadLine();            if (line != null) splitLine = line.Split();        }        return true;    }}