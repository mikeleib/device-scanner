/*global jasmine:true*/

jasmine.DEFAULT_TIMEOUT_INTERVAL = 600000;

import jasmineReporters from 'jasmine-reporters';

if (process.env.RUNNER === 'CI') {
  jasmine.VERBOSE = true;
  jasmine.getEnv().addReporter(
    new jasmineReporters.JUnitXmlReporter({
      consolidateAll: true,
      savePath: process.env.SAVE_PATH || './',
      filePrefix: process.env.FILE_PREFIX ||
        'device-scanner-results-' + process.version
    })
  );
}
