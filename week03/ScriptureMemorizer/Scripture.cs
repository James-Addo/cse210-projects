using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] wordList = text.Split(' ');

        foreach (string wordText in wordList)
        {
            Word newWord = new Word(wordText);
            _words.Add(newWord);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> shownWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                shownWords.Add(word);
            }
        }

        int count = Math.Min(numberToHide, shownWords.Count);

        for (int i = 0; i < count; i++)
        {
            int index = _random.Next(shownWords.Count);
            Word wordToHide = shownWords[index];
            wordToHide.Hide();
            shownWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = "";
        foreach (Word singleWord in _words)
        {
            if (scriptureText.Length > 0)
            {
                scriptureText += " ";
            }

            scriptureText += singleWord.GetDisplayText();
        }

        string referenceText = _reference.GetDisplayText();
        return $"{referenceText} {scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(singleWord => singleWord.IsHidden());
    }
}