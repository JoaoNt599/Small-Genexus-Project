package com.genexus.phamarcy.pharmacymenu;

import com.genexus.android.core.providers.EntityDataProvider;

public class AppEntityDataProvider extends EntityDataProvider
{
	public AppEntityDataProvider()
	{
		EntityDataProvider.AUTHORITY = "com.genexus.phamarcy.pharmacymenu.appentityprovider";
		EntityDataProvider.URI_MATCHER = buildUriMatcher();
	}
}
