declare namespace Cypress {
    interface Chainable {
        /**
         * Custom command to get DOM element by data-automation attribute.
         * @example cy.getByAutomation('div')
         */
        getByAutomation(
            selector: string,
            visible?: boolean,
            ...args: any
        ): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to get DOM element by data-automation attribute.
         * @example cy.getByTestId('continue-button')
         */
        getByTestId(
            selector: string,
            visible?: boolean,
            ...args: any
        ): Chainable<JQuery<HTMLElement>>;


        /**
         * Custom command to get DOM element by data-automation substring attribute.
         * @example cy.getByAutomationLike('div')
         */
        getByAutomationLike(
            selector: string,
            visible?: boolean,
            ...args: any
        ): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to find DOM element by data-automation attribute.
         * @example cy.findByAutomation('div')
         */
        findByAutomation(
            selector: string,
            visible?: boolean,
            ...args: any
        ): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to select DOM element by data-automation attribute.
         * @example cy.findByAutomationLike('div')
         */
        findByAutomationLike(
            selector: string,
            visible?: boolean,
            ...args: any
        ): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to get parent element by data-automation attribute.
         * @example cy.getParentByAutomation('div')
         */
        getParentByAutomation(
            selector: string,
            visible?: boolean,
            ...args: any
        ): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to click on a dom element with a delay.
         * @example cy.clickWithDelay('div')
         */
        clickWithDelay(delay: number, ...args: any): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to find a link with a partial href string.
         * @example cy.findWithHref('some-partial-href')
         */
        findByHref(
            partialLink: string,
            visible?: boolean,
            ...args: any
        ): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to perform an action if an element has a specific attribute.
         * @example cy.findWithHref('some-partial-href')
         */
        performIfAttr(
            attr: string,
            value: string | boolean | number,
            callback?: () => any,
            ...args: any
        ): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to see if a form element has validation error.
         * @example cy.hasError(1)
         */
        hasError(length: number, ...args: any): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to perform an action if an element contains a specific class.
         * @example cy.findWithHref('some-partial-href')
         */
        performIfClass(
            value: string,
            callback?: () => any,
            ...args: any
        ): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to wait seconds.
         * @example cy.waitSeconds(1)
         */
        waitSeconds(seconds: number, ...args: any): Chainable<undefined>;

        /**
         * Custom command to fetch errors.
         * @example cy.errors(1)
         */
        errors(length: number, ...args: any): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to acknowledge cookie.
         * @example cy.cookieConsent()
         */
        cookieConsent(...args: any): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to visit a page and consent cookies.
         * @example cy.visitCustom('url')
         */
        visitCustom(...args: any): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to wait until an iframe has loaded by waiting for a specific element.
         * @example cy.iframeLoaded(iframe, 'selector')
         */
        iframeLoaded(
            iframe: string,
            selector: string,
            timeout: number,
            callback?: ($iframe: JQuery<HTMLElement>) => any,
            ...args: any
        ): Chainable<JQuery<HTMLElement>>;

        /**
         * Custom command to find an element contained in an iframe.
         * @example cy.findInIframe($iframe, 'selector')
         */
        findInIframe(
            $iframe: JQuery<HTMLElement>,
            selector: string,
            ...args: any
        ): Cypress.Chainable<JQuery<HTMLElement | Document | Text | Comment>>;
        
        
        findInIframeIf(
            $iframe: JQuery<HTMLElement>,
            selector: string,
            ...args: any
        ): Cypress.Chainable<JQuery<HTMLElement | Document | Text | Comment>>;

        /**
         * Clicks the Orders link and waits until the page has actually reloaded.
         * The link points at Orders/Details, which is often the page already shown,
         * so without waiting, later queries can match elements on the old page.
         * @example cy.openOrders()
         */
        openOrders(): Chainable<undefined>;
        /**
         * Clicks an action button (data-automation) in the order row for a payment order.
         * Uses one selector instead of .within(): the click navigates away, which would
         * detach the .within() subject while Cypress is still finishing that command.
         * @example cy.clickOrderAction(paymentOrderLink, 'a-paymentordercapture')
         */
        clickOrderAction(paymentOrderLink: string, action: string): Chainable<JQuery<HTMLElement>>;
        getPaymentOrder<T = any>(
            paymentOrderId: string
        ): Cypress.Chainable<Response<T>>

