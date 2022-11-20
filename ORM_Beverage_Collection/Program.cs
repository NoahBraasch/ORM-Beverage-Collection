// Name: Noah Braasch
// Date: November 19 2022

using ORM_Beverage_Collection.Models;
using System;
using System.Linq;

namespace ORM_Beverage_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Console Window Size
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.WindowHeight = 40;
            Console.WindowWidth = 120;

            // Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            // Create an instance of the beverage context
            BeverageContext _beverageContext = new BeverageContext();

            // Create instance of beverage repository
            BeverageRepository _beverageRepository = new BeverageRepository(_beverageContext);

            // Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            // Display the Menu and get the response. Store the response in the choice integer
            // This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            // While the choice is not exit program
            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        // Print Entire List Of Items
                        string allItemsString = _beverageRepository.ToString();
                        if (!String.IsNullOrWhiteSpace(allItemsString))
                        {
                            // Display all of the items
                            userInterface.DisplayAllItems(allItemsString);
                        }
                        else
                        {
                            // Display error message for all items
                            userInterface.DisplayAllItemsError();
                        }
                        break;
    
                    case 2:
                        // Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();
                        string itemInformation = _beverageRepository.FindById(searchQuery);
                        if (itemInformation != null)
                        {
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }
                        break;
                        
                    case 3:
                        // Add A New Item To The List
                        string[] newItemInformation = userInterface.GetNewItemInformation();
                        if (_beverageContext.Beverages.Find(newItemInformation[0]) == null)
                        {
                            if(_beverageRepository.AddNewItem(newItemInformation) > -1)
                                userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;
                    case 4:
                        // Update an item from the list
                        string updateId = userInterface.GetUpdatedItemId();
                        if (_beverageContext.Beverages.Find(updateId) != null)
                        {
                            string[] updatedItemInformation = userInterface.GetUpdatedItemInformation();
                            _beverageRepository.UpdateItem(updateId, updatedItemInformation);
                        }
                        else 
                        {
                            userInterface.DisplayFindUpdateItemError();
                        }
                        break;
                    case 5:
                        // Remove an item from the list
                        string removeItemId = userInterface.GetRemoveItemInformation();
                        if (_beverageContext.Beverages.Find(removeItemId) != null)
                        {
                            _beverageRepository.RemoveItem(removeItemId);
                        }
                        else
                            userInterface.DisplayRemoveItemError();
                        break;

                }
                // Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }
        }
    }
}
