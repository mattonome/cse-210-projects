using System.Collections.Generic;
public class Scripture{
    private Reference _reference;

    private List<Word> _words;

    public Scripture(Reference reference, string text){
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split();
        foreach (string word in parts)
        {
            Word wordObj = new Word(word);
            _words.Add(wordObj);
        }
    }
    public void HideRandomWords(int numberToHide){
        Random randomSelector = new Random();
        int counter = 0;
        while (counter < numberToHide){
            for (int i = 0; i < numberToHide; i++)
            {
                int value = randomSelector.Next(_words.Count);
                if (!_words[value].IsHidden()){
                    _words[value].Hide();
                    counter ++;
                }
            }
        }

    }
    public string GetDisplayText(){
        string referenceText = _reference.GetReferences();
        string script = "";
        foreach (Word word in _words)
        {
            script += word.GetDisplayText() + " ";
        }
        return $"{referenceText} {script.Trim()}";

    }
    public bool IsCompletelyHidden(){
        foreach (Word word in _words)
        {
            if(!word.IsHidden()){
                return false;
            }
        }
        return true;
    }

}