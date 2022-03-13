// Номер задачи в лабе: 1.27
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

let shift_left (list: 'a list) =
    if list.Length <= 1 then list
    else
        list.Tail @ [list.Head]

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов:"
    let cnt = Console.ReadLine() |> Convert.ToInt32
    printfn "Список:"
    let list = readList cnt

    let shifted_list = shift_left list
    printfn "Сдвинутый список:"
    writeList shifted_list
    0
