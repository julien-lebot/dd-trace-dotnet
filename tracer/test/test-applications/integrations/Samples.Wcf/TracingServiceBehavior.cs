using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Samples.Wcf;

internal class TracingServiceBehavior : IServiceBehavior
{
    private static readonly TracingMessageInspector Inspector = new("TracingServiceBehavior");

    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
    }

    public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
    {
    }

    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
        foreach (var channelDispatcherBase in serviceHostBase.ChannelDispatchers)
        {
            if (channelDispatcherBase is ChannelDispatcher channelDispatcher)
            {
                foreach (var endpointDispatcher in channelDispatcher.Endpoints)
                {
                    endpointDispatcher.DispatchRuntime.MessageInspectors.Add(Inspector);
                }
            }
        }
    }
}
