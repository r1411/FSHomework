// ЛР 5 в книжке
open System

// Тип-обертка
type Maybe<'x> =
    | Just of 'x
    | Nothing 

// Функтор для применения функции func к значению в Maybe
let fmapMaybe func px =
    match px with
    | Just x -> Just (func x)
    | Nothing -> Nothing

// Аппликативный функтор для применения Maybe<f> к Maybe<a> (вернёт Maybe<b>)
let applyMaybe pf px =
    match pf, px with
    | Just f, Just x -> Just (f x)
    | _-> Nothing   

// Монада для применения f:(a -> Maybe<b>) к Maybe<x>
let monadMaybe px f =
    match px with
    | Just x -> f x
    | _-> Nothing   

// Для закона функтора 1
let id x = x
let f1 x = x + 3
let f2 x = x * 2

[<EntryPoint>]
let main argv =
    let px1 = fmapMaybe f1 (Just 2) // Just 5

    // Закон 1. Подъем функции (id) в контекст не влияет на вычисление 
    printfn "1. %O should be equal to %O" (id px1) (fmapMaybe id px1)

    // Закон 2. Для двух функций f и g композиция их подъемов эквивалентна подъему композиции.
    let px2 = fmapMaybe f1 px1 // Just 8
    let px3 = fmapMaybe f2 px2 // Just 16 
    let px4 = fmapMaybe(f1 >> f2) px1 // Just 16
    printfn "2. %O should be equal to %O" (px3) (px4)


    // Закон 1. Применение поднятой функции id к поднятому значению эквивалентно применению неподнятой функции id к неподнятому значению.
    let px5 = applyMaybe (Just f1) (Just 2) // Just 5
    printfn "1. %O should be equal to %O" (id px5) (applyMaybe (Just id) px5)

    // Закон 2. Если y=f(x), то подъем функции f и значения х и применение к ним функции apply приведет к такому же результату, что и подъем y.
    let test1 = applyMaybe (Just f1) (Just 1)
    //let test2 = applyMaybe func_f app_x - нельзя проверить средставами F#
    printfn "2. %O" test1

    // Закон 3. Аргументы apply можно менять местами
    //let t1 = applyMaybe (Just f1) (Just 1)
    //let t2 = applyMaybe (Just 1) (Just f2)
    // Не работает t2

    // Закон 4. Композиция функций apply ассоциативна. Из-за отсутствия встроенной функции <*> (apply) продемонстрировать
    // проверку данного правила невозможно.
    0
