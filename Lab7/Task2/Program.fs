open System

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
    
    let max1 = List.max list
    let max2 = List.reduce (fun accum x -> if x > accum && x <> max1 then x else accum) list
    
    let max1_index = List.findIndex (fun x -> x = max1) list
    let max2_index = List.findIndex (fun x -> x = max2) list

    let from_index = min max1_index max2_index
    let to_index = max max1_index max2_index

    let between_indexed = List.filter (fun x -> fst x > from_index && fst x < to_index) (List.indexed list)
    let between = List.map (fun x -> snd x) between_indexed

    printfn "Элементы между двумя максимальными:"
    writeList between
    
    0
