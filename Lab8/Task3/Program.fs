open System
open FParsec

// Алгебраический тип для выражения (число, сумма, разность)
type Expr =
    | Number of float
    | Add of Expr * Expr
    | Sub of Expr * Expr

// Спарсить строку, возможно окруженную пробелами
let pstring_trim s = spaces >>. pstring s .>> spaces
// float без пробелов
let float_ws = spaces >>. pfloat .>> spaces

// Создаем парсер и ref переменную
let parser, parserRef = createParserForwardedToRef<Expr, unit>()

// 1. Спарсить пару с +, сохранить в Add
let parsePlusExpr = tuple2 (parser .>> pstring_trim "+") parser |>> Add 
// 2. Спарсить пару с -, сохранить в Sub
let parseSubExpr = tuple2 (parser .>> pstring_trim "-") parser |>> Sub

// 3. Спарсить между скобками произвольные комбинации (1) и (2). 
// Attempt - продолжить разбор, если первый вариант разбора оказался неуспешным
let parseOp = between (pstring_trim "(") (pstring_trim ")") (attempt parsePlusExpr <|> parseSubExpr)

// Спарсить float и сохранить в Number
let parseNum = float_ws |>> Number

// Пихаем в parserRef парсер произвольной комбинации float'ов и (3)
parserRef := parseNum <|> parseOp


// Функция вычисления выражения
let rec EvalExpr (e:Expr): float =
    match e with
    | Number(num) -> num
    | Add(a,b) ->
        let left = EvalExpr(a)
        let right = EvalExpr(b)
        let result = left + right
        result
    | Sub(a,b) ->
        let left = EvalExpr(a)
        let right = EvalExpr(b)
        let result = left - right
        result



[<EntryPoint>]
let main argv =
    printfn "Введите выражение (всё оборачивать в скобки): "
    let input = Console.ReadLine() 
    let expr = run parser input

    match expr with
    | Success (result, _, _) -> printfn "Результат: %f" (EvalExpr result)
    | Failure (errorMsg, _, _) -> printfn "Еггог: %s" errorMsg

    0
