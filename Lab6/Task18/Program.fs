// Номер задачи в лабе: 1.42
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

// Проход по списку с аккумулятором
let rec accumulate list f acc = 
    match list with
    | [] -> acc
    | h::t ->
        let newAcc = f acc h
        accumulate t f newAcc

// Среднее значение по списку
let list_avg list =
    let listSum = accumulate list (fun x y -> x + y) 0
    (double) listSum / (double) list.Length

// Выбрать элементы, удовлетворяющие предикату
let filter_pred list pred =
    let rec countPred_r list pred new_list =
        match list with
        | [] -> new_list
        | h::t ->
            let new_new_list = if pred h then new_list @ [h] else new_list
            countPred_r t pred new_new_list
    
    countPred_r list pred []

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов:"
    let cnt = Console.ReadLine() |> Convert.ToInt32
    printfn "Список:"
    let list = readList cnt

    let avg = list_avg list
    let less_than_avg = filter_pred list (fun x -> (double) x < avg)
    
    printfn "Элементы, меньшие, чем среднее (%f):" avg
    writeList less_than_avg

    0
