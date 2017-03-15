module LineDelimitedJsonStream.Stream

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

open System
open Fable.Import.Node
open Fable.Core.JsInterop
open System.Text.RegularExpressions
open LineDelimitedJsonStream.Opts

type Callback = Func<Option<Exception>, Option<obj>, unit>

let private matcher x =
  match Regex.Match(x, "\\n") with
    | m when m.Success -> Some(m.Index)
    | _ -> None

let adjustBuff (buff:string, index:int) =
  let out = buff.Substring(0, index)
  let buff = buff.Substring(index + 1)
  (out, buff)

let tryJson (x:string, onSuccess:obj -> unit, onFail) =
  try
    let result = ofJson x
    onSuccess(result)
  with
  | ex ->
    onFail(ex)

let rec getNextMatch (buff:string, callback:Callback, turn:int) =
  let opt = matcher(buff)

  match opt with
    | None ->
      if turn = 0 then
        callback.Invoke(None, None)
      buff
    | Some(index) ->
      let (out, b) = adjustBuff(buff, index)
      tryJson(
        out,
        (fun x -> callback.Invoke(None, Some(x))),
        (fun e -> callback.Invoke(Some(e), None))
      )
      getNextMatch(b, callback, turn + 1)


type LineDelimitedJsonStream(x:string) as self =
  inherit stream.Transform(getOpts())
  let mutable buff = x
  member __._transform (chunk: Buffer, encoding: String, callback:Callback) : unit =
    buff <- getNextMatch(
      buff + chunk.toString("utf-8"),
      callback,
      0
    )
    member __._flush (callback: Callback): unit =
      if buff.Length = 0
      then
        callback.Invoke(None, None)
      else
        tryJson(
          buff,
          (fun x ->
            self.push(x) |> ignore
            callback.Invoke(None, None)
          ),
          (fun e -> callback.Invoke(Some(e), None))
        )

let getJsonStream () = LineDelimitedJsonStream("")
