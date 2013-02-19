using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStoreApp.MVC.Domain.Entities;
using SportsStoreApp.MVC.Domain.Concrete;

namespace SportsStoreApp.MVC.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails details);
    }
}
