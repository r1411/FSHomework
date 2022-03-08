open System

// Произведение цифр числа, рекурсия вверх
let rec mult_up x =
    if x = 0 then 1
    else (x % 10) * mult_up(x / 10)

// Произведение цифр числа, рекурсия вниз
let mult_down x =
    let rec mult_down_r x current =
        if x = 0 then current
        else
            let new_curent = current * (x % 10)
            let new_x = x / 10
            mult_down_r new_x new_curent
    mult_down_r x 1

// Минимальная цифра числа, рекурсия вниз
let min_number_down x =
    let rec min_number_down_r x current_min =
        if x = 0 then current_min
        else
            let new_min = if x % 10 < current_min then x % 10 else current_min
            let new_x = x / 10
            min_number_down_r new_x new_min

    min_number_down_r x (x % 10)

// Мин. цифра числа, рекурсия вверх
let rec min_number_up x =
    if x < 10 then x
    else min (x % 10) (min_number_up (x / 10))


// Максимальная цифра числа, рекурсия вниз
let max_number_down x =
    let rec max_number_down_r x current_max =
        if x = 0 then current_max
        else
            let new_max = if x % 10 > current_max then x % 10 else current_max
            let new_x = x / 10
            max_number_down_r new_x new_max

    max_number_down_r x (x % 10)

// Макс. цифра числа, рекурсия вверх
let rec max_number_up x =
    if x < 10 then x
    else max (x % 10) (max_number_up (x / 10))

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число")
    let x = Console.ReadLine() |> Int32.Parse
    Console.WriteLine("Произведение цифр (вверх): {0}", mult_up x)
    Console.WriteLine("Произведение цифр (вниз): {0}", mult_down x)
    Console.WriteLine("Минимальная цифра числа (вверх): {0}", min_number_up x)
    Console.WriteLine("Минимальная цифра числа (вниз): {0}", min_number_down x)
    Console.WriteLine("Максимальная цифра числа (вверх): {0}", max_number_up x)
    Console.WriteLine("Максимальная цифра числа (вниз): {0}", max_number_down x)
    0
