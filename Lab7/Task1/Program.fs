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

let shiftLeft list n =
    let len = List.length list
    let shift_index idx = if idx < len - n then idx + n else if idx-(len-n) < len then idx-(len-n) else 0
    List.init (List.length list) (fun idx -> List.item (shift_index idx) list)

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов:"
    let cnt = Console.ReadLine() |> Convert.ToInt32
    printfn "Список:"
    let list = readList cnt
    
    let shifted = shiftLeft list 3

    printfn "Сдвинутый список"
    writeList shifted
    0
