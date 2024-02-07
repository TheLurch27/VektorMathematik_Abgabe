using System;

namespace VektorMathematik_Abgabe
{
    class Vektor
    {
        #region Parameter constructor and coordinator
        // Felder für die Koordinaten
        public float x;
        public float y;
        public float z;

        // Standardkonstruktor
        public Vektor()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        // Konstruktor mit Parametern
        public Vektor(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion

        #region Operator and length/square length
        // Operatorüberladung für die Addition von zwei Vektoren
        public static Vektor operator +(Vektor v1, Vektor v2)
        {
            return new Vektor(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        // Operatorüberladung für die Subtraktion von zwei Vektoren
        public static Vektor operator -(Vektor v1, Vektor v2)
        {
            return new Vektor(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        // Operatorüberladung für die Multiplikation eines Vektors mit einem Skalar
        public static Vektor operator *(Vektor v, float scalar)
        {
            return new Vektor(v.x * scalar, v.y * scalar, v.z * scalar);
        }

        // Methode zur Berechnung der Distanz zwischen zwei Vektoren
        public static float Distance(Vektor v1, Vektor v2)
        {
            float dx = v2.x - v1.x;
            float dy = v2.y - v1.y;
            float dz = v2.z - v1.z;
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        // Methode zur Berechnung der Länge eines Vektors
        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        // Methode zur Berechnung der Quadratlänge eines Vektors
        public float SquareLength()
        {
            return x * x + y * y + z * z;
        }
        #endregion

        #region ToString-Methode
        // Überschreiben der ToString-Methode für eine benutzerfreundliche Ausgabe
        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }
        #endregion
    }
}
