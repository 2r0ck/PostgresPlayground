using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresPlayGround.ViewModels
{
    public abstract class ViewModelBase<T> where T: class
    {
        protected abstract void FromDb(T data);
    }
}
