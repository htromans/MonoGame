#region License
/* FNA - XNA4 Reimplementation for Desktop Platforms
 * Copyright 2009-2014 Ethan Lee and the MonoGame Team
 *
 * Released under the Microsoft Public License.
 * See LICENSE for details.
 */
#endregion

using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework.Content
{
	internal class BasicEffectReader : ContentTypeReader<BasicEffect>
	{
		protected internal override BasicEffect Read(
			ContentReader input,
			BasicEffect existingInstance
		) {
			BasicEffect effect = new BasicEffect(input.GraphicsDevice);
			Texture2D texture = input.ReadExternalReference<Texture>() as Texture2D;
			if (texture != null)
			{
				effect.Texture = texture;
				effect.TextureEnabled = true;
			}
			effect.DiffuseColor = input.ReadVector3();
			effect.EmissiveColor = input.ReadVector3();
			effect.SpecularColor = input.ReadVector3();
			effect.SpecularPower = input.ReadSingle();
			effect.Alpha = input.ReadSingle();
			effect.VertexColorEnabled = input.ReadBoolean();
			return effect;
		}
	}
}
