import babel from 'rollup-plugin-babel';
import nodeResolve from 'rollup-plugin-node-resolve';
import cleanup from 'rollup-plugin-cleanup';

export default {
  plugins: [
    babel({
      presets: [['env', { targets: { node: 'current' }, modules: false }]],
      plugins: [
        ['transform-object-rest-spread', { useBuiltIns: true }],
        'transform-flow-strip-types',
        'external-helpers'
      ],
      babelrc: false
    }),
    nodeResolve({ main: true }),
    cleanup({ maxEmptyLines: 0 })
  ],
  format: 'cjs'
};
