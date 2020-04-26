using System.Collections.Generic;
using MyAPI.Repository;

namespace MyAPI.Service
{
    public interface IMemberService
    {
        IEnumerable<Member> Get();
    }
}