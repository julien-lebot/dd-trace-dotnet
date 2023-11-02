using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Samples.Wcf;

internal class TracingEndpointBehavior : IEndpointBehavior
{
    private static readonly TracingMessageInspector Inspector = new("TracingEndpointBehavior");

    /// <inheritdoc />
    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
    {
    }

    /// <inheritdoc />
    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
    }

    /// <inheritdoc />
    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    {
        endpointDispatcher.DispatchRuntime.MessageInspectors.Add(Inspector);
    }

    /// <inheritdoc />
    public void Validate(ServiceEndpoint endpoint)
    {
    }
}
