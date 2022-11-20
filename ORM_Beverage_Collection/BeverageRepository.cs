// Name: Noah Braasch
// Date: November 19 2022

using ORM_Beverage_Collection.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Beverage_Collection
{
    internal class BeverageRepository : IBeverageRepository
    {
        BeverageContext _beverageContext = new BeverageContext();
        // Constructor for beverage context
        public BeverageRepository(BeverageContext beverageContext)
        { 
            _beverageContext = beverageContext;
        }
        // Converts wine database to string format to be printed
        public override string ToString()
        {
            string returnString = "";
            foreach (Beverage beverage in _beverageContext.Beverages)
            {
                if (beverage != null)
                {
                    returnString += beverage.ToString() + Environment.NewLine;
                }
            }
            return returnString;
        }
        // Querys the database for an itm with the given id
        public string FindById(string searchQuery)
        {
            string returnString = null;
            Beverage returnedBeverage = _beverageContext.Beverages.Find(searchQuery);
            if (returnedBeverage != null)
                returnString = returnedBeverage.ToString();
            return returnString;
        }
        // Gathers information for a new item and then adds it to the database
        public int AddNewItem(string[] informationToAdd)
        {
            Beverage beverageToAdd = new Beverage();
            beverageToAdd.Id = informationToAdd[0];
            beverageToAdd.Name = informationToAdd[1];
            beverageToAdd.Pack = informationToAdd[2];
            beverageToAdd.Price = Decimal.Parse(informationToAdd[3]);
            beverageToAdd.Active = Boolean.Parse(informationToAdd[4]);
            try
            {
                _beverageContext.Beverages.Add(beverageToAdd);
                _beverageContext.SaveChanges();
            }
            catch 
            {
                _beverageContext.Beverages.Remove(beverageToAdd);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error adding beverage to the database.");
                Console.ForegroundColor = ConsoleColor.Gray;
                return -1;
            }
            return 0;
        }
        // Gathers the information for which item to update and the information to change and then updates the database
        public int UpdateItem(string idToUpdate, string[] informationToUpdate)
        {
            Beverage beverageToUpdate = _beverageContext.Beverages.Find(idToUpdate);
            if (informationToUpdate[0] != null)
                beverageToUpdate.Name = informationToUpdate[0];
            if (informationToUpdate[1] != null)
                beverageToUpdate.Pack = informationToUpdate[1];
            if (informationToUpdate[2] != null)
                beverageToUpdate.Price = Decimal.Parse(informationToUpdate[2]);
            if (informationToUpdate[3] != null)
                beverageToUpdate.Active = Boolean.Parse(informationToUpdate[3]);
            try
            {
                _beverageContext.SaveChanges();
            }
            catch 
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was an error updating the item");
                Console.ForegroundColor = ConsoleColor.Gray;
                return -1;
            }
            return 0;

        }
        // Removes the item from the database with the given id
        public int RemoveItem(string idToRemove)
        {
            Beverage beverageToRemove = _beverageContext.Beverages.Find(idToRemove);
            try
            {
                _beverageContext.Beverages.Remove(beverageToRemove);
                _beverageContext.SaveChanges();
            }
            catch
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error remooving item from the database.");
                Console.ForegroundColor = ConsoleColor.Gray;
                return -1;
            }
            return 0;
        }
    }
}
