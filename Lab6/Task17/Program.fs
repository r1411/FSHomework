// Номер задачи в лабе: 1.30
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

let is_local_max list idx =
    let rec ilm_r (list: 'a list) prev idx current_idx =
        if idx = current_idx then
            match (prev, list.Tail) with
            | (None, []) -> true
            | (None, h::t) -> list.Head > h
            | (Some p, []) -> list.Head > p
            | (Some p, _) -> list.Head > p && list.Head > list.Tail.Head
        else
            let new_list = list.Tail
            let new_prev = list.Head
            let new_ci = current_idx + 1
            ilm_r new_list (Some new_prev) idx new_ci

    ilm_r list None idx 0


[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов:"
    let cnt = Console.ReadLine() |> Convert.ToInt32
    printfn "Список:"
    let list = readList cnt
    printfn "Индекс проверки локального максимума"
    let idx = Console.ReadLine() |> Convert.ToInt32

    let result = is_local_max list idx
    printfn "Элемент по индексу %d - локальный max: %b" idx result
    0
