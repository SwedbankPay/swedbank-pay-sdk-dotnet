/// <reference types="cypress" />

// Node-side setup, wired in from cypress.config.ts via setupNodeEvents.
module.exports = (on: Cypress.PluginEvents, config: Cypress.PluginConfigOptions) => {
    on("before:browser:launch", (browser, launchOptions) => {
        if (browser.family === "chromium") {
            console.log("Adding Chrome flag: --disable-dev-shm-usage");
            launchOptions.args.push("--disable-dev-shm-usage");
        }
        if (browser.name === "chrome") {
            launchOptions.args.push("--js-flags=--expose-gc");
            launchOptions.args.push(
                "--disable-features=CrossSiteDocumentBlockingIfIsolating,CrossSiteDocumentBlockingAlways,IsolateOrigins,site-per-process"
            );
            launchOptions.args.push(
                "--load-extension=cypress/extensions/Ignore-X-Frame-headers_v1.1"
            );
        }
        if (browser.family === "firefox") {
            launchOptions.preferences["security.fileuri.strict_origin_policy"] = false;
            launchOptions.preferences["network.http.referer.XOriginPolicy"] = 1;
        }
        return launchOptions;
    });

    return config;
};
