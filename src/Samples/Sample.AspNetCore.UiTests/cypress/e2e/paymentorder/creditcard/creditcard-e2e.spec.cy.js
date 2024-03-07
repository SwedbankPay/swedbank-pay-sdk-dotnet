import SwedbankBlock from "../../elements/blocks/common/swedbank-block";
import {PaymentMethods, TokenType} from "../../../support/enums";

describe('Pay with Credit card', () => {
    beforeEach(() => {
        cy.visit(Cypress.env("baseUrl"))
    });

    it('Should succeed payment and create cancellation', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout"]').first().click()

        new SwedbankBlock().payWithSwedbank(PaymentMethods.card);

        cy.get('h2', {timeout: 30000}).then(($h) => {
            expect($h).to.contain('Thanks!');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.getByAutomation('orderslink', true, {timeout: 30000}).click();

                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentordercancel').should('be.visible').click();
                });

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');
            })
        });
    })


    it('Should succeed payment and create capture and reversal', () => {

        //Add to cart and go to checkout    
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout"]').first().click()

        new SwedbankBlock().payWithSwedbank(PaymentMethods.card);

        cy.get('h2', {timeout: 30000}).then(($h) => {
            expect($h).to.contain('Thanks!');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.getByAutomation('orderslink', true, {timeout: 30000}).click();

                cy.getPaymentOrder(paymentOrderLink).then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;

                    expect(responseBody.paymentOrder.status.value).to.eq('Paid');
                    expect(responseBody.paymentOrder.paid.instrument.value).to.eq('CreditCard');
                    expect(responseBody.paymentOrder.paid.transactionType.value).to.eq('Authorization');
                    expect(responseBody.operations.capture).to.not.be.undefined;
                    expect(responseBody.operations.reversal).to.be.undefined;
                });

                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentordercapture').should('be.visible').click();
                });

                cy.getPaymentOrder(paymentOrderLink).then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;

                    expect(responseBody.paymentOrder.status.value).to.eq('Paid');
                    expect(responseBody.paymentOrder.paid.instrument.value).to.eq('CreditCard');
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[0].type.value).to.eq('Capture');
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[0].amount.inLowestMonetaryUnit).to.eq(responseBody.paymentOrder.amount.inLowestMonetaryUnit);
                    expect(responseBody.operations.capture).to.be.undefined;
                    expect(responseBody.operations.reversal).to.not.be.undefined;
                });

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentorderreversal').should('be.visible').click();
                });


                cy.getPaymentOrder(paymentOrderLink).then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;

                    expect(responseBody.paymentOrder.status.value).to.eq('Reversed');
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[1].type.value).to.eq('Reversal');
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[1].amount.inLowestMonetaryUnit).to.eq(responseBody.paymentOrder.amount.inLowestMonetaryUnit);
                    expect(responseBody.operations.capture).to.be.undefined;
                    expect(responseBody.operations.reversal).to.be.undefined;
                });

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');
            })
        });
    })
})

describe('Pay with Credit card and Payment token', () => {
    beforeEach(() => {
        cy.visit('https://localhost:5001')
    });

    it('Should succeed payment and delete token', () => {
        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()

        cy.get('[data-automation="button-checkout-payment-token"]').first().click()

        let swedbankBlock = new SwedbankBlock();
        swedbankBlock.payWithSwedbank(PaymentMethods.card);

        cy.get('h2', {timeout: 30000}).then(($h) => {
            expect($h).to.contain('Thanks!');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();

                swedbankBlock.deleteToken(TokenType.Payment);
            })
        });
    })
})

describe('Pay with Credit card', () => {
    beforeEach(() => {
        cy.visit('https://localhost:5001')
    });

    it('Should succeed payment and create cancellation', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout"]').first().click()

        new SwedbankBlock().payWithSwedbank(PaymentMethods.card);

        cy.get('h2', {timeout: 30000}).then(($h) => {
            expect($h).to.contain('Thanks!');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.getByAutomation('orderslink', true, {timeout: 30000}).click();

                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentordercancel').should('be.visible').click();
                });

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');
            })
        });
    })


    it('Should succeed payment and create capture and reversal', () => {

        //Add to cart and go to checkout    
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout"]').first().click()

        new SwedbankBlock().payWithSwedbank(PaymentMethods.card);

        cy.get('h2', {timeout: 30000}).then(($h) => {
            expect($h).to.contain('Thanks!');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.getByAutomation('orderslink', true, {timeout: 30000}).click();

                cy.getPaymentOrder(paymentOrderLink).then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;

                    expect(responseBody.paymentOrder.status.value).to.eq('Paid');
                    expect(responseBody.paymentOrder.paid.instrument.value).to.eq('CreditCard');
                    expect(responseBody.paymentOrder.paid.transactionType.value).to.eq('Authorization');
                    expect(responseBody.operations.capture).to.not.be.undefined;
                    expect(responseBody.operations.reversal).to.be.undefined;
                });

                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentordercapture').should('be.visible').click();
                });

                cy.getPaymentOrder(paymentOrderLink).then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;

                    expect(responseBody.paymentOrder.status.value).to.eq('Paid');
                    expect(responseBody.paymentOrder.paid.instrument.value).to.eq('CreditCard');
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[0].type.value).to.eq('Capture');
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[0].amount.inLowestMonetaryUnit).to.eq(responseBody.paymentOrder.amount.inLowestMonetaryUnit);
                    expect(responseBody.operations.capture).to.be.undefined;
                    expect(responseBody.operations.reversal).to.not.be.undefined;
                });

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

                cy.get('[data-paymentorderlink="' + paymentOrderLink + '"]').within(($paymentOrder) => {
                    cy.getByAutomation('a-paymentorderreversal').should('be.visible').click();
                });


                cy.getPaymentOrder(paymentOrderLink).then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;

                    expect(responseBody.paymentOrder.status.value).to.eq('Reversed');
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[1].type.value).to.eq('Reversal');
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[1].amount.inLowestMonetaryUnit).to.eq(responseBody.paymentOrder.amount.inLowestMonetaryUnit);
                    expect(responseBody.operations.capture).to.be.undefined;
                    expect(responseBody.operations.reversal).to.be.undefined;
                });

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');
            })
        });
    })
})