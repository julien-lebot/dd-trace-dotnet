// <copyright file="DatabaseSchema.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable

using System.Collections.Generic;
using Datadog.Trace.ClrProfiler.AutoInstrumentation.Elasticsearch;
using Datadog.Trace.ClrProfiler.AutoInstrumentation.MongoDb;
using Datadog.Trace.ClrProfiler.AutoInstrumentation.Redis;
using Datadog.Trace.Tagging;

namespace Datadog.Trace.Configuration.Schema
{
    internal class DatabaseSchema
    {
        private readonly SchemaVersion _version;
        private readonly bool _peerServiceTagsEnabled;
        private readonly IDictionary<string, string> _peerServiceMappings;
        private readonly bool _removeClientServiceNamesEnabled;
        private readonly string _defaultServiceName;
        private readonly IDictionary<string, string>? _serviceNameMappings;

        public DatabaseSchema(SchemaVersion version, bool peerServiceTagsEnabled, IDictionary<string, string> peerServiceMappings, bool removeClientServiceNamesEnabled, string defaultServiceName, IDictionary<string, string>? serviceNameMappings)
        {
            _version = version;
            _peerServiceTagsEnabled = peerServiceTagsEnabled;
            _peerServiceMappings = peerServiceMappings;
            _removeClientServiceNamesEnabled = removeClientServiceNamesEnabled;
            _defaultServiceName = defaultServiceName;
            _serviceNameMappings = serviceNameMappings;
        }

        public string GetOperationName(string databaseType) => $"{databaseType}.query";

        public string GetServiceName(string databaseType)
        {
            if (_serviceNameMappings is not null && _serviceNameMappings.TryGetValue(databaseType, out var mappedServiceName))
            {
                return mappedServiceName;
            }

            return _version switch
            {
                SchemaVersion.V0 when !_removeClientServiceNamesEnabled => $"{_defaultServiceName}-{databaseType}",
                _ => _defaultServiceName,
            };
        }

        public ElasticsearchTags CreateElasticsearchTags()
            => _version switch
            {
                SchemaVersion.V0 when !_peerServiceTagsEnabled => new ElasticsearchTags(),
                _ => new ElasticsearchV1Tags(_peerServiceMappings),
            };

        public MongoDbTags CreateMongoDbTags()
            => _version switch
            {
                SchemaVersion.V0 when !_peerServiceTagsEnabled => new MongoDbTags(),
                _ => new MongoDbV1Tags(_peerServiceMappings),
            };

        public SqlTags CreateSqlTags()
            => _version switch
            {
                SchemaVersion.V0 when !_peerServiceTagsEnabled => new SqlTags(),
                _ => new SqlV1Tags(_peerServiceMappings),
            };

        public RedisTags CreateRedisTags()
            => _version switch
            {
                SchemaVersion.V0 when !_peerServiceTagsEnabled => new RedisTags(),
                _ => new RedisV1Tags(_peerServiceMappings),
            };
    }
}
