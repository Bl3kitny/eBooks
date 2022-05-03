using eBooks.DataAccess.Repository.IRepository;
using eBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBooks.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) :base(db)
        {
            _db=db;
        }

        public int Decrementcount(ShoppingCart cart, int count)
        {
            cart.Count -= count;
            return cart.Count;
        }

        public int IncrementCount(ShoppingCart cart, int count)
        {
            cart.Count += count;
            return count;
        }
    }
}
