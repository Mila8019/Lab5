using System.Text.RegularExpressions;
using Avalonia.Controls;
using Avalonia.Media;
using Lab5.Views;
using ReactiveUI;

namespace Lab5.ViewModels;

public sealed class DialogViewModel : ViewModelBase
{
    private string _word;
    private string _construction;
    private string _root;
    private string _inputWord;
    
    private readonly MainWindowViewModel _mainWindowViewModel;
    private readonly DialogWindow _dialog;
    private readonly Button _button;

    public DialogViewModel(MainWindowViewModel mwvm, DialogWindow dialog, string word)
    {
        _mainWindowViewModel = mwvm;
        _dialog = dialog;
        Word = word;
        _button = _dialog.FindControl<Button>("OkButton");
    }

    public string InputWord
    {
        get => _inputWord;
        set => this.RaiseAndSetIfChanged(ref _inputWord, value);
    }
    
    public string Word
    {
        get => _word;
        set => this.RaiseAndSetIfChanged(ref _word, value);
    }

    public string Construction
    {
        get => _construction;
        set => this.RaiseAndSetIfChanged(ref _construction, value);
    }

    public string Root
    {
        get => _root;
        set => this.RaiseAndSetIfChanged(ref _root, value);
    }

    private bool IsInputWordValid(string inputWord)
    {
        const string pattern = @"^([a-zA-Zа-яА-Я]+-)*\[(\w+)*\](-\w+)*(-\w+)*(-\w+)*(-\w+)*$";

        var excWord = inputWord.Replace("-", "").Replace("[", "").Replace("]", "");

        return Regex.IsMatch(inputWord, pattern) && Word == excWord;
    }

    public async void AddWord()
    {
        Construction = _inputWord;
        string pattern = @"\[(.*?)\]";
        if (IsInputWordValid(InputWord))
        {
            _button.Background = Brushes.Chartreuse;
            Root = Regex.Match(_construction, pattern).Groups[1].Value;
            await _mainWindowViewModel.AddWord(Word, Construction, Root);
            _dialog.Close();
        }
        else
        {
            _button.Background = Brushes.Red;
        }
    }
}