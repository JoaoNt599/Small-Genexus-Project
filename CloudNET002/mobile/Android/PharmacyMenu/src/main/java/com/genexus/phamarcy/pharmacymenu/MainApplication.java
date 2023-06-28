package com.genexus.phamarcy.pharmacymenu;
import android.content.Context;
import androidx.multidex.MultiDex;

import com.artech.base.services.AndroidContext;
import com.artech.base.services.IGxProcedure;

import com.genexus.android.ContextImpl;
import com.genexus.android.core.application.MyApplication;
import com.genexus.android.core.base.metadata.GenexusApplication;
import com.genexus.android.core.base.services.Services;
import com.genexus.android.core.providers.EntityDataProvider;

import com.genexus.Application;
import com.genexus.ClientContext;

public class MainApplication extends MyApplication
{
	@Override
	public final void onCreate()
	{
		GenexusApplication application = new GenexusApplication();
		application.setName("phamarcy");
		application.setAPIUri("https://trialapps3.genexus.com/Id4e90c195d19901033ca49a8c782c9a53/");
		application.setAppEntry("PharmacyMenu");
		application.setMajorVersion(1);
		application.setMinorVersion(0);

		// Extensibility Point for Logging
 

		// Security
		application.setIsSecure(false);
		application.setEnableAnonymousUser(false);
		application.setClientId("");
		application.setLoginObject("");
		application.setNotAuthorizedObject("");
		application.setChangePasswordObject("");
		//application.setCompleteUserDataObject("");

		application.setAllowWebViewExecuteJavascripts(true);
		application.setAllowWebViewExecuteLocalFiles(true);

		application.setShareSessionToWebView(false);

		// Dynamic Url		
		application.setUseDynamicUrl(false);
		application.setDynamicUrlAppId("Phamarcy");
		application.setDynamicUrlPanel("");

		// Notifications
		application.setUseNotification(false);
		application.setNotificationSenderId("");
		application.setNotificationRegistrationHandler("(none)");

		setApp(application);

		registerModule(new com.genexus.android.core.externalobjects.CoreExternalObjectsModule());

		registerModule(new com.genexus.android.core.usercontrols.CoreUserControlsModule());

		registerModule(new com.genexus.android.controls.grids.smart.SmartGridModule());


	

		super.onCreate();

		

    }

	@Override
	public Class<? extends com.genexus.android.core.services.EntityService> getEntityServiceClass()
	{
		return AppEntityService.class;
	}

	@Override
	public EntityDataProvider getProvider()
	{
		return new AppEntityDataProvider();
	}

	@Override
	protected void attachBaseContext(Context base)
	{
		super.attachBaseContext(base);
		MultiDex.install(this);
	}

}
