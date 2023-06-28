// <copyright file="GrpcTags.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System.Collections.Generic;
using Datadog.Trace.Configuration;
using Datadog.Trace.SourceGenerators;

namespace Datadog.Trace.Tagging
{
#pragma warning disable SA1402 // File must contain single type
    internal abstract partial class GrpcTags : InstrumentationTags
    {
        public GrpcTags(string spanKind)
        {
            SpanKind = spanKind;
        }

        [Tag(Trace.Tags.SpanKind)]
        public override string SpanKind { get; }

        [Tag(Trace.Tags.InstrumentationName)]
        public string InstrumentationName => nameof(IntegrationId.Grpc);

        [Tag(Trace.Tags.GrpcMethodKind)]
        public string MethodKind { get; set; }

        [Tag(Trace.Tags.GrpcMethodName)]
        public string MethodName { get; set; }

        [Tag(Trace.Tags.GrpcMethodPath)]
        public string MethodPath { get; set; }

        [Tag(Trace.Tags.GrpcMethodPackage)]
        public string MethodPackage { get; set; }

        [Tag(Trace.Tags.GrpcMethodService)]
        public string MethodService { get; set; }

        [Tag(Trace.Tags.GrpcStatusCode)]
        public string StatusCode { get; set; }
    }

    internal partial class GrpcServerTags : GrpcTags
    {
        public GrpcServerTags()
            : base(SpanKinds.Server)
        {
        }
    }

    internal partial class GrpcClientTags : GrpcTags
    {
        public GrpcClientTags()
            : base(SpanKinds.Client)
        {
        }

        [Tag(Trace.Tags.OutHost)]
        public string Host { get; set; }
    }

    internal partial class GrpcClientV1Tags : GrpcClientTags
    {
        public GrpcClientV1Tags(IDictionary<string, string> peerServiceMappings)
            : base()
        {
            PeerServiceMappings = peerServiceMappings;
        }

        public override string CalculatePeerService() => MethodService ?? Host;

        public override string CalculatePeerServiceSource() =>
            MethodService is not null
                ? "rpc.service"
                : "network.destination.name";
    }
}
