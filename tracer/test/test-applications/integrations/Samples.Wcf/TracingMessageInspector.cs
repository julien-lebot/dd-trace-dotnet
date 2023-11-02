using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Samples.Wcf;

internal class TracingMessageInspector : IDispatchMessageInspector
{
    private readonly string _inspectorSource;

    public TracingMessageInspector(string inspectorSource)
    {
        _inspectorSource = inspectorSource;
    }

    /// <inheritdoc />
    public void BeforeSendReply(ref Message reply, object correlationState)
    {
        var span = SampleHelpers.GetActiveSpan();

        Console.WriteLine(
            span is null ?
                $"{_inspectorSource} BeforeSendReply called. Span is null." :
                $"{_inspectorSource} BeforeSendReply called. Span is not null.");
    }

    /// <inheritdoc />
    public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
    {
        var span = SampleHelpers.GetActiveSpan();

        Console.WriteLine(
            span is null ?
                $"{_inspectorSource} AfterReceiveRequest called. Span is null." :
                $"{_inspectorSource} AfterReceiveRequest called. Span is not null.");

        return default;
    }
}
