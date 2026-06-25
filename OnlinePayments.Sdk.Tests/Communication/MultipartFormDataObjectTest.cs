using System;
using System.IO;
using NUnit.Framework;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Communication;

[TestFixture]
public class MultipartFormDataObjectTest
{
    private static UploadableFile CreateFile(string fileName = "test.pdf", string contentType = "application/pdf") =>
        new(fileName, new MemoryStream([1, 2, 3]), contentType);

    [TestCase]
    public void Constructor_WithNewInstance_HasNonEmptyBoundary()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        Assert.That(multipartFormDataObject.Boundary, Is.Not.Null.And.Not.Empty);
    }

    [TestCase]
    public void Constructor_WithNewInstance_ContentTypeContainsBoundary()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        Assert.That(multipartFormDataObject.ContentType, Does.Contain("multipart/form-data; boundary="));
        Assert.That(multipartFormDataObject.ContentType, Does.Contain(multipartFormDataObject.Boundary));
    }

    [TestCase]
    public void Constructor_WithNewInstance_ValuesIsEmpty()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        Assert.That(multipartFormDataObject.Values, Is.Empty);
    }

    [TestCase]
    public void Constructor_WithNewInstance_FilesIsEmpty()
    {
        MultipartFormDataObject obj = new();

        Assert.That(obj.Files, Is.Empty);
    }

    [TestCase]
    public void Constructor_WithTwoInstances_BoundariesAreUnique()
    {
        MultipartFormDataObject multipartFormDataObjectFirst = new();
        MultipartFormDataObject multipartFormDataObjectSecond = new();

        Assert.That(multipartFormDataObjectFirst.Boundary, Is.Not.EqualTo(multipartFormDataObjectSecond.Boundary));
    }

    [TestCase]
    public void AddValue_WithNullParameterName_ThrowsArgumentException()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        var exception = Assert.Throws<ArgumentException>(
            () => multipartFormDataObject.AddValue(null, "val"));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("Parameter name is required"));
    }

    [TestCase]
    public void AddValue_WithEmptyParameterName_ThrowsArgumentException()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        var exception = Assert.Throws<ArgumentException>(
            () => multipartFormDataObject.AddValue("", "val"));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("Parameter name is required"));
    }

    [TestCase]
    public void AddValue_WithWhitespaceParameterName_ThrowsArgumentException()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        var exception = Assert.Throws<ArgumentException>(
            () => multipartFormDataObject.AddValue("   ", "val"));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("Parameter name is required"));
    }

    [TestCase]
    public void AddValue_WithNullValue_ThrowsArgumentException()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        var exception = Assert.Throws<ArgumentException>(
            () => multipartFormDataObject.AddValue("param", null));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("value is required"));
    }

    [TestCase]
    public void AddValue_WithValidParameters_StoresValue()
    {
        MultipartFormDataObject multipartFormDataObject = new();
        multipartFormDataObject.AddValue("key", "value");

        Assert.That(multipartFormDataObject.Values.ContainsKey("key"), Is.True);
        Assert.That(multipartFormDataObject.Values["key"], Is.EqualTo("value"));
    }

    [TestCase]
    public void AddValue_WithMultipleValues_StoresAll()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        multipartFormDataObject.AddValue("firstKey", "firstValue");
        multipartFormDataObject.AddValue("secondKey", "secondValue");

        Assert.That(multipartFormDataObject.Values.Count, Is.EqualTo(2));
    }

    [TestCase]
    public void AddValue_WithDuplicateParameterName_ThrowsArgumentException()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        multipartFormDataObject.AddValue("key", "value1");

        var exception = Assert.Throws<ArgumentException>(
            () => multipartFormDataObject.AddValue("key", "value2"));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("Duplicate parameter name: key"));
    }

    [TestCase]
    public void AddValue_WithParameterNameAlreadyUsedByFile_ThrowsArgumentException()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        multipartFormDataObject.AddFile("key", CreateFile());

        var exception = Assert.Throws<ArgumentException>(
            () => multipartFormDataObject.AddValue("key", "value"));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("Duplicate parameter name: key"));
    }

    [TestCase]
    public void AddFile_WithNullParameterName_ThrowsArgumentException()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        var exception = Assert.Throws<ArgumentException>(
            () => multipartFormDataObject.AddFile(null, CreateFile()));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("Parameter name is required"));
    }

    [TestCase]
    public void AddFile_WithEmptyParameterName_ThrowsArgumentException()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        var exception = Assert.Throws<ArgumentException>(
            () => multipartFormDataObject.AddFile("", CreateFile()));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("Parameter name is required"));
    }

    [TestCase]
    public void AddFile_WithWhitespaceParameterName_ThrowsArgumentException()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        var exception = Assert.Throws<ArgumentException>(
            () => multipartFormDataObject.AddFile("   ", CreateFile()));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("Parameter name is required"));
    }

    [TestCase]
    public void AddFile_WithNullFile_ThrowsArgumentException()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        var exception = Assert.Throws<ArgumentException>(
            () => multipartFormDataObject.AddFile("file", null));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("file is required"));
    }

    [TestCase]
    public void AddFile_WithValidParameters_StoresFile()
    {
        MultipartFormDataObject multipartFormDataObject = new();
        var file = CreateFile();
        multipartFormDataObject.AddFile("attachment", file);

        Assert.That(multipartFormDataObject.Files.ContainsKey("attachment"), Is.True);
        Assert.That(multipartFormDataObject.Files["attachment"], Is.SameAs(file));
    }

    [TestCase]
    public void AddFile_WithMultipleFiles_StoresAll()
    {
        MultipartFormDataObject multipartFormDataObject = new();
        var fileFirst = CreateFile("first.pdf");
        var fileSecond = CreateFile("second.pdf");

        multipartFormDataObject.AddFile("first", fileFirst);
        multipartFormDataObject.AddFile("second", fileSecond);

        Assert.That(multipartFormDataObject.Files.Count, Is.EqualTo(2));
        Assert.That(multipartFormDataObject.Files["first"], Is.SameAs(fileFirst));
        Assert.That(multipartFormDataObject.Files["second"], Is.SameAs(fileSecond));
    }

    [TestCase]
    public void AddFile_WithDuplicateParameterName_ThrowsArgumentException()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        multipartFormDataObject.AddFile("file", CreateFile());

        var exception = Assert.Throws<ArgumentException>(
            () => multipartFormDataObject.AddFile("file", CreateFile()));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("Duplicate parameter name: file"));
    }

    [TestCase]
    public void AddFile_WithParameterNameAlreadyUsedByValue_ThrowsArgumentException()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        multipartFormDataObject.AddValue("key", "value");

        var exception = Assert.Throws<ArgumentException>(
            () => multipartFormDataObject.AddFile("key", CreateFile()));

        Assert.That(exception, Is.Not.Null);
        Assert.That(exception.Message, Does.Contain("Duplicate parameter name: key"));
    }

    [TestCase]
    public void Values_WhenModified_ThrowsNotSupportedException()
    {
        MultipartFormDataObject multipartFormDataObject = new();
        multipartFormDataObject.AddValue("key", "value");

        Assert.Throws<NotSupportedException>(() => multipartFormDataObject.Values.Add("other", "other"));
    }

    [TestCase]
    public void Files_WhenModified_ThrowsNotSupportedException()
    {
        MultipartFormDataObject multipartFormDataObject = new();
        multipartFormDataObject.AddFile("file", CreateFile());

        Assert.Throws<NotSupportedException>(() => multipartFormDataObject.Files.Add("other", CreateFile()));
    }

    [TestCase]
    public void Values_AfterAddingValues_ReflectsAllValues()
    {
        MultipartFormDataObject multipartFormDataObject = new();

        multipartFormDataObject.AddValue("firstName", "John");
        multipartFormDataObject.AddValue("lastName", "Doe");

        Assert.That(multipartFormDataObject.Values["firstName"], Is.EqualTo("John"));
        Assert.That(multipartFormDataObject.Values["lastName"], Is.EqualTo("Doe"));
    }
}
