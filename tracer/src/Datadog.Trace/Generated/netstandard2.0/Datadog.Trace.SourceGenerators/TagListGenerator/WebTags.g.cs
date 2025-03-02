﻿// <copyright company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>
// <auto-generated/>

#nullable enable

using Datadog.Trace.Processors;
using Datadog.Trace.Tagging;
using System;

namespace Datadog.Trace.Tagging
{
    partial class WebTags
    {
        // SpanKindBytes = MessagePack.Serialize("span.kind");
#if NETCOREAPP
        private static ReadOnlySpan<byte> SpanKindBytes => new byte[] { 169, 115, 112, 97, 110, 46, 107, 105, 110, 100 };
#else
        private static readonly byte[] SpanKindBytes = new byte[] { 169, 115, 112, 97, 110, 46, 107, 105, 110, 100 };
#endif
        // HttpUserAgentBytes = MessagePack.Serialize("http.useragent");
#if NETCOREAPP
        private static ReadOnlySpan<byte> HttpUserAgentBytes => new byte[] { 174, 104, 116, 116, 112, 46, 117, 115, 101, 114, 97, 103, 101, 110, 116 };
#else
        private static readonly byte[] HttpUserAgentBytes = new byte[] { 174, 104, 116, 116, 112, 46, 117, 115, 101, 114, 97, 103, 101, 110, 116 };
#endif
        // HttpMethodBytes = MessagePack.Serialize("http.method");
#if NETCOREAPP
        private static ReadOnlySpan<byte> HttpMethodBytes => new byte[] { 171, 104, 116, 116, 112, 46, 109, 101, 116, 104, 111, 100 };
#else
        private static readonly byte[] HttpMethodBytes = new byte[] { 171, 104, 116, 116, 112, 46, 109, 101, 116, 104, 111, 100 };
#endif
        // HttpRequestHeadersHostBytes = MessagePack.Serialize("http.request.headers.host");
#if NETCOREAPP
        private static ReadOnlySpan<byte> HttpRequestHeadersHostBytes => new byte[] { 185, 104, 116, 116, 112, 46, 114, 101, 113, 117, 101, 115, 116, 46, 104, 101, 97, 100, 101, 114, 115, 46, 104, 111, 115, 116 };
#else
        private static readonly byte[] HttpRequestHeadersHostBytes = new byte[] { 185, 104, 116, 116, 112, 46, 114, 101, 113, 117, 101, 115, 116, 46, 104, 101, 97, 100, 101, 114, 115, 46, 104, 111, 115, 116 };
#endif
        // HttpUrlBytes = MessagePack.Serialize("http.url");
#if NETCOREAPP
        private static ReadOnlySpan<byte> HttpUrlBytes => new byte[] { 168, 104, 116, 116, 112, 46, 117, 114, 108 };
#else
        private static readonly byte[] HttpUrlBytes = new byte[] { 168, 104, 116, 116, 112, 46, 117, 114, 108 };
#endif
        // HttpStatusCodeBytes = MessagePack.Serialize("http.status_code");
#if NETCOREAPP
        private static ReadOnlySpan<byte> HttpStatusCodeBytes => new byte[] { 176, 104, 116, 116, 112, 46, 115, 116, 97, 116, 117, 115, 95, 99, 111, 100, 101 };
#else
        private static readonly byte[] HttpStatusCodeBytes = new byte[] { 176, 104, 116, 116, 112, 46, 115, 116, 97, 116, 117, 115, 95, 99, 111, 100, 101 };
#endif
        // NetworkClientIpBytes = MessagePack.Serialize("network.client.ip");
#if NETCOREAPP
        private static ReadOnlySpan<byte> NetworkClientIpBytes => new byte[] { 177, 110, 101, 116, 119, 111, 114, 107, 46, 99, 108, 105, 101, 110, 116, 46, 105, 112 };
#else
        private static readonly byte[] NetworkClientIpBytes = new byte[] { 177, 110, 101, 116, 119, 111, 114, 107, 46, 99, 108, 105, 101, 110, 116, 46, 105, 112 };
#endif
        // HttpClientIpBytes = MessagePack.Serialize("http.client_ip");
#if NETCOREAPP
        private static ReadOnlySpan<byte> HttpClientIpBytes => new byte[] { 174, 104, 116, 116, 112, 46, 99, 108, 105, 101, 110, 116, 95, 105, 112 };
#else
        private static readonly byte[] HttpClientIpBytes = new byte[] { 174, 104, 116, 116, 112, 46, 99, 108, 105, 101, 110, 116, 95, 105, 112 };
#endif

