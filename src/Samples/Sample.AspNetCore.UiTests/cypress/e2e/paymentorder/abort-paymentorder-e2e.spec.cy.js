describe('Abort paymentorder', () => {
    beforeEach(() => {
        cy.visit('https://localhost:5001')
    })

    it('Should abort paymentorder', () => {

        //Add to cart and go to checkout
        cy.getByAutomation('button-addtocart').first().click();
        cy.getByAutomation('button-checkout').first().click();
        cy.getByAutomation('button-abort').click();
        cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');
    })
}) 