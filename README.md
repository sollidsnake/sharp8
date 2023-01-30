# Chip 8 Emulator/Interpreter

This is a Chip 8 emulator I wrote to learn C#. The core is decoupled from the
UI, so it's possible to implement it using any UI library. For this project I
implemented using SFML.

## Build
To run, `cd` into `src/Sharp8.UI` and run `dotnet run [chip 8 rom file]`. You
  need Dotnet 7 SDK.

## Debugging
- You can set (multiple) breaking points using `-d` or `--debug-at-address`
- You can pause or resume the execution with F5.
- Once paused, either by breaking points or `F5`, you can use `F10` to run the
  next instruction

## Other commands
- You can use `-v` to show debug information (PC, registers)
- You can use `--ips` to set number of instructions per second
- Run the program with `--help` for more information

## Sound
This emulator has sound implementation as well. The program will try to load the
  file assets/beep.wav
