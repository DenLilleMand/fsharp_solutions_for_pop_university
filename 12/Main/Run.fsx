namespace GrayScaleHistogram.Main

open System
open System.Drawing
open GrayScaleHistogram.Views
open GrayScaleHistogram.Controllers

module Run =
  [<EntryPoint>]
  let main args =
    let imageController = new ImageController();
    let columnsWanted = 256
    let pixelQuantifier = 13
    let histogram : Color [][] = imageController.GetHistogram("./coins.jpg")
    let transformedHistogramAndInterval = imageController.TransformHistogramToLessColumns(histogram, columnsWanted)
    let histogramForm = new HistogramForm((fst transformedHistogramAndInterval), pixelQuantifier, (snd transformedHistogramAndInterval))
    histogramForm.Run()
    0
