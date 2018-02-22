using Captions.DataMap;
using Captions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Captions.Service
{
    public class ApplicationService
    {

        public static string GetApplicationServiceValue(string propertyName)
        {
            var ctx = new DataContext();
            return ctx.ApplicationValues.SingleOrDefault(x => x.Name == propertyName).Value;
        }
    }
}