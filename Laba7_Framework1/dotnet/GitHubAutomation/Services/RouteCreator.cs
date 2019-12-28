using Framework.Models;
using GitHubAutomation.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Services
{
    class RegistrationCreator
    {
        public static Registration WithAllProperties()
        {
            return new Registration(TestDataReader.GetData("Name"));
        }
    }
}
