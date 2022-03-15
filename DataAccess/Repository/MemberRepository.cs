using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(int memberID) => MemberDAO.Instance.remove(memberID);

        public Member GetMemberByID(int memberID) => MemberDAO.Instance.GetMemberByID(memberID);

        public IEnumerable<Member> GetMembers() => MemberDAO.Instance.getMemberList();

        public void InsertMember(Member member) => MemberDAO.Instance.addNew(member);

        public void UpdateMember(Member member) => MemberDAO.Instance.update(member);
    }
}
