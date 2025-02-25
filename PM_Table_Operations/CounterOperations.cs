using CsvHelper;
using PM_Table_Operations;
using PM_Table_Operations.Model;
using System.Globalization;
using System.Text;

public class CounterOperations
{
    public string InputFileName { get; init; }
    public bool HashFlag { get; init; }
    string workingDirectory = Directory.GetCurrentDirectory();

    public CounterOperations(
        string inputFileName,
        bool hashFlag)
    {
        InputFileName = inputFileName;
        HashFlag = hashFlag;
    }

    public void PrepareCfgCounterDefinition()
    {
        var counterDefinition = ReadInputFile();

        CreateCfgCounterDefTable(counterDefinition);
        DeleteFromCfgCounterDefTable(counterDefinition);

    }

    private void CreateCfgCounterDefTable(List<CounterDefinition> counterDefinitions)
    {
        CfgCounterDefinition obj = new CfgCounterDefinition();
        string outputPath = Path.Combine(workingDirectory, "output", "InsertIntoCfgCounterDef.sql");
        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            foreach (var counterDefinition in counterDefinitions)
            {
                string ddl = obj.CreateCfgCounterDML(counterDefinition, HashFlag);
                sw.WriteLine(ddl);
            }
            sw.Close();
        }
    }

    private void DeleteFromCfgCounterDefTable(List<CounterDefinition> counterDefinitions)
    {
        CfgCounterDefinition obj = new CfgCounterDefinition();
        string outputPath = Path.Combine(workingDirectory, "output", "rollback", "DelFromCfgCounterDef.sql");
        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            foreach (var counterDefinition in counterDefinitions)
            {
                string ddl = obj.DeleteFromCfgCounterDef(counterDefinition);
                sw.WriteLine(ddl);
            }
            sw.Close();
        }
    }

    private List<CounterDefinition> ReadInputFile()
    {

        var csvReaderConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture);
        csvReaderConfig.Delimiter = ";";
        csvReaderConfig.BadDataFound = null;
        csvReaderConfig.MissingFieldFound = null;


        string inputFilePath = Path.Combine(workingDirectory, InputFileName);

        using (var reader = new StreamReader(inputFilePath))
        using (var csv = new CsvReader(reader, csvReaderConfig))
        {
            return csv.GetRecords<CounterDefinition>().ToList();
        }
    }


}


