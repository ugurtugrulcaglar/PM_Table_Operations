
using PM_Table_Operations.Model;

namespace PM_Table_Operations
{
    public class CfgAggregator
    {
        public string CreateCfgAggregator(PmTable table, int aggregatorid)
        {
            string tecn = "";
            string nonCounterFields = "";
            string nonCounterFieldsfor4GCell = "CELL,CELLID,CELLMONAME,BASESTATION,BSID";
            string nonCounterFieldsfor4GCellChild = "CELL,CELLID,CELLMONAME,CHILDMONAME,BASESTATION,BSID";
            string nonCounterFieldsfor4GBS = "BASESTATION,BSID,BSMONAME";
            string nonCounterFieldsfor4GBSChild = "BASESTATION,BSID,BSMONAME,CHILDMONAME";
            string nonCounterFieldsforMRBTSChild = "BASESTATION,BSID,MRBTSMONAME,CHILDMONAME";
            string nonCounterFieldsforMRBTS = "BASESTATION,BSID,MRBTSMONAME";
            string nonCounterFieldsfor4GHO = "CELL,CELLID,CELLMONAME,NCELL,NCELLID,BASESTATION,BSID";
            string nonCounterFieldsfor2G3GCell = "CELL,CELLID,CELLMONAME,BASESTATION,BSID,NODE,NODEID";
            string nonCounterFieldsfor2G3GCellChild = "CELL,CELLID,CELLMONAME,CHILDMONAME,BASESTATION,BSID,NODE,NODEID";
            string nonCounterFieldsfor2G3GBS = "BASESTATION,BSID,BSMONAME,NODE,NODEID";
            string nonCounterFieldsfor2G3GBSChild = "BASESTATION,BSID,BSMONAME,NODE,NODEID,CHILDMONAME";
            string nonCounterFieldsfor2G3GHO = "CELL,CELLID,NCELL,NCELLID,BASESTATION,BSID,NODE,NODEID";
            string nonCounterFieldsfor2G3GNode = "NODE,NODEID,NODEMONAME";
            string nonCounterFieldsfor2G3GNodeChild = "NODE,NODEID,NODEMONAME,CHILDMONAME";
            string nonCounterFieldsfor2GTRX = "CELL,CELLID,TRX,TRXMONAME,BASESTATION,BSID,NODE,NODEID";
            string nonCounterFieldsfor2GTRXChild = "CELL,CELLID,TRX,TRXMONAME,CHILDMONAME,BASESTATION,BSID,NODE,NODEID";
            string nonCounterFieldsforCoreNode = "NODE,NODEID";
            string nonCounterFieldsforCoreEda = "NODE,NODEID,NODEINDEX,COREINDEX";

            switch (table.ObjectType)
            {
                case ObjectType._4G_Cell:
                    nonCounterFields = nonCounterFieldsfor4GCell;
                    tecn = "4G";
                    break;
                case ObjectType._4G_Cell_Child:
                    nonCounterFields = nonCounterFieldsfor4GCellChild;
                    tecn = "4G";
                    break;
                case ObjectType._4G_BS:
                    nonCounterFields = nonCounterFieldsfor4GBS;
                    tecn = "4G";
                    break;
                case ObjectType._4G_BS_Child:
                    nonCounterFields = nonCounterFieldsfor4GBSChild;
                    tecn = "4G";
                    break;
                case ObjectType.MRBTS:
                    nonCounterFields = nonCounterFieldsforMRBTS;
                    tecn = "4G";
                    break;
                case ObjectType.MRBTS_Child:
                    nonCounterFields = nonCounterFieldsforMRBTSChild;
                    tecn = "4G";
                    break;
                case ObjectType._4G_HO:
                    nonCounterFields = nonCounterFieldsfor4GHO;
                    tecn = "4G";
                    break;
                case ObjectType._3G_Cell:
                    nonCounterFields = nonCounterFieldsfor2G3GCell;
                    tecn = "3G";
                    break;
                case ObjectType._2G_Cell:
                    nonCounterFields = nonCounterFieldsfor2G3GCell;
                    tecn = "2G";
                    break;
                case ObjectType._3G_Cell_Child:
                    nonCounterFields = nonCounterFieldsfor2G3GCellChild;
                    tecn = "3G";
                    break;
                case ObjectType._2G_Cell_Child:
                    nonCounterFields = nonCounterFieldsfor2G3GCellChild;
                    tecn = "2G";
                    break;
                case ObjectType._3G_HO:
                    nonCounterFields = nonCounterFieldsfor2G3GHO;
                    tecn = "3G";
                    break;
                case ObjectType._2G_HO:
                    nonCounterFields = nonCounterFieldsfor2G3GHO;
                    tecn = "2G";
                    break;
                case ObjectType._3G_Node:
                    nonCounterFields = nonCounterFieldsfor2G3GNode;
                    tecn = "3G";
                    break;
                case ObjectType._2G_Node:
                    nonCounterFields = nonCounterFieldsfor2G3GNode;
                    tecn = "2G";
                    break;
                case ObjectType._3G_Node_Child:
                    nonCounterFields = nonCounterFieldsfor2G3GNodeChild;
                    tecn = "3G";
                    break;
                case ObjectType._2G_Node_Child:
                    nonCounterFields = nonCounterFieldsfor2G3GNodeChild;
                    tecn = "2G";
                    break;
                case ObjectType._3G_BS:
                    nonCounterFields = nonCounterFieldsfor2G3GBS;
                    tecn = "3G";
                    break;
                case ObjectType._2G_BS:
                    nonCounterFields = nonCounterFieldsfor2G3GBS;
                    tecn = "2G";
                    break;
                case ObjectType._3G_BS_Child:
                    nonCounterFields = nonCounterFieldsfor2G3GBSChild;
                    tecn = "3G";
                    break;
                case ObjectType._2G_BS_Child:
                    nonCounterFields = nonCounterFieldsfor2G3GBSChild;
                    tecn = "2G";
                    break;
                case ObjectType._2G_TRX_Child:
                    nonCounterFields = nonCounterFieldsfor2GTRX;
                    tecn = "2G";
                    break;
                case ObjectType._2G_TRX:
                    nonCounterFields = nonCounterFieldsfor2GTRXChild;
                    tecn = "2G";
                    break;
                case ObjectType.Core_Node:
                    nonCounterFields = nonCounterFieldsforCoreNode;
                    tecn = "Huawei CN";
                    break;
                case ObjectType.Core_EDA:
                    nonCounterFields = nonCounterFieldsforCoreEda;
                    tecn = "Ericsson EDA";
                    break;
                default:
                    throw new ArgumentException("Invalid Object_Type value");
            }


            string query = @$"INSERT INTO CFG_AGGREGATOR
(OID, AGGREGATORID, RAWTABLENAME, HISTTABLENAME, AGGREGATIONTYPE, ENABLED, KEYFIELDS, NONCOUNTERFIELDS, SKIPPEDFIELDS, NUMSPLITS, GROUPNAME, EXPORTTIMEOUT, IMPORTTIMEOUT, DESCRIPTION, TARGETDBS)
VALUES(28601, {aggregatorid}, '{table.TableName}', 'HIST_{table.TableName}', 'day', 1, 'SOURCE,MONAME', '{nonCounterFields}', 'INSERT_DATETIME', 1, '{tecn}', NULL, NULL, NULL, 'piworks-ch-etl,piworks-db');";

            return query;


        }

        public string CrreateCfgAggregatorRollback(PmTable table)
        {
            string query = @$"DELETE FROM CFG_AGGREGATOR WHERE RAWTABLENAME = '{table.TableName}';";
            return query;

        }
    }


}


