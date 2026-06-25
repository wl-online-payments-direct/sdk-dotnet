using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Json;
using OnlinePayments.Sdk.Util;

namespace OnlinePayments.Sdk.It;

[TestFixture]
public class MultipartFormDataTest : IntegrationTest
{
    [TestFixture]
    public class WhenPostingMultipartFormData
    {
        [TestFixture]
        public class WithMultipartFormDataObject
        {
            [TestFixture]
            public class WithSingleFileAndValue
            {
                [TestCase]
                public async Task Post_SingleFileAndValue_ReturnsResponse()
                {
                    await RunWithMockServer(async communicator =>
                    {
                        await using Stream content = CreateTestFileStream("file content");
                        MultipartFormDataObject multipart = new MultipartFormDataObject();

                        multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
                        multipart.AddValue("value", "Hello World");

                        var response =
                            await communicator.Post<MockHttpServer.HttpBinResponse>("/post",
                                null,
                                null,
                                multipart,
                                null);

                        Assert.That(response, Is.Not.Null);
                        Assert.That(response.Files, Is.Not.Null);
                        Assert.That(response.Files["file"], Is.EqualTo("file content"));
                        Assert.That(response.Form, Is.Not.Null);
                        Assert.That(response.Form["value"], Is.EqualTo("Hello World"));
                    });
                }

                [TestCase]
                public async Task Post_SingleFileAndValue_InvokesBodyHandler()
                {
                    await RunWithMockServer(async communicator =>
                    {
                        await using Stream content = CreateTestFileStream("file content");
                        MultipartFormDataObject multipart = new MultipartFormDataObject();

                        multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
                        multipart.AddValue("value", "Hello World");

                        await communicator.Post("/post",
                            null,
                            null,
                            multipart,
                            (stream,
                                _) =>
                            {
                                var response =
                                    DefaultMarshaller.Instance.Unmarshal<MockHttpServer.HttpBinResponse>(stream);

                            Assert.That(response, Is.Not.Null);
                            Assert.That(response.Files, Is.Not.Null);
                            Assert.That(response.Files.Count, Is.EqualTo(1));
                            Assert.That(response.Files["file"], Is.EqualTo("file content"));
                            Assert.That(response.Form, Is.Not.Null);
                            Assert.That(response.Form.Count, Is.EqualTo(1));
                            Assert.That(response.Form["value"], Is.EqualTo("Hello World"));
                        }, null);
                    });
                }
            }

            [TestFixture]
            public class WithMultipleFiles
            {
                [TestCase]
                public async Task Post_TwoFiles_ReturnsBothFilesInResponse()
                {
                    await RunWithMockServer(async communicator =>
                    {
                        await using Stream firstContent = CreateTestFileStream("firstContent");
                        await using Stream secondContent = CreateTestFileStream("secondContent");
                        MultipartFormDataObject multipart = new MultipartFormDataObject();

                        multipart.AddFile("firstFile", new UploadableFile("first.txt", firstContent, "text/plain"));
                        multipart.AddFile("secondFile",
                            new UploadableFile("second.txt", secondContent, "text/plain"));

                        var response =
                            await communicator.Post<MockHttpServer.HttpBinResponse>("/post",
                                null,
                                null,
                                multipart,
                                null);

                        Assert.That(response, Is.Not.Null);
                        Assert.That(response.Files, Is.Not.Null);
                        Assert.That(response.Files.Count, Is.EqualTo(2));
                        Assert.That(response.Files["firstFile"], Is.EqualTo("firstContent"));
                        Assert.That(response.Files["secondFile"], Is.EqualTo("secondContent"));
                    });
                }

                [TestCase]
                public async Task Post_ThreeFilesWithDifferentContentTypes_ReturnsAllFilesInResponse()
                {
                    await RunWithMockServer(async communicator =>
                    {
                        await using Stream textContent = CreateTestFileStream("text");
                        await using Stream jsonContent = CreateTestFileStream("json");
                        await using Stream xmlContent = CreateTestFileStream("xml");
                        MultipartFormDataObject multipart = new MultipartFormDataObject();

                        multipart.AddFile("textFile", new UploadableFile("file.txt", textContent, "text/plain"));
                        multipart.AddFile("jsonFile",
                            new UploadableFile("file.json", jsonContent, "application/json"));
                        multipart.AddFile("xmlFile",
                            new UploadableFile("file.xml", xmlContent, "application/xml"));

                        var response =
                            await communicator.Post<MockHttpServer.HttpBinResponse>("/post",
                                null,
                                null,
                                multipart,
                                null);

                        Assert.That(response, Is.Not.Null);
                        Assert.That(response.Files, Is.Not.Null);
                        Assert.That(response.Files.Count, Is.EqualTo(3));
                    });
                }
            }

