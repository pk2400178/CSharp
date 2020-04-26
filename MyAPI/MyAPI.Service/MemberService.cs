using MyAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Service
{
    public class MemberService: IMemberService
    {
        IMemberRepository memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public IEnumerable<Member> Get()
        {
            return memberRepository.Get();
        }
    }
}
