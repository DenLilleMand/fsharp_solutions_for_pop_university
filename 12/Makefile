CC=fsharpc
FLAGS=--nologo --consolecolors+ --utf8output
NAME=--out:GrayscaleHistogram.exe
SRC=Controllers/ImageController.fsx Views/HistogramForm.fsx
RUN=Main/Run.fsx

compile:
	@echo "Compiling GrayscaleHistogram"
	@$(CC) $(FLAGS) $(NAME) $(SRC) $(RUN)
	mono GrayscaleHistogram.exe
