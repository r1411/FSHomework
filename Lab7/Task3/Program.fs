﻿open System

let rec readList n = 
    if n=0 then []
    else
        let Head = Console.ReadLine() |> Convert.ToInt32
        let Tail = readList (n-1)
        Head::Tail

let rec writeList = function
    | [] -> ()
    | head::tail -> 
        printfn "%O" head
        writeList tail

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов:"
    let cnt = Console.ReadLine() |> Convert.ToInt32
    printfn "Список:"
    let list = readList cnt
    
    let min_elem = List.min list
    
    let min1_index = List.findIndex (fun (idx, x) -> x = min_elem) (List.indexed list)
    let min2_index = List.findIndexBack (fun (idx, x) -> x = min_elem) (List.indexed list)
    
    if min1_index = min2_index then
        printfn "В списке нет второго минимального числа"
    else
        printfn "Элементов между первым и вторым максимальными: %d" (min2_index - min1_index - 1)

    0
