open System


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


let sum_not_prime_dividers x =
    let rec sum_not_prime_dividers_r x current_sum current_divider =
        if current_divider = 0 then current_sum
        else
            let new_sum = if x % current_divider = 0 && not (is_prime current_divider) then current_sum + current_divider else current_sum
            let new_divider = current_divider - 1
            sum_not_prime_dividers_r x new_sum new_divider
    sum_not_prime_dividers_r x 0 x
    
[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число")
    let x = Console.ReadLine() |> Int32.Parse

    printf "Сумма непростых делителей: %d" (sum_not_prime_dividers x)

    0
