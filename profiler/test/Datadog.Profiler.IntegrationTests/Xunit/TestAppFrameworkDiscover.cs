// <copyright file="TestAppFrameworkDiscover.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2022 Datadog, Inc.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using Datadog.Profiler.IntegrationTests.Helpers;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Datadog.Profiler.IntegrationTests.Xunit
{
    /// <summary>
    /// This class allows to discover test cases for smoke application.
    /// </summary>
    internal class TestAppFrameworkDiscover : IXunitTestCaseDiscoverer
    {
        public TestAppFrameworkDiscover(IMessageSink messageSink)
        {
            MessageSink = messageSink;
        }

        public IMessageSink MessageSink { get; }

        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            var appName = factAttribute.GetNamedArgument<string>("AppName");
            var appAssembly = factAttribute.GetNamedArgument<string>("AppAssembly");
            var frameworks = factAttribute.GetNamedArgument<string[]>("Frameworks");
            var appFolderPath = TestApplicationRunner.GetApplicationOutputFolderPath(appName);

            MessageSink.OnMessage(new DiagnosticMessage("Discovering tests case in {0} for application {1}", appFolderPath, appName));

            var results = new List<IXunitTestCase>();

            if (!System.IO.Directory.Exists(appFolderPath))
            {
                results.Add(
                    new ExecutionErrorTestCase(
                        MessageSink,
                        TestMethodDisplay.Method,
                        TestMethodDisplayOptions.None,
                        testMethod,
                        $"Application folder path '{appFolderPath}' does not exist: try compiling application '{appName}' first."));
                return results;
            }

            foreach (var folder in System.IO.Directory.GetDirectories(appFolderPath))
            {
                var framework = System.IO.Path.GetFileName(folder);
                if (frameworks == null || frameworks.Contains(framework))
                {
                    results.Add(
                        new ProfilerTestCase(
                                MessageSink,
                                TestMethodDisplay.ClassAndMethod,
                                TestMethodDisplayOptions.All,
                                testMethod,
                                new object[] { appName, System.IO.Path.GetFileName(folder), appAssembly }));
                }
                else
                {
                    var xx = new SkippableTestCase(
                        $"Test case skipped: {framework} is an unsupported framework",
                        testMethod,
                        new object[] { appName, System.IO.Path.GetFileName(folder), appAssembly });
                    results.Add(xx);
                }
            }

            if (results.Count == 0)
            {
                results.Add(
                    new ExecutionErrorTestCase(
                            MessageSink,
                            TestMethodDisplay.Method,
                            TestMethodDisplayOptions.None,
                            testMethod,
                            $"Application '{appName}' does not have any test cases: try compiling the application '{appName}' first."));
            }

            return results;
        }
    }
}
