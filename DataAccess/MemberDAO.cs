using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Member> getMemberList()
        {
            var mems = new List<Member>();
            try
            {
                using var context = new FStoreDBAssignmentContext();
                mems = context.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return mems;
        }

        public Member GetMemberByID(int memberID)
        {
            Member mem = null;
            try
            {
                using var context = new FStoreDBAssignmentContext();
                mem = context.Members.SingleOrDefault(p => p.MemberId == memberID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return mem;
        }

        public void addNew(Member mem)
        {
            try
            {
                Member member = GetMemberByID(mem.MemberId);
                if (member == null)
                {
                    using var context = new FStoreDBAssignmentContext();
                    context.Members.Add(mem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void update(Member mem)
        {
            try
            {
                Member member = GetMemberByID(mem.MemberId);
                if (member != null)
                {
                    using var context = new FStoreDBAssignmentContext();
                    context.Members.Update(mem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void remove(int memberID)
        {
            try
            {
                Member mem = GetMemberByID(memberID);
                if (mem != null)
                {
                    using var context = new FStoreDBAssignmentContext();
                    context.Members.Remove(mem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
