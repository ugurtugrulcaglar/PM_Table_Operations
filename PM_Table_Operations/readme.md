# PM_Table_Operations

PM_Table_Operations is a console application designed to automate VantagePm database operations through two main functionalities:

    `CreateTable`: Generates ClickHouse PM Tables DDL, Creating Oracle History Tables DDL, Cfg_Aggregator DMLs, and all their rollback data. 
                   Multiple table types can be generated concurrently.
    `CreateCounterDefinitionDml`: Generates CFG_COUNTER_DEFINITION DMLs and its rollback data.

##How It Works:

The application starts by parsing the command-line arguments defined in the CliArguments class. Based on the selected operation type, it then:

    Reads the specified input file.
    Processes the input data.
    Generates the corresponding SQL statements:
        `CreateTable`: Produces DDL for table creation.
        `CreateCounterDefinitionDml`: Produces DML for counter definitions.

Both functionalities require input file. You can find example files in the following directory:
`\ExampleInputFiles`

`output files` under the `Output` folder in the working directory.

The application accepts the following command-line options:

    -t, --operation-type (required):
    Specifies the type of operation. Allowed values:
        `CreateTable`
        `CreateCounterDefinitionDml`

    -i, --input-file-name (required):
    Specifies the input file containing the necessary data. The file must be located in the working directory, e.g., `\bin\Debug\net8.0`

    -c, --counter-type (required):
    Specifies the counter type. Allowed values:
        `Numeric (or N)`
        `String (or S)`

    -h, --hash-flag (optional):
    Determines whether to hash columns.
        Use `1` for hashing columns.
        Use `0` for no hashing.

Example Commands

## Example for creating tables:
`dotnet run -- -t CreateTable -i path/to/your/inputfile.txt -c Numeric`

## Example for creating counter definition DML:
`dotnet run -- -t CreateCounterDefinitionDml -i inputCfgCounter.csv -c String -h 1`
