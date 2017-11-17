// Copyright (c) 2017 Intel Corporation. All rights reserved.
// Use of this source code is governed by a MIT-style
// license that can be found in the LICENSE file.

module IML.EventListener.Listener

open Fable.Import.JS
open Fable.Import.Node
open NodeHelpers

let private client = connect { path = "/var/run/device-scanner.sock"; }

let private endClient = ``end`` client

let private data = (JSON.stringify Globals.``process``.env)

client
  |> onceConnect (fun () -> endClient (Some data))
  |> ignore