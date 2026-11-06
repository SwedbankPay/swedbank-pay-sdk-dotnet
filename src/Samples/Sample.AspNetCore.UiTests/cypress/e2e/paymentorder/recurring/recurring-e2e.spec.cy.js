import SwedbankBlock from "../../elements/blocks/common/swedbank-block";
import {PaymentMethods, TokenType} from "../../../support/enums";

describe('Create recurring payments', () => {
    beforeEach(() => {
        cy.visit(Cypress.expose("baseUrl"))
    });

    it('Should succeed recurring, create a new payment order and cancel it', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout-recurrence-token"]').first().click()

        let swedbankBlock = new SwedbankBlock();
        swedbankBlock.payWithSwedbank(PaymentMethods.card);

        cy.url({timeout: 60000}).should('contain', '/Checkout/Thankyou');
        cy.contains('h2', 'Thanks!', {timeout: 30000});

        cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
            let paymentOrderLink = $paymentOrderLink.text();
            cy.openOrders();

            cy.clickOrderAction(paymentOrderLink, 'a-recurring');

            cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.openOrders();


                cy.clickOrderAction(paymentOrderLink, 'a-paymentordercancel');

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

                swedbankBlock.deleteToken(TokenType.Recurrence);
            })
        });
    })

    it('Should succeed recurring, create a new payment order and perform capture and reversal', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout-recurrence-token"]').first().click()

        let swedbankBlock = new SwedbankBlock();
        swedbankBlock.payWithSwedbank(PaymentMethods.card);

        cy.url({timeout: 60000}).should('contain', '/Checkout/Thankyou');
        cy.contains('h2', 'Thanks!', {timeout: 30000});

        cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
            let paymentOrderLink = $paymentOrderLink.text();
            cy.openOrders();

            cy.clickOrderAction(paymentOrderLink, 'a-recurring');

            cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.openOrders();

                cy.getPaymentOrderUntil(paymentOrderLink, (body) => body.operations.capture != null).then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;

                    expect(responseBody.paymentOrder.status.value).to.eq('Paid');
                    expect(responseBody.paymentOrder.paid.instrument.value).to.eq('CreditCard');
                    expect(responseBody.paymentOrder.paid.transactionType.value).to.eq('Authorization');
                    expect(responseBody.operations.capture).to.not.be.undefined;
                    expect(responseBody.operations.reversal).to.be.undefined;
                });

                cy.clickOrderAction(paymentOrderLink, 'a-paymentordercapture');

                cy.getPaymentOrderUntil(paymentOrderLink, (body) => body.operations.reversal != null).then((response) => {
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

                cy.clickOrderAction(paymentOrderLink, 'a-paymentorderreversal');

                cy.getPaymentOrderUntil(paymentOrderLink, (body) => body.paymentOrder.status.value === 'Reversed').then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;

                    expect(responseBody.paymentOrder.status.value).to.eq('Reversed');
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[1].type.value).to.eq('Reversal');
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[1].amount.inLowestMonetaryUnit).to.eq(responseBody.paymentOrder.amount.inLowestMonetaryUnit);
                    expect(responseBody.operations.capture).to.be.undefined;
                    expect(responseBody.operations.reversal).to.be.undefined;
                });

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

                swedbankBlock.deleteToken(TokenType.Recurrence);
            })
        });
    })


    it('Should succeed unscheduled, create a new payment order and cancel it', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout-unscheduled-token"]').first().click()

        let swedbankBlock = new SwedbankBlock();
        swedbankBlock.payWithSwedbank(PaymentMethods.card);

        cy.url({timeout: 60000}).should('contain', '/Checkout/Thankyou');
        cy.contains('h2', 'Thanks!', {timeout: 30000});

        cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
            let paymentOrderLink = $paymentOrderLink.text();
            cy.openOrders();

            cy.clickOrderAction(paymentOrderLink, 'a-unscheduled');

            cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.openOrders();


                cy.clickOrderAction(paymentOrderLink, 'a-paymentordercancel');

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

                swedbankBlock.deleteToken(TokenType.Unscheduled);
            })
        });
    })

    it('Should succeed unscheduled, create a new payment order and perform capture and reversal', () => {

        //Add to cart and go to checkout
        cy.get('[data-automation="button-addtocart"]').first().click()
        cy.get('[data-automation="button-checkout-unscheduled-token"]').first().click()

        let swedbankBlock = new SwedbankBlock();
        swedbankBlock.payWithSwedbank(PaymentMethods.card);

        cy.url({timeout: 60000}).should('contain', '/Checkout/Thankyou');
        cy.contains('h2', 'Thanks!', {timeout: 30000});

        cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
            let paymentOrderLink = $paymentOrderLink.text();
            cy.openOrders();

            cy.clickOrderAction(paymentOrderLink, 'a-unscheduled');

            cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

            cy.getByAutomation('paymentorderlink').then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.openOrders();

                cy.getPaymentOrderUntil(paymentOrderLink, (body) => body.operations.capture != null).then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;

                    expect(responseBody.paymentOrder.status.value).to.eq('Paid');
                    expect(responseBody.paymentOrder.paid.instrument.value).to.eq('CreditCard');
                    expect(responseBody.paymentOrder.paid.transactionType.value).to.eq('Authorization');
                    expect(responseBody.operations.capture).to.not.be.undefined;
                    expect(responseBody.operations.reversal).to.be.undefined;
                });

                cy.clickOrderAction(paymentOrderLink, 'a-paymentordercapture');

                cy.getPaymentOrderUntil(paymentOrderLink, (body) => body.operations.reversal != null).then((response) => {
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

                cy.clickOrderAction(paymentOrderLink, 'a-paymentorderreversal');

                cy.getPaymentOrderUntil(paymentOrderLink, (body) => body.paymentOrder.status.value === 'Reversed').then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;

                    expect(responseBody.paymentOrder.status.value).to.eq('Reversed');
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[1].type.value).to.eq('Reversal');
                    expect(responseBody.paymentOrder.financialTransactions.financialTransactionsList[1].amount.inLowestMonetaryUnit).to.eq(responseBody.paymentOrder.amount.inLowestMonetaryUnit);
                    expect(responseBody.operations.capture).to.be.undefined;
                    expect(responseBody.operations.reversal).to.be.undefined;
                });

                cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

                swedbankBlock.deleteToken(TokenType.Unscheduled);
            })
        });
    })
})
