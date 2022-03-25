open System

// Операторы async, let! И return! используются для асинхронного программирования. Но оно не рассмотрено в курсе :(

// Агент отвечает на сообщения пользователя.

let messageResponder = MailboxProcessor.Start(fun inbox->
    // Цикл обработки сообщений
    let rec messageLoop() = async {
        // Чтение сообщения
        let! (msg:string) = inbox.Receive()

        let response = match msg.ToLower() with
        | "привет" -> "Привет!!!"
        | "как дела?" -> "Все путем"
        | "что делаешь?" -> "Принимаю сообщения"
        | "расскажи анекдот" -> "Шел медведь по лесу, видит камень, а на нем надпись: налево пойдешь — в машине сгоришь, направо пойдешь — в машине сгоришь, прямо пойдешь — в машине сгоришь. Пошел медведь направо, видит — машина горит. Сел в машину и сгорел."
        | "очень смешно" -> "Спасибо, я старался"
        | _ -> "Моя твоя не понимать"

        printfn "<- %s" response

        return! messageLoop()
    }
    
    // Запуск обработки сообщений
    messageLoop()
)

let rec askUser() =
    let input = Console.ReadLine().Trim()
    if not (String.IsNullOrEmpty input) then
        messageResponder.Post(input)
        askUser()

[<EntryPoint>]
let main argv =
    printfn "Супер мега искусственный интеллект готов ответить на ваши сообщения!"
    printfn "Для окончания ввода введите пустой символ"
    askUser()
    0
