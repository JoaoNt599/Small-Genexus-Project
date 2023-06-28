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
   public class product : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A5ProductTypeCode = (short)(Math.Round(NumberUtil.Val( GetPar( "ProductTypeCode"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A5ProductTypeCode", StringUtil.LTrimStr( (decimal)(A5ProductTypeCode), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A5ProductTypeCode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7ProductCode = (long)(Math.Round(NumberUtil.Val( GetPar( "ProductCode"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7ProductCode", StringUtil.LTrimStr( (decimal)(AV7ProductCode), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTCODE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProductCode), "ZZZZZZZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_3-171579", 0) ;
            }
            Form.Meta.addItem("description", "Product", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProductCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Phamarcy", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public product( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Phamarcy", true);
      }

      public product( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_ProductCode )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ProductCode = aP1_ProductCode;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Product", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductCode_Internalname, "Code", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductCode_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1ProductCode), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1ProductCode), "ZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductCode_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductName_Internalname, StringUtil.RTrim( A2ProductName), StringUtil.RTrim( context.localUtil.Format( A2ProductName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductPrice_Internalname, "Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A3ProductPrice, 9, 2, ".", "")), StringUtil.LTrim( ((edtProductPrice_Enabled!=0) ? context.localUtil.Format( A3ProductPrice, "ZZZZZ9.99") : context.localUtil.Format( A3ProductPrice, "ZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductPrice_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Price", "end", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductStock_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductStock_Internalname, "Stock", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4ProductStock), 4, 0, ".", "")), StringUtil.LTrim( ((edtProductStock_Enabled!=0) ? context.localUtil.Format( (decimal)(A4ProductStock), "ZZZ9") : context.localUtil.Format( (decimal)(A4ProductStock), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductStock_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductStock_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductTypeCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductTypeCode_Internalname, "Product Type Code", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductTypeCode_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ProductTypeCode), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A5ProductTypeCode), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductTypeCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductTypeCode_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_5_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_5_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_5_Internalname, sImgUrl, imgprompt_5_Link, "", "", context.GetTheme( ), imgprompt_5_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtProductTypeName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductTypeName_Internalname, "Product Type Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProductTypeName_Internalname, StringUtil.RTrim( A6ProductTypeName), StringUtil.RTrim( context.localUtil.Format( A6ProductTypeName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductTypeName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductTypeName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgProductPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A7ProductPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A7ProductPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProductPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A7ProductPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A7ProductPhoto)) ? A40000ProductPhoto_GXI : context.PathToRelativeUrl( A7ProductPhoto));
         GxWebStd.gx_bitmap( context, imgProductPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProductPhoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", "", "", 0, A7ProductPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
         AssignProp("", false, imgProductPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A7ProductPhoto)) ? A40000ProductPhoto_GXI : context.PathToRelativeUrl( A7ProductPhoto)), true);
         AssignProp("", false, imgProductPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A7ProductPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1ProductCode = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1ProductCode"), ".", ","), 18, MidpointRounding.ToEven));
               Z2ProductName = cgiGet( "Z2ProductName");
               Z3ProductPrice = context.localUtil.CToN( cgiGet( "Z3ProductPrice"), ".", ",");
               Z4ProductStock = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z4ProductStock"), ".", ","), 18, MidpointRounding.ToEven));
               Z5ProductTypeCode = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z5ProductTypeCode"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N5ProductTypeCode = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N5ProductTypeCode"), ".", ","), 18, MidpointRounding.ToEven));
               AV7ProductCode = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vPRODUCTCODE"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_ProductTypeCode = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PRODUCTTYPECODE"), ".", ","), 18, MidpointRounding.ToEven));
               A40000ProductPhoto_GXI = cgiGet( "PRODUCTPHOTO_GXI");
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductCode_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductCode_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTCODE");
                  AnyError = 1;
                  GX_FocusControl = edtProductCode_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1ProductCode = 0;
                  AssignAttri("", false, "A1ProductCode", StringUtil.LTrimStr( (decimal)(A1ProductCode), 10, 0));
               }
               else
               {
                  A1ProductCode = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtProductCode_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1ProductCode", StringUtil.LTrimStr( (decimal)(A1ProductCode), 10, 0));
               }
               A2ProductName = cgiGet( edtProductName_Internalname);
               AssignAttri("", false, "A2ProductName", A2ProductName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",") > 999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTPRICE");
                  AnyError = 1;
                  GX_FocusControl = edtProductPrice_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A3ProductPrice = 0;
                  AssignAttri("", false, "A3ProductPrice", StringUtil.LTrimStr( A3ProductPrice, 9, 2));
               }
               else
               {
                  A3ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",");
                  AssignAttri("", false, "A3ProductPrice", StringUtil.LTrimStr( A3ProductPrice, 9, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTSTOCK");
                  AnyError = 1;
                  GX_FocusControl = edtProductStock_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A4ProductStock = 0;
                  AssignAttri("", false, "A4ProductStock", StringUtil.LTrimStr( (decimal)(A4ProductStock), 4, 0));
               }
               else
               {
                  A4ProductStock = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A4ProductStock", StringUtil.LTrimStr( (decimal)(A4ProductStock), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductTypeCode_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductTypeCode_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTTYPECODE");
                  AnyError = 1;
                  GX_FocusControl = edtProductTypeCode_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A5ProductTypeCode = 0;
                  AssignAttri("", false, "A5ProductTypeCode", StringUtil.LTrimStr( (decimal)(A5ProductTypeCode), 4, 0));
               }
               else
               {
                  A5ProductTypeCode = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductTypeCode_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A5ProductTypeCode", StringUtil.LTrimStr( (decimal)(A5ProductTypeCode), 4, 0));
               }
               A6ProductTypeName = cgiGet( edtProductTypeName_Internalname);
               AssignAttri("", false, "A6ProductTypeName", A6ProductTypeName);
               A7ProductPhoto = cgiGet( imgProductPhoto_Internalname);
               AssignAttri("", false, "A7ProductPhoto", A7ProductPhoto);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProductPhoto_Internalname, ref  A7ProductPhoto, ref  A40000ProductPhoto_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Product");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1ProductCode != Z1ProductCode ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("product:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A1ProductCode = (long)(Math.Round(NumberUtil.Val( GetPar( "ProductCode"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1ProductCode", StringUtil.LTrimStr( (decimal)(A1ProductCode), 10, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PRODUCTCODE");
                        AnyError = 1;
                        GX_FocusControl = edtProductCode_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
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
            E12012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes011( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
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
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_ProductTypeCode = 0;
         AssignAttri("", false, "AV11Insert_ProductTypeCode", StringUtil.LTrimStr( (decimal)(AV11Insert_ProductTypeCode), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV13Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV14GXV1 = 1;
            AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            while ( AV14GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV14GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ProductTypeCode") == 0 )
               {
                  AV11Insert_ProductTypeCode = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ProductTypeCode", StringUtil.LTrimStr( (decimal)(AV11Insert_ProductTypeCode), 4, 0));
               }
               AV14GXV1 = (int)(AV14GXV1+1);
               AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwproduct.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2ProductName = T00013_A2ProductName[0];
               Z3ProductPrice = T00013_A3ProductPrice[0];
               Z4ProductStock = T00013_A4ProductStock[0];
               Z5ProductTypeCode = T00013_A5ProductTypeCode[0];
            }
            else
            {
               Z2ProductName = A2ProductName;
               Z3ProductPrice = A3ProductPrice;
               Z4ProductStock = A4ProductStock;
               Z5ProductTypeCode = A5ProductTypeCode;
            }
         }
         if ( GX_JID == -11 )
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
         imgprompt_5_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTTYPECODE"+"'), id:'"+"PRODUCTTYPECODE"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ProductCode) )
         {
            A1ProductCode = AV7ProductCode;
            AssignAttri("", false, "A1ProductCode", StringUtil.LTrimStr( (decimal)(A1ProductCode), 10, 0));
         }
         if ( ! (0==AV7ProductCode) )
         {
            edtProductCode_Enabled = 0;
            AssignProp("", false, edtProductCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCode_Enabled), 5, 0), true);
         }
         else
         {
            edtProductCode_Enabled = 1;
            AssignProp("", false, edtProductCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCode_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7ProductCode) )
         {
            edtProductCode_Enabled = 0;
            AssignProp("", false, edtProductCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCode_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ProductTypeCode) )
         {
            edtProductTypeCode_Enabled = 0;
            AssignProp("", false, edtProductTypeCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductTypeCode_Enabled), 5, 0), true);
         }
         else
         {
            edtProductTypeCode_Enabled = 1;
            AssignProp("", false, edtProductTypeCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductTypeCode_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ProductTypeCode) )
         {
            A5ProductTypeCode = AV11Insert_ProductTypeCode;
            AssignAttri("", false, "A5ProductTypeCode", StringUtil.LTrimStr( (decimal)(A5ProductTypeCode), 4, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV13Pgmname = "Product";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T00014 */
            pr_default.execute(2, new Object[] {A5ProductTypeCode});
            A6ProductTypeName = T00014_A6ProductTypeName[0];
            AssignAttri("", false, "A6ProductTypeName", A6ProductTypeName);
            pr_default.close(2);
         }
      }

      protected void Load011( )
      {
         /* Using cursor T00015 */
         pr_default.execute(3, new Object[] {A1ProductCode});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
            A2ProductName = T00015_A2ProductName[0];
            AssignAttri("", false, "A2ProductName", A2ProductName);
            A3ProductPrice = T00015_A3ProductPrice[0];
            AssignAttri("", false, "A3ProductPrice", StringUtil.LTrimStr( A3ProductPrice, 9, 2));
            A4ProductStock = T00015_A4ProductStock[0];
            AssignAttri("", false, "A4ProductStock", StringUtil.LTrimStr( (decimal)(A4ProductStock), 4, 0));
            A6ProductTypeName = T00015_A6ProductTypeName[0];
            AssignAttri("", false, "A6ProductTypeName", A6ProductTypeName);
            A40000ProductPhoto_GXI = T00015_A40000ProductPhoto_GXI[0];
            AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A7ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A7ProductPhoto))), true);
            AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A7ProductPhoto), true);
            A5ProductTypeCode = T00015_A5ProductTypeCode[0];
            AssignAttri("", false, "A5ProductTypeCode", StringUtil.LTrimStr( (decimal)(A5ProductTypeCode), 4, 0));
            A7ProductPhoto = T00015_A7ProductPhoto[0];
            AssignAttri("", false, "A7ProductPhoto", A7ProductPhoto);
            AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A7ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A7ProductPhoto))), true);
            AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A7ProductPhoto), true);
            ZM011( -11) ;
         }
         pr_default.close(3);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         AV13Pgmname = "Product";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV13Pgmname = "Product";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2ProductName)) )
         {
            GX_msglist.addItem("The product name cannot e empty", 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A3ProductPrice) )
         {
            GX_msglist.addItem("The product price is empty", 0, "PRODUCTPRICE");
         }
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A5ProductTypeCode});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Product Type'.", "ForeignKeyNotFound", 1, "PRODUCTTYPECODE");
            AnyError = 1;
            GX_FocusControl = edtProductTypeCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A6ProductTypeName = T00014_A6ProductTypeName[0];
         AssignAttri("", false, "A6ProductTypeName", A6ProductTypeName);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( short A5ProductTypeCode )
      {
         /* Using cursor T00016 */
         pr_default.execute(4, new Object[] {A5ProductTypeCode});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Product Type'.", "ForeignKeyNotFound", 1, "PRODUCTTYPECODE");
            AnyError = 1;
            GX_FocusControl = edtProductTypeCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A6ProductTypeName = T00016_A6ProductTypeName[0];
         AssignAttri("", false, "A6ProductTypeName", A6ProductTypeName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A6ProductTypeName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey011( )
      {
         /* Using cursor T00017 */
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
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1ProductCode});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 11) ;
            RcdFound1 = 1;
            A1ProductCode = T00013_A1ProductCode[0];
            AssignAttri("", false, "A1ProductCode", StringUtil.LTrimStr( (decimal)(A1ProductCode), 10, 0));
            A2ProductName = T00013_A2ProductName[0];
            AssignAttri("", false, "A2ProductName", A2ProductName);
            A3ProductPrice = T00013_A3ProductPrice[0];
            AssignAttri("", false, "A3ProductPrice", StringUtil.LTrimStr( A3ProductPrice, 9, 2));
            A4ProductStock = T00013_A4ProductStock[0];
            AssignAttri("", false, "A4ProductStock", StringUtil.LTrimStr( (decimal)(A4ProductStock), 4, 0));
            A40000ProductPhoto_GXI = T00013_A40000ProductPhoto_GXI[0];
            AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A7ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A7ProductPhoto))), true);
            AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A7ProductPhoto), true);
            A5ProductTypeCode = T00013_A5ProductTypeCode[0];
            AssignAttri("", false, "A5ProductTypeCode", StringUtil.LTrimStr( (decimal)(A5ProductTypeCode), 4, 0));
            A7ProductPhoto = T00013_A7ProductPhoto[0];
            AssignAttri("", false, "A7ProductPhoto", A7ProductPhoto);
            AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A7ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A7ProductPhoto))), true);
            AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A7ProductPhoto), true);
            Z1ProductCode = A1ProductCode;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T00018 */
         pr_default.execute(6, new Object[] {A1ProductCode});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00018_A1ProductCode[0] < A1ProductCode ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00018_A1ProductCode[0] > A1ProductCode ) ) )
            {
               A1ProductCode = T00018_A1ProductCode[0];
               AssignAttri("", false, "A1ProductCode", StringUtil.LTrimStr( (decimal)(A1ProductCode), 10, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T00019 */
         pr_default.execute(7, new Object[] {A1ProductCode});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1ProductCode[0] > A1ProductCode ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00019_A1ProductCode[0] < A1ProductCode ) ) )
            {
               A1ProductCode = T00019_A1ProductCode[0];
               AssignAttri("", false, "A1ProductCode", StringUtil.LTrimStr( (decimal)(A1ProductCode), 10, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProductCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1ProductCode != Z1ProductCode )
               {
                  A1ProductCode = Z1ProductCode;
                  AssignAttri("", false, "A1ProductCode", StringUtil.LTrimStr( (decimal)(A1ProductCode), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODUCTCODE");
                  AnyError = 1;
                  GX_FocusControl = edtProductCode_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProductCode_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtProductCode_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1ProductCode != Z1ProductCode )
               {
                  /* Insert record */
                  GX_FocusControl = edtProductCode_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODUCTCODE");
                     AnyError = 1;
                     GX_FocusControl = edtProductCode_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProductCode_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A1ProductCode != Z1ProductCode )
         {
            A1ProductCode = Z1ProductCode;
            AssignAttri("", false, "A1ProductCode", StringUtil.LTrimStr( (decimal)(A1ProductCode), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODUCTCODE");
            AnyError = 1;
            GX_FocusControl = edtProductCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProductCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1ProductCode});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2ProductName, T00012_A2ProductName[0]) != 0 ) || ( Z3ProductPrice != T00012_A3ProductPrice[0] ) || ( Z4ProductStock != T00012_A4ProductStock[0] ) || ( Z5ProductTypeCode != T00012_A5ProductTypeCode[0] ) )
            {
               if ( StringUtil.StrCmp(Z2ProductName, T00012_A2ProductName[0]) != 0 )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductName");
                  GXUtil.WriteLogRaw("Old: ",Z2ProductName);
                  GXUtil.WriteLogRaw("Current: ",T00012_A2ProductName[0]);
               }
               if ( Z3ProductPrice != T00012_A3ProductPrice[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductPrice");
                  GXUtil.WriteLogRaw("Old: ",Z3ProductPrice);
                  GXUtil.WriteLogRaw("Current: ",T00012_A3ProductPrice[0]);
               }
               if ( Z4ProductStock != T00012_A4ProductStock[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductStock");
                  GXUtil.WriteLogRaw("Old: ",Z4ProductStock);
                  GXUtil.WriteLogRaw("Current: ",T00012_A4ProductStock[0]);
               }
               if ( Z5ProductTypeCode != T00012_A5ProductTypeCode[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductTypeCode");
                  GXUtil.WriteLogRaw("Old: ",Z5ProductTypeCode);
                  GXUtil.WriteLogRaw("Current: ",T00012_A5ProductTypeCode[0]);
               }
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
                     /* Using cursor T000110 */
                     pr_default.execute(8, new Object[] {A1ProductCode, A2ProductName, A3ProductPrice, A4ProductStock, A7ProductPhoto, A40000ProductPhoto_GXI, A5ProductTypeCode});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Product");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption010( ) ;
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
                     /* Using cursor T000111 */
                     pr_default.execute(9, new Object[] {A2ProductName, A3ProductPrice, A4ProductStock, A5ProductTypeCode, A1ProductCode});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Product");
                     if ( (pr_default.getStatus(9) == 103) )
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
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000112 */
            pr_default.execute(10, new Object[] {A7ProductPhoto, A40000ProductPhoto_GXI, A1ProductCode});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Product");
         }
      }

      protected void delete( )
      {
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
                  /* Using cursor T000113 */
                  pr_default.execute(11, new Object[] {A1ProductCode});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Product");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
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
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Product";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T000114 */
            pr_default.execute(12, new Object[] {A5ProductTypeCode});
            A6ProductTypeName = T000114_A6ProductTypeName[0];
            AssignAttri("", false, "A6ProductTypeName", A6ProductTypeName);
            pr_default.close(12);
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
            pr_default.close(1);
            pr_default.close(12);
            context.CommitDataStores("product",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            context.RollbackDataStores("product",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Scan By routine */
         /* Using cursor T000115 */
         pr_default.execute(13);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound1 = 1;
            A1ProductCode = T000115_A1ProductCode[0];
            AssignAttri("", false, "A1ProductCode", StringUtil.LTrimStr( (decimal)(A1ProductCode), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound1 = 1;
            A1ProductCode = T000115_A1ProductCode[0];
            AssignAttri("", false, "A1ProductCode", StringUtil.LTrimStr( (decimal)(A1ProductCode), 10, 0));
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(13);
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
         edtProductCode_Enabled = 0;
         AssignProp("", false, edtProductCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCode_Enabled), 5, 0), true);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), true);
         edtProductPrice_Enabled = 0;
         AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), true);
         edtProductStock_Enabled = 0;
         AssignProp("", false, edtProductStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductStock_Enabled), 5, 0), true);
         edtProductTypeCode_Enabled = 0;
         AssignProp("", false, edtProductTypeCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductTypeCode_Enabled), 5, 0), true);
         edtProductTypeName_Enabled = 0;
         AssignProp("", false, edtProductTypeName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductTypeName_Enabled), 5, 0), true);
         imgProductPhoto_Enabled = 0;
         AssignProp("", false, imgProductPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProductPhoto_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 456460), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 456460), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 456460), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("product.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProductCode,10,0))}, new string[] {"Gx_mode","ProductCode"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Product");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("product:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1ProductCode", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1ProductCode), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2ProductName", StringUtil.RTrim( Z2ProductName));
         GxWebStd.gx_hidden_field( context, "Z3ProductPrice", StringUtil.LTrim( StringUtil.NToC( Z3ProductPrice, 9, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4ProductStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4ProductStock), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5ProductTypeCode", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z5ProductTypeCode), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N5ProductTypeCode", StringUtil.LTrim( StringUtil.NToC( (decimal)(A5ProductTypeCode), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPRODUCTCODE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProductCode), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTCODE", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProductCode), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODUCTTYPECODE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ProductTypeCode), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTPHOTO_GXI", A40000ProductPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
         GXCCtlgxBlob = "PRODUCTPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A7ProductPhoto);
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("product.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProductCode,10,0))}, new string[] {"Gx_mode","ProductCode"})  ;
      }

      public override string GetPgmname( )
      {
         return "Product" ;
      }

      public override string GetPgmdesc( )
      {
         return "Product" ;
      }

      protected void InitializeNonKey011( )
      {
         A5ProductTypeCode = 0;
         AssignAttri("", false, "A5ProductTypeCode", StringUtil.LTrimStr( (decimal)(A5ProductTypeCode), 4, 0));
         A2ProductName = "";
         AssignAttri("", false, "A2ProductName", A2ProductName);
         A3ProductPrice = 0;
         AssignAttri("", false, "A3ProductPrice", StringUtil.LTrimStr( A3ProductPrice, 9, 2));
         A4ProductStock = 0;
         AssignAttri("", false, "A4ProductStock", StringUtil.LTrimStr( (decimal)(A4ProductStock), 4, 0));
         A6ProductTypeName = "";
         AssignAttri("", false, "A6ProductTypeName", A6ProductTypeName);
         A7ProductPhoto = "";
         AssignAttri("", false, "A7ProductPhoto", A7ProductPhoto);
         AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A7ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A7ProductPhoto))), true);
         AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A7ProductPhoto), true);
         A40000ProductPhoto_GXI = "";
         AssignProp("", false, imgProductPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A7ProductPhoto)) ? A40000ProductPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A7ProductPhoto))), true);
         AssignProp("", false, imgProductPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A7ProductPhoto), true);
         Z2ProductName = "";
         Z3ProductPrice = 0;
         Z4ProductStock = 0;
         Z5ProductTypeCode = 0;
      }

      protected void InitAll011( )
      {
         A1ProductCode = 0;
         AssignAttri("", false, "A1ProductCode", StringUtil.LTrimStr( (decimal)(A1ProductCode), 10, 0));
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20236271952723", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("product.js", "?20236271952723", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtProductCode_Internalname = "PRODUCTCODE";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         edtProductStock_Internalname = "PRODUCTSTOCK";
         edtProductTypeCode_Internalname = "PRODUCTTYPECODE";
         edtProductTypeName_Internalname = "PRODUCTTYPENAME";
         imgProductPhoto_Internalname = "PRODUCTPHOTO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_5_Internalname = "PROMPT_5";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Phamarcy", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Product";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgProductPhoto_Enabled = 1;
         edtProductTypeName_Jsonclick = "";
         edtProductTypeName_Enabled = 0;
         imgprompt_5_Visible = 1;
         imgprompt_5_Link = "";
         edtProductTypeCode_Jsonclick = "";
         edtProductTypeCode_Enabled = 1;
         edtProductStock_Jsonclick = "";
         edtProductStock_Enabled = 1;
         edtProductPrice_Jsonclick = "";
         edtProductPrice_Enabled = 1;
         edtProductName_Jsonclick = "";
         edtProductName_Enabled = 1;
         edtProductCode_Jsonclick = "";
         edtProductCode_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
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

      public void Valid_Producttypecode( )
      {
         /* Using cursor T000114 */
         pr_default.execute(12, new Object[] {A5ProductTypeCode});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No matching 'Product Type'.", "ForeignKeyNotFound", 1, "PRODUCTTYPECODE");
            AnyError = 1;
            GX_FocusControl = edtProductTypeCode_Internalname;
         }
         A6ProductTypeName = T000114_A6ProductTypeName[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A6ProductTypeName", StringUtil.RTrim( A6ProductTypeName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ProductCode',fld:'vPRODUCTCODE',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ProductCode',fld:'vPRODUCTCODE',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12012',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTCODE","{handler:'Valid_Productcode',iparms:[]");
         setEventMetadata("VALID_PRODUCTCODE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTNAME","{handler:'Valid_Productname',iparms:[]");
         setEventMetadata("VALID_PRODUCTNAME",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTPRICE","{handler:'Valid_Productprice',iparms:[]");
         setEventMetadata("VALID_PRODUCTPRICE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTTYPECODE","{handler:'Valid_Producttypecode',iparms:[{av:'A5ProductTypeCode',fld:'PRODUCTTYPECODE',pic:'ZZZ9'},{av:'A6ProductTypeName',fld:'PRODUCTTYPENAME',pic:''}]");
         setEventMetadata("VALID_PRODUCTTYPECODE",",oparms:[{av:'A6ProductTypeName',fld:'PRODUCTTYPENAME',pic:''}]}");
         return  ;
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z2ProductName = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A2ProductName = "";
         imgprompt_5_gximage = "";
         sImgUrl = "";
         A6ProductTypeName = "";
         A7ProductPhoto = "";
         A40000ProductPhoto_GXI = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z7ProductPhoto = "";
         Z40000ProductPhoto_GXI = "";
         Z6ProductTypeName = "";
         T00014_A6ProductTypeName = new string[] {""} ;
         T00015_A1ProductCode = new long[1] ;
         T00015_A2ProductName = new string[] {""} ;
         T00015_A3ProductPrice = new decimal[1] ;
         T00015_A4ProductStock = new short[1] ;
         T00015_A6ProductTypeName = new string[] {""} ;
         T00015_A40000ProductPhoto_GXI = new string[] {""} ;
         T00015_A5ProductTypeCode = new short[1] ;
         T00015_A7ProductPhoto = new string[] {""} ;
         T00016_A6ProductTypeName = new string[] {""} ;
         T00017_A1ProductCode = new long[1] ;
         T00013_A1ProductCode = new long[1] ;
         T00013_A2ProductName = new string[] {""} ;
         T00013_A3ProductPrice = new decimal[1] ;
         T00013_A4ProductStock = new short[1] ;
         T00013_A40000ProductPhoto_GXI = new string[] {""} ;
         T00013_A5ProductTypeCode = new short[1] ;
         T00013_A7ProductPhoto = new string[] {""} ;
         T00018_A1ProductCode = new long[1] ;
         T00019_A1ProductCode = new long[1] ;
         T00012_A1ProductCode = new long[1] ;
         T00012_A2ProductName = new string[] {""} ;
         T00012_A3ProductPrice = new decimal[1] ;
         T00012_A4ProductStock = new short[1] ;
         T00012_A40000ProductPhoto_GXI = new string[] {""} ;
         T00012_A5ProductTypeCode = new short[1] ;
         T00012_A7ProductPhoto = new string[] {""} ;
         T000114_A6ProductTypeName = new string[] {""} ;
         T000115_A1ProductCode = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.product__default(),
            new Object[][] {
                new Object[] {
               T00012_A1ProductCode, T00012_A2ProductName, T00012_A3ProductPrice, T00012_A4ProductStock, T00012_A40000ProductPhoto_GXI, T00012_A5ProductTypeCode, T00012_A7ProductPhoto
               }
               , new Object[] {
               T00013_A1ProductCode, T00013_A2ProductName, T00013_A3ProductPrice, T00013_A4ProductStock, T00013_A40000ProductPhoto_GXI, T00013_A5ProductTypeCode, T00013_A7ProductPhoto
               }
               , new Object[] {
               T00014_A6ProductTypeName
               }
               , new Object[] {
               T00015_A1ProductCode, T00015_A2ProductName, T00015_A3ProductPrice, T00015_A4ProductStock, T00015_A6ProductTypeName, T00015_A40000ProductPhoto_GXI, T00015_A5ProductTypeCode, T00015_A7ProductPhoto
               }
               , new Object[] {
               T00016_A6ProductTypeName
               }
               , new Object[] {
               T00017_A1ProductCode
               }
               , new Object[] {
               T00018_A1ProductCode
               }
               , new Object[] {
               T00019_A1ProductCode
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
               T000114_A6ProductTypeName
               }
               , new Object[] {
               T000115_A1ProductCode
               }
            }
         );
         AV13Pgmname = "Product";
      }

      private short Z4ProductStock ;
      private short Z5ProductTypeCode ;
      private short N5ProductTypeCode ;
      private short GxWebError ;
      private short A5ProductTypeCode ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A4ProductStock ;
      private short AV11Insert_ProductTypeCode ;
      private short RcdFound1 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_1 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProductCode_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductPrice_Enabled ;
      private int edtProductStock_Enabled ;
      private int edtProductTypeCode_Enabled ;
      private int imgprompt_5_Visible ;
      private int edtProductTypeName_Enabled ;
      private int imgProductPhoto_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV14GXV1 ;
      private int idxLst ;
      private long wcpOAV7ProductCode ;
      private long Z1ProductCode ;
      private long AV7ProductCode ;
      private long A1ProductCode ;
      private decimal Z3ProductPrice ;
      private decimal A3ProductPrice ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z2ProductName ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProductCode_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtProductCode_Jsonclick ;
      private string edtProductName_Internalname ;
      private string A2ProductName ;
      private string edtProductName_Jsonclick ;
      private string edtProductPrice_Internalname ;
      private string edtProductPrice_Jsonclick ;
      private string edtProductStock_Internalname ;
      private string edtProductStock_Jsonclick ;
      private string edtProductTypeCode_Internalname ;
      private string edtProductTypeCode_Jsonclick ;
      private string imgprompt_5_gximage ;
      private string sImgUrl ;
      private string imgprompt_5_Internalname ;
      private string imgprompt_5_Link ;
      private string edtProductTypeName_Internalname ;
      private string A6ProductTypeName ;
      private string edtProductTypeName_Jsonclick ;
      private string imgProductPhoto_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string hsh ;
      private string sMode1 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z6ProductTypeName ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A7ProductPhoto_IsBlob ;
      private bool returnInSub ;
      private string A40000ProductPhoto_GXI ;
      private string Z40000ProductPhoto_GXI ;
      private string A7ProductPhoto ;
      private string Z7ProductPhoto ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00014_A6ProductTypeName ;
      private long[] T00015_A1ProductCode ;
      private string[] T00015_A2ProductName ;
      private decimal[] T00015_A3ProductPrice ;
      private short[] T00015_A4ProductStock ;
      private string[] T00015_A6ProductTypeName ;
      private string[] T00015_A40000ProductPhoto_GXI ;
      private short[] T00015_A5ProductTypeCode ;
      private string[] T00015_A7ProductPhoto ;
      private string[] T00016_A6ProductTypeName ;
      private long[] T00017_A1ProductCode ;
      private long[] T00013_A1ProductCode ;
      private string[] T00013_A2ProductName ;
      private decimal[] T00013_A3ProductPrice ;
      private short[] T00013_A4ProductStock ;
      private string[] T00013_A40000ProductPhoto_GXI ;
      private short[] T00013_A5ProductTypeCode ;
      private string[] T00013_A7ProductPhoto ;
      private long[] T00018_A1ProductCode ;
      private long[] T00019_A1ProductCode ;
      private long[] T00012_A1ProductCode ;
      private string[] T00012_A2ProductName ;
      private decimal[] T00012_A3ProductPrice ;
      private short[] T00012_A4ProductStock ;
      private string[] T00012_A40000ProductPhoto_GXI ;
      private short[] T00012_A5ProductTypeCode ;
      private string[] T00012_A7ProductPhoto ;
      private string[] T000114_A6ProductTypeName ;
      private long[] T000115_A1ProductCode ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class product__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@ProductTypeCode",GXType.Int16,4,0)
          };
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@ProductTypeCode",GXType.Int16,4,0)
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0) ,
          new ParDef("@ProductName",GXType.NChar,50,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,9,2) ,
          new ParDef("@ProductStock",GXType.Int16,4,0) ,
          new ParDef("@ProductPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="Product", Fld="ProductPhoto"} ,
          new ParDef("@ProductTypeCode",GXType.Int16,4,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          new ParDef("@ProductName",GXType.NChar,50,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,9,2) ,
          new ParDef("@ProductStock",GXType.Int16,4,0) ,
          new ParDef("@ProductTypeCode",GXType.Int16,4,0) ,
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmT000112;
          prmT000112 = new Object[] {
          new ParDef("@ProductPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProductPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Product", Fld="ProductPhoto"} ,
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmT000113;
          prmT000113 = new Object[] {
          new ParDef("@ProductCode",GXType.Decimal,10,0)
          };
          Object[] prmT000115;
          prmT000115 = new Object[] {
          };
          Object[] prmT000114;
          prmT000114 = new Object[] {
          new ParDef("@ProductTypeCode",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [ProductCode], [ProductName], [ProductPrice], [ProductStock], [ProductPhoto_GXI], [ProductTypeCode], [ProductPhoto] FROM [Product] WITH (UPDLOCK) WHERE [ProductCode] = @ProductCode ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [ProductCode], [ProductName], [ProductPrice], [ProductStock], [ProductPhoto_GXI], [ProductTypeCode], [ProductPhoto] FROM [Product] WHERE [ProductCode] = @ProductCode ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT [ProductTypeName] FROM [ProductType] WHERE [ProductTypeCode] = @ProductTypeCode ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT TM1.[ProductCode], TM1.[ProductName], TM1.[ProductPrice], TM1.[ProductStock], T2.[ProductTypeName], TM1.[ProductPhoto_GXI], TM1.[ProductTypeCode], TM1.[ProductPhoto] FROM ([Product] TM1 INNER JOIN [ProductType] T2 ON T2.[ProductTypeCode] = TM1.[ProductTypeCode]) WHERE TM1.[ProductCode] = @ProductCode ORDER BY TM1.[ProductCode]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT [ProductTypeName] FROM [ProductType] WHERE [ProductTypeCode] = @ProductTypeCode ",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00017", "SELECT [ProductCode] FROM [Product] WHERE [ProductCode] = @ProductCode  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00018", "SELECT TOP 1 [ProductCode] FROM [Product] WHERE ( [ProductCode] > @ProductCode) ORDER BY [ProductCode]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00019", "SELECT TOP 1 [ProductCode] FROM [Product] WHERE ( [ProductCode] < @ProductCode) ORDER BY [ProductCode] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000110", "INSERT INTO [Product]([ProductCode], [ProductName], [ProductPrice], [ProductStock], [ProductPhoto], [ProductPhoto_GXI], [ProductTypeCode]) VALUES(@ProductCode, @ProductName, @ProductPrice, @ProductStock, @ProductPhoto, @ProductPhoto_GXI, @ProductTypeCode)", GxErrorMask.GX_NOMASK,prmT000110)
             ,new CursorDef("T000111", "UPDATE [Product] SET [ProductName]=@ProductName, [ProductPrice]=@ProductPrice, [ProductStock]=@ProductStock, [ProductTypeCode]=@ProductTypeCode  WHERE [ProductCode] = @ProductCode", GxErrorMask.GX_NOMASK,prmT000111)
             ,new CursorDef("T000112", "UPDATE [Product] SET [ProductPhoto]=@ProductPhoto, [ProductPhoto_GXI]=@ProductPhoto_GXI  WHERE [ProductCode] = @ProductCode", GxErrorMask.GX_NOMASK,prmT000112)
             ,new CursorDef("T000113", "DELETE FROM [Product]  WHERE [ProductCode] = @ProductCode", GxErrorMask.GX_NOMASK,prmT000113)
             ,new CursorDef("T000114", "SELECT [ProductTypeName] FROM [ProductType] WHERE [ProductTypeCode] = @ProductTypeCode ",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000115", "SELECT [ProductCode] FROM [Product] ORDER BY [ProductCode]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000115,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 13 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
