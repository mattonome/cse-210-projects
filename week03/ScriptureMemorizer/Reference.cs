public class Reference{
    private string _passageName;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string passage,int chapter,int verse){
        _passageName = passage;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }
    public Reference(string passage,int chapter, int startVerse, int endVerse){
        _passageName = passage;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
    public string GetReferences(){
        if (_startVerse == _endVerse){
            string text=$"{_passageName} {_chapter}:{_startVerse}";
            return text;
        }else{
            string text= $"{_passageName} {_chapter}:{_startVerse}-{_endVerse}";
            return text;
        }
    }

}