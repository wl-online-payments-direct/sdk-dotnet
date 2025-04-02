using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Json;

namespace OnlinePayments.Sdk.It
{
    [TestFixture]
    public class MultipartFormDataTest : IntegrationTest
    {
        [TestCase]
        public async Task TestMultipartFormDataUploadPostMultipartFormDataObjectWithResponse()
        {
            var configuration = GetCommunicatorConfiguration();
            // changing the ApiEndpoint changes the underlying configuration section; restore it afterwards
            var apiEndpoint = configuration.ApiEndpoint;
            try
            {
                configuration.ApiEndpoint = new Uri(HttpBinUrl());

                using (var communicator = Factory.CreateCommunicator(configuration))
                {
                    var content = new MemoryStream();
                    var writer = new StreamWriter(content);
                    await writer.WriteAsync("file-content");
                    await writer.FlushAsync();
                    content.Position = 0;
                    var multipart = new MultipartFormDataObject();
                    multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
                    multipart.AddValue("value", "Hello World");

                    var response = await communicator.Post<HttpBinResponse>("/post", null, null, multipart, null);

                    Assert.NotNull(response.Form);
                    Assert.AreEqual(1, response.Form.Count);
                    Assert.IsTrue(response.Form.ContainsKey("value"));
                    Assert.AreEqual("Hello World", response.Form["value"]);

                    Assert.NotNull(response.Files);
                    Assert.AreEqual(1, response.Files.Count);
                    Assert.IsTrue(response.Files.ContainsKey("file"));
                    Assert.AreEqual("file-content", response.Files["file"]);
                }
            }
            finally
            {
                configuration.ApiEndpoint = apiEndpoint;
            }
        }

        [TestCase]
        public async Task TestMultipartFormDataUploadPostIMultipartFormDataRequestWithResponse()
        {
            var configuration = GetCommunicatorConfiguration();
            // changing the ApiEndpoint changes the underlying configuration section; restore it afterwards
            var apiEndpoint = configuration.ApiEndpoint;
            try
            {
                configuration.ApiEndpoint = new Uri(HttpBinUrl());

                using (var communicator = Factory.CreateCommunicator(configuration))
                {
                    var content = new MemoryStream();
                    var writer = new StreamWriter(content);
                    await writer.WriteAsync("file-content");
                    await writer.FlushAsync();
                    content.Position = 0;
                    var multipart = new MultipartFormDataObject();
                    multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
                    multipart.AddValue("value", "Hello World");

                    var response = await communicator.Post<HttpBinResponse>("/post", null, null, new MultipartFormDataObjectWrapper(multipart), null);

                    Assert.NotNull(response.Form);
                    Assert.AreEqual(1, response.Form.Count);
                    Assert.IsTrue(response.Form.ContainsKey("value"));
                    Assert.AreEqual("Hello World", response.Form["value"]);

                    Assert.NotNull(response.Files);
                    Assert.AreEqual(1, response.Files.Count);
                    Assert.IsTrue(response.Files.ContainsKey("file"));
                    Assert.AreEqual("file-content", response.Files["file"]);
                }
            }
            finally
            {
                configuration.ApiEndpoint = apiEndpoint;
            }
        }

        [TestCase]
        public async Task TestMultipartFormDataUploadPostMultipartFormDataObjectWithBodyHandler()
        {
            var configuration = GetCommunicatorConfiguration();
            // changing the ApiEndpoint changes the underlying configuration section; restore it afterwards
            var apiEndpoint = configuration.ApiEndpoint;
            try
            {
                configuration.ApiEndpoint = new Uri(HttpBinUrl());

                using (var communicator = Factory.CreateCommunicator(configuration))
                {
                    var content = new MemoryStream();
                    var writer = new StreamWriter(content);
                    await writer.WriteAsync("file-content");
                    await writer.FlushAsync();
                    content.Position = 0;
                    var multipart = new MultipartFormDataObject();
                    multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
                    multipart.AddValue("value", "Hello World");

                    await communicator.Post("/post", null, null, multipart, (stream, headers) => {
                        var response = DefaultMarshaller.Instance.Unmarshal<HttpBinResponse>(stream);

                        Assert.NotNull(response.Form);
                        Assert.AreEqual(1, response.Form.Count);
                        Assert.IsTrue(response.Form.ContainsKey("value"));
                        Assert.AreEqual("Hello World", response.Form["value"]);

                        Assert.NotNull(response.Files);
                        Assert.AreEqual(1, response.Files.Count);
                        Assert.IsTrue(response.Files.ContainsKey("file"));
                        Assert.AreEqual("file-content", response.Files["file"]);
                    }, null);
                }
            }
            finally
            {
                configuration.ApiEndpoint = apiEndpoint;
            }
        }

