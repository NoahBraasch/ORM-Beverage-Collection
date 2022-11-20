// Name: Noah Braasch
// Date: November 19 2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Beverage_Collection
{
    internal interface IBeverageRepository
    {
        int AddNewItem(string[] itemString);
        int UpdateItem(string id, string[] updatedInformation);
        int RemoveItem(string id);
        string ToString();
        public string FindById(string id);
    }
}
