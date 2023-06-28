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
   public class workwithproduct_product_section_general : GXProcedure
   {
      public workwithproduct_product_section_general( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public workwithproduct_product_section_general( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProductCode ,
                           int aP1_gxid ,
                           out SdtWorkWithProduct_Product_Section_GeneralSdt aP2_GXM1WorkWithProduct_Product_Section_GeneralSdt )
      {
         this.A1ProductCode = aP0_ProductCode;
         this.AV6gxid = aP1_gxid;
         this.AV7GXM1WorkWithProduct_Product_Section_GeneralSdt = new SdtWorkWithProduct_Product_Section_GeneralSdt(context) ;
         initialize();
         executePrivate();
         aP2_GXM1WorkWithProduct_Product_Section_GeneralSdt=this.AV7GXM1WorkWithProduct_Product_Section_GeneralSdt;
      }

      public SdtWorkWithProduct_Product_Section_GeneralSdt executeUdp( long aP0_ProductCode ,
                                                                       int aP1_gxid )
      {
         execute(aP0_ProductCode, aP1_gxid, out aP2_GXM1WorkWithProduct_Product_Section_GeneralSdt);
         return AV7GXM1WorkWithProduct_Product_Section_GeneralSdt ;
      }

      public void executeSubmit( long aP0_ProductCode ,
                                 int aP1_gxid ,
                                 out SdtWorkWithProduct_Product_Section_GeneralSdt aP2_GXM1WorkWithProduct_Product_Section_GeneralSdt )
      {
         workwithproduct_product_section_general objworkwithproduct_product_section_general;
         objworkwithproduct_product_section_general = new workwithproduct_product_section_general();
         objworkwithproduct_product_section_general.A1ProductCode = aP0_ProductCode;
         objworkwithproduct_product_section_general.AV6gxid = aP1_gxid;
         objworkwithproduct_product_section_general.AV7GXM1WorkWithProduct_Product_Section_GeneralSdt = new SdtWorkWithProduct_Product_Section_GeneralSdt(context) ;
         objworkwithproduct_product_section_general.context.SetSubmitInitialConfig(context);
         objworkwithproduct_product_section_general.initialize();
         Submit( executePrivateCatch,objworkwithproduct_product_section_general);
         aP2_GXM1WorkWithProduct_Product_Section_GeneralSdt=this.AV7GXM1WorkWithProduct_Product_Section_GeneralSdt;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((workwithproduct_product_section_general)stateInfo).executePrivate();
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
         /* Using cursor P00002 */
         pr_default.execute(0, new Object[] {A1ProductCode});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A40000ProductPhoto_GXI = P00002_A40000ProductPhoto_GXI[0];
            A2ProductName = P00002_A2ProductName[0];
            A3ProductPrice = P00002_A3ProductPrice[0];
            A4ProductStock = P00002_A4ProductStock[0];
            A5ProductTypeCode = P00002_A5ProductTypeCode[0];
            A6ProductTypeName = P00002_A6ProductTypeName[0];
            A7ProductPhoto = P00002_A7ProductPhoto[0];
            A6ProductTypeName = P00002_A6ProductTypeName[0];
            AV7GXM1WorkWithProduct_Product_Section_GeneralSdt.gxTpr_Productcode = A1ProductCode;
            AV7GXM1WorkWithProduct_Product_Section_GeneralSdt.gxTpr_Productname = A2ProductName;
            AV7GXM1WorkWithProduct_Product_Section_GeneralSdt.gxTpr_Productprice = A3ProductPrice;
            AV7GXM1WorkWithProduct_Product_Section_GeneralSdt.gxTpr_Productstock = A4ProductStock;
            AV7GXM1WorkWithProduct_Product_Section_GeneralSdt.gxTpr_Producttypecode = A5ProductTypeCode;
            AV7GXM1WorkWithProduct_Product_Section_GeneralSdt.gxTpr_Producttypename = A6ProductTypeName;
            AV7GXM1WorkWithProduct_Product_Section_GeneralSdt.gxTpr_Productphoto = A7ProductPhoto;
            AV7GXM1WorkWithProduct_Product_Section_GeneralSdt.gxTpr_Productphoto_gxi = A40000ProductPhoto_GXI;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         AV7GXM1WorkWithProduct_Product_Section_GeneralSdt = new SdtWorkWithProduct_Product_Section_GeneralSdt(context);
         scmdbuf = "";
         P00002_A1ProductCode = new long[1] ;
         P00002_A40000ProductPhoto_GXI = new string[] {""} ;
         P00002_A2ProductName = new string[] {""} ;
         P00002_A3ProductPrice = new decimal[1] ;
         P00002_A4ProductStock = new short[1] ;
         P00002_A5ProductTypeCode = new short[1] ;
         P00002_A6ProductTypeName = new string[] {""} ;
         P00002_A7ProductPhoto = new string[] {""} ;
         A40000ProductPhoto_GXI = "";
         A2ProductName = "";
         A6ProductTypeName = "";
         A7ProductPhoto = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithproduct_product_section_general__default(),
            new Object[][] {
                new Object[] {
               P00002_A1ProductCode, P00002_A40000ProductPhoto_GXI, P00002_A2ProductName, P00002_A3ProductPrice, P00002_A4ProductStock, P00002_A5ProductTypeCode, P00002_A6ProductTypeName, P00002_A7ProductPhoto
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A4ProductStock ;
      private short A5ProductTypeCode ;
      private int AV6gxid ;
      private long A1ProductCode ;
      private decimal A3ProductPrice ;
      private string scmdbuf ;
      private string A2ProductName ;
      private string A6ProductTypeName ;
      private string A40000ProductPhoto_GXI ;
      private string A7ProductPhoto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00002_A1ProductCode ;
      private string[] P00002_A40000ProductPhoto_GXI ;
      private string[] P00002_A2ProductName ;
      private decimal[] P00002_A3ProductPrice ;
      private short[] P00002_A4ProductStock ;
      private short[] P00002_A5ProductTypeCode ;
      private string[] P00002_A6ProductTypeName ;
      private string[] P00002_A7ProductPhoto ;
      private SdtWorkWithProduct_Product_Section_GeneralSdt aP2_GXM1WorkWithProduct_Product_Section_GeneralSdt ;
      private SdtWorkWithProduct_Product_Section_GeneralSdt AV7GXM1WorkWithProduct_Product_Section_GeneralSdt ;
   }

   public class workwithproduct_product_section_general__default : DataStoreHelperBase, IDataStoreHelper
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
              new CursorDef("P00002", "SELECT TOP 1 T1.[ProductCode], T1.[ProductPhoto_GXI], T1.[ProductName], T1.[ProductPrice], T1.[ProductStock], T1.[ProductTypeCode], T2.[ProductTypeName], T1.[ProductPhoto] FROM ([Product] T1 INNER JOIN [ProductType] T2 ON T2.[ProductTypeCode] = T1.[ProductTypeCode]) WHERE T1.[ProductCode] = @ProductCode ORDER BY T1.[ProductCode] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00002,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 50);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(2));
                return;
       }
    }

 }

}
