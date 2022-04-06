using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using PanoptiBooru.Server.Structures;

namespace PanoptiBooru.Server.Tests.Structures;

public class StringTrieTests
{
    private StringTrie _trie;
    
    [SetUp]
    public void Setup()
    {
        _trie = new StringTrie(new []
        {
            "stress",
            "stress test",
            "stressful",
            "anime",
            "animated",
            "animatronic",
            "animosity"
        });
    }

    [Test]
    public void TestGetAll_GetsCorrectValues()
    {
        var all = _trie.GetAll().ToList();
        
        Assert.AreEqual(7, all.Count);
        Assert.Contains("stress", all);
        Assert.Contains("stress test", all);
        Assert.Contains("stressful", all);
        Assert.Contains("anime", all);
        Assert.Contains("animated", all);
        Assert.Contains("animatronic", all);
        Assert.Contains("animosity", all);
    }

    [Test]
    public void TestGetByPrefix_GetsCorrectValues()
    {
        var matches = _trie.GetByPrefix("stress").ToList();
        Assert.AreEqual(3, matches.Count);
        Assert.Contains("stress", matches);
        Assert.Contains("stress test", matches);
        Assert.Contains("stressful", matches);

        matches = _trie.GetByPrefix("ani").ToList();
        Assert.AreEqual(4, matches.Count);
        Assert.Contains("anime", matches);
        Assert.Contains("animated", matches);
        Assert.Contains("animatronic", matches);
        Assert.Contains("animosity", matches);

        matches = _trie.GetByPrefix("anima").ToList();
        Assert.Contains("animated", matches);
        Assert.Contains("animatronic", matches);
    }
}
