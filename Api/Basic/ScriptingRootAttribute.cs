using System;

namespace PixelCombats.Api.Basic
{
	[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Struct | AttributeTargets.Class)]
	public sealed class ScriptingRootAttribute : Attribute
	{
		string m_Name;

		/// <summary>Имя, для доступа из скрипта</summary>
		public string Name => m_Name;

		public ScriptingRootAttribute() { }
		public ScriptingRootAttribute(string name)
		{
			m_Name = name;
		}
	}
}