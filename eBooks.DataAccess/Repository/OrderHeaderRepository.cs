using eBooks.DataAccess.Repository.IRepository;
using eBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBooks.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) :base(db)
        {
            _db=db;
        }

        public void Update(OrderHeader orderHeadertegory)
        {
            _db.OrderHeaders.Update(orderHeadertegory);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var order = _db.OrderHeaders.FirstOrDefault(u=> u.Id == id);
            if(order != null)
            {
                order.OrderStatus = orderStatus;
                if(paymentStatus != null)
                {
                    order.PaymentStatus = paymentStatus;
                }
            }
        }
    }
}
