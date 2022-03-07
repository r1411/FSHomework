open System

let answer_to = function
    | "f#" | "prolog" -> "Пoдлизa!"
    | "python" -> "На змеином не разгорвариваю"
    | "java" -> "Приглашаю на чашечку Java"
    | "c#" -> "Мистер Билл Гейтс передает вам привет"
    | "c++" -> "Отлично"
    | "c" -> "Здорово"
    | "php" -> "Купи слона"
    | _ -> "Такого не знаю"

[<EntryPoint>]
let main argv =
    let lang = Console.ReadLine().ToLower()
    Console.WriteLine(answer_to lang)
    0