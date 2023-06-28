using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class sdsvc_workwithproduct_product_list : GXProcedure
   {
      public sdsvc_workwithproduct_product_list( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public sdsvc_workwithproduct_product_list( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         this.cleanup();
      }

      protected void S111( )
      {
         /* AfterFilterProductTypeCode Routine */
         returnInSub = false;
         /* Using cursor SDSVC_WORK2 */
         pr_default.execute(0, new Object[] {AV1Pmpt_producttypecode});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A5ProductTypeCode = SDSVC_WORK2_A5ProductTypeCode[0];
            A6ProductTypeName = SDSVC_WORK2_A6ProductTypeName[0];
            AV2Pmpt_producttypename = A6ProductTypeName;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      public GxUnknownObjectCollection AfterFilterProductTypeCode( short A5ProductTypeCode )
      {
         initialize();
         AV1Pmpt_producttypecode = A5ProductTypeCode;
         /* Execute user subroutine: AfterFilterProductTypeCode */
         S111 ();
         GxUnknownObjectCollection gxjsonarray = new GxUnknownObjectCollection();
         gxjsonarray.Add(StringUtil.RTrim( AV2Pmpt_producttypename));
         /* End function AfterFilterProductTypeCode */
         return gxjsonarray ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         scmdbuf = "";
         SDSVC_WORK2_A5ProductTypeCode = new short[1] ;
         SDSVC_WORK2_A6ProductTypeName = new string[] {""} ;
         A6ProductTypeName = "";
         AV2Pmpt_producttypename = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sdsvc_workwithproduct_product_list__default(),
            new Object[][] {
                new Object[] {
               SDSVC_WORK2_A5ProductTypeCode, SDSVC_WORK2_A6ProductTypeName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected short AV1Pmpt_producttypecode ;
      protected short A5ProductTypeCode ;
      protected string scmdbuf ;
      protected string A6ProductTypeName ;
      protected string AV2Pmpt_producttypename ;
      protected bool returnInSub ;
      protected IGxDataStore dsDefault ;
      protected IDataStoreProvider pr_default ;
      protected short[] SDSVC_WORK2_A5ProductTypeCode ;
      protected string[] SDSVC_WORK2_A6ProductTypeName ;
   }

   public class sdsvc_workwithproduct_product_list__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmSDSVC_WORK2;
          prmSDSVC_WORK2 = new Object[] {
          new ParDef("@AV1Pmpt_producttypecode",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("SDSVC_WORK2", "SELECT [ProductTypeCode], [ProductTypeName] FROM [ProductType] WHERE [ProductTypeCode] = @AV1Pmpt_producttypecode ORDER BY [ProductTypeCode] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmSDSVC_WORK2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                return;
       }
    }

 }

}
