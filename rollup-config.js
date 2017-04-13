import fable from 'rollup-plugin-fable';

export default {
  entry: 'BlockDeviceListener.fsproj',
  dest: 'dist/bundle.js',
  plugins: [
    fable({
      babel: {
        presets: [['env', { targets: { node: 'current' }, modules: false }]],
        plugins: [],
        babelrc: false
      }
    })
  ],
  format: 'cjs'
};
