﻿// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Reflection;
using System.Linq;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAzure.MobileServices
{
    /// <summary>
    /// Implements the <see cref="IPlatform"/> interface for the Windows
    /// Phone platform.
    /// </summary>
    public class PlatformInformation : IPlatformInformation
    {
        /// <summary>
        /// Required interface which provides information only attainable
        /// using platform dependent APIs
        /// </summary>
        public static IPlatformQueryImpl OSInfoQuery { get; set; }

        /// <summary>
        /// A singleton instance of the <see cref="ApplicationStorage"/>.
        /// </summary>
        private static IPlatformInformation instance = new PlatformInformation();

        /// <summary>
        /// A singleton instance of the <see cref="ApplicationStorage"/>.
        /// </summary>
        public static IPlatformInformation Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// The architecture of the platform.
        /// </summary>
        public string OperatingSystemArchitecture
        {
            get
            {
                return OSInfoQuery.GetOperatingSystemArchitecture();
            }
        }

        /// <summary>
        /// The name of the operating system of the platform.
        /// </summary>
        public string OperatingSystemName
        {
            get
            {
                return OSInfoQuery.GetOperatingSystemName();
            }
        }

        /// <summary>
        /// The version of the operating system of the platform.
        /// </summary>
        public string OperatingSystemVersion
        {
            get
            {
                /*
                Version version = Environment.OSVersion.Version;

                return string.Format(CultureInfo.InvariantCulture,
                    "{0}.{1}.{2}.{3}",
                    version.Major,
                    version.Minor,
                    version.Revision,
                    version.Build
                );
                */

                return OSInfoQuery.GetOperatingSystemVersion();
            }
        }

        /// <summary>
        /// Indicated whether the device is an emulator or not
        /// </summary>
        public bool IsEmulator
        {
            get
            {
                return false;
            }
        }

        public string Version
        {
            get
            {
                return this.GetVersionFromAssemblyFileVersion();
            }
        }
    }
}
