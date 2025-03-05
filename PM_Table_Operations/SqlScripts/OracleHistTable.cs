
using PM_Table_Operations.Model;

namespace PM_Table_Operations
{

    public class OracleHistTable
    {

        string customCounters = "";

        public void CreateCustomCounters(PmTable table, CounterType counterType, bool hashFlag)
        {
            List<string> Counters = table.Counters.Split(',').ToList();
            var sortedCounters = Counters.ToList();
            for (int i = 0; i < sortedCounters.Count; i++)
            {
                 if (sortedCounters[i] != null)
                {
                    if (hashFlag == true)
                    {
                        CounterHash objCHash = new CounterHash();
                        sortedCounters[i] = objCHash.GetCounterHash(sortedCounters[i]);
                    }

                    if (sortedCounters.Count != i + 1)
                    {
                        if (counterType == CounterType.Numeric)
                            customCounters += $"    \"{sortedCounters[i]}\" NUMBER,\n";
                        else
                            customCounters += $"    \"{sortedCounters[i]}\" VARCHAR2(100),\n";
                    }
                    else
                    {
                        if (counterType == CounterType.Numeric)
                            customCounters += $"    \"{sortedCounters[i]}\" NUMBER\n";
                        else
                            customCounters += $"    \"{sortedCounters[i]}\" VARCHAR2(100)\n";
                    }

                }

            }
        }


        public string CreateOraHistTable(PmTable table, string mainColoums)
        {
            string TableName = $"HIST_{table.TableName}";
            string schema = "PIADMIN";


            string def = $@"PARTITION BY RANGE (""DATETIME"") INTERVAL (NUMTODSINTERVAL(1, 'DAY'))
(
    PARTITION ""P1"" VALUES LESS THAN (TO_DATE(' 2024-08-01 00:00:00', 'SYYYY-MM-DD HH24:MI:SS', 'NLS_CALENDAR=GREGORIAN'))
)
PARALLEL 4;
CREATE UNIQUE INDEX ""{schema}"".""{TableName}_PK"" ON ""{schema}"".""{TableName}"" {table.PK} LOCAL PARALLEL 4;
ALTER TABLE ""{schema}"".""{TableName}"" ADD CONSTRAINT ""{TableName}_PK""  PRIMARY KEY {table.PK} USING INDEX ""{schema}"".""{TableName}_PK""  ENABLE;";


            string HistTable = @$"-- {schema}.{TableName} definition
INSERT INTO DBA_RETENTIONS (TableName,DAYS_CLEANUP) VALUES('{TableName}', 1825);
CREATE TABLE ""{schema}"".""{TableName}"" 
   ({mainColoums}
{customCounters})
{def}";
            return HistTable;


        }

        public string DropOracleHistTable(PmTable obj)
        {
            return $@"DROP TABLE HIST_{obj.TableName} PURGE;";
        }
    }

}


