import SwedbankBlock from "../../elements/blocks/common/swedbank-block";
import {PaymentMethods} from "../../../support/enums";
import {Data} from "../../../support/data";

describe('Pay with Trustly', () => {
    beforeEach(() => {
        cy.visit('https://localhost:5001')
    })

    it('Should succeed and create reversal', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout"]').first().click()

        new SwedbankBlock().payWithSwedbank(PaymentMethods.trustly, () => {
            cy.iframeLoaded(
                "#px-overlay-iframe",
                '[data-testid="header-title"]',
                30,
                ($iframe) => {
                    cy.waitSeconds(2);
                    cy.findInIframe($iframe, '[data-testid="list-item-sweden.esse"]').click();
                    cy.waitSeconds(4);
                    cy.findInIframe($iframe, '[data-testid="continue-button"]').click();
                    cy.waitSeconds(4);
                    cy.findInIframe($iframe, '[data-testid="Input-text-loginid"]').type(Data.payment.invoiceSsn, {force: true})
                    cy.findInIframe($iframe, '[data-testid="continue-button"]').click();
                    cy.waitSeconds(4);

                    cy.findInIframe($iframe, 'h3').invoke('text')
                        .then((challengeResponse) => {
                            cy.findInIframe($iframe, '[data-testid="Input-password-challenge_response"]').type(challengeResponse, {force: true})
                            cy.findInIframe($iframe, '[data-testid="continue-button"]').click();
                        });

                    cy.waitSeconds(10);
                    cy.findInIframe($iframe, '[data-testid="account-list"]').children().first().click();
                    cy.waitSeconds(4);
                    cy.findInIframe($iframe, '[data-testid="summary-step-continue-cta-button"]').click();
                    cy.waitSeconds(10);

                    cy.findInIframe($iframe, 'h3').invoke('text')
                        .then((challengeResponse) => {
                            cy.findInIframe($iframe, '[data-testid="Input-password-challenge_response"]').type(challengeResponse, {force: true})
                            cy.findInIframe($iframe, '[data-testid="continue-button"]').click();
                        });
                    cy.waitSeconds(4);
                });
        });


        cy.get('h2', {timeout: 30000}).then(($h) => {
            expect($h).to.contain('Thanks!');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.getByAutomation('orderslink', true, {timeout: 30000}).click();

                cy.getPaymentOrder(paymentOrderLink).then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;
                    expect(responseBody.paymentOrder.status.value).to.eq('Paid');
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
                    expect(responseBody.operations.capture).to.be.undefined;
                    expect(responseBody.operations.reversal).to.be.undefined;
                });
            })
        });
    })
}) 



