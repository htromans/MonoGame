#region License
/* FNA - XNA4 Reimplementation for Desktop Platforms
 * Copyright 2009-2014 Ethan Lee and the MonoGame Team
 *
 * Released under the Microsoft Public License.
 * See LICENSE for details.
 */
#endregion

using System;

using Microsoft.Xna.Framework.Content;

namespace Microsoft.Xna.Framework.Content
{
	internal class Int64Reader : ContentTypeReader<long>
	{
		internal Int64Reader()
		{
		}

		protected internal override long Read(
			ContentReader input,
			long existingInstance
		) {
			return input.ReadInt64();
		}
	}
}
