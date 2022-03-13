// Номер задачи в лабе: 1.6
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


let rec shift_left_n list n = 
    if n = 0 then list
    else
        let new_n = n - 1
        let new_list = shift_left list
        shift_left_n new_list new_n

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов:"
    let cnt = Console.ReadLine() |> Convert.ToInt32
    printfn "Список:"
    let list = readList cnt

    let shifted_list = shift_left_n list 3
    printfn "Сдвинутый список:"
    writeList shifted_list
    0
