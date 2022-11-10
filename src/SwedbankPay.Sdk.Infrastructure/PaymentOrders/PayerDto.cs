using System;

namespace SwedbankPay.Sdk.PaymentOrders;

	internal class PayerDto
	{
		public PayerDto() { }

		public PayerDto(Payer payer)
		{
			if (payer == null)
			{
				return;
			}

			AccountInfo = payer.AccountInfo;
			BillingAddress = payer.BillingAddress;
			ConsumerProfileRef = payer.ConsumerProfileRef;
			Email = payer.Email?.ToString();
			FirstName = payer.FirstName;
			HomePhoneNumber = payer.HomePhoneNumber;
			LastName = payer.LastName;
			Msisdn = payer.Msisdn?.ToString();
			NationalIdentifier = payer.NationalIdentifier != null ? new NationalIdentifierDto(payer.NationalIdentifier) : null;
			ShippingAddress = payer.ShippingAddress;
			WorkPhoneNumber = payer.WorkPhoneNumber;
		}

		public string Id { get; set; }
		public AccountInfo AccountInfo { get; set; }
		public Address BillingAddress { get; set; }
		public string ConsumerProfileRef { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string HomePhoneNumber { get; set; }
		public string LastName { get; set; }
		public string Msisdn { get; set; }
		public NationalIdentifierDto NationalIdentifier { get; set; }
		public Address ShippingAddress { get; set; }
		public string WorkPhoneNumber { get; set; }

		internal PayerResponse Map()
		{
			var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
			var payer = new PayerResponse(uri)
			{
				AccountInfo = AccountInfo,
				BillingAddress = BillingAddress,
				ConsumerProfileRef = ConsumerProfileRef,
				FirstName = FirstName,
				HomePhoneNumber = HomePhoneNumber,
				LastName = LastName,
				ShippingAddress = ShippingAddress,
				WorkPhoneNumber = WorkPhoneNumber
			};
			if (Email != null)
			{
				payer.Email = new EmailAddress(Email);
			}

			if (!String.IsNullOrEmpty(Msisdn))
			{
				payer.Msisdn = new Msisdn(Msisdn);
			}

			if (NationalIdentifier != null)
			{
				payer.NationalIdentifier = new NationalIdentifier(new CountryCode(NationalIdentifier.CountryCode), NationalIdentifier.SocialSecurityNumber);
			}

			return payer;
		}
	}