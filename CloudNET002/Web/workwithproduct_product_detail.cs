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
   public class workwithproduct_product_detail : GXProcedure
   {
      public workwithproduct_product_detail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public workwithproduct_product_detail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProductCode ,
                           int aP1_gxid ,
                           out SdtWorkWithProduct_Product_DetailSdt aP2_GXM2WorkWithProduct_Product_DetailSdt )
      {
         this.A1ProductCode = aP0_ProductCode;
         this.AV7gxid = aP1_gxid;
         this.AV12GXM2WorkWithProduct_Product_DetailSdt = new SdtWorkWithProduct_Product_DetailSdt(context) ;
         initialize();
         executePrivate();
         aP2_GXM2WorkWithProduct_Product_DetailSdt=this.AV12GXM2WorkWithProduct_Product_DetailSdt;
      }

      public SdtWorkWithProduct_Product_DetailSdt executeUdp( long aP0_ProductCode ,
                                                              int aP1_gxid )
      {
         execute(aP0_ProductCode, aP1_gxid, out aP2_GXM2WorkWithProduct_Product_DetailSdt);
         return AV12GXM2WorkWithProduct_Product_DetailSdt ;
      }

      public void executeSubmit( long aP0_ProductCode ,
                                 int aP1_gxid ,
                                 out SdtWorkWithProduct_Product_DetailSdt aP2_GXM2WorkWithProduct_Product_DetailSdt )
      {
         workwithproduct_product_detail objworkwithproduct_product_detail;
         objworkwithproduct_product_detail = new workwithproduct_product_detail();
         objworkwithproduct_product_detail.A1ProductCode = aP0_ProductCode;
         objworkwithproduct_product_detail.AV7gxid = aP1_gxid;
         objworkwithproduct_product_detail.AV12GXM2WorkWithProduct_Product_DetailSdt = new SdtWorkWithProduct_Product_DetailSdt(context) ;
         objworkwithproduct_product_detail.context.SetSubmitInitialConfig(context);
         objworkwithproduct_product_detail.initialize();
         Submit( executePrivateCatch,objworkwithproduct_product_detail);
         aP2_GXM2WorkWithProduct_Product_DetailSdt=this.AV12GXM2WorkWithProduct_Product_DetailSdt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((workwithproduct_product_detail)stateInfo).executePrivate();
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
         Gxids = "gxid_" + StringUtil.Str( (decimal)(AV7gxid), 8, 0);
         if ( StringUtil.StrCmp(Gxwebsession.Get(Gxids), "") == 0 )
         {
            /* Using cursor P00002 */
            pr_default.execute(0, new Object[] {A1ProductCode});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A2ProductName = P00002_A2ProductName[0];
               Gxdynprop1 = A2ProductName;
               Gxdynprop += ((StringUtil.StrCmp(Gxdynprop, "")==0) ? "" : ", ") + "[\"Form\",\"Caption\",\"" + StringUtil.JSONEncode( Gxdynprop1) + "\"]";
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            Gxwebsession.Set(Gxids, "true");
         }
         AV12GXM2WorkWithProduct_Product_DetailSdt.gxTpr_Gxdynprop = "[ "+Gxdynprop+" ]";
         Gxdynprop = "";
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
         AV12GXM2WorkWithProduct_Product_DetailSdt = new SdtWorkWithProduct_Product_DetailSdt(context);
         Gxids = "";
         Gxwebsession = context.GetSession();
         scmdbuf = "";
         P00002_A1ProductCode = new long[1] ;
         P00002_A2ProductName = new string[] {""} ;
         A2ProductName = "";
         Gxdynprop1 = "";
         Gxdynprop = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithproduct_product_detail__default(),
            new Object[][] {
                new Object[] {
               P00002_A1ProductCode, P00002_A2ProductName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV7gxid ;
      private long A1ProductCode ;
      private string Gxids ;
      private string scmdbuf ;
      private string A2ProductName ;
      private string Gxdynprop1 ;
      private string Gxdynprop ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00002_A1ProductCode ;
      private string[] P00002_A2ProductName ;
      private SdtWorkWithProduct_Product_DetailSdt aP2_GXM2WorkWithProduct_Product_DetailSdt ;
      private IGxSession Gxwebsession ;
      private SdtWorkWithProduct_Product_DetailSdt AV12GXM2WorkWithProduct_Product_DetailSdt ;
   }

   public class workwithproduct_product_detail__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00002", "SELECT [ProductCode], [ProductName] FROM [Product] WHERE [ProductCode] = @ProductCode ORDER BY [ProductCode] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                return;
       }
    }

 }

}
