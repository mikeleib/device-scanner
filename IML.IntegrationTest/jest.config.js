module.exports = {
  setupTestFrameworkScriptFile: './jest.setup.js',
  preset: 'jest-fable-preprocessor',
  displayName: 'Integration tests',
  bail: true,
  snapshotSerializers: ['../buffer-serializer.js']
};
