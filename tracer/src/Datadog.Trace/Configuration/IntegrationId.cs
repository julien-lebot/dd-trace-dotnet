// <copyright file="IntegrationId.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using Datadog.Trace.SourceGenerators;

namespace Datadog.Trace.Configuration
{
    [EnumExtensions]
    internal enum IntegrationId
    {
        HttpMessageHandler,
        HttpSocketsHandler,
        WinHttpHandler,
        CurlHandler,
        AspNetCore,
        AdoNet,
        AspNet,
        AspNetMvc,
        AspNetWebApi2,
        GraphQL,
        HotChocolate,
        MongoDb,
        XUnit,
        NUnit,
        MsTestV2,
        Wcf,
        WebRequest,
        ElasticsearchNet,
        ServiceStackRedis,
        StackExchangeRedis,
        ServiceRemoting,
        RabbitMQ,
        Msmq,
        Kafka,
        CosmosDb,
        AwsSdk,
        AwsSqs,
        AwsSns,
        AwsLambda,
        ILogger,
        Aerospike,
        AzureFunctions,
        Couchbase,
        MySql,
        Npgsql,  // PostgreSQL
        Oracle,
        SqlClient, // SQL Server
        Sqlite,
        Serilog,
        Log4Net,
        NLog,
        TraceAnnotations,
        Grpc,
        Process,
        HashAlgorithm,
        SymmetricAlgorithm,
        OpenTelemetry,
        PathTraversal,
        Ldap,
        Ssrf,
        AwsKinesis,
        AzureServiceBus,
        SystemRandom,
        AwsDynamoDb,
        // If you add an integration here, please don't forget to impact the allow / block list of telemetry config
        // In the telemetry repository. (and keep that comment at the bottom :))
    }
}
