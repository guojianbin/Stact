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
	using System;
	using System.Linq.Expressions;
	using System.Reflection;


	public class PublicMessageMethodConvention<TActor, TChannel> :
		ActorConvention<TActor>
	{
		readonly Action<TActor, TChannel> _instanceConsumer;

		public PublicMessageMethodConvention(MethodInfo method)
		{
			_instanceConsumer = GenerateConsumer(method);
		}

		public void Initialize(TActor instance, Fiber fiber, Scheduler scheduler, Inbox inbox)
		{
			inbox.Connect(x =>
				{
					x.AddConsumerOf<TChannel>()
						.UsingConsumer(message => _instanceConsumer(instance, message))
						.HandleOnFiber(fiber);
				});
		}

		static Action<TActor, TChannel> GenerateConsumer(MethodInfo method)
		{
			ParameterExpression instance = Expression.Parameter(typeof(TActor), "instance");
			ParameterExpression message = Expression.Parameter(typeof(TChannel), "message");
			MethodCallExpression call = Expression.Call(instance, method, message);
			Expression<Action<TActor, TChannel>> expression = Expression.Lambda<Action<TActor, TChannel>>(call, new[]{instance, message});

			return expression.Compile();
		}
	}
}