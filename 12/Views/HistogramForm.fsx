namespace GrayScaleHistogram.Views

open System
open System.Drawing
open System.Windows.Forms

type HistogramForm(histogram : Color[][], pixelQuantifier : int, interval : int) = class
  inherit Form()

  do
    base.Text            <- "Grayscale histogram"
    base.FormBorderStyle <- FormBorderStyle.FixedSingle
    base.MaximizeBox     <- false
    base.Width           <- 1600
    base.Height          <- 800
    base.BackColor       <- Color.White
    for i in 0 .. histogram.Length-1 do
      let pixels = histogram.[i]
      let newLength = (pixels.Length/pixelQuantifier)
      if newLength <> 0 then
        let reducedPixels = pixels.[..(newLength)]
        histogram.[i] <- reducedPixels

  member this.InitializeHistogram() = this.Invalidate()

  member this.Run() = Application.Run(this)

  override this.OnPaint(e : PaintEventArgs) =
    base.OnPaint(e)

    let graphics = e.Graphics
    let brush   = new SolidBrush(Color.Black)
    let drawFont = new Font("Arial", (float32 12.0))
    let drawFormat = new StringFormat()
    let mutable x = 20 //start x position
    let mutable y = 750 //start y position
    let mutable offset = 5 //the offset between columns
    let mutable currentPixels = 0 //
    //text on the y-axis
    for i in 0 .. 1000 do
      if (i % 100 = 0) then
        graphics.DrawString((string (i * pixelQuantifier)), drawFont, brush, new PointF(float32 (x), float32 (y-i)))

    //axis
    graphics.FillRectangle(brush, new Rectangle(5, 0, 2, y))

    printfn "%d" (histogram.Length-1*offset)
    graphics.FillRectangle(brush, new Rectangle(5, y, (histogram.Length-1*offset), 2))

    //histogram, axis pointers and text on the x-axis
    for i in 0 .. histogram.Length-1 do
      x <- offset + x
      if (x % 12 = 0 || i = 0 || i = 255) then
        graphics.DrawString((string (i * interval)), drawFont, brush, new PointF(float32 (x + i), float32 (y+5)))
      for j in 0 .. (histogram.[i].Length-1) do
        graphics.FillRectangle(brush, new Rectangle((x + i), (y - j), 3, 1))

  override this.OnLoad(e : EventArgs) =
    base.OnLoad(e)
    this.DoubleBuffered <- true
end



