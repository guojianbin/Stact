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


	public interface SetMessageHeader
	{
		/// <summary>
		/// The identifier for this message
		/// </summary>
		string MessageId { set; }

		/// <summary>
		/// The identifier correlating this message to a message exchange/conversation
		/// </summary>
		string CorrelationId { set; }

		/// <summary>
		/// The sender address of the message
		/// </summary>
		Uri SenderAddress { set; }

		/// <summary>
		/// The final destination of the message
		/// </summary>
		Uri DestinationAddress { set; }

		/// <summary>
		/// The address where faults should be sent
		/// </summary>
		Uri FaultAddress { set; }
	}
}