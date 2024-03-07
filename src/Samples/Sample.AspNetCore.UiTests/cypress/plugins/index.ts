/// <reference types="cypress" />
// ***********************************************************
// This example plugins/index.js can be used to load plugins
//
// You can change the location of this file or turn off loading
// the plugins file with the 'pluginsFile' configuration option.
//
// You can read more here:
// https://on.cypress.io/plugins-guide
// ***********************************************************

// This function is called when a project is opened or re-opened (e.g. due to
// the project's config changing)

const fs = require("fs");
const path = require("path");

/**
 * @type {Cypress.PluginConfig}
 */
module.exports = (on, config) => {
    // `on` is used to hook into various events Cypress emits
    // `config` is the resolved Cypress config

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
            // launchOptions.preferences is a map of preference names to values
            launchOptions.preferences["security.fileuri.strict_origin_policy"] =
                false;
            launchOptions.preferences["network.http.referer.XOriginPolicy"] = 1;
            return launchOptions;
        }
        return launchOptions;
    });

    on("task", {
        nogooglejs() {
            cy.setCookie("uitest_disable_googlejs", "true");
            return true;
        },

        waitUntilFileExists({ directory, filter }) {
            while (true) {
                let files = fs.readdirSync(directory);
                {
                    if (files.filter((file) => file.endsWith(filter)).length > 0) {
                        return files[0];
                    }
                }
            }
        },

        cleanFolder(directory) {
            if (fs.existsSync(path)) {
                let files = fs.readdirSync(directory);
                {
                    for (const file of files) {
                        fs.unlink(directory + file, (err) => {
                            if (err) throw err;
                        });
                    }
                }
                return files;
            } else {
                return null;
            }
        },
    });
};
