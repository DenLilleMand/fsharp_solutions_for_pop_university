///<summary>A function that returns the multiplication table</summary>
///<param name="n">int : n is the number that decides the scale of the multiplication table</param>
///<returns> A string containing the multiplication table </returns>
let mulTable n =
   let table =
       "     1   2   3   4   5   6   7   8   9  10\n" +
       " 1   1   2   3   4   5   6   7   8   9  10\n" +
       " 2   2   4   6   8  10  12  14  16  18  20\n" +
       " 3   3   6   9  12  15  18  21  24  27  30\n" +
       " 4   4   8  12  16  20  24  28  32  36  40\n" +
       " 5   5  10  15  20  25  30  35  40  45  50\n" +
       " 6   6  12  18  24  30  36  42  48  54  60\n" +
       " 7   7  14  21  28  35  42  49  56  63  70\n" +
       " 8   8  16  24  32  40  48  56  64  72  80\n" +
       " 9   9  18  27  36  45  54  63  72  81  90\n" +
       "10  10  20  30  40  50  60  70  80  90 100\n"
   (table.[..(((n + 1)*43)-1)])

printfn "%s" "Med \%A : \n"
printfn "%A" (mulTable 10)
printfn "%s" "Med \%s : \n"
printfn "%s" (mulTable 10)

///forskellen på %A og %s er at %A tager imod data strukturer som  tuples, records og 
///union typer og printer dem pænt, som vi ser her beholder den citationstegnene
///på vores String, og hvis vi havde et array ville den beholde brackets. %s tager kun
///imod en string og printer så blot værdien uden citations tegnene, som i det
///her tilfælde er pænest.


