//
//  GXAppDelegate.swift
//  PharmacyMenu
//

import Foundation
import GXCoreBL

@objc
public class GXAppDelegate: AppDelegate_Shared {

#if DEBUG
	override public var gxShowDeveloperInfo: Bool {
		get { return true }
	}
#endif

}
