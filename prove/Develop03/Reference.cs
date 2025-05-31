// Reference.cs
using System;

public class Reference
{
    // Attributes
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse; // Will be 0 or same as _verse if not a range

    // Constructors
    // Constructor for a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0; 
    }

    // Constructor for a verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // Behaviors (Methods)
    public string GetDisplayText()
    {
        if (_endVerse == 0 || _endVerse == _verse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }

}