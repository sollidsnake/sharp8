# Chip 8 Emulator/Interpreter

This is a Chip 8 emulator I wrote to learn C#.

- You can set (multiple) breaking points using `-d` or `--debug-at-address`
- You can pause or resume the execution with F5.
- Once paused, either by breaking points or `F5`, you can use `F10` to run the
  next instruction
- You can use `-v` to show debug information (PC, registers)
- You can use `--ips` to set number of instructions per seccond
- Run the program with `--help` for more information
- There's sound implementation as well. The program will try to load the file
  assets/beep.wav
