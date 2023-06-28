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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class product_bc : GxSilentTrn, IGxSilentTrn
   {
      public product_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Phamarcy", true);
      }

      public product_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public GXBCCollection<SdtProduct> GetAll( int Start ,
                                                int Count )
      {
         GXPagingFrom1 = Start;
         GXPagingTo1 = Count;
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {GXPagingFrom1, GXPagingTo1});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
            A1ProductCode = BC00015_A1ProductCode[0];
            A2ProductName = BC00015_A2ProductName[0];
            A3ProductPrice = BC00015_A3ProductPrice[0];
            A4ProductStock = BC00015_A4ProductStock[0];
            A6ProductTypeName = BC00015_A6ProductTypeName[0];
            A40000ProductPhoto_GXI = BC00015_A40000ProductPhoto_GXI[0];
            A5ProductTypeCode = BC00015_A5ProductTypeCode[0];
            A7ProductPhoto = BC00015_A7ProductPhoto[0];
         }
         bcProduct = new SdtProduct(context);
         gx_restcollection.Clear();
         while ( RcdFound1 != 0 )
         {
            OnLoadActions011( ) ;
            AddRow011( ) ;
            gx_sdt_item = (SdtProduct)(bcProduct.Clone());
            gx_restcollection.Add(gx_sdt_item, 0);
            pr_default.readNext(3);
            RcdFound1 = 0;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            if ( (pr_default.getStatus(3) != 101) )
            {
               RcdFound1 = 1;
               A1ProductCode = BC00015_A1ProductCode[0];
               A2ProductName = BC00015_A2ProductName[0];
               A3ProductPrice = BC00015_A3ProductPrice[0];
               A4ProductStock = BC00015_A4ProductStock[0];
               A6ProductTypeName = BC00015_A6ProductTypeName[0];
               A40000ProductPhoto_GXI = BC00015_A40000ProductPhoto_GXI[0];
               A5ProductTypeCode = BC00015_A5ProductTypeCode[0];
               A7ProductPhoto = BC00015_A7ProductPhoto[0];
            }
            Gx_mode = sMode1;
         }
         pr_default.close(3);
         /* Load Subordinate Levels */
         return gx_restcollection ;
      }

      protected void SETSEUDOVARS( )
      {
         ZM011( 0) ;
      }

      public void GetInsDefault( )
      {
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1ProductCode = A1ProductCode;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               if ( AnyError == 0 )
               {
                  ZM011( 4) ;
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12012( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11012( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z2ProductName = A2ProductName;
            Z3ProductPrice = A3ProductPrice;
            Z4ProductStock = A4ProductStock;
            Z5ProductTypeCode = A5ProductTypeCode;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z6ProductTypeName = A6ProductTypeName;
         }
         if ( GX_JID == -3 )
         {
            Z1ProductCode = A1ProductCode;
            Z2ProductName = A2ProductName;
            Z3ProductPrice = A3ProductPrice;
            Z4ProductStock = A4ProductStock;
            Z7ProductPhoto = A7ProductPhoto;
            Z40000ProductPhoto_GXI = A40000ProductPhoto_GXI;
            Z5ProductTypeCode = A5ProductTypeCode;
            Z6ProductTypeName = A6ProductTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load011( )
      {
         /* Using cursor BC00016 */
         pr_default.execute(4, new Object[] {A1ProductCode});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound1 = 1;
            A2ProductName = BC00016_A2ProductName[0];
            A3ProductPrice = BC00016_A3ProductPrice[0];
            A4ProductStock = BC00016_A4ProductStock[0];
            A6ProductTypeName = BC00016_A6ProductTypeName[0];
            A40000ProductPhoto_GXI = BC00016_A40000ProductPhoto_GXI[0];
            A5ProductTypeCode = BC00016_A5ProductTypeCode[0];
            A7ProductPhoto = BC00016_A7ProductPhoto[0];
            ZM011( -3) ;
         }
         pr_default.close(4);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2ProductName)) )
         {
            GX_msglist.addItem("The product name cannot e empty", 1, "");
            AnyError = 1;
         }
         if ( (Convert.ToDecimal(0)==A3ProductPrice) )
         {
            GX_msglist.addItem("The product price is empty", 0, "");
         }
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A5ProductTypeCode});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Product Type'.", "ForeignKeyNotFound", 1, "PRODUCTTYPECODE");
            AnyError = 1;
         }
         A6ProductTypeName = BC00014_A6ProductTypeName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00017 */
         pr_default.execute(5, new Object[] {A1ProductCode});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {A1ProductCode});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 3) ;
            RcdFound1 = 1;
            A1ProductCode = BC00013_A1ProductCode[0];
            A2ProductName = BC00013_A2ProductName[0];
            A3ProductPrice = BC00013_A3ProductPrice[0];
            A4ProductStock = BC00013_A4ProductStock[0];
            A40000ProductPhoto_GXI = BC00013_A40000ProductPhoto_GXI[0];
            A5ProductTypeCode = BC00013_A5ProductTypeCode[0];
            A7ProductPhoto = BC00013_A7ProductPhoto[0];
            Z1ProductCode = A1ProductCode;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_010( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {A1ProductCode});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2ProductName, BC00012_A2ProductName[0]) != 0 ) || ( Z3ProductPrice != BC00012_A3ProductPrice[0] ) || ( Z4ProductStock != BC00012_A4ProductStock[0] ) || ( Z5ProductTypeCode != BC00012_A5ProductTypeCode[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Product"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00018 */
                     pr_default.execute(6, new Object[] {A1ProductCode, A2ProductName, A3ProductPrice, A4ProductStock, A7ProductPhoto, A40000ProductPhoto_GXI, A5ProductTypeCode});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Product");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00019 */
                     pr_default.execute(7, new Object[] {A2ProductName, A3ProductPrice, A4ProductStock, A5ProductTypeCode, A1ProductCode});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Product");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000110 */
            pr_default.execute(8, new Object[] {A7ProductPhoto, A40000ProductPhoto_GXI, A1ProductCode});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("Product");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000111 */
                  pr_default.execute(9, new Object[] {A1ProductCode});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Product");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000112 */
            pr_default.execute(10, new Object[] {A5ProductTypeCode});
            A6ProductTypeName = BC000112_A6ProductTypeName[0];
            pr_default.close(10);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart011( )
      {
         /* Scan By routine */
         /* Using cursor BC000113 */
         pr_default.execute(11, new Object[] {A1ProductCode});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound1 = 1;
            A1ProductCode = BC000113_A1ProductCode[0];
            A2ProductName = BC000113_A2ProductName[0];
            A3ProductPrice = BC000113_A3ProductPrice[0];
            A4ProductStock = BC000113_A4ProductStock[0];
            A6ProductTypeName = BC000113_A6ProductTypeName[0];
            A40000ProductPhoto_GXI = BC000113_A40000ProductPhoto_GXI[0];
            A5ProductTypeCode = BC000113_A5ProductTypeCode[0];
            A7ProductPhoto = BC000113_A7ProductPhoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound1 = 1;
            A1ProductCode = BC000113_A1ProductCode[0];
            A2ProductName = BC000113_A2ProductName[0];
            A3ProductPrice = BC000113_A3ProductPrice[0];
            A4ProductStock = BC000113_A4ProductStock[0];
            A6ProductTypeName = BC000113_A6ProductTypeName[0];
            A40000ProductPhoto_GXI = BC000113_A40000ProductPhoto_GXI[0];
            A5ProductTypeCode = BC000113_A5ProductTypeCode[0];
            A7ProductPhoto = BC000113_A7ProductPhoto[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bcProduct) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bcProduct, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A2ProductName = "";
         A3ProductPrice = 0;
         A4ProductStock = 0;
         A5ProductTypeCode = 0;
         A6ProductTypeName = "";
         A7ProductPhoto = "";
         A40000ProductPhoto_GXI = "";
         Z2ProductName = "";
         Z3ProductPrice = 0;
         Z4ProductStock = 0;
         Z5ProductTypeCode = 0;
      }

      protected void InitAll011( )
      {
         A1ProductCode = 0;
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow1( SdtProduct obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Productname = A2ProductName;
         obj1.gxTpr_Productprice = A3ProductPrice;
         obj1.gxTpr_Productstock = A4ProductStock;
         obj1.gxTpr_Producttypecode = A5ProductTypeCode;
         obj1.gxTpr_Producttypename = A6ProductTypeName;
         obj1.gxTpr_Productphoto = A7ProductPhoto;
         obj1.gxTpr_Productphoto_gxi = A40000ProductPhoto_GXI;
         obj1.gxTpr_Productcode = A1ProductCode;
         obj1.gxTpr_Productcode_Z = Z1ProductCode;
         obj1.gxTpr_Productname_Z = Z2ProductName;
         obj1.gxTpr_Productprice_Z = Z3ProductPrice;
         obj1.gxTpr_Productstock_Z = Z4ProductStock;
         obj1.gxTpr_Producttypecode_Z = Z5ProductTypeCode;
         obj1.gxTpr_Producttypename_Z = Z6ProductTypeName;
         obj1.gxTpr_Productphoto_gxi_Z = Z40000ProductPhoto_GXI;
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( SdtProduct obj1 )
      {
         obj1.gxTpr_Productcode = A1ProductCode;
         return  ;
      }

      public void RowToVars1( SdtProduct obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A2ProductName = obj1.gxTpr_Productname;
         A3ProductPrice = obj1.gxTpr_Productprice;
         A4ProductStock = obj1.gxTpr_Productstock;
         A5ProductTypeCode = obj1.gxTpr_Producttypecode;
         A6ProductTypeName = obj1.gxTpr_Producttypename;
         A7ProductPhoto = obj1.gxTpr_Productphoto;
         A40000ProductPhoto_GXI = obj1.gxTpr_Productphoto_gxi;
         A1ProductCode = obj1.gxTpr_Productcode;
         Z1ProductCode = obj1.gxTpr_Productcode_Z;
         Z2ProductName = obj1.gxTpr_Productname_Z;
         Z3ProductPrice = obj1.gxTpr_Productprice_Z;
         Z4ProductStock = obj1.gxTpr_Productstock_Z;
         Z5ProductTypeCode = obj1.gxTpr_Producttypecode_Z;
         Z6ProductTypeName = obj1.gxTpr_Producttypename_Z;
         Z40000ProductPhoto_GXI = obj1.gxTpr_Productphoto_gxi_Z;
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1ProductCode = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1ProductCode = A1ProductCode;
         }
         ZM011( -3) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars1( bcProduct, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1ProductCode = A1ProductCode;
         }
         ZM011( -3) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1ProductCode != Z1ProductCode )
               {
                  A1ProductCode = Z1ProductCode;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update011( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A1ProductCode != Z1ProductCode )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcProduct, 1) ;
         SaveImpl( ) ;
         VarsToRow1( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcProduct, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow1( bcProduct) ;
         }
         else
         {
            SdtProduct auxBC = new SdtProduct(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1ProductCode);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcProduct);
               auxBC.Save();
               bcProduct.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcProduct, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcProduct, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow1( bcProduct) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow1( bcProduct) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcProduct, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1ProductCode != Z1ProductCode )
            {
               A1ProductCode = Z1ProductCode;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A1ProductCode != Z1ProductCode )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(10);
         context.RollbackDataStores("product_bc",pr_default);
         VarsToRow1( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcProduct.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcProduct.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcProduct )
         {
            bcProduct = (SdtProduct)(sdt);
            if ( StringUtil.StrCmp(bcProduct.gxTpr_Mode, "") == 0 )
            {
               bcProduct.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcProduct) ;
            }
            else
            {
               RowToVars1( bcProduct, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcProduct.gxTpr_Mode, "") == 0 )
            {
               bcProduct.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcProduct, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtProduct Product_BC
      {
         get {
            return bcProduct ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(10);
      }

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         BC00015_A1ProductCode = new long[1] ;
         BC00015_A2ProductName = new string[] {""} ;
         BC00015_A3ProductPrice = new decimal[1] ;
         BC00015_A4ProductStock = new short[1] ;
         BC00015_A6ProductTypeName = new string[] {""} ;
         BC00015_A40000ProductPhoto_GXI = new string[] {""} ;
         BC00015_A5ProductTypeCode = new short[1] ;
         BC00015_A7ProductPhoto = new string[] {""} ;
         A2ProductName = "";
         A6ProductTypeName = "";
         A40000ProductPhoto_GXI = "";
         A7ProductPhoto = "";
         gx_restcollection = new GXBCCollection<SdtProduct>( context, "Product", "Phamarcy");
         sMode1 = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z2ProductName = "";
         Z6ProductTypeName = "";
         Z7ProductPhoto = "";
         Z40000ProductPhoto_GXI = "";
         BC00016_A1ProductCode = new long[1] ;
         BC00016_A2ProductName = new string[] {""} ;
         BC00016_A3ProductPrice = new decimal[1] ;
         BC00016_A4ProductStock = new short[1] ;
         BC00016_A6ProductTypeName = new string[] {""} ;
         BC00016_A40000ProductPhoto_GXI = new string[] {""} ;
         BC00016_A5ProductTypeCode = new short[1] ;
         BC00016_A7ProductPhoto = new string[] {""} ;
         BC00014_A6ProductTypeName = new string[] {""} ;
         BC00017_A1ProductCode = new long[1] ;
         BC00013_A1ProductCode = new long[1] ;
         BC00013_A2ProductName = new string[] {""} ;
         BC00013_A3ProductPrice = new decimal[1] ;
         BC00013_A4ProductStock = new short[1] ;
         BC00013_A40000ProductPhoto_GXI = new string[] {""} ;
         BC00013_A5ProductTypeCode = new short[1] ;
         BC00013_A7ProductPhoto = new string[] {""} ;
         BC00012_A1ProductCode = new long[1] ;
         BC00012_A2ProductName = new string[] {""} ;
         BC00012_A3ProductPrice = new decimal[1] ;
         BC00012_A4ProductStock = new short[1] ;
         BC00012_A40000ProductPhoto_GXI = new string[] {""} ;
         BC00012_A5ProductTypeCode = new short[1] ;
         BC00012_A7ProductPhoto = new string[] {""} ;
         BC000112_A6ProductTypeName = new string[] {""} ;
         BC000113_A1ProductCode = new long[1] ;
         BC000113_A2ProductName = new string[] {""} ;
         BC000113_A3ProductPrice = new decimal[1] ;
         BC000113_A4ProductStock = new short[1] ;
         BC000113_A6ProductTypeName = new string[] {""} ;
         BC000113_A40000ProductPhoto_GXI = new string[] {""} ;
         BC000113_A5ProductTypeCode = new short[1] ;
         BC000113_A7ProductPhoto = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.product_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A1ProductCode, BC00012_A2ProductName, BC00012_A3ProductPrice, BC00012_A4ProductStock, BC00012_A40000ProductPhoto_GXI, BC00012_A5ProductTypeCode, BC00012_A7ProductPhoto
               }
               , new Object[] {
               BC00013_A1ProductCode, BC00013_A2ProductName, BC00013_A3ProductPrice, BC00013_A4ProductStock, BC00013_A40000ProductPhoto_GXI, BC00013_A5ProductTypeCode, BC00013_A7ProductPhoto
               }
               , new Object[] {
               BC00014_A6ProductTypeName
               }
               , new Object[] {
               BC00015_A1ProductCode, BC00015_A2ProductName, BC00015_A3ProductPrice, BC00015_A4ProductStock, BC00015_A6ProductTypeName, BC00015_A40000ProductPhoto_GXI, BC00015_A5ProductTypeCode, BC00015_A7ProductPhoto
               }
               , new Object[] {
               BC00016_A1ProductCode, BC00016_A2ProductName, BC00016_A3ProductPrice, BC00016_A4ProductStock, BC00016_A6ProductTypeName, BC00016_A40000ProductPhoto_GXI, BC00016_A5ProductTypeCode, BC00016_A7ProductPhoto
               }
               , new Object[] {
               BC00017_A1ProductCode
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000112_A6ProductTypeName
               }
               , new Object[] {
               BC000113_A1ProductCode, BC000113_A2ProductName, BC000113_A3ProductPrice, BC000113_A4ProductStock, BC000113_A6ProductTypeName, BC000113_A40000ProductPhoto_GXI, BC000113_A5ProductTypeCode, BC000113_A7ProductPhoto
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12012 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short RcdFound1 ;
      private short A4ProductStock ;
      private short A5ProductTypeCode ;
      private short GX_JID ;
      private short Z4ProductStock ;
      private short Z5ProductTypeCode ;
      private short nIsDirty_1 ;
      private int trnEnded ;
      private int Start ;
      private int Count ;
      private int GXPagingFrom1 ;
      private int GXPagingTo1 ;
      private long A1ProductCode ;
      private long Z1ProductCode ;
      private decimal A3ProductPrice ;
      private decimal Z3ProductPrice ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string A2ProductName ;
      private string A6ProductTypeName ;
      private string sMode1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z2ProductName ;
      private string Z6ProductTypeName ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string A40000ProductPhoto_GXI ;
      private string Z40000ProductPhoto_GXI ;
      private string A7ProductPhoto ;
      private string Z7ProductPhoto ;
      private GXBCCollection<SdtProduct> gx_restcollection ;
      private SdtProduct bcProduct ;
      private SdtProduct gx_sdt_item ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00015_A1ProductCode ;
      private string[] BC00015_A2ProductName ;
      private decimal[] BC00015_A3ProductPrice ;
      private short[] BC00015_A4ProductStock ;
      private string[] BC00015_A6ProductTypeName ;
      private string[] BC00015_A40000ProductPhoto_GXI ;
      private short[] BC00015_A5ProductTypeCode ;
      private string[] BC00015_A7ProductPhoto ;
      private long[] BC00016_A1ProductCode ;
      private string[] BC00016_A2ProductName ;
      private decimal[] BC00016_A3ProductPrice ;
      private short[] BC00016_A4ProductStock ;
      private string[] BC00016_A6ProductTypeName ;
      private string[] BC00016_A40000ProductPhoto_GXI ;
      private short[] BC00016_A5ProductTypeCode ;
      private string[] BC00016_A7ProductPhoto ;
      private string[] BC00014_A6ProductTypeName ;
      private long[] BC00017_A1ProductCode ;
      private long[] BC00013_A1ProductCode ;
      private string[] BC00013_A2ProductName ;
      private decimal[] BC00013_A3ProductPrice ;
      private short[] BC00013_A4ProductStock ;
      private string[] BC00013_A40000ProductPhoto_GXI ;
      private short[] BC00013_A5ProductTypeCode ;
      private string[] BC00013_A7ProductPhoto ;
      private long[] BC00012_A1ProductCode ;
      private string[] BC00012_A2ProductName ;
      private decimal[] BC00012_A3ProductPrice ;
      private short[] BC00012_A4ProductStock ;
      private string[] BC00012_A40000ProductPhoto_GXI ;
      private short[] BC00012_A5ProductTypeCode ;
      private string[] BC00012_A7ProductPhoto ;
      private string[] BC000112_A6ProductTypeName ;
      private long[] BC000113_A1ProductCode ;
      private string[] BC000113_A2ProductName ;
      private decimal[] BC000113_A3ProductPrice ;
      private short[] BC000113_A4ProductStock ;
      private string[] BC000113_A6ProductTypeName ;
      private string[] BC000113_A40000ProductPhoto_GXI ;
      private short[] BC000113_A5ProductTypeCode ;
      private string[] BC000113_A7ProductPhoto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class product_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00015;
          prmBC00015 = new Object[] {
          new ParDef("@GXPagingFrom1",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo1",GXType.Int32,9,0)
          };
          Object[] prmBC00016;
          prmBC00016 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmBC00014;
          prmBC00014 = new Object[] {
          new ParDef("@ProductTypeCode",GXType.Int16,4,0)
          };
          Object[] prmBC00017;
          prmBC00017 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmBC00013;
          prmBC00013 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmBC00012;
          prmBC00012 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmBC00018;
          prmBC00018 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0) ,
          new ParDef("@ProductName",GXType.NChar,50,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,9,2) ,
          new ParDef("@ProductStock",GXType.Int16,4,0) ,
          new ParDef("@ProductPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="Product", Fld="ProductPhoto"} ,
          new ParDef("@ProductTypeCode",GXType.Int16,4,0)
          };
          Object[] prmBC00019;
          prmBC00019 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,50,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,9,2) ,
          new ParDef("@ProductStock",GXType.Int16,4,0) ,
          new ParDef("@ProductTypeCode",GXType.Int16,4,0) ,
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmBC000110;
          prmBC000110 = new Object[] {
          new ParDef("@ProductPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Product", Fld="ProductPhoto"} ,
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmBC000111;
          prmBC000111 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmBC000112;
          prmBC000112 = new Object[] {
          new ParDef("@ProductTypeCode",GXType.Int16,4,0)
          };
          Object[] prmBC000113;
          prmBC000113 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00012", "SELECT [ProductCode], [ProductName], [ProductPrice], [ProductStock], [ProductPhoto_GXI], [ProductTypeCode], [ProductPhoto] FROM [Product] WITH (UPDLOCK) WHERE [ProductCode] = @ProductCode ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00013", "SELECT [ProductCode], [ProductName], [ProductPrice], [ProductStock], [ProductPhoto_GXI], [ProductTypeCode], [ProductPhoto] FROM [Product] WHERE [ProductCode] = @ProductCode ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00014", "SELECT [ProductTypeName] FROM [ProductType] WHERE [ProductTypeCode] = @ProductTypeCode ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00015", "SELECT TM1.[ProductCode], TM1.[ProductName], TM1.[ProductPrice], TM1.[ProductStock], T2.[ProductTypeName], TM1.[ProductPhoto_GXI], TM1.[ProductTypeCode], TM1.[ProductPhoto] FROM ([Product] TM1 INNER JOIN [ProductType] T2 ON T2.[ProductTypeCode] = TM1.[ProductTypeCode]) ORDER BY TM1.[ProductCode]  OFFSET @GXPagingFrom1 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo1 > 0 THEN @GXPagingTo1 ELSE 1e9 END) AS INTEGER) ROWS ONLY",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00016", "SELECT TM1.[ProductCode], TM1.[ProductName], TM1.[ProductPrice], TM1.[ProductStock], T2.[ProductTypeName], TM1.[ProductPhoto_GXI], TM1.[ProductTypeCode], TM1.[ProductPhoto] FROM ([Product] TM1 INNER JOIN [ProductType] T2 ON T2.[ProductTypeCode] = TM1.[ProductTypeCode]) WHERE TM1.[ProductCode] = @ProductCode ORDER BY TM1.[ProductCode]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00016,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00017", "SELECT [ProductCode] FROM [Product] WHERE [ProductCode] = @ProductCode  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00017,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00018", "INSERT INTO [Product]([ProductCode], [ProductName], [ProductPrice], [ProductStock], [ProductPhoto], [ProductPhoto_GXI], [ProductTypeCode]) VALUES(@ProductCode, @ProductName, @ProductPrice, @ProductStock, @ProductPhoto, @ProductPhoto_GXI, @ProductTypeCode)", GxErrorMask.GX_NOMASK,prmBC00018)
             ,new CursorDef("BC00019", "UPDATE [Product] SET [ProductName]=@ProductName, [ProductPrice]=@ProductPrice, [ProductStock]=@ProductStock, [ProductTypeCode]=@ProductTypeCode  WHERE [ProductCode] = @ProductCode", GxErrorMask.GX_NOMASK,prmBC00019)
             ,new CursorDef("BC000110", "UPDATE [Product] SET [ProductPhoto]=@ProductPhoto, [ProductPhoto_GXI]=@ProductPhoto_GXI  WHERE [ProductCode] = @ProductCode", GxErrorMask.GX_NOMASK,prmBC000110)
             ,new CursorDef("BC000111", "DELETE FROM [Product]  WHERE [ProductCode] = @ProductCode", GxErrorMask.GX_NOMASK,prmBC000111)
             ,new CursorDef("BC000112", "SELECT [ProductTypeName] FROM [ProductType] WHERE [ProductTypeCode] = @ProductTypeCode ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000112,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000113", "SELECT TM1.[ProductCode], TM1.[ProductName], TM1.[ProductPrice], TM1.[ProductStock], T2.[ProductTypeName], TM1.[ProductPhoto_GXI], TM1.[ProductTypeCode], TM1.[ProductPhoto] FROM ([Product] TM1 INNER JOIN [ProductType] T2 ON T2.[ProductTypeCode] = TM1.[ProductTypeCode]) WHERE TM1.[ProductCode] = @ProductCode ORDER BY TM1.[ProductCode]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000113,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(5));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(6));
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(6));
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 11 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(6));
                return;
       }
    }

 }

}
