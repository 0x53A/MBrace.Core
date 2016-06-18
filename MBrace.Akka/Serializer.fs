namespace MBrace.Akka.Runtime

open Akka.Serialization
open Nessos.FsPickler


type FsPicklerSerializer(system) =
    inherit Serializer(system) with
        let fsPickler = FsPickler.CreateBinarySerializer()
        override x.IncludeManifest = false
        override x.Identifier = -1700261163 //"FsPickler".GetHashCode()
        override x.ToBinary obj =
            fsPickler.Pickle obj
        override x.FromBinary(bytes, typ) =
            fsPickler.UnPickle bytes

