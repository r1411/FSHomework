// Номер задачи в лабе: 1.5
open System

let rec readList n = 
    if n=0 then []
    else
        let Head = Console.ReadLine() |> Convert.ToInt32
        let Tail = readList (n-1)
        Head::Tail

// Минимальный элемент списка
let get_min_elem list =
    let rec gmi_r list current_min =
        match list with
        | [] -> current_min
        | h::t ->
            let new_current_min = if h < current_min then h else current_min
            gmi_r t new_current_min
    
    gmi_r list list.Head

// Является ли элемент по индексу минимальным
let is_global_min list idx =
    let min_value = get_min_elem list

    // Идем до индекса, когда дошли, проверяем, что элемент по этому индексу = минимальному
    let rec check_if_min (list: 'a list) idx current_idx =
        if current_idx = idx then
            list.Head = min_value
        else
            let new_current_idx = current_idx + 1
            let new_list = list.Tail
            check_if_min new_list idx new_current_idx

    check_if_min list idx 0


[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов и список:"
    let list = readList (Console.ReadLine() |> Convert.ToInt32)
    printfn "Индекс предполагаемого минимума:"
    let idx = (Console.ReadLine() |> Convert.ToInt32)
    let result = is_global_min list idx
    printfn "Элемент по индексу %d минимальный: %b" idx result
    0
