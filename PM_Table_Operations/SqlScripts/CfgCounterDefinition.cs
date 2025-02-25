
using PM_Table_Operations.Model;

namespace PM_Table_Operations
{
    public class CfgCounterDefinition
    {
        public string CreateCfgCounterDML(CounterDefinition obj, bool hashFlag)
        {
            if (hashFlag == true)
            {
                CounterHash objCHash = new CounterHash();
                objCHash.GetCounterHash(obj);
            }

            string agg = obj.Aggregation == "" ? "null" : $"\'{obj.Aggregation}\'";
            string line = ($"INSERT INTO PIADMIN.CFG_COUNTER_DEFINITION (RAW_TABLE_NAME,COUNTER_NAME,TIME_AGG_FUNCTION,COUNTER_ALIAS,COUNTER_OSS_NAME, COUNTER_LONG_NAME,SCHEMA_NAME,COUNTERSETNAME,DBCONNECTIONNAME,COUNTER_OSS_NAME_ORIGINAL) \r\nVALUES ('{obj.TableName}','{obj.CounterName}',{agg},'{obj.CounterName}','{obj.CounterOSSName}','{obj.CounterLongName}','pipm','{obj.TableName}','piworks-ch','{obj.CounterName}');\n");

            string line2 = ($"INSERT INTO PIADMIN.CFG_COUNTER_DEFINITION (RAW_TABLE_NAME,COUNTER_NAME,TIME_AGG_FUNCTION,COUNTER_ALIAS,COUNTER_OSS_NAME, COUNTER_LONG_NAME,SCHEMA_NAME,COUNTERSETNAME,DBCONNECTIONNAME,COUNTER_OSS_NAME_ORIGINAL,HWI_FUNCSET_ID,HWI_MU_ID) \r\nVALUES ('{obj.TableName}','{obj.CounterName}',{agg},'{obj.CounterName}','{obj.CounterOSSName}','{obj.CounterLongName}','pipm','{obj.TableName}','piworks-ch','{obj.CounterName.Substring(1)}',{obj.HwiFuncsetId},{obj.HwiMuId});\n");

            string line3 = ($"INSERT INTO PIADMIN.CFG_COUNTER_DEFINITION (RAW_TABLE_NAME,COUNTER_NAME,TIME_AGG_FUNCTION,COUNTER_ALIAS,COUNTER_OSS_NAME, COUNTER_LONG_NAME,SCHEMA_NAME,COUNTERSETNAME,DBCONNECTIONNAME,COUNTER_OSS_NAME_ORIGINAL) \r\nVALUES ('{obj.TableName}','COLLINTERVAL',NULL,'COLLINTERVAL','COLLINTERVAL','COLLINTERVAL','pipm','{obj.TableName}','piworks-ch','COLLINTERVAL');\n");

            return line;
        }

        public string DeleteFromCfgCounterDef(CounterDefinition obj)
        {
            string line = ($"DELETE FROM PIADMIN.CFG_COUNTER_DEFINITION WHERE RAW_TABLE_NAME = '{obj.TableName}' AND COUNTER_NAME = '{obj.CounterName}';");

            return line;
        }
    }

}


