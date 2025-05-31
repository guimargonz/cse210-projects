// Scripture.cs
using System;
using System.Collections.Generic;
using System.Linq; // For LINQ methods like Where, ToList, Count

public class Scripture
{
    // Attributes
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random(); // For selecting random words

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        // Split the text into words and create Word objects
        string[] wordArray = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordStr in wordArray)
        {
            _words.Add(new Word(wordStr));
        }
    }

    // Behaviors (Methods)
    public void HideRandomWords(int numberToHide)
    {
        // Core requirement: can select any word at random, even if already hidden.
        // For a better experience, we'll try to hide words that are not yet hidden.

        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        if (visibleWords.Count == 0)
        {
            return; // All words are already hidden
        }

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int randomIndex = _random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex); // Remove from list of words to pick from this round
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim(); // Trim trailing space
    }

    public bool IsCompletelyHidden()
    {
        // Returns true if all words in the scripture are hidden
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false; // Found a word that is not hidden
            }
        }
        return true; // All words are hidden
    }
}