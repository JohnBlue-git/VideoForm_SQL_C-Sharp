# VideoForm_SQL_C-Sharp

A form project with video stream, image saving and image exporting functions, which is supported by WinForm, Emgu.CV and SQL.

## Confriguration of coding

MDI.cpp works as the main function in which MainForm object is runing as an application.

MainForm class can dynamically allocate multiple MyForm object, and MainForm object will be set as parent for every MyForm objects.

Each MyForm object can handle one video thread.

Additionally, template linkedlist class have been employed fully over this project.
