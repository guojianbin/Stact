﻿// Copyright 2010 Chris Patterson
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Stact
{
	using System.Threading;
	using Configuration;
	using Configuration.Internal;


	public static class ExtensionsForSynchronizedChannels
	{
		public static SynchronizedChannelConfigurator<TChannel> OnCurrentSynchronizationContext<TChannel>(
			this ChannelConfigurator<TChannel> configurator)
		{
			var synchronizedConfigurator = new SynchronizedChannelConfiguratorImpl<TChannel>();

			configurator.AddConfigurator(synchronizedConfigurator);

			return synchronizedConfigurator;
		}

		public static SynchronizedChannelConfigurator<TChannel> OnSynchronizationContext<TChannel>(
			this ChannelConfigurator<TChannel> configurator, SynchronizationContext synchronizationContext)
		{
			var synchronizedConfigurator = new SynchronizedChannelConfiguratorImpl<TChannel>(synchronizationContext);

			configurator.AddConfigurator(synchronizedConfigurator);

			return synchronizedConfigurator;
		}
	}
}