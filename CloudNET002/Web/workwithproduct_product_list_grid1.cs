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
   public class workwithproduct_product_list_grid1 : GXProcedure
   {
      public workwithproduct_product_list_grid1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public workwithproduct_product_list_grid1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SearchText ,
                           short aP1_cProductTypeCode ,
                           long aP2_start ,
                           long aP3_count ,
                           int aP4_gxid ,
                           out GXBaseCollection<SdtWorkWithProduct_Product_List_Grid1Sdt_Item> aP5_GXM2RootCol )
      {
         this.AV9SearchText = aP0_SearchText;
         this.AV5cProductTypeCode = aP1_cProductTypeCode;
         this.AV7start = aP2_start;
         this.AV8count = aP3_count;
         this.AV6gxid = aP4_gxid;
         this.AV10GXM2RootCol = new GXBaseCollection<SdtWorkWithProduct_Product_List_Grid1Sdt_Item>( context, "WorkWithProduct_Product_List_Grid1Sdt.Item", "") ;
         initialize();
         executePrivate();
         aP5_GXM2RootCol=this.AV10GXM2RootCol;
      }

      public GXBaseCollection<SdtWorkWithProduct_Product_List_Grid1Sdt_Item> executeUdp( string aP0_SearchText ,
                                                                                         short aP1_cProductTypeCode ,
                                                                                         long aP2_start ,
                                                                                         long aP3_count ,
                                                                                         int aP4_gxid )
      {
         execute(aP0_SearchText, aP1_cProductTypeCode, aP2_start, aP3_count, aP4_gxid, out aP5_GXM2RootCol);
         return AV10GXM2RootCol ;
      }

      public void executeSubmit( string aP0_SearchText ,
                                 short aP1_cProductTypeCode ,
                                 long aP2_start ,
                                 long aP3_count ,
                                 int aP4_gxid ,
                                 out GXBaseCollection<SdtWorkWithProduct_Product_List_Grid1Sdt_Item> aP5_GXM2RootCol )
      {
         workwithproduct_product_list_grid1 objworkwithproduct_product_list_grid1;
         objworkwithproduct_product_list_grid1 = new workwithproduct_product_list_grid1();
         objworkwithproduct_product_list_grid1.AV9SearchText = aP0_SearchText;
         objworkwithproduct_product_list_grid1.AV5cProductTypeCode = aP1_cProductTypeCode;
         objworkwithproduct_product_list_grid1.AV7start = aP2_start;
         objworkwithproduct_product_list_grid1.AV8count = aP3_count;
         objworkwithproduct_product_list_grid1.AV6gxid = aP4_gxid;
         objworkwithproduct_product_list_grid1.AV10GXM2RootCol = new GXBaseCollection<SdtWorkWithProduct_Product_List_Grid1Sdt_Item>( context, "WorkWithProduct_Product_List_Grid1Sdt.Item", "") ;
         objworkwithproduct_product_list_grid1.context.SetSubmitInitialConfig(context);
         objworkwithproduct_product_list_grid1.initialize();
         Submit( executePrivateCatch,objworkwithproduct_product_list_grid1);
         aP5_GXM2RootCol=this.AV10GXM2RootCol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((workwithproduct_product_list_grid1)stateInfo).executePrivate();
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
         GXPagingFrom2 = (int)(AV7start);
         GXPagingTo2 = (int)(AV8count);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9SearchText ,
                                              AV5cProductTypeCode ,
                                              A2ProductName ,
                                              A5ProductTypeCode } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV9SearchText = StringUtil.Concat( StringUtil.RTrim( AV9SearchText), "%", "");
         /* Using cursor P00002 */
         pr_default.execute(0, new Object[] {lV9SearchText, AV5cProductTypeCode, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A5ProductTypeCode = P00002_A5ProductTypeCode[0];
            A2ProductName = P00002_A2ProductName[0];
            A40000ProductPhoto_GXI = P00002_A40000ProductPhoto_GXI[0];
            A1ProductCode = P00002_A1ProductCode[0];
            A7ProductPhoto = P00002_A7ProductPhoto[0];
            AV11GXM1WorkWithProduct_Product_List_Grid1Sdt = new SdtWorkWithProduct_Product_List_Grid1Sdt_Item(context);
            AV10GXM2RootCol.Add(AV11GXM1WorkWithProduct_Product_List_Grid1Sdt, 0);
            AV11GXM1WorkWithProduct_Product_List_Grid1Sdt.gxTpr_Productcode = A1ProductCode;
            AV11GXM1WorkWithProduct_Product_List_Grid1Sdt.gxTpr_Productphoto = A7ProductPhoto;
            AV11GXM1WorkWithProduct_Product_List_Grid1Sdt.gxTpr_Productphoto_gxi = A40000ProductPhoto_GXI;
            AV11GXM1WorkWithProduct_Product_List_Grid1Sdt.gxTpr_Productname = A2ProductName;
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

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         AV10GXM2RootCol = new GXBaseCollection<SdtWorkWithProduct_Product_List_Grid1Sdt_Item>( context, "WorkWithProduct_Product_List_Grid1Sdt.Item", "");
         scmdbuf = "";
         lV9SearchText = "";
         A2ProductName = "";
         P00002_A5ProductTypeCode = new short[1] ;
         P00002_A2ProductName = new string[] {""} ;
         P00002_A40000ProductPhoto_GXI = new string[] {""} ;
         P00002_A1ProductCode = new long[1] ;
         P00002_A7ProductPhoto = new string[] {""} ;
         A40000ProductPhoto_GXI = "";
         A7ProductPhoto = "";
         AV11GXM1WorkWithProduct_Product_List_Grid1Sdt = new SdtWorkWithProduct_Product_List_Grid1Sdt_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithproduct_product_list_grid1__default(),
            new Object[][] {
                new Object[] {
               P00002_A5ProductTypeCode, P00002_A2ProductName, P00002_A40000ProductPhoto_GXI, P00002_A1ProductCode, P00002_A7ProductPhoto
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV5cProductTypeCode ;
      private short A5ProductTypeCode ;
      private int AV6gxid ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private long AV7start ;
      private long AV8count ;
      private long A1ProductCode ;
      private string scmdbuf ;
      private string A2ProductName ;
      private string AV9SearchText ;
      private string lV9SearchText ;
      private string A40000ProductPhoto_GXI ;
      private string A7ProductPhoto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00002_A5ProductTypeCode ;
      private string[] P00002_A2ProductName ;
      private string[] P00002_A40000ProductPhoto_GXI ;
      private long[] P00002_A1ProductCode ;
      private string[] P00002_A7ProductPhoto ;
      private GXBaseCollection<SdtWorkWithProduct_Product_List_Grid1Sdt_Item> aP5_GXM2RootCol ;
      private GXBaseCollection<SdtWorkWithProduct_Product_List_Grid1Sdt_Item> AV10GXM2RootCol ;
      private SdtWorkWithProduct_Product_List_Grid1Sdt_Item AV11GXM1WorkWithProduct_Product_List_Grid1Sdt ;
   }

   public class workwithproduct_product_list_grid1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00002( IGxContext context ,
                                             string AV9SearchText ,
                                             short AV5cProductTypeCode ,
                                             string A2ProductName ,
                                             short A5ProductTypeCode )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ProductTypeCode], [ProductName], [ProductPhoto_GXI], [ProductCode], [ProductPhoto]";
         sFromString = " FROM [Product]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9SearchText)) )
         {
            AddWhere(sWhereString, "(UPPER([ProductName]) like '%' + UPPER(@lV9SearchText))");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV5cProductTypeCode) )
         {
            AddWhere(sWhereString, "([ProductTypeCode] = @AV5cProductTypeCode)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         sOrderString += " ORDER BY [ProductName]";
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
                     return conditional_P00002(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] );
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
          new ParDef("@lV9SearchText",GXType.VarChar,1000,0) ,
          new ParDef("@AV5cProductTypeCode",GXType.Int16,4,0) ,
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
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(3));
                return;
       }
    }

 }

}
