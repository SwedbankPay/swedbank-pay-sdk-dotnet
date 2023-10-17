const { defineConfig } = require("cypress");

module.exports = defineConfig({
  e2e: {
    setupNodeEvents(on: any, config: any) {
      // implement node event listeners here
      return require("./cypress/plugins/index.ts")(on, config);
    }
  },
  chromeWebSecurity: false,
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
