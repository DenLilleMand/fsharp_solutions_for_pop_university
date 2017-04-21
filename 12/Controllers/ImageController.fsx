namespace GrayScaleHistogram.Controllers

open System
open System.Drawing
open Microsoft.FSharp.Collections

type ImageController() = class

  member this.GetHistogram(imageFile : string)  =
    let bitMap = new Bitmap(imageFile)
    let mutable histogram = Array.create 256 [| |]
    for heightIndex in 0 .. (bitMap.Height-1) do
      for widthIndex in 0 .. (bitMap.Width-1) do
        let pixel : Color = bitMap.GetPixel(widthIndex, heightIndex)
        let pixelIndex = (int (pixel.R + pixel.G + pixel.B))/3
        histogram.[pixelIndex] <- (Array.append (histogram.[pixelIndex]) [|pixel|])
    (histogram)

  member this.TransformHistogramToLessColumns(histogram : Color[][], columns : int) =
    let interval = int (Math.Ceiling(float(histogram.Length / columns)))
    let mutable newHistogram : Color[][] = Array.create ((histogram.Length/interval)) [| |]
    let mutable newHistogramIndex = 0
    for i in 0 .. (histogram.Length-1) do
      if i = 0 then
        newHistogram.[newHistogramIndex] <- Array.concat (seq { for k in 0 .. 0 do yield histogram.[k] })
        newHistogramIndex <- newHistogramIndex + 1
      else if (i % interval = 0) then
        newHistogram.[newHistogramIndex] <- Array.concat (seq { for k in ((i - interval)+1) .. i do yield histogram.[k] })
        newHistogramIndex <- newHistogramIndex + 1
    (newHistogram, interval)
end
