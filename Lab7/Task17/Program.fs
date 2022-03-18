// Для теста:
// 7,3,4,5,6
// 2,3,4,6,7
// 2,3,4,5,6
// 4,3,10,4,5

open System

let rec writeList = function
    | [] -> ()
    | head::tail -> 
        printfn "%O" head
        writeList tail

// Прочитать кортеж длины 5
let read_tuple5() =
    let nums = Console.ReadLine().Split(",") |> Array.toList |> List.map (fun x -> Int32.Parse x)
    (nums.[0], nums.[1], nums.[2], nums.[3], nums.[4])

// Прочитать список 5-кортежей
let rec read_tuples5_list n = 
    if n=0 then []
    else
        let Head = read_tuple5()
        let Tail = read_tuples5_list (n-1)
        Head::Tail

let is_digit x =
    x >= 0 && x <= 9

// Получить idx-ый элемент кортежа
let unpack5 tuple idx =
    match idx, tuple with
    | 0, (a,_,_,_,_) -> a
    | 1, (_,b,_,_,_) -> b
    | 2, (_,_,c,_,_) -> c
    | 3, (_,_,_,d,_) -> d
    | 4, (_,_,_,_,e) -> e
    | _, _ -> failwith (sprintf "Несуществующий индекс %i" idx) 

// Проверить, состоит ли кортеж только из цифр
let is_digital5 tuple =
    let rec is_digital5_r tuple idx =
        if idx = 5 then
            true
        else if not (is_digit (unpack5 tuple idx)) then
            false
        else
            let new_idx = idx + 1
            is_digital5_r tuple new_idx


    is_digital5_r tuple 0

// Кортеж в число
let tuple_to_int tuple =
    let rec tti_r tuple number idx =
        if idx = 5 then
            number
        else
            let new_number = number * 10 + unpack5 tuple idx
            let new_idx = idx + 1
            tti_r tuple new_number new_idx
    tti_r tuple (unpack5 tuple 0) 1

[<EntryPoint>]
let main argv =
    printfn "Количество кортежей:"
    let cnt = Console.ReadLine() |> Int32.Parse
    printfn "Введите %d корежей длины 5. Числа разделять запятыми." cnt
    let tuples = read_tuples5_list cnt
    let good_tuples = List.filter (fun x -> is_digital5 x) tuples
    let joined = List.map (fun x -> tuple_to_int x) (List.sort good_tuples)

    printfn "Результат:"
    writeList joined

    0
