using System;
using FluentNHibernate.Mapping;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace FluentNHibernateDemo1
{
    class FriendMap : ClassMap<Friend>
    {
        public FriendMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Table("Friend");

        }
        

    }
}
