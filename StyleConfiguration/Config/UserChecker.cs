using System.IO;using static System.String;namespace StyleConfiguration.Config;public class UserChecker{    private readonly string? _password;    private readonly string? _login;    public string? PathToConfig;    private readonly StreamReader _sr =        new StreamReader("/home/darling/RiderProjects/StyleConfiguration/StyleConfiguration/Config/userTest.txt");    public UserChecker(string? password, string? login)    {        _password = password;        _login = login;    }    public bool CmpUsers()    {        var line = _sr.ReadLine();        if (line == null)        {            MessageBox.Avalonia.MessageBoxManager                .GetMessageBoxStandardWindow("Ошибка файла", "Файл пуст или заполнен неверно").Show();                        return false;        }        var splitLine = line.Split();        while (line != null)        {            if (splitLine.Length == 3)            {                if (CompareOrdinal(_login, splitLine[0]) == 0 && CompareOrdinal(_password, splitLine[1]) == 0                                                               && IsNullOrWhiteSpace(splitLine[2]) == false)                {                    PathToConfig = splitLine[2];                    return true;                }            }            line = _sr.ReadLine();            if (line != null) splitLine = line.Split();        }        MessageBox.Avalonia.MessageBoxManager            .GetMessageBoxStandardWindow("Неверные данные", "Неверно введен логин или пароль").Show();        return false;    }}