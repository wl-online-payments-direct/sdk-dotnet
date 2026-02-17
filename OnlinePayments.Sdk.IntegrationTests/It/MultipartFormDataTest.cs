using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;
using OnlinePayments.Sdk.Communication;
using OnlinePayments.Sdk.Domain;
using OnlinePayments.Sdk.Json;
using OnlinePayments.Sdk.Util;

namespace OnlinePayments.Sdk.It;

[TestFixture]
public class MultipartFormDataTest : IntegrationTest
{
    [TestCase]
    public async Task TestMultipartFormDataUploadPostMultipartFormDataObjectWithResponse()
    {
        await RunWithMockServer(async (communicator) =>
        {
            var multipart = CreateSampleMultipart();
            var response =
                await communicator.Post<MockHttpServer.HttpBinResponse>("/post", null, null, multipart, null);
            AssertHttpBinResponse(response);
        });
    }

    [TestCase]
    public async Task TestMultipartFormDataUploadPostIMultipartFormDataRequestWithResponse()
    {
        await RunWithMockServer(async (communicator) =>
        {
            var multipart = new MultipartFormDataObjectWrapper(CreateSampleMultipart());
            var response =
                await communicator.Post<MockHttpServer.HttpBinResponse>("/post", null, null, multipart, null);
            AssertHttpBinResponse(response);
        });
    }

    [TestCase]
    public async Task TestMultipartFormDataUploadPostMultipartFormDataObjectWithBodyHandler()
    {
        await RunWithMockServer(async (communicator) =>
        {
            var multipart = CreateSampleMultipart();
            await communicator.Post("/post", null, null, multipart, (stream, headers) =>
            {
                var response = DefaultMarshaller.Instance.Unmarshal<MockHttpServer.HttpBinResponse>(stream);
                AssertHttpBinResponse(response);
            }, null);
        });
    }

    [TestCase]
    public async Task TestMultipartFormDataUploadPostIMultipartFormDataRequestWithBodyHandler()
    {
        await RunWithMockServer(async (communicator) =>
        {
            var multipart = new MultipartFormDataObjectWrapper(CreateSampleMultipart());
            await communicator.Post("/post", null, null, multipart, (stream, headers) =>
            {
                var response = DefaultMarshaller.Instance.Unmarshal<MockHttpServer.HttpBinResponse>(stream);
                AssertHttpBinResponse(response);
            }, null);
        });
    }

    [TestCase]
    public async Task TestMultipartFormDataUploadPutMultipartFormDataObjectWithResponse()
    {
        await RunWithMockServer(async (communicator) =>
        {
            var multipart = CreateSampleMultipart();
            var response =
                await communicator.Put<MockHttpServer.HttpBinResponse>("/put", null, null, multipart, null);
            AssertHttpBinResponse(response);
        });
    }

    [TestCase]
    public async Task TestMultipartFormDataUploadPutIMultipartFormDataRequestWithResponse()
    {
        await RunWithMockServer(async (communicator) =>
        {
            var multipart = new MultipartFormDataObjectWrapper(CreateSampleMultipart());
            var response =
                await communicator.Put<MockHttpServer.HttpBinResponse>("/put", null, null, multipart, null);
            AssertHttpBinResponse(response);
        });
    }

    [TestCase]
    public async Task TestMultipartFormDataUploadPutMultipartFormDataObjectWithBodyHandler()
    {
        await RunWithMockServer(async (communicator) =>
        {
            var multipart = CreateSampleMultipart();
            await communicator.Put("/put", null, null, multipart, (stream, headers) =>
            {
                var response = DefaultMarshaller.Instance.Unmarshal<MockHttpServer.HttpBinResponse>(stream);
                AssertHttpBinResponse(response);
            }, null);
        });
    }

    [TestCase]
    public async Task TestMultipartFormDataUploadPutIMultipartFormDataRequestWithBodyHandler()
    {
        await RunWithMockServer(async (communicator) =>
        {
            var multipart = new MultipartFormDataObjectWrapper(CreateSampleMultipart());
            await communicator.Put("/put", null, null, multipart, (stream, headers) =>
            {
                var response = DefaultMarshaller.Instance.Unmarshal<MockHttpServer.HttpBinResponse>(stream);
                AssertHttpBinResponse(response);
            }, null);
        });
    }

    private MultipartFormDataObject CreateSampleMultipart()
    {
        var content = new MemoryStream();
        var writer = new StreamWriter(content);
        writer.Write("file-content");
        writer.Flush();
        content.Position = 0;

        var multipart = new MultipartFormDataObject();
        multipart.AddFile("file", new UploadableFile("file.txt", content, "text/plain"));
        multipart.AddValue("value", "Hello World");

        return multipart;
    }

    private void AssertHttpBinResponse(MockHttpServer.HttpBinResponse response)
    {
        Assert.NotNull(response.Form);
        Assert.AreEqual(1, response.Form.Count);
        Assert.IsTrue(response.Form.ContainsKey("value"));
        Assert.AreEqual("Hello World", response.Form["value"]);

        Assert.NotNull(response.Files);
        Assert.AreEqual(1, response.Files.Count);
        Assert.IsTrue(response.Files.ContainsKey("file"));
        Assert.AreEqual("file-content", response.Files["file"]);
    }

    private async Task RunWithMockServer(Func<ICommunicator, Task> testFunc)
    {
        var configuration = GetCommunicatorConfiguration();
        var apiEndpoint = configuration.ApiEndpoint;

        try
        {
            using var server = new MockHttpServer();
            configuration.ApiEndpoint = new Uri(server.Url);

            using var communicator = Factory.CreateCommunicator(configuration);
            await testFunc(communicator);
        }
        finally
        {
            configuration.ApiEndpoint = apiEndpoint;
        }
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
