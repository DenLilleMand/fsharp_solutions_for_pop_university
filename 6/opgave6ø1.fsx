///Lav en funktion dayToNumber : weekday -> int, der givet en ugedag returnerer et tal, hvor
///mandag skal give tallet 1, tirsdag tallet 2 osv.

type Weekday = Monday = 1 | Tuesday = 2 | Wednesday = 3 | Thursday = 4 | Friday = 5 | Saturday = 6 | Sunday = 7 

let dayToNumber weekday = (int weekday)

printfn "%i" (dayToNumber (Weekday.Tuesday))


///Lav en funktion nextDay : weekday -> weekday, der givet en ugedag returnerer den næste dag,
///så mandag skal give tirsdag, tirsdag skal give onsdag, osv, og søndag skal give mandag.

let nextDay weekday = 
    match weekday with
    | weekday when weekday >= 0 && weekday <= 7 -> Weekday.[(int weekday)]
    | _ -> 0

