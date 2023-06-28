// <copyright file="CommonTags.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System.Collections.Generic;
using Datadog.Trace.SourceGenerators;

namespace Datadog.Trace.Tagging
{
    internal partial class CommonTags : TagsList
    {
        private string _peerServiceOverride;
        private string _peerServiceSourceOverride;
        private string _peerServiceRemappedFrom;

        [Metric(Trace.Metrics.SamplingLimitDecision)]
        public double? SamplingLimitDecision { get; set; }

        [Metric(Trace.Metrics.TracesKeepRate)]
        public double? TracesKeepRate { get; set; }

        [Metric(Trace.Metrics.SamplingAgentDecision)]
        public double? SamplingAgentDecision { get; set; }

        // Use a private setter for setting the "peer.service" tag so we avoid
        // accidentally setting the value ourselves and instead calculate the
        // value from predefined precursor attributes.
        // However, this can still be set from ITags.SetTag so the user can
        // customize the value if they wish.
        // Note: Retrieving the PeerService will automatically update the value returned from PeerServiceRemappedFrom.
        [Tag(Trace.Tags.PeerService)]
        public string PeerService
        {
            get => RemapPeerService(_peerServiceOverride ?? CalculatePeerService());
            private set
            {
                _peerServiceOverride = value;
                _peerServiceSourceOverride = value is null ? null : "peer.service";
            }
        }

        [Tag(Trace.Tags.PeerServiceSource)]
        public string PeerServiceSource
        {
            get => _peerServiceSourceOverride ?? CalculatePeerServiceSource();
        }

        [Tag(Trace.Tags.PeerServiceRemappedFrom)]
        public string PeerServiceRemappedFrom => _peerServiceRemappedFrom;

        protected IDictionary<string, string> PeerServiceMappings { get; set; }

        public virtual string CalculatePeerService() => null;

        public virtual string CalculatePeerServiceSource() => null;

        private string RemapPeerService(string peerService)
        {
            if (peerService is null || PeerServiceMappings is null || !PeerServiceMappings.TryGetValue(PeerService, out var remappedValue))
            {
                _peerServiceRemappedFrom = null;
                return peerService;
            }

            _peerServiceRemappedFrom = peerService;
            return remappedValue;
        }
    }
}
