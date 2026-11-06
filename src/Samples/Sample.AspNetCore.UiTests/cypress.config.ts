const { defineConfig } = require("cypress");

module.exports = defineConfig({
  e2e: {
    setupNodeEvents(on: any, config: any) {
      // implement node event listeners here
      return require("./cypress/plugins/index.ts")(on, config);
    },
  },
  expose: {
    baseUrl: "https://localhost:5001"
  },
  chromeWebSecurity: false,
  // Cypress 16 changed the default from 10 to 0. Swedbank Pay's card form formats
  // input as you type (e.g. MM/YY), so keep the previous per-keystroke delay.
  keystrokeDelay: 10,
  reporter: "junit",
  reporterOptions: {
    mochaFile: "cypress/reports/report-[hash].xml",
    toConsole: true,
  },
  viewportWidth: 1280,
  viewportHeight: 800,
  blockHosts: [
    "*googleoptimize.com",
    "*googletagmanager.com",
    "*google-analytics.com",
    "*googleadservices.com",
    "*static.hotjar.com",
    "*script.hotjar.com",
    "*connect.facebook.net",
    "*tvsquared.com",
    "*dc.services.visualstudio.com",
    "*logx.optimizely.com",
  ],
});
