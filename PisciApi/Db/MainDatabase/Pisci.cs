using System;
using System.Collections.Generic;

namespace Db.MainDatabase
{
    public partial class Pisci
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Drzava { get; set; }
        public int GodinaRodjenja { get; set; }
        public bool Domaci { get; set; }
    }
}
