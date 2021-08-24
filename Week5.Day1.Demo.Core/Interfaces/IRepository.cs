using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5.Day1.Demo.Core.Interfaces
{
    public interface IRepository<T>
    {
        List<T> FetchAll();
        T GetById(int id);
        bool AddItem(T newItem);
        bool EditItem(T itemToEdit);
        bool DeleteItemById(T ItemToBeDeleted);

    }
}
