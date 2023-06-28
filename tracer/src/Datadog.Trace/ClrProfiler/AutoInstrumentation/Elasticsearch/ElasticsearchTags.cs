// <copyright file="ElasticsearchTags.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System.Collections.Generic;
using Datadog.Trace.SourceGenerators;
using Datadog.Trace.Tagging;

#pragma warning disable SA1402 // File must contain single type
namespace Datadog.Trace.ClrProfiler.AutoInstrumentation.Elasticsearch
{
    internal partial class ElasticsearchTags : InstrumentationTags
    {
        [Tag(Trace.Tags.SpanKind)]
        public override string SpanKind => SpanKinds.Client;

        [Tag(Trace.Tags.InstrumentationName)]
        public string InstrumentationName => ElasticsearchNetCommon.ComponentValue;

        [Tag(Trace.Tags.ElasticsearchAction)]
        public string Action { get; set; }

        [Tag(Trace.Tags.ElasticsearchMethod)]
        public string Method { get; set; }

        [Tag(Trace.Tags.ElasticsearchUrl)]
        public string Url { get; set; }

        [Tag(Trace.Tags.OutHost)]
        public string Host { get; set; }
    }

    internal partial class ElasticsearchV1Tags : ElasticsearchTags
    {
        public ElasticsearchV1Tags(IDictionary<string, string> peerServiceMappings)
        {
            PeerServiceMappings = peerServiceMappings;
        }

        public override string CalculatePeerService() => Host;

        public override string CalculatePeerServiceSource() => "network.destination.name";
    }
}
