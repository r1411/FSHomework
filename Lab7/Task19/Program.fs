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

// Расположить все цифры в начале строки, все буквы - в конце
let arrange str =
    let nums_only = String.filter (fun ch -> Char.IsDigit ch) str
    let chars_only = String.filter (fun ch -> Char.IsLetter ch) str
    String.concat "" [nums_only; chars_only]

[<EntryPoint>]
let main argv =
    
    0
