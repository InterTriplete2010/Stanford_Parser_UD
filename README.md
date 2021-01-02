# Stanford_Parser_UD

This is a very simple program to get people started to extract Universal Dependencies with the Stanford Parser by using C#. The program was written in Ubuntu 20.04 and is based on Sergey Tihon's library (https://sergey-tihon.github.io/Stanford.NLP.NET/StanfordParser.html). 

I am adding a few basic instructions that (I hope) will be useful to compile (if the user wants to make changes) and run the code.

1) Make sure you have Mono installed in Ubuntu (https://www.mono-project.com/download/stable/#download-lin)

2) Create a global path for the libraries: export MONO_PATH=/path_to/Stanford.NLP.CoreNLP.3.9.2.0/lib:/path_to/Stanford_Parser/IKVM.8.1.5717.0/lib. Or as an alternative, copy and paste the libraries stored in IKVM.8.1.5717.0/lib and stanford-corenlp-3.9.2.dll into the folder where the ".exe" file is saved

3) Compile the code: csc SP.cs -r:/path_to/IKVM.8.1.5717.0/lib/IKVM.OpenJDK.Core.dll -r:/path_to/Stanford.NLP.CoreNLP.3.9.2.0/lib/stanford-corenlp-3.9.2.dll

4) Run the exe file: mono SP.exe


How the program works:

1) First the user will be asked to select the dictionary to be used. Even though there are 2 options, at this moment only the English dictionary is available.

Select the dictionary to be used: 1) English, 2) Spanish


2) Then the user will be asked to select if the dependency tree will be printed:

Print the dependency tree: 1)True, 2) False


3) Finally the user will be asked to type in the command that will be parsed:

Type the command to be executed


Example
If the user selects English, True and types the following command "Robot, get the milk on the table", the output will look like this:

(ROOT
  (S
    (VP (VB Robot) (, ,) (VB get)
      (NP (DT the) (NN milk))
      (PP (IN on)
        (NP (DT the) (NN table))))))

root(ROOT-0, Robot-1)
dep(Robot-1, get-3)
det(milk-5, the-4)
dobj(Robot-1, milk-5)
case(table-8, on-6)
det(table-8, the-7)
nmod:on(Robot-1, table-8)

If you have any question and/or want to report bugs, please e-mail me (Ale) at: pressalex@hotmail.com
