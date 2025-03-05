
using PM_Table_Operations.Model;

namespace PM_Table_Operations
{
    public class ClickHousePmTable
    {
        string customCounters = "";

        public void CreateCustomCounters(PmTable table, CounterType counterType, bool hashFlag)
        {
            List<string> Counters = table.Counters.Split(',').ToList();
            var sortedCounters = Counters.ToList();

            for (int i = 0; i < sortedCounters.Count; i++)
            {
                /*if (sortedCounters[i] != null && (sortedCounters[i].StartsWith("C", StringComparison.OrdinalIgnoreCase) || sortedCounters[i].StartsWith("M", StringComparison.OrdinalIgnoreCase)))*/
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
                            customCounters += $"    `{sortedCounters[i]}` Nullable(Float64) CODEC(ZSTD(1)),\n";
                        else
                            customCounters += $"    `{sortedCounters[i]}` LowCardinality(Nullable(String)) CODEC(ZSTD(9)),\n";
                    }
                    else
                    {
                        if (counterType == CounterType.Numeric)
                            customCounters += $"    `{sortedCounters[i]}` Nullable(Float64) CODEC(ZSTD(1))";
                        else
                            customCounters += $"    `{sortedCounters[i]}` LowCardinality(Nullable(String)) CODEC(ZSTD(9))";
                    }

                }
                else Console.WriteLine($"Please Check Counter: {table.TableName}:{sortedCounters[i]}");
            }
        }

        public string CreateClickHousePMTable(PmTable table, string mainColoums)
        {
            /*string sharding_key;
            if (table.Object_Type.Contains("CELL") || table.Object_Type.Contains("TRX") || table.Object_Type.Contains("HO"))
            {
                sharding_key = "CELLID";
            }
            else if (table.Object_Type.Contains("BS") || table.Object_Type.Contains("MRBTS") || table.Object_Type.Contains("BTS") || table.Object_Type.Contains("NODEB"))
            {
                sharding_key = "BSID";
            }
            else if (table.Object_Type.Contains("NODE") || table.Object_Type.Contains("RNC") || table.Object_Type.Contains("BSC"))
            {
                sharding_key = "NODEID";
            }
            else
            {
                sharding_key = $@"cityHash64('{table.TableName}')";
            }*/

            string DDL = $@"
-- RAW TABLES
-- pipm_etl.{table.TableName}_HOT_LOCAL definition

CREATE TABLE pipm_etl.{table.TableName}_HOT_LOCAL ON CLUSTER '{{cluster}}'
({mainColoums}
{customCounters}

)
ENGINE = ReplicatedReplacingMergeTree('/clickhouse/{{cluster}}/{{layer}}-{{shard}}/pipm_etl/{table.TableName}_HOT_LOCAL',
 '{{replica}}',
 INSERT_DATETIME)
PARTITION BY toYYYYMMDD(DATETIME)
PRIMARY KEY {table.PK}
ORDER BY {table.PK}
SETTINGS min_bytes_for_wide_part = '524G',
 index_granularity = 8192,
 min_age_to_force_merge_seconds = 7200,
 min_age_to_force_merge_on_partition_only = 1,
 merge_selecting_sleep_ms = 200000;


-- pipm_etl.{table.TableName}_COLD_LOCAL definition

CREATE TABLE pipm_etl.{table.TableName}_COLD_LOCAL ON CLUSTER '{{cluster}}' as pipm_etl.{table.TableName}_HOT_LOCAL
ENGINE = ReplicatedReplacingMergeTree('/clickhouse/{{cluster}}/{{layer}}-{{shard}}/pipm_etl/{table.TableName}_COLD_LOCAL',
 '{{replica}}',
 INSERT_DATETIME)
PARTITION BY toYYYYMM(DATETIME)
PRIMARY KEY {table.PK}
ORDER BY {table.PK}
TTL DATETIME + toIntervalDay(400)
SETTINGS min_bytes_for_wide_part = '524G',
 index_granularity = 8192,
 min_age_to_force_merge_seconds = 172800,
 min_age_to_force_merge_on_partition_only = 1,
 merge_selecting_sleep_ms = 200000;


-- pipm_etl.{table.TableName} definition

CREATE TABLE pipm_etl.{table.TableName} ON CLUSTER '{{cluster}}' as pipm_etl.{table.TableName}_HOT_LOCAL
ENGINE = Distributed('{{cluster}}',
 'pipm_etl',
 '{table.TableName}_HOT_LOCAL',
jumpConsistentHash(cityHash64('{table.TableName}'), 6));


-- pipm.{table.TableName} definition

CREATE TABLE pipm.{table.TableName} ON CLUSTER '{{cluster}}' as pipm_etl.{table.TableName}_HOT_LOCAL
ENGINE = Distributed('{{cluster}}',
 'pipm',
 'MERGE_{table.TableName}',
 rand());


-- pipm.MERGE_{table.TableName} definition

CREATE TABLE pipm.MERGE_{table.TableName} ON CLUSTER '{{cluster}}' as pipm_etl.{table.TableName}_HOT_LOCAL
ENGINE = Merge('pipm_etl',
 '^{table.TableName}_HOT_.+|^{table.TableName}_COLD_.+');


-- HIST TABLES

-- pipm_etl.HIST_{table.TableName}_HOT_LOCAL definition

CREATE TABLE pipm_etl.HIST_{table.TableName}_HOT_LOCAL ON CLUSTER '{{cluster}}' as pipm_etl.{table.TableName}_HOT_LOCAL
ENGINE = ReplicatedReplacingMergeTree('/clickhouse/{{cluster}}/{{layer}}-{{shard}}/pipm_etl/HIST_{table.TableName}_HOT_LOCAL',
 '{{replica}}',
 INSERT_DATETIME)
PARTITION BY toYYYYMMDD(DATETIME)
PRIMARY KEY {table.PK}
ORDER BY {table.PK}
SETTINGS min_bytes_for_wide_part = '524G',
 index_granularity = 8192,
 min_age_to_force_merge_seconds = 7200,
 min_age_to_force_merge_on_partition_only = 1,
 merge_selecting_sleep_ms = 200000;


-- pipm_etl.HIST_{table.TableName}_COLD_LOCAL definition

CREATE TABLE pipm_etl.HIST_{table.TableName}_COLD_LOCAL ON CLUSTER '{{cluster}}' as pipm_etl.{table.TableName}_HOT_LOCAL
ENGINE = ReplicatedReplacingMergeTree('/clickhouse/{{cluster}}/{{layer}}-{{shard}}/pipm_etl/HIST_{table.TableName}_COLD_LOCAL',
 '{{replica}}',
 INSERT_DATETIME)
PARTITION BY toYYYYMM(DATETIME)
PRIMARY KEY {table.PK}
ORDER BY {table.PK}
TTL DATETIME + toIntervalDay(1095)
SETTINGS min_bytes_for_wide_part = '524G',
 index_granularity = 8192,
 min_age_to_force_merge_seconds = 172800,
 min_age_to_force_merge_on_partition_only = 1,
 merge_selecting_sleep_ms = 200000;


-- pipm_etl.HIST_{table.TableName} definition

CREATE TABLE pipm_etl.HIST_{table.TableName} ON CLUSTER '{{cluster}}' as pipm_etl.{table.TableName}_HOT_LOCAL
ENGINE = Distributed('{{cluster}}',
 'pipm_etl',
 'HIST_{table.TableName}_HOT_LOCAL',
jumpConsistentHash(cityHash64('{table.TableName}'), 6));


-- pipm.HIST_{table.TableName} definition

CREATE TABLE pipm.HIST_{table.TableName} ON CLUSTER '{{cluster}}' as pipm_etl.{table.TableName}_HOT_LOCAL
ENGINE = Distributed('{{cluster}}',
 'pipm',
 'MERGE_HIST_{table.TableName}',
 rand());


-- pipm.MERGE_HIST_{table.TableName} definition

CREATE TABLE pipm.MERGE_HIST_{table.TableName} ON CLUSTER '{{cluster}}' as pipm_etl.{table.TableName}_HOT_LOCAL
ENGINE = Merge('pipm_etl',
 '^HIST_{table.TableName}_HOT_.+|^HIST_{table.TableName}_COLD_.+');

";

            return DDL;

        }


        public string DropClickHousePMTable(PmTable obj)
        {
            string newColoumn = $@"DROP TABLE pipm.{obj.TableName} ON CLUSTER '{{cluster}}';
DROP TABLE pipm.HIST_{obj.TableName} ON CLUSTER '{{cluster}}';
DROP TABLE pipm.MERGE_{obj.TableName} ON CLUSTER '{{cluster}}';
DROP TABLE pipm.MERGE_HIST_{obj.TableName} ON CLUSTER '{{cluster}}';
DROP TABLE pipm_etl.{obj.TableName} ON CLUSTER '{{cluster}}';
DROP TABLE pipm_etl.{obj.TableName}_HOT_LOCAL ON CLUSTER '{{cluster}}';
DROP TABLE pipm_etl.{obj.TableName}_COLD_LOCAL ON CLUSTER '{{cluster}}';
DROP TABLE pipm_etl.HIST_{obj.TableName} ON CLUSTER '{{cluster}}';
DROP TABLE pipm_etl.HIST_{obj.TableName}_HOT_LOCAL ON CLUSTER '{{cluster}}';
DROP TABLE pipm_etl.HIST_{obj.TableName}_COLD_LOCAL ON CLUSTER '{{cluster}}';
";
            return newColoumn;
        }

        public string TruncateChTables(PmTable obj)
        {
            string newColoumn = $@"
TRUNCATE TABLE pipm_etl.{obj.TableName}_HOT_LOCAL ON CLUSTER '{{cluster}}';
TRUNCATE TABLE pipm_etl.{obj.TableName}_COLD_LOCAL ON CLUSTER '{{cluster}}';
TRUNCATE TABLE pipm_etl.HIST_{obj.TableName}_HOT_LOCAL ON CLUSTER '{{cluster}}';
TRUNCATE TABLE pipm_etl.HIST_{obj.TableName}_COLD_LOCAL ON CLUSTER '{{cluster}}';
";
            return newColoumn;
        }
    }
}
