// Word.cs
using System;
using System.Linq; // For new string('_', count)

public class Word
{
    // Attributes
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false; // Words start visible
    }

    // Behaviors (Methods)
    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Replace with underscores matching the word length
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }

    // Getter for the original text (might be useful for stretch goals)
    public string GetText()
    {
        return _text;
    }
}