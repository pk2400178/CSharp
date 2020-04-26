using System.Collections.Generic;

namespace MyAPI.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> Get();
    }
}