        [TestCase]
        public async Task TestMultipartFormDataUploadPostIMultipartFormDataRequestWithBodyHandler()
        {
            var configuration = GetCommunicatorConfiguration();
            // changing the ApiEndpoint changes the underlying configuration section; restore it afterwards
            var apiEndpoint = configuration.ApiEndpoint;
            try
            {
                configuration.ApiEndpoint = new Uri(HttpBinUrl());

                using (var communicator = Factory.CreateCommunicator(configuration))
                {
                    var content = new MemoryStream();
                    var writer = new StreamWriter(content);
                    await writer.WriteAsync("file-content");
                    await writer.FlushAsync();
                    content.Position = 0;
                    var multipart = new MultipartFormDataObject();
                    multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
                    multipart.AddValue("value", "Hello World");

                    await communicator.Post("/post", null, null, new MultipartFormDataObjectWrapper(multipart), (stream, headers) => {
                        var response = DefaultMarshaller.Instance.Unmarshal<HttpBinResponse>(stream);

                        Assert.NotNull(response.Form);
                        Assert.AreEqual(1, response.Form.Count);
                        Assert.IsTrue(response.Form.ContainsKey("value"));
                        Assert.AreEqual("Hello World", response.Form["value"]);

                        Assert.NotNull(response.Files);
                        Assert.AreEqual(1, response.Files.Count);
                        Assert.IsTrue(response.Files.ContainsKey("file"));
                        Assert.AreEqual("file-content", response.Files["file"]);
                    }, null);
                }
            }
            finally
            {
                configuration.ApiEndpoint = apiEndpoint;
            }
        }

        [TestCase]
        public async Task TestMultipartFormDataUploadPutMultipartFormDataObjectWithResponse()
        {
            var configuration = GetCommunicatorConfiguration();
            // changing the ApiEndpoint changes the underlying configuration section; restore it afterwards
            var apiEndpoint = configuration.ApiEndpoint;
            try
            {
                configuration.ApiEndpoint = new Uri(HttpBinUrl());

                using (var communicator = Factory.CreateCommunicator(configuration))
                {
                    var content = new MemoryStream();
                    var writer = new StreamWriter(content);
                    await writer.WriteAsync("file-content");
                    await writer.FlushAsync();
                    content.Position = 0;
                    var multipart = new MultipartFormDataObject();
                    multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
                    multipart.AddValue("value", "Hello World");

                    var response = await communicator.Put<HttpBinResponse>("/put", null, null, multipart, null);

                    Assert.NotNull(response.Form);
                    Assert.AreEqual(1, response.Form.Count);
                    Assert.IsTrue(response.Form.ContainsKey("value"));
                    Assert.AreEqual("Hello World", response.Form["value"]);

                    Assert.NotNull(response.Files);
                    Assert.AreEqual(1, response.Files.Count);
                    Assert.IsTrue(response.Files.ContainsKey("file"));
                    Assert.AreEqual("file-content", response.Files["file"]);
                }
            }
            finally
            {
                configuration.ApiEndpoint = apiEndpoint;
            }
        }

        [TestCase]
        public async Task TestMultipartFormDataUploadPutIMultipartFormDataRequestWithResponse()
        {
            var configuration = GetCommunicatorConfiguration();
            // changing the ApiEndpoint changes the underlying configuration section; restore it afterwards
            var apiEndpoint = configuration.ApiEndpoint;
            try
            {
                configuration.ApiEndpoint = new Uri(HttpBinUrl());

                using (var communicator = Factory.CreateCommunicator(configuration))
                {
                    var content = new MemoryStream();
                    var writer = new StreamWriter(content);
                    await writer.WriteAsync("file-content");
                    await writer.FlushAsync();
                    content.Position = 0;
                    var multipart = new MultipartFormDataObject();
                    multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
                    multipart.AddValue("value", "Hello World");

                    var response = await communicator.Put<HttpBinResponse>("/put", null, null, new MultipartFormDataObjectWrapper(multipart), null);

                    Assert.NotNull(response.Form);
                    Assert.AreEqual(1, response.Form.Count);
                    Assert.IsTrue(response.Form.ContainsKey("value"));
                    Assert.AreEqual("Hello World", response.Form["value"]);

                    Assert.NotNull(response.Files);
                    Assert.AreEqual(1, response.Files.Count);
                    Assert.IsTrue(response.Files.ContainsKey("file"));
                    Assert.AreEqual("file-content", response.Files["file"]);
                }
            }
            finally
            {
                configuration.ApiEndpoint = apiEndpoint;
            }
        }

