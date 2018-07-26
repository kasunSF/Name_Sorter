# Code Quality Assessment

## Getting Started
* This is a Visual Studio 2015 project that sort names
* Framework: .Net Framework 4.5.2

Default Configurations(App.config)

```
Input_File_Name = unsorted-names-list.txt
```
```
Output_File_Name = sorted-names-list.txt
```

## Code execution
Make sure that input file with Input\_File\_Name is available at working directory of the system. Input file should contain names to be sorted. 
> **Note:** A name must have at least 1 given name and last name. A name may have up to 3 given names.


### Command to execute

Absence of command-line argument will read input file that has Input_File_Name from current working directory

```
name-sorter
```

If command-line argument is provided, it will read input file in that path.

```
name-sorter ./unsorted-names-list.txt
```

### Output
Output will be shown on console with key prompt to exit program. Output will be written to the current working directory with the Output\_File\_Name.

> **Note:** If there already exists a file with Output_File_Name, it will be renamed appending current time stamp to the file name.


[Name_Sorter](https://github.com/kasunSF/Name\_Sorter)
