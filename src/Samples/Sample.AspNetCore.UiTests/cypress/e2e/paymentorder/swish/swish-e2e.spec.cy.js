import SwedbankBlock from "../../elements/blocks/common/swedbank-block";
import {PaymentMethods} from "../../../support/enums";
import {Data} from "../../../support/data";

describe('Pay with Swish', () => {
    beforeEach(() => {
        cy.visit('https://localhost:5001')
    })

    it('Should succeed and create reversal', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout"]').first().click()

        new SwedbankBlock().payWithSwedbank(PaymentMethods.swish);

        cy.get('h2', {timeout: 30000}).then(($h) => {
            expect($h).to.contain('Thanks!');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.getByAutomation('orderslink', true, {timeout: 30000}).click();

                cy.getPaymentOrder(paymentOrderLink).then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;

                    expect(responseBody.paymentOrder.status.value).to.eq('Paid');
                    expect(responseBody.paymentOrder.paid.instrument).to.eq('Swish');
                    expect(responseBody.paymentOrder.paid.transactionType.value).to.eq('Sale');
                    expect(responseBody.paymentOrder.paid.details.msisdn).to.eq(Data.payment.swishPhone);
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[0].type.value).to.eq('Sale');

                    expect(responseBody.operations.capture).to.be.undefined;
                    expect(responseBody.operations.reversal).to.not.be.undefined;
                });
                
                
                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentorderreversal').should('be.visible').click();
                });

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

                cy.getPaymentOrder(paymentOrderLink).then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;
                    expect(responseBody.paymentOrder.status.value).to.eq('Reversed');
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[1].type.value).to.eq('Reversal');
                    expect(responseBody.operations.capture).to.be.undefined;
                    expect(responseBody.operations.reversal).to.be.undefined;
                });
            })
        });
    })
}) 



