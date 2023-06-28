using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gx0020sd_level_detail_grid1 : GXProcedure
   {
      public gx0020sd_level_detail_grid1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public gx0020sd_level_detail_grid1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_pProductTypeCode ,
                           short aP1_cProductTypeCode ,
                           long aP2_start ,
                           long aP3_count ,
                           int aP4_gxid ,
                           out GXBaseCollection<SdtGx0020sd_Level_Detail_Grid1Sdt_Item> aP5_GXM2RootCol )
      {
         this.AV5pProductTypeCode = aP0_pProductTypeCode;
         this.AV11cProductTypeCode = aP1_cProductTypeCode;
         this.AV13start = aP2_start;
         this.AV14count = aP3_count;
         this.AV12gxid = aP4_gxid;
         this.AV15GXM2RootCol = new GXBaseCollection<SdtGx0020sd_Level_Detail_Grid1Sdt_Item>( context, "Gx0020sd_Level_Detail_Grid1Sdt.Item", "") ;
         initialize();
         executePrivate();
         aP5_GXM2RootCol=this.AV15GXM2RootCol;
      }

      public GXBaseCollection<SdtGx0020sd_Level_Detail_Grid1Sdt_Item> executeUdp( short aP0_pProductTypeCode ,
                                                                                  short aP1_cProductTypeCode ,
                                                                                  long aP2_start ,
                                                                                  long aP3_count ,
                                                                                  int aP4_gxid )
      {
         execute(aP0_pProductTypeCode, aP1_cProductTypeCode, aP2_start, aP3_count, aP4_gxid, out aP5_GXM2RootCol);
         return AV15GXM2RootCol ;
      }

      public void executeSubmit( short aP0_pProductTypeCode ,
                                 short aP1_cProductTypeCode ,
                                 long aP2_start ,
                                 long aP3_count ,
                                 int aP4_gxid ,
                                 out GXBaseCollection<SdtGx0020sd_Level_Detail_Grid1Sdt_Item> aP5_GXM2RootCol )
      {
         gx0020sd_level_detail_grid1 objgx0020sd_level_detail_grid1;
         objgx0020sd_level_detail_grid1 = new gx0020sd_level_detail_grid1();
         objgx0020sd_level_detail_grid1.AV5pProductTypeCode = aP0_pProductTypeCode;
         objgx0020sd_level_detail_grid1.AV11cProductTypeCode = aP1_cProductTypeCode;
         objgx0020sd_level_detail_grid1.AV13start = aP2_start;
         objgx0020sd_level_detail_grid1.AV14count = aP3_count;
         objgx0020sd_level_detail_grid1.AV12gxid = aP4_gxid;
         objgx0020sd_level_detail_grid1.AV15GXM2RootCol = new GXBaseCollection<SdtGx0020sd_Level_Detail_Grid1Sdt_Item>( context, "Gx0020sd_Level_Detail_Grid1Sdt.Item", "") ;
         objgx0020sd_level_detail_grid1.context.SetSubmitInitialConfig(context);
         objgx0020sd_level_detail_grid1.initialize();
         Submit( executePrivateCatch,objgx0020sd_level_detail_grid1);
         aP5_GXM2RootCol=this.AV15GXM2RootCol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gx0020sd_level_detail_grid1)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXPagingFrom2 = (int)(AV13start);
         GXPagingTo2 = (int)(AV14count);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11cProductTypeCode ,
                                              A5ProductTypeCode } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00002 */
         pr_default.execute(0, new Object[] {AV11cProductTypeCode, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A5ProductTypeCode = P00002_A5ProductTypeCode[0];
            AV16GXM1Gx0020sd_Level_Detail_Grid1Sdt = new SdtGx0020sd_Level_Detail_Grid1Sdt_Item(context);
            AV15GXM2RootCol.Add(AV16GXM1Gx0020sd_Level_Detail_Grid1Sdt, 0);
            AV16GXM1Gx0020sd_Level_Detail_Grid1Sdt.gxTpr_Producttypecode = A5ProductTypeCode;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV15GXM2RootCol = new GXBaseCollection<SdtGx0020sd_Level_Detail_Grid1Sdt_Item>( context, "Gx0020sd_Level_Detail_Grid1Sdt.Item", "");
         scmdbuf = "";
         P00002_A5ProductTypeCode = new short[1] ;
         AV16GXM1Gx0020sd_Level_Detail_Grid1Sdt = new SdtGx0020sd_Level_Detail_Grid1Sdt_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0020sd_level_detail_grid1__default(),
            new Object[][] {
                new Object[] {
               P00002_A5ProductTypeCode
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV5pProductTypeCode ;
      private short AV11cProductTypeCode ;
      private short A5ProductTypeCode ;
      private int AV12gxid ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private long AV13start ;
      private long AV14count ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00002_A5ProductTypeCode ;
      private GXBaseCollection<SdtGx0020sd_Level_Detail_Grid1Sdt_Item> aP5_GXM2RootCol ;
      private GXBaseCollection<SdtGx0020sd_Level_Detail_Grid1Sdt_Item> AV15GXM2RootCol ;
      private SdtGx0020sd_Level_Detail_Grid1Sdt_Item AV16GXM1Gx0020sd_Level_Detail_Grid1Sdt ;
   }

   public class gx0020sd_level_detail_grid1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00002( IGxContext context ,
                                             short AV11cProductTypeCode ,
                                             short A5ProductTypeCode )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ProductTypeCode]";
         sFromString = " FROM [ProductType]";
         sOrderString = "";
         if ( ! (0==AV11cProductTypeCode) )
         {
            AddWhere(sWhereString, "([ProductTypeCode] = @AV11cProductTypeCode)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY [ProductTypeCode]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00002(context, (short)dynConstraints[0] , (short)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00002;
          prmP00002 = new Object[] {
          new ParDef("@AV11cProductTypeCode",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00002", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
