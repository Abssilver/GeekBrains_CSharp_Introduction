
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0




// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly Lesson_7_2
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- Следующий настраиваемый атрибут добавлен автоматически, не следует отменять преобразование в комментарий -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 0A 4C 65 73 73 6F 6E 5F 37 5F 32 00 00 )    // ...Lesson_7_2..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 0A 4C 65 73 73 6F 6E 5F 37 5F 32 00 00 )    // ...Lesson_7_2..
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 12 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                  20 32 30 32 31 00 00 )                            //  2021..
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 41 37 37 33 30 42 41 31 2D 30 46 41 37   // ..$A7730BA1-0FA7
                                                                                                  2D 34 33 30 33 2D 39 46 41 33 2D 44 31 44 31 38   // -4303-9FA3-D1D18
                                                                                                  41 34 37 43 37 32 39 00 00 )                      // A47C729..
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 1A 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 38 01 00 54   // ,Version=v4.8..T
                                                                                                        0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C   // ..FrameworkDispl
                                                                                                        61 79 4E 61 6D 65 12 2E 4E 45 54 20 46 72 61 6D   // ayName..NET Fram
                                                                                                        65 77 6F 72 6B 20 34 2E 38 )                      // ework 4.8
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module Lesson_7_2.exe
// MVID: {EF828C0C-584C-4894-B23B-488BE0C5D917}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00020003    //  ILONLY 32BITPREFERRED
// Image base: 0x0B3B0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit Lesson_7_2.Program
       extends [mscorlib]System.Object
{
  .method public hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Размер кода:       67 (0x43)
    .maxstack  2
    .locals init ([0] int32 userInput)
    IL_0000:  nop
    IL_0001:  ldstr      "The program for calculating of the number factorial doubled by 2 welcomes you"
    IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_000b:  nop
    IL_000c:  ldc.i4.0
    IL_000d:  stloc.0
    IL_000e:  ldloca.s   userInput
    IL_0010:  call       void Lesson_7_2.Program::GetUserInput(int32&)
    IL_0015:  nop
    IL_0016:  ldstr      "The factorial of the entered number doubled by 2 is: {0}"
    IL_001b:  ldloc.0
    IL_001c:  call       int32 Lesson_7_2.Program::CalculateFactorial(int32)
    IL_0021:  box        [mscorlib]System.Int32
    IL_0026:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_002b:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0030:  nop
    IL_0031:  ldstr      "Press any key to exit the program"
    IL_0036:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_003b:  nop
    IL_003c:  call       valuetype [mscorlib]System.ConsoleKeyInfo [mscorlib]System.Console::ReadKey()
    IL_0041:  pop
    IL_0042:  ret
  } // end of method Program::Main

  .method private hidebysig static void  GetUserInput(int32& convertedInput) cil managed
  {
    // Размер кода:       50 (0x32)
    .maxstack  3
    .locals init ([0] bool V_0)
    IL_0000:  nop
    IL_0001:  nop
    IL_0002:  ldstr      "{0}\n{1}"
    IL_0007:  ldstr      "Enter a positive number to calculate its factorial doubled by 2"
    IL_000c:  ldstr      "Input example: 3"
    IL_0011:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                  object,
                                                                  object)
    IL_0016:  nop
    IL_0017:  nop
    IL_0018:  call       string [mscorlib]System.Console::ReadLine()
    IL_001d:  ldarg.0
    IL_001e:  call       bool [mscorlib]System.Int32::TryParse(string,
                                                               int32&)
    IL_0023:  brfalse.s  IL_002c

    IL_0025:  ldarg.0
    IL_0026:  ldind.i4
    IL_0027:  ldc.i4.0
    IL_0028:  clt
    IL_002a:  br.s       IL_002d

    IL_002c:  ldc.i4.1
    IL_002d:  stloc.0
    IL_002e:  ldloc.0
    IL_002f:  brtrue.s   IL_0001

    IL_0031:  ret
  } // end of method Program::GetUserInput

  .method private hidebysig static int32 
          CalculateFactorial(int32 number) cil managed
  {
    // Размер кода:       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  brfalse.s  IL_0012

    IL_0003:  ldarg.0
    IL_0004:  ldarg.0
    IL_0005:  ldc.i4.1
    IL_0006:  sub
    IL_0007:  dup
    IL_0008:  starg.s    number
    IL_000a:  call       int32 Lesson_7_2.Program::CalculateFactorial(int32)
    IL_000f:  mul
    IL_0010:  br.s       IL_0013

    IL_0012:  ldc.i4.2
    IL_0013:  ret
  } // end of method Program::CalculateFactorial

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program::.ctor

} // end of class Lesson_7_2.Program


// =============================================================

// *********** ДИЗАССЕМБЛИРОВАНИЕ ЗАВЕРШЕНО ***********************
// ВНИМАНИЕ: создан файл ресурсов Win32 C:\GeekBrains\Введение в С#\GeekBrains_CSharp_Introduction\HomeWorks\Lesson_7_2\Lesson_7_2.res
