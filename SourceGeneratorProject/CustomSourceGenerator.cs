using Microsoft.CodeAnalysis;
using System;
using System.Text.Json;

namespace SourceGeneratorProject
{
	[Generator]
	public class CustomSourceGenerator : ISourceGenerator
	{
		public TestObject Object { get; set; }

		public void Execute(GeneratorExecutionContext context)
		{
			context.AddSource("TestSource", $@"
public static class GeneratedSource
{{
	public static readonly int TestProperty = {Object.TestProperty};
}}");
		}

		public void Initialize(GeneratorInitializationContext context)
		{
			Object = JsonSerializer.Deserialize<TestObject>(@"{""TestProperty"":123}");
		}
	}

	public class TestObject
	{
		public int TestProperty { get; set; }
	}
}
