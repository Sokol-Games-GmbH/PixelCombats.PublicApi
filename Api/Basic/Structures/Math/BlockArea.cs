using System;
using JavaScriptEngine.DataAnnotations;
using PixelCombats.Annotation;

namespace PixelCombats.Api.Basic.Structures.Math
{
	/// <summary>
	/// область с одним блоком
	/// </summary>
	[Serializable]
	[ScriptAllowed]
	[ScriptType("BlockArea", ScriptModuleNames.BASIC)]
	public struct BlockArea
	{
		/// <summary>
		/// ID блока
		/// </summary>
		[SerializeMember(1)]
		public ushort BlockId;
		/// <summary>
		/// область пространства для блока
		/// </summary>
		[SerializeMember(2)]
		public IndexRange Range;
	}
}