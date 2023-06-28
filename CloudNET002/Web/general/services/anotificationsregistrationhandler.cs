using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class anotificationsregistrationhandler : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new general.services.anotificationsregistrationhandler().executeCmdLine(args); ;
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
            return 1 ;
         }
      }

      public int executeCmdLine( string[] args )
      {
          short aP0_DeviceType ;
         string aP1_DeviceId = new string(' ',0)  ;
         string aP2_DeviceToken = new string(' ',0)  ;
         string aP3_DeviceName = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_DeviceType=((short)(NumberUtil.Val( (string)(args[0]), ".")));
         }
         else
         {
            aP0_DeviceType=0;
         }
         if ( 1 < args.Length )
         {
            aP1_DeviceId=((string)(args[1]));
         }
         else
         {
            aP1_DeviceId="";
         }
         if ( 2 < args.Length )
         {
            aP2_DeviceToken=((string)(args[2]));
         }
         else
         {
            aP2_DeviceToken="";
         }
         if ( 3 < args.Length )
         {
            aP3_DeviceName=((string)(args[3]));
         }
         else
         {
            aP3_DeviceName="";
         }
         execute(aP0_DeviceType, aP1_DeviceId, aP2_DeviceToken, aP3_DeviceName);
         return GX.GXRuntime.ExitCode ;
      }

      public anotificationsregistrationhandler( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("Phamarcy", true);
      }

      public anotificationsregistrationhandler( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( short aP0_DeviceType ,
                           string aP1_DeviceId ,
                           string aP2_DeviceToken ,
                           string aP3_DeviceName )
      {
         this.AV11DeviceType = aP0_DeviceType;
         this.AV8DeviceId = aP1_DeviceId;
         this.AV10DeviceToken = aP2_DeviceToken;
         this.AV9DeviceName = aP3_DeviceName;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_DeviceType ,
                                 string aP1_DeviceId ,
                                 string aP2_DeviceToken ,
                                 string aP3_DeviceName )
      {
         anotificationsregistrationhandler objanotificationsregistrationhandler;
         objanotificationsregistrationhandler = new anotificationsregistrationhandler();
         objanotificationsregistrationhandler.AV11DeviceType = aP0_DeviceType;
         objanotificationsregistrationhandler.AV8DeviceId = aP1_DeviceId;
         objanotificationsregistrationhandler.AV10DeviceToken = aP2_DeviceToken;
         objanotificationsregistrationhandler.AV9DeviceName = aP3_DeviceName;
         objanotificationsregistrationhandler.context.SetSubmitInitialConfig(context);
         objanotificationsregistrationhandler.initialize();
         Submit( executePrivateCatch,objanotificationsregistrationhandler);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((anotificationsregistrationhandler)stateInfo).executePrivate();
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
         context.StatusMessage( StringUtil.Trim( AV10DeviceToken) );
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

      public override void initialize( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11DeviceType ;
      private string AV8DeviceId ;
      private string AV10DeviceToken ;
      private string AV9DeviceName ;
   }

}
