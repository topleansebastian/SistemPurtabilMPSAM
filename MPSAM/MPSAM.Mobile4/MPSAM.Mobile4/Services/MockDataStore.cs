using MPSAM.Mobile4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPSAM.Mobile4.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        public List<Activitate> activitati;

        public static MockDataStore Instance = new MockDataStore();
        private MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
            activitati = new List<Activitate>()
            {
                new Activitate(){ ID=1, Data = DateTime.Now.Date.AddDays(-1), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
                new Activitate(){ ID=2, Data = DateTime.Now.Date.AddDays(0), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
                new Activitate(){ ID=3, Data = DateTime.Now.Date.AddDays(1), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
                new Activitate(){ ID=4, Data = DateTime.Now.Date.AddDays(2), Nume="NumeActivitate1", Descriere="Descriere ActivitateThis is Cool event1's description!This is Cool event1's description!This is Cool event1's description!"},
                new Activitate(){ ID=5, Data = DateTime.Now.Date.AddDays(3), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
                new Activitate(){ ID=6, Data = DateTime.Now.Date.AddDays(4), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
                new Activitate(){ ID=7, Data = DateTime.Now.Date.AddDays(5), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
                 new Activitate(){ ID=1, Data = DateTime.Now.Date.AddDays(-1), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
                new Activitate(){ ID=2, Data = DateTime.Now.Date.AddDays(0), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
                new Activitate(){ ID=3, Data = DateTime.Now.Date.AddDays(1), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
                new Activitate(){ ID=4, Data = DateTime.Now.Date.AddDays(2), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
                new Activitate(){ ID=5, Data = DateTime.Now.Date.AddDays(3), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
                new Activitate(){ ID=6, Data = DateTime.Now.Date.AddDays(4), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
                new Activitate(){ ID=7, Data = DateTime.Now.Date.AddDays(5), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
                 new Activitate(){ ID=1, Data = DateTime.Now.Date.AddDays(-1), Nume="NumeActivitate1", Descriere="Descriere Activitate"},
            
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}