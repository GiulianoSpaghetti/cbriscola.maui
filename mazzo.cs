/*
 *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 2.0
 *
 *  Created by numerone on 28/01/23.
 *  Copyright 2023 Some rights reserved.
 *
 */

using System;
namespace CBriscola
{
    public class Mazzo
    {
        private UInt16[] carte;
        private UInt16 numeroCarte;
        private elaboratoreCarte elaboratore;
        private void mischia()
        {
            for (numeroCarte = 0; numeroCarte < 40; numeroCarte++)
                carte[numeroCarte] = elaboratore.getCarta();
        }

        public Mazzo(elaboratoreCarte e)
        {
            elaboratore = e;
            carte = new UInt16[40];
            mischia();
        }
        public UInt16 getNumeroCarte() { return numeroCarte; }
        public UInt16 getCarta()
        {
            if (numeroCarte > 40)
                throw new IndexOutOfRangeException();
            UInt16 c = carte[--numeroCarte];
            return c;
        }
    };
}