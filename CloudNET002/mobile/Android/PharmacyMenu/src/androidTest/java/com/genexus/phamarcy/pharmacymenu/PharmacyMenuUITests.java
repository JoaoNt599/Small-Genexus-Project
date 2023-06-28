package com.genexus.phamarcy.pharmacymenu;

import androidx.test.ext.junit.runners.AndroidJUnit4;
import androidx.test.filters.LargeTest;

import com.artech.base.services.IGxProcedure;

import com.genexus.android.core.activities.StartupActivity;
import com.genexus.android.core.layers.GxObjectFactory;
import com.genexus.android.uitesting.logging.TestWatcher;
import com.genexus.android.uitesting.rules.GenexusActivityTestRule;

import org.junit.FixMethodOrder;
import org.junit.Rule;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.MethodSorters;

@FixMethodOrder(MethodSorters.NAME_ASCENDING)
@RunWith(AndroidJUnit4.class)
@LargeTest
public class PharmacyMenuUITests {
    @Rule
    public GenexusActivityTestRule<StartupActivity> mActivityRule = new GenexusActivityTestRule<>(StartupActivity.class);

    @Rule
    public TestWatcher mTestWatcher = new TestWatcher("");

}
