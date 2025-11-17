using System;
using System.Text.RegularExpressions;

// Завдання 1
interface IRemoteControl
{
    void TurnOn();
    void TurnOff();
    void SetChannel(int channel);
}

class TvRemoteControl : IRemoteControl
{
    public void TurnOn()  => Console.WriteLine("TV увімкнено");
    public void TurnOff() => Console.WriteLine("TV вимкнено");
    public void SetChannel(int channel) =>
        Console.WriteLine($"TV: канал {channel}");
}

class RadioRemoteControl : IRemoteControl
{
    public void TurnOn()  => Console.WriteLine("Радіо увімкнено");
    public void TurnOff() => Console.WriteLine("Радіо вимкнено");
    public void SetChannel(int channel) =>
        Console.WriteLine($"Радіо: частота {channel} МГц");
}


// Завдання 2
interface IValidator
{
    bool Validate(string input);
}

class EmailValidator : IValidator
{
    public bool Validate(string input)
    {
        return Regex.IsMatch(input, @"^[\w\.-]+@[\w\.-]+\.\w+$");
    }
}

class PasswordValidator : IValidator
{
    public bool Validate(string input)
    {
        return input.Length >= 6 &&
               input.Any(char.IsDigit) &&
               input.Any(char.IsUpper);
    }
}


// Демонстрація
class Program
{
    static void Main()
    {
        IRemoteControl tv = new TvRemoteControl();
        IRemoteControl radio = new RadioRemoteControl();

        tv.TurnOn();
        tv.SetChannel(5);
        tv.TurnOff();

        radio.TurnOn();
        radio.SetChannel(102);
        radio.TurnOff();

        IValidator emailValidator = new EmailValidator();
        IValidator passwordValidator = new PasswordValidator();

        Console.WriteLine(emailValidator.Validate("test@mail.com"));
        Console.WriteLine(passwordValidator.Validate("Qwerty1"));
    }
}
