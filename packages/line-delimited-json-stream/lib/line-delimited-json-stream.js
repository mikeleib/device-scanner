// @flow

// INTEL CONFIDENTIAL
//
// Copyright 2013-2017 Intel Corporation All Rights Reserved.
//
// The source code contained or described herein and all documents related
// to the source code ("Material") are owned by Intel Corporation or its
// suppliers or licensors. Title to the Material remains with Intel Corporation
// or its suppliers and licensors. The Material contains trade secrets and
// proprietary and confidential information of Intel or its suppliers and
// licensors. The Material is protected by worldwide copyright and trade secret
// laws and treaty provisions. No part of the Material may be used, copied,
// reproduced, modified, published, uploaded, posted, transmitted, distributed,
// or disclosed in any way without Intel's prior express written permission.
//
// No license under any patent, copyright, trade secret or other intellectual
// property right is granted to or conferred upon you by disclosure or delivery
// of the Materials, either expressly, by implication, inducement, estoppel or
// otherwise. Any license under such intellectual property rights must be
// express and approved by Intel in writing.

import { Transform } from 'stream';

import { flow } from '@iml/fp';

declare interface RegexpMatch extends Array<string> {
  index: number,
  input: string
}

const newline = /\n/;

const matchNewline = (input: string): ?RegexpMatch => newline.exec(input);

const indexOrNull = (match: ?RegexpMatch) => match == null ? null : match.index;

const matcher: (string) => ?number = flow(matchNewline, indexOrNull);

export default () => {
  let buff: string = '';

  type cb = (err: ?Error, obj: ?Object) => mixed;

  return new Transform({
    readableObjectMode: true,
    transform(chunk: Buffer, encoding: buffer$Encoding, callback: cb) {
      buff += chunk.toString('utf8');

      let index: ?number = matcher(buff);

      if (index == null) return callback();

      while (index != null) {
        const input = buff.substr(0, index);

        buff = buff.substr(index + 1);

        try {
          callback(null, JSON.parse(input));
        } catch (e) {
          callback(e);
        }

        index = matcher(buff);
      }
    },
    flush(callback: cb): void {
      if (buff.length > 0)
        try {
          this.push(JSON.parse(buff));
        } catch (e) {
          callback(e);
        }

      callback();
    }
  });
};
