using System;
using System.Collections.Generic;

namespace MySolidWebApi.Services
{
    public sealed class Database<T> where T : class
    {
        private static readonly Lazy<Database<T>> lazy = new Lazy<Database<T>>(() => new Database<T>());
        public static Database<T> Instance { get { return lazy.Value; } }

        private List<T> items;

        private Database()
        {
            items = new List<T>();
        }

        public List<T> GetItems()
        {
            return items;
        }

        public void AddItem(T item)
        {
            items.Add(item);
        }
    }
}