using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Ingenico.Direct.Sdk
{
    /// <summary>
    /// A representation of a multipart/form-data request.
    /// </summary>
    public interface IMultipartFormDataRequest
    {
        MultipartFormDataObject ToMultipartFormDataObject();
    }
}
