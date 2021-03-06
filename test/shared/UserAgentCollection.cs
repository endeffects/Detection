﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace Wangkanai.Detection
{
    public class UserAgentCollection
    {
        public static IEnumerable<object[]> Data => new List<object[]> {
            new object[]{
                "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.73 Safari/537.36 OPR/34.0.2036.42",
                DeviceType.Desktop,
                BrowserType.Opera,
                PlatformType.Windows,
                EngineType.WebKit
            },
        };
    }

    public class UserAgentDataAttribute : DataAttribute
    {
        private readonly DeviceType device;
        private readonly BrowserType browser;
        private readonly PlatformType platform;
        private readonly EngineType engine;
        private readonly string agent;

        public UserAgentDataAttribute(DeviceType device, BrowserType browser, PlatformType platform, EngineType engine, string agent)
        {
            this.device = device;
            this.browser = browser;
            this.platform = platform;
            this.engine = engine;
            this.agent = agent;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { device, browser, platform, engine, agent };
        }
    }
}