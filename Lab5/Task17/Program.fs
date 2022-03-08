open System

let rec nod a b =
    if a = 0 || b = 0 then
        a + b
    else
        let new_a = if a > b then a % b else a
        let new_b = if a <= b then b % a else b
        nod new_a new_b

let process_dividers x func init =
    let rec process_divs_internal x func init current_divider =
        if current_divider = 0 then init
        else
            let new_init = if x % current_divider = 0 then func init current_divider else init
            let new_divider = current_divider - 1
            process_divs_internal x func new_init new_divider
    process_divs_internal x func init x

let process_primes x func init =
    let rec process_primes_internal x func init candidate =
        if candidate <= 0 then
            init
        else
            let new_init = if nod x candidate = 1 then func init candidate else init
            let new_cand = candidate - 1
            process_primes_internal x func new_init new_cand
    process_primes_internal x func init x

// 17.1 - Обход делителей числа с условием
let proc_div_pred x predicate func init =
    let func1 init divider = if predicate divider then func init divider else init
    process_dividers x func1 init

// 17.2 - Обход взаимнопростых чисел с условием
let proc_primes_pred x predicate func init =
    let func1 init divider = if predicate divider then func init divider else init
    process_primes x func1 init

[<EntryPoint>]
let main argv =
    printfn "Введите число"
    let x = Console.ReadLine() |> Int32.Parse

    // Тест 1 - Сумма четных делителей числа
    let test1 = proc_div_pred x (fun d -> d % 2 = 0) (fun init div -> init + div) 0
    printfn "Test 1: %d" test1

    // Тест 2 - Сумма взаимно простых компонентов числа x, которые больше 10
    let test2 = proc_primes_pred x (fun pr -> pr > 10) (fun init pr -> init + pr) 0
    printfn "Test 2: %d" test2

    0
