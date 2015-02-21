﻿using System;

namespace Vexe.Runtime.Types
{
	/// <summary>
	/// A shorter alternative to SerializeField - applicable to fields and properties
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class SerializeAttribute : Attribute
	{
	}

	/// <summary>
	/// Fields/auto-properties annotated with this don't get serialized
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class DontSerializeAttribute : Attribute
	{
	}

	/// <summary>
	/// A shorter alternative to SerializeField - applicable to fields and properties
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class SaveAttribute : Attribute
	{
	}

	/// <summary>
	/// Fields/auto-properties annotated with this don't get serialized
	/// Classes annoated with it won't appear in a SaveMarker's components to save list
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class)]
	public class DontSaveAttribute : Attribute
	{
	}
}
