using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benner.DeveloperEvaluation.Common.Security
{
    public interface IUser
    {
        public string Id { get; }

        public string Username { get; }

        public string Role { get; }
    }
}
