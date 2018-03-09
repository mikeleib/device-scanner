// Copyright (c) 2018 Intel Corporation. All rights reserved.
// Use of this source code is governed by a MIT-style
// license that can be found in the LICENSE file.

module IML.IntegrationTest.IntegrationTest

open Fable.Core.JsInterop
open Fable.PowerPack
open IML.StatefulPromise.StatefulPromise
open IML.IntegrationTestFramework.IntegrationTestFramework

open Fable.Import
open Fable.Import.Jest
open Fable.Import.Jest.Matchers
open Fable.Import.Node
open Fable.Import.Node.PowerPack
open Fable.PowerPack.Json

let scannerInfo =
  pipeToShellCmd "echo '\"Info\"'" "socat - UNIX-CONNECT:/var/run/device-scanner.sock"
let unwrapObject a =
    match a with
    | Json.Object a -> Map.ofArray a
    | _ -> failwith "Invalid JSON, it must be an object"

let unwrapResult a =
  match a with
  | Ok x -> x
  | Error e -> failwith !!e

let unwrapDeviceData = Json.ofString >> unwrapResult >> unwrapObject >> Map.find("blockDevices") >> unwrapObject
let resultOutput: StatefulResult<State, Out, Err> -> string = function
  | Ok ((Stdout(r), _), _) -> r
  | Error (e) -> failwithf "Command failed: %A" !!e

let rbScanForDisk (hostId:string) (rollbackState:RollbackState): JS.Promise<RollbackStateResult<Out, Err>> =
  let command = sprintf "echo \"- - -\" > /sys/class/scsi_host/host%s/scan" hostId
  command
    |> (execShell >> (addToRollbackState command rollbackState))

let setDeviceState (name:string) (state:string): State -> JS.Promise<CommandResult<Out, Err>> =
  cmd (sprintf "echo \"%s\" > /sys/block/%s/device/state" state name)

let deleteDevice (name:string) (hostId:string): State -> JS.Promise<CommandResult<Out, Err>> =
  cmd (sprintf "echo \"1\" > /sys/block/%s/device/delete" name)
    >> rollback (rbScanForDisk hostId)

let matchResultToSnapshot (r:StatefulResult<State, Out, Err>, _): unit =
  let json =
    r
      |> resultOutput
      |> unwrapDeviceData
      |> toJson
      |> buffer.Buffer.from

  toMatchSnapshot json

testAsync "info event" <| fun () ->
  command {
    return! scannerInfo
  }
  |> startCommand "Info Event"
  |> Promise.map matchResultToSnapshot

testAsync "remove a device" <| fun () ->
  command {
    do! (setDeviceState "sdc" "offline") >> ignoreCmd
    do! (deleteDevice "sdc" "4") >> ignoreCmd
    return! scannerInfo

  }
  |> startCommand "removing a device"
  |> Promise.map matchResultToSnapshot
