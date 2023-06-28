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
   public class SdtGx0020sd_Level_Detail_Grid1Sdt_Item : GxUserType
   {
      public SdtGx0020sd_Level_Detail_Grid1Sdt_Item( )
      {
         /* Constructor for serialization */
      }

      public SdtGx0020sd_Level_Detail_Grid1Sdt_Item( IGxContext context )
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
         AddObjectProperty("ProductTypeCode", gxTv_SdtGx0020sd_Level_Detail_Grid1Sdt_Item_Producttypecode, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "ProductTypeCode" )]
      [  XmlElement( ElementName = "ProductTypeCode"   )]
      public short gxTpr_Producttypecode
      {
         get {
            return gxTv_SdtGx0020sd_Level_Detail_Grid1Sdt_Item_Producttypecode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtGx0020sd_Level_Detail_Grid1Sdt_Item_Producttypecode = value;
            SetDirty("Producttypecode");
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short gxTv_SdtGx0020sd_Level_Detail_Grid1Sdt_Item_Producttypecode ;
      protected short sdtIsNull ;
   }

   [DataContract(Name = @"Gx0020sd_Level_Detail_Grid1Sdt.Item", Namespace = "http://tempuri.org/")]
   public class SdtGx0020sd_Level_Detail_Grid1Sdt_Item_RESTInterface : GxGenericCollectionItem<SdtGx0020sd_Level_Detail_Grid1Sdt_Item>
   {
      public SdtGx0020sd_Level_Detail_Grid1Sdt_Item_RESTInterface( ) : base()
      {
      }

      public SdtGx0020sd_Level_Detail_Grid1Sdt_Item_RESTInterface( SdtGx0020sd_Level_Detail_Grid1Sdt_Item psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProductTypeCode" , Order = 0 )]
      public Nullable<short> gxTpr_Producttypecode
      {
         get {
            return sdt.gxTpr_Producttypecode ;
         }

         set {
            sdt.gxTpr_Producttypecode = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtGx0020sd_Level_Detail_Grid1Sdt_Item sdt
      {
         get {
            return (SdtGx0020sd_Level_Detail_Grid1Sdt_Item)Sdt ;
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
            sdt = new SdtGx0020sd_Level_Detail_Grid1Sdt_Item() ;
         }
      }

   }

}
