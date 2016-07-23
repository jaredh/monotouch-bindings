using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;

namespace UrbanAirship
{
	[BaseType (typeof (NSObject))]
	interface UAirship {
		[Export ("deviceToken")]
		string DeviceToken { get; set;  }

		[Export ("analytics")]
		UAAnalytics Analytics { get; set;  }

		[Export ("server")]
		string Server { get; set;  }

		[Export ("appId")]
		string AppId { get; set;  }

		[Export ("appSecret")]
		string AppSecret { get; set;  }

		[Export ("deviceTokenHasChanged")]
		bool DeviceTokenHasChanged { get; set;  }

		[Export ("ready")]
		bool Ready { get; set;  }

		[Static]
		[Export ("setLogging:")]
		void SetLogging (bool enabled);

		[Static]
		[Export ("takeOff:")]
		void TakeOff (UAConfig config);

		[Static]
		[Export ("land")]
		void Land ();

		[Static]
		[Export ("shared")]
		UAirship Shared { get; }



//		[Export ("registerDeviceTokenWithExtraInfo:")]
//		void RegisterDeviceToken (NSDictionary info);

		[Export ("registerDeviceToken:withAlias:")]
		void RegisterDeviceToken (NSData token, string alias);

		[Export ("registerDeviceToken:withExtraInfo:")]
		void RegisterDeviceToken (NSData token, NSDictionary info);

		[Export ("unRegisterDeviceToken")]
		void UnRegisterDeviceToken ();

	}

	[BaseType (typeof (NSObject))]
	interface UAConfig {
		[Export ("appKey")]
		string AppKey { get; set; }

		[Export ("appSecret")]
		string AppSecret { get; set; }

		[Export ("logLevel")]
		UALogLevel LogLevel { get; set; }

		[Export ("inProduction")]
		bool InProduction { get; set; }

		[Export ("analyticsEnabled")]
		bool AnalyticsEnabled { get; set; }

		[Export ("developmentAppKey")]
		string DevelopmentAppKey { get; set; }

		[Export ("developmentAppSecret")]
		string DevelopmentAppSecret { get; set; }

		[Export ("productionAppKey")]
		string ProductionAppKey { get; set; }

		[Export ("productionAppSecret")]
		string ProductionAppSecret { get; set; }

		[Export ("developmentLogLevel")]
		string DevelopmentLogLevel { get; set; }

		[Export ("productionLogLevel")]
		string ProductionLogLevel { get; set; }

		[Export ("cacheDiskSizeInMB")]
		int CacheDiskSizeInMB { get; set; }

		[Export ("automaticSetupEnabled")]
		bool AutomaticSetupEnabled { get; set; }

		[Export ("detectProvisioningMode")]
		bool DetectProvisioningMode { get; set; }

		[Export ("clearKeychain")]
		bool ClearKeychain { get; set; }

		[Export ("deviceAPIURL")]
		string DeviceAPIURL { get; set; }

		[Export ("analyticsURL")]
		string AnalyticsURL { get; set; }

		[Static]
		[Export ("defaultConfig")]
		UAConfig DefaultConfig ();

		[Static]
		[Export ("configWithContentsOfFile")]
		UAConfig ConfigWithContentsOfFile (string path);

		[Static]
		[Export ("config")]
		UAConfig Config ();
	}

