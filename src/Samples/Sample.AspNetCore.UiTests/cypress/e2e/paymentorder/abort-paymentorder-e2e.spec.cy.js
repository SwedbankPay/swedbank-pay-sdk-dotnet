describe('Abort paymentorder', () => {
    beforeEach(() => {
        cy.visit(Cypress.env("baseUrl"))
    })

    it('Should abort paymentorder', () => {

        //Add to cart and go to checkout
        cy.getByAutomation('button-addtocart').first().click();
        cy.getByAutomation('button-checkout').first().click();
        cy.waitSeconds(2);
        cy.getByAutomation('button-abort').click();
        cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');

        cy.getByAutomation('paymentorderlink', true)
            .then(($paymentOrderLink) => {
                let paymentOrderLink = $paymentOrderLink.text();
                cy.getPaymentOrder(paymentOrderLink).then((response) => {
                    expect(response.status).to.eq(200);
                    let responseBody = response.body;

                    expect(responseBody.paymentOrder.status.value).to.eq('Aborted');
                    expect(responseBody.paymentOrder.aborted.abortReason).to.eq('CanceledByUser');
                });
            });
    })
}) 