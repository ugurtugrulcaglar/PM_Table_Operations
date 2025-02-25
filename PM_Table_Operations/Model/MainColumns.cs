
namespace PM_Table_Operations.Model
{
    public class mainColumns
    {
        public string getChMainColumns(PmTable table)
        {
            string mainColoumsCHfor4GCell = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `CELL` LowCardinality(String) CODEC(ZSTD(1)),
    `CELLID` Int64 CODEC(ZSTD(1)),
    `CELLMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `BASESTATION` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `BSID` Nullable(Int64) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHfor4GCellChild = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `CELL` LowCardinality(String) CODEC(ZSTD(1)),
    `CELLID` Int64 CODEC(ZSTD(1)),
    `CELLMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `CHILDMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `BASESTATION` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `BSID` Nullable(Int64) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHfor4GBS = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `BASESTATION` LowCardinality(String) CODEC(ZSTD(1)),
    `BSID` Int64 CODEC(ZSTD(1)),
    `BSMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHfor4GBSChild = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `BASESTATION` LowCardinality(String) CODEC(ZSTD(1)),
    `BSID` Int64 CODEC(ZSTD(1)),
    `BSMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `CHILDMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHforMRBTSChild = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `BASESTATION` LowCardinality(String) CODEC(ZSTD(1)),
    `BSID` Int64 CODEC(ZSTD(1)),
    `MRBTSMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `CHILDMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHforMRBTS = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `BASESTATION` LowCardinality(String) CODEC(ZSTD(1)),
    `BSID` Int64 CODEC(ZSTD(1)),
    `MRBTSMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHfor4GHO = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `CELL` LowCardinality(String) CODEC(ZSTD(1)),
    `CELLID` Int64 CODEC(ZSTD(1)),
    `CELLMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `NCELL` LowCardinality(String) CODEC(ZSTD(1)),
    `NCELLID` Int64 CODEC(ZSTD(1)),
    `BASESTATION` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `BSID` Nullable(Int64) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHfor2G3GCell = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `CELL` LowCardinality(String) CODEC(ZSTD(1)),
    `CELLID` Int64 CODEC(ZSTD(1)),
    `CELLMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `BASESTATION` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `BSID` Nullable(Int64) CODEC(ZSTD(1)),
    `NODE` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `NODEID` Nullable(Int64) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHfor2G3GCellChild = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `CELL` LowCardinality(String) CODEC(ZSTD(1)),
    `CELLID` Int64 CODEC(ZSTD(1)),
    `CELLMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `CHILDMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `BASESTATION` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `BSID` Nullable(Int64) CODEC(ZSTD(1)),
    `NODE` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `NODEID` Nullable(Int64) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHfor2G3GBS = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `BASESTATION` LowCardinality(String) CODEC(ZSTD(1)),
    `BSID` Int64 CODEC(ZSTD(1)),
    `BSMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `NODE` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `NODEID` Nullable(Int64) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHfor2G3GBSChild = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `BASESTATION` LowCardinality(String) CODEC(ZSTD(1)),
    `BSID` Int64 CODEC(ZSTD(1)),
    `BSMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `NODE` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `NODEID` Nullable(Int64) CODEC(ZSTD(1)),
    `CHILDMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHfor2G3GHO = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `CELL` LowCardinality(String) CODEC(ZSTD(1)),
    `CELLID` Int64 CODEC(ZSTD(1)),
    `NCELL` LowCardinality(String) CODEC(ZSTD(1)),
    `NCELLID` Int64 CODEC(ZSTD(1)),
    `BASESTATION` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `BSID` Nullable(Int64) CODEC(ZSTD(1)),
    `NODE` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `NODEID` Nullable(Int64) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHfor2G3GNode = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `NODE` LowCardinality(String) CODEC(ZSTD(1)),
    `NODEID` Int64 CODEC(ZSTD(1)),
    `NODEMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHfor2G3GNodeChild = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `NODE` LowCardinality(String) CODEC(ZSTD(1)),
    `NODEID` Int64 CODEC(ZSTD(1)),
    `NODEMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `CHILDMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHfor2GTRX = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `CELL` LowCardinality(String) CODEC(ZSTD(1)),
    `CELLID` Int64 CODEC(ZSTD(1)),
    `TRX` LowCardinality(String) CODEC(ZSTD(1)),
    `TRXMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `BASESTATION` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `BSID` Nullable(Int64) CODEC(ZSTD(1)),
    `NODE` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `NODEID` Nullable(Int64) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHfor2GTRXChild = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `CELL` LowCardinality(String) CODEC(ZSTD(1)),
    `CELLID` Int64 CODEC(ZSTD(1)),
    `TRX` LowCardinality(String) CODEC(ZSTD(1)),
    `TRXMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `CHILDMONAME` LowCardinality(String) CODEC(ZSTD(1)),
    `BASESTATION` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `BSID` Nullable(Int64) CODEC(ZSTD(1)),
    `NODE` LowCardinality(Nullable(String)) CODEC(ZSTD(1)),
    `NODEID` Nullable(Int64) CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHforCoreNode = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `NODE` LowCardinality(String) CODEC(ZSTD(1)),
    `NODEID` Int64 CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            string mainColoumsCHforCoreEda = $@"
    `DATETIME` DateTime CODEC(ZSTD(1)),
    `SOURCE` LowCardinality(String) CODEC(ZSTD(9)),
    `MONAME` LowCardinality(String) CODEC(ZSTD(9)),
    `NODE` LowCardinality(String) CODEC(ZSTD(1)),
    `NODEID` Int64 CODEC(ZSTD(1)),
    `NODEINDEX` Int64 CODEC(ZSTD(1)),
    `COREINDEX` Int64 CODEC(ZSTD(1)),
    `COLLINTERVAL` UInt16 CODEC(ZSTD(1)),
    `INSERT_DATETIME` DateTime DEFAULT now() CODEC(ZSTD(1)),
    `AGGRTD_ROW_COUNT` Nullable(Int64) CODEC(ZSTD(1)),";
            switch (table.ObjectType)
            {
                case ObjectType._4G_Cell:
                    return mainColoumsCHfor4GCell;
                case ObjectType._4G_Cell_Child:
                    return mainColoumsCHfor4GCellChild;
                case ObjectType._4G_BS:
                    return mainColoumsCHfor4GBS;
                case ObjectType._4G_BS_Child:
                    return mainColoumsCHfor4GBSChild;
                case ObjectType.MRBTS:
                    return mainColoumsCHforMRBTS;
                case ObjectType.MRBTS_Child:
                    return mainColoumsCHforMRBTSChild;
                case ObjectType._4G_HO:
                    return mainColoumsCHfor4GHO;
                case ObjectType._3G_Cell:
                case ObjectType._2G_Cell:
                    return mainColoumsCHfor2G3GCell;
                case ObjectType._3G_Cell_Child:
                case ObjectType._2G_Cell_Child:
                    return mainColoumsCHfor2G3GCellChild;
                case ObjectType._3G_HO:
                case ObjectType._2G_HO:
                    return mainColoumsCHfor2G3GHO;
                case ObjectType._3G_Node:
                case ObjectType._2G_Node:
                    return mainColoumsCHfor2G3GNode;
                case ObjectType._3G_Node_Child:
                case ObjectType._2G_Node_Child:
                    return mainColoumsCHfor2G3GNodeChild;
                case ObjectType._3G_BS:
                case ObjectType._2G_BS:
                    return mainColoumsCHfor2G3GBS;
                case ObjectType._3G_BS_Child:
                case ObjectType._2G_BS_Child:
                    return mainColoumsCHfor2G3GBSChild;
                case ObjectType._2G_TRX:
                    return mainColoumsCHfor2GTRX;
                case ObjectType._2G_TRX_Child:
                    return mainColoumsCHfor2GTRXChild;
                case ObjectType.Core_Node:
                    return mainColoumsCHforCoreNode;
                case ObjectType.Core_EDA:
                    return mainColoumsCHforCoreEda;
                default:
                    throw new ArgumentException("Invalid ObjectType value");
            }
        }
            public string getORacleMainColumns(PmTable table)
            {
                string mainColoumsOraclefor4GCell = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""CELL"" VARCHAR2(100) NOT NULL ENABLE, 
   ""CELLID"" NUMBER(12,0), 
   ""CELLMONAME"" VARCHAR2(500),
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOraclefor4GCellChild = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""CELL"" VARCHAR2(100) NOT NULL ENABLE, 
   ""CELLID"" NUMBER(12,0), 
   ""CELLMONAME"" VARCHAR2(500),
   ""CHILDMONAME"" VARCHAR2(500),
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOraclefor4GBS = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""BSMONAME"" VARCHAR2(500),
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOraclefor4GBSChild = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""BSMONAME"" VARCHAR2(500),
   ""CHILDMONAME"" VARCHAR2(500),
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOracleforMRBTSChild = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""MRBTSMONAME"" VARCHAR2(500),
   ""CHILDMONAME"" VARCHAR2(500),
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOracleforMRBTS = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""MRBTSMONAME"" VARCHAR2(500),
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOraclefor4GHO = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""CELL"" VARCHAR2(100) NOT NULL ENABLE, 
   ""CELLID"" NUMBER(12,0), 
   ""CELLMONAME"" VARCHAR2(500),
   ""NCELL"" VARCHAR2(100), 
   ""NCELLID"" NUMBER(12,0), 
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOraclefor2G3GCell = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""CELL"" VARCHAR2(100) NOT NULL ENABLE, 
   ""CELLID"" NUMBER(12,0), 
   ""CELLMONAME"" VARCHAR2(500),
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""NODE"" VARCHAR2(100), 
   ""NODEID"" NUMBER(12,0), 
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOraclefor2G3GCellChild = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""CELL"" VARCHAR2(100) NOT NULL ENABLE, 
   ""CELLID"" NUMBER(12,0), 
   ""CELLMONAME"" VARCHAR2(500),
   ""CHILDMONAME"" VARCHAR2(500),
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""NODE"" VARCHAR2(100), 
   ""NODEID"" NUMBER(12,0), 
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOraclefor2G3GBS = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""BSMONAME"" VARCHAR2(500),
   ""NODE"" VARCHAR2(100), 
   ""NODEID"" NUMBER(12,0), 
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOraclefor2G3GBSChild = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""BSMONAME"" VARCHAR2(500),
   ""NODE"" VARCHAR2(100), 
   ""NODEID"" NUMBER(12,0), 
   ""CHILDMONAME"" VARCHAR2(500),
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOraclefor2G3GHO = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""CELL"" VARCHAR2(100) NOT NULL ENABLE, 
   ""CELLID"" NUMBER(12,0), 
   ""NCELL"" VARCHAR2(100), 
   ""NCELLID"" NUMBER(12,0), 
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""NODE"" VARCHAR2(100), 
   ""NODEID"" NUMBER(12,0), 
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOraclefor2G3GNode = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""NODE"" VARCHAR2(100), 
   ""NODEID"" NUMBER(12,0), 
   ""NODEMONAME"" VARCHAR2(500),
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOraclefor2G3GNodeChild = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""NODE"" VARCHAR2(100), 
   ""NODEID"" NUMBER(12,0), 
   ""NODEMONAME"" VARCHAR2(500),
   ""CHILDMONAME"" VARCHAR2(500),
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOraclefor2GTRX = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""CELL"" VARCHAR2(100) NOT NULL ENABLE, 
   ""CELLID"" NUMBER(12,0), 
   ""TRX"" VARCHAR2(100), 
   ""TRXMONAME"" VARCHAR2(500),
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""NODE"" VARCHAR2(100), 
   ""NODEID"" NUMBER(12,0), 
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOraclefor2GTRXChild = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""CELL"" VARCHAR2(100) NOT NULL ENABLE, 
   ""CELLID"" NUMBER(12,0), 
   ""TRX"" VARCHAR2(100), 
   ""TRXMONAME"" VARCHAR2(500),
   ""CHILDMONAME"" VARCHAR2(500),
   ""BASESTATION"" VARCHAR2(100), 
   ""BSID"" NUMBER(12,0), 
   ""NODE"" VARCHAR2(100), 
   ""NODEID"" NUMBER(12,0), 
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOracleforCoreNode = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""NODE"" VARCHAR2(100), 
   ""NODEID"" NUMBER(12,0), 
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                string mainColoumsOracleforEda = $@"
   ""DATETIME"" DATE, 
   ""SOURCE"" VARCHAR2(100) NOT NULL ENABLE, 
   ""MONAME"" VARCHAR2(1000) NOT NULL ENABLE,
   ""NODE"" VARCHAR2(100), 
   ""NODEID"" NUMBER(12,0), 
   ""NODEINDEX"" NUMBER(12,0), 
   ""COREINDEX"" NUMBER(12,0), 
   ""COLLINTERVAL"" NUMBER(4,0) NOT NULL ENABLE, 
   ""INSERT_DATETIME"" DATE DEFAULT SYSDATE, 
   ""AGGRTD_ROW_COUNT"" NUMBER(4,0),";
                switch (table.ObjectType)
                {
                    case ObjectType._4G_Cell:
                        return mainColoumsOraclefor4GCell;
                    case ObjectType._4G_Cell_Child:
                        return mainColoumsOraclefor4GCellChild;
                    case ObjectType._4G_BS:
                        return mainColoumsOraclefor4GBS;
                    case ObjectType._4G_BS_Child:
                        return mainColoumsOraclefor4GBSChild;
                    case ObjectType.MRBTS:
                        return mainColoumsOracleforMRBTS;
                    case ObjectType.MRBTS_Child:
                        return mainColoumsOracleforMRBTSChild;
                    case ObjectType._4G_HO:
                        return mainColoumsOraclefor4GHO;
                    case ObjectType._3G_Cell:
                    case ObjectType._2G_Cell:
                        return mainColoumsOraclefor2G3GCell;
                    case ObjectType._3G_Cell_Child:
                    case ObjectType._2G_Cell_Child:
                        return mainColoumsOraclefor2G3GCellChild;
                    case ObjectType._3G_HO:
                    case ObjectType._2G_HO:
                        return mainColoumsOraclefor2G3GHO;
                    case ObjectType._3G_Node:
                    case ObjectType._2G_Node:
                        return mainColoumsOraclefor2G3GNode;
                    case ObjectType._3G_Node_Child:
                    case ObjectType._2G_Node_Child:
                        return mainColoumsOraclefor2G3GNodeChild;
                    case ObjectType._3G_BS:
                    case ObjectType._2G_BS:
                        return mainColoumsOraclefor2G3GBS;
                    case ObjectType._3G_BS_Child:
                    case ObjectType._2G_BS_Child:
                        return mainColoumsOraclefor2G3GBSChild;
                    case ObjectType._2G_TRX:
                        return mainColoumsOraclefor2GTRX;
                    case ObjectType._2G_TRX_Child:
                        return mainColoumsOraclefor2GTRXChild;
                    case ObjectType.Core_Node:
                        return mainColoumsOracleforCoreNode;
                    case ObjectType.Core_EDA:
                        return mainColoumsOracleforEda;
                    default:
                        throw new ArgumentException("Invalid ObjectType value");
                }

            }
        }
    }