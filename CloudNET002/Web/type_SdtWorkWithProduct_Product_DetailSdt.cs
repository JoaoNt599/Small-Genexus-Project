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
   [XmlRoot(ElementName = "WorkWithProduct_Product_DetailSdt" )]
   [XmlType(TypeName =  "WorkWithProduct_Product_DetailSdt" , Namespace = "http://tempuri.org/" )]
   [Serializable]
   public class SdtWorkWithProduct_Product_DetailSdt : GxUserType
   {
      public SdtWorkWithProduct_Product_DetailSdt( )
      {
         /* Constructor for serialization */
         gxTv_SdtWorkWithProduct_Product_DetailSdt_Gxdynprop = "";
      }

      public SdtWorkWithProduct_Product_DetailSdt( IGxContext context )
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
         AddObjectProperty("Gxdynprop", gxTv_SdtWorkWithProduct_Product_DetailSdt_Gxdynprop, false, false);
         return  ;
      }

      [  SoapElement( ElementName = "Gxdynprop" )]
      [  XmlElement( ElementName = "Gxdynprop"   )]
      public string gxTpr_Gxdynprop
      {
         get {
            return gxTv_SdtWorkWithProduct_Product_DetailSdt_Gxdynprop ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkWithProduct_Product_DetailSdt_Gxdynprop = value;
            SetDirty("Gxdynprop");
         }

      }

      public void initialize( )
      {
         gxTv_SdtWorkWithProduct_Product_DetailSdt_Gxdynprop = "";
         sdtIsNull = 1;
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      protected short sdtIsNull ;
      protected string gxTv_SdtWorkWithProduct_Product_DetailSdt_Gxdynprop ;
   }

   [DataContract(Name = @"WorkWithProduct_Product_DetailSdt", Namespace = "http://tempuri.org/")]
   public class SdtWorkWithProduct_Product_DetailSdt_RESTInterface : GxGenericCollectionItem<SdtWorkWithProduct_Product_DetailSdt>
   {
      public SdtWorkWithProduct_Product_DetailSdt_RESTInterface( ) : base()
      {
      }

      public SdtWorkWithProduct_Product_DetailSdt_RESTInterface( SdtWorkWithProduct_Product_DetailSdt psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Gxdynprop" , Order = 0 )]
      public string gxTpr_Gxdynprop
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gxdynprop) ;
         }

         set {
            sdt.gxTpr_Gxdynprop = value;
         }

      }

      public SdtWorkWithProduct_Product_DetailSdt sdt
      {
         get {
            return (SdtWorkWithProduct_Product_DetailSdt)Sdt ;
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
            sdt = new SdtWorkWithProduct_Product_DetailSdt() ;
         }
      }

   }

}
