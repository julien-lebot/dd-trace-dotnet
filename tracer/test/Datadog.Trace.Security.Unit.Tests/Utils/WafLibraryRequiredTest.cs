﻿// <copyright file="WafLibraryRequiredTest.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable
using System;
using Datadog.Trace.AppSec.Waf.NativeBindings;
using Xunit;

namespace Datadog.Trace.Security.Unit.Tests.Utils;

public class WafLibraryRequiredTest
{
    static WafLibraryRequiredTest()
    {
        var result = WafLibraryInvoker.Initialize();
        WafLibraryInvoker = result.WafLibraryInvoker;
    }

    internal static WafLibraryInvoker? WafLibraryInvoker { get; }
}
