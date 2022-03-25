open System
open System.Text.RegularExpressions

type DriversLicense(first_name: string, last_name: string, series: int, number: int, issDate: DateTime, expDate: DateTime) =
    member this.first_name = first_name
    member this.last_name = last_name
    member this.series = series
    member this.number = number
    member this.issDate = issDate
    member this.expDate = expDate

    member this.isValid() = DateTime.Now < expDate

    interface IComparable with
        member this.CompareTo(obj: obj): int = 
            match obj with
            | :? DriversLicense as lic2 -> if this.series = lic2.series then this.number.CompareTo lic2.number else this.series.CompareTo lic2.series
            | _ -> invalidArg "obj" "Cannot compare values of different types" 

    override this.GetHashCode() =
        HashCode.Combine(series, number)

    override this.Equals(obj2) =
        match obj2 with
        | :? DriversLicense as lic2 -> (this.series = lic2.series) && (this.number = lic2.number)
        | _ -> false

    override this.ToString() = $"Права{{Имя: {this.first_name}, Фамилия: {this.last_name}, Серия: {this.series}, Номер: {this.number}, Дата выдачи: {this.issDate.ToShortDateString()}, Дата истечения: {this.expDate.ToShortDateString()}}}"

// Кидает ошибку если строка не уд. регулярке
let assertRegex str regex =
    let r = Regex(regex)
    if not (r.IsMatch str) then
        invalidArg str $"Строка не удовлетворяет формату: {regex}"

// Ввод поля в соотв. с регуляркой (пока не будет введено верно)
let rec inputField prompt regex =
    printf $"{prompt}: "
    let input = Console.ReadLine()
    try
        assertRegex input regex
        input
    with
    | :? System.ArgumentException as e ->
        printfn "Ошибка: %s" e.Message
        inputField prompt regex
    | e ->
        printfn "Непредвиденное исключение: %s" e.Message
        reraise()

let inputLicense() =
    printfn "=== Создание прав ==="
    
    let fname = inputField "Имя" "^[a-zA-Zа-яА-Я]+$"
    let lname = inputField "Фамилия" "^[a-zA-Zа-яА-Я]+$"
    let series = inputField "Серия" "^\d{4}$" |> Int32.Parse
    let number = inputField "Номер" "^\d{6}$" |> Int32.Parse
    let issDate = inputField "Дата выдачи" "^\s*(3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:19|20)\d{2})\s*$" |> DateTime.Parse
    let expDate = inputField "Дата окончания" "^\s*(3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:19|20)\d{2})\s*$" |> DateTime.Parse

    DriversLicense(fname, lname, series, number, issDate, expDate)


[<EntryPoint>]
let main argv =
    let lic1 = DriversLicense("Артур", "Манукьян", 7777, 123000, DateTime.Parse "01.01.2020", DateTime.Parse "01.04.2022")
    Console.WriteLine(lic1)
    let lic2 = inputLicense()
    
    0
