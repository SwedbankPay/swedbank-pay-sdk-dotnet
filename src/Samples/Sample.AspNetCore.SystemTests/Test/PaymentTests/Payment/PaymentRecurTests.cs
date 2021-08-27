using Atata;

using NUnit.Framework;

using Sample.AspNetCore.SystemTests.Services;
using Sample.AspNetCore.SystemTests.Test.Helpers;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentInstruments;

using System.Threading.Tasks;

namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.Payment
{
	public class PaymentRecurTests : Base.PaymentTests
	{
		public PaymentRecurTests(string driverAlias) : base(driverAlias)
		{
		}

		[Test]
		[Retry(3)]
		[TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
		public async Task Payment_Card_Recur(Product[] products, PayexInfo payexInfo)
		{
			GoToOrdersPage(products, payexInfo, Checkout.Option.LocalPaymentMenu)
				.PaymentLink.StoreValueAsUri(out var paymentLink)
				.Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCancellation)].Should.BeVisible()
				.Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.CreateCapture)].Should.BeVisible()
				.Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.PaidPayment)].Should.BeVisible()
				.Actions.Rows[y => y.Name.Value.Contains(PaymentResourceOperations.ViewPayment)].Should.BeVisible();

			var cardPayment = await SwedbankPayClient.Payments.CardPayments.Get(paymentLink, PaymentExpand.All);

			Assert.NotNull(cardPayment.Payment.RecurrenceToken);
			Assert.True(!string.IsNullOrEmpty(cardPayment.Payment.RecurrenceToken));
			Assert.NotNull(cardPayment.Payment.Urls);
			Assert.NotNull(cardPayment.Payment.Urls.CallbackUrl);

			IPayeeInfo payeeInfo = new PayeeInfo(cardPayment.Payment.PayeeInfo.PayeeId, GeneratePayeeReference());
			var recur = new SwedbankPay.Sdk.PaymentInstruments.Card.CardPaymentRecurRequest(PaymentIntent.Authorization,
																							cardPayment.Payment.RecurrenceToken,
																							cardPayment.Payment.Currency,
																							cardPayment.Payment.Amount,
																							cardPayment.Payment.VatAmount,
																							cardPayment.Payment.Description,
																							cardPayment.Payment.UserAgent,
																							cardPayment.Payment.Language,
																							cardPayment.Payment.Urls,
																							payeeInfo);
			recur.Payment.Metadata = cardPayment.Payment.Metadata;

			var result = await SwedbankPayClient.Payments.CardPayments.Create(recur);

			Assert.NotNull(result);
			Assert.NotNull(result.Payment);
		}

		private string GeneratePayeeReference()
		{
			return System.DateTime.UtcNow.Ticks.ToString();
		}
	}
}