        getPaymentOrderUntil<T = any>(
            paymentOrderId: string,
            predicate: (body: any) => boolean,
            attempts?: number
        ): Cypress.Chainable<Response<T>>
    }
}


// ***********************************************
// This example commands.js shows you how to
// create various custom commands and overwrite
// existing commands.
//
// For more comprehensive examples of custom
// commands please read more here:
// https://on.cypress.io/custom-commands
// ***********************************************
//
//
// -- This is a parent command --
// Cypress.Commands.add('login', (email, password) => { ... })
//
//
// -- This is a child command --
// Cypress.Commands.add('drag', { prevSubject: 'element'}, (subject, options) => { ... })
//
//
// -- This is a dual command --
// Cypress.Commands.add('dismiss', { prevSubject: 'optional'}, (subject, options) => { ... })
//
//
// -- This will overwrite an existing command --
// Cypress.Commands.overwrite('visit', (originalFn, url, options) => { ... })

interface TypeOptions extends Cypress.TypeOptions {
    sensitive: boolean;
}

Cypress.Commands.add("getByAutomation", (selector: string, visible: boolean = false, ...args: any) => {
        return cy.get(
            `[data-automation='${selector}']${visible == true ? ":visible" : ""}`,
            ...args
        );
    }
);

Cypress.Commands.add("getByTestId", (selector: string, visible: boolean = false, ...args: any) => {
        return cy.get(
            `[data-testid='${selector}']${visible == true ? ":visible" : ""}`,
            ...args
        );
    }
);

Cypress.Commands.add("getByAutomationLike", (selector, visible = false, ...args) => {
        return cy.get(
            `[data-automation*='${selector}']${visible == true ? ":visible" : ""}`,
            ...args
        );
    }
);

Cypress.Commands.add("findByAutomation", {prevSubject: "element"},
    (subject /* :JQuery<HTMLElement> */, selector, visible = false, ...args) => {
        return cy
            .wrap(subject)
            .find(
                `[data-automation='${selector}']${visible == true ? ":visible" : ""}`,
                ...args
            );
    }
);

Cypress.Commands.add("findByAutomationLike", {prevSubject: "element"},
    (subject, selector, visible = false, ...args) => {
        return cy
            .wrap(subject)
            .find(
                `[data-automation*='${selector}']${visible == true ? ":visible" : ""}`,
                ...args
            );
    }
);

Cypress.Commands.add("getParentByAutomation", {prevSubject: "element"},
    (subject, selector, visible = false, ...args) => {
        return cy
            .wrap(subject)
            .parents(
                `[data-automation='${selector}']${visible == true ? ":visible" : ""}`,
                ...args
            );
    }
);

Cypress.Commands.add("clickWithDelay", {prevSubject: "element"},
    (subject, delay = 1, ...args) => {
        cy.wait(delay * 1000).then((_) => {
            cy.wrap(subject).click(...args);
        });
    }
);

Cypress.Commands.add("findByHref", {prevSubject: "element"},
    (subject, partialLink: string, visible: boolean = true) => {
        return cy
            .wrap(subject)
            .find(`a[href*="${partialLink}"]${visible ? ":visible" : ""}`)
            .first();
    }
);

Cypress.Commands.add("performIfAttr", {prevSubject: "element"},
    (
        subject,
        attr: string,
        value: string | boolean | number,
        callback?: () => any
    ) => {
        cy.wrap(subject)
            .invoke("attr", attr)
            .then((attr) => {
                cy.log(String(attr));
                if (attr == value) {
                    return callback?.();
                }
            });
    }
);

Cypress.Commands.add("performIfClass", {prevSubject: "element"},
    (subject, value: string, callback?: () => any) => {
        cy.wrap(subject)
            .invoke("attr", "class")
            .then((className) => {
                cy.log(className ?? "");
                if (className?.includes(value)) {
                    return callback?.();
                }
            });
    }
);

