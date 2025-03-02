﻿// <copyright company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>
// <auto-generated/>

#nullable enable

using System.Threading;

namespace Datadog.Trace.Telemetry;
internal partial class CiVisibilityMetricsTelemetryCollector
{
    private const int CountSharedLength = 177;

    /// <summary>
    /// Creates the buffer for the <see cref="Datadog.Trace.Telemetry.Metrics.CountShared" /> values.
    /// </summary>
    private static AggregatedMetric[] GetCountSharedBuffer()
        => new AggregatedMetric[]
        {
            // integration_errors, index = 0
            new(new[] { "integration_name:datadog", "error_type:duck_typing" }),
            new(new[] { "integration_name:datadog", "error_type:invoker" }),
            new(new[] { "integration_name:datadog", "error_type:execution" }),
            new(new[] { "integration_name:opentracing", "error_type:duck_typing" }),
            new(new[] { "integration_name:opentracing", "error_type:invoker" }),
            new(new[] { "integration_name:opentracing", "error_type:execution" }),
            new(new[] { "integration_name:ciapp", "error_type:duck_typing" }),
            new(new[] { "integration_name:ciapp", "error_type:invoker" }),
            new(new[] { "integration_name:ciapp", "error_type:execution" }),
            new(new[] { "integration_name:debugger_span_probe", "error_type:duck_typing" }),
            new(new[] { "integration_name:debugger_span_probe", "error_type:invoker" }),
            new(new[] { "integration_name:debugger_span_probe", "error_type:execution" }),
            new(new[] { "integration_name:aws_lambda", "error_type:duck_typing" }),
            new(new[] { "integration_name:aws_lambda", "error_type:invoker" }),
            new(new[] { "integration_name:aws_lambda", "error_type:execution" }),
            new(new[] { "integration_name:msbuild", "error_type:duck_typing" }),
            new(new[] { "integration_name:msbuild", "error_type:invoker" }),
            new(new[] { "integration_name:msbuild", "error_type:execution" }),
            new(new[] { "integration_name:httpmessagehandler", "error_type:duck_typing" }),
            new(new[] { "integration_name:httpmessagehandler", "error_type:invoker" }),
            new(new[] { "integration_name:httpmessagehandler", "error_type:execution" }),
            new(new[] { "integration_name:httpsocketshandler", "error_type:duck_typing" }),
            new(new[] { "integration_name:httpsocketshandler", "error_type:invoker" }),
            new(new[] { "integration_name:httpsocketshandler", "error_type:execution" }),
            new(new[] { "integration_name:winhttphandler", "error_type:duck_typing" }),
            new(new[] { "integration_name:winhttphandler", "error_type:invoker" }),
            new(new[] { "integration_name:winhttphandler", "error_type:execution" }),
            new(new[] { "integration_name:curlhandler", "error_type:duck_typing" }),
            new(new[] { "integration_name:curlhandler", "error_type:invoker" }),
            new(new[] { "integration_name:curlhandler", "error_type:execution" }),
            new(new[] { "integration_name:aspnetcore", "error_type:duck_typing" }),
            new(new[] { "integration_name:aspnetcore", "error_type:invoker" }),
            new(new[] { "integration_name:aspnetcore", "error_type:execution" }),
            new(new[] { "integration_name:adonet", "error_type:duck_typing" }),
            new(new[] { "integration_name:adonet", "error_type:invoker" }),
            new(new[] { "integration_name:adonet", "error_type:execution" }),
            new(new[] { "integration_name:aspnet", "error_type:duck_typing" }),
            new(new[] { "integration_name:aspnet", "error_type:invoker" }),
            new(new[] { "integration_name:aspnet", "error_type:execution" }),
            new(new[] { "integration_name:aspnetmvc", "error_type:duck_typing" }),
            new(new[] { "integration_name:aspnetmvc", "error_type:invoker" }),
            new(new[] { "integration_name:aspnetmvc", "error_type:execution" }),
            new(new[] { "integration_name:aspnetwebapi2", "error_type:duck_typing" }),
            new(new[] { "integration_name:aspnetwebapi2", "error_type:invoker" }),
            new(new[] { "integration_name:aspnetwebapi2", "error_type:execution" }),
            new(new[] { "integration_name:graphql", "error_type:duck_typing" }),
            new(new[] { "integration_name:graphql", "error_type:invoker" }),
            new(new[] { "integration_name:graphql", "error_type:execution" }),
            new(new[] { "integration_name:hotchocolate", "error_type:duck_typing" }),
            new(new[] { "integration_name:hotchocolate", "error_type:invoker" }),
            new(new[] { "integration_name:hotchocolate", "error_type:execution" }),
            new(new[] { "integration_name:mongodb", "error_type:duck_typing" }),
            new(new[] { "integration_name:mongodb", "error_type:invoker" }),
            new(new[] { "integration_name:mongodb", "error_type:execution" }),
            new(new[] { "integration_name:xunit", "error_type:duck_typing" }),
            new(new[] { "integration_name:xunit", "error_type:invoker" }),
            new(new[] { "integration_name:xunit", "error_type:execution" }),
            new(new[] { "integration_name:nunit", "error_type:duck_typing" }),
            new(new[] { "integration_name:nunit", "error_type:invoker" }),
            new(new[] { "integration_name:nunit", "error_type:execution" }),
            new(new[] { "integration_name:mstestv2", "error_type:duck_typing" }),
            new(new[] { "integration_name:mstestv2", "error_type:invoker" }),
            new(new[] { "integration_name:mstestv2", "error_type:execution" }),
            new(new[] { "integration_name:wcf", "error_type:duck_typing" }),
            new(new[] { "integration_name:wcf", "error_type:invoker" }),
            new(new[] { "integration_name:wcf", "error_type:execution" }),
            new(new[] { "integration_name:webrequest", "error_type:duck_typing" }),
            new(new[] { "integration_name:webrequest", "error_type:invoker" }),
            new(new[] { "integration_name:webrequest", "error_type:execution" }),
            new(new[] { "integration_name:elasticsearchnet", "error_type:duck_typing" }),
            new(new[] { "integration_name:elasticsearchnet", "error_type:invoker" }),
            new(new[] { "integration_name:elasticsearchnet", "error_type:execution" }),
            new(new[] { "integration_name:servicestackredis", "error_type:duck_typing" }),
            new(new[] { "integration_name:servicestackredis", "error_type:invoker" }),
            new(new[] { "integration_name:servicestackredis", "error_type:execution" }),
            new(new[] { "integration_name:stackexchangeredis", "error_type:duck_typing" }),
            new(new[] { "integration_name:stackexchangeredis", "error_type:invoker" }),
            new(new[] { "integration_name:stackexchangeredis", "error_type:execution" }),
            new(new[] { "integration_name:serviceremoting", "error_type:duck_typing" }),
            new(new[] { "integration_name:serviceremoting", "error_type:invoker" }),
            new(new[] { "integration_name:serviceremoting", "error_type:execution" }),
            new(new[] { "integration_name:rabbitmq", "error_type:duck_typing" }),
            new(new[] { "integration_name:rabbitmq", "error_type:invoker" }),
            new(new[] { "integration_name:rabbitmq", "error_type:execution" }),
            new(new[] { "integration_name:msmq", "error_type:duck_typing" }),
            new(new[] { "integration_name:msmq", "error_type:invoker" }),
            new(new[] { "integration_name:msmq", "error_type:execution" }),
            new(new[] { "integration_name:kafka", "error_type:duck_typing" }),
            new(new[] { "integration_name:kafka", "error_type:invoker" }),
            new(new[] { "integration_name:kafka", "error_type:execution" }),
            new(new[] { "integration_name:cosmosdb", "error_type:duck_typing" }),
            new(new[] { "integration_name:cosmosdb", "error_type:invoker" }),
            new(new[] { "integration_name:cosmosdb", "error_type:execution" }),
            new(new[] { "integration_name:awssdk", "error_type:duck_typing" }),
            new(new[] { "integration_name:awssdk", "error_type:invoker" }),
            new(new[] { "integration_name:awssdk", "error_type:execution" }),
            new(new[] { "integration_name:awssqs", "error_type:duck_typing" }),
            new(new[] { "integration_name:awssqs", "error_type:invoker" }),
            new(new[] { "integration_name:awssqs", "error_type:execution" }),
            new(new[] { "integration_name:awssns", "error_type:duck_typing" }),
            new(new[] { "integration_name:awssns", "error_type:invoker" }),
            new(new[] { "integration_name:awssns", "error_type:execution" }),
            new(new[] { "integration_name:ilogger", "error_type:duck_typing" }),
            new(new[] { "integration_name:ilogger", "error_type:invoker" }),
            new(new[] { "integration_name:ilogger", "error_type:execution" }),
            new(new[] { "integration_name:aerospike", "error_type:duck_typing" }),
            new(new[] { "integration_name:aerospike", "error_type:invoker" }),
            new(new[] { "integration_name:aerospike", "error_type:execution" }),
            new(new[] { "integration_name:azurefunctions", "error_type:duck_typing" }),
            new(new[] { "integration_name:azurefunctions", "error_type:invoker" }),
            new(new[] { "integration_name:azurefunctions", "error_type:execution" }),
            new(new[] { "integration_name:couchbase", "error_type:duck_typing" }),
            new(new[] { "integration_name:couchbase", "error_type:invoker" }),
            new(new[] { "integration_name:couchbase", "error_type:execution" }),
            new(new[] { "integration_name:mysql", "error_type:duck_typing" }),
            new(new[] { "integration_name:mysql", "error_type:invoker" }),
            new(new[] { "integration_name:mysql", "error_type:execution" }),
            new(new[] { "integration_name:npgsql", "error_type:duck_typing" }),
            new(new[] { "integration_name:npgsql", "error_type:invoker" }),
            new(new[] { "integration_name:npgsql", "error_type:execution" }),
            new(new[] { "integration_name:oracle", "error_type:duck_typing" }),
            new(new[] { "integration_name:oracle", "error_type:invoker" }),
            new(new[] { "integration_name:oracle", "error_type:execution" }),
            new(new[] { "integration_name:sqlclient", "error_type:duck_typing" }),
            new(new[] { "integration_name:sqlclient", "error_type:invoker" }),
            new(new[] { "integration_name:sqlclient", "error_type:execution" }),
            new(new[] { "integration_name:sqlite", "error_type:duck_typing" }),
            new(new[] { "integration_name:sqlite", "error_type:invoker" }),
            new(new[] { "integration_name:sqlite", "error_type:execution" }),
            new(new[] { "integration_name:serilog", "error_type:duck_typing" }),
            new(new[] { "integration_name:serilog", "error_type:invoker" }),
            new(new[] { "integration_name:serilog", "error_type:execution" }),
            new(new[] { "integration_name:log4net", "error_type:duck_typing" }),
            new(new[] { "integration_name:log4net", "error_type:invoker" }),
            new(new[] { "integration_name:log4net", "error_type:execution" }),
            new(new[] { "integration_name:nlog", "error_type:duck_typing" }),
            new(new[] { "integration_name:nlog", "error_type:invoker" }),
            new(new[] { "integration_name:nlog", "error_type:execution" }),
            new(new[] { "integration_name:traceannotations", "error_type:duck_typing" }),
            new(new[] { "integration_name:traceannotations", "error_type:invoker" }),
            new(new[] { "integration_name:traceannotations", "error_type:execution" }),
            new(new[] { "integration_name:grpc", "error_type:duck_typing" }),
            new(new[] { "integration_name:grpc", "error_type:invoker" }),
            new(new[] { "integration_name:grpc", "error_type:execution" }),
            new(new[] { "integration_name:process", "error_type:duck_typing" }),
            new(new[] { "integration_name:process", "error_type:invoker" }),
            new(new[] { "integration_name:process", "error_type:execution" }),
            new(new[] { "integration_name:hashalgorithm", "error_type:duck_typing" }),
            new(new[] { "integration_name:hashalgorithm", "error_type:invoker" }),
            new(new[] { "integration_name:hashalgorithm", "error_type:execution" }),
            new(new[] { "integration_name:symmetricalgorithm", "error_type:duck_typing" }),
            new(new[] { "integration_name:symmetricalgorithm", "error_type:invoker" }),
            new(new[] { "integration_name:symmetricalgorithm", "error_type:execution" }),
            new(new[] { "integration_name:opentelemetry", "error_type:duck_typing" }),
            new(new[] { "integration_name:opentelemetry", "error_type:invoker" }),
            new(new[] { "integration_name:opentelemetry", "error_type:execution" }),
            new(new[] { "integration_name:pathtraversal", "error_type:duck_typing" }),
            new(new[] { "integration_name:pathtraversal", "error_type:invoker" }),
            new(new[] { "integration_name:pathtraversal", "error_type:execution" }),
            new(new[] { "integration_name:ssrf", "error_type:duck_typing" }),
            new(new[] { "integration_name:ssrf", "error_type:invoker" }),
            new(new[] { "integration_name:ssrf", "error_type:execution" }),
            new(new[] { "integration_name:ldap", "error_type:duck_typing" }),
            new(new[] { "integration_name:ldap", "error_type:invoker" }),
            new(new[] { "integration_name:ldap", "error_type:execution" }),
            new(new[] { "integration_name:awskinesis", "error_type:duck_typing" }),
            new(new[] { "integration_name:awskinesis", "error_type:invoker" }),
            new(new[] { "integration_name:awskinesis", "error_type:execution" }),
            new(new[] { "integration_name:azureservicebus", "error_type:duck_typing" }),
            new(new[] { "integration_name:azureservicebus", "error_type:invoker" }),
            new(new[] { "integration_name:azureservicebus", "error_type:execution" }),
            new(new[] { "integration_name:systemrandom", "error_type:duck_typing" }),
            new(new[] { "integration_name:systemrandom", "error_type:invoker" }),
            new(new[] { "integration_name:systemrandom", "error_type:execution" }),
            new(new[] { "integration_name:awsdynamodb", "error_type:duck_typing" }),
            new(new[] { "integration_name:awsdynamodb", "error_type:invoker" }),
            new(new[] { "integration_name:awsdynamodb", "error_type:execution" }),
        };

    /// <summary>
    /// Gets an array of metric counts, indexed by integer value of the <see cref="Datadog.Trace.Telemetry.Metrics.CountShared" />.
    /// Each value represents the number of unique entries in the buffer returned by <see cref="GetCountSharedBuffer()" />
    /// It is equal to the cardinality of the tag combinations (or 1 if there are no tags)
    /// </summary>
    private static int[] CountSharedEntryCounts { get; }
        = new int[]{ 177, };

    public void RecordCountSharedIntegrationsError(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationError tag2, int increment = 1)
    {
        var index = 0 + ((int)tag1 * 3) + (int)tag2;
        Interlocked.Add(ref _buffer.CountShared[index], increment);
    }
}