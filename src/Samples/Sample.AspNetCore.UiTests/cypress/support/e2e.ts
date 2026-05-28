// ***********************************************************
// This example support/e2e.js is processed and
// loaded automatically before your test files.
//
// This is a great place to put global configuration and
// behavior that modifies Cypress.
//
// You can change the location of this file or turn off
// automatically serving support files with the
// 'supportFile' configuration option.
//
// You can read more here:
// https://on.cypress.io/configuration
// ***********************************************************

// Import commands.js using ES2015 syntax:
import "./index";


// Alternatively you can use CommonJS syntax:
// require('./commands')

beforeEach(() => {
    // Swedbank Pay's hosted checkout fires telemetry POSTs to /checkout/Beacon/... — both fetch
    // and navigator.sendBeacon variants. The endpoint occasionally hangs, keeping Cypress
    // waiting for page stability. We respond with a 204 (the same status the real endpoint
    // returns on success) so the iframe treats the beacon as delivered and does not retry.
    // Destroying the request instead causes the iframe to re-fire it in a loop. Aliased as
    // @beacon so it is visible in the test runner. No effect on the payment flow.
    cy.intercept({ url: /\/checkout\/Beacon\// }, { statusCode: 204, body: "" }).as("beacon");
});
