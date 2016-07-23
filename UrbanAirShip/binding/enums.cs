using System;

namespace UrbanAirship
{
	public enum UALocalStorageType
	{
		/**
     * Represents permanent data that should be backed up.
     */
		Critical = 0,
		/**
     * Represents semi-permanent data such as caches, that can be regenerated.
     */
		Cached = 1,
		/**
     * Represents temporary data.
     */
		Temporary = 2,
		/**
     * Represents permanent data that should not be backed up.
     */
		Offline = 3
	}

	public enum UALogLevel
	{
		Undefined = -1,
		None = 0,
		Error = 1,
		Warn = 2,
		Info = 3,
		Debug = 4,
		Trace = 5
	}
	
	public enum UATagType
	{
		TimeZone             = 1 << 0, /** Full Time Zone: "America/Los_Angeles" */
		TimeZoneAbbreviation = 1 << 1, /** Abbreviated Time Zone: "PST" Note: Containst DST info and may abbreviations may conflict with other time zones. */
		Language             = 1 << 2, /** Language Code, with prefix: "language_en" */
		Country              = 1 << 3, /** Country Code, with prefix: "country_us" */
		DeviceType           = 1 << 4  /** Device type: iPhone, iPad or iPod */
}
	;

}
