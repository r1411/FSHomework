open System

let rec readList n = 
    if n=0 then []
    else
        let Head = Console.ReadLine() |> Convert.ToInt32
        let Tail = readList (n-1)
        Head::Tail

let is_prime x =
    let rec is_prime_r x current =
        if current = 0 then false // Отдельный случай для 1
        else
        if current = 1 then true
        else
            if x % current = 0 then false
            else
                let new_current = current - 1
                is_prime_r x new_current

    is_prime_r x (x - 1)

// Посчитать сумму и количество элементов в списке, удовл. предикату
let get_sum_and_count pred list =
    List.fold (fun a x -> if pred (fst x) then (fst a + fst x, snd a + 1) else a) (0, 0) (List.zip list list)

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов:"
    let cnt = Console.ReadLine() |> Convert.ToInt32
    printfn "Список:"
    let list = readList cnt
    
    // Сумма и кол-во простых чисел
    let prime_sum_cnt = get_sum_and_count (fun x -> is_prime x) list
    // Среднее значение простых элементов в list
    let prime_avg = (double) (fst prime_sum_cnt) / (double) (snd prime_sum_cnt)

    // Сумма и кол-во непростых элементов, больших prime_avg
    let big_not_prime_sum_cnt = get_sum_and_count (fun x -> not (is_prime x) && (double)x > prime_avg) list
    // Среднее непростых элементов, больших prime_avg
    let big_not_prime_avg = (double) (fst big_not_prime_sum_cnt) / (double) (snd big_not_prime_sum_cnt) 
    
    printfn "Среднее простых: %f" prime_avg
    printfn "Cреднее непростых элементов, больших, чем среднее простых: %f" big_not_prime_avg

    0