open System

type DriversLicense(first_name: string, last_name: string, series: int, number: int, issDate: DateTime, expDate: DateTime) =
    member this.first_name = first_name
    member this.last_name = last_name
    member this.series = series
    member this.number = number
    member this.issDate = issDate
    member this.expDate = expDate

    member this.isValid() = DateTime.Now < expDate

    override this.ToString() = $"Права{{Имя: {this.first_name}, Фамилия: {this.last_name}, Серия: {this.series}, Номер: {this.number}, Дата выдачи: {this.issDate.ToShortDateString()}, Дата истечения: {this.expDate.ToShortDateString()}}}"

[<EntryPoint>]
let main argv =
    let lic1 = DriversLicense("Артур", "Манукьян", 7777, 123000, DateTime.Parse "01.01.2020", DateTime.Parse "01.04.2022")
    Console.WriteLine(lic1)

    0
