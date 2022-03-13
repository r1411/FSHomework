// Номер задачи в лабе: 1.54
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

// Выбрать элементы, удовлетворяющие предикату
let filter_pred list pred =
    let rec countPred_r list pred new_list =
        match list with
        | [] -> new_list
        | h::t ->
            let new_new_list = if pred h then new_list @ [h] else new_list
            countPred_r t pred new_new_list
    
    countPred_r list pred []

let remove_elements list el = 
    filter_pred list (fun x -> (x <> el))

// Убрать повторы из списка
let unique list = 
    let rec unique_r list accum_list = 
        match list with
            | [] -> accum_list
            | h::t -> 
                let tail_without = remove_elements t h
                let new_accum_list = accum_list @ [h]
                unique_r tail_without new_accum_list
    unique_r list [] 

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов:"
    let cnt = Console.ReadLine() |> Convert.ToInt32
    printfn "Список:"
    let list = readList cnt

    let more_3 = filter_pred list (fun x -> frequency list x > 3)
    let result = unique more_3

    printfn "Элементы, встречающиеся более 3 раз:"
    writeList result
    0
