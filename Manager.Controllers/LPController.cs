using LPManager.Data;
using LPManager.Models;
using LPManager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Controllers
{
    public class LPController
    {
        LPRepository Repo;
        LPView Viewer;

        public LPController()
        {
            Repo = new LPRepository();
            Viewer = new LPView();
        }
        public void Run()//controls process, callS related methods
        {
            while (true)
            {

                int choice = Viewer.GetMenuChoice(); // returns number between 1 and 5

                switch (choice)
                {
                    case 1: //Create
                        CreateLP();
                        break;
                    case 2: //List All
                        DisplayDVDS();
                        break;
                    case 3: // Find by ID
                        SearchLPs();
                        break;
                    case 4: //Edit
                        EditLP();
                        break;
                    case 5: //Remove
                        RemoveLP();
                        break;
                }

                if(!ContinueProgram())
                {
                    Console.WriteLine("Thank you for using LPManager, Goodbye");
                    Console.ReadLine();
                    return;
                }

                else
                {
                    Console.Clear();
                }

            }
      
        }
       

        //create an instance of an LP
        // instructs to add data
        // adds created LP to repo
        public void CreateLP()
        {
            LP album = new LP();

            while (true)
            {
                Console.WriteLine("Please enter the artist, album, release year, and ID number");
                Console.WriteLine("example: Mahavishnu Orchestra, The Inner Mounting Flame, 1971, 1");
                string original = Console.ReadLine();
                string[] stringarr = original.Split(',');

                if (stringarr.Length < 4)
                {
                    Console.WriteLine("Incomplete Information: Please enter all four elements");

                }

                else if (stringarr.Length > 4)
                {
                    Console.WriteLine("To many elements: artist, title, year, and ID number only");

                }

                else if (!ValidateInt(stringarr[2]) || !ValidateInt(stringarr[3]))
                {

                    Console.WriteLine("year and ID must be a number");

                }

                else
                {
                    Viewer.SetArtist(stringarr[0]);
                    Viewer.SetTitle(stringarr[1]);
                    Viewer.SetReleaseYear(Int32.Parse(stringarr[2]));
                    Viewer.SetId(Int32.Parse(stringarr[3]));
                    break;
                }

            }

          
            Repo.AddToRepo(Viewer.GetNewLPInfo());
            Console.ReadLine();
        }

        //asks for id from user, validates that it is a number
        //finds the LP in the Repo list
        //prints requested information
        public void SearchLPs()
        {
            
            int x = Viewer.SearchLP(); // will return the interger of the LP ID

            LP LPToBeFound = Repo.ReadById(x);

            if (LPToBeFound == null)
            {
                Console.WriteLine("There was no album in the collection with ID {0}", x);
            }

            else
            {
                Console.WriteLine("Here is the information you requested:\nID: {0}, Title: {1}, Artist: {2}, " +
                    "Release Year: {3}", LPToBeFound.GetID(), LPToBeFound.GetTitle(), LPToBeFound.GetArtist(), LPToBeFound.GetReleaseYear());
            }
        }

        //displays list of albums in repo
        //asks for ID of album to edit
        //requests new informantion
        //replaced the old LP with new one
        public void EditLP()
        {
            //1 - show list of LP's
            Console.WriteLine("Here is a List of all of your LP's");
            DisplayDVDS();
            int IdToEdit = Viewer.SearchLP(); //asks for ID of albun, validates and retruns it
            LP AlbumWithOldInfo = Repo.ReadById(IdToEdit);
            int IndexOfOldAlbum = Repo.ReadAll().IndexOf(AlbumWithOldInfo);
    
            LP EditedLP = CreateEditedLP();
            Repo.Update(IndexOfOldAlbum, EditedLP);
            Console.WriteLine();
        }

        //modifies code from CreateLP method to reflect it is edited album
        // returns the new LP instead of adding it directly to repo
        public LP CreateEditedLP()
        {
            LP album = new LP();


            while (true)
            {
                Console.WriteLine("Please enter the EDITED artist, album title, release year, and ID number");
                Console.WriteLine("here is an example: Mahavishnu Orchestra, The Inner Mounting Flame, 1971, 1");
                string original = Console.ReadLine();
                string[] stringarr = original.Split(',');

                if (stringarr.Length < 4)
                {
                    Console.WriteLine("Incomplete Information: Please enter all four elements");

                }

                else if (stringarr.Length > 4)
                {
                    Console.WriteLine("To many elements: title, artist, year, and ID number only");

                }

                else if (!ValidateInt(stringarr[2]) || !ValidateInt(stringarr[3]))
                {

                    Console.WriteLine("year and ID must be a number");

                }

                else
                {
                    Viewer.SetArtist(stringarr[0]);
                    Viewer.SetTitle(stringarr[1]);
                    Viewer.SetReleaseYear(Int32.Parse(stringarr[2]));
                    Viewer.SetId(Int32.Parse(stringarr[3]));
                    break;
                }

            }

            album = Viewer.GetNewLPInfo();

           
            Console.ReadLine();
            return album;    

        }
        
        //removes LP by ID
        // locates LP in Repo
        // asks user to confirm removal
        // deletes album from AllLPs list
        //Note: if ID does not exist or repo empty (but not null), program will display that it 
        //if removing an object but the information is empty
        //specs did not mention to handle this case specifically, but will fix if necessary for the assignment
        public void RemoveLP()
        {
            int x = Viewer.SearchLP(); // will return the interger of the LP ID

            LP LPToBeFound = Repo.ReadById(x);

            if (LPToBeFound == null)
            {
                Console.WriteLine("There was no album in the collection with ID {0}", x);
            }

            else
            {
                Console.WriteLine("you have selected to remove:\nID: {0}, Title: {1}, Artist: {2}, " +
                    "Release Year: {3}", LPToBeFound.GetID(), LPToBeFound.GetTitle(), LPToBeFound.GetArtist(), LPToBeFound.GetReleaseYear());
                Console.WriteLine("press any key to continue with removal: ");
                Console.ReadKey();
                Console.WriteLine();
                //Repo.Delete(LPToBeFound.GetID());
                
                if(Viewer.ConfirmRemoveLP(LPToBeFound))
                {
                    Repo.Delete(LPToBeFound.GetID());
                    Console.WriteLine("{0} has been deleted", LPToBeFound.GetTitle());
                }

                else
                {
                    Console.WriteLine("Removal has been cancelled");
                }

            }

        }


        //validates and returns true if input is an int, false otherwise
        private bool ValidateInt(string input)
        {
            
            int output;

            return (int.TryParse(input, out output)) ;
        }

        //Displays List of Albums in Repo
        public void DisplayDVDS()
        {
        
            foreach(LP x in Repo.ReadAll())
            {
                Viewer.DisplayLP(x);
            }

        }

        //asks user if they want to continue with program, and validates entry
        public bool ContinueProgram()
        {
            bool YN;

            while (true)
            {
                
                Console.Write("enter \"Y\" to Continue or \"N\" to QUIT:  ");
                string YorN = Console.ReadLine().ToLower();

                

                if (YorN == "y")
                {
                     YN= true;
                    break;
                }

                else if(YorN == "n")
                {
                    YN = false;
                    break;
                }

                else 
                {
                    Console.WriteLine("Invalid entry, please Try again");
                    continue;
                }

            }



            return YN; 
        }
    }
}
            
        


    

