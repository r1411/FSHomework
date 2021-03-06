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

let between_max list = 
    let max_elem = List.max list
    
    let max1_index = List.findIndex (fun (idx, x) -> x = max_elem) (List.indexed list)
    let max2_index = List.tryFindIndex (fun (idx, x) -> idx <> max1_index && x = max_elem) (List.indexed list)
    
    if max2_index = None then
        []
    else
        let between_indexed = List.filter (fun x -> fst x > max1_index && fst x < Option.get max2_index) (List.indexed list)
        List.map (fun x -> snd x) between_indexed

        

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов:"
    let cnt = Console.ReadLine() |> Convert.ToInt32
    printfn "Список:"
    let list = readList cnt
    
    let between = between_max list

    printfn "Элементы между первым и вторым максимальными:"
    writeList between
    0
