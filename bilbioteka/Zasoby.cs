﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilbioteka
{
    internal class Zasoby
    {
        public Zasoby(string tytul, string autor, int rokWydania, int numerKatalogowy, string typ, bool czyWypozyczone, float ocena, int ilosc, string kategoria)
        {
            Tytul = tytul;
            Autor = autor;
            RokWydania = rokWydania;
            NumerKatalogowy = numerKatalogowy;
            Typ = typ;
            CzyWypozyczone = czyWypozyczone;
            Ocena = ocena;
            Ilosc = ilosc;
            Kategoria = kategoria;


        }

        public string Tytul { get; set; }
        public string Autor { get; set; }
        public int RokWydania { get; set; }
        public int NumerKatalogowy { get; set; }
        public string Typ { get; set; }
        public bool CzyWypozyczone { get; set; }
        public float Ocena {  get; set; }
        public int Ilosc {  get; set; } 
        public string Kategoria { get; set; }
    }
}
