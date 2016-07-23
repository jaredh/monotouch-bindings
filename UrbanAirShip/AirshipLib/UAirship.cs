
	[BaseType (typeof (UAObservable))]
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
		void TakeOff (NSDictionary options);

		[Static]
		[Export ("land")]
		void Land ();

		[Static]
		[Export ("shared")]
		UAirship Shared ();

		[Export ("appRegisteredForRemoteNotificationsWithDeviceToken:")]
		void AppRegisteredForRemoteNotificationsWithDeviceToken (NSData token);

		[Export ("registerDeviceTokenWithExtraInfo:")]
		void RegisterDeviceToken (NSDictionary info);

		[Export ("registerDeviceToken:withAlias:")]
		void RegisterDeviceToken (NSData token, string alias);

		[Export ("registerDeviceToken:withExtraInfo:")]
		void RegisterDeviceToken (NSData token, NSDictionary info);

		[Export ("unRegisterDeviceToken")]
		void UnRegisterDeviceToken ();

	}
