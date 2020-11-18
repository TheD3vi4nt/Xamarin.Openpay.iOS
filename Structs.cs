using System;
using ObjCRuntime;

namespace Xamarin.Openpay
{
	[Native]
	public enum OPCardType : ulong
	{
		Unknown,
		Visa,
		Mastercard,
		AmericanExpress
	}

	[Native]
	public enum OPCardSecurityCodeCheck : ulong
	{
		Unknown,
		Passed,
		Failed
	}
}
