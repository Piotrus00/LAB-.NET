namespace Lab2;

public class TextAnalyzer
{
    public int CountCharacters_space(string text)
    {
        return text.Length;
    }
    
    public int CountCharacters_wo_space(string text)
    {
        return text.Replace(" ", "").Length;
    }

    public int CountLetters(string text)
    {
        int count = 0;
        foreach (var znak in text)
        {
            if (char.IsLetter(znak))
            {
                count++;
            }
        }
        return count;
    }
    
    public int CountNumbers(string text)
    {
        int count = 0;
        foreach (var znak in text)
        {
            if (char.IsNumber(znak))
            {
                count++;
            }
        }
        return count;
    }
    
    public int CountInterpuction(string text)
    {
        int count = 0;
        foreach (var znak in text)
        {
            if (char.IsPunctuation(znak))
            {
                count++;
            }
        }
        return count;
    }
    
    public int CountWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;
        return text.Split(' ').Length;
    }
    
    public int Count_Uniq_Words(string text)
    {
        string[] words = text.Split(' ');
        words = words.Distinct().ToArray();
        if (string.IsNullOrWhiteSpace(text))
            return 0;
        return words.Length;
    }
    
    public string Count_most_common_Words(string text)
    {
        text = text.Replace(".", "").ToLower();
        string[] arr = text.Split(' ');
        Dictionary<String, int> hs = new Dictionary<String, int>();

        foreach (var x in arr)
        {
            if (hs.ContainsKey(x)) {
                hs[x] = hs[x] + 1;
            }
            else {
                hs.Add(x, 1);
            }
        }
        
        String key = "";
        int value = 0;

        foreach(KeyValuePair<String, int> dict in hs)
        {
            if (dict.Value > value) {
                value = dict.Value;
                key = dict.Key;
            }
        }
        return key;
    }
    
    public int Count_avg_len_Words(string text)
    {
        int sum = 0;
        int div = 0;
        text = text.Replace(".", "").ToLower();
        string[] arr = text.Split(' ');

        foreach (var x in arr)
        {
            sum+= x.Length;
            div++;
        }

        if (div < 1)
        {
            return 0;
        }
        return sum/div;
    }

    public string Find_shortest_and_logest_word(string text)
    {
        text = text.Replace(".", "").ToLower();
        string[] arr = text.Split(' ');
        int tempShortest = 999, tempLongest = 0;
        string shortest = "", logest = "";
        foreach (var x in arr)
        {
            if (x.Length < tempShortest)
            {
                tempShortest = x.Length;
                shortest = x;
            }

            if (x.Length > tempLongest)
            {
                tempLongest = x.Length;
                logest = x;
            }
        }
        
        return shortest + " " + logest;
    }

    public int CountSentences(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;

        return text.Split('.', '!', '?').Length;
    }

    public int CountSentences_avg_leng(string text)
    {
        int sum=0, div=0;
        string[] arr = text.Split('.', '!', '?');
        foreach (var x in arr)
        {
            sum += x.Length;
            div++;
        }

        if (div==0)
        {
            return -1;
        }
        return sum/div;
    }

    public string CountSentences_lognest(string text)
    {
        string[] arr = text.Split('.', '!', '?');
        int tempLongest = 0;
        string logest = "";
        foreach (var x in arr)
            if (x.Length > tempLongest)
            {
                tempLongest = x.Length;
                logest = x;
            }
        return logest;
    }
    
    public TextStatistics AnalyzeText(string text)
    {
        TextStatistics stats = new TextStatistics();
    
        stats.CharacterCount = CountCharacters_space(text);
        stats.CharacterCountWithoutSpaces = CountCharacters_wo_space(text);
        stats.LetterCount = CountLetters(text);
        stats.NumberCount = CountNumbers(text);
        stats.PunctuationCount = CountInterpuction(text);
        stats.WordCount = CountWords(text);
        stats.UniqueWordCount = Count_Uniq_Words(text);
        stats.MostCommonWord = Count_most_common_Words(text);
        stats.AverageWordLength = Count_avg_len_Words(text);
        stats.ShortestAndLongestWord = Find_shortest_and_logest_word(text);
        stats.SentenceCount = CountSentences(text);
        stats.AverageSentenceLength = CountSentences_avg_leng(text);
        stats.LongestSentence = CountSentences_lognest(text);

        return stats;
    }

}