import SwedbankBlock from "../../elements/blocks/common/swedbank-block";
import {PaymentMethods} from "../../../support/enums";

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

                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentorderreversal').should('be.visible').click();
                });

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');


                
            })
        });
    })
}) 



