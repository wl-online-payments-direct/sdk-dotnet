using System;
using System.IO;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Communication;

[TestFixture]
public class UploadableFileTest
{
    [TestCase]
    public void Constructor_WithValidParametersAndKnownLength_StoresAllProperties()
    {
        var stream = new MemoryStream([1, 2, 3]);
        var file = new UploadableFile("test.txt", stream, "text/plain", 12);

        Assert.That(file.FileName, Is.EqualTo("test.txt"));
        Assert.That(file.ContentType, Is.EqualTo("text/plain"));
        Assert.That(file.ContentLength, Is.EqualTo(12));
        Assert.That(file.Content, Is.SameAs(stream));
    }

    [TestCase]
    public void Constructor_WithDefaultContentLength_DefaultsToMinusOne()
    {
        var file = new UploadableFile("test.txt", new MemoryStream(), "text/plain");

        Assert.That(file.ContentLength, Is.EqualTo(-1));
    }

    [TestCase]
    public void Constructor_WithNegativeContentLength_NormalizesToMinusOne()
    {
        var file = new UploadableFile("test.txt", new MemoryStream(), "text/plain", -100);

        Assert.That(file.ContentLength, Is.EqualTo(-1));
    }

    [TestCase]
    public void Constructor_WithNullFileName_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => { _ = new UploadableFile(null, new MemoryStream(), "text/plain"); });

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("File Name is required"));
    }

    [TestCase]
    public void Constructor_WithEmptyFileName_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => { _ = new UploadableFile("", new MemoryStream(), "text/plain"); });

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("File Name is required"));
    }

    [TestCase]
    public void Constructor_WithNullContent_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => { _ = new UploadableFile("test.txt", null, "text/plain"); });

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("Content is required"));
    }

    [TestCase]
    public void Constructor_WithNullContentType_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => { _ = new UploadableFile("test.txt", new MemoryStream(), null); });

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("Content Type is required"));
    }

    [TestCase]
    public void Constructor_WithEmptyContentType_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => { _ = new UploadableFile("test.txt", new MemoryStream(), ""); });

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("Content Type is required"));
    }
}
