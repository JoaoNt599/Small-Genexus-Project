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
namespace GeneXus.Programs.general.services {
   public class notificationsregistrationhandler : GXProcedure
   {
      public notificationsregistrationhandler( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public notificationsregistrationhandler( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_DeviceType ,
                           string aP1_DeviceId ,
                           string aP2_DeviceToken ,
                           string aP3_DeviceName )
      {
         this.AV2DeviceType = aP0_DeviceType;
         this.AV3DeviceId = aP1_DeviceId;
         this.AV4DeviceToken = aP2_DeviceToken;
         this.AV5DeviceName = aP3_DeviceName;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_DeviceType ,
                                 string aP1_DeviceId ,
                                 string aP2_DeviceToken ,
                                 string aP3_DeviceName )
      {
         notificationsregistrationhandler objnotificationsregistrationhandler;
         objnotificationsregistrationhandler = new notificationsregistrationhandler();
         objnotificationsregistrationhandler.AV2DeviceType = aP0_DeviceType;
         objnotificationsregistrationhandler.AV3DeviceId = aP1_DeviceId;
         objnotificationsregistrationhandler.AV4DeviceToken = aP2_DeviceToken;
         objnotificationsregistrationhandler.AV5DeviceName = aP3_DeviceName;
         objnotificationsregistrationhandler.context.SetSubmitInitialConfig(context);
         objnotificationsregistrationhandler.initialize();
         Submit( executePrivateCatch,objnotificationsregistrationhandler);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((notificationsregistrationhandler)stateInfo).executePrivate();
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
         args = new Object[] {(short)AV2DeviceType,(string)AV3DeviceId,(string)AV4DeviceToken,(string)AV5DeviceName} ;
         ClassLoader.Execute("general-services-anotificationsregistrationhandler","GeneXus.Programs","general.services.anotificationsregistrationhandler", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 4 ) )
         {
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV2DeviceType ;
      private string AV3DeviceId ;
      private string AV4DeviceToken ;
      private string AV5DeviceName ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
   }

}