            [TestFixture]
            public class WithMultipleValues
            {
                [TestCase]
                public async Task Post_TwoValues_ReturnsBothValuesInResponse()
                {
                    await RunWithMockServer(async communicator =>
                    {
                        MultipartFormDataObject multipart = new MultipartFormDataObject();
                        multipart.AddValue("firstKey", "firstValue");
                        multipart.AddValue("secondKey", "secondValue");

                        var response =
                            await communicator.Post<MockHttpServer.HttpBinResponse>("/post",
                                null,
                                null,
                                multipart,
                                null);

                        Assert.That(response, Is.Not.Null);
                        Assert.That(response.Form, Is.Not.Null);
                        Assert.That(response.Form.Count, Is.EqualTo(2));
                        Assert.That(response.Form["firstKey"], Is.EqualTo("firstValue"));
                        Assert.That(response.Form["secondKey"], Is.EqualTo("secondValue"));
                    });
                }

                [TestCase]
                public async Task Post_ThreeValues_ReturnsAllValuesInResponse()
                {
                    await RunWithMockServer(async communicator =>
                    {
                        MultipartFormDataObject multipart = new MultipartFormDataObject();
                        multipart.AddValue("name", "John");
                        multipart.AddValue("age", "30");
                        multipart.AddValue("city", "NYC");

                        var response =
                            await communicator.Post<MockHttpServer.HttpBinResponse>("/post",
                                null,
                                null,
                                multipart,
                                null);

                        Assert.That(response, Is.Not.Null);
                        Assert.That(response.Form, Is.Not.Null);
                        Assert.That(response.Form.Count, Is.EqualTo(3));
                    });
                }
            }

            [TestFixture]
            public class WithFilesOnly
            {
                [TestCase]
                public async Task Post_SingleFileWithoutValues_ReturnsFileInResponse()
                {
                    await RunWithMockServer(async communicator =>
                    {
                        await using Stream content = CreateTestFileStream("doc content");
                        MultipartFormDataObject multipart = new MultipartFormDataObject();

                        multipart.AddFile("document", new UploadableFile("doc.pdf", content, "application/pdf"));

                        var response =
                            await communicator.Post<MockHttpServer.HttpBinResponse>("/post",
                                null,
                                null,
                                multipart,
                                null);

                        Assert.That(response, Is.Not.Null);
                        Assert.That(response.Files, Is.Not.Null);
                        Assert.That(response.Files["document"], Is.EqualTo("doc content"));
                    });
                }
            }

            [TestFixture]
            public class WithValuesOnly
            {
                [TestCase]
                public async Task Post_SingleValueWithoutFiles_ReturnsValueInResponse()
                {
                    await RunWithMockServer(async communicator =>
                    {
                        MultipartFormDataObject multipart = new MultipartFormDataObject();
                        multipart.AddValue("message", "Hello");

                        var response =
                            await communicator.Post<MockHttpServer.HttpBinResponse>("/post",
                                null,
                                null,
                                multipart,
                                null);

                        Assert.That(response, Is.Not.Null);
                        Assert.That(response.Form, Is.Not.Null);
                        Assert.That(response.Form["message"], Is.EqualTo("Hello"));
                    });
                }
            }

            [TestFixture]
            public class WithDifferentContentTypes
            {
                [TestCase]
                public async Task Post_PdfFile_ReturnsSuccessResponse()
                {
                    await RunWithMockServer(async communicator =>
                    {
                        await using Stream content = CreateTestFileStream("pdf content");
                        MultipartFormDataObject multipart = new MultipartFormDataObject();

                        multipart.AddFile("pdf", new UploadableFile("document.pdf", content, "application/pdf"));

                        var response =
                            await communicator.Post<MockHttpServer.HttpBinResponse>("/post",
                                null,
                                null,
                                multipart,
                                null);

                        Assert.That(response, Is.Not.Null);
                    });
                }

