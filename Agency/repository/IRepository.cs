using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IRepository<ID,E> where E:Identifiable<ID>
{
    void Save(E entity);

    void Delete(ID id);

    void Update(E entity);

    E FindOne(ID id);

    IEnumerable<E> GetAll();
}

