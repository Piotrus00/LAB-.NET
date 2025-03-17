namespace Lab2 ;

using NUnit.Framework;
using System.Collections.Generic;


[TestFixture]
public class TextAnalyzerTests
{
    TextAnalyzer analyzer = new TextAnalyzer();
    [Test]
    public void CountCharacters_ShouldReturnCorrectNumber()
    {
        var text = "Hello, world!";
        int result = analyzer.CountCharacters_space(text);
        Assert.AreEqual(13, result);
    }

    [Test]
    public void CountCharacters_wo_space_ShouldReturnCorrectNumber()
    {
        var text = "Hello world!";
        int result = analyzer.CountCharacters_wo_space(text);
        Assert.AreEqual(11, result);
    }
    
    [Test]
    public void CountNumbers_ShouldReturnCorrectNumber()
    {
        var text = "Hello world!";
        int result = analyzer.CountNumbers(text);
        Assert.AreEqual(0, result);
    }
    
    [Test]
    public void CountInterpuction_ShouldReturnCorrectNumber()
    {
        var text = "Hello world!";
        int result = analyzer.CountInterpuction(text);
        Assert.AreEqual(1, result);
    }
    
    [Test]
    public void CountWords_ShouldReturnCorrectNumber()
    {
        var text = "Hello world!";
        int result = analyzer.CountWords(text);
        Assert.AreEqual(2, result);
    }
    
    [Test]
    public void Count_Uniq_Words_ShouldReturnCorrectNumber()
    {
        var text = "Hello world! world! world! world!";
        int result = analyzer.Count_Uniq_Words(text);
        Assert.AreEqual(2, result);
    }
    
    
        [Test]
    public void Count_Uniq_Wor_ShouldReturnCorrectNumber()
    {
        var text = "Hello world!";
        int result = analyzer.CountNumbers(text);
        Assert.AreEqual(0, result);
    }
    [Test]
    public void Count_most_common_Words_ShouldReturnCorrectWord()
    {
        var text = "apple banana apple orange apple banana";
        string result = analyzer.Count_most_common_Words(text);
        Assert.AreEqual("apple", result);
    }

    [Test]
    public void AnalyzeText_WithEmptyString_ShouldReturnZeroes()
    {
        var text = "";
        var result = analyzer.AnalyzeText(text);
        
        Assert.AreEqual(0, result.CharacterCount);
        Assert.AreEqual(0, result.WordCount);
        Assert.AreEqual(0, result.SentenceCount);
    }
}