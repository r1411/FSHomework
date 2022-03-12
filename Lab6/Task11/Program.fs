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

let proc3 list func =
    let rec proc3_r list func new_list =
        match list with
        | [] -> new_list
        | elem_0::t ->
            // elem_1 - следующий, elem_2 - после следующего
            let elem_1 = if t <> [] then t.Head else 1
            let elem_2 = if t <> [] then (if t.Tail <> [] then t.Tail.Head else 1) else 1
            // Результат применения функци к трем обрабатываемым элементам
            let three_to_one = func elem_0 elem_1 elem_2
            // Добавляем элемент к накапливаемому списку
            let new_new_list = new_list @ [three_to_one]
            // Сдвигаем переданный список на три влево
            let shifted_list = if t <> [] then (if t.Tail <> [] then t.Tail.Tail else []) else []
            proc3_r shifted_list func new_new_list

    proc3_r list func []

[<EntryPoint>]
let main argv =
    printfn "Кол-во элементов и список:"
    let list = readList (Console.ReadLine() |> Convert.ToInt32)
    let new_list = proc3 list (fun x y z -> x + y + z)
    printfn "Результат:"
    writeList new_list
    0