open System

let read_array n =
    let rec read_array_r n arr = 
        if n = 0 then
            arr
        else
            let tail = System.Console.ReadLine() |> Int32.Parse
            let new_arr = Array.append arr [|tail|]
            let n1 = n - 1
            read_array_r n1 new_arr

    read_array_r n Array.empty

let write_array arr =
    printfn "%A" arr



[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов в массиве 1:"
    let n1 = Console.ReadLine() |>Int32.Parse
    printfn "Массив 1:"
    let arr1 = read_array  n1
    printfn "Кол-во элементов в массиве 2:"
    let n2 = Console.ReadLine() |> Int32.Parse
    printfn "Массив 2:"
    let arr2 = read_array n2

    let union = Array.filter (fun x -> not (Array.contains x arr1)) arr2 |> Array.append arr1 |> Array.sort

    printfn "Объединение элементов массивов:"
    write_array union

    0
