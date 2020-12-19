using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp.ViewModels
{
    public class RandomGameViewModel
    {
        public GameModel Game { get; set; }
        public List<CustomerModel> Customers { get; set; }
    }
}