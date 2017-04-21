let reverseApply x f = f x

printfn "%i" (reverseApply 50 (fun x -> x * x))