        public override string? GetTag(string key)
        {
            return key switch
            {
                "span.kind" => SpanKind,
                "http.useragent" => HttpUserAgent,
                "http.method" => HttpMethod,
                "http.request.headers.host" => HttpRequestHeadersHost,
                "http.url" => HttpUrl,
                "http.status_code" => HttpStatusCode,
                "network.client.ip" => NetworkClientIp,
                "http.client_ip" => HttpClientIp,
                _ => base.GetTag(key),
            };
        }

        public override void SetTag(string key, string value)
        {
            switch(key)
            {
                case "http.useragent": 
                    HttpUserAgent = value;
                    break;
                case "http.method": 
                    HttpMethod = value;
                    break;
                case "http.request.headers.host": 
                    HttpRequestHeadersHost = value;
                    break;
                case "http.url": 
                    HttpUrl = value;
                    break;
                case "http.status_code": 
                    HttpStatusCode = value;
                    break;
                case "network.client.ip": 
                    NetworkClientIp = value;
                    break;
                case "http.client_ip": 
                    HttpClientIp = value;
                    break;
                case "span.kind": 
                    Logger.Value.Warning("Attempted to set readonly tag {TagName} on {TagType}. Ignoring.", key, nameof(WebTags));
                    break;
                default: 
                    base.SetTag(key, value);
                    break;
            }
        }

        public override void EnumerateTags<TProcessor>(ref TProcessor processor)
        {
            if (SpanKind is not null)
            {
                processor.Process(new TagItem<string>("span.kind", SpanKind, SpanKindBytes));
            }

            if (HttpUserAgent is not null)
            {
                processor.Process(new TagItem<string>("http.useragent", HttpUserAgent, HttpUserAgentBytes));
            }

            if (HttpMethod is not null)
            {
                processor.Process(new TagItem<string>("http.method", HttpMethod, HttpMethodBytes));
            }

            if (HttpRequestHeadersHost is not null)
            {
                processor.Process(new TagItem<string>("http.request.headers.host", HttpRequestHeadersHost, HttpRequestHeadersHostBytes));
            }

            if (HttpUrl is not null)
            {
                processor.Process(new TagItem<string>("http.url", HttpUrl, HttpUrlBytes));
            }

            if (HttpStatusCode is not null)
            {
                processor.Process(new TagItem<string>("http.status_code", HttpStatusCode, HttpStatusCodeBytes));
            }

            if (NetworkClientIp is not null)
            {
                processor.Process(new TagItem<string>("network.client.ip", NetworkClientIp, NetworkClientIpBytes));
            }

            if (HttpClientIp is not null)
            {
                processor.Process(new TagItem<string>("http.client_ip", HttpClientIp, HttpClientIpBytes));
            }

            base.EnumerateTags(ref processor);
        }

        protected override void WriteAdditionalTags(System.Text.StringBuilder sb)
        {
            if (SpanKind is not null)
            {
                sb.Append("span.kind (tag):")
                  .Append(SpanKind)
                  .Append(',');
            }

            if (HttpUserAgent is not null)
            {
                sb.Append("http.useragent (tag):")
                  .Append(HttpUserAgent)
                  .Append(',');
            }

            if (HttpMethod is not null)
            {
                sb.Append("http.method (tag):")
                  .Append(HttpMethod)
                  .Append(',');
            }

            if (HttpRequestHeadersHost is not null)
            {
                sb.Append("http.request.headers.host (tag):")
                  .Append(HttpRequestHeadersHost)
                  .Append(',');
            }

            if (HttpUrl is not null)
            {
                sb.Append("http.url (tag):")
                  .Append(HttpUrl)
                  .Append(',');
            }

            if (HttpStatusCode is not null)
            {
                sb.Append("http.status_code (tag):")
                  .Append(HttpStatusCode)
                  .Append(',');
            }

            if (NetworkClientIp is not null)
            {
                sb.Append("network.client.ip (tag):")
                  .Append(NetworkClientIp)
                  .Append(',');
            }

            if (HttpClientIp is not null)
            {
                sb.Append("http.client_ip (tag):")
                  .Append(HttpClientIp)
                  .Append(',');
            }

            base.WriteAdditionalTags(sb);
        }
    }
}