                [TestCase]
                public async Task Post_ImageFile_ReturnsSuccessResponse()
                {
                    await RunWithMockServer(async communicator =>
                    {
                        await using Stream content = CreateTestFileStream("image content");
                        MultipartFormDataObject multipart = new MultipartFormDataObject();

                        multipart.AddFile("image", new UploadableFile("photo.jpg", content, "image/jpeg"));

                        var response =
                            await communicator.Post<MockHttpServer.HttpBinResponse>("/post",
                                null,
                                null,
                                multipart,
                                null);

                        Assert.That(response, Is.Not.Null);
                    });
                }

                [TestCase]
                public async Task Post_JsonFile_ReturnsSuccessResponse()
                {
                    await RunWithMockServer(async communicator =>
                    {
                        await using Stream content = CreateTestFileStream("json content");
                        MultipartFormDataObject multipart = new MultipartFormDataObject();

                        multipart.AddFile("data", new UploadableFile("data.json", content, "application/json"));

                        var response =
                            await communicator.Post<MockHttpServer.HttpBinResponse>("/post",
                                null,
                                null,
                                multipart,
                                null);

                        Assert.That(response, Is.Not.Null);
                    });
                }
            }

            [TestFixture]
            public class WithContentLength
            {
                [TestCase]
                public async Task Post_FileWithKnownContentLength_ReturnsSuccessResponse()
                {
                    await RunWithMockServer(async communicator =>
                    {
                        await using Stream content = CreateTestFileStream("content");
                        MultipartFormDataObject multipart = new MultipartFormDataObject();

                        multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain", 7));

                        var response =
                            await communicator.Post<MockHttpServer.HttpBinResponse>("/post",
                                null,
                                null,
                                multipart,
                                null);

                        Assert.That(response, Is.Not.Null);
                    });
                }

