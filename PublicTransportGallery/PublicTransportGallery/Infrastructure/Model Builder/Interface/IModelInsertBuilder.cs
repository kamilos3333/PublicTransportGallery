using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Infrastructure.Model_Builder.Interface
{
    public interface IModelInsertBuilder<T>
    {
        void Execute(T model);
        T Rebuild(T model);
    }
}
