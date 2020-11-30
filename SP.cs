using System;

using java.io;
using edu.stanford.nlp.process;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.trees;
using edu.stanford.nlp.parser.lexparser;
using Console = System.Console;
using java.util;

namespace Stanford_Parser_Lib_C_Sharp
{
	            public class Stanford_Parser
               {
		       string path_dictionaries;   //Path to the dictionaries
		               LexicalizedParser lex_dict; //Lexical parser 
			               Tree tree_obj;  //Tree object
				               TreePrint univ_dep_tp; //TreePrint object. Universal Dependencies
					              List univ_dep;  //List of the universal dependencies


//Path where the English dictionary is saved
 private void Dir_Dictionaries(int flag_dict)
 {
                             
    switch (flag_dict - 1)
    {

      case 0:
     
	 path_dictionaries = "englishPCFG.ser.gz";

              break;

      case 1:

   break;         

     }
    
 }


 // Loading english PCFG parser from file
 private void Load_Dict()
	         {
			  
			  lex_dict = LexicalizedParser.loadModel(path_dictionaries);

		 }


 //Initialize the tokenizer
         private void Tokenizer(string text_input)
                 {
 
                             TokenizerFactory tokenizerFactory = PTBTokenizer.factory(new CoreLabelTokenFactory(), "");
                                         var text_reader = new StringReader(text_input);
                                                     var tok_raw_word = tokenizerFactory.getTokenizer(text_reader).tokenize();
 
                                                                 text_reader.close();
                                                                             tree_obj = lex_dict.apply(tok_raw_word);
 
                                                                                     }

 //Initiliaze the Penn Treebank
         private void Penn_Treebank()
                 {
 
                             PennTreebankLanguagePack ptlp = new PennTreebankLanguagePack();
                                         var gsf = ptlp.grammaticalStructureFactory();
                                                     var gs = gsf.newGrammaticalStructure(tree_obj);
                                                                 univ_dep = gs.typedDependenciesCCprocessed();
 
                                                                             // Extract collapsed dependencies from parsed tree
                                                                                         univ_dep_tp = new TreePrint("penn,typedDependenciesCollapsed");
                                                                                                     //univ_dep_tp.printTree(tree_obj);
 
                                                                                                             }	 
//Main method to extract the Universal Dependencies
        public string[] Universal_Dep(int flag_dict_selected,string txt_input, bool print_tree)
                {

                            string[] split_CD = new string[] { };
                                
                                                //Starts the chain of commands
                                                                Dir_Dictionaries(flag_dict_selected);
                                                                                Load_Dict();
                                                                                                Tokenizer(txt_input);
                                                                                                                Penn_Treebank();

         //Option to print the Tree                                                                                                                                
	if (print_tree)
                                       
	{

                                                                                                                                                                   
	univ_dep_tp.printTree(tree_obj);

 	}
																
	else

	{
                                                                                                                                                                                                                     
      //Split the Universal Dependencies to easily print them out
                                                                                                                                                                                                                                                     split_CD = univ_dep.ToString().Split(' ');

                                                                                                                                                                                                                  
	}
                                                                                                                                                                                                                                                                             return split_CD;

                                                                                                                                                                                                                                                                                    }

static void Main(string[] args) 
{

	Stanford_Parser sp = new Stanford_Parser();

//-----------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------//
	//Select the dictionary to be used
	Console.WriteLine("Select the dictionary to be used: 1) English, 2) Spanish");

	string input_dict = Console.ReadLine();

	//Check if the input is an integer
	int check_input;

	while (!int.TryParse(input_dict, out check_input))
	{

		     Console.WriteLine("A positive integer needs to be entered");

		          input_dict = Console.ReadLine();
	
	}

	Console.WriteLine("\n");

	    if (Convert.ToInt32(input_dict) == 2)
		        {

				       Console.WriteLine("The Spanish dictionary is currently unavailable");

					       
System.Environment.Exit(0);

						    }

	        if ((Convert.ToInt32(input_dict) > 2) | (Convert.ToInt32(input_dict) == 0))
			    {

				            Console.WriteLine("Invalid choice. The program will be aborted");

				System.Environment.Exit(0);

						        }
//-----------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------//



//-----------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------//
		//Choose how to print out the results
		    Console.WriteLine("Print the dependency tree: 1)True, 2) False");
		        
		    	string tree_string = Console.ReadLine(); //Select if to print the tree 		
	    
while (!int.TryParse(tree_string, out check_input))
{
     
	Console.WriteLine("A positive integer needs to be entered");
     
	tree_string = Console.ReadLine();

}     
		       
			Console.WriteLine("\n");

bool tree_bool;
    switch (Convert.ToInt32(tree_string) - 1)
	        {

		 case 0:

			tree_bool = true;

		break;

		
		 	case 1:

				tree_bool = false;
				
			break;

								        
				default:

								            
					tree_bool = true;

			Console.WriteLine("Since no valid integer has been entered, the program will select the default value of True");		

			Console.WriteLine("\n");
									            
				break;
										        
		}
//-----------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------//



//-----------------------------------------------------------------------------------//
//-----------------------------------------------------------------------------------//
//Type the command to be executed
//
    Console.WriteLine("Type the command to be executed");
        string input_string = System.Console.ReadLine(); //Type the command to be analyzed
	    Console.WriteLine("\n");

string[] universal_dep = sp.Universal_Dep(Convert.ToInt32(input_dict), input_string, tree_bool);    //Extract the Universal Dependencies


	    
	    //Print on the console the Universal Dependencies
	    for (int kk = 0; kk < universal_dep.Length - 1; kk += 2)
	    {

		    try
		            {

		                Console.WriteLine(universal_dep[kk] + universal_dep[kk + 1]);

											        }

		            catch (System.IndexOutOfRangeException) {Console.WriteLine(universal_dep[kk] + '\n'); }

		        }

}

       }



}

 