        [TestCase]
        public async Task TestMultipartFormDataUploadPutMultipartFormDataObjectWithBodyHandler()
        {
            var configuration = GetCommunicatorConfiguration();
            // changing the ApiEndpoint changes the underlying configuration section; restore it afterwards
            var apiEndpoint = configuration.ApiEndpoint;
            try
            {
                configuration.ApiEndpoint = new Uri(HttpBinUrl());

                using (var communicator = Factory.CreateCommunicator(configuration))
                {
                    var content = new MemoryStream();
                    var writer = new StreamWriter(content);
                    await writer.WriteAsync("file-content");
                    await writer.FlushAsync();
                    content.Position = 0;
                    var multipart = new MultipartFormDataObject();
                    multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
                    multipart.AddValue("value", "Hello World");

                    await communicator.Put("/put", null, null, multipart, (stream, headers) => {
                        var response = DefaultMarshaller.Instance.Unmarshal<HttpBinResponse>(stream);

                        Assert.NotNull(response.Form);
                        Assert.AreEqual(1, response.Form.Count);
                        Assert.IsTrue(response.Form.ContainsKey("value"));
                        Assert.AreEqual("Hello World", response.Form["value"]);

                        Assert.NotNull(response.Files);
                        Assert.AreEqual(1, response.Files.Count);
                        Assert.IsTrue(response.Files.ContainsKey("file"));
                        Assert.AreEqual("file-content", response.Files["file"]);
                    }, null);
                }
            }
            finally
            {
                configuration.ApiEndpoint = apiEndpoint;
            }
        }

        [TestCase]
        public async Task TestMultipartFormDataUploadPutIMultipartFormDataRequestWithBodyHandler()
        {
            var configuration = GetCommunicatorConfiguration();
            // changing the ApiEndpoint changes the underlying configuration section; restore it afterwards
            var apiEndpoint = configuration.ApiEndpoint;
            try
            {
                configuration.ApiEndpoint = new Uri(HttpBinUrl());

                using (var communicator = Factory.CreateCommunicator(configuration))
                {
                    var content = new MemoryStream();
                    var writer = new StreamWriter(content);
                    await writer.WriteAsync("file-content");
                    await writer.FlushAsync();
                    content.Position = 0;
                    var multipart = new MultipartFormDataObject();
                    multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
                    multipart.AddValue("value", "Hello World");

                    await communicator.Put("/put", null, null, new MultipartFormDataObjectWrapper(multipart), (stream, headers) => {
                        var response = DefaultMarshaller.Instance.Unmarshal<HttpBinResponse>(stream);

                        Assert.NotNull(response.Form);
                        Assert.AreEqual(1, response.Form.Count);
                        Assert.IsTrue(response.Form.ContainsKey("value"));
                        Assert.AreEqual("Hello World", response.Form["value"]);

                        Assert.NotNull(response.Files);
                        Assert.AreEqual(1, response.Files.Count);
                        Assert.IsTrue(response.Files.ContainsKey("file"));
                        Assert.AreEqual("file-content", response.Files["file"]);
                    }, null);
                }
            }
            finally
            {
                configuration.ApiEndpoint = apiEndpoint;
            }
        }

        private static string HttpBinUrl()
        {
            return Environment.GetEnvironmentVariable("httpbin_url") ?? "http://httpbin.org";
        }

        sealed class HttpBinResponse
        {
            public Dictionary<string, string> Form { get; set; }
            public Dictionary<string, string> Files { get; set; }
        }

        private class MultipartFormDataObjectWrapper : IMultipartFormDataRequest
        {
            private readonly MultipartFormDataObject _multipart;

            public MultipartFormDataObjectWrapper(MultipartFormDataObject multipart)
            {
                _multipart = multipart;
            }

            public MultipartFormDataObject ToMultipartFormDataObject()
            {
                return _multipart;
            }
        }
    }
}
