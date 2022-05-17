# VideoForm_SQL_C-Sharp

A form project with video stream, image saving and image exporting functions, which is supported by WinForm, Emgu.CV and SQL.

## Confriguration of coding

1.
Program.cs works as the main function in where MainForm object is allocated and run as form application.

where

MainForm class is defined in MainForm.cs and MainForm.Designer.cs

ChildForm class is defined in ChildForm.cs and ChildForm.Designer.cs

2.
MainForm class can dynamically allocate multiple ChildForm objects in which each ChildForm object can handle one video thread

, and MainForm object will be set as parent for each ChildForm object.

## Video Demonstration

There is a Demonstration_VideoForm.mp4 for demonstration
