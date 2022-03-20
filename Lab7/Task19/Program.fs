open System

// Перемешать символы в слове, кроме первого и последнего
let shuffle_inside str =
    let len = String.length str
    if len <= 3 then
        str
    else
        let rnd = System.Random()
        let order = [1 .. len-2]
        let transposition = [0] @ (List.sortBy(fun _ -> rnd.Next(1, len-2)) order) @ [len - 1]
        String.init len (fun idx -> str.[transposition.[idx]].ToString())

[<EntryPoint>]
let main argv =

    0
