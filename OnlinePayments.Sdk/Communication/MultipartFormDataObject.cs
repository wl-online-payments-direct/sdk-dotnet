using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.Communication
{
    /// <summary>
    /// A representation of a multipart/form-data object.
    /// </summary>
    public class MultipartFormDataObject
    {
        public MultipartFormDataObject()
        {
            Boundary = Guid.NewGuid().ToString();
            ContentType = "multipart/form-data; boundary=" + Boundary;
            _values = new Dictionary<string, string>();
            _files = new Dictionary<string, UploadableFile>();
        }

        public string Boundary { get; }

        public string ContentType { get; }

        public IDictionary<string, string> Values => _values.ToImmutableDictionary();

        public IDictionary<string, UploadableFile> Files => _files.ToImmutableDictionary();

        public void AddValue(string parameterName, string value)
        {
            if (string.IsNullOrWhiteSpace(parameterName))
            {
                throw new ArgumentException("Parameter name is required");
            }
            if (value == null)
            {
                throw new ArgumentException("value is required");
            }
            if (_values.ContainsKey(parameterName) || _files.ContainsKey(parameterName))
            {
                throw new ArgumentException("Duplicate parameter name: " + parameterName);
            }
            _values.Add(parameterName, value);
        }

        public void AddFile(string parameterName, UploadableFile file)
        {
            if (string.IsNullOrWhiteSpace(parameterName))
            {
                throw new ArgumentException("Parameter name is required");
            }
            if (file == null)
            {
                throw new ArgumentException("file is required");
            }
            if (_values.ContainsKey(parameterName) || _files.ContainsKey(parameterName))
            {
                throw new ArgumentException("Duplicate parameter name: " + parameterName);
            }
            _files.Add(parameterName, file);
        }

        private readonly IDictionary<string, string> _values;
        private readonly IDictionary<string, UploadableFile> _files;
    }
}
