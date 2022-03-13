// Номер задачи в лабе: 1.48
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

// Сколько раз элемент встречается в списке
let frequency list element =
    let rec freq list elem count =
        match list with
        | [] -> count
        | h::t -> 
            let new_count = if h = elem then count + 1 else count
            freq t elem new_count

    freq list element 0

// Найти самый частый элемент в списке
let find_most_freq_elem list =
    let rec fmfe_r list elem current_max =
        match list with
        | [] -> elem
        | h::t -> 
            let fr_h = frequency list h
            let new_max = if fr_h > current_max then fr_h else current_max
            let new_elem = if fr_h > current_max then h else elem
            fmfe_r t new_elem new_max

    fmfe_r list 0 0

// Найти индексы, где стоит элемент
let find_elem_idxs list elem =
    let rec fei_r list elem new_list idx =
        match list with
        | [] -> new_list
        | h::t ->
            let new_new_list = if h = elem then new_list @ [idx] else new_list
            let new_idx = idx + 1
            fei_r t elem new_new_list new_idx
    
    fei_r list elem [] 0

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов:"
    let cnt = Console.ReadLine() |> Convert.ToInt32
    printfn "Список:"
    let list = readList cnt

    let most_freq_elem = find_most_freq_elem list
    let elem_idxs = find_elem_idxs list most_freq_elem

    printfn "Самый частый элемент: %d" most_freq_elem
    printfn "Его индексы:"
    writeList elem_idxs
    0
