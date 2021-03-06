﻿module FSharpx.TypeProviders.Tests.FifaTests

open NUnit.Framework
open FsUnit
open FSharpx.TypeProviders.Freebase

let data = FreebaseData.GetDataContext()

let findCountryByFifaCode code = 
    query { for x in data.``Time and Space``.Location.Countries do 
            where (x.``FIFA Code`` = code) 
            exactlyOne }

[<Test>]
let ``Can access Australia's national anthem by Fifa code``() =
    let country = findCountryByFifaCode "AUS"
    let anthem = country.``National anthem`` |> Seq.head
    anthem.Anthem.Name |> should equal "Advance Australia Fair"