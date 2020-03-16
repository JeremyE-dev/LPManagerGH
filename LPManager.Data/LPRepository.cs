using LPManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPManager.Data
{
    public class LPRepository
    {
        // list of all albums in repository
        private List<LP> AllLPs;
        
        

        public LPRepository()
        {
            AllLPs = new List<LP>();
        }

        //add album to list
        public LP AddToRepo(LP x)
        {
            AllLPs.Add(x);
            return x;
        }

        //returns list of LPs
        public List<LP> ReadAll()
        {
            
            return AllLPs;
        }

        //returns LP found, if found returns informatio, otherwise returns empty object
        // 
        public LP ReadById(int Id)
        {
          
            LP LPfound = new LP();
                       
            foreach(LP x in AllLPs)
            {
                if(x.GetID() == Id)
                {
                    LPfound = x;
                    
                    break;
                }
            }


            Console.WriteLine();
            return LPfound;
        }


       //updates LP at specific index with a new LP
        public void Update(int index, LP x)
        {

            AllLPs[index] = x;

            

        }

        //searches for and removes an LP if found
        public void Delete(int id)
        {
           foreach(LP x in AllLPs)
            {
                if(x.GetID() == id)
                {
                    AllLPs.Remove(x);
                    break;
                }
            }
        }
    }
}
