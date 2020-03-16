using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPManager.Models
{
    public class LP
    {
        private int Id;
        private string Title;
        private int ReleaseYear;

        private string Artist;


        //public LP ()
        //{

        //}


        public void SetId(int x)
        {
            Id = x;
        }

        public void SetTitle(string s)
        {
            Title = s;
        }

        public void SetReleaseYear(int x)
        {
            ReleaseYear = x;
        }

        public void SetArtist(string s)
        {
            Artist = s;
        }

        public int GetID()
        {
            return Id;
        }

        public int GetReleaseYear()
        {
            return ReleaseYear;
        }

        public string GetArtist()
        {
            return Artist;
        }

        public string GetTitle()
        {
            return Title;
        }
            

        



        
    }
}
