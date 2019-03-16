# File_Renamer_II

## Description

I needed a bulk renamer for my digital camera files. The camera uses an alphanumeric naming convention that is useless for knowing what the picture is about. I looked around and didn't find anything I really like so I wrote this one. It uses the Windows Management interface to catalog all the fixed and USB drives and then display them in a traditional tree view. Whatever folder you are pointing to will then be scanned for files and they will be displayed in a list box to the right of the drives. The program watches for changes in your hard drive list by attaching to system management events, particularly the USB drives, and updates the drive list. It also watches the folder for changes by attaching to another system management event and then updates the file list.

You can modify the files by replace, prefix, infix, and postfix, and filter with various options. There is a preview function so you can see your intended file name changes. Try it. You'll like it.

## The Project

It took me some time to track down and learn how to implement the various management objects and events to do all this. Just scan the source code files and you can learn alot.

This app was compiled for .Net 4.7.2 and "any cpu". You can always download the source and recompile with whichever options you prefer. I have chopped off several of the folders below the source code files to reduce the download time. All you have to do is recompile and Visual Studio (2017) will recreate them as they are working files and the 'bin' file tree for the Debug and Release compiled versions.

It would take a book to explain the management objects so I won't do it here. I suggest you just search SourceForge, CodeProject, and other sites using the management object names and/or methods to seek. The rest of the project code and components are all straight forward Windows Forms items. You can try the VS Help file but I'm not a fan.

If you're a beginning programmer in C# and Windows Forms, this might be a bit of a hard road to take. Still, nothing is more fun than meeting a challenge and winning.

I am uploading both the source files and the compiled application. That way you can test drive it and see if it looks like something you'd like to use and/or dive into the code. Either way, ENJOY!

## License

This software is licensed under the GNU General Public License Version 3 (and newer if published).
