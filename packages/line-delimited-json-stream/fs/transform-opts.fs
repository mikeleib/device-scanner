module LineDelimitedJsonStream.Opts

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


open Fable.Import.Node

let getOpts () =
  let mutable objectMode = Some(true)
  let mutable encoding = None
  let mutable decodeStrings = None
  let mutable highWaterMark: float option = None

  {
    new stream.TransformOptions with
      member this.highWaterMark
        with get() = highWaterMark
        and set(x) = highWaterMark <- x
      member this.encoding
        with get() = encoding
        and set(x) = encoding <- x
      member this.objectMode
        with get() = objectMode
        and set(x) = objectMode <- x
      member this.decodeStrings
        with get() = decodeStrings
        and set(x) = decodeStrings <- x
  }
