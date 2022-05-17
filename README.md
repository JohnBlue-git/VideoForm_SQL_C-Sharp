# VideoForm_SQL_C-Sharp

A form project with video stream, image saving and image exporting functions, which is supported by WinForm, Emgu.CV and SQL.

## Confriguration of coding

Program.cpp works as the main function in where MainForm object is allocated and run as form application.

MainForm class can dynamically allocate multiple ChildForm objects in which each ChildForm object can handle one video thread

, and MainForm object will be set as parent for each ChildForm object.
