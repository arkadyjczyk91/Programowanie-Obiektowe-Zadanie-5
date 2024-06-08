using System;

public class Macierz<T> : IEquatable<Macierz<T>> where T : IEquatable<T>
{
    private T[,] komorki;

    public Macierz(int wiersze, int kolumny)
    {
        komorki = new T[wiersze, kolumny];
    }

    public T this[int wiersz, int kolumna]
    {
        get { return komorki[wiersz, kolumna]; }
        set { komorki[wiersz, kolumna] = value; }
    }

    public static bool operator ==(Macierz<T> macierz1, Macierz<T> macierz2)
    {
        return Equals(macierz1, macierz2);
    }

    public static bool operator !=(Macierz<T> macierz1, Macierz<T> macierz2)
    {
        return !Equals(macierz1, macierz2);
    }

    public bool Equals(Macierz<T> other)
    {
        if (other == null || komorki.GetLength(0) != other.komorki.GetLength(0) || komorki.GetLength(1) != other.komorki.GetLength(1))
            return false;

        for (int i = 0; i < komorki.GetLength(0); i++)
        {
            for (int j = 0; j < komorki.GetLength(1); j++)
            {
                if (!komorki[i, j].Equals(other.komorki[i, j]))
                    return false;
            }
        }
        return true;
    }

    public override bool Equals(object obj)
    {
        if (obj is Macierz<T>)
            return Equals((Macierz<T>)obj);
        return false;
    }

    public override int GetHashCode()
    {
        // Implementacja GetHashCode powinna być dostosowana do potrzeb i może być bardziej złożona.
        return base.GetHashCode();
    }
}
class Program
{
    static void Main()
    {
        // Tworzenie macierzy o wymiarach 2x3
        Macierz<int> macierz1 = new Macierz<int>(2, 3);
        Macierz<int> macierz2 = new Macierz<int>(2, 3);

        // Wypełnianie macierzy wartościami
        macierz1[0, 0] = 1; macierz1[0, 1] = 2; macierz1[0, 2] = 3;
        macierz1[1, 0] = 4; macierz1[1, 1] = 5; macierz1[1, 2] = 6;

        macierz2[0, 0] = 1; macierz2[0, 1] = 2; macierz2[0, 2] = 3;
        macierz2[1, 0] = 4; macierz2[1, 1] = 5; macierz2[1, 2] = 6;

        // Porównanie macierzy
        if (macierz1 == macierz2)
        {
            Console.WriteLine("Macierze są równe.");
        }
        else
        {
            Console.WriteLine("Macierze nie są równe.");
        }

        // Sprawdzenie równości za pomocą IEquatable
        if (macierz1.Equals(macierz2))
        {
            Console.WriteLine("Macierze są równe (IEquatable).");
        }
        else
        {
            Console.WriteLine("Macierze nie są równe (IEquatable).");
        }
    }
}