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
   [XmlRoot(ElementName = "WorkWithProduct_Product_Section_GeneralSdt" )]
   [XmlType(TypeName =  "WorkWithProduct_Product_Section_GeneralSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtWorkWithProduct_Product_Section_GeneralSdt : GxUserType
   {
      public SdtWorkWithProduct_Product_Section_GeneralSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productname = "";
         gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Producttypename = "";
         gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productphoto = "";
         gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productphoto_gxi = "";
      }

      public SdtWorkWithProduct_Product_Section_GeneralSdt( IGxContext context )
      {
         this.context = context;
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
         AddObjectProperty("ProductCode", gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productcode, false, false);
         AddObjectProperty("ProductName", gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productname, false, false);
         AddObjectProperty("ProductPrice", gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productprice, false, false);
         AddObjectProperty("ProductStock", gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productstock, false, false);
         AddObjectProperty("ProductTypeCode", gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Producttypecode, false, false);
         AddObjectProperty("ProductTypeName", gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Producttypename, false, false);
         AddObjectProperty("ProductPhoto", gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productphoto, false, false);
         AddObjectProperty("ProductPhoto_GXI", gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productphoto_gxi, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "ProductCode" )]
      [  XmlElement( ElementName = "ProductCode"   )]
      public long gxTpr_Productcode
      {
         get {
            return gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productcode = value;
            SetDirty("Productcode");
         }

      }

      [  SoapElement( ElementName = "ProductName" )]
      [  XmlElement( ElementName = "ProductName"   )]
      public string gxTpr_Productname
      {
         get {
            return gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productname = value;
            SetDirty("Productname");
         }

      }

      [  SoapElement( ElementName = "ProductPrice" )]
      [  XmlElement( ElementName = "ProductPrice"   )]
      public decimal gxTpr_Productprice
      {
         get {
            return gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productprice ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productprice = value;
            SetDirty("Productprice");
         }

      }

      [  SoapElement( ElementName = "ProductStock" )]
      [  XmlElement( ElementName = "ProductStock"   )]
      public short gxTpr_Productstock
      {
         get {
            return gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productstock ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productstock = value;
            SetDirty("Productstock");
         }

      }

      [  SoapElement( ElementName = "ProductTypeCode" )]
      [  XmlElement( ElementName = "ProductTypeCode"   )]
      public short gxTpr_Producttypecode
      {
         get {
            return gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Producttypecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Producttypecode = value;
            SetDirty("Producttypecode");
         }

      }

      [  SoapElement( ElementName = "ProductTypeName" )]
      [  XmlElement( ElementName = "ProductTypeName"   )]
      public string gxTpr_Producttypename
      {
         get {
            return gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Producttypename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Producttypename = value;
            SetDirty("Producttypename");
         }

      }

      [  SoapElement( ElementName = "ProductPhoto" )]
      [  XmlElement( ElementName = "ProductPhoto"   )]
      [GxUpload()]
      public string gxTpr_Productphoto
      {
         get {
            return gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productphoto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productphoto = value;
            SetDirty("Productphoto");
         }

      }

      [  SoapElement( ElementName = "ProductPhoto_GXI" )]
      [  XmlElement( ElementName = "ProductPhoto_GXI"   )]
      public string gxTpr_Productphoto_gxi
      {
         get {
            return gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productphoto_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productphoto_gxi = value;
            SetDirty("Productphoto_gxi");
         }

      }

      public void initialize( )
      {
         gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productname = "";
         gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Producttypename = "";
         gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productphoto = "";
         gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productphoto_gxi = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected short gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productstock ;
      protected short gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Producttypecode ;
      protected long gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productcode ;
      protected decimal gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productprice ;
      protected string gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productname ;
      protected string gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Producttypename ;
      protected string gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productphoto_gxi ;
      protected string gxTv_SdtWorkWithProduct_Product_Section_GeneralSdt_Productphoto ;
   }

   [DataContract(Name = @"WorkWithProduct_Product_Section_GeneralSdt", Namespace = "http://tempuri.org/")]
   public class SdtWorkWithProduct_Product_Section_GeneralSdt_RESTInterface : GxGenericCollectionItem<SdtWorkWithProduct_Product_Section_GeneralSdt>
   {
      public SdtWorkWithProduct_Product_Section_GeneralSdt_RESTInterface( ) : base()
      {
      }

      public SdtWorkWithProduct_Product_Section_GeneralSdt_RESTInterface( SdtWorkWithProduct_Product_Section_GeneralSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductCode" , Order = 0 )]
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

      public SdtWorkWithProduct_Product_Section_GeneralSdt sdt
      {
         get {
            return (SdtWorkWithProduct_Product_Section_GeneralSdt)Sdt ;
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
            sdt = new SdtWorkWithProduct_Product_Section_GeneralSdt() ;
         }
      }

   }

}
