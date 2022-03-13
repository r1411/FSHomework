// Номер задачи в лабе: 1.18
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

// Минимальный элемент списка
let get_min_elem list =
    let rec gmi_r list current_min =
        match list with
        | [] -> current_min
        | h::t ->
            let new_current_min = if h < current_min then h else current_min
            gmi_r t new_current_min
    
    gmi_r list list.Head

// Элементы до минимального элемента списка
let get_before_min list =
    let min_elem = get_min_elem list

    let rec gbm_r (list: 'a list) new_list =
        if list.Head = min_elem then
            new_list
        else
            let new_new_list = new_list @ [list.Head]
            let next_list = list.Tail
            gbm_r next_list new_new_list

    gbm_r list []

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов:"
    let cnt = Console.ReadLine() |> Convert.ToInt32
    printfn "Список:"
    let list = readList cnt

    let bm_list = get_before_min list
    printfn "Элементы до минимального:"
    writeList bm_list
    0
