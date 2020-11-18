using System;
using Foundation;
using ObjCRuntime;
using WebKit;

namespace Xamarin.Openpay
{
	// @interface OPAddress : NSObject
	[BaseType(typeof(NSObject))]
	interface OPAddress
	{
		// @property NSString * postalCode;
		[Export("postalCode")]
		string PostalCode { get; set; }

		// @property NSString * line1;
		[Export("line1")]
		string Line1 { get; set; }

		// @property NSString * line2;
		[Export("line2")]
		string Line2 { get; set; }

		// @property NSString * line3;
		[Export("line3")]
		string Line3 { get; set; }

		// @property NSString * city;
		[Export("city")]
		string City { get; set; }

		// @property NSString * state;
		[Export("state")]
		string State { get; set; }

		// @property NSString * countryCode;
		[Export("countryCode")]
		string CountryCode { get; set; }

		// -(NSMutableDictionary *)asMutableDictionary;
		[Export("asMutableDictionary")]
		NSMutableDictionary AsMutableDictionary { get; }

		// +(OPAddress *)initWithDictionary:(NSMutableDictionary *)dictionary;
		[Static]
		[Export("initWithDictionary:")]
		OPAddress InitWithDictionary(NSMutableDictionary dictionary);
	}

	// @interface OPCard : NSObject
	[BaseType(typeof(NSObject))]
	interface OPCard
	{
		// @property NSDate * creationDate;
		[Export("creationDate", ArgumentSemantic.Assign)]
		NSDate CreationDate { get; set; }

		// @property NSString * id;
		[Export("id")]
		string Id { get; set; }

		// @property NSString * bankName;
		[Export("bankName")]
		string BankName { get; set; }

		// @property BOOL allowPayouts;
		[Export("allowPayouts")]
		bool AllowPayouts { get; set; }

		// @property NSString * holderName;
		[Export("holderName")]
		string HolderName { get; set; }

		// @property NSString * expirationMonth;
		[Export("expirationMonth")]
		string ExpirationMonth { get; set; }

		// @property NSString * expirationYear;
		[Export("expirationYear")]
		string ExpirationYear { get; set; }

		// @property OPAddress * address;
		[Export("address", ArgumentSemantic.Assign)]
		OPAddress Address { get; set; }

		// @property NSString * number;
		[Export("number")]
		string Number { get; set; }

		// @property NSString * brand;
		[Export("brand")]
		string Brand { get; set; }

		// @property BOOL allowsCharges;
		[Export("allowsCharges")]
		bool AllowsCharges { get; set; }

		// @property NSString * bankCode;
		[Export("bankCode")]
		string BankCode { get; set; }

		// @property NSString * cvv2;
		[Export("cvv2")]
		string Cvv2 { get; set; }

		// @property (readonly, getter = getType, assign, nonatomic) OPCardType type;
		[Export("type", ArgumentSemantic.Assign)]
		OPCardType Type { [Bind("getType")] get; }

		// @property (readonly, getter = getValid, assign, nonatomic) BOOL valid;
		[Export("valid")]
		bool Valid { [Bind("getValid")] get; }

		// @property (readonly, getter = getNumberValid, assign, nonatomic) BOOL numberValid;
		[Export("numberValid")]
		bool NumberValid { [Bind("getNumberValid")] get; }

		// @property (readonly, getter = getExpired, assign, nonatomic) BOOL expired;
		[Export("expired")]
		bool Expired { [Bind("getExpired")] get; }

		// @property (readonly, getter = getSecurityCodeCheck, assign, nonatomic) OPCardSecurityCodeCheck securityCodeCheck;
		[Export("securityCodeCheck", ArgumentSemantic.Assign)]
		OPCardSecurityCodeCheck SecurityCodeCheck { [Bind("getSecurityCodeCheck")] get; }

		// @property (nonatomic, strong) NSMutableArray * errors;
		[Export("errors", ArgumentSemantic.Strong)]
		NSMutableArray Errors { get; set; }

		// -(NSMutableDictionary *)asMutableDictionary;
		[Export("asMutableDictionary")]
		NSMutableDictionary AsMutableDictionary { get; }

		// +(OPCard *)initWithDictionary:(NSMutableDictionary *)dictionary;
		[Static]
		[Export("initWithDictionary:")]
		OPCard InitWithDictionary(NSMutableDictionary dictionary);
	}

	// @interface OPToken : NSObject
	[BaseType(typeof(NSObject))]
	interface OPToken
	{
		// @property NSString * id;
		[Export("id")]
		string Id { get; set; }

		// @property OPCard * card;
		[Export("card", ArgumentSemantic.Assign)]
		OPCard Card { get; set; }

		// +(OPToken *)initWithDictionary:(NSMutableDictionary *)dictionary;
		[Static]
		[Export("initWithDictionary:")]
		OPToken InitWithDictionary(NSMutableDictionary dictionary);
	}

	// typedef void (^OpenpayTokenizeResponseBlock)(OPToken *);
	delegate void OpenpayTokenizeResponseBlock(OPToken arg0);

	// typedef void (^OpenpayErrorBlock)(NSError *);
	delegate void OpenpayErrorBlock(NSError arg0);

	// @interface Openpay : NSObject <NSURLConnectionDelegate>
	[BaseType(typeof(NSObject))]
	interface Openpay : INSUrlConnectionDelegate
	{
		// @property NSString * merchantId;
		[Export("merchantId")]
		string MerchantId { get; set; }

		// @property NSString * apiKey;
		[Export("apiKey")]
		string ApiKey { get; set; }

		// @property BOOL isProductionMode;
		[Export("isProductionMode")]
		bool IsProductionMode { get; set; }

		// @property (nonatomic, strong) WKWebView * webViewDF;
		[Export("webViewDF", ArgumentSemantic.Strong)]
		WKWebView WebViewDF { get; set; }

		// -(Openpay *)initWithMerchantId:(NSString *)merchantId apyKey:(NSString *)apiKey isProductionMode:(BOOL)isProductionMode;
		[Export("initWithMerchantId:apyKey:isProductionMode:")]
		IntPtr Constructor(string merchantId, string apiKey, bool isProductionMode);

		// -(Openpay *)initWithMerchantId:(NSString *)merchantId apyKey:(NSString *)apiKey isProductionMode:(BOOL)isProductionMode isDebug:(BOOL)isDebug;
		[Export("initWithMerchantId:apyKey:isProductionMode:isDebug:")]
		IntPtr Constructor(string merchantId, string apiKey, bool isProductionMode, bool isDebug);

		// -(void)createTokenWithCard:(OPCard *)card success:(OpenpayTokenizeResponseBlock)successBlock failure:(OpenpayErrorBlock)failureBlock;
		[Export("createTokenWithCard:success:failure:")]
		void CreateTokenWithCard(OPCard card, OpenpayTokenizeResponseBlock successBlock, OpenpayErrorBlock failureBlock);

		// -(void)getTokenWithId:(NSString *)tokenId success:(OpenpayTokenizeResponseBlock)successBlock failure:(OpenpayErrorBlock)failureBlock;
		[Export("getTokenWithId:success:failure:")]
		void GetTokenWithId(string tokenId, OpenpayTokenizeResponseBlock successBlock, OpenpayErrorBlock failureBlock);

		// -(NSString *)createDeviceSessionId;
		[Export("createDeviceSessionId")]
		string CreateDeviceSessionId();
	}
}
