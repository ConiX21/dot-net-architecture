using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Data.Objects;
using System.Linq.Expressions;

namespace Model.Repository
{
    class REPContact
    {
        private DBContactEntities _entities;

        public REPContact(DBContactEntities entities)
        {
            _entities = entities;
        }

        public IQueryable<Contact> SelectAllContact()
        {
            IQueryable<Contact> queryContact = from contact in _entities.Contact
                                               select contact;

            return queryContact;
        }

        public void ExtractValueConditionalMapping()
        {
            string queryContact = (from contact in _entities.Contact
                                   select contact).ToString();

            string[] res = queryContact.Split(new String[] { "WHERE" }, StringSplitOptions.RemoveEmptyEntries);
            string[] sorti = res[1].Split(new Char[] { '\'' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(sorti[1]);
        }
    }
}
