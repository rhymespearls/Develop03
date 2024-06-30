public class Reference
{
    public string _Book =""; 
    public int _Chapter;
    public int _VerseStart; 
    public int _VerseEnd; 
    
    public Reference(string book, int chapter, int verse)
    {
        _Book = book;
        _Chapter = chapter;
        _VerseStart = verse;
        _VerseEnd = verse;
    }
    
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _Book = book;
        _Chapter = chapter;
        _VerseStart = verseStart;
        _VerseEnd = verseEnd;
    }
    
    public string GetFormattedReference()
    {
        if (_VerseStart == _VerseEnd)
        {
            return $"{_Book} {_Chapter}:{_VerseStart}";
        }
        else
        {
            return $"{_Book} {_Chapter}:{_VerseStart}-{_VerseEnd}";
        }
    }
}