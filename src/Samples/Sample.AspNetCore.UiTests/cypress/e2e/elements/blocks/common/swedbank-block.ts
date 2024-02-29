import {PaymentMethods} from "../../../../support/enums";
import {Data} from "../../../../support/data";

class SwedbankBlock {
    payWithSwedbank(payment: string, callback: () => any) {
        switch (payment) {
            case PaymentMethods.card:
                return this.payWithCard();

            case PaymentMethods.savedCard:
                return this.payWithSavedCard();

            case PaymentMethods.card3ds:
                return this.payWithCard3ds(callback);

            case PaymentMethods.swish:
                return this.payWithSwish();

            case PaymentMethods.invoice:
                return this.payWithInvoice();

            case PaymentMethods.trustly:
                return this.payWithTrustly(callback);
        }
    }

    deleteToken(tokenType: string) {
        cy.getByAutomation('tokenslink', true, {timeout: 30000}).click();
        cy.get('table.table tr[data-automation="' + tokenType + '"] td a.btn', {timeout: 30000}).first().click()
        cy.get('.alert.alert-success', {timeout: 5000}).should('have.class', 'alert-success');
    }

    payWithCard() {
        cy.iframeLoaded(
            'iframe[src^="https://ecom.externalintegration.payex.com/checkout"]',
            "#creditcard",
            30,
            ($iframe) => {
                cy.wait(2000);
                cy.findInIframe($iframe, '#creditcard')
                    .then(($btn) => {
                        if (!$btn.hasClass('selected')) {
                            $btn.trigger('click');
                        }
                        
                        cy.findInIframe($iframe, '#view-creditcard').within(() => {
                            cy.iframeLoaded(
                                'iframe[src^="https://ecom.externalintegration.payex.com/creditcard"]',
                                "#px-submit",
                                30,
                                ($iframe2) => {

                                    cy.findInIframeIf($iframe2, '#panInput')
                                        .then(($input) => {
                                            if($input){
                                                console.log('2 id:' + $input.attr('id'));
                                                cy.findInIframe($iframe2, "#panInput").type(
                                                    Data.payment.creditCardNumber,
                                                    {force: true}
                                                );
                                                cy.findInIframe($iframe2, "#expiryInput").type(
                                                    `${Data.payment.creditCardExpirationMonth}/${Data.payment.creditCardExpirationYear}`,
                                                    {force: true}
                                                );
                                                cy.findInIframe($iframe2, "#cvcInput-1").type(
                                                    Data.payment.creditCardCvc,
                                                    {force: true}
                                                );
                                            }
                                        })
                                    cy.wait(4000);
                                    cy.findInIframe($iframe2, "#px-submit").click({
                                        force: true,
                                    });
                                }
                            );
                        });
                    })
            }
        );
    }

    payWithSavedCard() {
        cy.iframeLoaded(
            'iframe[src^="https://ecom.externalintegration.payex.com/checkout"]',
            "#creditcard",
            30,
            ($iframe) => {
                cy.findInIframe($iframe, "#creditcard").click();
                cy.findInIframe($iframe, "#view-creditcard").within(() => {
                    cy.iframeLoaded(
                        'iframe[src^="https://ecom.externalintegration.payex.com/creditcard"]',
                        '#px-submit[aria-disabled="false"]',
                        30,
                        ($iframe) => {
                            cy.findInIframe($iframe, "#px-submit").click({
                                force: true,
                            });
                        }
                    );
                });
            }
        );
    }

    payWithCard3ds(callback: () => any) {
        cy.iframeLoaded(
            'iframe[src^="https://ecom.externalintegration.payex.com/checkout"]',
            "#creditcard",
            30,
            ($iframe) => {
                cy.findInIframe($iframe, "#creditcard").click();
                cy.findInIframe($iframe, "#view-creditcard").within(() => {
                    cy.iframeLoaded(
                        'iframe[src^="https://ecom.externalintegration.payex.com/creditcard"]',
                        "#panInput",
                        30,
                        ($iframe) => {
                            cy.findInIframe($iframe, "#panInput").type(
                                Data.payment.creditCardNumber3DS,
                                {force: true}
                            );
                            cy.findInIframe($iframe, "#expiryInput").type(
                                `${Data.payment.creditCardExpirationMonth}/${Data.payment.creditCardExpirationYear}`,
                                {force: true}
                            );
                            cy.findInIframe($iframe, "#cvcInput-1").type(
                                Data.payment.creditCardCvc,
                                {force: true}
                            );
                            cy.findInIframe($iframe, "#px-submit").click({
                                force: true,
                            });
                        }
                    );
                });

                callback();
            }
        );
    }

    payWithSwish() {
        cy.iframeLoaded(
            'iframe[src^="https://ecom.externalintegration.payex.com/checkout"]',
            "#swish",
            30,
            ($iframe) => {
                cy.findInIframe($iframe, "#swish").click();
                cy.findInIframe($iframe, "#px-submit").click({
                    force: true,
                });
            }
        );
    }

    payWithInvoice() {
        cy.iframeLoaded(
            'iframe[src^="https://ecom.externalintegration.payex.com/checkout"]',
            "#invoice-payexfinancingse",
            30,
            ($iframe) => {
                cy.findInIframe($iframe, "#invoice-payexfinancingse").click();
                cy.findInIframe($iframe, "#view-invoice-payexfinancingse").within(() => {
                    cy.iframeLoaded(
                        'iframe[src^="https://ecom.externalintegration.payex.com/invoice"]',
                        "#ssnInput",
                        30,
                        ($iframe) => {
                            cy.findInIframe($iframe, "#ssnInput").type(
                                Data.payment.invoiceSsn,
                                {force: true}
                            );
                            cy.findInIframe($iframe, "#emailInput").type(
                                `${Data.payment.invoiceEmail}`,
                                {force: true}
                            );
                            cy.findInIframe($iframe, "#msisdnInput").type(
                                Data.payment.invoicePhone,
                                {force: true}
                            );
                            cy.findInIframe($iframe, "#px-submit").click({
                                force: true,
                            });
                        }
                    );
                });
            }
        );
    }

    payWithTrustly(callback: () => any) {
        cy.iframeLoaded(
            'iframe[src^="https://ecom.externalintegration.payex.com/checkout"]',
            "#trustly",
            30,
            ($iframe) => {
                cy.findInIframe($iframe, "#trustly").click();
                cy.findInIframe($iframe, "#view-trustly").within(() => {
                    cy.iframeLoaded(
                        'iframe[src^="https://ecom.externalintegration.payex.com/trustly"]',
                        "#first-name-input",
                        30,
                        ($iframe) => {
                            cy.findInIframe($iframe, "#first-name-input").type(
                                Data.payment.trustlyFirstName,
                                {force: true}
                            );
                            cy.findInIframe($iframe, "#last-name-input").type(
                                `${Data.payment.trustlyLastName}`,
                                {force: true}
                            );
                            cy.findInIframe($iframe, "#px-submit").click({
                                force: true,
                            });
                        }
                    );
                });

                callback();
            }
        );
    }
}

export default SwedbankBlock;