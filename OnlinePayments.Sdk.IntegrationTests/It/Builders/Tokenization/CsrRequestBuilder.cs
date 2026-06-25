using OnlinePayments.Sdk.Domain;

namespace OnlinePayments.Sdk.It.Builders.Tokenization;

public class CsrRequestBuilder
{
    private const string ValidCsr =
        "-----BEGIN CERTIFICATE REQUEST-----\\nMIIBVTCBvwIBADBZMQswCQYDVQQGEwJVUzELMAkGA1UECAwCQ0ExEDAOBgNVBAcM\\nB1NhbiBKb3NlMQ8wDQYDVQQKDAZFeGFtcGxlMQ8wDQYDVQQLDAZFeGFtcGxlMQ8w\\nDQYDVQQDDAZFeGFtcGxlMFwwDQYJKoZIhvcNAQEBBQADSwAwSAJBALe4...\\n-----END CERTIFICATE REQUEST-----\\n";

    private string _csr = ValidCsr;

    #region Setters

    public CsrRequestBuilder WithCsr(string csr)
    {
        _csr = csr;
        return this;
    }

    #endregion

    public CsrRequest Build() => new()
    {
        Csr = _csr
    };
}
