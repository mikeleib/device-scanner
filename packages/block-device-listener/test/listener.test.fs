module BlockDeviceListener.Test

open Jest
open Fable.Import.JS
open Fable.Core
open BlockDeviceListener.Listener

[<Pojo>]
type MockSocket = {
   once: (obj -> obj);
   ``end``: (obj -> unit);
}

[<Pojo>]
type MockNet = {
  connect: (NetPath -> MockSocket)
}

[<Pojo>]
type MockEnv = {
  foo: string;
  bar: int;
}

let createMocks () =
  let mockSocket = {
    once = jest.fn();
    ``end`` = jest.fn();
  }

  let mockNet = {
      connect = jest.fn(fun () -> mockSocket);
  }

  (mockSocket, mockNet)

test "should call connect with NetPath" <| fun () ->
  let (_, mockNet) = createMocks()

  run (unbox mockNet) { foo = "foo"; bar = 3; }

  toBeCalledWith mockNet.connect { path = "/var/run/device-scanner.sock"; }

test "should call connect" <| fun () ->
  let (mockSocket, mockNet) = createMocks()

  run (unbox mockNet) { foo = "foo"; bar = 3; }

  toBeCalledWith2 mockSocket.once "connect" (expect.any Function)

test "should call end with process data" <| fun () ->
  let (mockSocket, mockNet) = createMocks()

  run (unbox mockNet) { foo = "foo"; bar = 3; }

  mockSocket.once
  |> getMock
  |> fun x -> x.calls
  |> List.last<string * (unit -> unit)>
  |> snd
  |> fun fn -> fn()

  toBeCalledWith mockSocket.``end`` "{\"foo\":\"foo\",\"bar\":3}"
