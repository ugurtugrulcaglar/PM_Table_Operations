using CsvHelper;
using PM_Table_Operations;
using PM_Table_Operations.Model;
using System.Globalization;


public class TableOperations
{
    public string InputFileName { get; init; }
    public CounterType CounterType { get; init; }
    public bool HashFlag { get; init; }
    public int Aggregatorid { get; init; }
    string workingDirectory = Directory.GetCurrentDirectory();

    public TableOperations(
        string inputFileName,
        CounterType counterType,
        bool hashFlag)
    {
        InputFileName = inputFileName;
        CounterType = counterType;
        HashFlag = hashFlag;
    }

    public void CreatePMTables()
    {
        var tables = ReadInputFile();

        string outputDir = Path.Combine(workingDirectory, "output");
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        string rollbackDir = Path.Combine(workingDirectory, "output", "rollback");
        if (!Directory.Exists(rollbackDir))
        {
            Directory.CreateDirectory(rollbackDir);
        }


        CreateClikhousePMTable(tables);
        CreateOraclePMTable(tables);
        DropClikHousePMTable(tables);
        DropOracleHistTable(tables);
        CreateCfgAggregatorDML(tables, Aggregatorid);
        DeleteCfgAggregatorDML(tables);
    }

    private void CreateClikhousePMTable(List<PmTable> tables)
    {
        ClickHousePmTable chObj = new ClickHousePmTable();
        mainColumns obj_mainColumns = new mainColumns();
        string outputPath = Path.Combine(workingDirectory, "output", "CreateClickHouseTables.sql");
        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            foreach (var table in tables)
            {

                chObj.CreateCustomCounters(table, CounterType, HashFlag);
                string ChMainColoums = obj_mainColumns.getChMainColumns(table);
                string ddl = chObj.CreateClickHousePMTable(table, ChMainColoums);
                sw.WriteLine(ddl);
                sw.WriteLine("\n\n\n\n\n");
            }
            sw.Close();
        }
    }

    private void CreateOraclePMTable(List<PmTable> tables)
    {
        OracleHistTable oracleObj = new OracleHistTable();
        mainColumns obj_mainColumns = new mainColumns();
        string outputPath = Path.Combine(workingDirectory, "output", "CreateOracleHistTables.sql");
        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            foreach (var table in tables)
            {
                string OraclemainColoums = obj_mainColumns.getORacleMainColumns(table);
                oracleObj.CreateCustomCounters(table, CounterType, HashFlag);
                string ddlORA = oracleObj.CreateOraHistTable(table, OraclemainColoums);

                sw.WriteLine(ddlORA);
                sw.WriteLine("\n\n\n\n\n");

            }
            sw.Close();
        }
    }

    private void DropClikHousePMTable(List<PmTable> tables)
    {
        ClickHousePmTable chObj = new ClickHousePmTable();

        string outputPath = Path.Combine(workingDirectory, "output", "rollback", "DropClickHouseTables.sql");
        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            foreach (var table in tables)
            {
                string ddl = chObj.DropClickHousePMTable(table);
                sw.WriteLine(ddl);
            }
            sw.Close();
        }
    }

    private void DropOracleHistTable(List<PmTable> tables)
    {
        OracleHistTable oracleObj = new OracleHistTable();

        string outputPath = Path.Combine(workingDirectory, "output", "rollback", "DropOracleHistTables.sql");
        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            foreach (var table in tables)
            {
                string ddl = oracleObj.DropOracleHistTable(table);
                sw.WriteLine(ddl);
            }
            sw.Close();
        }
    }

    private void CreateCfgAggregatorDML(List<PmTable> tables, int aggregatorid)
    {
        CfgAggregator cfgAggObj = new CfgAggregator();

        string outputPath = Path.Combine(workingDirectory, "output", "CreateCfgAggregatorDML.sql");
        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            foreach (var table in tables)
            {
                string ddl = cfgAggObj.CreateCfgAggregator(table, aggregatorid);
                sw.WriteLine(ddl);
                aggregatorid++;
            }
            sw.Close();
        }
    }

    private void DeleteCfgAggregatorDML(List<PmTable> tables)
    {
        CfgAggregator cfgAggObj = new CfgAggregator();

        string outputPath = Path.Combine(workingDirectory, "output", "rollback", "DeleteCfgAggregatorDML.sql");
        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            foreach (var table in tables)
            {
                string ddl = cfgAggObj.CrreateCfgAggregatorRollback(table);
                sw.WriteLine(ddl);
            }
            sw.Close();
        }
    }

    private List<PmTable> ReadInputFile()
    {
        var csvReaderConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture);
        csvReaderConfig.Delimiter = ";";
        csvReaderConfig.BadDataFound = null;
        csvReaderConfig.MissingFieldFound = null;


        string inputFilePath = Path.Combine(workingDirectory, InputFileName);

        using (var reader = new StreamReader(inputFilePath))
        using (var csv = new CsvReader(reader, csvReaderConfig))
        {
            return csv.GetRecords<PmTable>().ToList();
        }
    }
}