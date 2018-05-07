using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierFuerVier.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public int TotalVotes
        {
            get
            {
                return Upvotes + Downvotes;
            }
        }
    }
}