                [TestCase]
                public async Task Post_FileWithUnknownContentLength_ReturnsSuccessResponse()
                {
                    await RunWithMockServer(async communicator =>
                    {
                        await using Stream content = CreateTestFileStream("content");
                        MultipartFormDataObject multipart = new MultipartFormDataObject();

                        multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));

                        var response =
                            await communicator.Post<MockHttpServer.HttpBinResponse>("/post",
                                null,
                                null,
                                multipart,
                                null);

                        Assert.That(response, Is.Not.Null);
                    });
                }
            }
        }

        [TestFixture]
        public class WithMultipartFormDataRequest
        {
            [TestCase]
            public async Task Post_MultipartFormDataRequest_ReturnsResponse()
            {
                await RunWithMockServer(async communicator =>
                {
                    MultipartFormDataObjectWrapper multipart = new MultipartFormDataObjectWrapper(CreateSampleMultipart());

                    var response =
                        await communicator.Post<MockHttpServer.HttpBinResponse>("/post",
                            null,
                            null,
                            multipart,
                            null);

                    Assert.That(response, Is.Not.Null);
                    Assert.That(response.Files, Is.Not.Null);
                    Assert.That(response.Files.Count, Is.EqualTo(1));
                    Assert.That(response.Files["file"], Is.EqualTo("file content"));
                    Assert.That(response.Form, Is.Not.Null);
                    Assert.That(response.Form.Count, Is.EqualTo(1));
                    Assert.That(response.Form["value"], Is.EqualTo("Hello World"));
                });
            }

            [TestCase]
            public async Task Post_MultipartFormDataRequest_InvokesBodyHandler()
            {
                await RunWithMockServer(async communicator =>
                {
                    MultipartFormDataObjectWrapper multipart = new MultipartFormDataObjectWrapper(CreateSampleMultipart());

                    await communicator.Post("/post", null, null, multipart, (stream, _) =>
                    {
                        var response =
                            DefaultMarshaller.Instance.Unmarshal<MockHttpServer.HttpBinResponse>(stream);

                        Assert.That(response, Is.Not.Null);
                        Assert.That(response.Files, Is.Not.Null);
                        Assert.That(response.Files.Count, Is.EqualTo(1));
                        Assert.That(response.Files["file"], Is.EqualTo("file content"));
                        Assert.That(response.Form, Is.Not.Null);
                        Assert.That(response.Form.Count, Is.EqualTo(1));
                        Assert.That(response.Form["value"], Is.EqualTo("Hello World"));
                    }, null);
                });
            }
        }
    }

    [TestFixture]
    public class WhenPuttingMultipartFormData
    {
        [TestFixture]
        public class WithMultipartFormDataObject
        {
            [TestCase]
            public async Task Put_SingleFileAndValue_ReturnsResponse()
            {
                await RunWithMockServer(async communicator =>
                {
                    await using Stream content = CreateTestFileStream("file content");
                    MultipartFormDataObject multipart = new MultipartFormDataObject();

                    multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
                    multipart.AddValue("value", "Hello World");

                    var response =
                        await communicator.Put<MockHttpServer.HttpBinResponse>("/put",
                            null,
                            null,
                            multipart,
                            null);

                    Assert.That(response, Is.Not.Null);
                    Assert.That(response.Files, Is.Not.Null);
                    Assert.That(response.Files.Count, Is.EqualTo(1));
                    Assert.That(response.Files["file"], Is.EqualTo("file content"));
                    Assert.That(response.Form, Is.Not.Null);
                    Assert.That(response.Form.Count, Is.EqualTo(1));
                    Assert.That(response.Form["value"], Is.EqualTo("Hello World"));
                });
            }

            [TestCase]
            public async Task Put_SingleFileAndValue_InvokesBodyHandler()
            {
                await RunWithMockServer(async communicator =>
                {
                    await using Stream content = CreateTestFileStream("file content");
                    MultipartFormDataObject multipart = new MultipartFormDataObject();

                    multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
                    multipart.AddValue("value", "Hello World");

                    await communicator.Put("/put", null, null, multipart, (stream, _) =>
                    {
                        var response =
                            DefaultMarshaller.Instance.Unmarshal<MockHttpServer.HttpBinResponse>(stream);

                        Assert.That(response, Is.Not.Null);
                        Assert.That(response.Files, Is.Not.Null);
                        Assert.That(response.Files.Count, Is.EqualTo(1));
                        Assert.That(response.Files["file"], Is.EqualTo("file content"));
                        Assert.That(response.Form, Is.Not.Null);
                        Assert.That(response.Form.Count, Is.EqualTo(1));
                        Assert.That(response.Form["value"], Is.EqualTo("Hello World"));
                    }, null);
                });
            }
        }

        [TestFixture]
        public class WithMultipartFormDataRequest
        {
            [TestCase]
            public async Task Put_MultipartFormDataRequest_ReturnsResponse()
            {
                await RunWithMockServer(async communicator =>
                {
                    MultipartFormDataObjectWrapper multipart = new MultipartFormDataObjectWrapper(CreateSampleMultipart());

                    var response =
                        await communicator.Put<MockHttpServer.HttpBinResponse>("/put",
                            null,
                            null,
                            multipart,
                            null);

                    Assert.That(response, Is.Not.Null);
                    Assert.That(response.Files, Is.Not.Null);
                    Assert.That(response.Files.Count, Is.EqualTo(1));
                    Assert.That(response.Files["file"], Is.EqualTo("file content"));
                    Assert.That(response.Form, Is.Not.Null);
                    Assert.That(response.Form.Count, Is.EqualTo(1));
                    Assert.That(response.Form["value"], Is.EqualTo("Hello World"));
                });
            }

            [TestCase]
            public async Task Put_MultipartFormDataRequest_InvokesBodyHandler()
            {
                await RunWithMockServer(async communicator =>
                {
                    MultipartFormDataObjectWrapper multipart = new MultipartFormDataObjectWrapper(CreateSampleMultipart());

                    await communicator.Put("/put", null, null, multipart, (stream, _) =>
                    {
                        var response =
                            DefaultMarshaller.Instance.Unmarshal<MockHttpServer.HttpBinResponse>(stream);

                        Assert.That(response, Is.Not.Null);
                        Assert.That(response.Files, Is.Not.Null);
                        Assert.That(response.Files.Count, Is.EqualTo(1));
                        Assert.That(response.Files["file"], Is.EqualTo("file content"));
                        Assert.That(response.Form, Is.Not.Null);
                        Assert.That(response.Form.Count, Is.EqualTo(1));
                        Assert.That(response.Form["value"], Is.EqualTo("Hello World"));
                    }, null);
                });
            }
        }
    }

    [TestFixture]
    public class WhenAddingFiles
    {
        [TestFixture]
        public class WithValidFile
        {
            [TestCase]
            public void AddFile_FileWithKnownContentLength_StoresFileCorrectly()
            {
                using Stream content = CreateTestFileStream("content");
                UploadableFile file = new UploadableFile("file.txt", content, "text/plain", 7);
                MultipartFormDataObject multipart = new MultipartFormDataObject();

                multipart.AddFile("document", file);

                Assert.That(multipart.Files.Count, Is.EqualTo(1));
                Assert.That(multipart.Files.ContainsKey("document"), Is.True);
                Assert.That(multipart.Files["document"], Is.SameAs(file));
            }

            [TestCase]
            public void AddFile_FileWithUnknownContentLength_StoresFileWithMinusOneLength()
            {
                using Stream content = CreateTestFileStream("content");
                UploadableFile file = new UploadableFile("file.txt", content, "text/plain");
                MultipartFormDataObject multipart = new MultipartFormDataObject();

                multipart.AddFile("document", file);

                Assert.That(multipart.Files.Count, Is.EqualTo(1));
                Assert.That(multipart.Files["document"].ContentLength, Is.EqualTo(-1));
            }
        }

        [TestFixture]
        public class WithInvalidFile
        {
            [TestCase]
            public void AddFile_NullFile_ThrowsArgumentException()
            {
                MultipartFormDataObject multipart = new MultipartFormDataObject();

                ArgumentException ex = Assert.Throws<ArgumentException>(() => multipart.AddFile("file", null));

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("file is required"));
            }

            [TestCase]
            public void AddFile_NullParameterName_ThrowsArgumentException()
            {
                using Stream content = CreateTestFileStream("content");
                UploadableFile file = new UploadableFile("file.txt", content, "text/plain");
                MultipartFormDataObject multipart = new MultipartFormDataObject();

                ArgumentException ex = Assert.Throws<ArgumentException>(() => multipart.AddFile(null, file));

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("Parameter name is required"));
            }

            [TestCase]
            public void AddFile_EmptyParameterName_ThrowsArgumentException()
            {
                using Stream content = CreateTestFileStream("content");
                UploadableFile file = new UploadableFile("file.txt", content, "text/plain");
                MultipartFormDataObject multipart = new MultipartFormDataObject();

                ArgumentException ex = Assert.Throws<ArgumentException>(() => multipart.AddFile("", file));

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("Parameter name is required"));
            }

            [TestCase]
            public void AddFile_DuplicateParameterNameAlreadyUsedByFile_ThrowsArgumentException()
            {
                using Stream firstContent = CreateTestFileStream("firstContent");
                using Stream secondContent = CreateTestFileStream("secondContent");

                UploadableFile firstFile = new UploadableFile("first.txt", firstContent, "text/plain");
                UploadableFile secondFile = new UploadableFile("second.txt", secondContent, "text/plain");

                MultipartFormDataObject multipart = new MultipartFormDataObject();
                multipart.AddFile("document", firstFile);

                ArgumentException ex = Assert.Throws<ArgumentException>(() => multipart.AddFile("document", secondFile));

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("Duplicate parameter name: document"));
            }

            [TestCase]
            public void AddFile_DuplicateParameterNameAlreadyUsedByValue_ThrowsArgumentException()
            {
                using Stream content = CreateTestFileStream("content");

                UploadableFile file = new UploadableFile("file.txt", content, "text/plain");

                MultipartFormDataObject multipart = new MultipartFormDataObject();
                multipart.AddValue("field", "value");

                ArgumentException ex = Assert.Throws<ArgumentException>(() => multipart.AddFile("field", file));

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("Duplicate parameter name: field"));
            }
        }
    }

    [TestFixture]
    public class WhenAddingValues
    {
        [TestFixture]
        public class WithValidValue
        {
            [TestCase]
            public void AddValue_SingleValue_StoresValueCorrectly()
            {
                MultipartFormDataObject multipart = new MultipartFormDataObject();

                multipart.AddValue("key", "value");

                Assert.That(multipart.Values.Count, Is.EqualTo(1));
                Assert.That(multipart.Values.ContainsKey("key"), Is.True);
                Assert.That(multipart.Values["key"], Is.EqualTo("value"));
            }

            [TestCase]
            public void AddValue_MultipleValues_StoresAllValuesCorrectly()
            {
                MultipartFormDataObject multipart = new MultipartFormDataObject();

                multipart.AddValue("firstKey", "firstValue");
                multipart.AddValue("secondKey", "secondValue");
                multipart.AddValue("thirdKey", "thirdValue");

                Assert.That(multipart.Values.Count, Is.EqualTo(3));
                Assert.That(multipart.Values["firstKey"], Is.EqualTo("firstValue"));
                Assert.That(multipart.Values["secondKey"], Is.EqualTo("secondValue"));
                Assert.That(multipart.Values["thirdKey"], Is.EqualTo("thirdValue"));
            }
        }

        [TestFixture]
        public class WithInvalidValue
        {
            [TestCase]
            public void AddValue_NullValue_ThrowsArgumentException()
            {
                MultipartFormDataObject multipart = new MultipartFormDataObject();

                ArgumentException ex = Assert.Throws<ArgumentException>(() => multipart.AddValue("key", null));

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("value is required"));
            }

            [TestCase]
            public void AddValue_NullParameterName_ThrowsArgumentException()
            {
                MultipartFormDataObject multipart = new MultipartFormDataObject();

                ArgumentException ex = Assert.Throws<ArgumentException>(() => multipart.AddValue(null, "value"));

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("Parameter name is required"));
            }

            [TestCase]
            public void AddValue_EmptyParameterName_ThrowsArgumentException()
            {
                MultipartFormDataObject multipart = new MultipartFormDataObject();

                ArgumentException ex = Assert.Throws<ArgumentException>(() => multipart.AddValue("", "value"));

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("Parameter name is required"));
            }

            [TestCase]
            public void AddValue_DuplicateParameterNameAlreadyUsedByValue_ThrowsArgumentException()
            {
                MultipartFormDataObject multipart = new MultipartFormDataObject();
                multipart.AddValue("key", "value1");

                ArgumentException ex = Assert.Throws<ArgumentException>(() => multipart.AddValue("key", "value2"));

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("Duplicate parameter name: key"));
            }

            [TestCase]
            public void AddValue_DuplicateParameterNameAlreadyUsedByFile_ThrowsArgumentException()
            {
                using Stream content = CreateTestFileStream("content");

                UploadableFile file = new UploadableFile("file.txt", content, "text/plain");

                MultipartFormDataObject multipart = new MultipartFormDataObject();
                multipart.AddFile("field", file);

                ArgumentException ex = Assert.Throws<ArgumentException>(() => multipart.AddValue("field", "value"));

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("Duplicate parameter name: field"));
            }
        }
    }

    [TestFixture]
    public class WhenVerifyingBoundaryAndContentType
    {
        [TestCase]
        public void GetBoundary_TwoSeparateInstances_ReturnsDifferentBoundaries()
        {
            MultipartFormDataObject multipartFirst = new MultipartFormDataObject();
            MultipartFormDataObject multipartSecond = new MultipartFormDataObject();

            string boundaryFirst = multipartFirst.Boundary;
            string boundarySecond = multipartSecond.Boundary;

            Assert.That(boundaryFirst, Is.Not.Null);
            Assert.That(boundarySecond, Is.Not.Null);
            Assert.That(boundaryFirst, Is.Not.EqualTo(boundarySecond), "Boundaries should be unique");
        }

        [TestCase]
        public void GetContentType_NewInstance_ContainsBoundaryValue()
        {
            MultipartFormDataObject multipart = new MultipartFormDataObject();

            string contentType = multipart.ContentType;
            string boundary = multipart.Boundary;

            Assert.That(contentType, Does.Contain(boundary));
            Assert.That(contentType, Does.StartWith("multipart/form-data; boundary="));
        }

        [TestCase]
        public void GetContentType_NewInstance_StartsWithMultipartFormData()
        {
            MultipartFormDataObject multipart = new MultipartFormDataObject();

            string contentType = multipart.ContentType;

            Assert.That(contentType, Does.StartWith("multipart/form-data"));
            Assert.That(contentType, Does.Contain("boundary="));
        }
    }

    [TestFixture]
    public class WhenCreatingUploadableFile
    {
        [TestFixture]
        public class WithValidInput
        {
            [TestCase]
            public void NewUploadableFile_WithKnownContentLength_SetsAllPropertiesCorrectly()
            {
                using Stream content = CreateTestFileStream("test content");

                UploadableFile file = new UploadableFile("test.txt", content, "text/plain", 12);

                Assert.That(file.FileName, Is.EqualTo("test.txt"));
                Assert.That(file.ContentType, Is.EqualTo("text/plain"));
                Assert.That(file.ContentLength, Is.EqualTo(12));
                Assert.That(file.Content, Is.Not.Null);
            }

            [TestCase]
            public void NewUploadableFile_WithoutContentLength_SetsContentLengthToMinusOne()
            {
                using Stream content = CreateTestFileStream("test content");

                UploadableFile file = new UploadableFile("test.txt", content, "text/plain");

                Assert.That(file.FileName, Is.EqualTo("test.txt"));
                Assert.That(file.ContentType, Is.EqualTo("text/plain"));
                Assert.That(file.ContentLength, Is.EqualTo(-1));
                Assert.That(file.Content, Is.Not.Null);
            }

            [TestCase]
            public void NewUploadableFile_WithNegativeContentLength_NormalizesContentLengthToMinusOne()
            {
                using Stream content = CreateTestFileStream("content");

                UploadableFile file = new UploadableFile("file.txt", content, "text/plain", -100);

                Assert.That(file.ContentLength, Is.EqualTo(-1));
            }
        }

        [TestFixture]
        public class WithInvalidInput
        {
            [TestCase]
            public void NewUploadableFile_NullFileName_ThrowsArgumentException()
            {
                using Stream content = CreateTestFileStream("content");

                ArgumentException ex = Assert.Throws<ArgumentException>(
                    () =>
                    {
                        _ = new UploadableFile(null, content, "text/plain");
                    });

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("File Name is required"));
            }

            [TestCase]
            public void NewUploadableFile_EmptyFileName_ThrowsArgumentException()
            {
                using Stream content = CreateTestFileStream("content");

                ArgumentException ex = Assert.Throws<ArgumentException>(
                    () =>
                    {
                        _ = new UploadableFile("", content, "text/plain");
                    });

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("File Name is required"));
            }

            [TestCase]
            public void NewUploadableFile_NullContent_ThrowsArgumentException()
            {
                ArgumentException ex = Assert.Throws<ArgumentException>(
                    () =>
                    {
                        _ = new UploadableFile("file.txt", null, "text/plain");
                    });

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("Content is required"));
            }

            [TestCase]
            public void NewUploadableFile_NullContentType_ThrowsArgumentException()
            {
                using Stream content = CreateTestFileStream("content");

                ArgumentException ex = Assert.Throws<ArgumentException>(
                    () =>
                    {
                        _ = new UploadableFile("file.txt", content, null);
                    });

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("Content Type is required"));
            }

            [TestCase]
            public void NewUploadableFile_EmptyContentType_ThrowsArgumentException()
            {
                using Stream content = CreateTestFileStream("content");

                ArgumentException ex = Assert.Throws<ArgumentException>(
                    () =>
                    {
                        _ = new UploadableFile("file.txt", content, "");
                    });

                Assert.That(ex, Is.Not.Null);
                Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
                Assert.That(ex.Message, Does.Contain("Content Type is required"));
            }
        }
    }

    private static Stream CreateTestFileStream(string content)
        => new MemoryStream(Encoding.UTF8.GetBytes(content));

    private static MultipartFormDataObject CreateSampleMultipart()
    {
        Stream content = CreateTestFileStream("file content");
        MultipartFormDataObject multipart = new MultipartFormDataObject();

        multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
        multipart.AddValue("value", "Hello World");

        return multipart;
    }

    private static async Task RunWithMockServer(Func<ICommunicator, Task> testFunc)
    {
        CommunicatorConfiguration configuration = Factory.CreateConfiguration("some-api-id", "some-secret-key");
        Uri originalEndpoint = configuration.ApiEndpoint;

        try
        {
            using MockHttpServer server = new MockHttpServer();
            configuration.ApiEndpoint = new Uri(server.Url);

            using ICommunicator communicator = Factory.CreateCommunicator(configuration);
            await testFunc(communicator);
        }
        finally
        {
            configuration.ApiEndpoint = originalEndpoint;
        }
    }

    private class MultipartFormDataObjectWrapper(MultipartFormDataObject multipart) : IMultipartFormDataRequest
    {
        public MultipartFormDataObject ToMultipartFormDataObject() => multipart;
    }
}
