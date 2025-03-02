// <copyright file="NUnitCompositeWorkItemPerformOneTimeSetUpIntegration.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System;
using System.ComponentModel;
using Datadog.Trace.ClrProfiler.CallTarget;
using Datadog.Trace.DuckTyping;

namespace Datadog.Trace.ClrProfiler.AutoInstrumentation.Testing.NUnit;

/// <summary>
/// NUnit.Framework.Internal.Execution.CompositeWorkItem.PerformOneTimeSetUp() calltarget instrumentation
/// </summary>
[InstrumentMethod(
    AssemblyName = "nunit.framework",
    TypeName = "NUnit.Framework.Internal.Execution.CompositeWorkItem",
    MethodName = "PerformOneTimeSetUp",
    ReturnTypeName = ClrNames.Void,
    MinimumVersion = "3.0.0",
    MaximumVersion = "3.*.*",
    IntegrationName = NUnitIntegration.IntegrationName)]
[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public class NUnitCompositeWorkItemPerformOneTimeSetUpIntegration
{
    /// <summary>
    /// OnMethodEnd callback
    /// </summary>
    /// <typeparam name="TTarget">Type of the target</typeparam>
    /// <param name="instance">Instance value, aka `this` of the instrumented method.</param>
    /// <param name="exception">Exception instance in case the original code threw an exception.</param>
    /// <param name="state">Calltarget state value</param>
    /// <returns>Return value of the method</returns>
    internal static CallTargetReturn OnMethodEnd<TTarget>(TTarget instance, Exception exception, in CallTargetState state)
    {
        if (instance.TryDuckCast<ICompositeWorkItem>(out var compositeWorkItem) &&
            compositeWorkItem.Result.ResultState.Status == TestStatus.Failed)
        {
            if (compositeWorkItem.Result.ResultState.Site == FailureSite.SetUp)
            {
                NUnitIntegration.WriteSetUpOrTearDownError(compositeWorkItem, "SetUpException");
            }
            else if (compositeWorkItem.Result.ResultState.Site == FailureSite.TearDown)
            {
                NUnitIntegration.WriteSetUpOrTearDownError(compositeWorkItem, "TearDownException");
            }
        }

        return CallTargetReturn.GetDefault();
    }
}
