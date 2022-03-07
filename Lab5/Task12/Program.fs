open System

[<EntryPoint>]
let main argv =
    let lower (x: String) = x.ToLower()
    let answer_to x =
        match x with
        | "f#" | "prolog" -> "Пoдлизa!"
        | "python" -> "На змеином не разгорвариваю"
        | "java" -> "Приглашаю на чашечку Java"
        | "c#" -> "Мистер Билл Гейтс передает вам привет"
        | "c++" -> "Отлично"
        | "c" -> "Здорово"
        | "php" -> "Купи слона"
        | _ -> "Такого не знаю"

    
    //12.1
    printfn "Какoй твoй любимый язык?"
    (Console.ReadLine >> lower >> answer_to >> Console.WriteLine)()

    //12.2
    printfn "Какoй твoй любимый язык?"
    let proc input (output:string->unit) chooser = output (chooser (input ()))
    proc Console.ReadLine Console.WriteLine answer_to

    0