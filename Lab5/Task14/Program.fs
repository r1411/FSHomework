open System

let process_dividers x func init =
    let rec process_divs_internal x func init current_divider =
        if current_divider = 0 then init
        else
            let new_init = if x % current_divider = 0 then func init current_divider else init
            let new_divider = current_divider - 1
            process_divs_internal x func new_init new_divider
    process_divs_internal x func init x
        

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите число")
    let x = Console.ReadLine() |> Int32.Parse
    let result = process_dividers x (fun x y -> x + y) 0
    Console.Write("Результат: ")
    Console.WriteLine result

    0
