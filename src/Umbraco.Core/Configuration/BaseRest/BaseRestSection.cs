﻿using System.Collections.Generic;
using System.Configuration;

namespace Umbraco.Core.Configuration.BaseRest
{
    [ConfigurationKey("BaseRestExtensions")]
    internal class BaseRestSection : UmbracoConfigurationSection, IBaseRest
    {
        private const string KeyEnabled = "enabled";

        private bool? _enabled;

        //internal protected override void ResetSection()
        //{
        //    base.ResetSection();

        //    _enabled = null;
        //}

        [ConfigurationProperty("", IsKey = false, IsRequired = false, IsDefaultCollection = true)]
		public ExtensionElementCollection Items
		{
			get { return (ExtensionElementCollection)base[""]; }
		}

        /// <summary>
        /// Gets or sets a value indicating whether base rest extensions are enabled.
        /// </summary>
        [ConfigurationProperty(KeyEnabled, DefaultValue = true, IsRequired = false)]
        public bool Enabled
        {
            get
            {
                return _enabled ?? (IsPresent == false || (bool)this[KeyEnabled]);
            }
            internal set { _enabled = value; }
        }

        IExtensionsCollection IBaseRest.Items
        {
            get { return Items; }
        }

    }
}
