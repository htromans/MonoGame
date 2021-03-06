#region License
/* FNA - XNA4 Reimplementation for Desktop Platforms
 * Copyright 2009-2014 Ethan Lee and the MonoGame Team
 *
 * Released under the Microsoft Public License.
 * See LICENSE for details.
 */

/*
MIT License
Copyright (c) 2006 The Mono.Xna Team

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using System;
using System.IO;


namespace Microsoft.Xna.Framework.Content
{
	public abstract class ContentTypeReader
	{
#region Private Member Variables

		private Type targetType;

#endregion Private Member Variables


#region Public Properties

		public Type TargetType
		{
			get
			{
				return this.targetType;
			}
		}

		public virtual int TypeVersion
		{
			// The default version (unless overridden) is zero
			get
			{
				return 0;
			}
		}

#endregion Public Properties


#region Protected Constructors

		protected ContentTypeReader(Type targetType)
		{
			this.targetType = targetType;
		}

#endregion Protected Constructors


#region Protected Methods

		protected internal virtual void Initialize(ContentTypeReaderManager manager)
		{
			// Do nothing. Are we supposed to add ourselves to the manager?
		}

		protected internal abstract object Read(ContentReader input, object existingInstance);

#endregion Protected Methods

#region Internal Static Helper Methods
		public static string Normalize(string fileName, string[] extensions)
		{
			if (File.Exists(fileName))
			{
				return fileName;
			}

			foreach (string ext in extensions)
			{
				// Concat the file name with valid extensions
				string fileNamePlusExt = fileName + ext;
				if (File.Exists(fileNamePlusExt))
				{
					return fileNamePlusExt;
				}
			}
			return null;
		}
#endregion
	}

	public abstract class ContentTypeReader<T> : ContentTypeReader
	{
#region Protected Constructors

		protected ContentTypeReader() : base(typeof(T))
		{
			// Nothing
		}

#endregion Protected Constructors

#region Protected Methods

		protected internal override object Read(ContentReader input, object existingInstance)
		{
			/* As per the documentation http://msdn.microsoft.com/en-us/library/microsoft.xna.framework.content.contenttypereader.read.aspx
			 * existingInstance
			 * The object receiving the data, or null if a new instance of the object should be created.
			 */
			if (existingInstance == null)
			{
				return this.Read(input, default(T));
			}
			else
			{
				return this.Read(input, (T) existingInstance);
			}
		}

		protected internal abstract T Read(ContentReader input, T existingInstance);

#endregion Protected Methods
	}
}
