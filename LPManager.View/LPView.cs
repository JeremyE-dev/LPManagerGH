using LPManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPManager.View
{
    public class LPView
    {
        string Artist;
        string Title;
        int ReleaseYear;
        int Id;

    //the following four methods are setter methods 
      public void SetArtist (string s)
        {
            Artist = s;
        }


      public void SetTitle(string s)
        {
            Title = s;
        }

        public void SetReleaseYear(int x)
        {
            ReleaseYear = x;
        }

        public void SetId(int x)
        {
            Id = x;
        }


        //Invite user to enter menu choice
        //validates choice is between 1 and 5
        //returns validated integer
        public int GetMenuChoice()
        {
            
            int ChoiceInteger;
            while (true)
            {
                Console.WriteLine("Please choose one of the following " +
                "\n1 Create\n2 List All\n3 Find By Id\n4 EditLP\n5 RemoveLP");
                Console.Write("Enter a number 1-5, indicating your choice:");
                string choice = Console.ReadLine();

                
                if (!ValidateInt(choice))
                {
                    Console.WriteLine("That was not a number");
                    Console.WriteLine();
                    continue;

                }

                else if (ValidateInt(choice))
                {
                    ChoiceInteger = Int32.Parse(choice);
                    if (ChoiceInteger >= 1 && ChoiceInteger <= 5)
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine("That was not a number between 1 and 5");
                        Console.WriteLine();
                        continue;
                    }

                }

            }
            Console.WriteLine();
            return ChoiceInteger;
        }

       
        //sets info  new LP to info set in viewer
        public LP GetNewLPInfo()
        {
            LP album = new LP();
            album.SetArtist(Artist);
            album.SetTitle(Title);
            album.SetReleaseYear(ReleaseYear);
            album.SetId(Id);

            return album;
        }

        //gets album information for single album and displays it
        public void DisplayLP(LP x)
        {
            Console.WriteLine("Artist: {0} Album: {1} Release Year: {2} ID: {3}", x.GetArtist(),
                x.GetTitle(), x.GetReleaseYear(), x.GetID());
        }
      
        //asks for Id number of album to find, validates it and returns it 
        public int SearchLP()
        {
           
            int IdInteger;
            while (true)
            {
                Console.Write("Enter the ID number of the LP you would like to find, " +
                    "edit or remove: ");
               
                string choice = Console.ReadLine();

               
                if (ValidateInt(choice))
                {
                    IdInteger = Int32.Parse(choice);
                    break;

                }

                else
                {
                   
                    Console.WriteLine("That was not a number");
                    continue;

                }

            }

            Console.WriteLine();
            return IdInteger;


        }

        // confirms that user would like to remove the album, returns true if yes, 
        //false otherwise
        public bool ConfirmRemoveLP(LP x)
        {   bool remove;
            
            while (true)
            {
                Console.WriteLine("Are you sure you want to remove this album?:\nID: {0}, Title: {1}, Artist: {2}, " +
                      "Release Year: {3}", x.GetID(), x.GetTitle(), x.GetArtist(), x.GetReleaseYear());
                Console.WriteLine();
                Console.Write("enter \"Y\" to REMOVE or \"N\" to CANCEL:  ");
                string YorN = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (YorN == "y")
                {
                    remove = true;
                    break;
                }

                else if (YorN == "n")
                {
                    remove = false;
                    break;
                }

                else
                {
                    Console.WriteLine("Invalid entry, please Try again");
                    continue;
                }

            }

            Console.WriteLine();
            return remove;
        }

        //returns true is input is an integer
        private bool ValidateInt(string input)
        {
            bool b;
            int output;

            if (int.TryParse(input, out output))
            {
                b = true;
            }

            else
            {
                b = false;
                Console.WriteLine("validate was false");
            }

            return b;
        }









    }
}
