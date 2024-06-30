
public class Scripture
{
    private readonly List<ScriptureWord> words;

    public Scripture(string reference, string text)
    {
        Reference = ParseReference(reference);
        words = ConvertStringToWords(text);
    }

    public Reference Reference { get; }

    public bool IsVerseDone()
    {
        return words.All(word => word.IsHidden);
    }

    public void HideRandomWord()
    {
        var hiddenWords = words.Where(word => word.IsHidden).ToList();
        var visibleWords = words.Where(word => !word.IsHidden).ToList();

        var randomIndex = new Random().Next(visibleWords.Count);
        var wordToHide = visibleWords[randomIndex];
        wordToHide.IsHidden = true;
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(Reference.GetFormattedReference());
        foreach (var word in words)
        {
            if (word.IsHidden)
            {
                Console.Write("------- ");
            }
            else
            {
                Console.Write(word.Word + " ");
            }
        }
        Console.WriteLine();
    }

    private static Reference ParseReference(string reference)
    {
        var parts = reference.Split(' ');
        var book = parts[0];
        var chapterVerse = parts[1].Split(':');
        var chapter = int.Parse(chapterVerse[0]);

        if (chapterVerse[1].Contains('-'))
        {
            var verseRange = chapterVerse[1].Split('-');
            var verseStart = int.Parse(verseRange[0]);
            var verseEnd = int.Parse(verseRange[0]);
            return new Reference(book, chapter, verseStart, verseEnd);
        }
        else
        {
            var verse = int.Parse(chapterVerse[0]);
            return new Reference(book, chapter, verse);
        }
    }

    private static List<ScriptureWord> ConvertStringToWords(string text)
    {
        var words = text.Split(' ').Select(word => new ScriptureWord(word)).ToList();
        return words;
    }
}