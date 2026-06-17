import SwedbankBlock from "../../elements/blocks/common/swedbank-block";
import {PaymentMethods} from "../../../support/enums";
import {Data} from "../../../support/data";

describe('Pay with Swish', () => {
    beforeEach(() => {
        cy.visit(Cypress.expose("baseUrl"))
    })

    it('Should succeed and create reversal', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout"]').first().click()

        new SwedbankBlock().payWithSwedbank(PaymentMethods.swish);

        cy.url({timeout: 60000}).should('contain', '/Checkout/Thankyou');
        cy.contains('h2', 'Thanks!', {timeout: 30000});

        cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
            let paymentOrderLink = $paymentOrderLink.text();
            cy.getByAutomation('orderslink', true, {timeout: 30000}).click();

            cy.getPaymentOrderUntil(paymentOrderLink, (body) => body.operations.reversal != null).then((response) => {
                expect(response.status).to.eq(200);
                let responseBody = response.body;

                expect(responseBody.paymentOrder.status.value).to.eq('Paid');
                expect(responseBody.paymentOrder.paid.instrument.value).to.eq('Swish');
                expect(responseBody.paymentOrder.paid.transactionType.value).to.eq('Sale');
                expect(responseBody.paymentOrder.paid.details.msisdn.value).to.eq(Data.payment.swishPhone);
                expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[0].type.value).to.eq('Sale');

                expect(responseBody.operations.capture).to.be.undefined;
                expect(responseBody.operations.reversal).to.not.be.undefined;
            });


            cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]', {timeout: 30000}).within(($paymentOrder) => {
                cy.getByAutomation('a-paymentorderreversal').should('be.visible').click();
            });

            cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

            cy.getPaymentOrderUntil(paymentOrderLink, (body) => body.paymentOrder.status.value === 'Reversed').then((response) => {
                expect(response.status).to.eq(200);
                let responseBody = response.body;
                expect(responseBody.paymentOrder.status.value).to.eq('Reversed');
                expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[1].type.value).to.eq('Reversal');
                expect(responseBody.operations.capture).to.be.undefined;
                expect(responseBody.operations.reversal).to.be.undefined;
            });
        });
    })
}) 



