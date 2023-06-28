//
//  GXUserNotificationsManager+Optionals.m
//  PharmacyMenu
//

#if TARGET_OS_IOS

@import GXCoreBL;

@implementation GXUserNotificationsManager (GXUserNotificatinManagerOptionals)

- (BOOL)supportsRemoteNotifications {
	return NO;
}

- (BOOL)supportsLocalNotifications {
	return NO;
}

@end
#endif // TARGET_OS_IOS
