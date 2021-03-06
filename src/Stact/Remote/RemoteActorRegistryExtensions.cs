// Copyright 2010 Chris Patterson
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
	using System;
	using Configuration;


	public static class RemoteActorRegistryExtensions
	{
		public static ActorRegistryConfigurator Remote(this ActorRegistryConfigurator configurator,
		                                               Action<RemoteActorRegistryConfigurator> configure)
		{
			var remoteConfigurator = new RemoteActorRegistryConfiguratorImpl();

			configure(remoteConfigurator);

			configurator.AddConfigurator(remoteConfigurator);

			return configurator;
		}

		public static RemoteActorRegistryConfigurator ListenTo(this RemoteActorRegistryConfigurator configurator,
		                                                       string uriString)
		{
			var uri = new Uri(uriString);

			return configurator.ListenTo(uri);
		}
	}
}