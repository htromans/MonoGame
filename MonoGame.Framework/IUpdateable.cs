#region License
/* FNA - XNA4 Reimplementation for Desktop Platforms
 * Copyright 2009-2014 Ethan Lee and the MonoGame Team
 *
 * Released under the Microsoft Public License.
 * See LICENSE for details.
 */
#endregion

#region Statemenents
using System;
#endregion

namespace Microsoft.Xna.Framework
{
	public interface IUpdateable
	{
		#region Methods
		void Update(GameTime gameTime);
		#endregion
		
		#region Events
		event EventHandler<EventArgs> EnabledChanged;
		
		event EventHandler<EventArgs> UpdateOrderChanged;
		#endregion
	
		#region Properties
		bool Enabled { get; }
		
		int UpdateOrder { get; }
		#endregion
	}
}
