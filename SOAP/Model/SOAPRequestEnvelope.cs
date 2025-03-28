using System.Xml.Serialization;
namespace SOAP.Model;
[XmlRoot("Envelope", Namespace = SOAPConstants.SOAP1_1Namespace)]
public partial class SOAPRequestEnvelope
{
    public SOAPHeader? Header { get; set; }

    public SOAPRequestBody? Body { get; set; }
}