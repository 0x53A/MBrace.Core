module MBrace.Akka.Runtime.Worker

open Nessos.FsPickler
open Akka.Serialization
open Akka.Actor
open Akka.Configuration
    
let main (argv:string array) : int =
    let configStr = """
akka {
    actor {
        provider = "Akka.Remote.RemoteActorRefProvider, Akka.Remote"
        serializers {
            bytes = "Akka.Serialization.ByteArraySerializer"
            fspickler = "MBrace.Akka.Runtime.FsPicklerSerializer"
        }
    }
    remote {
        helios.tcp {
            port = 8090
            hostname = localhost
        }
    }
}
"""
    let parent = "..."
    let config = ConfigurationFactory.ParseString(configStr)
    use system = ActorSystem.Create("MBrace.Client", config)
    let parent = system.ActorSelection(parent)
    parent.Tell()
    0

