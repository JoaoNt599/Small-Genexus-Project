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
   [XmlRoot(ElementName = "Item" )]
   [XmlType(TypeName =  "Item" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtWorkWithProduct_Product_List_Grid1Sdt_Item : GxUserType
   {
      public SdtWorkWithProduct_Product_List_Grid1Sdt_Item( )
      {
         /* Constructor for serialization */
         gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productphoto = "";
         gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productphoto_gxi = "";
         gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productname = "";
      }

      public SdtWorkWithProduct_Product_List_Grid1Sdt_Item( IGxContext context )
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
         AddObjectProperty("ProductCode", gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productcode, false, false);
         AddObjectProperty("ProductPhoto", gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productphoto, false, false);
         AddObjectProperty("ProductPhoto_GXI", gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productphoto_gxi, false, false);
         AddObjectProperty("ProductName", gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productname, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "ProductCode" )]
      [  XmlElement( ElementName = "ProductCode"   )]
      public long gxTpr_Productcode
      {
         get {
            return gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productcode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productcode = value;
            SetDirty("Productcode");
         }

      }

      [  SoapElement( ElementName = "ProductPhoto" )]
      [  XmlElement( ElementName = "ProductPhoto"   )]
      [GxUpload()]
      public string gxTpr_Productphoto
      {
         get {
            return gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productphoto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productphoto = value;
            SetDirty("Productphoto");
         }

      }

      [  SoapElement( ElementName = "ProductPhoto_GXI" )]
      [  XmlElement( ElementName = "ProductPhoto_GXI"   )]
      public string gxTpr_Productphoto_gxi
      {
         get {
            return gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productphoto_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productphoto_gxi = value;
            SetDirty("Productphoto_gxi");
         }

      }

      [  SoapElement( ElementName = "ProductName" )]
      [  XmlElement( ElementName = "ProductName"   )]
      public string gxTpr_Productname
      {
         get {
            return gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productname = value;
            SetDirty("Productname");
         }

      }

      public void initialize( )
      {
         gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productphoto = "";
         gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productphoto_gxi = "";
         gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productname = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected long gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productcode ;
      protected string gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productname ;
      protected string gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productphoto_gxi ;
      protected string gxTv_SdtWorkWithProduct_Product_List_Grid1Sdt_Item_Productphoto ;
   }

   [DataContract(Name = @"WorkWithProduct_Product_List_Grid1Sdt.Item", Namespace = "http://tempuri.org/")]
   public class SdtWorkWithProduct_Product_List_Grid1Sdt_Item_RESTInterface : GxGenericCollectionItem<SdtWorkWithProduct_Product_List_Grid1Sdt_Item>
   {
      public SdtWorkWithProduct_Product_List_Grid1Sdt_Item_RESTInterface( ) : base()
      {
      }

      public SdtWorkWithProduct_Product_List_Grid1Sdt_Item_RESTInterface( SdtWorkWithProduct_Product_List_Grid1Sdt_Item psdt ) : base(psdt)
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

      [DataMember( Name = "ProductPhoto" , Order = 1 )]
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

      [DataMember( Name = "ProductName" , Order = 2 )]
      public string gxTpr_Productname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Productname) ;
         }

         set {
            sdt.gxTpr_Productname = value;
         }

      }

      public SdtWorkWithProduct_Product_List_Grid1Sdt_Item sdt
      {
         get {
            return (SdtWorkWithProduct_Product_List_Grid1Sdt_Item)Sdt ;
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
            sdt = new SdtWorkWithProduct_Product_List_Grid1Sdt_Item() ;
         }
      }

   }

}
