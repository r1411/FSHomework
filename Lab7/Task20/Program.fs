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



[<EntryPoint>]
let main argv =
   
    0
