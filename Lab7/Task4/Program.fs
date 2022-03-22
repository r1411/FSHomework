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

let max_odd (list: int list) =
    let sorted = List.sortDescending list
    List.tryFind (fun x -> x % 2 = 1) sorted

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов:"
    let cnt = Console.ReadLine() |> Convert.ToInt32
    printfn "Список:"
    let list = readList cnt

    let max_odd = max_odd list

    if Option.isNone max_odd then
        printfn "В списке нет нечетных элементов"
    else
        printfn "Максимальный нечетный элемент: %d" (Option.get max_odd)

    0
