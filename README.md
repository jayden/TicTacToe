TicTacToe
=========

A Tic Tac Toe program written in C#.

File List
---------

	Board.cs
	GameController.cs
	GameState.cs
	Node.cs
	PerfectPlayer.cs
	Player.cs
	Program.cs
	IConsoleWrapper.cs
	ConsoleWrapper.cs
	

Setup
-----

You can also invoke the C# compiler (csc.exe) at a standard Command Prompt window to build this program. The csc.exe file is usually located in the 'Microsoft.NET\Framework\[Version]' folder under the Windows directory (replace [Version] with the .NET version installed on your computer). Assuming you have .NET v4 installed and have installed Windows on your C drive, open a command prompt window inside the root directory and use the following command:

	C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /out:TicTacToe.exe *.cs

This command will compile all the C# files in the current directory and output the program as 'TicTacToe.exe'.

How to Play
-----------

The board is set up as depicted below.

	    	   	  	 
                    |         |
               1    |    2    |   3	
                    |         |
            ________|_________|________
                    |         |
               4    |    5    |   6
                    |         |
            ________|_________|________
                    |         |
               7    |    8    |   9
                    |         |
                    |         |
            
You will be Player 'X' and will always have the first move. To select a move, type in the desired numbered space. For example, if you wanted to move to the center of the board, type in "5" (without the quotes).
