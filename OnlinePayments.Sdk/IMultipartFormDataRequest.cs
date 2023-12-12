﻿using System;

namespace OnlinePayments.Sdk 
{
    /// <summary>
    /// A representation of a multipart/form-data request.
    /// </summary>
    public interface IMultipartFormDataRequest
    {
        MultipartFormDataObject ToMultipartFormDataObject();
    }

}
