using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
namespace SOAP.Model;

[XmlRoot("Envelope", Namespace = SOAPConstants.SOAP1_1Namespace)]
public partial class SOAPResponseEnvelope
{
    protected SOAPResponseBody? _body;

    public SOAPResponseBody? Body
    {
        get
        {
            if (_body is null)
                _body = new SOAPResponseBody();
            return _body;
        }
        set { _body = value; }
    }
}