Cypress.Commands.add("waitSeconds", (seconds: number, ...args: any) => {
    return cy.wait(seconds * 1000);
});

Cypress.Commands.add("hasError", {prevSubject: "element"},
    (subject, length) => {
        return cy
            .wrap(subject)
            .parent()
            .siblings("[data-automation='text-error']:visible")
            .should("have.length", length);
    }
);

Cypress.Commands.add("errors", (seconds: number, ...args: any) => {
    return cy.getByAutomation("text-error", true).should("have.length", length);
});

Cypress.Commands.add("cookieConsent", (...args: any) => {
    cy.waitSeconds(1);
    cy.get("body").then(($body) => {
        if ($body.find("#CookieConsent").length > 0) {
            return cy.wait(1000).get("#cc-b-custom").click();
        }
    });
});

Cypress.Commands.add("visitCustom", (url: string, ...args: any) => {
    cy.visit(url);
    cy.get("body").then(($body) => {
        if ($body.find("#CookieConsent").length > 0) {
            return cy.wait(1000).get("#cc-b-custom").click();
        }
    });
});

Cypress.Commands.add("iframeLoaded", (
        iframe: string,
        element: string,
        timeout: number,
        callback?: ($iframe: JQuery<HTMLElement>) => any
    ) => {
        console.log(iframe);
        return cy
            .get(iframe, {
                timeout: timeout * 1000,
            })
            .should(($iframe) => {
                expect($iframe.contents().find(element)).to.exist;
            })
            .then(($iframe) => {
                callback?.($iframe);
            });
    }
);

// Let Cypress run the find (instead of jQuery up front) so it retries until the element
// renders and names the selector in the error when it never appears.
Cypress.Commands.add("findInIframe",
    ($iframe: JQuery<HTMLElement>, element: string) => {
        return cy.wrap($iframe.contents(), {log: false}).find(element);
    }
);

Cypress.Commands.add("findInIframeIf",
    ($iframe: JQuery<HTMLElement>, 
     element: string) => {
        if($iframe.contents().find(element).length > 0){
            return cy.wrap($iframe.contents().find(element));    
        }   
        else{
            return
        }
    }
);


Cypress.Commands.add("openOrders", () => {
    const marker = "__beforeOrdersNavigation";
    cy.window({log: false}).then((win) => {
        (win as any)[marker] = true;
    });
    cy.getByAutomation("orderslink", true, {timeout: 30000}).click();
    // A fresh window has no marker, so this passes only once the reload has replaced the page.
    cy.window({timeout: 30000}).should((win) => {
        expect((win as any)[marker], "page reloaded").to.be.undefined;
    });
    return cy.wrap(undefined, {log: false});
});

Cypress.Commands.add("clickOrderAction", (paymentOrderLink: string, action: string) => {
    return cy
        .get(`[data-paymentorderlink="${paymentOrderLink}"] [data-automation="${action}"]`, {timeout: 30000})
        .should("be.visible")
        .click();
});

Cypress.Commands.add("getPaymentOrder",
    (paymentOrderId: string) => {
        return cy.request('https://localhost:5001/payment/getpaymentorder?paymentorderid=' + paymentOrderId)
    }
);

// Operations such as capture and reversal settle asynchronously at Swedbank Pay: the operation
// POST can succeed while a follow-up GET still reports the previous state for a short window.
// Poll the payment order until `predicate(body)` holds (or attempts run out) so assertions run
// against the settled state instead of racing the transition.
Cypress.Commands.add("getPaymentOrderUntil",
    (paymentOrderId: string, predicate: (body: any) => boolean, attempts: number = 10) => {
        const request = (attemptsLeft: number): any =>
            cy.request('https://localhost:5001/payment/getpaymentorder?paymentorderid=' + paymentOrderId)
                .then((response) => {
                    if (predicate(response.body) || attemptsLeft <= 1) {
                        return response;
                    }
                    cy.wait(2000);
                    return request(attemptsLeft - 1);
                });

        return request(attempts);
    }
);