using System;
using System.Collections.Generic;

namespace hungryNinja
{

    public class Food
    {
        public string Name { get; set; }
        public int Calories { get; set; } = 359;
        public bool IsSpicy { get; set; } = false;
        public bool IsSweet { get; set; } = false;

        public string GetInfo()
        {
            return $"Your { Name } has { Calories } calories. Is it sweet? { IsSweet }. Is it spicy? { IsSpicy }.";
        }
        // add a Food constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet
        public Food(string name, int calories, bool spicy, bool sweet)
        {
            Name = name;
            Calories = calories;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }
    class Buffet
    {
        public List<Food> Menu;
        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Burrito", 500, false, false),
                new Food("Pepperoni Pizza", 250, false, true),
                new Food("Cookie", 295, false, false),
                new Food("Garlic Wing", 175, false, true),
                new Food("Cheeseburger", 650, true, false),
            };
        }
        public Food Serve()
        {
            Random randFood = new Random();
            int randInt = randFood.Next(Menu.Count);
            return Menu[randInt];
        }
    }
    class Ninja
    {
        public Ninja() // add a constructor
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }
        private int calorieIntake;
        public List<Food> FoodHistory;
        public bool IsFull { get; set; } // add a public "getter" property called "IsFull"
        public void Eat(Food item) // build out the Eat method
        {
            if (calorieIntake <= 1200)
            {
                calorieIntake += item.Calories;
                FoodHistory.Add(item);
                item.GetInfo();
                IsFull = false;
            }
            else
            {
                Console.WriteLine("The Ninja is full!");
                IsFull = true;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var Ryan = new Ninja();
            var newBuffet = new Buffet();
            while (!Ryan.IsFull)
            {
                Ryan.Eat(newBuffet.Serve());
            }
            Console.WriteLine(Ryan);
            Console.Write("The Ninja ate: ");
            foreach (var food in Ryan.FoodHistory)
            {
                Console.Write($"{food.Name}: {food.Calories} cal; ");
            }
            Console.WriteLine();
        }
    }
}