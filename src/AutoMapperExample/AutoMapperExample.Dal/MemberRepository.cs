using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMapperExample.Dal
{
    public class MemberRepository
    {
        List<Member> _members;

        public MemberRepository()
        {
            _members = new List<Member>();

            _members.Add(new Member
            {
                MemberId = 1,
                FirstName = "John",
                LastName = "Bubriski",
                Age = 28,
                State = "MA"
            });

            _members.Add(new Member
            {
                MemberId = 2,
                FirstName = "Json",
                LastName = "Bubriski",
                Age = 15,
                State = "NY"
            });

            _members.Add(new Member
            {
                MemberId = 3,
                FirstName = "Jimmy",
                LastName = "Bubriski",
                Age = 29,
                State = "CT"
            });
        }

        public Member GetMember(int id)
        {
            return _members.FirstOrDefault(m => m.MemberId == id);
        }


        public List<Member> GetMembers()
        {
            return _members;
        }
    }
}
