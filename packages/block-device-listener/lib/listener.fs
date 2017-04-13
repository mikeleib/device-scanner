module BlockDeviceListener.Listener

open Fable.Core
open Node.Net

[<Pojo>]
type NetPath = {
  path: string
}

[<Emit"JSON.stringify($0)">]
let toJson x = jsNative

let run (net:net_types.Globals) (env:obj) =
  let client = net.connect { path = "/var/run/device-scanner.sock"; }
  client.once(
    "connect",
    fun () -> client.``end``(toJson env)
  ) |> ignore
