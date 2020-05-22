using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Ingenico.Direct.Sdk
{
    /// <summary>
    /// A representation of a multipart/form-data object.
    /// </summary>
    public class MultipartFormDataObject
    {

        readonly IDictionary<string, string> _values;
        readonly IDictionary<string, UploadableFile> _files;

        public MultipartFormDataObject()
        {
            _values = new Dictionary<string, string>();
            _files = new Dictionary<string, UploadableFile>();
            Boundary = Guid.NewGuid().ToString();
            ContentType = "multipart/form-data; boundary=" + Boundary;
        }

        public IDictionary<string, string> Values => ImmutableDictionary.ToImmutableDictionary(_values);

        public IDictionary<string, UploadableFile> Files => ImmutableDictionary.ToImmutableDictionary(_files);

        public string Boundary { get; }

        public string ContentType { get; }

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
    }
}
