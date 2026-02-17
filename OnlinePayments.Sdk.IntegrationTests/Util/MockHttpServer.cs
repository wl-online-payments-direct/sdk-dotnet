using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePayments.Sdk.Util;

/// <summary>
/// Simple in-process HTTP server for testing multipart requests.
/// </summary>
public sealed class MockHttpServer : IDisposable
{
    private readonly HttpListener listener;
    private readonly int port;

    public string Url => $"http://localhost:{port}";

    public MockHttpServer()
    {
        listener = new HttpListener();
        port = GetFreePort();
        listener.Prefixes.Add($"http://localhost:{port}/");
        listener.Start();
        StartListening();
    }

    private void StartListening()
    {
        listener.BeginGetContext(async void (result) =>
        {
            try
            {
                var ctx = listener.EndGetContext(result);
                // continue listening
                StartListening();

                if (ctx.Request.HttpMethod != "POST" && ctx.Request.HttpMethod != "PUT")
                {
                    ctx.Response.StatusCode = 200;
                    ctx.Response.Close();
                    return;
                }

                var boundary = GetBoundary(ctx.Request.ContentType);
                if (string.IsNullOrEmpty(boundary))
                {
                    ctx.Response.StatusCode = 400;
                    ctx.Response.Close();
                    return;
                }

                var formFields = new Dictionary<string, string>();
                var files = new Dictionary<string, string>();

                await ParseMultipart(ctx.Request.InputStream, boundary, formFields, files);

                var responseObj = new HttpBinResponse
                {
                    Form = formFields,
                    Files = files
                };

                var responseJson = OnlinePayments.Sdk.Json.DefaultMarshaller.Instance.Marshal(responseObj);

                ctx.Response.ContentType = "application/json";
                ctx.Response.StatusCode = 200;
                var buffer = Encoding.UTF8.GetBytes(responseJson);
                await ctx.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                ctx.Response.Close();
            }
            catch
            {
                // ignore exceptions in mock server
            }
        }, null);
    }

    private static async Task ParseMultipart(Stream inputStream, string boundary,
        Dictionary<string, string> formFields, Dictionary<string, string> files)
    {
        var boundaryBytes = Encoding.UTF8.GetBytes("--" + boundary);
        var endBoundaryBytes = Encoding.UTF8.GetBytes("--" + boundary + "--");

        using var reader = new StreamReader(inputStream);
        string line;
        string currentName = null;
        StringBuilder fileContent = null;
        bool readingFile = false;

        while ((line = await reader.ReadLineAsync()) != null)
        {
            var lineBytes = Encoding.UTF8.GetBytes(line);
            if (lineBytes.SequenceEqual(boundaryBytes) || lineBytes.SequenceEqual(endBoundaryBytes))
            {
                if (readingFile && currentName != null)
                {
                    // trim only once here to remove any trailing CR/LF
                    files[currentName] = fileContent.ToString().TrimEnd('\r', '\n');
                }

                readingFile = false;
                currentName = null;
                fileContent = null;
                continue;
            }

            if (line.StartsWith("Content-Disposition:", StringComparison.OrdinalIgnoreCase))
            {
                var parts = line.Split(';');
                foreach (var part in parts)
                {
                    var trimmed = part.Trim();
                    if (trimmed.StartsWith("name=", StringComparison.OrdinalIgnoreCase))
                    {
                        currentName = trimmed.Substring("name=".Length).Trim('"');
                    }
                    else if (trimmed.StartsWith("filename=", StringComparison.OrdinalIgnoreCase))
                    {
                        trimmed.Substring("filename=".Length).Trim('"');
                        readingFile = true;
                        fileContent = new StringBuilder();
                    }
                }

                continue;
            }

            // skip empty line after headers
            if (string.IsNullOrWhiteSpace(line))
                continue;

            if (readingFile)
            {
                // Append directly, don't add extra line endings
                fileContent.Append(line);
            }
            else if (currentName != null)
            {
                formFields[currentName] = line;
            }
        }
    }

    private static string GetBoundary(string contentType)
    {
        if (string.IsNullOrEmpty(contentType))
            return null;

        var elements = contentType.Split(';');
        foreach (var element in elements)
        {
            var trimmed = element.Trim();
            if (trimmed.StartsWith("boundary=", StringComparison.OrdinalIgnoreCase))
            {
                return trimmed.Substring("boundary=".Length);
            }
        }

        return null;
    }

    private static int GetFreePort()
    {
        var listener = new TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        var port = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();
        return port;
    }

    public void Dispose()
    {
        try
        {
            listener?.Stop();
        }
        catch
        {
            // ignore
        }
    }

    public sealed class HttpBinResponse
    {
        public Dictionary<string, string> Form { get; set; }
        public Dictionary<string, string> Files { get; set; }
    }
}
