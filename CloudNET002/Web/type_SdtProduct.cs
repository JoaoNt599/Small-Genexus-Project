using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Product" )]
   [XmlType(TypeName =  "Product" , Namespace = "Phamarcy" )]
   [Serializable]
   public class SdtProduct : GxSilentTrnSdt
   {
      public SdtProduct( )
      {
      }

      public SdtProduct( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( long AV1ProductCode )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV1ProductCode});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProductCode", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Product");
         metadata.Set("BT", "Product");
         metadata.Set("PK", "[ \"ProductCode\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ProductTypeCode\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Productphoto_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Productcode_Z");
         state.Add("gxTpr_Productname_Z");
         state.Add("gxTpr_Productprice_Z");
         state.Add("gxTpr_Productstock_Z");
         state.Add("gxTpr_Producttypecode_Z");
         state.Add("gxTpr_Producttypename_Z");
         state.Add("gxTpr_Productphoto_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProduct sdt;
         sdt = (SdtProduct)(source);
         gxTv_SdtProduct_Productcode = sdt.gxTv_SdtProduct_Productcode ;
         gxTv_SdtProduct_Productname = sdt.gxTv_SdtProduct_Productname ;
         gxTv_SdtProduct_Productprice = sdt.gxTv_SdtProduct_Productprice ;
         gxTv_SdtProduct_Productstock = sdt.gxTv_SdtProduct_Productstock ;
         gxTv_SdtProduct_Producttypecode = sdt.gxTv_SdtProduct_Producttypecode ;
         gxTv_SdtProduct_Producttypename = sdt.gxTv_SdtProduct_Producttypename ;
         gxTv_SdtProduct_Productphoto = sdt.gxTv_SdtProduct_Productphoto ;
         gxTv_SdtProduct_Productphoto_gxi = sdt.gxTv_SdtProduct_Productphoto_gxi ;
         gxTv_SdtProduct_Mode = sdt.gxTv_SdtProduct_Mode ;
         gxTv_SdtProduct_Initialized = sdt.gxTv_SdtProduct_Initialized ;
         gxTv_SdtProduct_Productcode_Z = sdt.gxTv_SdtProduct_Productcode_Z ;
         gxTv_SdtProduct_Productname_Z = sdt.gxTv_SdtProduct_Productname_Z ;
         gxTv_SdtProduct_Productprice_Z = sdt.gxTv_SdtProduct_Productprice_Z ;
         gxTv_SdtProduct_Productstock_Z = sdt.gxTv_SdtProduct_Productstock_Z ;
         gxTv_SdtProduct_Producttypecode_Z = sdt.gxTv_SdtProduct_Producttypecode_Z ;
         gxTv_SdtProduct_Producttypename_Z = sdt.gxTv_SdtProduct_Producttypename_Z ;
         gxTv_SdtProduct_Productphoto_gxi_Z = sdt.gxTv_SdtProduct_Productphoto_gxi_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("ProductCode", gxTv_SdtProduct_Productcode, false, includeNonInitialized);
         AddObjectProperty("ProductName", gxTv_SdtProduct_Productname, false, includeNonInitialized);
         AddObjectProperty("ProductPrice", gxTv_SdtProduct_Productprice, false, includeNonInitialized);
         AddObjectProperty("ProductStock", gxTv_SdtProduct_Productstock, false, includeNonInitialized);
         AddObjectProperty("ProductTypeCode", gxTv_SdtProduct_Producttypecode, false, includeNonInitialized);
         AddObjectProperty("ProductTypeName", gxTv_SdtProduct_Producttypename, false, includeNonInitialized);
         AddObjectProperty("ProductPhoto", gxTv_SdtProduct_Productphoto, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("ProductPhoto_GXI", gxTv_SdtProduct_Productphoto_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtProduct_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProduct_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProductCode_Z", gxTv_SdtProduct_Productcode_Z, false, includeNonInitialized);
            AddObjectProperty("ProductName_Z", gxTv_SdtProduct_Productname_Z, false, includeNonInitialized);
            AddObjectProperty("ProductPrice_Z", gxTv_SdtProduct_Productprice_Z, false, includeNonInitialized);
            AddObjectProperty("ProductStock_Z", gxTv_SdtProduct_Productstock_Z, false, includeNonInitialized);
            AddObjectProperty("ProductTypeCode_Z", gxTv_SdtProduct_Producttypecode_Z, false, includeNonInitialized);
            AddObjectProperty("ProductTypeName_Z", gxTv_SdtProduct_Producttypename_Z, false, includeNonInitialized);
            AddObjectProperty("ProductPhoto_GXI_Z", gxTv_SdtProduct_Productphoto_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProduct sdt )
      {
         if ( sdt.IsDirty("ProductCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcode = sdt.gxTv_SdtProduct_Productcode ;
         }
         if ( sdt.IsDirty("ProductName") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productname = sdt.gxTv_SdtProduct_Productname ;
         }
         if ( sdt.IsDirty("ProductPrice") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productprice = sdt.gxTv_SdtProduct_Productprice ;
         }
         if ( sdt.IsDirty("ProductStock") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productstock = sdt.gxTv_SdtProduct_Productstock ;
         }
         if ( sdt.IsDirty("ProductTypeCode") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Producttypecode = sdt.gxTv_SdtProduct_Producttypecode ;
         }
         if ( sdt.IsDirty("ProductTypeName") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Producttypename = sdt.gxTv_SdtProduct_Producttypename ;
         }
         if ( sdt.IsDirty("ProductPhoto") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productphoto = sdt.gxTv_SdtProduct_Productphoto ;
         }
         if ( sdt.IsDirty("ProductPhoto") )
         {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productphoto_gxi = sdt.gxTv_SdtProduct_Productphoto_gxi ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProductCode" )]
      [  XmlElement( ElementName = "ProductCode"   )]
      public long gxTpr_Productcode
      {
         get {
            return gxTv_SdtProduct_Productcode ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtProduct_Productcode != value )
            {
               gxTv_SdtProduct_Mode = "INS";
               this.gxTv_SdtProduct_Productcode_Z_SetNull( );
               this.gxTv_SdtProduct_Productname_Z_SetNull( );
               this.gxTv_SdtProduct_Productprice_Z_SetNull( );
               this.gxTv_SdtProduct_Productstock_Z_SetNull( );
               this.gxTv_SdtProduct_Producttypecode_Z_SetNull( );
               this.gxTv_SdtProduct_Producttypename_Z_SetNull( );
               this.gxTv_SdtProduct_Productphoto_gxi_Z_SetNull( );
            }
            gxTv_SdtProduct_Productcode = value;
            SetDirty("Productcode");
         }

      }

      [  SoapElement( ElementName = "ProductName" )]
      [  XmlElement( ElementName = "ProductName"   )]
      public string gxTpr_Productname
      {
         get {
            return gxTv_SdtProduct_Productname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productname = value;
            SetDirty("Productname");
         }

      }

      [  SoapElement( ElementName = "ProductPrice" )]
      [  XmlElement( ElementName = "ProductPrice"   )]
      public decimal gxTpr_Productprice
      {
         get {
            return gxTv_SdtProduct_Productprice ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productprice = value;
            SetDirty("Productprice");
         }

      }

      [  SoapElement( ElementName = "ProductStock" )]
      [  XmlElement( ElementName = "ProductStock"   )]
      public short gxTpr_Productstock
      {
         get {
            return gxTv_SdtProduct_Productstock ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productstock = value;
            SetDirty("Productstock");
         }

      }

      [  SoapElement( ElementName = "ProductTypeCode" )]
      [  XmlElement( ElementName = "ProductTypeCode"   )]
      public short gxTpr_Producttypecode
      {
         get {
            return gxTv_SdtProduct_Producttypecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Producttypecode = value;
            SetDirty("Producttypecode");
         }

      }

      [  SoapElement( ElementName = "ProductTypeName" )]
      [  XmlElement( ElementName = "ProductTypeName"   )]
      public string gxTpr_Producttypename
      {
         get {
            return gxTv_SdtProduct_Producttypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Producttypename = value;
            SetDirty("Producttypename");
         }

      }

      [  SoapElement( ElementName = "ProductPhoto" )]
      [  XmlElement( ElementName = "ProductPhoto"   )]
      [GxUpload()]
      public string gxTpr_Productphoto
      {
         get {
            return gxTv_SdtProduct_Productphoto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productphoto = value;
            SetDirty("Productphoto");
         }

      }

      [  SoapElement( ElementName = "ProductPhoto_GXI" )]
      [  XmlElement( ElementName = "ProductPhoto_GXI"   )]
      public string gxTpr_Productphoto_gxi
      {
         get {
            return gxTv_SdtProduct_Productphoto_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productphoto_gxi = value;
            SetDirty("Productphoto_gxi");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProduct_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProduct_Mode_SetNull( )
      {
         gxTv_SdtProduct_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProduct_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProduct_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProduct_Initialized_SetNull( )
      {
         gxTv_SdtProduct_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProduct_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductCode_Z" )]
      [  XmlElement( ElementName = "ProductCode_Z"   )]
      public long gxTpr_Productcode_Z
      {
         get {
            return gxTv_SdtProduct_Productcode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productcode_Z = value;
            SetDirty("Productcode_Z");
         }

      }

      public void gxTv_SdtProduct_Productcode_Z_SetNull( )
      {
         gxTv_SdtProduct_Productcode_Z = 0;
         SetDirty("Productcode_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productcode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductName_Z" )]
      [  XmlElement( ElementName = "ProductName_Z"   )]
      public string gxTpr_Productname_Z
      {
         get {
            return gxTv_SdtProduct_Productname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productname_Z = value;
            SetDirty("Productname_Z");
         }

      }

      public void gxTv_SdtProduct_Productname_Z_SetNull( )
      {
         gxTv_SdtProduct_Productname_Z = "";
         SetDirty("Productname_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductPrice_Z" )]
      [  XmlElement( ElementName = "ProductPrice_Z"   )]
      public decimal gxTpr_Productprice_Z
      {
         get {
            return gxTv_SdtProduct_Productprice_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productprice_Z = value;
            SetDirty("Productprice_Z");
         }

      }

      public void gxTv_SdtProduct_Productprice_Z_SetNull( )
      {
         gxTv_SdtProduct_Productprice_Z = 0;
         SetDirty("Productprice_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductStock_Z" )]
      [  XmlElement( ElementName = "ProductStock_Z"   )]
      public short gxTpr_Productstock_Z
      {
         get {
            return gxTv_SdtProduct_Productstock_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productstock_Z = value;
            SetDirty("Productstock_Z");
         }

      }

      public void gxTv_SdtProduct_Productstock_Z_SetNull( )
      {
         gxTv_SdtProduct_Productstock_Z = 0;
         SetDirty("Productstock_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productstock_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductTypeCode_Z" )]
      [  XmlElement( ElementName = "ProductTypeCode_Z"   )]
      public short gxTpr_Producttypecode_Z
      {
         get {
            return gxTv_SdtProduct_Producttypecode_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Producttypecode_Z = value;
            SetDirty("Producttypecode_Z");
         }

      }

      public void gxTv_SdtProduct_Producttypecode_Z_SetNull( )
      {
         gxTv_SdtProduct_Producttypecode_Z = 0;
         SetDirty("Producttypecode_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Producttypecode_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductTypeName_Z" )]
      [  XmlElement( ElementName = "ProductTypeName_Z"   )]
      public string gxTpr_Producttypename_Z
      {
         get {
            return gxTv_SdtProduct_Producttypename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Producttypename_Z = value;
            SetDirty("Producttypename_Z");
         }

      }

      public void gxTv_SdtProduct_Producttypename_Z_SetNull( )
      {
         gxTv_SdtProduct_Producttypename_Z = "";
         SetDirty("Producttypename_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Producttypename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProductPhoto_GXI_Z" )]
      [  XmlElement( ElementName = "ProductPhoto_GXI_Z"   )]
      public string gxTpr_Productphoto_gxi_Z
      {
         get {
            return gxTv_SdtProduct_Productphoto_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProduct_Productphoto_gxi_Z = value;
            SetDirty("Productphoto_gxi_Z");
         }

      }

      public void gxTv_SdtProduct_Productphoto_gxi_Z_SetNull( )
      {
         gxTv_SdtProduct_Productphoto_gxi_Z = "";
         SetDirty("Productphoto_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtProduct_Productphoto_gxi_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtProduct_Productname = "";
         gxTv_SdtProduct_Producttypename = "";
         gxTv_SdtProduct_Productphoto = "";
         gxTv_SdtProduct_Productphoto_gxi = "";
         gxTv_SdtProduct_Mode = "";
         gxTv_SdtProduct_Productname_Z = "";
         gxTv_SdtProduct_Producttypename_Z = "";
         gxTv_SdtProduct_Productphoto_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "product", "GeneXus.Programs.product_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtProduct_Productstock ;
      private short gxTv_SdtProduct_Producttypecode ;
      private short gxTv_SdtProduct_Initialized ;
      private short gxTv_SdtProduct_Productstock_Z ;
      private short gxTv_SdtProduct_Producttypecode_Z ;
      private long gxTv_SdtProduct_Productcode ;
      private long gxTv_SdtProduct_Productcode_Z ;
      private decimal gxTv_SdtProduct_Productprice ;
      private decimal gxTv_SdtProduct_Productprice_Z ;
      private string gxTv_SdtProduct_Productname ;
      private string gxTv_SdtProduct_Producttypename ;
      private string gxTv_SdtProduct_Mode ;
      private string gxTv_SdtProduct_Productname_Z ;
      private string gxTv_SdtProduct_Producttypename_Z ;
      private string gxTv_SdtProduct_Productphoto_gxi ;
      private string gxTv_SdtProduct_Productphoto_gxi_Z ;
      private string gxTv_SdtProduct_Productphoto ;
   }

   [DataContract(Name = @"Product", Namespace = "Phamarcy")]
   public class SdtProduct_RESTInterface : GxGenericCollectionItem<SdtProduct>
   {
      public SdtProduct_RESTInterface( ) : base()
      {
      }

      public SdtProduct_RESTInterface( SdtProduct psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductCode" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Productcode
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Productcode), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Productcode = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProductName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Productname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Productname) ;
         }

         set {
            sdt.gxTpr_Productname = value;
         }

      }

      [DataMember( Name = "ProductPrice" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Productprice
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Productprice, 9, 2)) ;
         }

         set {
            sdt.gxTpr_Productprice = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ProductStock" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Productstock
      {
         get {
            return sdt.gxTpr_Productstock ;
         }

         set {
            sdt.gxTpr_Productstock = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductTypeCode" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Producttypecode
      {
         get {
            return sdt.gxTpr_Producttypecode ;
         }

         set {
            sdt.gxTpr_Producttypecode = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProductTypeName" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Producttypename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Producttypename) ;
         }

         set {
            sdt.gxTpr_Producttypename = value;
         }

      }

      [DataMember( Name = "ProductPhoto" , Order = 6 )]
      [GxUpload()]
      public string gxTpr_Productphoto
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Productphoto)) ? PathUtil.RelativeURL( sdt.gxTpr_Productphoto) : StringUtil.RTrim( sdt.gxTpr_Productphoto_gxi)) ;
         }

         set {
            sdt.gxTpr_Productphoto = value;
         }

      }

      public SdtProduct sdt
      {
         get {
            return (SdtProduct)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtProduct() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 7 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Product", Namespace = "Phamarcy")]
   public class SdtProduct_RESTLInterface : GxGenericCollectionItem<SdtProduct>
   {
      public SdtProduct_RESTLInterface( ) : base()
      {
      }

      public SdtProduct_RESTLInterface( SdtProduct psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Productname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Productname) ;
         }

         set {
            sdt.gxTpr_Productname = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtProduct sdt
      {
         get {
            return (SdtProduct)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtProduct() ;
         }
      }

   }

}
