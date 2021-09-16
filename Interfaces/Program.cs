using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.WebSockets;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            EatStuff(new Bread());
        }

        private static void EatStuff(IEdible edible)
        {
            throw new NotImplementedException();
        }
    }
}

interface IEdible
{
    static int temp = 5;

    void Eat()
    {
        Console.WriteLine("Mums");
    }
}

public class Bread : IThrowable, IEdible
{
    public int Range { get; set; }

    public void OnHit()
    {
        throw new NotImplementedException();
    }
}

public abstract class Weapon
{
}

interface IThrowable
{
    public int Range { get; set; }

    void Throw()
    {
        Console.WriteLine("Kastat grejen!");
        OnHit();
    }

    void OnHit();
}

class Axe : Weapon, IThrowable
{
    public int Range { get; set; }

    public void OnHit()
    {
        DoDamage();
    }

    public void DoDamage()
    {
        Console.WriteLine("En massa skada!");
    }
}

class Nunchaku : Weapon
{
}

class FirePotion : IThrowable
{
    public int Range { get; set; }

    public void OnHit()
    {
        Console.WriteLine("Träffade!");
    }
}

class Limpa : Bread
{
}

class Rat : IThrowable
{
    public int Range { get; set; }

    public void OnHit()
    {
        throw new NotImplementedException();
    }
}

/*
 * Weapon
 * Axe
 * Spear
 * Nunchaku
 *
 * Potion
 * HealingPotion
 * FirePotion
 *
 * Animal
 * Horse
 * Rat
 *
 * Food
 * Bread
 * Soup
 *
 * */