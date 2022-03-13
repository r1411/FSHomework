// Номер задачи в лабе: 1.20
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

// Максимальный элемент списка
let get_max_elem list =
    let rec gmi_r list current_max =
        match list with
        | [] -> current_max
        | h::t ->
            let new_current_max = if h > current_max then h else current_max
            gmi_r t new_current_max    
    gmi_r list list.Head

let rec contains list elem =
    match list with
    | [] -> false
    | h :: t ->
        if h = elem then true
        else contains t elem

// Все пропущенные элементы списка
let get_missing list = 
    let min_elem = get_min_elem list
    let max_elem = get_max_elem list
    
    // Собираем все числа от min до max, пропуская те, что есть в исходном списке
    let rec build_missing list new_list current =
        if current = max_elem then new_list
        else
            let new_new_list = if contains list current then new_list else new_list @ [current]
            let new_current = current + 1
            build_missing list new_new_list new_current
            
    build_missing list [] min_elem
        

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов:"
    let cnt = Console.ReadLine() |> Convert.ToInt32
    printfn "Список:"
    let list = readList cnt
    
    let missing = get_missing list
    printfn "Пропущенные числа:"
    writeList missing
    0