	[BaseType (typeof (NSObject), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(UAPushNotificationDelegate)})]
	interface UAPush {
		[Export ("useCustomUI")]
		NSObject UseCustomUI { get; set;  }

		[Export ("openApnsSettings:animated:")]
		void OpenApnsSettings(UIViewController viewController, bool animated);
		
		[Export ("closeApnsSettingsAnimated:")]
		void CloseApnsSettings(bool animated);

		[Export ("channelID")]
		string ChannelID { get; }
		
		[Export ("land")]
		void Land();

		[Static]
		[Export ("shared")]
		UAPush Shared { get; }
		
		[Export ("updateRegistration")]
		void UpdateRegistration();

		[Export ("currentEnabledNotificationTypes")]
		UIUserNotificationType CurrentEnabledNotificationTypes { get; }
		
		[Export ("addTag:")]
		void AddTag(string tag);
		
		[Export ("addTags:")]
		void AddTags(string[] tags);

		[Export ("removeTag:")]
		void RemoveTag(string tag);

		[Export ("removeTags:")]
		void RemoveTags(string[] tags); 
		
		[Export ("updateAlias:")]
		void UpdateAlias (string value);
		
		[Export ("updateTags:")]
		void UpdateTags(string[] value);
		
		[Export ("userNotificationTypes")]
		UIUserNotificationType UserNotificationTypes { get; set; }

		[Export ("userPushNotificationsEnabled")]
		bool UserPushNotificationsEnabled { get; }

		[Export ("userPushNotificationsEnabledByDefault")]
		bool UserPushNotificationsEnabledByDefault { get; set; }

		[Export ("backgroundPushNotificationsEnabled")]
		bool BackgroundPushNotificationsEnabled { get; }

		[Export ("backgroundPushNotificationsEnabledByDefault")]
		bool BackgroundPushNotificationsEnabledByDefault { get; set; }

		[Export ("setQuietTimeStartHour:startMinute:endHour:endMinute:")]
		void SetQuietTime(NSDate startHour, NSDate startMinute, NSDate endHour, NSDate endMinute);
		
		[Export ("disableQuietTime")]
		void DisableQuietTime();
		
		[Export ("enableAutobadge:")]
		void EnableAutobadge (bool enabled);
		
		[Export ("setBadgeNumber:")]
		void SetBadgeNumber (int badgeNumber);
		
		[Export ("resetBadge")]
		void ResetBadge();
		
		[Export("handleNotification:applicationState:")]
		void HandleNotification(NSDictionary notification, UIApplicationState state);
		
		[Export("pushTypeString:")]
		string PushTypeString (UIRemoteNotificationType types);

		[Wrap ("WeakDelegate")]
		UAPushNotificationDelegate WeakDelegate { get; set; }

	}

	[BaseType (typeof(NSObject))]
	[Model]
	[Protocol]
	interface UAPushNotificationDelegate
	{
		[Export ("displayNotificationAlert:")]
		void DisplayNotificationAlert (string alertMessage);

		[Export ("displayLocalizedNotificationAlert:")]
		void DisplayLocalizedNotificationAlert (NSDictionary alertDict);

		[Export ("playNotificationSound:")]
		void PlayNotificationSound (string sound);

		[Export ("handleNotification:withCustomPayload:"), EventArgs ("NotificationWithCustomPayload")]
		void HandleNotificationWithCustomPayload (NSDictionary notification, NSDictionary customPayload);

		[Export ("handleBadgeUpdate:")]
		void HandleBadgeUpdate (int badgeNumber);

		[Export ("handleBackgroundNotification:")]
		void HandleBackgroundNotification (NSDictionary notification);

	}

	[BaseType (typeof(NSObject), Delegates=new string [] { "WeakDelegate" }, Events=new Type [] {typeof(UAHTTPConnectionDelegate)})]
	interface UAAnalytics
	{
		[Export ("server")]
		string Server { get; set; }

		[Export ("session")]
		NSMutableDictionary Session { get; }

		[Export ("databaseSize")]
		int DatabaseSize { get; }

		[Export ("x_ua_max_total")]
		int X_ua_max_total { get; }

		[Export ("x_ua_max_batch")]
		int X_ua_max_batch { get; }

		[Export ("x_ua_max_wait")]
		int X_ua_max_wait { get; }

		[Export ("x_ua_min_batch_interval")]
		int X_ua_min_batch_interval { get; }

		[Export ("sendInterval")]
		int SendInterval { get; set; }

		[Export ("oldestEventTime")]
		double OldestEventTime { get; }

		[Export ("lastSendTime")]
		NSDate LastSendTime { get; }

		[Export ("initWithOptions:")]
		IntPtr Constructor (NSDictionary options);

		[Export ("restoreFromDefault")]
		void RestoreFromDefault ();

		[Export ("saveDefault")]
		void SaveDefault ();

		[Export ("addEvent:")]
		void AddEvent (UAEvent theEvent);

		[Export ("handleNotification:")]
		void HandleNotification (NSDictionary userInfo);

		[Export ("resetEventsDatabaseStatus")]
		void ResetEventsDatabaseStatus ();

		[Export ("sendIfNeeded")]
		void SendIfNeeded ();
			
		[Wrap ("WeakDelegate")]
		UAHTTPConnectionDelegate WeakDelegate { get; set; }
	}
	



	
	[BaseType (typeof(NSObject))]
	interface UAEvent
	{
		[Export ("time")]
		string Time { get; }

		[Export ("event_id")]
		string Event_id { get; }

		[Export ("data")]
		NSMutableDictionary Data { get; }

		[Static]
		[Export ("event")]
		UAEvent Event ();

		[Export ("initWithContext:")]
		IntPtr Constructor (NSDictionary context);

		[Static]
		[Export ("eventWithContext:")]
		NSObject FromContext (NSDictionary context);

		[Export ("getType")]
		string EventType { get; }

		[Export ("gatherData:")]
		void GatherData (NSDictionary context);

		[Export ("getEstimatedSize")]
		int GetEstimatedSize ();

	}


	[BaseType (typeof(UAEvent))]
	interface UAEventAppInit
	{
	}

	[BaseType (typeof(UAEventAppInit))]
	interface UAEventAppForeground
	{
	}

	[BaseType (typeof(UAEvent))]
	interface UAEventAppExit
	{
	}

	[BaseType (typeof(UAEventAppExit))]
	interface UAEventAppBackground
	{
	}

	[BaseType (typeof(UAEvent))]
	interface UAEventDeviceRegistration
	{
	}

	[BaseType (typeof(UAEvent))]
	interface UAEventPushReceived
	{
	}
	
	[BaseType (typeof(NSObject))]
	interface UAHTTPRequest
	{
		[Export ("HTTPMethod")]
		string HTTPMethod { get; set; }

		[Export ("headers")]
		NSDictionary Headers { get; }

		[Export ("username")]
		string Username { get; set; }

		[Export ("password")]
		string Password { get; set; }

		[Export ("body")]
		NSData Body { get; set; }

		[Export ("compressBody")]
		bool CompressBody { get; set; }

		[Export ("userInfo")]
		NSObject UserInfo { get; set; }

		[Static]
		[Export ("requestWithURLString:")]
		UAHTTPRequest RequestWithURLString (string urlString);

		[Export ("initWithURLString:")]
		IntPtr Constructor (string urlString);

		[Export ("addRequestHeader:value:")]
		void AddRequestHeadervalue (string header, string value);

		[Export ("appendBodyData:")]
		void AppendBodyData (NSData data);

	}

	[BaseType (typeof(NSObject))]
	[Model]
	[Protocol]
	interface UAHTTPConnectionDelegate
	{
		[Abstract]
		[Export ("requestDidSucceed:response:responseData:"), EventArgs ("UAHTTPConnectionSucceeded")]
		void Success (UAHTTPRequest request, NSHttpUrlResponse response, NSData responseData);

		[Abstract]
		[Export ("requestDidFail:")]
		void Failed (UAHTTPRequest request);

	}

	[BaseType (typeof(NSObject))]
	interface UAHTTPConnection
	{
		[Static]
		[Export ("connectionWithRequest:")]
		UAHTTPConnection ConnectionWithRequest (UAHTTPRequest httpRequest);

		[Export ("initWithRequest:")]
		IntPtr Constructor (UAHTTPRequest httpRequest);

		[Export ("start")]
		bool Start ();

		[Export ("connection:didReceiveResponse:")]
		void ReceivedResponse (NSUrlConnection connection, NSHttpUrlResponse response);

		[Export ("connection:didReceiveData:")]
		void ConnectionReceivedData (NSUrlConnection connection, NSData data);

		[Export ("connection:didFailWithError:")]
		void ConnectionFailed (NSUrlConnection connection, NSError error);

		[Export ("connectionDidFinishLoading:")]
		void FinishedLoading (NSUrlConnection connection);
	
	}
	
	[BaseType (typeof(NSObject))]
	interface UAKeychainUtils
	{
		[Static]
		[Export ("createKeychainValueForUsername:withPassword:forIdentifier:")]
		bool CreateKeychainValue (string username, string password, string identifier);

		[Static]
		[Export ("deleteKeychainValue:")]
		void DeleteKeychainValue (string identifier);

		[Static]
		[Export ("updateKeychainValueForUsername:withPassword:withEmailAddress:forIdentifier:")]
		bool UpdateKeychainValue (string username, string password, string email, string identifier);

		[Static]
		[Export ("getPassword:")]
		string GetPassword (string identifier);

		[Static]
		[Export ("getUsername:")]
		string GetUsername (string identifier);

		[Static]
		[Export ("getEmailAddress:")]
		string GetEmailAddress (string identifier);
	}
	
	[BaseType (typeof (NSObject))]
	interface UASQLite {
		[Export ("busyRetryTimeout")]
		int BusyRetryTimeout { get; set;  }

		[Export ("dbPath")]
		string DbPath { get;  }

		[Export ("initWithDBPath:")]
		IntPtr Constructor (string aDBPath);

		[Export ("open:")]
		bool Open (string aDBPath);

		[Export ("close")]
		void Close ();

		[Export ("lastErrorMessage")]
		string LastErrorMessage ();

		[Export ("lastErrorCode")]
		int LastErrorCode ();

		[Export ("executeQuery:")]
		NSArray ExecuteQuery (string sql);

		[Export ("executeQuery:arguments:")]
		NSArray ExecuteQuery (string sql, string[] args);

		[Export ("executeUpdate:")]
		bool ExecuteUpdate (string sql );

		[Export ("executeUpdate:arguments:")]
		bool ExecuteUpdate (string sql, string[] args);

		[Export ("commit")]
		bool Commit ();

		[Export ("rollback")]
		bool Rollback ();

		[Export ("beginTransaction")]
		bool BeginTransaction ();

		[Export ("beginDeferredTransaction")]
		bool BeginDeferredTransaction ();

		[Export ("tableExists:")]
		bool TableExists (string tableName);

		[Export ("indexExists:")]
		bool IndexExists (string indexName);

	}
	
	
	[BaseType (typeof (NSObject))]
	interface UATagUtils {
		[Static]
		[Export ("createTags:tags")]
		NSArray CreateTagstags (UATagType tags );

	}



}
