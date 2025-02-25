
using CommandLine;

namespace PM_Table_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CliArguments>(args)
                .WithParsed(cliArguments =>
                {
                    ArgumentException.ThrowIfNullOrEmpty(cliArguments.InputFileName, nameof(cliArguments.InputFileName));


                    switch (cliArguments.CounterType)
                    {
                        case CounterType.N:
                            cliArguments.CounterType = CounterType.Numeric;
                            break;
                        case CounterType.S:
                            cliArguments.CounterType = CounterType.String;
                            break;
                    }
                    
                    Console.WriteLine($"Operation Type: {cliArguments.OpetationType}");
                    Console.WriteLine($"Input file path: {cliArguments.InputFileName}");
                    Console.WriteLine($"Counter type: {cliArguments.CounterType}");
                    Console.WriteLine($"Hash flag: {cliArguments.HashFlag}");

                    switch (cliArguments.OpetationType)
                    {
                        case OpetationType.CreateTable:
                            var t = new TableOperations(
                                cliArguments.InputFileName,
                                cliArguments.CounterType,
                                cliArguments.HashFlag);
                            Console.WriteLine("Generating pm table script...");
                            t.CreatePMTables();
                            break;

                        case OpetationType.CreateCounterDefinationDml:
                            var c = new CounterOperations(
                               cliArguments.InputFileName,
                               cliArguments.HashFlag);
                            Console.WriteLine("Generating cfg counter definitions..");
                            c.PrepareCfgCounterDefinition();
                            break;
                    }
                });
        }
    }
}
