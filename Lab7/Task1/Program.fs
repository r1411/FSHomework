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
    let len = List.length list
    let shift_index idx = if idx < len - 3 then idx + 3 else if idx-(len-3) < len then idx-(len-3) else 0
    
    printfn "Сдвинутый список"
    let shifted = List.init (List.length list) (fun idx -> List.item (shift_index idx) list)
    writeList shifted
    0
