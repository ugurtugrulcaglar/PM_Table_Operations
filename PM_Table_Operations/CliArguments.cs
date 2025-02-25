// See https://aka.ms/new-console-template for more information

using CommandLine;

internal class CliArguments
{
    [Option('t', "operation-type", Required = true, HelpText = "Input file type: 'CreateTable', 'CreateCounterDefinationDml'.")]
    public OpetationType OpetationType { get; set; }

    [Option('i', "input-file-name", Required = true, HelpText = "Input file name.")]
    public required string InputFileName { get; set; }

    [Option('c', "counter-type", Required = true, HelpText = "Counter Type: Numeric:N, String:S")]
    public required CounterType CounterType { get; set; }

    [Option('h', "hash-flag", Required = false, HelpText = "Hash Columns:1, Do not Hash Columns:0")]
    public bool HashFlag { get; set; } = false;

}

public enum OpetationType
{
    CreateTable,
    CreateCounterDefinationDml
}

public enum CounterType
{
    Numeric,
    String,
    N,
    S
}
