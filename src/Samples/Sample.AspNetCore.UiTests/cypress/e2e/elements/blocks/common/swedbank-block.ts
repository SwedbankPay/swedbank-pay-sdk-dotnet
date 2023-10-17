import {PaymentMethods} from "../../../../support/enums";
import {Data} from "../../../../support/data";

class SwedbankBlock {
    payWithSwedbank(payment) {
        switch (payment) {
            case PaymentMethods.card:
                return this.payWithCard();

            case PaymentMethods.swish:
                return this.payWithSwish();

            case PaymentMethods.invoice:
                return this.payWithInvoice();

            case PaymentMethods.trustly:
                return this.payWithTrustly();
        }
    }

    payWithCard() {
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
                                Data.payment.creditCardNumber,
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
                cy.findInIframe($iframe, "#view-swish").within(() => {
                    cy.iframeLoaded(
                        'iframe[src^="https://ecom.externalintegration.payex.com/swish"]',
                        "#msisdnInput",
                        30,
                        ($iframe) => {
                            cy.findInIframe($iframe, "#msisdnInput").type(
                                Data.payment.swishPhone,
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

    payWithTrustly() {
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
            }
        );
    }
}

export default SwedbankBlock;