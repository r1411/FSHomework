open System

let rec write_list list =
    match list with
    | [] -> ()
    | h::t ->
        printfn "%O" h
        write_list t

let remove_at idx list =
    let rec rem_at_r idx list current_idx new_list =
        match list with
        | [] -> new_list
        | h::t ->
            let new_new_list = new_list @ if current_idx <> idx then [h] else []
            let new_idx = current_idx + 1
            rem_at_r idx t new_idx new_new_list

    rem_at_r idx list 0 []

let median list =
    list |> List.sort |> List.item ((List.length list) / 2)

// Метод 6
let sort_by_median list =
    let rec sbm_r list sorted =
        match list with
        | [] -> sorted
        | h::t ->
            let med = median list
            let new_sorted = sorted @ [med]
            let new_list = remove_at ((List.length list) / 2) list 
            sbm_r new_list new_sorted

    sbm_r list []

// Совмещает 2 карты, значения дублирующихся ключей складывает
let merge_maps map1 map2 =
    Map.fold (fun accum_map key value ->
        match Map.tryFind key accum_map with
        | Some v -> Map.add key (value + v) accum_map
        | None -> Map.add key value accum_map) map1 map2

//Для строки возвращает карту: (буква -> кол-во)
let occurMap (s:string) = 
    let result = Map.empty

    let sanitized = s.Replace(" ", "").ToLower()
    let char_list = Seq.toList sanitized
    let occur_tuples = List.countBy id char_list // Создает список кортежей: (буква, кол-во)
    
    Map.ofList occur_tuples

// Для алфавита возвращает карту (буква -> кол-во)
let alphabetOccurMap strings_list =
    let rec alph_freq_r str_list occur_map =
        match str_list with
        | [] -> occur_map
        | h::t ->
            let str_occur_map = occurMap h
            let new_occur_map = merge_maps occur_map str_occur_map
            alph_freq_r t new_occur_map
    alph_freq_r strings_list Map.empty
        
// Для алфавита возвращает карту (буква -> частота)
let alphabetFreqMap strings_list = 
    let total_length = List.fold (fun accum (str:string) -> accum + str.Replace(" ", "").Length) 0 strings_list
    let occur_map = alphabetOccurMap strings_list
    Map.map (fun k v -> (double) v / (double) total_length) occur_map

// Вернуть самый частый символ в строке
let mostFreqSymbol str =
    let chars = Seq.toList str
    let str_occur_map = alphabetOccurMap [str]

    List.sortByDescending (fun ch -> str_occur_map.[ch]) chars |> List.item 0

// Метод 3
let sort_freq strings_list =
    let alphabetFreq = alphabetFreqMap strings_list
    List.sortBy (fun str -> Math.Abs((alphabetFreqMap [str]).[mostFreqSymbol str] - alphabetFreq.[mostFreqSymbol str])) strings_list

let read_list n =
    let rec read_list_r n list =
        match n with
        | 0 -> list
        | _ ->
            let new_list = list @ [Console.ReadLine()]
            let new_n = n - 1
            read_list_r new_n new_list
    
    read_list_r n []

let choose_sort = function
    | 2 -> sort_freq
    | _ -> sort_by_median

[<EntryPoint>]
let main argv =
    printfn "Кол-во строк:"
    let n = Console.ReadLine() |> Convert.ToInt32;
    printfn "Строки:"
    let list = read_list n

    printfn "Как сортируем?"
    printfn "1. В порядке увеличения медианного значения выборки строк"
    printfn "2. В порядке увеличения разницы между частотой наиболее часто встречаемого символа в строке и частотой его появления в алфавите"
    
    let method = Console.ReadLine() |> Convert.ToInt32;
    let sorted_list = list |> choose_sort method

    printfn "Отсортированный список:"
    write_list sorted_list

    0
