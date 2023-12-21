﻿// using Atata;
// using NUnit.Framework;
// using Sample.AspNetCore.SystemTests.Test.Helpers;
// using SwedbankPay.Sdk;
// using SwedbankPay.Sdk.PaymentOrder;
//
// namespace Sample.AspNetCore.SystemTests.Test.PaymentTests.PaymentOrder.Anonymous
// {
//     public class AnonymousPaymentOrderCancellationTests : Base.PaymentTests
//     {
//         public AnonymousPaymentOrderCancellationTests(string driverAlias)
//             : base(driverAlias)
//         {
//         }
//
//
//         [Test]
//         [Retry(2)]
//         [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Card })]
//         public void Anonymous_PaymentOrder_Card_Cancellation(Product[] products, PayexInfo payexInfo)
//         {
//             Assert.DoesNotThrowAsync(async () => {
//
//                 GoToOrdersPage(products, payexInfo, Checkout.Option.Anonymous)
//                 .RefreshPageUntil(x => x.Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].IsVisible, 60, 10)
//                 .Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].ExecuteAction.ClickAndGo()
//                 .RefreshPageUntil(x => x.Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].IsVisible, 60, 10)
//                 .Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
//                 .Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Clear.ClickAndGo();
//
//                 var order = await SwedbankPayClient.PaymentOrders.Get(_link, PaymentOrderExpand.All);
//
//                 // Operations
//                 Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
//                 Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
//                 Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Null);
//                 Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);
//
//                 // Transactions
//                 Assert.That(order.PaymentOrder.Paid.Payment.Transactions.TransactionList.Count, Is.EqualTo(2));
//                 Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
//                             Is.EqualTo(State.Completed));
//                 Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Cancellation).State,
//                             Is.EqualTo(State.Completed));
//             });
//         }
//
//
//         [Test]
//         [Retry(2)]
//         [TestCaseSource(nameof(TestData), new object[] { false, PaymentMethods.Invoice })]
//         public void Anonymous_PaymentOrder_Invoice_Cancellation(Product[] products, PayexInfo payexInfo)
//         {
//             Assert.DoesNotThrowAsync(async () => {
//
//                 GoToOrdersPage(products, payexInfo, Checkout.Option.Anonymous)
//                 .RefreshPageUntil(x => x.Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].IsVisible, 60, 10)
//                 .Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.CreatePaymentOrderCancel)].ExecuteAction.ClickAndGo()
//                 .RefreshPageUntil(x => x.Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].IsVisible, 60, 10)
//                 .Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Actions.Rows[y => y.Name.Value.Contains(PaymentOrderResourceOperations.PaidPaymentOrder)].Should.BeVisible()
//                 .Orders[y => y.Attributes["data-paymentorderlink"] == _referenceLink].Clear.ClickAndGo();
//
//                 var order = await SwedbankPayClient.PaymentOrders.Get(_link, PaymentOrderExpand.All);
//
//                 // Operations
//                 Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCancel], Is.Null);
//                 Assert.That(order.Operations[LinkRelation.CreatePaymentOrderCapture], Is.Null);
//                 Assert.That(order.Operations[LinkRelation.CreatePaymentOrderReversal], Is.Null);
//                 Assert.That(order.Operations[LinkRelation.PaidPaymentOrder], Is.Not.Null);
//
//                 // Transactions
//                 Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.Count, Is.EqualTo(3));
//                 Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Initialization).State,
//                             Is.EqualTo(State.Completed));
//                 Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Authorization).State,
//                             Is.EqualTo(State.Completed));
//                 Assert.That(order.PaymentOrder.CurrentPayment.Payment.Transactions.TransactionList.First(x => x.Type == TransactionType.Cancellation).State,
//                             Is.EqualTo(State.Completed));
//             });
//         }
//
//     }
// }
