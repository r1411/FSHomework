open System


let rec nod a b =
    if a = 0 || b = 0 then
        a + b
    else
        let new_a = if a > b then a % b else a
        let new_b = if a <= b then b % a else b
        nod new_a new_b

// 15
let process_primes x func init =
    let rec process_primes_internal x func init candidate =
        if candidate <= 0 then
            init
        else
            let new_init = if nod x candidate = 1 then func init candidate else init
            let new_cand = candidate - 1
            process_primes_internal x func new_init new_cand
    process_primes_internal x func init x

//16
let euler_number x =
    process_primes x (fun a b -> a + 1) 0

[<EntryPoint>]
let main argv =
    printfn "Введите число"
    let x = Console.ReadLine() |> Int32.Parse
    printfn "Сумма взаимно простых чисел: %d" (process_primes x (fun a b -> a + b) 0)
    printfn "Число Эйлера: %d" (euler_number x)


    0
