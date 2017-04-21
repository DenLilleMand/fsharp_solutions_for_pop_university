///eulers better guess at square root,   x g = (g + x/g)/2     ... i think that x is the number we wan't to find the square root for. And y is the number we're attemping.
///So we could e.g.  give the recursive function x=4 ... then the check is if  y^2 = x     and if   y=x/y   

let rec squareRoot x y =
    if y >= 0 then 
        printf "%d" y
