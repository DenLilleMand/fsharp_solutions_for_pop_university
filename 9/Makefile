FSHARPCONF=--utf8output --nologo --consolecolors+
FSC=fsharpc $(FSHARPCONF)

default:
	@$(FSC) Car.fsx

tests:
	@$(FSC) TestLib.fs Car.fsx CarTests.fsx TestRunner.fsx
	@mono TestRunner.exe


