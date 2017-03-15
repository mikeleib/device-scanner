import { describe, beforeEach, it, expect } from '../../../jasmine.js';

import streamToPromise from 'stream-to-promise';

import { getJsonStream } from '../dist/bundle.js';

describe('line delimited json stream', () => {
  let jsonStream;

  beforeEach(() => {
    jsonStream = getJsonStream();
  });

  it('should handle JSON in a single chunk', async () => {
    jsonStream.end('{ "foo": "bar", "bar": "baz" }\n');

    const result: mixed = await streamToPromise(jsonStream);

    expect(result).toEqual([{ bar: 'baz', foo: 'bar' }]);
  });

  it('should handle chunks of JSON', async () => {
    jsonStream.write('{ "foo": "bar", ');
    jsonStream.end('"bar": "baz" }\n');

    const result = await streamToPromise(jsonStream);

    expect(result).toEqual([{ bar: 'baz', foo: 'bar' }]);
  });

  it('should handle newlines in a string', async () => {
    jsonStream.end(JSON.stringify({ foo: 'bar\n', bar: 'baz' }) + '\n');

    const result = await streamToPromise(jsonStream);

    expect(result).toEqual([{ bar: 'baz', foo: 'bar\n' }]);
  });

  it('should handle the final json line without a newline', async () => {
    jsonStream.end(JSON.stringify({ foo: 'bar', bar: 'baz' }));

    const result = await streamToPromise(jsonStream);

    expect(result).toEqual([{ bar: 'baz', foo: 'bar' }]);
  });

  it('should handle errors from the stream', (done: doneT) => {
    expect.assertions(1);

    jsonStream
      .on('data', done.fail)
      .on('error', e => {
        expect(e).toEqual(
          new SyntaxError('Unexpected token { in JSON at position 25')
        );
      })
      .on('end', done);

    jsonStream.write('{ "food": "bard", ');
    jsonStream.write('\n');
    jsonStream.end();
  });

  it('should handle multiple records correctly', async () => {
    jsonStream.write('{ "foo": "bar", ');
    jsonStream.write('"bar": "baz" }\n');
    jsonStream.end('{"baz": "bap"}');

    const result = await streamToPromise(jsonStream);

    expect(result).toEqual([{ bar: 'baz', foo: 'bar' }, { baz: 'bap' }]);
  });
});
